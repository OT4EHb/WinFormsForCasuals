using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App2
{
    public partial class DataBox<T> : Form where T : class, new()
    {
        private readonly MySqlConnection _connection;
        private readonly bool _isNewItem;
        public T Item { get; set; }
        private TableLayoutPanel _mainLayout;
        public Dictionary<string, Control> FieldControls { get; set; }
        public Dictionary<string, Label> FieldLabels { get; set; }
        private FlowLayoutPanel _buttonPanel;
        static string tableName { get => typeof(T).GetCustomAttribute<TableNameAttribute>()!.Name; }

        private DataBox(MySqlConnection connection,  bool isNewItem)
        {
            _connection = connection;
            _isNewItem = isNewItem;
            FieldControls = [];
            FieldLabels = [];
        }

        public DataBox(MySqlConnection connection, T? item = null)
        {
            _connection = connection;
            Item = item ?? new T();
            _isNewItem = item == null;
            FieldControls = [];
            FieldLabels = [];

            InitializeComponent();
            BuildForm();
            LoadData();
            if (!_isNewItem)
            {
                foreach (var i in FieldControls)
                {
                    if (typeof(T).GetProperty(i.Key)!.GetCustomAttribute<ForeignKeyAttribute>() != null)
                    {
                        i.Value.Enabled = false;
                        FieldLabels[i.Key].Enabled = false;
                    }
                }
            }
        }

        public static async Task<DataBox<T>> AsyncInit(MySqlConnection connection, T? item = null)
        {
            var instance = new DataBox<T>(connection, item == null);
            instance.Item = item??new T();
            instance.InitializeComponent();
            instance.BuildForm();
            await instance.LoadData();
            if (!instance._isNewItem)
            {
                foreach (var i in instance.FieldControls)
                {
                    if (typeof(T).GetProperty(i.Key)!.GetCustomAttribute<ForeignKeyAttribute>() != null)
                    {
                        i.Value.Enabled = false;
                        instance.FieldLabels[i.Key].Enabled = false;
                    }
                }
            }
            return instance;
        }

        private void BuildForm()
        {
            var displayName = typeof(T).GetCustomAttribute<DisplayNameAttribute>()!.DisplayName;
            this.Text = _isNewItem ? $"Добавление {displayName}" : $"Редактирование {displayName}";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Padding = new Padding(10);
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            _mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                ColumnCount = 2,
                Padding = new Padding(10),
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None
            };

            _mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            _mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));

            var titleLabel = new Label
            {
                Text = displayName,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Height = 40
            };
            _mainLayout.Controls.Add(titleLabel, 0, 0);
            _mainLayout.SetColumnSpan(titleLabel, 2);

            var properties = typeof(T).GetProperties();

            int row = 1;
            foreach (var prop in properties)
            {
                CreateFieldRow(prop, ref row);
            }

            _mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            _mainLayout.Controls.Add(new Panel(), 0, row);
            _mainLayout.SetColumnSpan(_mainLayout.GetControlFromPosition(0, row)!, 2);
            row++;

            _buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                Height = 40,
                Padding = new Padding(0, 5, 0, 0)
            };

            var btnCancel = new Button
            {
                Text = "Отмена",
                Size = new Size(100, 30),
                DialogResult = DialogResult.Cancel,
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; Close(); };

            var btnOk = new Button
            {
                Text = "OK",
                Size = new Size(100, 30),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
            };
            btnOk.Click += (s, e) =>
            {
                this.DialogResult = SaveData() ? DialogResult.OK : DialogResult.Cancel;
                Close();
            };
            
            _buttonPanel.Controls.Add(btnCancel);
            _buttonPanel.Controls.Add(btnOk);
            _mainLayout.Controls.Add(_buttonPanel, 0, row);
            _mainLayout.SetColumnSpan(_buttonPanel, 2);
            this.Controls.Add(_mainLayout);
            this.MinimumSize = new Size(500, 300);
        }

        private void CreateFieldRow(PropertyInfo prop, ref int row)
        {
            if (prop.GetCustomAttribute<IsPrimaryKeyAttribute>()?.AutoIncrement == true) return;
            var displayAttr = prop.GetCustomAttribute<DisplayNameAttribute>();
            string displayName = displayAttr?.DisplayName ?? prop.Name;

            var label = new Label
            {
                Text = displayName + ":",
                TextAlign = ContentAlignment.TopRight,
                AutoSize = true,
                Dock = DockStyle.Fill,
                Padding = new Padding(0, 5, 10, 0),
                Font = new Font("Segoe UI", 10F),
                Height = 50,
            };

            var control = CreateInputControl(prop);
            control.Dock = DockStyle.Fill;
            control.Margin = new Padding(0, 2, 10, 5);

            _mainLayout.Controls.Add(label, 0, row);
            _mainLayout.Controls.Add(control, 1, row);

            _mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));

            FieldLabels[prop.Name] = label;
            FieldControls[prop.Name] = control;

            row++;
        }

        static private ComboBox CreateForeignKeyComboBox(ForeignKeyAttribute fkAttr)
        {
            return new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 200,
                Tag = fkAttr
            };
        }

        private Control CreateInputControl(PropertyInfo prop)
        {
            var fkAttr = prop.GetCustomAttribute<ForeignKeyAttribute>();
            if (fkAttr != null)
            {
                return CreateForeignKeyComboBox(fkAttr);
            }

            Type propType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

            if (propType == typeof(bool))
            {
                return new CheckBox
                {
                    Text = "",
                    AutoSize = true,
                    Height = 25
                };
            }
            else if (propType == typeof(DateTime))
            {
                return new DateTimePicker
                {
                    Format = DateTimePickerFormat.Short,
                    Width = 200,
                    ShowCheckBox = Nullable.GetUnderlyingType(prop.PropertyType) != null
                };
            }
            else if (propType.IsEnum)
            {
                var comboBox = new ComboBox
                {
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Width = 200,
                    DataSource = Enum.GetValues(propType)
                };
                return comboBox;
            }
            else
            {
                var textBox = new TextBox { Width = 200 };

                if (propType == typeof(int) || propType == typeof(decimal) ||
                    propType == typeof(double) || propType == typeof(float) ||
                    propType == typeof(uint))
                {
                    textBox.KeyPress += NumericTextBox_KeyPress;
                }

                return textBox;
            }
        }

        private void NumericTextBox_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private async Task LoadData()
        {
            await LoadForeignKeyData();

            if (_isNewItem) return;

            foreach (var prop in typeof(T).GetProperties())
            {
                if (FieldControls.TryGetValue(prop.Name, out var control))
                {
                    var value = prop.GetValue(Item)!;
                    SetControlValue(control, _isNewItem?null:value);
                }
            }
        }
        
        public void ItemSyncForm()
        {
            foreach (var prop in typeof(T).GetProperties())
            {
                if (FieldControls.TryGetValue(prop.Name, out var control))
                {
                    var value = prop.GetValue(Item)!;
                    SetControlValue(control, value);
                }
            }
        }

        static private void SetControlValue(Control control, object? value)
        {
            switch (control)
            {
                case TextBox textBox:
                    textBox.Text = value?.ToString() ?? "";
                    break;
                case CheckBox checkBox:
                    checkBox.Checked = value as bool? ?? false;
                    break;
                case DateTimePicker datePicker:
                    if (value != null)
                    {
                        datePicker.Value = (DateTime)value;
                        datePicker.Checked = true;
                    }
                    else
                    {
                        datePicker.Checked = false;
                    }
                    break;
                case ComboBox comboBox:
                    if (value != null)
                    {
                        comboBox.SelectedValue = value;
                    }
                    else
                    {
                        comboBox.SelectedIndex = 0;
                    }
                        break;
            }
        }

        private async Task LoadForeignKeyData()
        {
            foreach (var prop in typeof(T).GetProperties())
            {
                var fkAttr = prop.GetCustomAttribute<ForeignKeyAttribute>();
                if (fkAttr != null && FieldControls.TryGetValue(prop.Name, out var control))
                {
                    if (control is ComboBox comboBox)
                    {
                        await PopulateComboBox(comboBox, fkAttr);
                    }
                }
            }
        }

        private async Task PopulateComboBox(ComboBox comboBox, ForeignKeyAttribute fkAttr)
        {
            string query = $"SELECT {fkAttr.ReferenceColumn}, {fkAttr.DisplayColumn} FROM {fkAttr.ReferenceTable}";

            var items = new List<KeyValuePair<object, string>>();

            using var cmd = new MySqlCommand(query, _connection);
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var value = reader[fkAttr.ReferenceColumn];
                var display = reader[fkAttr.DisplayColumn].ToString();
                items.Add(new KeyValuePair<object, string>(value, display ?? ""));
            }

            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
            comboBox.DataSource = items;
        }

        public bool SaveData()
        {
            try
            {
                foreach (var prop in typeof(T).GetProperties())
                {
                    if (FieldControls.TryGetValue(prop.Name, out var control))
                    {
                        var value = GetControlValue(control, prop.PropertyType);
                        prop.SetValue(Item, value);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        static private object? GetControlValue(Control control, Type targetType)
        {
            switch (control)
            {
                case TextBox textBox:
                    {
                        string text = textBox.Text.Trim();
                        if (string.IsNullOrEmpty(text)) return null;

                        Type underlyingType = Nullable.GetUnderlyingType(targetType) ?? targetType;

                        if (underlyingType == typeof(string)) return text;
                        if (underlyingType == typeof(int)) return int.Parse(text);
                        if (underlyingType == typeof(decimal)) return decimal.Parse(text);
                        if (underlyingType == typeof(double)) return double.Parse(text);
                        if (underlyingType == typeof(uint)) return uint.Parse(text);
                        break;
                    }
                case CheckBox checkBox:
                    return checkBox.Checked;

                case DateTimePicker datePicker:
                    return datePicker.Checked ? datePicker.Value : (DateTime?)null;

                case ComboBox comboBox:
                    if (comboBox.SelectedItem is KeyValuePair<object, string> kvp)
                    {
                        object keyValue = kvp.Key;
                        if (keyValue == null) return null;
                        Type underlyingType = Nullable.GetUnderlyingType(targetType) ?? targetType;
                        if (keyValue is uint uintValue && underlyingType == typeof(int))
                        {
                            return (int)uintValue;
                        }
                        if (keyValue is ulong ulongValue && underlyingType == typeof(long))
                        {
                            return (long)ulongValue;
                        }
                        return Convert.ChangeType(keyValue, underlyingType);
                    }
                    if (comboBox.SelectedItem != null && targetType.IsEnum)
                    {
                        return comboBox.SelectedItem;
                    }
                    return comboBox.SelectedItem;
            }
            return null;
        }
    }
}

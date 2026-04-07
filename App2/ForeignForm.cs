using App2.DataClass;
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
    public partial class ForeignForm<D,T> : Form 
        where D:class,new()
        where T : class,new() 
    {
        readonly MySqlConnection conn;
        DataTable dt = new();
        DataTable dt2 = new();
        readonly DataSet ds = new();
        readonly DataSet ds2 = new();
        string TableNameD{get=> typeof(D).GetCustomAttribute<TableNameAttribute>()!.Name; }
        string TableNameT { get => typeof(T).GetCustomAttribute<TableNameAttribute>()!.Name; }
        string DisplayD { get=> typeof(D).GetCustomAttribute<DisplayNameAttribute>()!.DisplayName; }
        string DisplayT { get=> typeof(T).GetCustomAttribute<DisplayNameAttribute>()!.DisplayName; }
        PropertyInfo Foreign { get => TableUtils.getForeign<D, T>()!; }
        PropertyInfo PrimaryD { get => TableUtils.getPrimary<D>()!; }
        PropertyInfo PrimaryT { get => TableUtils.getPrimary<T>()!; }

        public ForeignForm(MySqlConnection connection)
        {
            conn = connection;
            InitializeComponent();
            this.Text = $"Таблица {TableNameD}";
            UpdateD();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void UpdateD()
        {
            var cell = gridD.CurrentRow;
            using MySqlCommand command = new($"Select * from {TableNameD}", conn);
            using MySqlDataAdapter da = new(command);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            gridD.DataSource = dt;
            for (int i = 0; i < gridD.ColumnCount; i++)
            {
                gridD.Columns[i].HeaderText = 
                    typeof(D).GetProperties()[i].GetCustomAttribute<DisplayNameAttribute>()!.DisplayName;
            }
            UpdateT();
        }

        private void UpdateT()
        {
            var row = gridD.CurrentRow;
            if (row == null) return;
            var cell = row.Cells[PrimaryD.GetCustomAttribute<ColumnNameAttribute>()!.Name].Value;
            using MySqlCommand command1 =
                new($"Select * from {TableNameT} where {Foreign.GetCustomAttribute<ColumnNameAttribute>()!.Name}=@id",
                conn);
            command1.Parameters.AddWithValue("id", cell);
            using MySqlDataAdapter da1 = new(command1);
            ds2.Reset();
            da1.Fill(ds2);
            dt2 = ds2.Tables[0];
            gridT.DataSource = dt2;
            for (int i = 0; i < gridT.ColumnCount; i++)
            {
                gridT.Columns[i].HeaderText 
                    = typeof(T).GetProperties()[i].GetCustomAttribute<DisplayNameAttribute>()!.DisplayName;
            }
        }

        private void addItem<Type>(bool foreign) where Type : class, new()
        {
            var tableName = typeof(Type).GetCustomAttribute<TableNameAttribute>()!.Name;
            var formTask = DataBox<Type>.AsyncInit(conn);
            formTask.ContinueWith(t =>
            {
                using var form = t.Result;
                form.SaveData();
                if (foreign)
                {
                    string key = Foreign.GetCustomAttribute<ColumnNameAttribute>()!.Name;
                    var value = gridD.CurrentRow.Cells[PrimaryT.GetCustomAttribute<ColumnNameAttribute>()!.Name].Value;
                    Foreign.SetValue(form.Item, value);
                    form.ItemSyncForm();
                    form.FieldControls[key].Enabled = false;
                    form.FieldLabels[key].Enabled = false;

                }
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var properties = typeof(Type).GetProperties();

                    var columnNames = properties.Select(p => p.GetCustomAttribute<ColumnNameAttribute>()!.Name).ToList();
                    var paramNames = properties.Select(p => "@" + p.Name).ToList();

                    string sql = $@"
            INSERT INTO {tableName}
            ({string.Join(", ", columnNames)})
            VALUES ({string.Join(", ", paramNames)})";
                    using var command = new MySqlCommand(sql, conn);
                    foreach (var i in properties)
                    {
                        command.Parameters.AddWithValue(
                            i.GetCustomAttribute<ColumnNameAttribute>()!.Name,
                            i.GetValue(form.Item)
                            );
                    }
                    command.ExecuteNonQuery();
                    UpdateD();
                }
            });
        }

        private void replaceItem<Type>(DataGridView grid) where Type : class, new()
        {
            var row = grid.CurrentRow;
            if (row == null)
            {
                return;
            }

            var item = new Type();
            var properties = typeof(Type).GetProperties();
            foreach (var prop in properties)
            {
                string columnName = prop.Name;
                var columnAttr = prop.GetCustomAttribute<ColumnNameAttribute>();
                if (columnAttr != null)
                    columnName = columnAttr.Name;
                if (grid.Columns.Contains(columnName))
                {
                    var cellValue = row.Cells[columnName].Value;
                    if (cellValue != null && cellValue != DBNull.Value)
                    {
                        try
                        {
                            var convertedValue = Convert.ChangeType(cellValue, prop.PropertyType);
                            prop.SetValue(item, convertedValue);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"Ошибка конвертации для {prop.Name}: {ex.Message}");
                        }
                    }
                }
            }

            using DataBox<Type> form = new(conn, item);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var tableName = typeof(Type).GetCustomAttribute<TableNameAttribute>()!.Name;
                List<string> keys = [];
                var primary = TableUtils.getPrimary<Type>()!;
                var primaryKey = primary.GetCustomAttribute<ColumnNameAttribute>()!.Name;
                var primaryVal = primary.GetValue(item);

                foreach (var prop in properties)
                {
                    if (prop.GetCustomAttribute<ForeignKeyAttribute>() != null)
                    {
                        continue;
                    }
                    string key = prop.GetCustomAttribute<ColumnNameAttribute>()!.Name;
                    keys.Add($@"{key}=@{key}");
                }
                string sql = $@"
            UPDATE {tableName}
            SET {string.Join(", ", keys)}
            WHERE {primaryKey} = @primaryVal";
                using var command = new MySqlCommand(sql, conn);
                foreach (var i in properties)
                {
                    if (i.GetCustomAttribute<IsPrimaryKeyAttribute>() != null) continue;
                    command.Parameters.AddWithValue(
                        i.GetCustomAttribute<ColumnNameAttribute>()!.Name,
                        i.GetValue(form.Item)
                        );
                }
                command.Parameters.AddWithValue("primaryVal", primaryVal);
                var res = command.ExecuteNonQuery();
                UpdateD();
            }
        }

        private void deleteItem<Type>(DataGridView grid)
        {
            var tableName = typeof(Type).GetCustomAttribute<TableNameAttribute>()!.Name;
            var primary = PrimaryT.GetCustomAttribute<ColumnNameAttribute>()!.Name;
            var id = (uint)grid.CurrentRow.Cells[primary].Value;
            using MySqlCommand command = new($"Delete from {tableName} where {primary}= @id", conn);
            command.Parameters.AddWithValue("ID", id);
            command.ExecuteNonQuery();
            UpdateD();
        }

        private void exitMenuItem(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateMenuItem(object sender, EventArgs e)
        {
            UpdateD();
        }

        private void gridFutura_CurrentCellChanged(object sender, EventArgs e)
        {
            UpdateT();
        }

        private void addD(object sender, EventArgs e)
        {
            addItem<D>(false);
        }

        private void addT(object sender, EventArgs e)
        {
            addItem<T>(true);

        }

        private void replaceD(object sender, EventArgs e)
        {
            replaceItem<D>(gridD);
        }

        private void replaceT(object sender, EventArgs e)
        {
            replaceItem<T>(gridT);
        }

        private void deleteD(object sender, EventArgs e)
        {
            deleteItem<D>(gridD);
        }

        private void deleteT(object sender, EventArgs e)
        {
            deleteItem<T>(gridT);
        }
    }
}

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
    public partial class FormFutura : Form
    {
        readonly MySqlConnection conn;
        DataTable dt = new();
        DataTable dt2 = new();
        readonly DataSet ds = new();
        readonly DataSet ds2 = new();
        public FormFutura(MySqlConnection connection)
        {
            conn = connection;
            InitializeComponent();
            this.Text = $"Таблица Накладная";
            UpdateFutura();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void UpdateFutura()
        {
            var cell = gridFutura.CurrentRow;
            using MySqlCommand command = new($"Select * from futura", conn);
            using MySqlDataAdapter da = new(command);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            gridFutura.DataSource = dt;
            for (int i = 0; i < gridFutura.ColumnCount; i++)
            {
                gridFutura.Columns[i].HeaderText = 
                    typeof(Futura).GetProperties()[i].GetCustomAttribute<DisplayNameAttribute>()!.DisplayName;
            }
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            var row = gridFutura.CurrentRow;
            if (row == null) return;
            var cell = row.Cells["ID"].Value;
            using MySqlCommand command1 = new($"Select * from futurainfo where IDFutura=@id", conn);
            command1.Parameters.AddWithValue("id", cell);
            using MySqlDataAdapter da1 = new(command1);
            ds2.Reset();
            da1.Fill(ds2);
            dt2 = ds2.Tables[0];
            gridInfo.DataSource = dt2;
            for (int i = 0; i < gridInfo.ColumnCount; i++)
            {
                gridInfo.Columns[i].HeaderText 
                    = typeof(FuturaInfo).GetProperties()[i].GetCustomAttribute<DisplayNameAttribute>()!.DisplayName;
            }
        }

        private void addItem<T>() where T : class, new()
        {
            var tableName = typeof(T).GetCustomAttribute<TableNameAttribute>()!.Name;
            using DataBox<T> form = new(conn);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var properties = typeof(T).GetProperties();

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
                UpdateFutura();
            }
        }

        private void replaceItem<T>(DataGridView grid) where T : class, new()
        {
            var row = grid.CurrentRow;
            if (row == null)
            {
                return;
            }

            var item = new T();
            var properties = typeof(T).GetProperties();
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

            using DataBox<T> form = new(conn, item);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var tableName = typeof(T).GetCustomAttribute<TableNameAttribute>()!.Name;
                List<string> keys = [];
                object primaryKey = "ID";
                object? primaryVal = null;

                foreach (var prop in properties)
                {
                    if (prop.GetCustomAttribute<IsPrimaryKeyAttribute>() != null)
                    {
                        primaryKey = prop.GetCustomAttribute<ColumnNameAttribute>()!.Name;
                        primaryVal = prop.GetValue(item);
                        continue;
                    }
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
                UpdateFutura();
            }
        }

        private void deleteItem<T>(DataGridView grid)
        {
            var tableName = typeof(T).GetCustomAttribute<TableNameAttribute>()!.Name;
            object? primary = null;
            foreach (var i in typeof(T).GetProperties())
            {
                if (i.GetCustomAttribute<IsPrimaryKeyAttribute>() != null)
                {
                    primary = i.GetCustomAttribute<ColumnNameAttribute>()!.Name;
                    break;
                }
            }
            if (primary == null) return;
            var id = (uint)grid.CurrentRow.Cells[primary!.ToString()].Value;
            using MySqlCommand command = new($"Delete from {tableName} where {primary}= @id", conn);
            command.Parameters.AddWithValue("ID", id);
            command.ExecuteNonQuery();
            UpdateFutura();
        }

        private void exitMenuItem(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateMenuItem(object sender, EventArgs e)
        {
            UpdateFutura();
        }

        private void gridFutura_CurrentCellChanged(object sender, EventArgs e)
        {
            UpdateInfo();
        }

        private void addFutura(object sender, EventArgs e)
        {
            addItem<Futura>();
        }

        private void addInfo(object sender, EventArgs e)
        {
            addItem<FuturaInfo>();
        }

        private void replaceFutura(object sender, EventArgs e)
        {
            replaceItem<Futura>(gridFutura);
        }

        private void replaceInfo(object sender, EventArgs e)
        {
            replaceItem<FuturaInfo>(gridInfo);
        }

        private void deleteFutura(object sender, EventArgs e)
        {
            deleteItem<Futura>(gridFutura);
        }

        private void deleteInfo(object sender, EventArgs e)
        {
            deleteItem<FuturaInfo>(gridInfo);
        }
    }
}

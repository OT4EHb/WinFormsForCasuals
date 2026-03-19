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
    public partial class FormData<T> : Form where T : class, new()
    {
        MySqlConnection conn;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string tableName { get => typeof(T).GetCustomAttribute<TableNameAttribute>()!.Name; }
        public FormData(MySqlConnection connection)
        {
            conn = connection;
            InitializeComponent();
            this.Text = $"Таблица {tableName}";
            UpdateData();
        }

        private void UpdateData()
        {
            using MySqlCommand command = new($"Select * from {tableName}", conn);
            using MySqlDataAdapter da = new(command);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].HeaderText = typeof(T).GetProperties()[i].GetCustomAttribute<ColumnNameAttribute>()!.Name;
            }
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void addMenuItem(object sender, EventArgs e)
        {
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
                UpdateData();
            }
        }

        private void replaceMenuItem(object sender, EventArgs e)
        {
            var row = dataGridView1.CurrentRow;
            if (row == null) return;
            var item = new T();
            var properties = typeof(T).GetProperties();
            foreach (var prop in properties)
            {
                string columnName = prop.Name;
                var columnAttr = prop.GetCustomAttribute<ColumnNameAttribute>();
                if (columnAttr != null)
                    columnName = columnAttr.Name;
                if (dataGridView1.Columns.Contains(columnName))
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
                List<string> keys = [];
                object primaryKey = "ID";
                object? primaryVal= null;

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
                var res=command.ExecuteNonQuery();
                UpdateData();
            }
        }

        private void deleteMenuItem(object sender, EventArgs e)
        {
            object? primary = null;
            foreach(var i in typeof(T).GetProperties())
            {
                if (i.GetCustomAttribute<IsPrimaryKeyAttribute>() != null)
                {
                    primary = i.GetCustomAttribute<ColumnNameAttribute>()!.Name;
                    break;
                }
            }
            var id = (uint)dataGridView1.CurrentRow.Cells[primary!.ToString()].Value;
            using MySqlCommand command = new($"Delete from {tableName} where {primary}= @id", conn);
            command.Parameters.AddWithValue("ID", id);
            command.ExecuteNonQuery();
            UpdateData();
        }

        private void exitMenuItem(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateMenuItem(object sender, EventArgs e)
        {
            UpdateData();
        }
    }
}

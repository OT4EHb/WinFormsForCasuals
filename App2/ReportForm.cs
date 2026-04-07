using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace App2
{
    public partial class ReportForm : Form
    {
        readonly MySqlConnection conn;
        DataTable dt = new();
        readonly DataSet ds = new();

        public ReportForm(MySqlConnection connection)
        {
            InitializeComponent();
            conn = connection;
            comboBoxClient.Enabled = false;
            LoadData();
        }

        async void LoadData()
        {
            string query = $"SELECT ID, Name FROM client";

            var items = new List<KeyValuePair<object, string>>();

            using var cmd = new MySqlCommand(query, conn);
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var value = reader["ID"];
                var display = reader["Name"].ToString();
                items.Add(new KeyValuePair<object, string>(value, display ?? ""));
            }

            comboBoxClient.DisplayMember = "Value";
            comboBoxClient.ValueMember = "Key";
            comboBoxClient.DataSource = items;
            comboBoxClient.Enabled = true;
        }

        private void button_Click(object sender, EventArgs e)
        {
            using MySqlCommand command = new($"Select f.DateV, " +
                $"i.Quantity, i.Price, i.Quantity*i.Price, p.Name, p.Ed " +
                $"from futura as f " +
                $"left join futurainfo as i on f.ID=i.IDFutura " +
                $"left join product as p on i.IDProduct=p.ID " +
                $"where DateV between DATE(@begin) and DATE(@end) " +
                $"and IDClient=@id", conn);
            command.Parameters.AddWithValue("begin", dateTimePicker1.Value.Date);
            command.Parameters.AddWithValue("end", dateTimePicker2.Value.Date);
            command.Parameters.AddWithValue("id", comboBoxClient.SelectedValue);
            using MySqlDataAdapter da = new(command);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
            List<String> names = ["Дата", "Количество", "Цена", "Стоимость", "Название товара", "Единицы измерения"];
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].HeaderText = names[i];
            }
        }
    }
}

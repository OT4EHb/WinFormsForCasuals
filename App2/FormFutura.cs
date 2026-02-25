using MySql.Data.MySqlClient;

namespace App2
{
    public partial class FormFutura : Form
    {

        public FormFutura()
        {
            InitializeComponent();
            string connectionString = "Server=localhost;Database=netbase;Uid=root;Pwd=mariadb;";

            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            string sql = "SELECT * FROM futura";

            using var command = new MySqlCommand(sql, connection);
            //command.Parameters.AddWithValue("@id", 1);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                richTextBox.Text += reader["totalsum"].ToString()+'\n';
            }
        }
    }
}

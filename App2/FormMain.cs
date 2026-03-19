using App2.DataClass;
using MySql.Data.MySqlClient;

namespace App2
{
    public partial class FormMain : Form
    {
        public MySqlConnection Con { get; }
        

        public FormMain()
        {
            InitializeComponent();
            string connectionString = "Server=localhost;Database=netbase;Uid=root;Pwd=mariadb;";
            Con = new MySqlConnection(connectionString);
            Con.Open();
        }

        void showData<T>() where T:class,new()
        {
            FormData<T> form = new(Con);
            form.Show();
        }

        public void buttonClient_Click(object sender, EventArgs e)
        {
            showData<Client>();            
        }

        private void buttonProduct_Click(object sender, EventArgs e)
        {
            showData<Product>();
        }

        private void buttonFutura_Click(object sender, EventArgs e)
        {
            showData<Futura>();
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            showData<FuturaInfo>();
        }
    }
}

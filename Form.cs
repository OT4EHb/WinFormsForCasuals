namespace WinFormsApp1
{
    public partial class FormAnketa : Form
    {
        List<User> Users { get; set; } = [];
        public FormAnketa()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            
            User u = new()
            {
                Name = textBoxFIO.Text,
                Date = DateOnly.Parse(datePicker.Text),
                City = comboBoxCity.Text,
                Sex = (radioButtonM.Checked ? "мужской" : "женский")
            };
            foreach (string i in checkedListSport.CheckedItems)
            {
                u.Sport.Add(i);
            }
            richTextBox1.Text += u.ToString();
            Users.Add(u);
        }

        private void export(object sender, EventArgs e)
        {
            SaveFileDialog ofd = new()
            {
                Title = "Сохранить Excel файл",
                Filter = "Файлы Excel (*.xlsx)|*.xlsx",
                FileName = "Users.xlsx",
                AddExtension = true,
                OverwritePrompt = false,
                RestoreDirectory = true
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;
            string path = ofd.FileName;
            using (ExcelExporter<User> exporter = new(path))
            {
                exporter.AddData(Users);
            }
            MessageBox.Show("Результаты сохранены");
        }
    }
}

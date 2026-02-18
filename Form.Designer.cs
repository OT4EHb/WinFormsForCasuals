namespace WinFormsApp1
{
    partial class FormAnketa
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxFIO = new TextBox();
            labelFIO = new Label();
            labelDate = new Label();
            datePicker = new DateTimePicker();
            labelCity = new Label();
            comboBoxCity = new ComboBox();
            labelSex = new Label();
            radioButtonM = new RadioButton();
            radioButtonJ = new RadioButton();
            labelSport = new Label();
            checkedListSport = new CheckedListBox();
            buttonSave = new Button();
            richTextBox1 = new RichTextBox();
            buttonExport = new Button();
            SuspendLayout();
            // 
            // textBoxFIO
            // 
            textBoxFIO.Location = new Point(168, 30);
            textBoxFIO.Multiline = true;
            textBoxFIO.Name = "textBoxFIO";
            textBoxFIO.Size = new Size(250, 27);
            textBoxFIO.TabIndex = 0;
            // 
            // labelFIO
            // 
            labelFIO.AutoSize = true;
            labelFIO.Location = new Point(39, 37);
            labelFIO.Name = "labelFIO";
            labelFIO.Size = new Size(42, 20);
            labelFIO.TabIndex = 1;
            labelFIO.Text = "ФИО";
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Location = new Point(39, 79);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(116, 20);
            labelDate.TabIndex = 2;
            labelDate.Text = "Дата рождения";
            // 
            // datePicker
            // 
            datePicker.Location = new Point(168, 79);
            datePicker.Name = "datePicker";
            datePicker.Size = new Size(250, 27);
            datePicker.TabIndex = 3;
            // 
            // labelCity
            // 
            labelCity.AutoSize = true;
            labelCity.Location = new Point(39, 131);
            labelCity.Name = "labelCity";
            labelCity.Size = new Size(51, 20);
            labelCity.TabIndex = 4;
            labelCity.Text = "Город";
            // 
            // comboBoxCity
            // 
            comboBoxCity.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBoxCity.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxCity.FormattingEnabled = true;
            comboBoxCity.Items.AddRange(new object[] { "Краснодар", "Москва", "Берлин", "Париж", "Омск" });
            comboBoxCity.Location = new Point(168, 131);
            comboBoxCity.Name = "comboBoxCity";
            comboBoxCity.Size = new Size(250, 28);
            comboBoxCity.TabIndex = 5;
            // 
            // labelSex
            // 
            labelSex.AutoSize = true;
            labelSex.Location = new Point(39, 176);
            labelSex.Name = "labelSex";
            labelSex.Size = new Size(37, 20);
            labelSex.TabIndex = 6;
            labelSex.Text = "Пол";
            // 
            // radioButtonM
            // 
            radioButtonM.AutoSize = true;
            radioButtonM.Location = new Point(168, 176);
            radioButtonM.Name = "radioButtonM";
            radioButtonM.Size = new Size(93, 24);
            radioButtonM.TabIndex = 7;
            radioButtonM.TabStop = true;
            radioButtonM.Text = "Мужской";
            radioButtonM.UseVisualStyleBackColor = true;
            // 
            // radioButtonJ
            // 
            radioButtonJ.AutoSize = true;
            radioButtonJ.Location = new Point(301, 176);
            radioButtonJ.Name = "radioButtonJ";
            radioButtonJ.Size = new Size(92, 24);
            radioButtonJ.TabIndex = 8;
            radioButtonJ.TabStop = true;
            radioButtonJ.Text = "Женский";
            radioButtonJ.UseVisualStyleBackColor = true;
            // 
            // labelSport
            // 
            labelSport.AutoSize = true;
            labelSport.Location = new Point(39, 213);
            labelSport.Name = "labelSport";
            labelSport.Size = new Size(84, 20);
            labelSport.TabIndex = 9;
            labelSport.Text = "Увлечения";
            // 
            // checkedListSport
            // 
            checkedListSport.FormattingEnabled = true;
            checkedListSport.Items.AddRange(new object[] { "Футбол", "Баскетбол", "Хоккей", "Шахматы", "Монополия", "Мир танков", "Europa Universalis IV" });
            checkedListSport.Location = new Point(168, 213);
            checkedListSport.Name = "checkedListSport";
            checkedListSport.Size = new Size(250, 158);
            checkedListSport.TabIndex = 10;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(168, 409);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(250, 39);
            buttonSave.TabIndex = 11;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(449, 30);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(316, 425);
            richTextBox1.TabIndex = 12;
            richTextBox1.Text = "";
            // 
            // buttonExport
            // 
            buttonExport.Location = new Point(39, 409);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(84, 39);
            buttonExport.TabIndex = 13;
            buttonExport.Text = "Экспорт";
            buttonExport.UseVisualStyleBackColor = true;
            buttonExport.Click += export;
            // 
            // FormAnketa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 467);
            Controls.Add(buttonExport);
            Controls.Add(richTextBox1);
            Controls.Add(buttonSave);
            Controls.Add(checkedListSport);
            Controls.Add(labelSport);
            Controls.Add(radioButtonJ);
            Controls.Add(radioButtonM);
            Controls.Add(labelSex);
            Controls.Add(comboBoxCity);
            Controls.Add(labelCity);
            Controls.Add(datePicker);
            Controls.Add(labelDate);
            Controls.Add(labelFIO);
            Controls.Add(textBoxFIO);
            Name = "FormAnketa";
            Text = "Анкета";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxFIO;
        private Label labelFIO;
        private Label labelDate;
        private DateTimePicker datePicker;
        private Label labelCity;
        private ComboBox comboBoxCity;
        private Label labelSex;
        private RadioButton radioButtonM;
        private RadioButton radioButtonJ;
        private Label labelSport;
        private CheckedListBox checkedListSport;
        private Button buttonSave;
        private RichTextBox richTextBox1;
        private Button buttonExport;
    }
}

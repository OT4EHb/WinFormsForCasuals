namespace App2
{
    partial class ReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            comboBoxClient = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            labelClient = new Label();
            button = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 145);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(776, 293);
            dataGridView1.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(91, 18);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 1;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(415, 18);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(250, 27);
            dateTimePicker2.TabIndex = 2;
            // 
            // comboBoxClient
            // 
            comboBoxClient.FormattingEnabled = true;
            comboBoxClient.Location = new Point(146, 77);
            comboBoxClient.Name = "comboBoxClient";
            comboBoxClient.Size = new Size(151, 28);
            comboBoxClient.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 23);
            label1.Name = "label1";
            label1.Size = new Size(26, 20);
            label1.TabIndex = 4;
            label1.Text = "От";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(370, 23);
            label2.Name = "label2";
            label2.Size = new Size(28, 20);
            label2.TabIndex = 5;
            label2.Text = "До";
            // 
            // labelClient
            // 
            labelClient.AutoSize = true;
            labelClient.Location = new Point(48, 80);
            labelClient.Name = "labelClient";
            labelClient.Size = new Size(58, 20);
            labelClient.TabIndex = 6;
            labelClient.Text = "Клиент";
            // 
            // button
            // 
            button.Location = new Point(415, 80);
            button.Name = "button";
            button.Size = new Size(250, 29);
            button.TabIndex = 7;
            button.Text = "Кликни меня)";
            button.UseVisualStyleBackColor = true;
            button.Click += button_Click;
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button);
            Controls.Add(labelClient);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBoxClient);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(dataGridView1);
            Name = "ReportForm";
            Text = "ReportForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private ComboBox comboBoxClient;
        private Label label1;
        private Label label2;
        private Label labelClient;
        private Button button;
    }
}
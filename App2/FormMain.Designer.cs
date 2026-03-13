namespace App2
{
    partial class FormMain
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
            richTextBox = new RichTextBox();
            buttonClient = new Button();
            buttonProduct = new Button();
            buttonFutura = new Button();
            buttonReport = new Button();
            SuspendLayout();
            // 
            // richTextBox
            // 
            richTextBox.Location = new Point(313, 25);
            richTextBox.Name = "richTextBox";
            richTextBox.Size = new Size(457, 252);
            richTextBox.TabIndex = 0;
            richTextBox.Text = "";
            // 
            // buttonClient
            // 
            buttonClient.Location = new Point(75, 25);
            buttonClient.Name = "buttonClient";
            buttonClient.Size = new Size(163, 33);
            buttonClient.TabIndex = 1;
            buttonClient.Text = "Клиенты";
            buttonClient.UseVisualStyleBackColor = true;
            buttonClient.Click += buttonClient_Click;
            // 
            // buttonProduct
            // 
            buttonProduct.Location = new Point(75, 90);
            buttonProduct.Name = "buttonProduct";
            buttonProduct.Size = new Size(163, 35);
            buttonProduct.TabIndex = 2;
            buttonProduct.Text = "Товары";
            buttonProduct.UseVisualStyleBackColor = true;
            buttonProduct.Click += buttonProduct_Click;
            // 
            // buttonFutura
            // 
            buttonFutura.Location = new Point(75, 157);
            buttonFutura.Name = "buttonFutura";
            buttonFutura.Size = new Size(163, 46);
            buttonFutura.TabIndex = 3;
            buttonFutura.Text = "Накладные";
            buttonFutura.UseVisualStyleBackColor = true;
            buttonFutura.Click += buttonFutura_Click;
            // 
            // buttonReport
            // 
            buttonReport.Location = new Point(75, 232);
            buttonReport.Name = "buttonReport";
            buttonReport.Size = new Size(163, 45);
            buttonReport.TabIndex = 4;
            buttonReport.Text = "Отчеты";
            buttonReport.UseVisualStyleBackColor = true;
            buttonReport.Click += buttonReport_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonReport);
            Controls.Add(buttonFutura);
            Controls.Add(buttonProduct);
            Controls.Add(buttonClient);
            Controls.Add(richTextBox);
            Name = "FormMain";
            Text = "Form";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTextBox;
        private Button buttonClient;
        private Button buttonProduct;
        private Button buttonFutura;
        private Button buttonReport;
    }
}

namespace App2
{
    partial class FormFutura
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
            menuStrip1 = new MenuStrip();
            обновитьToolStripMenuItem = new ToolStripMenuItem();
            добавитьToolStripMenuItem = new ToolStripMenuItem();
            накладнаяToolStripMenuItem = new ToolStripMenuItem();
            товарToolStripMenuItem = new ToolStripMenuItem();
            изменитьToolStripMenuItem = new ToolStripMenuItem();
            накладнаяToolStripMenuItem2 = new ToolStripMenuItem();
            товарToolStripMenuItem2 = new ToolStripMenuItem();
            удалитьToolStripMenuItem = new ToolStripMenuItem();
            накладнаяToolStripMenuItem1 = new ToolStripMenuItem();
            товарToolStripMenuItem1 = new ToolStripMenuItem();
            выходToolStripMenuItem = new ToolStripMenuItem();
            gridFutura = new DataGridView();
            gridInfo = new DataGridView();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridFutura).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridInfo).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { обновитьToolStripMenuItem, добавитьToolStripMenuItem, изменитьToolStripMenuItem, удалитьToolStripMenuItem, выходToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // обновитьToolStripMenuItem
            // 
            обновитьToolStripMenuItem.Name = "обновитьToolStripMenuItem";
            обновитьToolStripMenuItem.Size = new Size(90, 24);
            обновитьToolStripMenuItem.Text = "обновить";
            обновитьToolStripMenuItem.Click += updateMenuItem;
            // 
            // добавитьToolStripMenuItem
            // 
            добавитьToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { накладнаяToolStripMenuItem, товарToolStripMenuItem });
            добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            добавитьToolStripMenuItem.Size = new Size(88, 24);
            добавитьToolStripMenuItem.Text = "добавить";
            // 
            // накладнаяToolStripMenuItem
            // 
            накладнаяToolStripMenuItem.Name = "накладнаяToolStripMenuItem";
            накладнаяToolStripMenuItem.Size = new Size(165, 26);
            накладнаяToolStripMenuItem.Text = "накладная";
            накладнаяToolStripMenuItem.Click += addFutura;
            // 
            // товарToolStripMenuItem
            // 
            товарToolStripMenuItem.Name = "товарToolStripMenuItem";
            товарToolStripMenuItem.Size = new Size(165, 26);
            товарToolStripMenuItem.Text = "товар";
            товарToolStripMenuItem.Click += addInfo;
            // 
            // изменитьToolStripMenuItem
            // 
            изменитьToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { накладнаяToolStripMenuItem2, товарToolStripMenuItem2 });
            изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            изменитьToolStripMenuItem.Size = new Size(90, 24);
            изменитьToolStripMenuItem.Text = "изменить";
            // 
            // накладнаяToolStripMenuItem2
            // 
            накладнаяToolStripMenuItem2.Name = "накладнаяToolStripMenuItem2";
            накладнаяToolStripMenuItem2.Size = new Size(165, 26);
            накладнаяToolStripMenuItem2.Text = "накладная";
            накладнаяToolStripMenuItem2.Click += replaceFutura;
            // 
            // товарToolStripMenuItem2
            // 
            товарToolStripMenuItem2.Name = "товарToolStripMenuItem2";
            товарToolStripMenuItem2.Size = new Size(165, 26);
            товарToolStripMenuItem2.Text = "товар";
            товарToolStripMenuItem2.Click += replaceInfo;
            // 
            // удалитьToolStripMenuItem
            // 
            удалитьToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { накладнаяToolStripMenuItem1, товарToolStripMenuItem1 });
            удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            удалитьToolStripMenuItem.Size = new Size(77, 24);
            удалитьToolStripMenuItem.Text = "удалить";
            // 
            // накладнаяToolStripMenuItem1
            // 
            накладнаяToolStripMenuItem1.Name = "накладнаяToolStripMenuItem1";
            накладнаяToolStripMenuItem1.Size = new Size(165, 26);
            накладнаяToolStripMenuItem1.Text = "накладная";
            накладнаяToolStripMenuItem1.Click += deleteFutura;
            // 
            // товарToolStripMenuItem1
            // 
            товарToolStripMenuItem1.Name = "товарToolStripMenuItem1";
            товарToolStripMenuItem1.Size = new Size(165, 26);
            товарToolStripMenuItem1.Text = "товар";
            товарToolStripMenuItem1.Click += deleteInfo;
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(66, 24);
            выходToolStripMenuItem.Text = "выход";
            выходToolStripMenuItem.Click += exitMenuItem;
            // 
            // gridFutura
            // 
            gridFutura.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridFutura.Location = new Point(12, 40);
            gridFutura.Name = "gridFutura";
            gridFutura.RowHeadersWidth = 51;
            gridFutura.Size = new Size(776, 176);
            gridFutura.TabIndex = 1;
            gridFutura.CurrentCellChanged += gridFutura_CurrentCellChanged;
            // 
            // gridInfo
            // 
            gridInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridInfo.Location = new Point(12, 241);
            gridInfo.Name = "gridInfo";
            gridInfo.RowHeadersWidth = 51;
            gridInfo.Size = new Size(776, 188);
            gridInfo.TabIndex = 2;
            // 
            // FormFutura
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gridInfo);
            Controls.Add(gridFutura);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormFutura";
            Text = "FormFutura";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridFutura).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridInfo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem обновитьToolStripMenuItem;
        private ToolStripMenuItem добавитьToolStripMenuItem;
        private ToolStripMenuItem накладнаяToolStripMenuItem;
        private ToolStripMenuItem товарToolStripMenuItem;
        private ToolStripMenuItem удалитьToolStripMenuItem;
        private ToolStripMenuItem накладнаяToolStripMenuItem1;
        private ToolStripMenuItem товарToolStripMenuItem1;
        private ToolStripMenuItem выходToolStripMenuItem;
        private DataGridView gridFutura;
        private DataGridView gridInfo;
        private ToolStripMenuItem изменитьToolStripMenuItem;
        private ToolStripMenuItem накладнаяToolStripMenuItem2;
        private ToolStripMenuItem товарToolStripMenuItem2;
    }
}
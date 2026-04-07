using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace App2
{
    partial class ForeignForm<D,T>
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
            gridD = new DataGridView();
            gridT = new DataGridView();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridT).BeginInit();
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
            накладнаяToolStripMenuItem.Text = DisplayD;
            накладнаяToolStripMenuItem.Click += addD;
            // 
            // товарToolStripMenuItem
            // 
            товарToolStripMenuItem.Name = "товарToolStripMenuItem";
            товарToolStripMenuItem.Size = new Size(165, 26);
            товарToolStripMenuItem.Text = DisplayT;
            товарToolStripMenuItem.Click += addT;
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
            накладнаяToolStripMenuItem2.Text = DisplayD;
            накладнаяToolStripMenuItem2.Click += replaceD;
            // 
            // товарToolStripMenuItem2
            // 
            товарToolStripMenuItem2.Name = "товарToolStripMenuItem2";
            товарToolStripMenuItem2.Size = new Size(165, 26);
            товарToolStripMenuItem2.Text = DisplayT;
            товарToolStripMenuItem2.Click += replaceT;
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
            накладнаяToolStripMenuItem1.Text = DisplayD;
            накладнаяToolStripMenuItem1.Click += deleteD;
            // 
            // товарToolStripMenuItem1
            // 
            товарToolStripMenuItem1.Name = "товарToolStripMenuItem1";
            товарToolStripMenuItem1.Size = new Size(165, 26);
            товарToolStripMenuItem1.Text = DisplayT;
            товарToolStripMenuItem1.Click += deleteT;
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
            gridD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridD.Location = new Point(12, 40);
            gridD.Name = "gridFutura";
            gridD.RowHeadersWidth = 51;
            gridD.Size = new Size(776, 176);
            gridD.TabIndex = 1;
            gridD.CurrentCellChanged += gridFutura_CurrentCellChanged;
            // 
            // gridInfo
            // 
            gridT.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridT.Location = new Point(12, 241);
            gridT.Name = "gridInfo";
            gridT.RowHeadersWidth = 51;
            gridT.Size = new Size(776, 188);
            gridT.TabIndex = 2;
            // 
            // FormFutura
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gridT);
            Controls.Add(gridD);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormFutura";
            Text = "FormFutura";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridD).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridT).EndInit();
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
        private DataGridView gridD;
        private DataGridView gridT;
        private ToolStripMenuItem изменитьToolStripMenuItem;
        private ToolStripMenuItem накладнаяToolStripMenuItem2;
        private ToolStripMenuItem товарToolStripMenuItem2;
    }
}
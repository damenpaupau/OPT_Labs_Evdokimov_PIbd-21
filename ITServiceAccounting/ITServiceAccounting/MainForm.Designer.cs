namespace ITServiceAccounting
{
    partial class MainForm
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
			menuStrip1 = new MenuStrip();
			справочникиToolStripMenuItem = new ToolStripMenuItem();
			организацииToolStripMenuItem = new ToolStripMenuItem();
			исполнителиToolStripMenuItem = new ToolStripMenuItem();
			услугиToolStripMenuItem = new ToolStripMenuItem();
			операцииToolStripMenuItem = new ToolStripMenuItem();
			договорыToolStripMenuItem = new ToolStripMenuItem();
			отчетыToolStripMenuItem = new ToolStripMenuItem();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// menuStrip1
			// 
			menuStrip1.Items.AddRange(new ToolStripItem[] { справочникиToolStripMenuItem, операцииToolStripMenuItem, отчетыToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(800, 24);
			menuStrip1.TabIndex = 0;
			menuStrip1.Text = "menuStrip1";
			// 
			// справочникиToolStripMenuItem
			// 
			справочникиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { организацииToolStripMenuItem, исполнителиToolStripMenuItem, услугиToolStripMenuItem });
			справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
			справочникиToolStripMenuItem.Size = new Size(94, 20);
			справочникиToolStripMenuItem.Text = "Справочники";
			справочникиToolStripMenuItem.Click += справочникиToolStripMenuItem_Click;
			// 
			// организацииToolStripMenuItem
			// 
			организацииToolStripMenuItem.Name = "организацииToolStripMenuItem";
			организацииToolStripMenuItem.Size = new Size(180, 22);
			организацииToolStripMenuItem.Text = "Организации";
			организацииToolStripMenuItem.Click += организацииToolStripMenuItem_Click;
			// 
			// исполнителиToolStripMenuItem
			// 
			исполнителиToolStripMenuItem.Name = "исполнителиToolStripMenuItem";
			исполнителиToolStripMenuItem.Size = new Size(180, 22);
			исполнителиToolStripMenuItem.Text = "Исполнители";
			исполнителиToolStripMenuItem.Click += исполнителииToolStripMenuItem_Click;
			// 
			// услугиToolStripMenuItem
			// 
			услугиToolStripMenuItem.Name = "услугиToolStripMenuItem";
			услугиToolStripMenuItem.Size = new Size(180, 22);
			услугиToolStripMenuItem.Text = "Услуги";
			услугиToolStripMenuItem.Click += услугиToolStripMenuItem_Click;
			// 
			// операцииToolStripMenuItem
			// 
			операцииToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { договорыToolStripMenuItem });
			операцииToolStripMenuItem.Name = "операцииToolStripMenuItem";
			операцииToolStripMenuItem.Size = new Size(75, 20);
			операцииToolStripMenuItem.Text = "Операции";
			// 
			// договорыToolStripMenuItem
			// 
			договорыToolStripMenuItem.Name = "договорыToolStripMenuItem";
			договорыToolStripMenuItem.Size = new Size(180, 22);
			договорыToolStripMenuItem.Text = "Договоры";
			договорыToolStripMenuItem.Click += договорыToolStripMenuItem_Click;
			// 
			// отчетыToolStripMenuItem
			// 
			отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
			отчетыToolStripMenuItem.Size = new Size(60, 20);
			отчетыToolStripMenuItem.Text = "Отчеты";
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(menuStrip1);
			MainMenuStrip = menuStrip1;
			Name = "MainForm";
			Text = "Учет услуг ИТ-компании";
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private MenuStrip menuStrip1;
        private ToolStripMenuItem справочникиToolStripMenuItem;
        private ToolStripMenuItem организацииToolStripMenuItem;
        private ToolStripMenuItem исполнителиToolStripMenuItem;
        private ToolStripMenuItem услугиToolStripMenuItem;
        private ToolStripMenuItem операцииToolStripMenuItem;
        private ToolStripMenuItem договорыToolStripMenuItem;
        private ToolStripMenuItem отчетыToolStripMenuItem;
    }
}

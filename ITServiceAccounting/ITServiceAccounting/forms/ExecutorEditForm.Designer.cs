namespace ITServiceAccounting
{
    partial class ExecutorEditForm
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
			label1 = new Label();
			label2 = new Label();
			txtFullName = new TextBox();
			txtPosition = new TextBox();
			btnSave = new Button();
			btnCancel = new Button();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 9);
			label1.Name = "label1";
			label1.Size = new Size(34, 15);
			label1.TabIndex = 2;
			label1.Text = "ФИО";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(12, 46);
			label2.Name = "label2";
			label2.Size = new Size(69, 15);
			label2.TabIndex = 3;
			label2.Text = "Должность";
			// 
			// txtFullName
			// 
			txtFullName.Location = new Point(88, 6);
			txtFullName.Name = "txtFullName";
			txtFullName.Size = new Size(100, 23);
			txtFullName.TabIndex = 4;
			// 
			// txtPosition
			// 
			txtPosition.Location = new Point(88, 43);
			txtPosition.Name = "txtPosition";
			txtPosition.Size = new Size(100, 23);
			txtPosition.TabIndex = 5;
			// 
			// btnSave
			// 
			btnSave.Location = new Point(12, 76);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(75, 23);
			btnSave.TabIndex = 6;
			btnSave.Text = "Сохранить";
			btnSave.UseVisualStyleBackColor = true;
			btnSave.Click += btnSave_Click;
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(113, 76);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 23);
			btnCancel.TabIndex = 7;
			btnCancel.Text = "Отмена";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += btnCancel_Click;
			// 
			// ExecutorEditForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(btnCancel);
			Controls.Add(btnSave);
			Controls.Add(txtPosition);
			Controls.Add(txtFullName);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "ExecutorEditForm";
			Text = "ExecutorEditForm";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Label label2;
		private TextBox txtFullName;
		private TextBox txtPosition;
		private Button btnSave;
		private Button btnCancel;
	}
}
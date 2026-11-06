namespace ITServiceAccounting
{
    partial class OrganizationEditForm
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
			label3 = new Label();
			txtName = new TextBox();
			txtInn = new TextBox();
			txtContact = new TextBox();
			btnSave = new Button();
			btnCancel = new Button();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 14);
			label1.Name = "label1";
			label1.Size = new Size(59, 15);
			label1.TabIndex = 0;
			label1.Text = "Название";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(12, 43);
			label2.Name = "label2";
			label2.Size = new Size(34, 15);
			label2.TabIndex = 1;
			label2.Text = "ИНН";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(12, 72);
			label3.Name = "label3";
			label3.Size = new Size(101, 15);
			label3.TabIndex = 2;
			label3.Text = "Контактное лицо";
			// 
			// txtName
			// 
			txtName.Location = new Point(133, 6);
			txtName.Name = "txtName";
			txtName.Size = new Size(100, 23);
			txtName.TabIndex = 3;
			// 
			// txtInn
			// 
			txtInn.Location = new Point(133, 35);
			txtInn.Name = "txtInn";
			txtInn.Size = new Size(100, 23);
			txtInn.TabIndex = 4;
			// 
			// txtContact
			// 
			txtContact.Location = new Point(133, 64);
			txtContact.Name = "txtContact";
			txtContact.Size = new Size(100, 23);
			txtContact.TabIndex = 5;
			// 
			// btnSave
			// 
			btnSave.Location = new Point(12, 101);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(75, 23);
			btnSave.TabIndex = 6;
			btnSave.Text = "Сохранить";
			btnSave.UseVisualStyleBackColor = true;
			btnSave.Click += btnSave_Click;
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(133, 101);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 23);
			btnCancel.TabIndex = 7;
			btnCancel.Text = "Отмена";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += btnCancel_Click;
			// 
			// OrganizationEditForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(btnCancel);
			Controls.Add(btnSave);
			Controls.Add(txtContact);
			Controls.Add(txtInn);
			Controls.Add(txtName);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "OrganizationEditForm";
			Text = "OrganizationEditForm";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtName;
        private TextBox txtInn;
        private TextBox txtContact;
        private Button btnSave;
        private Button btnCancel;
    }
}
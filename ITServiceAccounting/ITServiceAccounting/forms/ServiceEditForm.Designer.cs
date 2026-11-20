namespace ITServiceAccounting
{
    partial class ServiceEditForm
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
			txtName = new TextBox();
			txtBaseCost = new TextBox();
			cmbCategory = new ComboBox();
			btnSave = new Button();
			btnCancel = new Button();
			SuspendLayout();
			// 
			// txtName
			// 
			txtName.Location = new Point(12, 12);
			txtName.Name = "txtName";
			txtName.Size = new Size(100, 23);
			txtName.TabIndex = 0;
			txtName.Text = "Название";
			// 
			// txtBaseCost
			// 
			txtBaseCost.Location = new Point(118, 12);
			txtBaseCost.Name = "txtBaseCost";
			txtBaseCost.Size = new Size(100, 23);
			txtBaseCost.TabIndex = 1;
			txtBaseCost.Text = "Цена";
			// 
			// cmbCategory
			// 
			cmbCategory.FormattingEnabled = true;
			cmbCategory.Location = new Point(224, 12);
			cmbCategory.Name = "cmbCategory";
			cmbCategory.Size = new Size(121, 23);
			cmbCategory.TabIndex = 2;
			cmbCategory.Text = "Список";
			// 
			// btnSave
			// 
			btnSave.Location = new Point(12, 41);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(75, 23);
			btnSave.TabIndex = 3;
			btnSave.Text = "Сохранить";
			btnSave.UseVisualStyleBackColor = true;
			btnSave.Click += btnSave_Click;
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(93, 41);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 23);
			btnCancel.TabIndex = 4;
			btnCancel.Text = "Отмена";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += btnCancel_Click;
			// 
			// ServiceEditForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(btnCancel);
			Controls.Add(btnSave);
			Controls.Add(cmbCategory);
			Controls.Add(txtBaseCost);
			Controls.Add(txtName);
			Name = "ServiceEditForm";
			Text = "ServiceEditForm";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox txtName;
        private TextBox txtBaseCost;
        private ComboBox cmbCategory;
        private Button btnSave;
        private Button btnCancel;
    }
}
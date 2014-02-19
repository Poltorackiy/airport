namespace PlaneSolution
{
	partial class PlaneEdit
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.modeltextBox = new System.Windows.Forms.TextBox();
			this.planeNumberTextbox = new System.Windows.Forms.TextBox();
			this.airCompanycomboBox = new System.Windows.Forms.ComboBox();
			this.OKbutton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(46, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(98, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Модель самолёта";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(54, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(90, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Бортовой номер";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(11, 99);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(133, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Авиакомпания-владелец";
			// 
			// modeltextBox
			// 
			this.modeltextBox.Location = new System.Drawing.Point(150, 13);
			this.modeltextBox.MaxLength = 20;
			this.modeltextBox.Name = "modeltextBox";
			this.modeltextBox.Size = new System.Drawing.Size(220, 20);
			this.modeltextBox.TabIndex = 3;
			// 
			// planeNumberTextbox
			// 
			this.planeNumberTextbox.Location = new System.Drawing.Point(150, 55);
			this.planeNumberTextbox.MaxLength = 50;
			this.planeNumberTextbox.Name = "planeNumberTextbox";
			this.planeNumberTextbox.Size = new System.Drawing.Size(220, 20);
			this.planeNumberTextbox.TabIndex = 4;
			// 
			// airCompanycomboBox
			// 
			this.airCompanycomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.airCompanycomboBox.FormattingEnabled = true;
			this.airCompanycomboBox.Location = new System.Drawing.Point(150, 96);
			this.airCompanycomboBox.Name = "airCompanycomboBox";
			this.airCompanycomboBox.Size = new System.Drawing.Size(220, 21);
			this.airCompanycomboBox.TabIndex = 5;
			// 
			// OKbutton
			// 
			this.OKbutton.Location = new System.Drawing.Point(213, 144);
			this.OKbutton.Name = "OKbutton";
			this.OKbutton.Size = new System.Drawing.Size(75, 23);
			this.OKbutton.TabIndex = 6;
			this.OKbutton.Text = "ОК";
			this.OKbutton.UseVisualStyleBackColor = true;
			this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(294, 144);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 7;
			this.cancelButton.Text = "Отмена";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// PlaneEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(392, 199);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.OKbutton);
			this.Controls.Add(this.airCompanycomboBox);
			this.Controls.Add(this.planeNumberTextbox);
			this.Controls.Add(this.modeltextBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "PlaneEdit";
			this.Text = "PlaneEdit";
			this.Load += new System.EventHandler(this.PlaneEdit_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox modeltextBox;
		private System.Windows.Forms.TextBox planeNumberTextbox;
		private System.Windows.Forms.ComboBox airCompanycomboBox;
		private System.Windows.Forms.Button OKbutton;
		private System.Windows.Forms.Button cancelButton;
	}
}
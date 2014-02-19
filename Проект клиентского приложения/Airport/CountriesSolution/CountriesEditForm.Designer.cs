namespace CountriesSolution
{
    partial class CountriesEditForm
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.Label countryNameLabel;
			this.countryNameTextBox = new System.Windows.Forms.TextBox();
			this.countryInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			countryNameLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.countryInfoBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// countryNameLabel
			// 
			countryNameLabel.AutoSize = true;
			countryNameLabel.Location = new System.Drawing.Point(12, 27);
			countryNameLabel.Name = "countryNameLabel";
			countryNameLabel.Size = new System.Drawing.Size(97, 13);
			countryNameLabel.TabIndex = 1;
			countryNameLabel.Text = "Название страны";
			// 
			// countryNameTextBox
			// 
			this.countryNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.countryInfoBindingSource, "CountryName", true));
			this.countryNameTextBox.Location = new System.Drawing.Point(110, 24);
			this.countryNameTextBox.Name = "countryNameTextBox";
			this.countryNameTextBox.Size = new System.Drawing.Size(250, 20);
			this.countryNameTextBox.TabIndex = 2;
			// 
			// countryInfoBindingSource
			// 
			this.countryInfoBindingSource.DataSource = typeof(AirportLibrary.CountryInfo);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(284, 51);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(203, 51);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 4;
			this.buttonOK.Text = "ОК";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// CountriesEditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(372, 150);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(countryNameLabel);
			this.Controls.Add(this.countryNameTextBox);
			this.Name = "CountriesEditForm";
			this.Text = "Страна";
			this.Load += new System.EventHandler(this.CountriesEditForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.countryInfoBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource countryInfoBindingSource;
        private System.Windows.Forms.TextBox countryNameTextBox;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
    }
}
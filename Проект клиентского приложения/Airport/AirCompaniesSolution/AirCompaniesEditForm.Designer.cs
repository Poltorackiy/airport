namespace AirCompaniesSolution
{
    partial class AirCompaniesEditForm
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
            System.Windows.Forms.Label airCompanyIDLabel;
            System.Windows.Forms.Label airCompanyNameLabel;
            System.Windows.Forms.Label airCompanyPhoneLabel;
            System.Windows.Forms.Label airCompanyAddressLabel;
            this.airCompanyIDTextBox = new System.Windows.Forms.TextBox();
            this.airCompanyInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.airCompanyNameTextBox = new System.Windows.Forms.TextBox();
            this.airCompanyPhoneTextBox = new System.Windows.Forms.TextBox();
            this.airCompanyAddressTextBox = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            airCompanyIDLabel = new System.Windows.Forms.Label();
            airCompanyNameLabel = new System.Windows.Forms.Label();
            airCompanyPhoneLabel = new System.Windows.Forms.Label();
            airCompanyAddressLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.airCompanyInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // airCompanyIDLabel
            // 
            airCompanyIDLabel.AutoSize = true;
            airCompanyIDLabel.Location = new System.Drawing.Point(203, 23);
            airCompanyIDLabel.Name = "airCompanyIDLabel";
            airCompanyIDLabel.Size = new System.Drawing.Size(83, 13);
            airCompanyIDLabel.TabIndex = 1;
            airCompanyIDLabel.Text = "Air Company ID:";
            airCompanyIDLabel.Visible = false;
            // 
            // airCompanyNameLabel
            // 
            airCompanyNameLabel.AutoSize = true;
            airCompanyNameLabel.Location = new System.Drawing.Point(15, 64);
            airCompanyNameLabel.Name = "airCompanyNameLabel";
            airCompanyNameLabel.Size = new System.Drawing.Size(57, 13);
            airCompanyNameLabel.TabIndex = 2;
            airCompanyNameLabel.Text = "Название";
            // 
            // airCompanyPhoneLabel
            // 
            airCompanyPhoneLabel.AutoSize = true;
            airCompanyPhoneLabel.Location = new System.Drawing.Point(20, 102);
            airCompanyPhoneLabel.Name = "airCompanyPhoneLabel";
            airCompanyPhoneLabel.Size = new System.Drawing.Size(52, 13);
            airCompanyPhoneLabel.TabIndex = 4;
            airCompanyPhoneLabel.Text = "Телефон";
            // 
            // airCompanyAddressLabel
            // 
            airCompanyAddressLabel.AutoSize = true;
            airCompanyAddressLabel.Location = new System.Drawing.Point(34, 141);
            airCompanyAddressLabel.Name = "airCompanyAddressLabel";
            airCompanyAddressLabel.Size = new System.Drawing.Size(38, 13);
            airCompanyAddressLabel.TabIndex = 6;
            airCompanyAddressLabel.Text = "Адрес";
            // 
            // airCompanyIDTextBox
            // 
            this.airCompanyIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.airCompanyInfoBindingSource, "AirCompanyID", true));
            this.airCompanyIDTextBox.Location = new System.Drawing.Point(294, 12);
            this.airCompanyIDTextBox.Name = "airCompanyIDTextBox";
            this.airCompanyIDTextBox.Size = new System.Drawing.Size(100, 20);
            this.airCompanyIDTextBox.TabIndex = 2;
            this.airCompanyIDTextBox.Visible = false;
            // 
            // airCompanyInfoBindingSource
            // 
            this.airCompanyInfoBindingSource.DataSource = typeof(AirCompaniesSolution.AirCompanyInfo);
            // 
            // airCompanyNameTextBox
            // 
            this.airCompanyNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.airCompanyInfoBindingSource, "AirCompanyName", true));
            this.airCompanyNameTextBox.Location = new System.Drawing.Point(78, 61);
            this.airCompanyNameTextBox.Name = "airCompanyNameTextBox";
            this.airCompanyNameTextBox.Size = new System.Drawing.Size(316, 20);
            this.airCompanyNameTextBox.TabIndex = 3;
            // 
            // airCompanyPhoneTextBox
            // 
            this.airCompanyPhoneTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.airCompanyInfoBindingSource, "AirCompanyPhone", true));
            this.airCompanyPhoneTextBox.Location = new System.Drawing.Point(78, 99);
            this.airCompanyPhoneTextBox.Name = "airCompanyPhoneTextBox";
            this.airCompanyPhoneTextBox.Size = new System.Drawing.Size(316, 20);
            this.airCompanyPhoneTextBox.TabIndex = 5;
            // 
            // airCompanyAddressTextBox
            // 
            this.airCompanyAddressTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.airCompanyInfoBindingSource, "AirCompanyAddress", true));
            this.airCompanyAddressTextBox.Location = new System.Drawing.Point(78, 138);
            this.airCompanyAddressTextBox.Name = "airCompanyAddressTextBox";
            this.airCompanyAddressTextBox.Size = new System.Drawing.Size(316, 20);
            this.airCompanyAddressTextBox.TabIndex = 7;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(237, 227);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 8;
            this.buttonOK.Text = "ОК";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(318, 227);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // AirCompaniesEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 263);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(airCompanyAddressLabel);
            this.Controls.Add(this.airCompanyAddressTextBox);
            this.Controls.Add(airCompanyPhoneLabel);
            this.Controls.Add(this.airCompanyPhoneTextBox);
            this.Controls.Add(airCompanyNameLabel);
            this.Controls.Add(this.airCompanyNameTextBox);
            this.Controls.Add(airCompanyIDLabel);
            this.Controls.Add(this.airCompanyIDTextBox);
            this.Name = "AirCompaniesEditForm";
            this.Text = "Авиакомпания";
            this.Load += new System.EventHandler(this.AirCompaniesEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.airCompanyInfoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource airCompanyInfoBindingSource;
        private System.Windows.Forms.TextBox airCompanyIDTextBox;
        private System.Windows.Forms.TextBox airCompanyNameTextBox;
        private System.Windows.Forms.TextBox airCompanyPhoneTextBox;
        private System.Windows.Forms.TextBox airCompanyAddressTextBox;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}
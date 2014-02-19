namespace AirPortSolution
{
    partial class AirPortEditForm
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
			System.Windows.Forms.Label airPortNameLabel;
			this.airPortNameTextBox = new System.Windows.Forms.TextBox();
			this.airPortInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.citiesListBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.countriesListBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.countryComboBox = new System.Windows.Forms.ComboBox();
			this.CountryLabel = new System.Windows.Forms.Label();
			this.CityComboBox = new System.Windows.Forms.ComboBox();
			this.CityLabel = new System.Windows.Forms.Label();
			this.OKbutton = new System.Windows.Forms.Button();
			this.cancelbutton = new System.Windows.Forms.Button();
			airPortNameLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.airPortInfoBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.citiesListBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.countriesListBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// airPortNameLabel
			// 
			airPortNameLabel.AutoSize = true;
			airPortNameLabel.Location = new System.Drawing.Point(12, 9);
			airPortNameLabel.Name = "airPortNameLabel";
			airPortNameLabel.Size = new System.Drawing.Size(116, 13);
			airPortNameLabel.TabIndex = 1;
			airPortNameLabel.Text = "Название аэропорта:";
			// 
			// airPortNameTextBox
			// 
			this.airPortNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.airPortInfoBindingSource, "AirPortName", true));
			this.airPortNameTextBox.Location = new System.Drawing.Point(134, 6);
			this.airPortNameTextBox.Name = "airPortNameTextBox";
			this.airPortNameTextBox.Size = new System.Drawing.Size(253, 20);
			this.airPortNameTextBox.TabIndex = 2;
			// 
			// airPortInfoBindingSource
			// 
			this.airPortInfoBindingSource.DataSource = typeof(AirportLibrary.AirPortInfo);
			// 
			// citiesListBindingSource
			// 
			this.citiesListBindingSource.DataSource = typeof(AirportLibrary.CityInfo);
			// 
			// countriesListBindingSource
			// 
			this.countriesListBindingSource.DataSource = typeof(AirportLibrary.CountryInfo);
			// 
			// countryComboBox
			// 
			this.countryComboBox.DataSource = this.countriesListBindingSource;
			this.countryComboBox.DisplayMember = "CountryName";
			this.countryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.countryComboBox.FormattingEnabled = true;
			this.countryComboBox.Location = new System.Drawing.Point(134, 56);
			this.countryComboBox.Name = "countryComboBox";
			this.countryComboBox.Size = new System.Drawing.Size(253, 21);
			this.countryComboBox.TabIndex = 3;
			this.countryComboBox.ValueMember = "CountryID";
			this.countryComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// CountryLabel
			// 
			this.CountryLabel.AutoSize = true;
			this.CountryLabel.Location = new System.Drawing.Point(85, 59);
			this.CountryLabel.Name = "CountryLabel";
			this.CountryLabel.Size = new System.Drawing.Size(43, 13);
			this.CountryLabel.TabIndex = 4;
			this.CountryLabel.Text = "Страна";
			// 
			// CityComboBox
			// 
			this.CityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CityComboBox.FormattingEnabled = true;
			this.CityComboBox.Location = new System.Drawing.Point(134, 114);
			this.CityComboBox.Name = "CityComboBox";
			this.CityComboBox.Size = new System.Drawing.Size(253, 21);
			this.CityComboBox.TabIndex = 5;
			// 
			// CityLabel
			// 
			this.CityLabel.AutoSize = true;
			this.CityLabel.Location = new System.Drawing.Point(93, 117);
			this.CityLabel.Name = "CityLabel";
			this.CityLabel.Size = new System.Drawing.Size(37, 13);
			this.CityLabel.TabIndex = 6;
			this.CityLabel.Text = "Город";
			// 
			// OKbutton
			// 
			this.OKbutton.Location = new System.Drawing.Point(13, 154);
			this.OKbutton.Name = "OKbutton";
			this.OKbutton.Size = new System.Drawing.Size(75, 23);
			this.OKbutton.TabIndex = 7;
			this.OKbutton.Text = "OK";
			this.OKbutton.UseVisualStyleBackColor = true;
			this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
			// 
			// cancelbutton
			// 
			this.cancelbutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelbutton.Location = new System.Drawing.Point(95, 154);
			this.cancelbutton.Name = "cancelbutton";
			this.cancelbutton.Size = new System.Drawing.Size(75, 23);
			this.cancelbutton.TabIndex = 8;
			this.cancelbutton.Text = "Отмена";
			this.cancelbutton.UseVisualStyleBackColor = true;
			// 
			// AirPortEditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(395, 198);
			this.Controls.Add(this.cancelbutton);
			this.Controls.Add(this.OKbutton);
			this.Controls.Add(this.CityLabel);
			this.Controls.Add(this.CityComboBox);
			this.Controls.Add(this.CountryLabel);
			this.Controls.Add(this.countryComboBox);
			this.Controls.Add(airPortNameLabel);
			this.Controls.Add(this.airPortNameTextBox);
			this.Name = "AirPortEditForm";
			this.Text = "Аэропорт";
			this.Load += new System.EventHandler(this.AirPortEditForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.airPortInfoBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.citiesListBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.countriesListBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource airPortInfoBindingSource;
        private System.Windows.Forms.TextBox airPortNameTextBox;
        private System.Windows.Forms.BindingSource citiesListBindingSource;
        private System.Windows.Forms.BindingSource countriesListBindingSource;
        private System.Windows.Forms.ComboBox countryComboBox;
        private System.Windows.Forms.Label CountryLabel;
        private System.Windows.Forms.ComboBox CityComboBox;
        private System.Windows.Forms.Label CityLabel;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.Button cancelbutton;

    }
}
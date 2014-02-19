namespace CitiesSolution
{
    partial class CityEditForm
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
			System.Windows.Forms.Label gMTLabel;
			System.Windows.Forms.Label cityNameLabel;
			System.Windows.Forms.Label populationLabel;
			System.Windows.Forms.Label countryIDLabel;
			this.gMTDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.citiesListBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.cityNameTextBox = new System.Windows.Forms.TextBox();
			this.populationTextBox = new System.Windows.Forms.TextBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.countryIDcomboBox = new System.Windows.Forms.ComboBox();
			this.countriesListBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
			gMTLabel = new System.Windows.Forms.Label();
			cityNameLabel = new System.Windows.Forms.Label();
			populationLabel = new System.Windows.Forms.Label();
			countryIDLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.citiesListBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.countriesListBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// gMTLabel
			// 
			gMTLabel.AutoSize = true;
			gMTLabel.Location = new System.Drawing.Point(33, 81);
			gMTLabel.Name = "gMTLabel";
			gMTLabel.Size = new System.Drawing.Size(81, 13);
			gMTLabel.TabIndex = 1;
			gMTLabel.Text = "Часовой пояс:";
			// 
			// cityNameLabel
			// 
			cityNameLabel.AutoSize = true;
			cityNameLabel.Location = new System.Drawing.Point(16, 49);
			cityNameLabel.Name = "cityNameLabel";
			cityNameLabel.Size = new System.Drawing.Size(98, 13);
			cityNameLabel.TabIndex = 3;
			cityNameLabel.Text = "Название города:";
			// 
			// populationLabel
			// 
			populationLabel.AutoSize = true;
			populationLabel.Location = new System.Drawing.Point(48, 113);
			populationLabel.Name = "populationLabel";
			populationLabel.Size = new System.Drawing.Size(66, 13);
			populationLabel.TabIndex = 4;
			populationLabel.Text = "Население:";
			// 
			// countryIDLabel
			// 
			countryIDLabel.AutoSize = true;
			countryIDLabel.Location = new System.Drawing.Point(68, 18);
			countryIDLabel.Name = "countryIDLabel";
			countryIDLabel.Size = new System.Drawing.Size(46, 13);
			countryIDLabel.TabIndex = 7;
			countryIDLabel.Text = "Страна:";
			// 
			// gMTDateTimePicker
			// 
			this.gMTDateTimePicker.CustomFormat = "HH:mm";
			this.gMTDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.citiesListBindingSource, "GMT", true));
			this.gMTDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.gMTDateTimePicker.Location = new System.Drawing.Point(164, 78);
			this.gMTDateTimePicker.Name = "gMTDateTimePicker";
			this.gMTDateTimePicker.ShowUpDown = true;
			this.gMTDateTimePicker.Size = new System.Drawing.Size(208, 20);
			this.gMTDateTimePicker.TabIndex = 2;
			// 
			// citiesListBindingSource
			// 
			this.citiesListBindingSource.DataSource = typeof(AirportLibrary.CityInfo);
			// 
			// cityNameTextBox
			// 
			this.cityNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.citiesListBindingSource, "CityName", true));
			this.cityNameTextBox.Location = new System.Drawing.Point(120, 46);
			this.cityNameTextBox.Name = "cityNameTextBox";
			this.cityNameTextBox.Size = new System.Drawing.Size(252, 20);
			this.cityNameTextBox.TabIndex = 4;
			// 
			// populationTextBox
			// 
			this.populationTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.citiesListBindingSource, "Population", true));
			this.populationTextBox.Location = new System.Drawing.Point(120, 110);
			this.populationTextBox.Name = "populationTextBox";
			this.populationTextBox.Size = new System.Drawing.Size(252, 20);
			this.populationTextBox.TabIndex = 5;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "+",
            "-"});
			this.comboBox1.Location = new System.Drawing.Point(120, 78);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(38, 21);
			this.comboBox1.TabIndex = 6;
			// 
			// countryIDcomboBox
			// 
			this.countryIDcomboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.citiesListBindingSource, "CountryID", true));
			this.countryIDcomboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.citiesListBindingSource, "CountryID", true));
			this.countryIDcomboBox.DataSource = this.countriesListBindingSource;
			this.countryIDcomboBox.DisplayMember = "CountryName";
			this.countryIDcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.countryIDcomboBox.FormattingEnabled = true;
			this.countryIDcomboBox.Location = new System.Drawing.Point(120, 15);
			this.countryIDcomboBox.Name = "countryIDcomboBox";
			this.countryIDcomboBox.Size = new System.Drawing.Size(252, 21);
			this.countryIDcomboBox.TabIndex = 8;
			this.countryIDcomboBox.ValueMember = "CountryID";
			// 
			// countriesListBindingSource
			// 
			this.countriesListBindingSource.DataSource = typeof(AirportLibrary.CountryInfo);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(296, 140);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 9;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonOk
			// 
			this.buttonOk.Location = new System.Drawing.Point(215, 140);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 23);
			this.buttonOk.TabIndex = 10;
			this.buttonOk.Text = "ОК";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// CityEditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(393, 260);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.countryIDcomboBox);
			this.Controls.Add(countryIDLabel);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(populationLabel);
			this.Controls.Add(this.populationTextBox);
			this.Controls.Add(cityNameLabel);
			this.Controls.Add(this.cityNameTextBox);
			this.Controls.Add(gMTLabel);
			this.Controls.Add(this.gMTDateTimePicker);
			this.Name = "CityEditForm";
			this.Text = "Город - ";
			this.Load += new System.EventHandler(this.CityEditForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.citiesListBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.countriesListBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource citiesListBindingSource;
        private System.Windows.Forms.DateTimePicker gMTDateTimePicker;
        private System.Windows.Forms.TextBox cityNameTextBox;
        private System.Windows.Forms.TextBox populationTextBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox countryIDcomboBox;
        private System.Windows.Forms.BindingSource countriesListBindingSource;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
    }
}
namespace AirportLibrary
{
	partial class FlightListControl
	{
		/// <summary> 
		/// Требуется переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором компонентов

		/// <summary> 
		/// Обязательный метод для поддержки конструктора - не изменяйте 
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.headerLabel = new System.Windows.Forms.Label();
			this.startDateLabel = new System.Windows.Forms.Label();
			this.noBeginDateButton = new System.Windows.Forms.RadioButton();
			this.currentBeginDateButton = new System.Windows.Forms.RadioButton();
			this.iWantToSelectBeginDateButton = new System.Windows.Forms.RadioButton();
			this.endDateLabel = new System.Windows.Forms.Label();
			this.noEndDateButton = new System.Windows.Forms.RadioButton();
			this.iWantToSelectEndDateButton = new System.Windows.Forms.RadioButton();
			this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.countryComboBox = new System.Windows.Forms.ComboBox();
			this.cityComboBox = new System.Windows.Forms.ComboBox();
			this.airportComboBox = new System.Windows.Forms.ComboBox();
			this.findButton = new System.Windows.Forms.Button();
			this.flightsDataGridView = new System.Windows.Forms.DataGridView();
			this.eventButton = new System.Windows.Forms.Button();
			this.unexEventButton = new System.Windows.Forms.Button();
			this.passengersButton = new System.Windows.Forms.Button();
			this.buyersButton = new System.Windows.Forms.Button();
			this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.aircompanyIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.planeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.airPortIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.aircompanyNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.planeModelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.countryNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cityNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.airportNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.flightTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dateTimeStartDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.durationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dateTimeArrivalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dateTimeStartGMTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dateTimeArrivalGMTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.priceEconomDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.priceBusinessDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.priceFirstDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.flightListBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.flightsDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.flightListBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// headerLabel
			// 
			this.headerLabel.AutoSize = true;
			this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.headerLabel.Location = new System.Drawing.Point(71, 0);
			this.headerLabel.Name = "headerLabel";
			this.headerLabel.Size = new System.Drawing.Size(360, 20);
			this.headerLabel.TabIndex = 0;
			this.headerLabel.Text = "Поиск рейса. Введите параметры поиска";
			// 
			// startDateLabel
			// 
			this.startDateLabel.AutoSize = true;
			this.startDateLabel.Location = new System.Drawing.Point(4, 31);
			this.startDateLabel.Name = "startDateLabel";
			this.startDateLabel.Size = new System.Drawing.Size(90, 13);
			this.startDateLabel.TabIndex = 1;
			this.startDateLabel.Text = "Начиная с даты:";
			// 
			// noBeginDateButton
			// 
			this.noBeginDateButton.AutoSize = true;
			this.noBeginDateButton.Checked = true;
			this.noBeginDateButton.Location = new System.Drawing.Point(5, 3);
			this.noBeginDateButton.Name = "noBeginDateButton";
			this.noBeginDateButton.Size = new System.Drawing.Size(71, 17);
			this.noBeginDateButton.TabIndex = 2;
			this.noBeginDateButton.TabStop = true;
			this.noBeginDateButton.Text = "Неважно";
			this.noBeginDateButton.UseVisualStyleBackColor = true;
			// 
			// currentBeginDateButton
			// 
			this.currentBeginDateButton.AutoSize = true;
			this.currentBeginDateButton.Location = new System.Drawing.Point(5, 27);
			this.currentBeginDateButton.Name = "currentBeginDateButton";
			this.currentBeginDateButton.Size = new System.Drawing.Size(67, 17);
			this.currentBeginDateButton.TabIndex = 3;
			this.currentBeginDateButton.Text = "Сегодня";
			this.currentBeginDateButton.UseVisualStyleBackColor = true;
			// 
			// iWantToSelectBeginDateButton
			// 
			this.iWantToSelectBeginDateButton.AutoSize = true;
			this.iWantToSelectBeginDateButton.Location = new System.Drawing.Point(5, 51);
			this.iWantToSelectBeginDateButton.Name = "iWantToSelectBeginDateButton";
			this.iWantToSelectBeginDateButton.Size = new System.Drawing.Size(86, 17);
			this.iWantToSelectBeginDateButton.TabIndex = 4;
			this.iWantToSelectBeginDateButton.Text = "Сам выберу";
			this.iWantToSelectBeginDateButton.UseVisualStyleBackColor = true;
			this.iWantToSelectBeginDateButton.CheckedChanged += new System.EventHandler(this.iWantToSelectBeginDateButton_CheckedChanged);
			// 
			// endDateLabel
			// 
			this.endDateLabel.AutoSize = true;
			this.endDateLabel.Location = new System.Drawing.Point(236, 55);
			this.endDateLabel.Name = "endDateLabel";
			this.endDateLabel.Size = new System.Drawing.Size(102, 13);
			this.endDateLabel.TabIndex = 5;
			this.endDateLabel.Text = "Заканчивая датой:";
			// 
			// noEndDateButton
			// 
			this.noEndDateButton.AutoSize = true;
			this.noEndDateButton.Checked = true;
			this.noEndDateButton.Location = new System.Drawing.Point(3, 3);
			this.noEndDateButton.Name = "noEndDateButton";
			this.noEndDateButton.Size = new System.Drawing.Size(71, 17);
			this.noEndDateButton.TabIndex = 2;
			this.noEndDateButton.TabStop = true;
			this.noEndDateButton.Text = "Неважно";
			this.noEndDateButton.UseVisualStyleBackColor = true;
			// 
			// iWantToSelectEndDateButton
			// 
			this.iWantToSelectEndDateButton.AutoSize = true;
			this.iWantToSelectEndDateButton.Location = new System.Drawing.Point(3, 29);
			this.iWantToSelectEndDateButton.Name = "iWantToSelectEndDateButton";
			this.iWantToSelectEndDateButton.Size = new System.Drawing.Size(86, 17);
			this.iWantToSelectEndDateButton.TabIndex = 4;
			this.iWantToSelectEndDateButton.Text = "Сам выберу";
			this.iWantToSelectEndDateButton.UseVisualStyleBackColor = true;
			this.iWantToSelectEndDateButton.CheckedChanged += new System.EventHandler(this.iWantToSelectEndDateButton_CheckedChanged);
			// 
			// startDateTimePicker
			// 
			this.startDateTimePicker.Location = new System.Drawing.Point(7, 101);
			this.startDateTimePicker.Name = "startDateTimePicker";
			this.startDateTimePicker.Size = new System.Drawing.Size(200, 20);
			this.startDateTimePicker.TabIndex = 6;
			// 
			// endDateTimePicker
			// 
			this.endDateTimePicker.Location = new System.Drawing.Point(239, 101);
			this.endDateTimePicker.Name = "endDateTimePicker";
			this.endDateTimePicker.Size = new System.Drawing.Size(200, 20);
			this.endDateTimePicker.TabIndex = 6;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.noBeginDateButton);
			this.panel1.Controls.Add(this.currentBeginDateButton);
			this.panel1.Controls.Add(this.iWantToSelectBeginDateButton);
			this.panel1.Location = new System.Drawing.Point(100, 31);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(95, 71);
			this.panel1.TabIndex = 7;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.noEndDateButton);
			this.panel2.Controls.Add(this.iWantToSelectEndDateButton);
			this.panel2.Location = new System.Drawing.Point(344, 51);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(91, 51);
			this.panel2.TabIndex = 8;
			// 
			// countryComboBox
			// 
			this.countryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.countryComboBox.FormattingEnabled = true;
			this.countryComboBox.Location = new System.Drawing.Point(7, 137);
			this.countryComboBox.Name = "countryComboBox";
			this.countryComboBox.Size = new System.Drawing.Size(129, 21);
			this.countryComboBox.TabIndex = 9;
			this.countryComboBox.SelectedValueChanged += new System.EventHandler(this.countryComboBox_SelectedValueChanged);
			// 
			// cityComboBox
			// 
			this.cityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cityComboBox.FormattingEnabled = true;
			this.cityComboBox.Location = new System.Drawing.Point(142, 137);
			this.cityComboBox.Name = "cityComboBox";
			this.cityComboBox.Size = new System.Drawing.Size(129, 21);
			this.cityComboBox.TabIndex = 9;
			this.cityComboBox.SelectedValueChanged += new System.EventHandler(this.cityComboBox_SelectedValueChanged);
			// 
			// airportComboBox
			// 
			this.airportComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.airportComboBox.FormattingEnabled = true;
			this.airportComboBox.Location = new System.Drawing.Point(277, 137);
			this.airportComboBox.Name = "airportComboBox";
			this.airportComboBox.Size = new System.Drawing.Size(129, 21);
			this.airportComboBox.TabIndex = 9;
			// 
			// findButton
			// 
			this.findButton.Location = new System.Drawing.Point(422, 135);
			this.findButton.Name = "findButton";
			this.findButton.Size = new System.Drawing.Size(75, 23);
			this.findButton.TabIndex = 10;
			this.findButton.Text = "Найти";
			this.findButton.UseVisualStyleBackColor = true;
			this.findButton.Click += new System.EventHandler(this.findButton_Click);
			// 
			// flightsDataGridView
			// 
			this.flightsDataGridView.AllowUserToAddRows = false;
			this.flightsDataGridView.AllowUserToDeleteRows = false;
			this.flightsDataGridView.AllowUserToOrderColumns = true;
			this.flightsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flightsDataGridView.AutoGenerateColumns = false;
			this.flightsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.flightsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.flightsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.aircompanyIDDataGridViewTextBoxColumn,
            this.planeIDDataGridViewTextBoxColumn,
            this.airPortIDDataGridViewTextBoxColumn,
            this.aircompanyNameDataGridViewTextBoxColumn,
            this.planeModelDataGridViewTextBoxColumn,
            this.countryNameDataGridViewTextBoxColumn,
            this.cityNameDataGridViewTextBoxColumn,
            this.airportNameDataGridViewTextBoxColumn,
            this.flightTypeDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.dateTimeStartDataGridViewTextBoxColumn,
            this.durationDataGridViewTextBoxColumn,
            this.dateTimeArrivalDataGridViewTextBoxColumn,
            this.dateTimeStartGMTDataGridViewTextBoxColumn,
            this.dateTimeArrivalGMTDataGridViewTextBoxColumn,
            this.priceEconomDataGridViewTextBoxColumn,
            this.priceBusinessDataGridViewTextBoxColumn,
            this.priceFirstDataGridViewTextBoxColumn});
			this.flightsDataGridView.DataSource = this.flightListBindingSource;
			this.flightsDataGridView.Location = new System.Drawing.Point(7, 176);
			this.flightsDataGridView.Name = "flightsDataGridView";
			this.flightsDataGridView.ReadOnly = true;
			this.flightsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.flightsDataGridView.Size = new System.Drawing.Size(490, 212);
			this.flightsDataGridView.TabIndex = 11;
			this.flightsDataGridView.SelectionChanged += new System.EventHandler(this.flightsDataGridView_SelectionChanged);
			// 
			// eventButton
			// 
			this.eventButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.eventButton.Location = new System.Drawing.Point(7, 394);
			this.eventButton.Name = "eventButton";
			this.eventButton.Size = new System.Drawing.Size(75, 23);
			this.eventButton.TabIndex = 15;
			this.eventButton.Text = "События";
			this.eventButton.UseVisualStyleBackColor = true;
			// 
			// unexEventButton
			// 
			this.unexEventButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.unexEventButton.Location = new System.Drawing.Point(89, 394);
			this.unexEventButton.Name = "unexEventButton";
			this.unexEventButton.Size = new System.Drawing.Size(157, 23);
			this.unexEventButton.TabIndex = 16;
			this.unexEventButton.Text = "Непредвиденные события";
			this.unexEventButton.UseVisualStyleBackColor = true;
			// 
			// passengersButton
			// 
			this.passengersButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.passengersButton.Location = new System.Drawing.Point(252, 394);
			this.passengersButton.Name = "passengersButton";
			this.passengersButton.Size = new System.Drawing.Size(75, 23);
			this.passengersButton.TabIndex = 17;
			this.passengersButton.Text = "Пассажиры";
			this.passengersButton.UseVisualStyleBackColor = true;
			// 
			// buyersButton
			// 
			this.buyersButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buyersButton.Location = new System.Drawing.Point(333, 394);
			this.buyersButton.Name = "buyersButton";
			this.buyersButton.Size = new System.Drawing.Size(157, 23);
			this.buyersButton.TabIndex = 18;
			this.buyersButton.Text = "Покупатели билетов";
			this.buyersButton.UseVisualStyleBackColor = true;
			// 
			// iDDataGridViewTextBoxColumn
			// 
			this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
			this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
			this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
			this.iDDataGridViewTextBoxColumn.ReadOnly = true;
			this.iDDataGridViewTextBoxColumn.Visible = false;
			// 
			// aircompanyIDDataGridViewTextBoxColumn
			// 
			this.aircompanyIDDataGridViewTextBoxColumn.DataPropertyName = "AircompanyID";
			this.aircompanyIDDataGridViewTextBoxColumn.HeaderText = "AircompanyID";
			this.aircompanyIDDataGridViewTextBoxColumn.Name = "aircompanyIDDataGridViewTextBoxColumn";
			this.aircompanyIDDataGridViewTextBoxColumn.ReadOnly = true;
			this.aircompanyIDDataGridViewTextBoxColumn.Visible = false;
			// 
			// planeIDDataGridViewTextBoxColumn
			// 
			this.planeIDDataGridViewTextBoxColumn.DataPropertyName = "PlaneID";
			this.planeIDDataGridViewTextBoxColumn.HeaderText = "PlaneID";
			this.planeIDDataGridViewTextBoxColumn.Name = "planeIDDataGridViewTextBoxColumn";
			this.planeIDDataGridViewTextBoxColumn.ReadOnly = true;
			this.planeIDDataGridViewTextBoxColumn.Visible = false;
			// 
			// airPortIDDataGridViewTextBoxColumn
			// 
			this.airPortIDDataGridViewTextBoxColumn.DataPropertyName = "AirPortID";
			this.airPortIDDataGridViewTextBoxColumn.HeaderText = "AirPortID";
			this.airPortIDDataGridViewTextBoxColumn.Name = "airPortIDDataGridViewTextBoxColumn";
			this.airPortIDDataGridViewTextBoxColumn.ReadOnly = true;
			this.airPortIDDataGridViewTextBoxColumn.Visible = false;
			// 
			// aircompanyNameDataGridViewTextBoxColumn
			// 
			this.aircompanyNameDataGridViewTextBoxColumn.DataPropertyName = "AircompanyName";
			this.aircompanyNameDataGridViewTextBoxColumn.HeaderText = "Авиакомпания";
			this.aircompanyNameDataGridViewTextBoxColumn.Name = "aircompanyNameDataGridViewTextBoxColumn";
			this.aircompanyNameDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// planeModelDataGridViewTextBoxColumn
			// 
			this.planeModelDataGridViewTextBoxColumn.DataPropertyName = "PlaneModel";
			this.planeModelDataGridViewTextBoxColumn.HeaderText = "Борт";
			this.planeModelDataGridViewTextBoxColumn.Name = "planeModelDataGridViewTextBoxColumn";
			this.planeModelDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// countryNameDataGridViewTextBoxColumn
			// 
			this.countryNameDataGridViewTextBoxColumn.DataPropertyName = "CountryName";
			this.countryNameDataGridViewTextBoxColumn.HeaderText = "Страна";
			this.countryNameDataGridViewTextBoxColumn.Name = "countryNameDataGridViewTextBoxColumn";
			this.countryNameDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// cityNameDataGridViewTextBoxColumn
			// 
			this.cityNameDataGridViewTextBoxColumn.DataPropertyName = "CityName";
			this.cityNameDataGridViewTextBoxColumn.HeaderText = "Город";
			this.cityNameDataGridViewTextBoxColumn.Name = "cityNameDataGridViewTextBoxColumn";
			this.cityNameDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// airportNameDataGridViewTextBoxColumn
			// 
			this.airportNameDataGridViewTextBoxColumn.DataPropertyName = "AirportName";
			this.airportNameDataGridViewTextBoxColumn.HeaderText = "Аэропорт";
			this.airportNameDataGridViewTextBoxColumn.Name = "airportNameDataGridViewTextBoxColumn";
			this.airportNameDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// flightTypeDataGridViewTextBoxColumn
			// 
			this.flightTypeDataGridViewTextBoxColumn.DataPropertyName = "FlightType";
			this.flightTypeDataGridViewTextBoxColumn.HeaderText = "Рейс";
			this.flightTypeDataGridViewTextBoxColumn.Name = "flightTypeDataGridViewTextBoxColumn";
			this.flightTypeDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// statusDataGridViewTextBoxColumn
			// 
			this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
			this.statusDataGridViewTextBoxColumn.HeaderText = "Статус";
			this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
			this.statusDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// dateTimeStartDataGridViewTextBoxColumn
			// 
			this.dateTimeStartDataGridViewTextBoxColumn.DataPropertyName = "DateTimeStart";
			this.dateTimeStartDataGridViewTextBoxColumn.HeaderText = "Вылет";
			this.dateTimeStartDataGridViewTextBoxColumn.Name = "dateTimeStartDataGridViewTextBoxColumn";
			this.dateTimeStartDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// durationDataGridViewTextBoxColumn
			// 
			this.durationDataGridViewTextBoxColumn.DataPropertyName = "Duration";
			this.durationDataGridViewTextBoxColumn.HeaderText = "В пути";
			this.durationDataGridViewTextBoxColumn.Name = "durationDataGridViewTextBoxColumn";
			this.durationDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// dateTimeArrivalDataGridViewTextBoxColumn
			// 
			this.dateTimeArrivalDataGridViewTextBoxColumn.DataPropertyName = "DateTimeArrival";
			this.dateTimeArrivalDataGridViewTextBoxColumn.HeaderText = "Прибывает";
			this.dateTimeArrivalDataGridViewTextBoxColumn.Name = "dateTimeArrivalDataGridViewTextBoxColumn";
			this.dateTimeArrivalDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// dateTimeStartGMTDataGridViewTextBoxColumn
			// 
			this.dateTimeStartGMTDataGridViewTextBoxColumn.DataPropertyName = "DateTimeStartGMT";
			this.dateTimeStartGMTDataGridViewTextBoxColumn.HeaderText = "DateTimeStartGMT";
			this.dateTimeStartGMTDataGridViewTextBoxColumn.Name = "dateTimeStartGMTDataGridViewTextBoxColumn";
			this.dateTimeStartGMTDataGridViewTextBoxColumn.ReadOnly = true;
			this.dateTimeStartGMTDataGridViewTextBoxColumn.Visible = false;
			// 
			// dateTimeArrivalGMTDataGridViewTextBoxColumn
			// 
			this.dateTimeArrivalGMTDataGridViewTextBoxColumn.DataPropertyName = "DateTimeArrivalGMT";
			this.dateTimeArrivalGMTDataGridViewTextBoxColumn.HeaderText = "DateTimeArrivalGMT";
			this.dateTimeArrivalGMTDataGridViewTextBoxColumn.Name = "dateTimeArrivalGMTDataGridViewTextBoxColumn";
			this.dateTimeArrivalGMTDataGridViewTextBoxColumn.ReadOnly = true;
			this.dateTimeArrivalGMTDataGridViewTextBoxColumn.Visible = false;
			// 
			// priceEconomDataGridViewTextBoxColumn
			// 
			this.priceEconomDataGridViewTextBoxColumn.DataPropertyName = "PriceEconom";
			this.priceEconomDataGridViewTextBoxColumn.HeaderText = "PriceEconom";
			this.priceEconomDataGridViewTextBoxColumn.Name = "priceEconomDataGridViewTextBoxColumn";
			this.priceEconomDataGridViewTextBoxColumn.ReadOnly = true;
			this.priceEconomDataGridViewTextBoxColumn.Visible = false;
			// 
			// priceBusinessDataGridViewTextBoxColumn
			// 
			this.priceBusinessDataGridViewTextBoxColumn.DataPropertyName = "PriceBusiness";
			this.priceBusinessDataGridViewTextBoxColumn.HeaderText = "PriceBusiness";
			this.priceBusinessDataGridViewTextBoxColumn.Name = "priceBusinessDataGridViewTextBoxColumn";
			this.priceBusinessDataGridViewTextBoxColumn.ReadOnly = true;
			this.priceBusinessDataGridViewTextBoxColumn.Visible = false;
			// 
			// priceFirstDataGridViewTextBoxColumn
			// 
			this.priceFirstDataGridViewTextBoxColumn.DataPropertyName = "PriceFirst";
			this.priceFirstDataGridViewTextBoxColumn.HeaderText = "PriceFirst";
			this.priceFirstDataGridViewTextBoxColumn.Name = "priceFirstDataGridViewTextBoxColumn";
			this.priceFirstDataGridViewTextBoxColumn.ReadOnly = true;
			this.priceFirstDataGridViewTextBoxColumn.Visible = false;
			// 
			// flightListBindingSource
			// 
			this.flightListBindingSource.DataSource = typeof(AirportLibrary.FlightList);
			// 
			// FlightListControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.buyersButton);
			this.Controls.Add(this.passengersButton);
			this.Controls.Add(this.unexEventButton);
			this.Controls.Add(this.eventButton);
			this.Controls.Add(this.flightsDataGridView);
			this.Controls.Add(this.findButton);
			this.Controls.Add(this.airportComboBox);
			this.Controls.Add(this.cityComboBox);
			this.Controls.Add(this.countryComboBox);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.endDateTimePicker);
			this.Controls.Add(this.startDateTimePicker);
			this.Controls.Add(this.endDateLabel);
			this.Controls.Add(this.startDateLabel);
			this.Controls.Add(this.headerLabel);
			this.MinimumSize = new System.Drawing.Size(500, 400);
			this.Name = "FlightListControl";
			this.Size = new System.Drawing.Size(500, 425);
			this.Load += new System.EventHandler(this.FlightListControl_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.flightsDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.flightListBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label headerLabel;
		private System.Windows.Forms.Label startDateLabel;
		private System.Windows.Forms.RadioButton noBeginDateButton;
		private System.Windows.Forms.RadioButton currentBeginDateButton;
		private System.Windows.Forms.RadioButton iWantToSelectBeginDateButton;
		private System.Windows.Forms.Label endDateLabel;
		private System.Windows.Forms.RadioButton noEndDateButton;
		private System.Windows.Forms.RadioButton iWantToSelectEndDateButton;
		private System.Windows.Forms.DateTimePicker startDateTimePicker;
		private System.Windows.Forms.DateTimePicker endDateTimePicker;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ComboBox countryComboBox;
		private System.Windows.Forms.ComboBox cityComboBox;
		private System.Windows.Forms.ComboBox airportComboBox;
		private System.Windows.Forms.Button findButton;
		private System.Windows.Forms.DataGridView flightsDataGridView;
		private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn aircompanyIDDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn planeIDDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn airPortIDDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn aircompanyNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn planeModelDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn countryNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn cityNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn airportNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn flightTypeDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn dateTimeStartDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn dateTimeArrivalDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn dateTimeStartGMTDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn dateTimeArrivalGMTDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn priceEconomDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn priceBusinessDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn priceFirstDataGridViewTextBoxColumn;
		private System.Windows.Forms.BindingSource flightListBindingSource;
		private System.Windows.Forms.Button eventButton;
		private System.Windows.Forms.Button unexEventButton;
		private System.Windows.Forms.Button passengersButton;
		private System.Windows.Forms.Button buyersButton;
	}
}

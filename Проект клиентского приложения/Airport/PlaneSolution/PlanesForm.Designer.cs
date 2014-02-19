namespace PlaneSolution
{
	partial class PlanesForm
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

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.refreshButton = new System.Windows.Forms.Button();
			this.addButton = new System.Windows.Forms.Button();
			this.deleteButton = new System.Windows.Forms.Button();
			this.editButton = new System.Windows.Forms.Button();
			this.planeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.aircompanyIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.planeModelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.planeNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.aircompanyNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.planesListBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.planesListBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToOrderColumns = true;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.planeIDDataGridViewTextBoxColumn,
            this.aircompanyIDDataGridViewTextBoxColumn,
            this.planeModelDataGridViewTextBoxColumn,
            this.planeNumberDataGridViewTextBoxColumn,
            this.aircompanyNameDataGridViewTextBoxColumn});
			this.dataGridView1.DataSource = this.planesListBindingSource;
			this.dataGridView1.Location = new System.Drawing.Point(13, 13);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(485, 259);
			this.dataGridView1.TabIndex = 0;
			// 
			// refreshButton
			// 
			this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.refreshButton.Location = new System.Drawing.Point(13, 278);
			this.refreshButton.Name = "refreshButton";
			this.refreshButton.Size = new System.Drawing.Size(75, 23);
			this.refreshButton.TabIndex = 1;
			this.refreshButton.Text = "Обновить";
			this.refreshButton.UseVisualStyleBackColor = true;
			this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
			// 
			// addButton
			// 
			this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.addButton.Location = new System.Drawing.Point(94, 278);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(75, 23);
			this.addButton.TabIndex = 2;
			this.addButton.Text = "Добавить";
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// deleteButton
			// 
			this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.deleteButton.Location = new System.Drawing.Point(175, 278);
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.Size = new System.Drawing.Size(75, 23);
			this.deleteButton.TabIndex = 3;
			this.deleteButton.Text = "Удалить";
			this.deleteButton.UseVisualStyleBackColor = true;
			this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
			// 
			// editButton
			// 
			this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.editButton.Location = new System.Drawing.Point(256, 278);
			this.editButton.Name = "editButton";
			this.editButton.Size = new System.Drawing.Size(75, 23);
			this.editButton.TabIndex = 4;
			this.editButton.Text = "Исправить";
			this.editButton.UseVisualStyleBackColor = true;
			this.editButton.Click += new System.EventHandler(this.editButton_Click);
			// 
			// planeIDDataGridViewTextBoxColumn
			// 
			this.planeIDDataGridViewTextBoxColumn.DataPropertyName = "PlaneID";
			this.planeIDDataGridViewTextBoxColumn.HeaderText = "PlaneID";
			this.planeIDDataGridViewTextBoxColumn.Name = "planeIDDataGridViewTextBoxColumn";
			this.planeIDDataGridViewTextBoxColumn.ReadOnly = true;
			this.planeIDDataGridViewTextBoxColumn.Visible = false;
			// 
			// aircompanyIDDataGridViewTextBoxColumn
			// 
			this.aircompanyIDDataGridViewTextBoxColumn.DataPropertyName = "AircompanyID";
			this.aircompanyIDDataGridViewTextBoxColumn.HeaderText = "AircompanyID";
			this.aircompanyIDDataGridViewTextBoxColumn.Name = "aircompanyIDDataGridViewTextBoxColumn";
			this.aircompanyIDDataGridViewTextBoxColumn.ReadOnly = true;
			this.aircompanyIDDataGridViewTextBoxColumn.Visible = false;
			// 
			// planeModelDataGridViewTextBoxColumn
			// 
			this.planeModelDataGridViewTextBoxColumn.DataPropertyName = "PlaneModel";
			this.planeModelDataGridViewTextBoxColumn.HeaderText = "Модель самолёта";
			this.planeModelDataGridViewTextBoxColumn.Name = "planeModelDataGridViewTextBoxColumn";
			this.planeModelDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// planeNumberDataGridViewTextBoxColumn
			// 
			this.planeNumberDataGridViewTextBoxColumn.DataPropertyName = "PlaneNumber";
			this.planeNumberDataGridViewTextBoxColumn.HeaderText = "Бортовой номер";
			this.planeNumberDataGridViewTextBoxColumn.Name = "planeNumberDataGridViewTextBoxColumn";
			this.planeNumberDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// aircompanyNameDataGridViewTextBoxColumn
			// 
			this.aircompanyNameDataGridViewTextBoxColumn.DataPropertyName = "AircompanyName";
			this.aircompanyNameDataGridViewTextBoxColumn.HeaderText = "Владелец";
			this.aircompanyNameDataGridViewTextBoxColumn.Name = "aircompanyNameDataGridViewTextBoxColumn";
			this.aircompanyNameDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// planesListBindingSource
			// 
			this.planesListBindingSource.DataSource = typeof(AirportLibrary.PlanesList);
			// 
			// PlanesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(510, 313);
			this.Controls.Add(this.editButton);
			this.Controls.Add(this.deleteButton);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.refreshButton);
			this.Controls.Add(this.dataGridView1);
			this.Name = "PlanesForm";
			this.Text = "Самолёты";
			this.Load += new System.EventHandler(this.PlanesForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.planesListBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn planeIDDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn aircompanyIDDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn planeModelDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn planeNumberDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn aircompanyNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.BindingSource planesListBindingSource;
		private System.Windows.Forms.Button refreshButton;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Button deleteButton;
		private System.Windows.Forms.Button editButton;
	}
}


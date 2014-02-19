namespace Airport
{
    partial class MainForm
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.LoginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aircompaniesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aircompaniesOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.planesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.airportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.airportsViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.countriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.citiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoginToolStripMenuItem,
            this.editToolStripMenuItem,
            this.dataToolStripMenuItem,
            this.sheduleToolStripMenuItem,
            this.logoutToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(754, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// LoginToolStripMenuItem
			// 
			this.LoginToolStripMenuItem.Name = "LoginToolStripMenuItem";
			this.LoginToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
			this.LoginToolStripMenuItem.Text = "Войти в систему";
			this.LoginToolStripMenuItem.Click += new System.EventHandler(this.LoginToolStripMenuItem_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
			this.editToolStripMenuItem.Text = "Правка";
			// 
			// dataToolStripMenuItem
			// 
			this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aircompaniesToolStripMenuItem,
            this.airportsToolStripMenuItem});
			this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
			this.dataToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
			this.dataToolStripMenuItem.Text = "Данные";
			// 
			// aircompaniesToolStripMenuItem
			// 
			this.aircompaniesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aircompaniesOpenToolStripMenuItem,
            this.planesToolStripMenuItem});
			this.aircompaniesToolStripMenuItem.Name = "aircompaniesToolStripMenuItem";
			this.aircompaniesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.aircompaniesToolStripMenuItem.Text = "Авиакомпании";
			// 
			// aircompaniesOpenToolStripMenuItem
			// 
			this.aircompaniesOpenToolStripMenuItem.Name = "aircompaniesOpenToolStripMenuItem";
			this.aircompaniesOpenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.aircompaniesOpenToolStripMenuItem.Text = "Открыть";
			this.aircompaniesOpenToolStripMenuItem.Click += new System.EventHandler(this.aircompaniesToolStripMenuItem_Click);
			// 
			// planesToolStripMenuItem
			// 
			this.planesToolStripMenuItem.Name = "planesToolStripMenuItem";
			this.planesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.planesToolStripMenuItem.Text = "Самолёты";
			this.planesToolStripMenuItem.Click += new System.EventHandler(this.planesToolStripMenuItem_Click);
			// 
			// airportsToolStripMenuItem
			// 
			this.airportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.airportsViewToolStripMenuItem,
            this.countriesToolStripMenuItem,
            this.citiesToolStripMenuItem});
			this.airportsToolStripMenuItem.Name = "airportsToolStripMenuItem";
			this.airportsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.airportsToolStripMenuItem.Text = "Аэропорты";
			// 
			// airportsViewToolStripMenuItem
			// 
			this.airportsViewToolStripMenuItem.Name = "airportsViewToolStripMenuItem";
			this.airportsViewToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.airportsViewToolStripMenuItem.Text = "Открыть";
			this.airportsViewToolStripMenuItem.Click += new System.EventHandler(this.airportsViewToolStripMenuItem_Click);
			// 
			// countriesToolStripMenuItem
			// 
			this.countriesToolStripMenuItem.Name = "countriesToolStripMenuItem";
			this.countriesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.countriesToolStripMenuItem.Text = "Страны";
			this.countriesToolStripMenuItem.Click += new System.EventHandler(this.countriesToolStripMenuItem_Click);
			// 
			// citiesToolStripMenuItem
			// 
			this.citiesToolStripMenuItem.Name = "citiesToolStripMenuItem";
			this.citiesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.citiesToolStripMenuItem.Text = "Города";
			this.citiesToolStripMenuItem.Click += new System.EventHandler(this.citiesToolStripMenuItem_Click);
			// 
			// sheduleToolStripMenuItem
			// 
			this.sheduleToolStripMenuItem.Name = "sheduleToolStripMenuItem";
			this.sheduleToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
			this.sheduleToolStripMenuItem.Text = "Расписание";
			this.sheduleToolStripMenuItem.Click += new System.EventHandler(this.sheduleToolStripMenuItem_Click);
			// 
			// logoutToolStripMenuItem
			// 
			this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
			this.logoutToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
			this.logoutToolStripMenuItem.Text = "Выйти из системы";
			this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(754, 480);
			this.Controls.Add(this.menuStrip1);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "Аэропорт";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem LoginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aircompaniesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem airportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem airportsViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem countriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem citiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sheduleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aircompaniesOpenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem planesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;

    }
}


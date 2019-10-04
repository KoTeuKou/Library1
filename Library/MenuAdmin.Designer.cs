namespace Library
{
    partial class MenuAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuAdmin));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ДобавитьКнигуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ДобавитьГазетуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ДобавитьЖурналToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.вывестиСписокВсехЧитателейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вывестиТолькоДолжниковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ЗарегистрироватьНовогоЧитателяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ДобавитьКнигуToolStripMenuItem,
            this.ДобавитьГазетуToolStripMenuItem,
            this.ДобавитьЖурналToolStripMenuItem,
            this.toolStripMenuItem4,
            this.ЗарегистрироватьНовогоЧитателяToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(634, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ДобавитьКнигуToolStripMenuItem
            // 
            this.ДобавитьКнигуToolStripMenuItem.Name = "ДобавитьКнигуToolStripMenuItem";
            this.ДобавитьКнигуToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.ДобавитьКнигуToolStripMenuItem.Text = "Добавить книгу";
            this.ДобавитьКнигуToolStripMenuItem.Click += new System.EventHandler(this.ДобавитьКнигуToolStripMenuItem_Click);
            // 
            // ДобавитьГазетуToolStripMenuItem
            // 
            this.ДобавитьГазетуToolStripMenuItem.Name = "ДобавитьГазетуToolStripMenuItem";
            this.ДобавитьГазетуToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.ДобавитьГазетуToolStripMenuItem.Text = "Добавить газету";
            this.ДобавитьГазетуToolStripMenuItem.Click += new System.EventHandler(this.ДобавитьГазетуToolStripMenuItem_Click);
            // 
            // ДобавитьЖурналToolStripMenuItem
            // 
            this.ДобавитьЖурналToolStripMenuItem.Name = "ДобавитьЖурналToolStripMenuItem";
            this.ДобавитьЖурналToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.ДобавитьЖурналToolStripMenuItem.Text = "Добавить журнал";
            this.ДобавитьЖурналToolStripMenuItem.Click += new System.EventHandler(this.ДобавитьЖурналToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вывестиСписокВсехЧитателейToolStripMenuItem,
            this.вывестиТолькоДолжниковToolStripMenuItem});
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(70, 20);
            this.toolStripMenuItem4.Text = "Читатели";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // вывестиСписокВсехЧитателейToolStripMenuItem
            // 
            this.вывестиСписокВсехЧитателейToolStripMenuItem.Name = "вывестиСписокВсехЧитателейToolStripMenuItem";
            this.вывестиСписокВсехЧитателейToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.вывестиСписокВсехЧитателейToolStripMenuItem.Text = "Вывести список всех читателей";
            this.вывестиСписокВсехЧитателейToolStripMenuItem.Click += new System.EventHandler(this.вывестиСписокВсехЧитателейToolStripMenuItem_Click);
            // 
            // вывестиТолькоДолжниковToolStripMenuItem
            // 
            this.вывестиТолькоДолжниковToolStripMenuItem.Name = "вывестиТолькоДолжниковToolStripMenuItem";
            this.вывестиТолькоДолжниковToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.вывестиТолькоДолжниковToolStripMenuItem.Text = "Вывести только должников";
            this.вывестиТолькоДолжниковToolStripMenuItem.Click += new System.EventHandler(this.вывестиТолькоДолжниковToolStripMenuItem_Click);
            // 
            // ЗарегистрироватьНовогоЧитателяToolStripMenuItem
            // 
            this.ЗарегистрироватьНовогоЧитателяToolStripMenuItem.Name = "ЗарегистрироватьНовогоЧитателяToolStripMenuItem";
            this.ЗарегистрироватьНовогоЧитателяToolStripMenuItem.Size = new System.Drawing.Size(213, 20);
            this.ЗарегистрироватьНовогоЧитателяToolStripMenuItem.Text = "Зарегистрировать нового читателя";
            this.ЗарегистрироватьНовогоЧитателяToolStripMenuItem.Click += new System.EventHandler(this.ЗарегистрироватьНовогоЧитателяToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(225, 430);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 25);
            this.button1.TabIndex = 14;
            this.button1.Text = "Выйти из учетной записи";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView1
            // 
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listView1.Location = new System.Drawing.Point(12, 40);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(610, 380);
            this.listView1.TabIndex = 15;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(634, 461);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.Text = "Меню библиотекаря";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ДобавитьКнигуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ДобавитьГазетуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ДобавитьЖурналToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem вывестиСписокВсехЧитателейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вывестиТолькоДолжниковToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem ЗарегистрироватьНовогоЧитателяToolStripMenuItem;
        private System.Windows.Forms.ListView listView1;
    }
}
namespace Shop
{
    partial class History
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(History));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_choosePer = new System.Windows.Forms.Label();
            this.listBox_period = new System.Windows.Forms.ListBox();
            this.listView_History = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label_prodano = new System.Windows.Forms.Label();
            this.label_money = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.Controls.Add(this.label_money);
            this.panel1.Controls.Add(this.label_prodano);
            this.panel1.Controls.Add(this.label_choosePer);
            this.panel1.Controls.Add(this.listBox_period);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 856);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1924, 108);
            this.panel1.TabIndex = 0;
            // 
            // label_choosePer
            // 
            this.label_choosePer.AutoSize = true;
            this.label_choosePer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_choosePer.Location = new System.Drawing.Point(3, 42);
            this.label_choosePer.Name = "label_choosePer";
            this.label_choosePer.Size = new System.Drawing.Size(192, 25);
            this.label_choosePer.TabIndex = 1;
            this.label_choosePer.Text = "Выберите период";
            // 
            // listBox_period
            // 
            this.listBox_period.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox_period.FormattingEnabled = true;
            this.listBox_period.ItemHeight = 25;
            this.listBox_period.Items.AddRange(new object[] {
            "Весь период",
            "Январь",
            "Февраль",
            "Март",
            "Апрель",
            "Май",
            "Июнь",
            "Июль",
            "Август",
            "Сентябрь",
            "Октябрь",
            "Ноябрь",
            "Декабрь"});
            this.listBox_period.Location = new System.Drawing.Point(221, 42);
            this.listBox_period.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox_period.Name = "listBox_period";
            this.listBox_period.Size = new System.Drawing.Size(160, 29);
            this.listBox_period.TabIndex = 0;
            // 
            // listView_History
            // 
            this.listView_History.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader3,
            this.columnHeader4});
            this.listView_History.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_History.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView_History.HideSelection = false;
            this.listView_History.Location = new System.Drawing.Point(0, 0);
            this.listView_History.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView_History.MultiSelect = false;
            this.listView_History.Name = "listView_History";
            this.listView_History.Size = new System.Drawing.Size(1924, 856);
            this.listView_History.TabIndex = 1;
            this.listView_History.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader9
            // 
            this.columnHeader9.DisplayIndex = 6;
            this.columnHeader9.Text = "Id";
            this.columnHeader9.Width = 10;
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 0;
            this.columnHeader1.Text = "Оригинальный номер";
            this.columnHeader1.Width = 180;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 1;
            this.columnHeader2.Text = "Наименование";
            this.columnHeader2.Width = 530;
            // 
            // columnHeader7
            // 
            this.columnHeader7.DisplayIndex = 2;
            this.columnHeader7.Text = "Розничные";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.DisplayIndex = 3;
            this.columnHeader8.Text = "Количество было";
            this.columnHeader8.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.DisplayIndex = 4;
            this.columnHeader3.Text = "Количество стало";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.DisplayIndex = 5;
            this.columnHeader4.Text = "Дата";
            this.columnHeader4.Width = 450;
            // 
            // label_prodano
            // 
            this.label_prodano.AutoSize = true;
            this.label_prodano.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_prodano.Location = new System.Drawing.Point(1320, 42);
            this.label_prodano.Name = "label_prodano";
            this.label_prodano.Size = new System.Drawing.Size(290, 29);
            this.label_prodano.TabIndex = 2;
            this.label_prodano.Text = "ПРОДАНО НА СУММУ:";
            // 
            // label_money
            // 
            this.label_money.AutoSize = true;
            this.label_money.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_money.Location = new System.Drawing.Point(1733, 42);
            this.label_money.Name = "label_money";
            this.label_money.Size = new System.Drawing.Size(34, 29);
            this.label_money.TabIndex = 3;
            this.label_money.Text = "...";
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 964);
            this.Controls.Add(this.listView_History);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1918, 1001);
            this.Name = "History";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "History";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.History_FormClosing);
            this.Load += new System.EventHandler(this.History_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listView_History;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ListBox listBox_period;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label_choosePer;
        private System.Windows.Forms.Label label_money;
        private System.Windows.Forms.Label label_prodano;
    }
}
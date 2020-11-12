namespace Shop
{
    partial class Action
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Action));
            this.label_info = new System.Windows.Forms.Label();
            this.btn_prihod = new System.Windows.Forms.Button();
            this.btn_sell = new System.Windows.Forms.Button();
            this.label_info_count = new System.Windows.Forms.Label();
            this.textBox_count = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_info.Location = new System.Drawing.Point(203, 20);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(215, 25);
            this.label_info.TabIndex = 0;
            this.label_info.Text = "Выберите действие";
            // 
            // btn_prihod
            // 
            this.btn_prihod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_prihod.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_prihod.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_prihod.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btn_prihod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_prihod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_prihod.Location = new System.Drawing.Point(12, 65);
            this.btn_prihod.Name = "btn_prihod";
            this.btn_prihod.Size = new System.Drawing.Size(248, 74);
            this.btn_prihod.TabIndex = 1;
            this.btn_prihod.Text = "Приход товара";
            this.btn_prihod.UseVisualStyleBackColor = false;
            this.btn_prihod.Click += new System.EventHandler(this.btn_prihod_Click);
            // 
            // btn_sell
            // 
            this.btn_sell.BackColor = System.Drawing.Color.OrangeRed;
            this.btn_sell.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_sell.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_sell.FlatAppearance.BorderSize = 2;
            this.btn_sell.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btn_sell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_sell.Location = new System.Drawing.Point(362, 65);
            this.btn_sell.Name = "btn_sell";
            this.btn_sell.Size = new System.Drawing.Size(248, 74);
            this.btn_sell.TabIndex = 2;
            this.btn_sell.Text = "Продажа товара";
            this.btn_sell.UseVisualStyleBackColor = false;
            this.btn_sell.Click += new System.EventHandler(this.btn_sell_Click);
            // 
            // label_info_count
            // 
            this.label_info_count.AutoSize = true;
            this.label_info_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_info_count.Location = new System.Drawing.Point(247, 184);
            this.label_info_count.Name = "label_info_count";
            this.label_info_count.Size = new System.Drawing.Size(133, 25);
            this.label_info_count.TabIndex = 3;
            this.label_info_count.Text = "Количество";
            // 
            // textBox_count
            // 
            this.textBox_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_count.Location = new System.Drawing.Point(252, 212);
            this.textBox_count.Name = "textBox_count";
            this.textBox_count.Size = new System.Drawing.Size(128, 34);
            this.textBox_count.TabIndex = 4;
            // 
            // Action
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(622, 243);
            this.Controls.Add(this.textBox_count);
            this.Controls.Add(this.label_info_count);
            this.Controls.Add(this.btn_sell);
            this.Controls.Add(this.btn_prihod);
            this.Controls.Add(this.label_info);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(640, 290);
            this.MinimumSize = new System.Drawing.Size(640, 290);
            this.Name = "Action";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменение количества товара";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.Button btn_prihod;
        private System.Windows.Forms.Button btn_sell;
        private System.Windows.Forms.Label label_info_count;
        private System.Windows.Forms.TextBox textBox_count;
    }
}
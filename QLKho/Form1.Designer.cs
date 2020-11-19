namespace QLKho
{
    partial class Form1
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
            this.UC_01 = new QLKho.Nhap();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_datHang = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UC_01
            // 
            this.UC_01.BackColor = System.Drawing.Color.DarkRed;
            this.UC_01.Location = new System.Drawing.Point(123, 1);
            this.UC_01.Name = "UC_01";
            this.UC_01.Size = new System.Drawing.Size(728, 485);
            this.UC_01.TabIndex = 0;
            this.UC_01.Load += new System.EventHandler(this.nhap1_Load);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_datHang);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(117, 485);
            this.panel1.TabIndex = 1;
            // 
            // btn_datHang
            // 
            this.btn_datHang.Location = new System.Drawing.Point(3, 11);
            this.btn_datHang.Name = "btn_datHang";
            this.btn_datHang.Size = new System.Drawing.Size(111, 30);
            this.btn_datHang.TabIndex = 0;
            this.btn_datHang.Text = "Đặt hàng";
            this.btn_datHang.UseVisualStyleBackColor = true;
            this.btn_datHang.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 489);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.UC_01);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Nhap UC_01;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_datHang;
    }
}


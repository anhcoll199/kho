namespace QLKho
{
    partial class Nhap
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_Dathang_sanpham = new System.Windows.Forms.ComboBox();
            this.txtB_Dathang_soluong = new System.Windows.Forms.TextBox();
            this.cb_Dathang_ncc = new System.Windows.Forms.ComboBox();
            this.dtp_Dathang_ngaygiao = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(749, 27);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(303, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tạo đơn đặt hàng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cb_Dathang_sanpham
            // 
            this.cb_Dathang_sanpham.FormattingEnabled = true;
            this.cb_Dathang_sanpham.Location = new System.Drawing.Point(9, 13);
            this.cb_Dathang_sanpham.Name = "cb_Dathang_sanpham";
            this.cb_Dathang_sanpham.Size = new System.Drawing.Size(121, 21);
            this.cb_Dathang_sanpham.TabIndex = 1;
            this.cb_Dathang_sanpham.SelectedIndexChanged += new System.EventHandler(this.cb_Dathang_sanpham_SelectedIndexChanged);
            // 
            // txtB_Dathang_soluong
            // 
            this.txtB_Dathang_soluong.Location = new System.Drawing.Point(136, 14);
            this.txtB_Dathang_soluong.Name = "txtB_Dathang_soluong";
            this.txtB_Dathang_soluong.Size = new System.Drawing.Size(100, 20);
            this.txtB_Dathang_soluong.TabIndex = 2;
            // 
            // cb_Dathang_ncc
            // 
            this.cb_Dathang_ncc.FormattingEnabled = true;
            this.cb_Dathang_ncc.Location = new System.Drawing.Point(242, 14);
            this.cb_Dathang_ncc.Name = "cb_Dathang_ncc";
            this.cb_Dathang_ncc.Size = new System.Drawing.Size(121, 21);
            this.cb_Dathang_ncc.TabIndex = 3;
            // 
            // dtp_Dathang_ngaygiao
            // 
            this.dtp_Dathang_ngaygiao.Location = new System.Drawing.Point(370, 14);
            this.dtp_Dathang_ngaygiao.Name = "dtp_Dathang_ngaygiao";
            this.dtp_Dathang_ngaygiao.Size = new System.Drawing.Size(200, 20);
            this.dtp_Dathang_ngaygiao.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.cb_Dathang_ncc);
            this.panel2.Controls.Add(this.dtp_Dathang_ngaygiao);
            this.panel2.Controls.Add(this.cb_Dathang_sanpham);
            this.panel2.Controls.Add(this.txtB_Dathang_soluong);
            this.panel2.Location = new System.Drawing.Point(3, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(752, 105);
            this.panel2.TabIndex = 5;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Get Data Select";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Nhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Nhap";
            this.Size = new System.Drawing.Size(755, 414);
            this.Load += new System.EventHandler(this.Nhap_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_Dathang_sanpham;
        private System.Windows.Forms.TextBox txtB_Dathang_soluong;
        private System.Windows.Forms.ComboBox cb_Dathang_ncc;
        private System.Windows.Forms.DateTimePicker dtp_Dathang_ngaygiao;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
    }
}

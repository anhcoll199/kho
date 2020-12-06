namespace QLKho
{
    partial class Form2
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
            this.BangSup = new System.Windows.Forms.DataGridView();
            this.taoPhieuDatHang1 = new QLKho.TaoPhieuDatHang();
            ((System.ComponentModel.ISupportInitialize)(this.BangSup)).BeginInit();
            this.SuspendLayout();
            // 
            // BangSup
            // 
            this.BangSup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BangSup.Location = new System.Drawing.Point(663, 368);
            this.BangSup.Name = "BangSup";
            this.BangSup.Size = new System.Drawing.Size(100, 166);
            this.BangSup.TabIndex = 0;
            // 
            // taoPhieuDatHang1
            // 
            this.taoPhieuDatHang1.BackColor = System.Drawing.Color.White;
            this.taoPhieuDatHang1.Dock = System.Windows.Forms.DockStyle.Top;
            this.taoPhieuDatHang1.Location = new System.Drawing.Point(0, 0);
            this.taoPhieuDatHang1.Name = "taoPhieuDatHang1";
            this.taoPhieuDatHang1.Size = new System.Drawing.Size(861, 378);
            this.taoPhieuDatHang1.TabIndex = 1;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(861, 546);
            this.Controls.Add(this.taoPhieuDatHang1);
            this.Controls.Add(this.BangSup);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BangSup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView BangSup;
        private TaoPhieuDatHang taoPhieuDatHang1;
    }
}
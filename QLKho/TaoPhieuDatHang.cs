using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace QLKho
{
    public partial class TaoPhieuDatHang : UserControl
    {
        public TaoPhieuDatHang()
        {
            InitializeComponent();
        }

        private void guna2TextBox3_Load(object sender, EventArgs e)
        {
            
        }

        private void guna2TextBox4_Load(object sender, EventArgs e)
        {
            txtStatusOrderDetail.Text = "Chờ xử lí";
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            //UC_DatHang.panelOrdertab2.Visible = true;
        }

        private void guna2TextBox2_Load(object sender, EventArgs e)
        {
            txtNhanVienOrderDetail.Text = LoginVar.ID;
        }
    }
}

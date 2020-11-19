using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            guna2TextBox3.Text = DateTime.Now.ToString("yyyy.MM.dd");
        }

        private void guna2TextBox4_Load(object sender, EventArgs e)
        {
            guna2TextBox4.Text = "Chờ xử lí";
        }
    }
}

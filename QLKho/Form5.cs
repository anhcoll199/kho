using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKho
{
    public partial class Form5 : Form
    {
        String tabActive;
        Color tabActiveColor = Color.FromArgb(52, 152, 219);
        Color FontColor = Color.FromArgb(149, 161, 172);

        User loginUser = new User(LoginVar.ID, LoginVar.Name, LoginVar.Role);
        private void unActive()
        {
            this.tab1.FillColor = Color.White;
            this.tab1.ForeColor = FontColor;

            this.tab2.FillColor = Color.White;
            this.tab2.ForeColor = FontColor;

            this.tab3.FillColor = Color.White;
            this.tab3.ForeColor = FontColor;

            this.tab4.FillColor = Color.White;
            this.tab4.ForeColor = FontColor;

            this.tab5.FillColor = Color.White;
            this.tab5.ForeColor = FontColor;

            this.tab6.FillColor = Color.White;
            this.tab6.ForeColor = FontColor;

            this.tab1.Image = global::QLKho.Properties.Resources.dashboard1;
            this.tab2.Image = global::QLKho.Properties.Resources.checklist__1_;
            this.tab3.Image = global::QLKho.Properties.Resources.import;
            this.tab4.Image = global::QLKho.Properties.Resources.export;
            this.tab5.Image = global::QLKho.Properties.Resources.refresh_1_;
            this.tab6.Image = global::QLKho.Properties.Resources.statistics;

            tabActive = "";
        }
        public Form5()
        {
            InitializeComponent();
            LoginVar.ID = loginUser.ID;
            LoginVar.Name = loginUser.Name;
            LoginVar.Role = loginUser.Role;

            this.Text = "Storage management";

            LoginUserName.Text = loginUser.Name;
            LoginUserRole.Text = loginUser.Role;

            thongTinKho1.Hide();
            uC_DatHang1.Hide();
            uC_NhapHang1.Hide();
            uC_ThongTin1.Hide();
            uC_ThongKe1.Hide();
            xuatHang1.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            //this.guna2DataGridView1.Rows.Add("SP001", "Pepsi");

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }
        private void tab1_Click(object sender, EventArgs e)
        {
            if (thongTinKho1.Visible)
            {
                thongTinKho1.Hide();

                this.tab1.Image = global::QLKho.Properties.Resources.dashboard1;
                unActive();
            }
            else
            {
                thongTinKho1.Show();
                uC_DatHang1.Hide();
                uC_NhapHang1.Hide();
                uC_ThongTin1.Hide();
                uC_ThongKe1.Hide();

                unActive();

                this.tab1.Image = global::QLKho.Properties.Resources.dashboard;
                this.tab1.FillColor = tabActiveColor;
                this.tab1.ForeColor = Color.White;
                tabActive = "tab1";
            }
        }

        private void tab2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Oh noes!", "My Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (uC_DatHang1.Visible)
            {
                uC_DatHang1.Hide();
                this.tab2.Image = global::QLKho.Properties.Resources.dashboard1;

                unActive();
            }
            else
            {
                uC_DatHang1.Show();
                thongTinKho1.Hide();
                uC_NhapHang1.Hide();
                uC_ThongTin1.Hide();
                uC_ThongKe1.Hide();

                unActive();

                this.tab2.Image = global::QLKho.Properties.Resources.checklist;
                this.tab2.FillColor = tabActiveColor;
                this.tab2.ForeColor = Color.White;
                tabActive = "tab2";
            }

        }

        private void tab3_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Oh noes!", "My Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (uC_NhapHang1.Visible)
            {
                uC_NhapHang1.Hide();
                this.tab3.Image = global::QLKho.Properties.Resources.dashboard1;

                unActive();
            }
            else
            {
                uC_NhapHang1.Show();
                thongTinKho1.Hide();
                uC_DatHang1.Hide();
                uC_ThongTin1.Hide();
                uC_ThongKe1.Hide();

                unActive();

                this.tab3.Image = global::QLKho.Properties.Resources.import__1_;
                this.tab3.FillColor = tabActiveColor;
                this.tab3.ForeColor = Color.White;
                tabActive = "tab3";
            }
        }

        private void tab5_Click(object sender, EventArgs e)
        {
            if (uC_ThongTin1.Visible)
            {
                uC_ThongTin1.Hide();
                this.tab5.Image = global::QLKho.Properties.Resources.dashboard1;

                unActive();
            }
            else
            {
                uC_ThongTin1.Show();
                thongTinKho1.Hide();
                uC_DatHang1.Hide();
                uC_NhapHang1.Hide();
                uC_ThongKe1.Hide();

                unActive();

                this.tab5.Image = global::QLKho.Properties.Resources.refresh;
                this.tab5.FillColor = tabActiveColor;
                this.tab5.ForeColor = Color.White;
                tabActive = "tab5";
            }
        }

        private void tab6_Click(object sender, EventArgs e)
        {
            if (uC_ThongKe1.Visible)
            {
                uC_ThongKe1.Hide();
                this.tab6.Image = global::QLKho.Properties.Resources.statistics;

                unActive();
            }
            else
            {
                uC_ThongKe1.Show();
                thongTinKho1.Hide();
                uC_DatHang1.Hide();
                uC_NhapHang1.Hide();
                uC_ThongTin1.Hide();

                unActive();

                this.tab6.Image = global::QLKho.Properties.Resources.statistics__1_;
                this.tab6.FillColor = tabActiveColor;
                this.tab6.ForeColor = Color.White;
                tabActive = "tab6";
            }
        }

        private void tab4_Click(object sender, EventArgs e)
        {
            if (xuatHang1.Visible)
            {
                xuatHang1.Hide();
                this.tab4.Image = global::QLKho.Properties.Resources.export;

                unActive();
            }
            else
            {
                xuatHang1.Show();
                thongTinKho1.Hide();
                uC_DatHang1.Hide();
                uC_NhapHang1.Hide();
                uC_ThongTin1.Hide();
                uC_ThongKe1.Hide();

                unActive();

                this.tab4.Image = global::QLKho.Properties.Resources.export__1_;
                this.tab4.FillColor = tabActiveColor;
                this.tab4.ForeColor = Color.White;
                tabActive = "tab4";
            }
        }

        private void tab7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thongTinKho1_Load(object sender, EventArgs e)
        {
            
        }
    }
}

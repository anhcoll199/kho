using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using DTO;

namespace QLKho
{
    public partial class Nhap : UserControl
    {
        public Nhap()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cb_Dathang_sanpham_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Nhap_Load(object sender, EventArgs e)
        {

            ArrayList arrPersons = new ArrayList();

            arrPersons.Add(new Person("Nguyen Van A", 18));
            arrPersons.Add(new Person("Nguyen Van B", 25));
            arrPersons.Add(new Person("Nguyen Van C", 20));

            string[] dt = { "Kinh", "Hoa", "Kh'Me", "H'Mong", "Khác" };
            string[] dtt = { "x", "y", "z'z", "H'Mong", "Khác" };
            //foreach (Person person in arrPersons)
            //{
            //    cb_Dathang_sanpham.Items.Add(person);
            //    cb_Dathang_sanpham.DataSource = per


            //}
            cb_Dathang_sanpham.DataSource = arrPersons;
            cb_Dathang_sanpham.DisplayMember = "Name";
            cb_Dathang_sanpham.ValueMember = "Age";

            foreach (string x in dtt)
            {
                cb_Dathang_ncc.Items.Add(x);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = (int)cb_Dathang_sanpham.SelectedIndex;
            var dataString = cb_Dathang_sanpham.SelectedValue;

            string theDate = dtp_Dathang_ngaygiao.Value.ToString();
            MessageBox.Show(theDate, "Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}

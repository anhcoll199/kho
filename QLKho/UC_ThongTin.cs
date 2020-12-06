using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace QLKho
{
    public partial class UC_ThongTin : UserControl
    {
        Package_BUS Pbus = new Package_BUS();
        Suplier_BUS Sbus = new Suplier_BUS();
        
        public UC_ThongTin()
        {
            InitializeComponent();
            
        }
        private void loadDataInforSP()
        {
            //load column cho các bảng
            datagridSanPham.ColumnCount = 2;
            datagridSanPham.Columns[0].Name = "Mã sản phẩm";
            datagridSanPham.Columns[1].Name = "Tên sản phầm";
            datagridSanPham.Columns[0].Width = 100;

            var productTable = Pbus.getProduct();

            foreach (DataRow row in productTable.Rows)
            {
                string idProduct = row["IdProduct"].ToString();
                string name = row["DisplayName"].ToString();

                datagridSanPham.Rows.Add(new object[] { idProduct, name });
            }
        }
        private void loadDataInforUnit()
        {
            //load column cho các bảng

            datagridUnit.ColumnCount = 2;
            datagridUnit.Columns[0].Name = "Mã đơn vị";
            datagridUnit.Columns[1].Name = "Tên đơn vị";
            datagridUnit.Columns[0].Width = 100;

            var UnitTable = Pbus.getUnit();

            foreach (DataRow row in UnitTable.Rows)
            {
                string idUnit = row["Id_Unit"].ToString();
                string name = row["DisplayName"].ToString();

                datagridUnit.Rows.Add(new object[] { idUnit, name });

            }
        }
        private void loadDataInforNCC()
        {

            //load column cho các bảng
            datagridNCC.ColumnCount = 5;
            datagridNCC.Columns[0].Name = "Mã NCC";
            datagridNCC.Columns[1].Name = "Tên NCC";
            datagridNCC.Columns[2].Name = "Địa chỉ";
            datagridNCC.Columns[3].Name = "Số điện thoại";
            datagridNCC.Columns[4].Name = "Email";
            datagridNCC.Columns[0].Width = 100;

            var SuplierTable = Sbus.getSuplier();
           
            foreach (DataRow row in SuplierTable.Rows)
            {
                string idSuplier = row["IdSuplier"].ToString();
                string name = row["DisplayName"].ToString();
                string add = row["Address"].ToString();
                string phone = row["Phone"].ToString();
                string email = row["Email"].ToString();

                datagridNCC.Rows.Add(new object[] { idSuplier, name, add, phone, email });

            }
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel5_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Hello", "My Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UC_ThongTin_Load(object sender, EventArgs e)
        {
            loadDataInforSP();
            loadDataInforUnit();
            loadDataInforNCC();
        }

        private void datagridSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Row binding
            if (e.RowIndex >= 0)
            {
                datagridSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DataGridViewRow row = this.datagridSanPham.Rows[e.RowIndex];

                txtIdSPtab5.Text = row.Cells[0].Value.ToString();
                txtSPtab5.Text = row.Cells[1].Value.ToString();
            }
        }

        private void datagridUnit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                datagridUnit.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DataGridViewRow row = this.datagridUnit.Rows[e.RowIndex];

                txtIdUnittab5.Text = row.Cells[0].Value.ToString();
                txtUnittab5.Text = row.Cells[1].Value.ToString();
            }
        }

        private void datagridNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                datagridNCC.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DataGridViewRow row = this.datagridNCC.Rows[e.RowIndex];

                txtIdNCCtab5.Text = row.Cells[0].Value.ToString();
                txtNCCtab5.Text = row.Cells[1].Value.ToString();
                txtAddNCCtab5.Text = row.Cells[2].Value.ToString();
                txtPhoneNCCtab5.Text = row.Cells[3].Value.ToString();
                txtEmailNCCtab5.Text = row.Cells[4].Value.ToString();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Color DefaultBorderTxt = Color.FromArgb(213, 218, 223);

            string id = txtIdSPtab5.Text;
            string name = txtSPtab5.Text;
            if (id.Equals("") || name.Equals(""))            
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin sản phẩm", "My Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (id.Equals(""))
                    txtIdSPtab5.BorderColor = System.Drawing.Color.Red;
                else
                    txtIdSPtab5.BorderColor = DefaultBorderTxt;
                if (name.Equals(""))
                    txtSPtab5.BorderColor = System.Drawing.Color.Red;
                else
                    txtSPtab5.BorderColor = DefaultBorderTxt;
            }
            else
            {
                txtIdSPtab5.BorderColor = DefaultBorderTxt;
                txtSPtab5.BorderColor = DefaultBorderTxt;
                Product product = new Product(id, name);
                int result = Pbus.AddProduct(product);
                if (result == 1)
                { 
                    MessageBox.Show("Thêm sản phẩm: " + id + " - " + name + " Thành công", "My Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    datagridSanPham.Rows.Clear();
                    datagridSanPham.Refresh();
                    loadDataInforSP();
                }
                else
                    MessageBox.Show("Thêm sản phẩm thất bại", "My Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng này bị khoá", "My Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Color DefaultBorderTxt = Color.FromArgb(213, 218, 223);

            string id = txtIdNCCtab5.Text;
            string name = txtNCCtab5.Text;
            string add = txtAddNCCtab5.Text;
            string phone = txtPhoneNCCtab5.Text;
            string email = txtEmailNCCtab5.Text;

            if (id.Equals("") || name.Equals("") || add.Equals("") || phone.Equals("") || email.Equals(""))
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin nhà cung cấp", "My Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (id.Equals(""))
                    txtIdNCCtab5.BorderColor = System.Drawing.Color.Red;
                else
                    txtIdNCCtab5.BorderColor = DefaultBorderTxt;
                if (name.Equals(""))
                    txtNCCtab5.BorderColor = System.Drawing.Color.Red;
                else
                    txtNCCtab5.BorderColor = DefaultBorderTxt;
                if (add.Equals(""))
                    txtAddNCCtab5.BorderColor = System.Drawing.Color.Red;
                else
                    txtAddNCCtab5.BorderColor = DefaultBorderTxt;
                if (phone.Equals(""))
                    txtPhoneNCCtab5.BorderColor = System.Drawing.Color.Red;
                else
                    txtPhoneNCCtab5.BorderColor = DefaultBorderTxt;
                if (email.Equals(""))
                    txtEmailNCCtab5.BorderColor = System.Drawing.Color.Red;
                else
                    txtEmailNCCtab5.BorderColor = DefaultBorderTxt;
            }
            else
            {
                txtIdNCCtab5.BorderColor = DefaultBorderTxt;
                txtNCCtab5.BorderColor = DefaultBorderTxt;
                txtAddNCCtab5.BorderColor = DefaultBorderTxt;
                txtPhoneNCCtab5.BorderColor = DefaultBorderTxt;
                txtEmailNCCtab5.BorderColor = DefaultBorderTxt;

                Suplier suplier = new Suplier(id, name, add, phone, email);
                int result = Sbus.AddSuplier(suplier);
                if (result == 1)
                {
                    MessageBox.Show("Thêm Nhà cung cấp: " + id + " - " + name + " Thành công", "My Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    datagridNCC.Rows.Clear();
                    datagridNCC.Refresh();
                    loadDataInforNCC();

                }
                else
                    MessageBox.Show("Thêm nhà cung cấp thất bại", "My Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}

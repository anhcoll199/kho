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
using System.Collections;

namespace QLKho
{
    public partial class ThongTinKho : UserControl
    {
        Package_BUS bus = new Package_BUS();
        public ThongTinKho()
        {
            InitializeComponent();
        }

        private void ThongTinKho_Load(object sender, EventArgs e)
        {
            // Tải dữ liệu của bảng lô hàng trong tab1
            datagridPackage.DataSource = bus.getAll();

            //Test dữ liệu
            //DataTable datatable = bus.getAll();
            //var dataRow = datatable.AsEnumerable().Where(x => x.Field<string>("IdPackage") == "PACK001").FirstOrDefault();
            ////Console.WriteLine(dataRow["DisplayName"]);
            //lbTest.Text = dataRow["DisplayName"].ToString();


            // Tải dữ liệu combobox của sản phẩm trong tab1

            //cbMaSP.DataSource = bus.getProduct();

            cbMaSP.Items.Add(new Product("0", "Tất cả sản phẩm"));

            var table = bus.getProduct();
            foreach (DataRow row in table.Rows)
            {
                string id = row["IdProduct"].ToString();
                string name = id + " - " + row["DisplayName"].ToString();
                cbMaSP.Items.Add(new Product(id, name));
            }
            cbMaSP.SelectedIndex = 0;
            cbMaSP.DisplayMember = "Name";
            cbMaSP.ValueMember = "ID";




            cbMaLoHang.DataSource = bus.getPackageID();
            cbMaLoHang.DisplayMember = "IdPackage";
            cbMaLoHang.ValueMember = "IdPackage";




        }

        private void btnFilerTab1_Click(object sender, EventArgs e)
        {
            //DataRowView drv = (DataRowView)cbMaSP.SelectedItem;
            //String text = drv["DisplayName"].ToString();
            //String value = cbMaSP.SelectedValue.ToString();
            //String index = cbMaSP.SelectedIndex.ToString();
            //string value = cbMaSP.SelectedItem.Name;
            string value = ((Product) cbMaSP.SelectedItem).ID;
            string textSearch = txtSearchTab1.Text;

            //MessageBox.Show(textSearch + " " + value, "My Application", MessageBoxButtons.OK, MessageBoxIcon.Error);

            datagridPackage.DataSource = bus.FilterPackage(textSearch, value);


        }

        private void datagridPackage_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void datagridPackage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (datagridPackage.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                datagridPackage.CurrentRow.Selected = true;
                string str = datagridPackage.Rows[e.RowIndex].Cells["Column1"].FormattedValue.ToString();
                //MessageBox.Show(str, "My Application", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}

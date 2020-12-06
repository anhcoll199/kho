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
    public partial class UC_NhapHang : UserControl
    {
        Order_BUS bus = new Order_BUS();
        Import_BUS Ibus = new Import_BUS();
        Package_BUS Pbus = new Package_BUS();
        Suplier_BUS Sbus = new Suplier_BUS();
        public UC_NhapHang()
        {
            InitializeComponent();
        }
        private void loadDataImport()
        {
            btnCreateImportPackageDetail.Enabled = false;
            //Load dữ liệu cho các combobox sản phầm
            cbSanPhamImportPackage.Items.Add(new Product("0", "Tất cả sản phẩm"));
            var tablee = Pbus.getProduct();
            foreach (DataRow row in tablee.Rows)
            {
                string id = row["IdProduct"].ToString();
                string name = id + " - " + row["DisplayName"].ToString();
                cbSanPhamImportPackage.Items.Add(new Product(id, name));
            }
            cbSanPhamImportPackage.SelectedIndex = 0;
            cbSanPhamImportPackage.DisplayMember = "Name";
            cbSanPhamImportPackage.ValueMember = "ID";

            //Load dữ liệu cho các combobox unit
            cbUnitImportPackage.Items.Add(new Unit("0", "Đơn vị"));
            var tablbb = Pbus.getUnit();
            foreach (DataRow row in tablbb.Rows)
            {
                string id = row["Id_Unit"].ToString();
                string name = row["DisplayName"].ToString();
                cbUnitImportPackage.Items.Add(new Unit(id, name));
            }
            cbUnitImportPackage.SelectedIndex = 0;
            cbUnitImportPackage.DisplayMember = "Name";
            cbUnitImportPackage.ValueMember = "ID";

            //load combobox nhà cung cấp
            cbNCCImportPackage.Items.Add(new Suplier("0", "Nhà cung cấp", "0", "0", "0"));
            var tabll = Sbus.getSuplier();
            foreach (DataRow row in tabll.Rows)
            {
                string id = row["IdSuplier"].ToString();
                string name = row["DisplayName"] + "(" + id + ")".ToString();
                string add = row["Address"].ToString();
                string phone = row["Phone"].ToString();
                string mail = row["Email"].ToString();
                cbNCCImportPackage.Items.Add(new Suplier(id, name, add, phone, mail));
            }
            cbNCCImportPackage.SelectedIndex = 0;
            cbNCCImportPackage.DisplayMember = "DisplayName";
            cbNCCImportPackage.ValueMember = "IdSuplier";



            //Load dữ liệu cho sort
            cbImportStatus.Items.Add(new Status("all", "Tình trạng"));
            cbImportStatus.Items.Add(new Status("1", "Đã xử lí"));
            cbImportStatus.Items.Add(new Status("0", "Chưa xử lí"));

            cbImportStatus.SelectedIndex = 0;
            cbImportStatus.DisplayMember = "Display";
            cbImportStatus.ValueMember = "status";

            //Load dữ liệu combobox nhân viên
            cbImportUser.Items.Add(new User("0", "Nhân viên", "Staff"));

            var tab = bus.getUser();
            foreach (DataRow row in tab.Rows)
            {
                string id = row["Id"].ToString();
                string displayName = id + " - " + row["DisplayName"] + " (" + row["IdUserRole"] + ")".ToString();
                string role = row["IdUserRole"].ToString();
                cbImportUser.Items.Add(new User(id, displayName, role));
            }
            cbImportUser.SelectedIndex = 0;
            cbImportUser.DisplayMember = "Name";
            cbImportUser.ValueMember = "ID";

            
            //load column cho các bảng

            datagridImportPackage.ColumnCount = 7;
            datagridImportPackage.Columns[0].Name = "Mã nhập hàng";
            datagridImportPackage.Columns[1].Name = "Mã đặt hàng";
            datagridImportPackage.Columns[2].Name = "Ngày tạo";
            datagridImportPackage.Columns[3].Name = "Nhân viên";
            datagridImportPackage.Columns[4].Name = "Mã lô hàng";
            datagridImportPackage.Columns[5].Name = "Tình trạng";
            datagridImportPackage.Columns[6].Name = "Tổng tiền";

            dataGridImportPack.ColumnCount = 7;
            dataGridImportPack.Columns[0].Name = "Mã sản phẩm";
            dataGridImportPack.Columns[1].Name = "Số lượng";
            dataGridImportPack.Columns[2].Name = "Đơn giá";
            dataGridImportPack.Columns[3].Name = "Thành tiền";
            dataGridImportPack.Columns[4].Name = "Hạn sử dụng";
            dataGridImportPack.Columns[5].Name = "Mã đơn vị";
            dataGridImportPack.Columns[6].Name = "Mã nhà cung cấp";

            //load dữ liệu table
            var data = Ibus.getImport();
            foreach (DataRow row in data.Rows)
            {
                string idImport = row["IdImportProduct"].ToString();
                string idOrder = row["IdOrderProduct"].ToString();
                string createdDate = row["CreatedDate"].ToString();
                string checkstatus = row["StatusImportProduct"].ToString();
                string idUser = row["IdUsers"].ToString();
                string nameUser = row["DisplayName"].ToString();
                string roleUser = row["IdUserRole"].ToString();
                string package = row["IdPackage"].ToString();
                string totalPrice = row["TotalPrice"].ToString();

                string status = checkstatus.Equals("False") ? "Chưa xử lí" : "Đã xử lí";


                datagridImportPackage.Rows.Add(new object[] { idImport, idOrder, createdDate, idUser + " - " + nameUser + " (" + roleUser + ")", package , status, totalPrice });

            }
            datagridImportPackage.Columns[0].Width = 80;
            datagridImportPackage.Columns[1].Width = 80;
            datagridImportPackage.Columns[2].Width = 180;
            datagridImportPackage.Columns[3].Width = 250;

            datagridImportPackage.Columns[6].Width = 5;
            datagridImportPackage.Columns[6].Visible = false;



            //var check = dt.Columns.Count;
            //datagridOrder.DataSource = dt;

            // Sẽ không có dòng nào được chọn lúc load
            datagridImportPackage.ClearSelection();
            datagridImportPackage.Rows[0].Selected = false;
        }
        private void UC_NhapHang_Load(object sender, EventArgs e)
        {
            loadDataImport();
        }

        private void pannelBackButton_Click(object sender, EventArgs e)
        {
            panelNhapHangKho.Visible = true;
            //Reset giá trị trong bằng
            datagridImportPackage.Rows.Clear();
            datagridImportPackage.Refresh();
            loadDataImport();
        }

        private void btnCreateImportPackageDetail_Click(object sender, EventArgs e)
        {
            panelNhapHangKho.Visible = false;

            var index = datagridImportPackage.CurrentCell.RowIndex;
            DataGridViewRow roww = this.datagridImportPackage.Rows[index];
            var idImport = roww.Cells[0].Value.ToString();
            var idOrder = roww.Cells[1].Value.ToString();
            var idPackage = roww.Cells[4].Value.ToString();
            var totalPrice = roww.Cells[6].Value.ToString();

            txtIdImportPackage.Text = idImport;
            txtIdUserImportPackage.Text = LoginVar.ID + " - " + LoginVar.Name + " (" + LoginVar.Role + ")";
            txtCreateDateImportPackage.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtStatusImportPackage.Text = "Chưa xử lí";
            txtIdOrderinImportPackage.Text = idOrder;
            txtIdPackagetab3.Text = idPackage;
            txtTotalPriceImportPackage.Text = totalPrice;


            //Reset giá trị trong bằng
            dataGridImportPack.Rows.Clear();
            dataGridImportPack.Refresh();


            var data = Ibus.ImportDetail(idImport);

            foreach (DataRow row in data.Rows)
            {
                string idProduct = row["IdProduct"].ToString();
                string amount = row["Amount"].ToString();
                string price = row["UnitPrice"].ToString();
                string intoPrice = row["IntoPrice"].ToString();
                string exp = row["ExpiryDate"].ToString();
                string idUnit = row["Id_Unit"].ToString();
                string idSuplier = row["IdSuplier"].ToString();

                dataGridImportPack.Rows.Add(new object[] { idProduct, amount, price, intoPrice, exp,  idUnit, idSuplier });
            }
            // Sẽ không có dòng nào được chọn lúc load
            dataGridImportPack.ClearSelection();
            dataGridImportPack.Rows[0].Selected = false;
        }

        private void dataGridImportPack_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridImportPack.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DataGridViewRow row = this.dataGridImportPack.Rows[e.RowIndex];

                txtAmountImportPackage.Text = row.Cells[1].Value.ToString();

                for (int i = 0; i < cbSanPhamImportPackage.Items.Count; i++)
                {
                    string value = ((Product)cbSanPhamImportPackage.Items[i]).ID;
                    if (value.Equals(row.Cells[0].Value.ToString()))
                    {
                        cbSanPhamImportPackage.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < cbUnitImportPackage.Items.Count; i++)
                {
                    string value = ((Unit)cbUnitImportPackage.Items[i]).ID;
                    if (value.Equals(row.Cells[5].Value.ToString()))
                    {
                        cbUnitImportPackage.SelectedIndex = i;
                        break;
                    }
                }


                for (int i = 0; i < cbNCCImportPackage.Items.Count; i++)
                {
                    string value = ((Suplier)cbNCCImportPackage.Items[i]).IdSuplier;
                    if (value.Equals(row.Cells[6].Value.ToString()))
                    {
                        cbNCCImportPackage.SelectedIndex = i;
                        break;
                    }

                }

                txtPriceImportPackage.Text = row.Cells[2].Value.ToString();
                txtIntoPriceImportPackage.Text = row.Cells[3].Value.ToString();
                DateTime oDate = Convert.ToDateTime(row.Cells[4].Value.ToString());
                DatePickerImportPackage.Value = oDate;

                //MessageBox.Show(row.Cells[1].Value.ToString() + row.Cells[2].Value.ToString(), "My Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //txtIdOrderDetail.Text = rowSelect.Cells[0].Value.ToString();


            }
        }

        private void btnImportPackage_Click(object sender, EventArgs e)
        {
            string idImport = txtIdImportPackage.Text;
            string idOrder = txtIdOrderinImportPackage.Text;
            string idPackage = txtIdPackagetab3.Text;

            var rowCount = dataGridImportPack.RowCount;
            if (rowCount > 0)
            {
                List<PackageDTO> listPack = new List<PackageDTO>();
                for (int index = 0; index < dataGridImportPack.RowCount; index++)
                {
                    DataGridViewRow row = this.dataGridImportPack.Rows[index];

                    PackageDTO packDTO = new PackageDTO();
                    packDTO.IdPackage = idPackage;
                    packDTO.IdProduct = row.Cells[0].Value.ToString();
                    packDTO.Amount = row.Cells[1].Value.ToString();
                    packDTO.Id_Unit = row.Cells[5].Value.ToString();
                    packDTO.IdSuplier = row.Cells[6].Value.ToString();
                    packDTO.Id_OrderForm = idOrder;
                    DateTime oDate = Convert.ToDateTime(row.Cells[4].Value.ToString());
                    packDTO.ExpiryDate = oDate;



                    listPack.Add(packDTO);
                }

                var result = Pbus.AddPackage(listPack);

                if (result == 1)
                {
                    var confimrImport = Ibus.ComfirmImport(idImport);
                    MessageBox.Show("Nhập hàng hoá vào kho bảo quản thành công", "Kho", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Nhập hàng hoá vào kho bảo quản thất bại", "Kho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void datagridImportPackage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                datagridImportPackage.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DataGridViewRow row = this.datagridImportPackage.Rows[e.RowIndex];

                var checkStatus = row.Cells[5].Value.ToString();

                if (checkStatus.Equals("Đã xử lí"))
                {
                    btnCreateImportPackageDetail.Enabled = false;
                }
                else
                    btnCreateImportPackageDetail.Enabled = true;
            }
        }
    }
}

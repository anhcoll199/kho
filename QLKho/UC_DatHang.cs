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
    public partial class UC_DatHang : UserControl
    {
        Order_BUS Obus = new Order_BUS();
        Import_BUS Ibus = new Import_BUS();
        Package_BUS Pbus = new Package_BUS();
        Suplier_BUS Sbus = new Suplier_BUS();
        public UC_DatHang()
        {
            InitializeComponent();
        }

        private void loadNewIdOrder()
        {
            //Lấy ID tiếp theo của Order
            var maxId = Obus.getMaxIdOrder();
            LoginVar.newOrder = maxId.Rows[0]["IdOrderProduct"].ToString();
            LoginVar.newOrder = LoginVar.newOrder.Substring(LoginVar.newOrder.Length - 3);

            int numberGet = int.Parse(LoginVar.newOrder) + 1;
            if (numberGet < 10)
            {
                LoginVar.newOrder = "OR" + "0" + "0" + numberGet.ToString();
            }
            else if (numberGet < 100 && numberGet >= 10)
            {
                LoginVar.newOrder = "OR" + "0" + numberGet.ToString();
            }
        }
        private void loadNewIdPackage()
        {
            //Lấy ID tiếp theo của Package
            var maxId = Pbus.getMaxIdPackage();
            LoginVar.newPackage = maxId.Rows[0]["IdPackage"].ToString();
            LoginVar.newPackage = LoginVar.newPackage.Substring(LoginVar.newPackage.Length - 3);

            int numberGet = int.Parse(LoginVar.newPackage) + 1;
            if (numberGet < 10)
            {
                LoginVar.newPackage = "PACK" + "0" + "0" + numberGet.ToString();
            }
            else if (numberGet < 100 && numberGet >= 10)
            {
                LoginVar.newPackage = "PACK" + "0" + numberGet.ToString();
            }
        }
        private void loadNewIdImport()
        {
            //Lấy ID tiếp theo của Import
            var maxId = Ibus.getMaxIdImport();
            LoginVar.newImport = maxId.Rows[0]["IdImportProduct"].ToString();
            LoginVar.newImport = LoginVar.newImport.Substring(LoginVar.newImport.Length - 3);

            int numberGet = int.Parse(LoginVar.newImport) + 1;
            if (numberGet < 10)
            {
                LoginVar.newImport = "IP" + "0" + "0" + numberGet.ToString();
            }
            else if (numberGet < 100 && numberGet >= 10)
            {
                LoginVar.newImport = "IP" + "0" + numberGet.ToString();
            }
        }
        private void loadDataOrder()
        {
            //taoPhieuDatHang1.Hide();
            //Load dữ liệu cho bảng
            ///datagridOrder.DataSource = bus.getOrder();
            

            DataTable dt = new DataTable();

            //dt.Columns.Add("Mã đặt hàng",System.Type.GetType("System.String"));
            //dt.Columns.Add("Ngày tạo",System.Type.GetType("System.String"));
            //dt.Columns.Add("Nhân viên",System.Type.GetType("System.String"));
            //dt.Columns.Add("Tình trạng",System.Type.GetType("System.String"));

            //load data cho cac combobox
            cbProduct.Items.Add(new Product("0", "Tất cả sản phẩm"));
            var table = Pbus.getProduct();
            foreach (DataRow row in table.Rows)
            {
                string id = row["IdProduct"].ToString();
                string name = id + " - " + row["DisplayName"].ToString();
                cbProduct.Items.Add(new Product(id, name));
            }
            cbProduct.SelectedIndex = 0;
            cbProduct.DisplayMember = "Name";
            cbProduct.ValueMember = "ID";

            cbSanPhamImport.Items.Add(new Product("0", "Tất cả sản phẩm"));
            var tablee = Pbus.getProduct();
            foreach (DataRow row in tablee.Rows)
            {
                string id = row["IdProduct"].ToString();
                string name = id + " - " + row["DisplayName"].ToString();
                cbSanPhamImport.Items.Add(new Product(id, name));
            }
            cbSanPhamImport.SelectedIndex = 0;
            cbSanPhamImport.DisplayMember = "Name";
            cbSanPhamImport.ValueMember = "ID";

            //load combobox Unit
            cbUnit.Items.Add(new Unit("0", "Đơn vị"));
            var tablb = Pbus.getUnit();
            foreach (DataRow row in tablb.Rows)
            {
                string id = row["Id_Unit"].ToString();
                string name = row["DisplayName"].ToString();
                cbUnit.Items.Add(new Unit(id, name));
            }
            cbUnit.SelectedIndex = 0;
            cbUnit.DisplayMember = "Name";
            cbUnit.ValueMember = "ID";

            cbUnitImport.Items.Add(new Unit("0", "Đơn vị"));
            var tablbb = Pbus.getUnit();
            foreach (DataRow row in tablbb.Rows)
            {
                string id = row["Id_Unit"].ToString();
                string name = row["DisplayName"].ToString();
                cbUnitImport.Items.Add(new Unit(id, name));
            }
            cbUnitImport.SelectedIndex = 0;
            cbUnitImport.DisplayMember = "Name";
            cbUnitImport.ValueMember = "ID";

            //load combobox nhà cung cấp
            cbNCC.Items.Add(new Suplier("0", "Nhà cung cấp", "0", "0", "0"));
            var tabl = Sbus.getSuplier();
            foreach (DataRow row in tabl.Rows)
            {
                string id = row["IdSuplier"].ToString();
                string name = row["DisplayName"] + "(" + id + ")".ToString();
                string add = row["Address"].ToString();
                string phone = row["Phone"].ToString();
                string mail = row["Email"].ToString();
                cbNCC.Items.Add(new Suplier(id, name, add, phone, mail));
            }
            cbNCC.SelectedIndex = 0;
            cbNCC.DisplayMember = "DisplayName";
            cbNCC.ValueMember = "IdSuplier";

            cbNCCImport.Items.Add(new Suplier("0", "Nhà cung cấp", "0", "0", "0"));
            var tabll = Sbus.getSuplier();
            foreach (DataRow row in tabll.Rows)
            {
                string id = row["IdSuplier"].ToString();
                string name = row["DisplayName"] + "(" + id + ")".ToString();
                string add = row["Address"].ToString();
                string phone = row["Phone"].ToString();
                string mail = row["Email"].ToString();
                cbNCCImport.Items.Add(new Suplier(id, name, add, phone, mail));
            }
            cbNCCImport.SelectedIndex = 0;
            cbNCCImport.DisplayMember = "DisplayName";
            cbNCCImport.ValueMember = "IdSuplier";



            //load column cho các bảng
            datagridOrderDetail.ColumnCount = 4;
            datagridOrderDetail.Columns[0].Name = "Mã sản phẩm";
            datagridOrderDetail.Columns[1].Name = "Số lượng";
            datagridOrderDetail.Columns[2].Name = "Mã đơn vị";
            datagridOrderDetail.Columns[3].Name = "Nhà cung cấp";

            datagridOrder.ColumnCount = 4;
            datagridOrder.Columns[0].Name = "Mã đặt hàng";
            datagridOrder.Columns[1].Name = "Ngày tạo";
            datagridOrder.Columns[2].Name = "Nhân viên";
            datagridOrder.Columns[3].Name = "Tình trạng";


            dataGridImportDetail.ColumnCount = 7;
            dataGridImportDetail.Columns[0].Name = "Mã sản phẩm";
            dataGridImportDetail.Columns[1].Name = "Số lượng";
            dataGridImportDetail.Columns[2].Name = "Mã đơn vị";
            dataGridImportDetail.Columns[3].Name = "Nhà cung cấp";
            dataGridImportDetail.Columns[4].Name = "Đơn giá";
            dataGridImportDetail.Columns[5].Name = "Thành tiền";
            dataGridImportDetail.Columns[6].Name = "Hạn dùng";

            var data = Obus.getOrder();
            foreach (DataRow row in data.Rows)
            {
                string idOrder = row["IdOrderProduct"].ToString();
                string createdDate = row["CreatedDate"].ToString();
                string checkstatus = row["StatusOrderProduct"].ToString();
                string idUser = row["IdUsers"].ToString();
                string nameUser = row["DisplayName"].ToString();
                string roleUser = row["IdUserRole"].ToString();

                string status = checkstatus.Equals("False") ? "Chưa xử lí" : "Đã xử lí";


                datagridOrder.Rows.Add(new object[] { idOrder, createdDate, idUser + " - " + nameUser + " (" + roleUser + ")", status });

            }

            datagridOrder.Columns[0].Width = 80;
            datagridOrder.Columns[1].Width = 180;
            datagridOrder.Columns[2].Width = 280;

            //var check = dt.Columns.Count;
            //datagridOrder.DataSource = dt;

            // Sẽ không có dòng nào được chọn lúc load
            datagridOrder.ClearSelection();
            datagridOrder.Rows[0].Selected = false;

            //Load dữ liệu cho sort
            cbOrderStatus.Items.Add(new Status("all", "Tình trạng"));
            cbOrderStatus.Items.Add(new Status("1", "Đã xử lí"));
            cbOrderStatus.Items.Add(new Status("0", "Chưa xử lí"));

            cbOrderStatus.SelectedIndex = 0;
            cbOrderStatus.DisplayMember = "Display";
            cbOrderStatus.ValueMember = "status";

            //Load dữ liệu combobox nhân viên
            cbOrderUser.Items.Add(new User("0", "Nhân viên", "Staff"));

            var tab = Obus.getUser();
            foreach (DataRow row in tab.Rows)
            {
                string id = row["Id"].ToString();
                string displayName = id + " - " + row["DisplayName"] + " (" + row["IdUserRole"] + ")".ToString();
                string role = row["IdUserRole"].ToString();
                cbOrderUser.Items.Add(new User(id, displayName, role));
            }
            cbOrderUser.SelectedIndex = 0;
            cbOrderUser.DisplayMember = "Name";
            cbOrderUser.ValueMember = "ID";
        }
        private void UC_DatHang_Load(object sender, EventArgs e)
        {

            //Lấy ID tiếp theo của Order
            loadNewIdOrder();
            loadNewIdImport();
            loadNewIdPackage();

            loadDataOrder();

            btnCreateImportDetail.Enabled = false;

        }

        private void btnFilerTab2_Click(object sender, EventArgs e)
        {
            //Reset giá trị trong bằng
            datagridOrder.Rows.Clear();
            datagridOrder.Refresh();
            
            string statuss = ((Status)cbOrderStatus.SelectedItem).status;
            string iduser = ((User)cbOrderUser.SelectedItem).ID;
            if (statuss.Equals("all"))
                statuss = "NULL";
            if(iduser.Equals("0"))
                iduser = "NULL";

            var data = Obus.FilterOrder(statuss, iduser);

            foreach (DataRow row in data.Rows)
            {
                string idOrder = row["IdOrderProduct"].ToString();
                string createdDate = row["CreatedDate"].ToString();
                string checkstatus = row["StatusOrderProduct"].ToString();
                string idUser = row["IdUsers"].ToString();
                string nameUser = row["DisplayName"].ToString();
                string roleUser = row["IdUserRole"].ToString();

                string status = checkstatus.Equals("False") ? "Chưa xử lí" : "Đã xử lí";


                datagridOrder.Rows.Add(new object[] { idOrder, createdDate, idUser + " - " + nameUser + " (" + roleUser + ")", status });
            }
            // Sẽ không có dòng nào được chọn lúc load
            datagridOrder.ClearSelection();
            datagridOrder.Rows[0].Selected = false;
        }

        private void datagridOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnCreateImportDetail.Enabled = true;
            if (e.RowIndex >= 0)
            {
                datagridOrderDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DataGridViewRow row = this.datagridOrder.Rows[e.RowIndex];

                var checkStatus = row.Cells[3].Value.ToString();

                if (checkStatus.Equals("Đã xử lí"))
                {
                    btnCreateImportDetail.Enabled = false;
                }



            }
        }

        private void datagridOrder_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //taoPhieuDatHang1.Show();

            if (e.RowIndex >= 0)
            {
                datagridOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DataGridViewRow rowSelect = this.datagridOrder.Rows[e.RowIndex];

                //MessageBox.Show(row.Cells[1].Value.ToString() + row.Cells[2].Value.ToString(), "My Application", MessageBoxButtons.OK, MessageBoxIcon.Error);

               
                txtIdOrderDetail.Text = rowSelect.Cells[0].Value.ToString();
                txtCreatedDateOrderDetail.Text = rowSelect.Cells[1].Value.ToString();
                txtNhanVienOrderDetail.Text = rowSelect.Cells[2].Value.ToString();
                txtStatusOrderDetail.Text = rowSelect.Cells[3].Value.ToString();
                panelOrdertab2.Visible = false;

                cbProduct.Enabled = false;
                txtAmount.Enabled = false;
                cbUnit.Enabled = false;
                cbNCC.Enabled = false;
                btnDelOrder.Enabled = false;
                btnUpdateOrder.Enabled = false;
                btnCreateOrder.Enabled = false;

                //MessageBox.Show(row.Cells[1].Value.ToString() + row.Cells[2].Value.ToString(), "My Application", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //Reset giá trị trong bằng
                datagridOrderDetail.Rows.Clear();
                datagridOrderDetail.Refresh();

                var idOrder = txtIdOrderDetail.Text;
                var data = Obus.OrderDetail(idOrder);

                foreach (DataRow row in data.Rows)
                {
                    string idProduct = row["IdProduct"].ToString();
                    string amount = row["Amount"].ToString();
                    string idUnit = row["Id_Unit"].ToString();
                    string idSuplier = row["IdSuplier"].ToString();

                    datagridOrderDetail.Rows.Add(new object[] { idProduct, amount, idUnit, idSuplier });
                }
                // Sẽ không có dòng nào được chọn lúc load
                datagridOrderDetail.ClearSelection();
                datagridOrderDetail.Rows[0].Selected = false;

            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void pannelBackButton_Click_1(object sender, EventArgs e)
        {
            panelOrdertab2.Visible = true;
            panelOrderDetail.Visible = true;
            cbProduct.Enabled = true;
            txtAmount.Enabled = true;
            cbUnit.Enabled = true;
            cbNCC.Enabled = true;
            btnDelOrder.Enabled = true;
            btnUpdateOrder.Enabled = true;
            btnCreateOrder.Enabled = true;
            loadNewIdOrder();

            //Reset giá trị trong bằng
            datagridOrder.Rows.Clear();
            datagridOrder.Refresh();

            
            clearCb();
            loadDataOrder();

        }

        private void clearCb()
        {
            cbOrderStatus.Items.Clear();
            cbOrderUser.Items.Clear();
            cbProduct.Items.Clear();
            cbUnit.Items.Clear();
            cbNCC.Items.Clear();
            cbUnitImport.Items.Clear();
            cbNCCImport.Items.Clear();
        }

        private void btnOrderDetailCreate_Click(object sender, EventArgs e)
        {
            txtIdOrderDetail.Text = "";
            txtCreatedDateOrderDetail.Text = "";
            txtNhanVienOrderDetail.Text = "";
            txtStatusOrderDetail.Text = "";
            panelOrdertab2.Visible = false;


            txtIdOrderDetail.Text = LoginVar.newOrder;
            txtNhanVienOrderDetail.Text = LoginVar.ID + " - " + LoginVar.Name + " (" + LoginVar.Role + ")";
            txtCreatedDateOrderDetail.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtStatusOrderDetail.Text = "Chưa xử lí";

            //Reset giá trị trong bằng
            datagridOrderDetail.Rows.Clear();
            datagridOrderDetail.Refresh();

            txtAmount.Text = "";
            cbUnit.SelectedIndex = 0;
            cbProduct.SelectedIndex = 0;
            cbNCC.SelectedIndex = 0;


        }

        private void datagridOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datagridOrderDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                datagridOrderDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DataGridViewRow row = this.datagridOrderDetail.Rows[e.RowIndex];

                txtAmount.Text = row.Cells[1].Value.ToString();

                for (int i = 0; i < cbProduct.Items.Count; i++) 
                {
                    string value = ((Product)cbProduct.Items[i]).ID;
                    if (value.Equals(row.Cells[0].Value.ToString()))
                    {
                        cbProduct.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < cbUnit.Items.Count; i++)
                {
                    string value = ((Unit)cbUnit.Items[i]).Name;
                    if (value.Equals(row.Cells[2].Value.ToString()))
                    {
                        cbUnit.SelectedIndex = i;
                        break;
                    }
                }


                for (int i = 0; i < cbNCC.Items.Count; i++)
                {
                    string value = ((Suplier)cbNCC.Items[i]).IdSuplier;
                    if (value.Equals(row.Cells[3].Value.ToString()))
                    {
                        cbNCC.SelectedIndex = i;
                        break;
                    }

                }

                //MessageBox.Show(row.Cells[1].Value.ToString() + row.Cells[2].Value.ToString(), "My Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //txtIdOrderDetail.Text = rowSelect.Cells[0].Value.ToString();


            }
        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            string idProduct = ((Product)cbProduct.SelectedItem).ID.ToString();
            string amount = txtAmount.Text;
            string idUnit = ((Unit)cbUnit.SelectedItem).ID.ToString();
            string idSuplier = ((Suplier)cbNCC.SelectedItem).IdSuplier.ToString();

            if (cbProduct.SelectedIndex == 0 || txtAmount.Text == "" || cbUnit.SelectedIndex == 0 || cbNCC.SelectedIndex == 0)    
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin", "My Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool addrow = true;


                for (int i = 0; i < datagridOrderDetail.RowCount; i++)
                {
                    DataGridViewRow row = this.datagridOrderDetail.Rows[i];
                    var idhas = row.Cells[0].Value.ToString();
                    if (idProduct.Equals(idhas))
                    {
                        //update số lượng sản phẩm
                        var amo = int.Parse(amount);
                        amo += int.Parse(row.Cells[1].Value.ToString());
                        amount = amo.ToString();
                        row.Cells[1].Value = amount;
                        addrow = false;

                        //update đơn vị

                        string value = ((Unit)cbUnit.SelectedItem).ID;
                        if (!value.Equals(row.Cells[2].Value.ToString()))
                        {
                            row.Cells[2].Value = value;
                            for (int j = 1; j < cbUnit.Items.Count; j++)
                            {
                                if (((Unit)cbUnit.Items[j]).Name.Equals(value))
                                    cbUnit.SelectedIndex = j;
                                break;
                            }

                        }

                        //update NCC
                        string valueNCC = ((Suplier)cbNCC.SelectedItem).IdSuplier;
                        if (!valueNCC.Equals(row.Cells[3].Value.ToString()))
                        {
                            row.Cells[3].Value = valueNCC;
                            for (int j = 1; j < cbUnit.Items.Count; j++)
                            {
                                if (((Suplier)cbNCC.Items[j]).DisplayName.Equals(valueNCC))
                                    cbNCC.SelectedIndex = j;
                                break;
                            }

                        }
                        //for (int i = 0; i < cbNCC.Items.Count; i++)
                        //{
                        //    string value = ((Suplier)cbNCC.Items[i]).IdSuplier;
                        //    if (value.Equals(row.Cells[3].Value.ToString()))
                        //    {
                        //        cbNCC.SelectedIndex = i;
                        //        break;
                        //    }

                        //}
                        break;
                    }
                }
                if (addrow)
                {
                    datagridOrderDetail.Rows.Add(new object[] { idProduct, amount, idUnit, idSuplier });
                }

                // Sẽ không có dòng nào được chọn lúc load
                datagridOrderDetail.ClearSelection();
                datagridOrderDetail.Rows[0].Selected = false;
            }



        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            string idOrder = txtIdOrderDetail.Text;
            string idUser = txtNhanVienOrderDetail.Text.Substring(0, 10);
            var rowCount = datagridOrderDetail.RowCount;
            if (rowCount > 0)
            {
                OrderDTO order = new OrderDTO(idOrder, idUser);
                var i = Obus.AddOrder(order);
                
                List<OrderDetailDTO> listOrder = new List<OrderDetailDTO>();
                for (int index = 0; index< datagridOrderDetail.RowCount; index++)
                {
                    DataGridViewRow row = this.datagridOrderDetail.Rows[index];


                    OrderDetailDTO orderDetailDTO = new OrderDetailDTO();
                    orderDetailDTO.IdOrder = idOrder;
                    orderDetailDTO.IdProduct = row.Cells[0].Value.ToString();
                    orderDetailDTO.Amount = row.Cells[1].Value.ToString();
                    orderDetailDTO.idUnit = row.Cells[2].Value.ToString();
                    orderDetailDTO.idSuplier = row.Cells[3].Value.ToString();

                    listOrder.Add(orderDetailDTO);
                }

                var result = Obus.AddOrderDetail(listOrder);
                
                if (result == 1 && i == 1)
                    MessageBox.Show("Tạo chi tiết đặt hàng thành công", "Kho", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Tạo chi tiết đặt hàng thất bại", "Kho", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

        private void btnDelOrder_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = datagridOrderDetail.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    datagridOrderDetail.Rows.RemoveAt(datagridOrderDetail.SelectedRows[0].Index);
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            panelOrdertab2.Visible = false;
            panelOrderDetail.Visible = false;

            txtIdImportDetail.Text = "";
            txtCreateDateImportDetail.Text = "";
            txtIdUserImportDetail.Text = "";
            txtStatusImportDetail.Text = "";

            txtIdImportDetail.Text = LoginVar.newImport;
            txtIdUserImportDetail.Text = LoginVar.ID + " - " + LoginVar.Name + " (" + LoginVar.Role + ")";
            txtCreateDateImportDetail.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtStatusImportDetail.Text = "Chưa xử lí";
            txtIdPackage.Text = LoginVar.newPackage;
            

            loadNewIdImport();
            loadNewIdPackage();
            //Reset giá trị trong bằng
            dataGridImportDetail.Rows.Clear();
            dataGridImportDetail.Refresh();

            var index = datagridOrder.CurrentCell.RowIndex;
            DataGridViewRow roww = this.datagridOrder.Rows[index];
            var idOrder = roww.Cells[0].Value.ToString();

            txtIdOrderinImportDetail.Text = idOrder;

            var data = Obus.OrderDetail(idOrder);

            foreach (DataRow row in data.Rows)
            {
                string idProduct = row["IdProduct"].ToString();
                string amount = row["Amount"].ToString();
                string idUnit = row["Id_Unit"].ToString();
                string idSuplier = row["IdSuplier"].ToString();

                dataGridImportDetail.Rows.Add(new object[] { idProduct, amount, idUnit, idSuplier, "0", "0", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") });
            }
            // Sẽ không có dòng nào được chọn lúc load
            dataGridImportDetail.ClearSelection();
            dataGridImportDetail.Rows[0].Selected = false;


            //txtAmount.Text = "";
            //cbUnit.SelectedIndex = 0;
            //cbProduct.SelectedIndex = 0;
            //cbNCC.SelectedIndex = 0;

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string idImport = txtIdImportDetail.Text;
            string idUser = txtIdUserImportDetail.Text.Substring(0, 10);
            string idOrder = txtIdOrderinImportDetail.Text;
            string idPackage = txtIdPackage.Text;
            string totalPrice = txtTotalPriceImport.Text;

            var rowCount = dataGridImportDetail.RowCount;
            if (rowCount > 0)
            {
                ImportDTO import = new ImportDTO(idImport, idOrder, idPackage, totalPrice, idUser);
                
                var i = Ibus.AddImport(import);

                List<ImportDetailDTO> listImport = new List<ImportDetailDTO>();
                for (int index = 0; index < dataGridImportDetail.RowCount; index++)
                {
                    DataGridViewRow row = this.dataGridImportDetail.Rows[index];


                    ImportDetailDTO importDetailDTO = new ImportDetailDTO();
                    importDetailDTO.IdImport = idImport;
                    importDetailDTO.IdProduct = row.Cells[0].Value.ToString();
                    importDetailDTO.amount = row.Cells[1].Value.ToString();
                    importDetailDTO.idUnit = row.Cells[2].Value.ToString();
                    importDetailDTO.idSuplier = row.Cells[3].Value.ToString();
                    importDetailDTO.price = row.Cells[4].Value.ToString();
                    importDetailDTO.intoPrice = row.Cells[5].Value.ToString();
                    DateTime oDate = Convert.ToDateTime(row.Cells[6].Value.ToString());
                    importDetailDTO.expired = oDate;



                    listImport.Add(importDetailDTO);
                }

                var result = Ibus.AddImportDetail(listImport);

                if (result == 1 && i == 1)
                {
                    var confimrOrder = Obus.ComfirmOrder(idOrder);
                    MessageBox.Show("Tạo chi tiết nhập hàng thành công", "Kho", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Tạo chi tiết nhập hàng thất bại", "Kho", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
        }

        private void dataGridImportDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridImportDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DataGridViewRow row = this.dataGridImportDetail.Rows[e.RowIndex];

                txtAmountImport.Text = row.Cells[1].Value.ToString();

                for (int i = 0; i < cbSanPhamImport.Items.Count; i++)
                {
                    string value = ((Product)cbSanPhamImport.Items[i]).ID;
                    if (value.Equals(row.Cells[0].Value.ToString()))
                    {
                        cbSanPhamImport.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < cbUnitImport.Items.Count; i++)
                {
                    string value = ((Unit)cbUnitImport.Items[i]).ID;
                    if (value.Equals(row.Cells[2].Value.ToString()))
                    {
                        cbUnitImport.SelectedIndex = i;
                        break;
                    }
                }


                for (int i = 0; i < cbNCCImport.Items.Count; i++)
                {
                    string value = ((Suplier)cbNCCImport.Items[i]).IdSuplier;
                    if (value.Equals(row.Cells[3].Value.ToString()))
                    {
                        cbNCCImport.SelectedIndex = i;
                        break;
                    }

                }

                txtPriceImport.Text = row.Cells[4].Value.ToString();
                txtIntoPriceImport.Text = row.Cells[5].Value.ToString();
                DateTime oDate = Convert.ToDateTime(row.Cells[6].Value.ToString());
                DatePickerImport.Value = oDate;

                //MessageBox.Show(row.Cells[1].Value.ToString() + row.Cells[2].Value.ToString(), "My Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //txtIdOrderDetail.Text = rowSelect.Cells[0].Value.ToString();


            }
        }

        private void btnUpdateImportDetail_Click(object sender, EventArgs e)
        {
            var index = dataGridImportDetail.CurrentCell.RowIndex;
            DataGridViewRow roww = this.dataGridImportDetail.Rows[index];
            var idOrder = roww.Cells[0].Value.ToString();

            var price = txtPriceImport.Text;
            var intoPrice = txtIntoPriceImport.Text;
            var datePicker = DatePickerImport.Value.ToString("yyyy-MM-dd HH:mm:ss.fff");
            //var datePicker = DatePickerImport.Value.ToString();

            roww.Cells[4].Value = price;
            roww.Cells[5].Value = intoPrice;
            roww.Cells[6].Value = datePicker;

            int checkSum = 0;
            for (int i = 0; i<dataGridImportDetail.RowCount; i++)
            {
                DataGridViewRow row = this.dataGridImportDetail.Rows[i];
                if (row.Cells[5].Value.ToString().Equals("0"))
                {
                    continue;
                }
                var eachPrice = row.Cells[5].Value.ToString();
                checkSum += int.Parse(eachPrice);
            }
            txtTotalPriceImport.Text = checkSum.ToString();


            //setIntoPrice();

        }
        private int setIntoPrice(string price, string amount)
        {
            int soluong = int.Parse(amount);
            int gia = int.Parse(price);
            return gia * soluong;
        }

        private void txtIntoPriceImport_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void txtPriceImport_TextChanged(object sender, EventArgs e)
        {
            var index = dataGridImportDetail.CurrentCell.RowIndex;
            DataGridViewRow roww = this.dataGridImportDetail.Rows[index];
            var amount = roww.Cells[1].Value.ToString();
            txtIntoPriceImport.Text = setIntoPrice(txtPriceImport.Text, amount).ToString();
            
            
        }
    }
}

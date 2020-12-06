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
using BUS;

namespace QLKho
{
    public partial class XuatHang : UserControl
    {
        Export_BUS Exbus = new Export_BUS();

        //Trieu
        OutputBUS bus = new OutputBUS();
        private int vtRowTable1;
        private int vtRowTable2;
        private string masp1, mapackage1, sl1 = "";

        public XuatHang()
        {
            InitializeComponent();
        }

        private void XuatHang_Load(object sender, EventArgs e)
        {
            loadNewIdExport();
            loadIdUser();
            loadCreatedDate();
            loadStatus();
            loadDataExport();
            LoadBang1();
        }

        private void LoadBang1()
        {
            datagridPackEx.ColumnCount = 5;
            datagridPackEx.Columns[0].Name = "Mã sản phẩm";
            datagridPackEx.Columns[1].Name = "Tên sản phẩm";
            datagridPackEx.Columns[2].Name = "Mã lô hàng";
            datagridPackEx.Columns[3].Name = "Số lượng";
            datagridPackEx.Columns[4].Name = "Ngày hết hạn";

            var data = bus.getSanPham();
            foreach (DataRow row in data.Rows)
            {
                string IdProduct = row["IdProduct"].ToString();
                string name = row["DisplayName"].ToString();
                string idpack = row["IdPackage"].ToString();
                string sl = row["Amount"].ToString();
                string exp = row["ExpiryDate"].ToString();

                datagridPackEx.Rows.Add(new object[] { IdProduct, name,idpack, sl,exp});

            }
        }

        private void loadDataExport()
        {

            //Load lại 
            datagridOutput.Rows.Clear();
            datagridOutput.Refresh();

            //load column cho các bảng
            datagridOutput.ColumnCount = 3;
            datagridOutput.Columns[0].Name = "Mã Đơn xuất hàng";
            datagridOutput.Columns[1].Name = "Ngày tạo";
            datagridOutput.Columns[2].Name = "Nhân viên";

            //load column cho các bảng
            datagridOupdatagridOuputDetailutDetail.ColumnCount = 4;
            datagridOupdatagridOuputDetailutDetail.Columns[0].Name = "Mã sản phẩm";
            datagridOupdatagridOuputDetailutDetail.Columns[1].Name = "Sản phẩm";
            datagridOupdatagridOuputDetailutDetail.Columns[2].Name = "Số lượng";
            datagridOupdatagridOuputDetailutDetail.Columns[3].Name = "Mã lô hàng";

            var data = Exbus.getOutput();
            foreach (DataRow row in data.Rows)
            {
                string idExport = row["ID"].ToString();
                string createdDate = row["DATEOUTPUT"].ToString();
                string idUser = row["ID_USER"].ToString();
                string nameUser = row["DisplayName"].ToString();
                string roleUser = row["IdUserRole"].ToString();

                datagridOutput.Rows.Add(new object[] { idExport, createdDate, idUser + " - " + nameUser + " (" + roleUser + ")"});

            }

        }

        private void loadStatus()
        {
            return;
        }

        private void loadCreatedDate()
        {
            txtCreateDateOutPut.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void loadIdUser()
        {
            txtUserOutput.Text = LoginVar.ID + " - " + LoginVar.Name + " (" + LoginVar.Role + ")";
        }

        private void loadNewIdExport()
        {
            //Lấy ID tiếp theo của Order
            var maxId = Exbus.getMaxIdOutPut();
            if(maxId.Rows.Count == 0)
            {
                LoginVar.newOutput = "EX001";
            }
            else
            {
                LoginVar.newOutput = maxId.Rows[0]["ID"].ToString();
                LoginVar.newOutput = LoginVar.newOutput.Substring(LoginVar.newOutput.Length - 3);
                int numberGet = int.Parse(LoginVar.newOutput) + 1;
                if (numberGet < 10)
                {
                    LoginVar.newOutput = "EX" + "0" + "0" + numberGet.ToString();
                }
                else if (numberGet < 100 && numberGet >= 10)
                {
                    LoginVar.newOutput = "EX" + "0" + numberGet.ToString();
                }
            }

            txtNewIdOutPut.Text = LoginVar.newOutput;
        }

        private void datagridOutput_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datagridOutput_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                datagridOutput.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DataGridViewRow rowSelect = this.datagridOutput.Rows[e.RowIndex];

                //txtIdOrderDetail.Text = rowSelect.Cells[0].Value.ToString();
                //txtCreatedDateOrderDetail.Text = rowSelect.Cells[1].Value.ToString();
                //txtNhanVienOrderDetail.Text = rowSelect.Cells[2].Value.ToString();
                paneltab4.Visible = false;

                //Reset giá trị trong bằng
                datagridOupdatagridOuputDetailutDetail.Rows.Clear();
                datagridOupdatagridOuputDetailutDetail.Refresh();

                string idExport = rowSelect.Cells[0].Value.ToString();
                var data = Exbus.ExportDetail(idExport);

                foreach (DataRow row in data.Rows)
                {
                    string idProduct = row["ID_PRODUCT"].ToString();
                    string nameProduct = row["DisplayName"].ToString();
                    string amount = row["QUANTITY"].ToString();
                    string idPackage = row["ID_Package"].ToString();

                    datagridOupdatagridOuputDetailutDetail.Rows.Add(new object[] { idProduct, nameProduct, amount, idPackage });
                }
                // Sẽ không có dòng nào được chọn lúc load
                datagridOupdatagridOuputDetailutDetail.ClearSelection();
                datagridOupdatagridOuputDetailutDetail.Rows[0].Selected = false;

            }
        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {

            if (txtAmountExport.Text == "" || txtAmountExport.Text == "0" || sl1 == "" )
            {
                MessageBox.Show("Số lượng không thể để trống hoặc bằng 0", "My Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Int32.Parse(txtAmountExport.Text) > Int32.Parse(sl1))
                {
                    MessageBox.Show("Số lượng xuất đi ko thế lớn hơn số lượng tồn", "My Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int flag = 0;
                    if (datagridPackEx.RowCount > 0)
                    {
                        foreach (DataGridViewRow row in datagridPackEx2.Rows)
                        {
                            if (Convert.ToString(row.Cells[0].Value) == string.Empty)
                                break;
                            string val1 = row.Cells[0].Value.ToString();
                            string val2 = row.Cells[1].Value.ToString();
                            Console.WriteLine("Gia tri val la: ", val1);
                            //MessageBox.Show(val);
                            if (val1.Equals(masp1) && val2.Equals(mapackage1))
                            {
                                flag = 1;
                                break;
                            }
                            else
                                flag = 0;
                        }

                        if (flag == 0)
                        {
                            int vt = vtRowTable1;
                            datagridPackEx2.Rows.Add(datagridPackEx.Rows[vt].Cells[0].Value.ToString(), datagridPackEx.Rows[vt].Cells[2].Value.ToString(), txtAmountExport.Text);
                            txtAmountExport.Text = "";
                        }
                        else
                            MessageBox.Show("Sản phẩm này đã được chọn", "My Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void guna2Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void datagridOutputt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datagridOutputt_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void datagridPackEx_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                datagridPackEx.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DataGridViewRow row = this.datagridPackEx.Rows[e.RowIndex];

                txtSpExport.Text = row.Cells[0].Value.ToString();
                txtAmountExport.Text = row.Cells[3].Value.ToString();


                int VT = datagridPackEx.CurrentRow.Index;
                vtRowTable1 = VT;
                int VT1 = datagridPackEx.CurrentCell.RowIndex;
                masp1 = datagridPackEx.Rows[VT1].Cells[0].Value.ToString();
                mapackage1 = datagridPackEx.Rows[VT1].Cells[2].Value.ToString();
                sl1 = datagridPackEx.Rows[VT1].Cells[3].Value.ToString();
            }
        }

        private void datagridPackEx2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int VT = datagridPackEx2.CurrentRow.Index;
            vtRowTable2 = VT;
        }

        private void btnDelOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (datagridPackEx2.SelectedRows.Count > 0)
                {
                    int vt = vtRowTable2;
                    datagridPackEx2.Rows.RemoveAt(vt);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Đã xảy ra lỗi");
            }
        }

        private void btnAddDetailExport_Click(object sender, EventArgs e)
        {
            int flag = 0;
            if (datagridPackEx2.RowCount <= 1)
                MessageBox.Show("Không thể thêm chi tiết");
            else
            {
                if (txtNewIdOutPut.Text != "" && txtCreateDateOutPut.Text != "" && txtUserOutput.Text != "")
                {
                    OutPutDTO dto = new OutPutDTO(txtNewIdOutPut.Text, txtCreateDateOutPut.Text, txtUserOutput.Text.Substring(0,10));
                    if (bus.ThemPhieuXuat(dto))
                    {
                        for (int i = 0; i < datagridPackEx2.RowCount - 1; i++)
                        {
                            try
                            {
                                string masp = datagridPackEx2.Rows[i].Cells[0].Value.ToString();
                                string mapackage = datagridPackEx2.Rows[i].Cells[1].Value.ToString();
                                int sl = Int32.Parse(datagridPackEx2.Rows[i].Cells[2].Value.ToString()); ;
                                string machitietphieu = txtNewIdOutPut.Text;
                                OutPutDetail dto1 = new OutPutDetail(machitietphieu, masp, mapackage, sl);
                                if (bus.ThemCTPhieuXuat(dto1))
                                {
                                    flag = 1;
                                }
                                else
                                {
                                    flag = 0;
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Đã xảy ra lỗi");
                            }
                        }
                    }
                    else
                        MessageBox.Show("Thêm thất bại");
                }
                else
                {
                    MessageBox.Show("Không thể thêm");
                }
                if (flag == 1)
                {
                    MessageBox.Show("Thêm thành công chi tiết phiếu xuất hàng");
                }
                else
                    MessageBox.Show("Thêm chi tiết xuất hàng thất bại");
            }
            
        }

        private void pannelBackButton_Click(object sender, EventArgs e)
        {
            paneltab4.Visible = true;
            panelOutputDetail.Visible = true;
        }

        private void btnCreateOuput_Click(object sender, EventArgs e)
        {
            //panelCreateNewExport
            paneltab4.Visible = false;
            panelOutputDetail.Visible = false;
        }
    }
}

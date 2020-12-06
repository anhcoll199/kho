using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BUS;
using DTO;

namespace QLKho
{
    
    public partial class UC_ThongKe : UserControl
    {
        Chart_BUS CBus = new Chart_BUS();
        Package_BUS Pbus = new Package_BUS();
        public UC_ThongKe()
        {
            InitializeComponent();
        }

        private void UC_ThongKe_Load(object sender, EventArgs e)
        {
            setCustomDateTimePicker();
            panelChart1.Visible = false;
            panelFillChart1.Visible = false;
            panelChart2.Visible = false;
            panelFillChart2.Visible = false;
            loadCbProduct();
        }

        private void loadCbProduct()
        {
            cbProductChart.Items.Add(new Product("0", "Tất cả sản phẩm"));
            var table = Pbus.getProduct();
            foreach (DataRow row in table.Rows)
            {
                string id = row["IdProduct"].ToString();
                string name = id + " - " + row["DisplayName"].ToString();
                cbProductChart.Items.Add(new Product(id, name));
            }
            cbProductChart.SelectedIndex = 0;
            cbProductChart.DisplayMember = "Name";
            cbProductChart.ValueMember = "ID";
        }

        //fillChart method  
        private void fillChartIOYear(string year)
        {
            //clear
            chart1.Series["Đơn nhập"].Points.Clear();
            chart1.Titles.Clear();
            //Cài đặt biểu đồ

            //Thêm giá trị cho biểu đồ đơn nhập
            var chartYearI = CBus.getChartImport(year);

            

            chart1.Series["Đơn nhập"].Points.AddXY("Jan", chartYearI.January);
            chart1.Series["Đơn nhập"].Points.AddXY("Feb", chartYearI.February);
            chart1.Series["Đơn nhập"].Points.AddXY("Mar", chartYearI.March);
            chart1.Series["Đơn nhập"].Points.AddXY("Apr", chartYearI.April);
            chart1.Series["Đơn nhập"].Points.AddXY("May", chartYearI.May);
            chart1.Series["Đơn nhập"].Points.AddXY("Jun", chartYearI.June);
            chart1.Series["Đơn nhập"].Points.AddXY("Jul", chartYearI.July);
            chart1.Series["Đơn nhập"].Points.AddXY("Aug", chartYearI.August);
            chart1.Series["Đơn nhập"].Points.AddXY("Sep", chartYearI.September);
            chart1.Series["Đơn nhập"].Points.AddXY("Oct", chartYearI.October);
            chart1.Series["Đơn nhập"].Points.AddXY("Nov", chartYearI.November);
            chart1.Series["Đơn nhập"].Points.AddXY("Dec", chartYearI.December);


            lbOCount.ForeColor = Color.FromArgb(65, 140, 240);
            lbICount.Text = chartYearI.Total.ToString();

            ////Thêm giá trị cho biểu đồ đơn nhập
            //chart1.Series["Đơn xuất"].Points.AddXY("Jan", chartYearI.January);
            //chart1.Series["Đơn xuất"].Points.AddXY("Feb", chartYearI.February);
            //chart1.Series["Đơn xuất"].Points.AddXY("Mar", chartYearI.March);
            //chart1.Series["Đơn xuất"].Points.AddXY("Apr", chartYearI.April);
            //chart1.Series["Đơn xuất"].Points.AddXY("May", chartYearI.May);
            //chart1.Series["Đơn xuất"].Points.AddXY("Jun", chartYearI.June);
            //chart1.Series["Đơn xuất"].Points.AddXY("Jul", chartYearI.July);
            //chart1.Series["Đơn xuất"].Points.AddXY("Aug", chartYearI.August);
            //chart1.Series["Đơn xuất"].Points.AddXY("Sep", chartYearI.September);
            //chart1.Series["Đơn xuất"].Points.AddXY("Oct", chartYearI.October);
            //chart1.Series["Đơn xuất"].Points.AddXY("Nov", chartYearI.November);
            //chart1.Series["Đơn xuất"].Points.AddXY("Dec", chartYearI.December);
            //chart1.Series["Đơn xuất"].Points.AddXY("Total", chartYearI.Total);

            //lbOCount.Text = chartYearI.Total.ToString();
            //lbOCount.ForeColor = Color.FromArgb(252, 180, 65);

            //Tiêu đề biểu đồ
            Title title = new Title();
            title.Font = new Font("Arial", 14, FontStyle.Bold);
            title.Text = "Biểu đồ số lượng đơn nhập/xuất năm " + datetimepickerChartIO.Value.Year.ToString();
            chart1.Titles.Add(title);

            //Xoá bỏ các đường kẻ sau biểu đồ
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
        }

        private void setCustomDateTimePicker()
        {
            datetimepickerChartIO.Format = DateTimePickerFormat.Custom;
            datetimepickerChartIO.CustomFormat = "yyyy";

            datetimepickerChartIOProStart.Format = DateTimePickerFormat.Custom;
            datetimepickerChartIOProStart.CustomFormat = "dd-MM-yyyy";

            datetimepickerChartIOProEnd.Format = DateTimePickerFormat.Custom;
            datetimepickerChartIOProEnd.CustomFormat = "dd-MM-yyyy";

        }

        private void btnChartIOYear_Click(object sender, EventArgs e)
        {
            string year = datetimepickerChartIO.Value.Year.ToString();
            fillChartIOYear(year);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            panelChart1.Visible = true;
            panelFillChart1.Visible = true;
            panelChart2.Visible = false;
            panelFillChart2.Visible = false;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            panelChart2.Visible = true;
            panelFillChart2.Visible = true;
            panelChart1.Visible = false;
            panelFillChart1.Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnChartIO2_Click(object sender, EventArgs e)
        {
            string start = datetimepickerChartIOProStart.Value.ToString("yyyy/MM/dd");
            string end = datetimepickerChartIOProEnd.Value.ToString("yyyy/MM/dd");
            
            if (datetimepickerChartIOProStart.Value >= datetimepickerChartIOProEnd.Value)
                MessageBox.Show("Ngày bắt đầu không thể lớn hoặc bằng ngày kết thúc", "My Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string idProduct = ((Product)cbProductChart.SelectedItem).ID;
                fillChart2(idProduct, start, end);
            }
        }

        private void fillChart2(string idProduct, string start, string end)
        {
            //clear
            chart2.Series["Số lượng nhập"].Points.Clear();
            chart2.Titles.Clear();
            ////Cài đặt biểu đồ

            ////Thêm giá trị cho biểu đồ đơn nhập
            ChartSpDTO chartYearI = CBus.getChartSP(idProduct, start, end);
            ChartSpDTO chartYearII = CBus.getChartSPX(idProduct, start, end);

            chart2.Series["Số lượng nhập"].Points.AddXY(chartYearI.ID, chartYearI.Amount);
            chart2.Series["Số lượng xuất"].Points.AddXY(chartYearII.ID, chartYearII.Amount);

            lbSLImport.ForeColor = Color.FromArgb(65, 140, 240);
            lbSLImport.Text = chartYearI.Amount.ToString();

            lbSLExport.ForeColor = Color.FromArgb(65, 140, 240);
            lbSLExport.Text = chartYearII.Amount.ToString();

            //Thêm giá trị cho biểu đồ đơn nhập

            //Tiêu đề biểu đồ
            Title title = new Title();
            title.Font = new Font("Arial", 14, FontStyle.Bold);
            title.Text = "Biểu đồ số lượng nhập/xuất của " + chartYearI.ID + " trong "+ datetimepickerChartIOProStart.Value.ToString("yyyy/MM/dd") + " - " + datetimepickerChartIOProEnd.Value.ToString("yyyy/MM/dd");
            chart2.Titles.Add(title);

            //Xoá bỏ các đường kẻ sau biểu đồ
            chart2.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
        }
    }
}

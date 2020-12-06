using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Chart_DAL : DBConnect
    {
        public ChartYearDTO getChartImport(string year)
        {
            ChartYearDTO chartYear = new ChartYearDTO();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("USP_CHART_ORDER_YEAR", _conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@nvcYear", year);

            DataSet ds = new DataSet();
            da.Fill(ds, "result_name");

            DataTable dt = ds.Tables["result_name"];

            foreach (DataRow row in dt.Rows)
            {
                //manipulate your data
                chartYear.January = int.Parse(row["January"].ToString());
                chartYear.February = int.Parse(row["February"].ToString());
                chartYear.March = int.Parse(row["March"].ToString());
                chartYear.April = int.Parse(row["April"].ToString());
                chartYear.May = int.Parse(row["May"].ToString());
                chartYear.June = int.Parse(row["June"].ToString());
                chartYear.July = int.Parse(row["July"].ToString());
                chartYear.August = int.Parse(row["August"].ToString());
                chartYear.September = int.Parse(row["September"].ToString());
                chartYear.November = int.Parse(row["November"].ToString());
                chartYear.December = int.Parse(row["December"].ToString());
                chartYear.Total = int.Parse(row["TOTAL"].ToString());
            }
            return chartYear;
        }
        public ChartSpDTO getChartSP(string id, string start, string end)
        {
            ChartSpDTO chart = new ChartSpDTO();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("USP_CHART_SP_YEAR", _conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@nvcIdProduct", id);
            da.SelectCommand.Parameters.AddWithValue("@nvcStart", start);
            da.SelectCommand.Parameters.AddWithValue("@nvcEnd", end);

            DataSet ds = new DataSet();
            da.Fill(ds, "result_name");

            DataTable dt = ds.Tables["result_name"];

            foreach (DataRow row in dt.Rows)
            {
                //manipulate your data
                chart.Amount = int.Parse(row["SL"].ToString());
                chart.ID = id;
            } 

            return chart;
        }
        public ChartSpDTO getChartSPX(string id, string start, string end)
        {
            ChartSpDTO chart = new ChartSpDTO();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("USP_CHART_SPX_YEAR", _conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@nvcIdProduct", id);
            da.SelectCommand.Parameters.AddWithValue("@nvcStart", start);
            da.SelectCommand.Parameters.AddWithValue("@nvcEnd", end);

            DataSet ds = new DataSet();
            da.Fill(ds, "result_name");

            DataTable dt = ds.Tables["result_name"];

            foreach (DataRow row in dt.Rows)
            {
                //manipulate your data
                chart.Amount = int.Parse(row["SLX"].ToString());
                chart.ID = id;
            }

            return chart;
        }
    }
}


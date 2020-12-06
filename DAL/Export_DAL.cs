using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Export_DAL : DBConnect
    {
        public DataTable getMaxIdOutPut()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT ID FROM dbo.OutputProduct WHERE ID = (SELECT max(ID) FROM dbo.OutputProduct)", _conn);

            DataTable dtPackage = new DataTable();

            da.Fill(dtPackage);
            return dtPackage;
        }
        public DataTable getOutput()
        {
            SqlDataAdapter da = new SqlDataAdapter("EXEC dbo.USP_EXPORT", _conn);

            DataTable dtPackage = new DataTable();

            da.Fill(dtPackage);
            return dtPackage;
        }
        
        public DataTable ExportDetail(string idExport)
        {
            SqlDataAdapter da = new SqlDataAdapter("EXEC dbo.USP_EXPORT_DETAIL '" + idExport +"'" , _conn);

            DataTable dtPackage = new DataTable();

            da.Fill(dtPackage);
            return dtPackage;
        }
    }
}

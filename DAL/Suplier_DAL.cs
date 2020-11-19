using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Suplier_DAL : DBConnect
    {
        public DataTable getAll()
        {
            SqlDataAdapter da = new SqlDataAdapter("EXEC dbo.USP_GET_Product", _conn);
            DataTable dtSuplier = new DataTable();
            da.Fill(dtSuplier);
            return dtSuplier;
        }
    }
}

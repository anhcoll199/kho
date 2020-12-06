using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class User_DAL : DBConnect
    {
        public DataTable Login(string acc, string pass)
        {
            SqlDataAdapter da = new SqlDataAdapter("EXEC dbo.USP_LOGIN '" + acc + "', '" + pass + "'" , _conn);
            DataTable dtPackage = new DataTable();

            da.Fill(dtPackage);
            return dtPackage;
        }
    }
}

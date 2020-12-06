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
    public class Suplier_DAL : DBConnect
    {
        public DataTable getSuplier()
        {
            SqlDataAdapter da = new SqlDataAdapter("EXEC dbo.USP_GET_SUPLIER", _conn);
            DataTable dtSuplier = new DataTable();
            da.Fill(dtSuplier);
            return dtSuplier;
        }
        public int AddSuplier(Suplier suplier)
        {
            int result = 1;
            SqlCommand cmd;

            cmd = new SqlCommand("USP_INSERT_SUPLIER", _conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nvcIDSuplier", suplier.IdSuplier);
            cmd.Parameters.AddWithValue("@nvcDisplayName", suplier.DisplayName);
            cmd.Parameters.AddWithValue("@nvcAdd", suplier.Add);
            cmd.Parameters.AddWithValue("@nvcPhone", suplier.Phone);
            cmd.Parameters.AddWithValue("@nvcMail", suplier.Email);

            _conn.Open();
            int check = cmd.ExecuteNonQuery();
            if (check != 1)
            {
                result = check;
            }
            _conn.Close();

            return result;
        }
    }
}

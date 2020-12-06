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
    public class OutPutDAL : DBConnect
    {
        public DataTable getOutPut()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From OutputProduct", _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable getMaNhanVien()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select Id From Users", _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool ThemPhieuXuat(OutPutDTO dto)
        {
            try
            {
                _conn.Open();
                string SQL = string.Format("INSERT INTO OutputProduct(ID, DATEOUTPUT, ID_USER) VALUES ('{0}', '{1}', '{2}')", dto.maPhieu, dto.NgayLap, dto.maNhanVien);
                SqlCommand cmd = new SqlCommand(SQL, _conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                _conn.Close();
            }

            return false;
        }

        public bool SuaPhieuXuat(OutPutDTO dto)
        {
            try
            {
                _conn.Open();
                string SQL = string.Format("UPDATE OutputProduct SET DATEOUTPUT = '{0}', ID_USER = '{1}' WHERE ID = '{2}'", dto.NgayLap, dto.maNhanVien, dto.maPhieu);
                SqlCommand cmd = new SqlCommand(SQL, _conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                _conn.Close();
            }

            return false;
        }

        public DataTable getSanPham()
        {
            string sql = "SELECT p.IdProduct, p.DisplayName, pk.IdPackage, pk.Amount, ExpiryDate " +
                "FROM dbo.Product p, dbo.Package pk " +
                "WHERE p.IdProduct = pk.IdProduct AND pk.Amount <> 0";
            Console.WriteLine(sql);
            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        //Chi tiet phieu xuat

        public DataTable getOutPutDetail(string ma)
        {
            string sql = "Select * From DetailOutputProduct Where ID = '" + ma + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool ThemChiTietPhieuXuat(OutPutDetail dto)
        {
            try
            {
                _conn.Open();
                string SQL = string.Format("INSERT INTO DetailOutputProduct(ID, ID_PRODUCT, QUANTITY, ID_Package) VALUES ('{0}', '{1}', {2}, '{3}')", dto.machitietphieu, dto.masp, dto.sl, dto.mapackage);
                Console.WriteLine(SQL);
                SqlCommand cmd = new SqlCommand(SQL, _conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                _conn.Close();
            }

            return false;
        }
    }
}

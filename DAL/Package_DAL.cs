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
    public class Package_DAL : DBConnect
    {
        public DataTable getAll()
        {
            SqlDataAdapter da = new SqlDataAdapter("EXEC dbo.USP_GETDATA_PACKAGE", _conn);
            DataTable dtPackage = new DataTable();
            
            da.Fill(dtPackage);
            return dtPackage;
        }

        public DataTable getProduct()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM dbo.Product", _conn);
            DataTable dtPackage = new DataTable();

            da.Fill(dtPackage);
            return dtPackage;
        }


        public DataTable getPackageID()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT IdPackage FROM dbo.Package", _conn);
            DataTable dtPackage = new DataTable();

            da.Fill(dtPackage);
            return dtPackage;
        }

        public DataTable getUnit()
        {
            SqlDataAdapter da = new SqlDataAdapter("EXEC dbo.USP_GET_UNIT", _conn);
            DataTable dtPackage = new DataTable();

            da.Fill(dtPackage);
            return dtPackage;
        }

        public DataTable getMaxIdPackage()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT IdPackage FROM dbo.ImportProduct WHERE IdPackage = (SELECT max(IdPackage) FROM dbo.Package)", _conn);

            DataTable dtPackage = new DataTable();

            da.Fill(dtPackage);
            return dtPackage;
        }


        public DataTable FilterPackage(string textSearch, string idProduct)
        {
            string parIdProduct = "N'" + idProduct + "'";
            string productName = ", N'" + textSearch + "'";
            SqlDataAdapter da = new SqlDataAdapter("EXEC dbo.USP_GETDATA_FILTER_PACKAGE " + parIdProduct + productName, _conn);
            DataTable dtPackage = new DataTable();

            da.Fill(dtPackage);
            return dtPackage;
        }
        public int AddPackage(List<PackageDTO> listPack)
        {
            int result = 1;
            SqlCommand cmd;
            for (int index = 0; index < listPack.Count; index++)
            {
                PackageDTO pack = new PackageDTO();
                pack.IdPackage = listPack[index].IdPackage;
                pack.IdProduct = listPack[index].IdProduct;
                pack.IdSuplier = listPack[index].IdSuplier;
                pack.Amount = listPack[index].Amount;
                pack.ExpiryDate = listPack[index].ExpiryDate;
                pack.Id_Unit = listPack[index].Id_Unit;
                pack.Id_OrderForm = listPack[index].Id_OrderForm;

                cmd = new SqlCommand("USP_INSERT_PACKAGE", _conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nvcIdPackage", pack.IdPackage);
                cmd.Parameters.AddWithValue("@nvcIdProduct", pack.IdProduct);
                cmd.Parameters.AddWithValue("@nvcIdSuplier", pack.IdSuplier);
                cmd.Parameters.AddWithValue("@nvcAmount", pack.Amount);
                cmd.Parameters.AddWithValue("@nvcExpDate", pack.ExpiryDate);
                cmd.Parameters.AddWithValue("@nvcIdUnit", pack.Id_Unit);
                cmd.Parameters.AddWithValue("@nvcIdOrder", pack.Id_OrderForm);

                _conn.Open();
                int check = cmd.ExecuteNonQuery();
                if (check != 1)
                {
                    result = check;
                    break;
                }
                _conn.Close();
            }
            return result;
        }

        public int AddProduct(Product product)
        {
            int result = 1;
            SqlCommand cmd;

            cmd = new SqlCommand("USP_INSERT_Product", _conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nvcIDproduct", product.ID);
            cmd.Parameters.AddWithValue("@nvcDisplayName", product.Name);

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

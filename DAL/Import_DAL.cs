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
    public class Import_DAL : DBConnect
    {
        public DataTable getImport()
        {
            SqlDataAdapter da = new SqlDataAdapter("EXEC dbo.USP_GET_IMPORT  ", _conn);
            DataTable dtPackage = new DataTable();

            da.Fill(dtPackage);
            return dtPackage;
        }
        public DataTable ImportDetail(string idImport)
        {
            SqlDataAdapter da = new SqlDataAdapter("EXEC dbo.USP_GET_IMPORTDETAIL  '" + idImport + "'" , _conn);
            DataTable dtPackage = new DataTable();

            da.Fill(dtPackage);
            return dtPackage;
        }
        public DataTable getMaxIdImport()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT IdImportProduct FROM dbo.ImportProduct WHERE IdImportProduct = (SELECT max(IdImportProduct) FROM dbo.ImportProduct)", _conn);

            DataTable dtPackage = new DataTable();

            da.Fill(dtPackage);
            return dtPackage;
        }
        public int AddImport(ImportDTO import)
        {
            ImportDTO x = new ImportDTO();
            SqlCommand cmd = new SqlCommand("USP_INSERT_IMPORT", _conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nvcIdImportProduct", import.IdImport);
            cmd.Parameters.AddWithValue("@nvcIdOrderProduct", import.IdOrder);
            cmd.Parameters.AddWithValue("@nvcTotalPrice", import.totalPrice);
            cmd.Parameters.AddWithValue("@nvcCreatedDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            cmd.Parameters.AddWithValue("@nvcStatus", 0);
            cmd.Parameters.AddWithValue("@nvcIDPackage", import.idPackage);
            cmd.Parameters.AddWithValue("@nvcIdUser", import.idUser);

            var q = import.IdImport;
            var w = import.IdOrder;
            var e = import.totalPrice;
            var r = import.idPackage;
            var t = import.idUser;
            _conn.Open();
            int i = cmd.ExecuteNonQuery();

            _conn.Close();


            return i;
        }
        public int AddImportDetail(List<ImportDetailDTO> listImportDetailDTO)
        {
            int result = 1;
            SqlCommand cmd;
            for (int index = 0; index < listImportDetailDTO.Count; index++)
            {
                ImportDetailDTO importDetail = new ImportDetailDTO();
                importDetail.IdImport = listImportDetailDTO[index].IdImport;
                importDetail.IdProduct = listImportDetailDTO[index].IdProduct;
                importDetail.amount = listImportDetailDTO[index].amount;
                importDetail.idUnit = listImportDetailDTO[index].idUnit;
                importDetail.idSuplier = listImportDetailDTO[index].idSuplier;
                importDetail.price = listImportDetailDTO[index].price;
                importDetail.intoPrice = listImportDetailDTO[index].intoPrice;
                importDetail.expired = listImportDetailDTO[index].expired;

                cmd = new SqlCommand("USP_INSERT_IMPORTDETAIL", _conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nvcIdImportProduct", importDetail.IdImport);
                cmd.Parameters.AddWithValue("@nvcIdProduct", importDetail.IdProduct);
                cmd.Parameters.AddWithValue("@nvcAmount", importDetail.amount);
                cmd.Parameters.AddWithValue("@nvcUnitPrice", importDetail.price);
                cmd.Parameters.AddWithValue("@nvcIntoPrice", importDetail.intoPrice);
                cmd.Parameters.AddWithValue("@nvcExpDate", importDetail.expired);
                cmd.Parameters.AddWithValue("@nvcIdUnit", importDetail.idUnit);
                cmd.Parameters.AddWithValue("@nvcIdSuplier", importDetail.idSuplier);

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
        public int ComfirmImport(string idImport)
        {
            int result = 1;
            SqlCommand cmd;
            cmd = new SqlCommand("USP_CONFIRM_IMPORT", _conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nvcIdImportProduct", idImport);
            cmd.Parameters.AddWithValue("@nvcStatus", "1");

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

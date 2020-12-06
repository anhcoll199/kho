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
    public class Order_DAL : DBConnect
    {
        public DataTable getOrder()
        {
            SqlDataAdapter da = new SqlDataAdapter("EXEC dbo.USP_GET_ORDER  ", _conn);
            DataTable dtPackage = new DataTable();

            da.Fill(dtPackage);
            return dtPackage;
        }
        public DataTable getUser()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM dbo.Users", _conn);
            DataTable dtPackage = new DataTable();

            da.Fill(dtPackage);
            return dtPackage;
        }

        public DataTable FilterOrder(string status, string iduser)
        {
            SqlDataAdapter da = new SqlDataAdapter("EXEC USP_GETDATA_FILTER_ORDER " + status+ ", " + iduser , _conn);
            var sqlstring = "EXEC USP_GETDATA_FILTER_ORDER " + status + ", " + iduser;
            DataTable dtPackage = new DataTable();

            da.Fill(dtPackage);
            return dtPackage;
        }
        public DataTable OrderDetail(string idOrder)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT o.IdOrderProduct, o.IdProduct, o.Amount, o.Id_Unit, o.IdSuplier, p.DisplayName FROM dbo.OrderProductDetail o, dbo.Product p WHERE o.IdProduct = p.IdProduct AND o.IdOrderProduct = '" + idOrder + "'", _conn);
            DataTable dtPackage = new DataTable();

            da.Fill(dtPackage);
            return dtPackage;
        }

        public DataTable getMaxIdOrder()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT IdOrderProduct FROM dbo.OrderProduct WHERE IdOrderProduct = (SELECT max(IdOrderProduct) FROM dbo.OrderProduct)", _conn);
            
            DataTable dtPackage = new DataTable();

            da.Fill(dtPackage);
            return dtPackage;
        }
        public int AddOrder(OrderDTO order)
        {
            OrderDTO x = new OrderDTO();
            SqlCommand cmd = new SqlCommand("USP_INSERT_ORDER", _conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nvcIdOrderProduct", order.IdOrder);
            cmd.Parameters.AddWithValue("@nvcCreatedDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            cmd.Parameters.AddWithValue("@nvcStatus", 0);
            cmd.Parameters.AddWithValue("@nvcIdUser", order.idUser);

            var q = order.IdOrder;
            var w = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            var e = "0";
            var r = order.idUser;
            _conn.Open();
            int i = cmd.ExecuteNonQuery();

            _conn.Close();

            
            return i;
        }

        public int AddOrderDetail(List<OrderDetailDTO> listorderDetailDTO)
        {
            int result = 1;
            SqlCommand cmd;
            for (int index=0; index<listorderDetailDTO.Count; index++)
            {
                OrderDetailDTO orderDetail = new OrderDetailDTO();
                orderDetail.IdOrder = listorderDetailDTO[index].IdOrder;
                orderDetail.IdProduct = listorderDetailDTO[index].IdProduct;
                orderDetail.Amount = listorderDetailDTO[index].Amount;
                orderDetail.idUnit = listorderDetailDTO[index].idUnit;
                orderDetail.idSuplier = listorderDetailDTO[index].idSuplier;

                cmd = new SqlCommand("USP_INSERT_ORDERDETAIL", _conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nvcIdOrderProduct", orderDetail.IdOrder);
                cmd.Parameters.AddWithValue("@nvcIdProduct", orderDetail.IdProduct);
                cmd.Parameters.AddWithValue("@nvcAmount", orderDetail.Amount);
                cmd.Parameters.AddWithValue("@nvcIdUnit", orderDetail.idUnit);
                cmd.Parameters.AddWithValue("@nvcIdSuplier", orderDetail.idSuplier);

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
        public int ComfirmOrder(string idOrder)
        {
            int result = 1;
            SqlCommand cmd;
            cmd = new SqlCommand("USP_CONFIRM_ORDER", _conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nvcIdOrderProduct", idOrder);
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

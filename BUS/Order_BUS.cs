using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Order_BUS
    {
        Order_DAL dal = new Order_DAL();
        public DataTable getOrder()
        {
            return dal.getOrder();
        }
        public DataTable getUser()
        {
            return dal.getUser();
        }
        public DataTable FilterOrder(string status, string idUser)
        {
            return dal.FilterOrder(status, idUser);
        }
        public DataTable OrderDetail(string idOrder)
        {
            return dal.OrderDetail(idOrder);
        }
        public DataTable getMaxIdOrder()
        {
            return dal.getMaxIdOrder();
        }
        public int AddOrder(OrderDTO order)
        {
            return dal.AddOrder(order);
        }
        public int AddOrderDetail(List<OrderDetailDTO> listorderDetailDTO)
        {
            return dal.AddOrderDetail(listorderDetailDTO);
        }
        public int ComfirmOrder(string idOrder)
        {
            return dal.ComfirmOrder(idOrder);
        }


    }
}

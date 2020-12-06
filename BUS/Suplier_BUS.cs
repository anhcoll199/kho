using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class Suplier_BUS
    {
        Suplier_DAL dal = new Suplier_DAL();

        public DataTable getSuplier()
        {
            return dal.getSuplier();
        }
        public int AddSuplier(Suplier suplier)
        {
            return dal.AddSuplier(suplier);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class Suplier_BUS
    {
        Suplier_DAL dal = new Suplier_DAL();

        public DataTable getAll()
        {
            return dal.getAll();
        }
    }
}

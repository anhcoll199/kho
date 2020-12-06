using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class Export_BUS
    {
        Export_DAL dal = new Export_DAL();
        public DataTable getMaxIdOutPut()
        {
            return dal.getMaxIdOutPut();
        }
        public DataTable getOutput()
        {
            return dal.getOutput();
        }
        public DataTable ExportDetail(string idExport)
        {
            return dal.ExportDetail(idExport);
        }

    }
}

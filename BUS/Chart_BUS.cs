using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BUS
{
    public class Chart_BUS
    {
        Chart_DAL dal = new Chart_DAL();
        public ChartYearDTO getChartImport(string year)
        {
            return dal.getChartImport(year);
        }
        public ChartSpDTO getChartSP(string id, string start, string end)
        {
            return dal.getChartSP(id, start, end);
        }
        public ChartSpDTO getChartSPX(string id, string start, string end)
        {
            return dal.getChartSPX(id, start, end);
        }
    }
}

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
    public class Import_BUS
    {
        Import_DAL dal = new Import_DAL();

        public DataTable getMaxIdImport()
        {
            return dal.getMaxIdImport();
        }
        public DataTable getImport()
        {
            return dal.getImport();
        }
        public DataTable ImportDetail(string idImport)
        {
            return dal.ImportDetail(idImport);
        }
        
        public int AddImport(ImportDTO import)
        {
            return dal.AddImport(import);
        }
        public int AddImportDetail(List<ImportDetailDTO> listImportDetailDTO)
        {
            return dal.AddImportDetail(listImportDetailDTO);
        }
        public int ComfirmImport(string idImport)
        {
            return dal.ComfirmImport(idImport);
        }
    }
}

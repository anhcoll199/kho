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
    public class Package_BUS
    {
        Package_DAL dal = new Package_DAL();

        public DataTable getAll()
        {
            return dal.getAll();
        }

        public DataTable getProduct()
        {
            return dal.getProduct();
        }

        public DataTable getPackageID()
        {
            return dal.getPackageID();
        }

        public DataTable getUnit()
        {
            return dal.getUnit();
        }
        public DataTable FilterPackage(string textSearch, string idProduct)
        {
            return dal.FilterPackage(textSearch, idProduct);
        }
        public DataTable getMaxIdPackage()
        {
            return dal.getMaxIdPackage();
        }

        public int AddPackage(List<PackageDTO> listPack)
        {
            return dal.AddPackage(listPack);
        }
        public int AddProduct(Product product)
        {
            return dal.AddProduct(product);
        }
        
    }
}

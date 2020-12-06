using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PackageDTO
    {
        public string IdPackage { get; set; }
        public string IdProduct { get; set; }
        public string IdSuplier { get; set; }
        public string Amount { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Id_Unit { get; set; }
        public string Id_OrderForm { get; set; }


        public PackageDTO() { }
        public PackageDTO(string IdPackage, string IdProduct, string IdSuplier, string amount, DateTime exp, string idUnit, string idSuplier)
        {
            this.IdPackage = IdPackage;
            this.IdProduct = IdProduct;
            this.IdSuplier = IdSuplier;
            this.Amount = amount;
            this.ExpiryDate = exp;
            this.Id_Unit = idUnit;
            this.Id_OrderForm = idSuplier;
        }
    }
}

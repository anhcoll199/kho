using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ImportDetailDTO
    {
        public string IdImport { get; set; }
        public string IdProduct { get; set; }
        public string amount { get; set; }
        public string idUnit { get; set; }
        public string idSuplier { get; set; }
        public string price { get; set; }
        public string intoPrice { get; set; }
        public DateTime expired { get; set; }

        public ImportDetailDTO() { }
        public ImportDetailDTO(string idImport, string idProduct, string amount, string idUnit, string idSuplier, string price, string intoPrice, DateTime exp) 
        {
            this.IdImport = IdImport;
            this.IdProduct = IdProduct;
            this.amount = amount;
            this.idUnit = idUnit;
            this.idSuplier = idSuplier;
            this.price = price;
            this.intoPrice = intoPrice;
            this.expired = exp;
        }

    }
}

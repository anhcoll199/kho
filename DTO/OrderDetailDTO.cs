using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDetailDTO
    {
        public string IdOrder { get; set; }
        public string IdProduct { get; set; }
        public string Amount { get; set; }
        public string idUnit { get; set; }
        public string idSuplier { get; set; }
        public OrderDetailDTO() { }

        public OrderDetailDTO(string IdOrder, string IdProduct, string Amount, string idUnit, string idSuplier)
        {
            this.IdOrder = IdOrder;
            this.IdProduct = IdProduct;
            this.Amount = Amount;
            this.idUnit = idUnit;
            this.idSuplier = idSuplier;
        }

    }
}

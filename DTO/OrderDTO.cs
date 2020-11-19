using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDTO
    {
        private string IdObject { get; set; }
        private string IdSuplier { get; set; }
        private string DisplayNameObject { get; set; }
        private string DisplayNameSuplier { get; set; }
        private string Amount { get; set; }
        private DateTime CreatedDate { get; set; }
        private DateTime DeliveryDate { get; set; }


        public OrderDTO() { }

        public OrderDTO(string IdObject, string IdSuplier, string DisplayNameObject, string DisplayNameSuplier, string Amount, DateTime CreatedDate, DateTime DeliveryDate)
        {
            this.IdObject = IdObject;
            this.IdSuplier = IdSuplier;
            this.DisplayNameObject = DisplayNameObject;
            this.DisplayNameSuplier = DisplayNameSuplier;
            this.Amount = Amount;
            this.CreatedDate = CreatedDate;
            this.DeliveryDate = DeliveryDate;
        }

        
    }
}

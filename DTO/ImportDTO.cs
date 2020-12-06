using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ImportDTO
    {
        public string IdImport { get; set; }
        public string IdOrder { get; set; }
        public DateTime CreatedDate { get; set; }
        public string totalPrice { get; set; }
        public string idPackage { get; set; }
        public string status { get; set; }
        public string idUser { get; set; }


        public ImportDTO() { }
        public ImportDTO(string IdImport, string IdOrder, string idPackage, string totalPrice, string idUser)
        {
            this.IdImport = IdImport;
            this.IdOrder = IdOrder;
            this.idPackage = idPackage;
            this.totalPrice = totalPrice;
            this.idUser = idUser;
        }

    }
}

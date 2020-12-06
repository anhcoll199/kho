using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDTO
    {
        public string IdOrder { get; set; }
        public DateTime CreatedDate { get; set; }
        public string status { get; set; }
        public string idUser { get; set; }


        public OrderDTO() { }
        public OrderDTO(string IdOrder, string idUser)
        {
            this.IdOrder = IdOrder;
            this.idUser = idUser;
        }

        public OrderDTO(string IdOrder, DateTime CreatedDate, string status, string idUser)
        {
            this.IdOrder = IdOrder;
            this.CreatedDate = CreatedDate;
            this.status = status;
            this.idUser = idUser;
        }

        
    }
}

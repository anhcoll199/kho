using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Order
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public User User { get; set; }

        public Order() { }
        public Order(string id, string name, DateTime createdDate, string status, User user)
        {
            this.ID = ID;
            this.Name = Name;
            this.CreatedDate = createdDate;
            this.Status = status;
            this.User = user;

        }
    }
}

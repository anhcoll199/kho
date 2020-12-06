using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Suplier
    {

        public string IdSuplier { get; set; }
        public string DisplayName { get; set; }
        public string Add { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Suplier() { }

        public Suplier(string id, string name, string add, string phone, string email)
        {
            this.IdSuplier = id;
            this.DisplayName = name;
            this.Add = add;
            this.Phone = phone;
            this.Email = email;
        }
    }
}

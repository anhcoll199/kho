using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class User
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        public User() { }
        public User(string ID, string Name, string Role)
        {
            this.ID = ID;
            this.Name = Name;
            this.Role = Role;
        }
    }
}

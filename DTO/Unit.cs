using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Unit
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public Unit() { }
        public Unit(string ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
    }
}

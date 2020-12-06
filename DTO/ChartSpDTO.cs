using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChartSpDTO
    {
        public string ID { get; set; }
        public int Amount { get; set; }
        public ChartSpDTO() { }
        public ChartSpDTO(string id,  int amount) 
        {
            this.ID = id;
            this.Amount = amount;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Status
    {
        public string status { get; set; }
        public string Display { get; set; }

        public Status() { }
        public Status(string status, string display)
        {
            this.status = status;
            this.Display = display;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OutPutDetail
    {
        public string machitietphieu { get; set; }
        public string masp { get; set; }
        public string mapackage { get; set; }
        public int sl { get; set; }
        public OutPutDetail() { }
        public OutPutDetail(string machitietphieu, string masp, string mapack, int s1) 
        {
            this.machitietphieu = machitietphieu;
            this.masp = masp;
            this.mapackage = mapack;
            this.sl = s1;
        }
    }
}

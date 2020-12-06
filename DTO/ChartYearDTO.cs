using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChartYearDTO
    {
        public int January { get; set; }
        public int February { get; set; }
        public int March { get; set; }
        public int April { get; set; }
        public int May { get; set; }
        public int June { get; set; }
        public int July { get; set; }
        public int August { get; set; }
        public int September { get; set; }
        public int October { get; set; }
        public int November { get; set; }
        public int December { get; set; }
        public int Total { get; set; }
        public ChartYearDTO() { }
        public ChartYearDTO(int jan, int feb, int mar, int apr, int may, int june, int july, int aug, int sep, int oct, int nov, int dec, int total) 
        {
            this.January = jan;
            this.February = feb;
            this.March = mar;
            this.April = apr;
            this.May = may;
            this.June = june;
            this.July = july;
            this.August = aug;
            this.September = sep;
            this.October = oct;
            this.November = nov;
            this.December = dec;
            this.Total = total;
        }
    }

}

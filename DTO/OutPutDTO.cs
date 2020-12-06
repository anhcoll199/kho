using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OutPutDTO
    {
        public string maPhieu { get; set; }
        public string NgayLap { get; set; }
        public string maNhanVien { get; set; }
        public OutPutDTO() { }
        public OutPutDTO(string maphieu, string ngaylap, string manhanvien)
        {
            this.maPhieu = maphieu;
            this.NgayLap = ngaylap;
            this.maNhanVien = manhanvien;
        }
    }
}

using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class OutputBUS
    {
        OutPutDAL dal = new OutPutDAL();

        public DataTable getOutPut()
        {
            return dal.getOutPut();
        }
        public DataTable getMaNhanVien()
        {
            return dal.getMaNhanVien();
        }
        public bool ThemPhieuXuat(OutPutDTO dto)
        {
            return dal.ThemPhieuXuat(dto);
        }
        public DataTable getSanPham()
        {
            return dal.getSanPham();
        }

        //Chi tiết phiếu xuất

        public DataTable getChiTietXuat(string ma)
        {
            return dal.getOutPutDetail(ma);
        }

        public bool ThemCTPhieuXuat(OutPutDetail dto)
        {
            return dal.ThemChiTietPhieuXuat(dto);
        }
        public bool SuaPhieuXuat(OutPutDTO dto)
        {
            return dal.SuaPhieuXuat(dto);
        }

    }
}

using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class User_BUS
    {
        User_DAL dal = new User_DAL();
        public DataTable Login(string acc, string pass)
        {
            return dal.Login(acc, pass);
        }
    }
}

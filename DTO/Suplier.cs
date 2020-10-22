using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Suplier
    {
        private string IdSuplier, DisplayName, Add, Phone, Email, MoreInfo;

        public Suplier() { }

        public Suplier(string id, string name, string add, string phone, string email, string info)
        {
            this.IdSuplier = id;
            this.DisplayName = name;
            this.Add = add;
            this.Phone = phone;
            this.Email = email;
            this.MoreInfo = info;
        }

        public string IdSuplier1 { get => IdSuplier; set => IdSuplier = value; }
        public string DisplayName1 { get => DisplayName; set => DisplayName = value; }
        public string Add1 { get => Add; set => Add = value; }
        public string Phone1 { get => Phone; set => Phone = value; }
        public string Email1 { get => Email; set => Email = value; }
        public string MoreInfo1 { get => MoreInfo; set => MoreInfo = value; }
    }
}

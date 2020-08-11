using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlycuahang.DTO
{
    public class nhacungcap
    {
        private String mancc;
        private String tencc;
        private String dc;
        private String email;
        private String sdt;

        public nhacungcap(string mancc, string tencc, string dc, string email, string sdt)
        {
            this.mancc = mancc;
            this.tencc = tencc;
            this.dc = dc;
            this.email = email;
            this.sdt = sdt;
        }

        public nhacungcap(DataRow row)
        {
            this.mancc = row["mancc"].ToString();
            this.tencc = row["tenncc"].ToString();
            this.dc = row["diachi"].ToString();
            this.email = row["email"].ToString();
            this.sdt = row["sdt"].ToString();
        }

        public string Mancc { get => mancc; set => mancc = value; }
        public string Tencc { get => tencc; set => tencc = value; }
        public string Dc { get => dc; set => dc = value; }
        public string Email { get => email; set => email = value; }
        public string Sdt { get => sdt; set => sdt = value; }
    }
}

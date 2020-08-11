using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlycuahang.DTO
{
    public class Khachhang
    {
        private String makh;
        private String tenkh;
        private String diachi;
        private String sdt;

        public Khachhang(string makh, string tenkh, string diachi, string sdt)
        {
            this.makh = makh;
            this.tenkh = tenkh;
            this.diachi = diachi;
            this.sdt = sdt;
        }

        public Khachhang(DataRow row)
        {
            this.makh = row["makh"].ToString();
            this.tenkh = row["tenkh"].ToString();
            this.diachi = row["diachi"].ToString();
            this.sdt = row["sdt"].ToString();
        }

        public string Makh { get => makh; set => makh = value; }
        public string Tenkh { get => tenkh; set => tenkh = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
    }
}

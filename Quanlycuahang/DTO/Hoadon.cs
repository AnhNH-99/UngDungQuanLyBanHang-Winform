using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlycuahang.DTO
{
    public class Hoadon
    {
        private String mahd;
        private String manv;
        private String makh;
        private DateTime ngaylap;
        private decimal tongtien;

        public Hoadon(string mahd, string manv, string makh, DateTime ngaylap, decimal tongtien)
        {
            this.mahd = mahd;
            this.manv = manv;
            this.makh = makh;
            this.ngaylap = ngaylap;
            this.tongtien = tongtien;
        }
        public Hoadon(DataRow row)
        {
            this.mahd = row["mahd"].ToString();
            this.manv = row["manv"].ToString();
            this.makh = row["makh"].ToString();
            this.ngaylap = (DateTime)row["ngaylap"];
            this.tongtien = decimal.Parse(row["tongtien"].ToString());
        }

        public string Mahd { get => mahd; set => mahd = value; }
        public string Manv { get => manv; set => manv = value; }
        public string Makh { get => makh; set => makh = value; }
        public DateTime Ngaylap { get => ngaylap; set => ngaylap = value; }
        public decimal Tongtien { get => tongtien; set => tongtien = value; }
    }
}

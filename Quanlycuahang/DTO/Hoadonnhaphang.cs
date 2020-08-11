using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlycuahang.DTO
{
    public class Hoadonnhaphang
    {
        private String mahd;
        private String manv;
        private String mancc;
        private DateTime ngaylap;
        private decimal Tongtien;

        public Hoadonnhaphang(string mahd, string manv, string mancc, DateTime ngaylap, decimal tongtien)
        {
            this.mahd = mahd;
            this.manv = manv;
            this.mancc = mancc;
            this.ngaylap = ngaylap;
            Tongtien = tongtien;
        }
        public Hoadonnhaphang(DataRow row)
        {
            this.mahd = row["mahd"].ToString();
            this.manv = row["manv"].ToString();
            this.mancc = row["mancc"].ToString();
            this.ngaylap = (DateTime)row["ngaylap"];
            Tongtien = decimal.Parse(row["tongtien"].ToString());
        }
        public string Mahd { get => mahd; set => mahd = value; }
        public string Manv { get => manv; set => manv = value; }
        public string Mancc { get => mancc; set => mancc = value; }
        public DateTime Ngaylap { get => ngaylap; set => ngaylap = value; }
        public decimal Tongtien1 { get => Tongtien; set => Tongtien = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlycuahang.DTO
{
    public class CTHoadon
    {
        private String macthd;
        private String mahd;
        private String madh;
        private decimal giaban;
        private int soluong;

        public CTHoadon(string macthd, string mahd, string madh, decimal giaban, int soluong)
        {
            this.macthd = macthd;
            this.mahd = mahd;
            this.madh = madh;
            this.giaban = giaban;
            this.soluong = soluong;
        }
        public CTHoadon(DataRow row)
        {
            this.macthd = row["macthd"].ToString();
            this.mahd = row["mahd"].ToString();
            this.madh = row["madh"].ToString();
            this.giaban = decimal.Parse(row["giaban"].ToString());
            this.soluong = (int)row["soluong"];
        }
        public string Macthd { get => macthd; set => macthd = value; }
        public string Mahd { get => mahd; set => mahd = value; }
        public string Madh { get => madh; set => madh = value; }
        public decimal Giaban { get => giaban; set => giaban = value; }
        public int Soluong { get => soluong; set => soluong = value; }
    }
}

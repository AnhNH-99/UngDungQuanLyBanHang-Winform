using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlycuahang.DTO
{
    public class CTHoadonnhaphang
    {
        private String macthd;
        private String mahd;
        private String madh;
        private float gianhap;
        private int soluong;

        public CTHoadonnhaphang(string macthd, string mahd, string madh, float gianhap, int soluong)
        {
            this.macthd = macthd;
            this.mahd = mahd;
            this.madh = madh;
            this.gianhap = gianhap;
            this.soluong = soluong;
        }
        public CTHoadonnhaphang(DataRow row)
        {
            this.macthd = row["macthd"].ToString();
            this.mahd = row["mahd"].ToString();
            this.madh = row["madh"].ToString();
            this.gianhap = float.Parse(row["gianhap"].ToString());
            this.soluong = (int)row["soluong"];
        }
        public string Macthd { get => macthd; set => macthd = value; }
        public string Mahd { get => mahd; set => mahd = value; }
        public string Madh { get => madh; set => madh = value; }
        public float Gianhap { get => gianhap; set => gianhap = value; }
        public int Soluong { get => soluong; set => soluong = value; }
    }
}

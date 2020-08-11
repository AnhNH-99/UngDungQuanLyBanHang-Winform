using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlycuahang.DTO
{
    public class Dongho
    {
        private String madh;
        private String tendh;
        private String kieudang;
        private String thuonghieu;
        private int namsanxuat;
        private String nhacungcap;
        private decimal gianhap;
        private int soluong;
        private decimal giaban;
        private int baohanh;

        public Dongho(string madh, string tendh, string kieudang, string thuonghieu, int namsanxuat, string nhacungcap, decimal gianhap, int soluong, decimal giaban, int baohanh)
        {
            this.madh = madh;
            this.tendh = tendh;
            this.kieudang = kieudang;
            this.thuonghieu = thuonghieu;
            this.namsanxuat = namsanxuat;
            this.nhacungcap = nhacungcap;
            this.gianhap = gianhap;
            this.soluong = soluong;
            this.giaban = giaban;
            this.baohanh = baohanh;
        }
        public Dongho(DataRow row)
        {
            this.madh = row["madh"].ToString();
            this.tendh = row["tendh"].ToString();
            this.kieudang = row["kieudang"].ToString();
            this.thuonghieu = row["thuonghieu"].ToString();
            this.namsanxuat = (int)row["namsanxuat"];
            this.nhacungcap = row["mancc"].ToString();
            this.gianhap = decimal.Parse(row["gianhap"].ToString());
            this.soluong = (int)row["soluong"];
            this.giaban = decimal.Parse(row["giaban"].ToString());
            this.baohanh = (int)row["baohanh"];
        }
        public string Madh { get => madh; set => madh = value; }
        public string Tendh { get => tendh; set => tendh = value; }
        public string Kieudang { get => kieudang; set => kieudang = value; }
        public string Thuonghieu { get => thuonghieu; set => thuonghieu = value; }
        public int Namsanxuat { get => namsanxuat; set => namsanxuat = value; }
        public string Nhacungcap { get => nhacungcap; set => nhacungcap = value; }
        public decimal Gianhap { get => gianhap; set => gianhap = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public decimal Giaban { get => giaban; set => giaban = value; }
        public int Baohanh { get => baohanh; set => baohanh = value; }
    }
}

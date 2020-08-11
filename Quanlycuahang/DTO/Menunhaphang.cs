using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlycuahang.DTO
{
    public class Menunhaphang
    {
        private String madh;
        private String tendh;
        private decimal dongia;
        private int soluong;
        private decimal thanhtien;

        public Menunhaphang(string madh, string tendh, decimal dongia, int soluong, decimal thanhtien)
        {
            this.madh = madh;
            this.tendh = tendh;
            this.dongia = dongia;
            this.soluong = soluong;
            this.thanhtien = thanhtien;
        }
        public Menunhaphang(DataRow row)
        {
            this.madh = row["madh"].ToString();
            this.tendh = row["tendh"].ToString();
            this.dongia = decimal.Parse(row["gianhap"].ToString());
            this.soluong = (int)row["soluong"];
            this.thanhtien = decimal.Parse(row["thanhtien"].ToString());
        }

        public string Madh { get => madh; set => madh = value; }
        public string Tendh { get => tendh; set => tendh = value; }
        public decimal Dongia { get => dongia; set => dongia = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public decimal Thanhtien { get => thanhtien; set => thanhtien = value; }
    }
}

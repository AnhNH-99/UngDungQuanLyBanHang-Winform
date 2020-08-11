using Quanlycuahang.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlycuahang.DTO
{
    public class Nhanvien
    {
        private String manv;
        private String tennv;
        private String gioitinh;
        private DateTime ngaysinh;
        private String diachi;
        private String email;
        private String sdt;
        private String chucvu;
        private String matkhau;

        public Nhanvien(string manv, string tennv, string gioitinh, DateTime ngaysinh, string diachi, string email, string sdt, string chucvu, string matkhau)
        {
            this.manv = manv;
            this.tennv = tennv;
            this.gioitinh = gioitinh;
            this.ngaysinh = ngaysinh;
            this.diachi = diachi;
            this.email = email;
            this.sdt = sdt;
            this.chucvu = chucvu;
            this.matkhau = matkhau;
        }
        public Nhanvien(DataRow row)
        {
            this.manv = row["manv"].ToString();
            this.tennv = row["tennv"].ToString();
            this.gioitinh = row["gioitinh"].ToString();
            this.ngaysinh = (DateTime)row["ngaysinh"];
            this.diachi = row["diachi"].ToString();
            this.email = row["email"].ToString();
            this.sdt = row["sdt"].ToString();
            this.chucvu = row["chucvu"].ToString();
            this.matkhau = row["matkhau"].ToString();
        }

        

        public string Manv { get => manv; set => manv = value; }
        public string Tennv { get => tennv; set => tennv = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Email { get => email; set => email = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Chucvu { get => chucvu; set => chucvu = value; }
        public string Matkhau { get => matkhau; set => matkhau = value; }
    }
}

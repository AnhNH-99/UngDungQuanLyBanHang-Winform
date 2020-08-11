using DevExpress.DataAccess.Native.Data;
using Quanlycuahang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTable = System.Data.DataTable;

namespace Quanlycuahang.DAO
{
    public class NhanvienDAO
    {
        private static NhanvienDAO instance;

        public static NhanvienDAO Instance
        {
            get { if (instance == null) instance = new NhanvienDAO(); return instance; }
            set { instance = value; }
        }
        private NhanvienDAO() { }
        public bool Dangnhap(String manv, String matkhau)
        {
            matkhau = MaHoa.MD5Hash(matkhau);
            String qurey = "EXEC USP_Dangnhap @manv , @matkhau";
            DataTable result = DataProvider.Instance.ExecuteQuery(qurey, new Object[] { manv, matkhau });
            return result.Rows.Count > 0;
        }
        public Nhanvien GetAccountByUserName(String manv)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Nhanvien WHERE manv = '" + manv + "'");
            foreach (DataRow item in data.Rows)
            {
                return new Nhanvien(item);
            }
            return null;
        }

        public bool Doimatkhau(String manv, String matkhaucu, String matkhaumoi)
        {
            matkhaucu = MaHoa.MD5Hash(matkhaucu);
            matkhaumoi = MaHoa.MD5Hash(matkhaumoi);
            String qurey = "EXEC USP_Doimatkhau @manv , @matkhaucu , @matkhaumoi ";
            int data = DataProvider.Instance.ExecuteNonQuery(qurey, new Object[] { manv, matkhaucu, matkhaumoi });
            return data > 0;
        }
        public DataTable LoadDanhSachNhanVien()
        {
            String qurey = "SELECT manv AS [Mã nhân viên], tennv AS [Tên nhân viên], gioitinh AS[Giới tính], ngaysinh AS [Ngày sinh], diachi AS [Địa chỉ], email AS [Email], sdt AS [Số điện thoại], chucvu AS [Chức vụ] FROM nhanvien";
            return DataProvider.Instance.ExecuteQuery(qurey);
        }
        public List<Nhanvien> GetListChucVu()
        {
            List<Nhanvien> list = new List<Nhanvien>();
            String query = "SELECT * FROM nhanvien";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Nhanvien nhanvien = new Nhanvien(item);
                list.Add(nhanvien);
            }
            return list;
        }
        public bool ResertMatKhau(String manv)
        {
            String mk = "123456";
            String mkmh = MaHoa.MD5Hash(mk);
            String query = String.Format("UPDATE nhanvien SET matkhau = '{0}' WHERE manv = N'{1}'", mkmh, manv);
            int data = DataProvider.Instance.ExecuteNonQuery(query);
            return data > 0;
        }
        public bool InsertNhanVien(String manv, String tennv, String gt, DateTime ngaysinh, String diachi, String email, String sdt, String chucvu)
        {
            String mk = "123456";
            String mkmh = MaHoa.MD5Hash(mk);
            String query = String.Format("INSERT nhanvien(manv, tennv, gioitinh, ngaysinh, diachi, email, sdt, chucvu, matkhau) VALUES(N'{0}',N'{1}',N'{2}','{3}',N'{4}',N'{5}',N'{6}',N'{7}', '{8}')", manv, tennv, gt, ngaysinh, diachi, email, sdt, chucvu, mkmh);
            int data = DataProvider.Instance.ExecuteNonQuery(query);
            return data > 0;
        }
        public bool UpdateNhanVien(String manv, String tennv, String gt, DateTime ngaysinh, String diachi, String email, String sdt, String chucvu)
        {
            String query = String.Format("UPDATE nhanvien SET tennv = N'{0}', gioitinh = N'{1}', ngaysinh = '{2}', diachi = N'{3}', email = N'{4}', sdt = N'{5}', chucvu = N'{6}' WHERE manv = N'{7}'", tennv, gt, ngaysinh, diachi, email, sdt, chucvu, manv);
            int data = DataProvider.Instance.ExecuteNonQuery(query);
            return data > 0;
        }
        public bool DeleteNhanVien(String manv)
        {
            String query = String.Format("DELETE FROM nhanvien  WHERE manv = N'{0}'", manv);
            int data = DataProvider.Instance.ExecuteNonQuery(query);
            return data > 0;
        }
        public DataTable SearchnhanvienByName(String name)
        {
            String query = String.Format("SELECT manv AS [Mã nhân viên], tennv AS [Tên nhân viên], gioitinh AS[Giới tính], ngaysinh AS [Ngày sinh], diachi AS [Địa chỉ], email AS [Email], sdt AS [Số điện thoại], chucvu AS [Chức vụ] FROM nhanvien WHERE tennv like N'%{0}%'", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }
        public string GetNameById(String manv)
        {
            string data = (string)DataProvider.Instance.ExecuteScalar("SELECT tennv FROM nhanvien WHERE manv = '" + manv + "'");
            return data;
        }
        public int GetNhanVienByMa(String manv)
        {
            int data = (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*)tennv FROM nhanvien WHERE manv = '" + manv + "'");
            return data;

        }

    }
}

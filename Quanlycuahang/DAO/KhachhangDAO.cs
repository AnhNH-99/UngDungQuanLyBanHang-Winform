using Quanlycuahang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlycuahang.DAO
{
    public class KhachhangDAO
    {
        private static KhachhangDAO instance;

        public static KhachhangDAO Instance
        {
            get { if (instance == null) instance = new KhachhangDAO(); return instance; }
            set { instance = value; }
        }
        private KhachhangDAO() { }
        public DataTable LoadDanhSachKhachHang()
        {
            String query = "SELECT makh AS [Mã khách hàng], tenkh AS [Tên khách hàng], diachi AS [Địa chỉ], sdt AS [Số điện thoại] FROM khachhang";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public bool InsertKhachHang(String tenkh, String dc, String sdt)
        {
            String query = String.Format("INSERT INTO khachhang VALUES ( N'{0}',  N'{1}', '{2}')", tenkh, dc, sdt);
            int data = DataProvider.Instance.ExecuteNonQuery(query);
            return data > 0;
        }
        public bool UpdateKhachHang(String makh, String tenkh, String dc, String sdt)
        {
            String query = String.Format("UPDATE khachhang SET tenkh = N'{0}', diachi = N'{1}', sdt = N'{2}'  WHERE  makh='{3}'", tenkh, dc, sdt, makh);
            int data = DataProvider.Instance.ExecuteNonQuery(query);
            return data > 0;
        }
        public bool DeleteKhachHang(String makh)
        {
            String query = String.Format("DELETE FROM khachhang  WHERE  makh='{0}'", makh);
            int data = DataProvider.Instance.ExecuteNonQuery(query);
            return data > 0;
        }
        public List<Khachhang> Getkhachhang()
        {
            List<Khachhang> khachhang = new List<Khachhang>();
            String query = "SELECT * FROM khachhang";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                Khachhang list = new Khachhang(item);
                khachhang.Add(list);
            }
            return khachhang;
        }
        public string GetTenKhachhangByMaKhachhang(string makh)
        {
            List<Khachhang> khachhang = new List<Khachhang>();
            String query = String.Format("SELECT tenkh FROM khachhang WHERE makh = '{0}'",makh);
            String tenkh = (string)DataProvider.Instance.ExecuteScalar(query);
            return tenkh;
        }
        public string GetDiachiKhachhangByMaKhachhang(string makh)
        {
            List<Khachhang> khachhang = new List<Khachhang>();
            String query = String.Format("SELECT diachi FROM khachhang WHERE makh = '{0}'", makh);
            String diachi = (string)DataProvider.Instance.ExecuteScalar(query);
            return diachi;
        }
        public string GetSdtKhachhangByMaKhachhang(string makh)
        {
            List<Khachhang> khachhang = new List<Khachhang>();
            String query = String.Format("SELECT sdt FROM khachhang WHERE makh = '{0}'", makh);
            String sdt = (string)DataProvider.Instance.ExecuteScalar(query);
            return sdt;
        }
        public DataTable SearchKhachhangByName(String name)
        {
            String query = String.Format("SELECT makh AS [Mã khách hàng], tenkh AS [Tên khách hàng], diachi AS [Địa chỉ], sdt AS [Số điện thoại] FROM khachhang WHERE tenkh like N'%{0}%'", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }
        public int GetMaKhachHangBySDT(String sdt, String tenkh)
        {
            try
            {
                String query = String.Format("SELECT makh FROM khachhang WHERE sdt = '{0}' AND tenkh = N'{1}'", sdt, tenkh);
                int makh = (int)DataProvider.Instance.ExecuteScalar(query);
                return makh;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}

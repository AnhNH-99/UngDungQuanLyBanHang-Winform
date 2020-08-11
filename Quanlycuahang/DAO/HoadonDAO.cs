using Quanlycuahang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlycuahang.DAO
{
    public class HoadonDAO
    {
        private static HoadonDAO instance;

        public static HoadonDAO Instance
        {
            get { if (instance == null) instance = new HoadonDAO(); return instance; }
            set { instance = value; }
        }
        private HoadonDAO() { }
        public String CheckMaHoaDon(String mahd)
        {
            String query = String.Format("SELECT * FROM hoadonbanhang WHERE mahd = '{0}'", mahd);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            if(data.Rows.Count > 0)
            {
                Hoadon hoadon = new Hoadon(data.Rows[0]);
                return hoadon.Mahd;
            }
            return null;
        }
        public void InsertHoaDon(String mahd, String manv, int makh, DateTime ngaylap, decimal tongtien)
        {
            String query = String.Format("INSERT INTO hoadonbanhang VALUES( '{0}', '{1}', '{2}', '{3}', {4})", mahd, manv, makh, ngaylap, tongtien);
            DataProvider.Instance.ExecuteQuery(query);
        }
        public bool LapHoaHoaDon(String mahd, decimal tongtien)
        {
            String query = String.Format("UPDATE hoadonbanhang SET tongtien = {0} WHERE mahd = '{1}'", tongtien, mahd);
             int data = DataProvider.Instance.ExecuteNonQuery(query);
            return data > 0;
        }
        public bool DeleteHoadonByMaHoaDon(String mahd)
        {
            String query = String.Format("DELETE FROM hoadonbanhang WHERE mahd = '{0}'", mahd);
            int data = DataProvider.Instance.ExecuteNonQuery(query);
            return data > 0;
        }
        public DataTable LoadDanhSachHoaDon()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT mahd as [Mã hóa đơn], manv as [Mã nhân viên], makh as [Mã khách hàng], ngaylap as [Ngày lập], tongtien as [Tổng tiền] FROM hoadonbanhang");
        }
        public DataTable LoadBieuDo()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT mahd as [Mã hóa đơn]/*, manv as [Mã nhân viên], makh as [Mã khách hàng], ngaylap as [Ngày lập]*/, tongtien as [Tổng tiền] FROM hoadonbanhang");
        }
        public DataTable GetlistByDate(DateTime checkIn, DateTime checkOut)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC USP_GetListHoadonbanhangByDate @checkIn , @checkOut", new Object[] { checkIn, checkOut });
        }
        public decimal GetTongtien(DateTime checkIn, DateTime checkOut)
        {
            decimal tongtien = 0;
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_GetListHoadonbanhangByDate @checkIn , @checkOut", new Object[] { checkIn, checkOut });
            if (data.Rows.Count > 0)
            {
                tongtien = (decimal)DataProvider.Instance.ExecuteScalar("EXEC USP_GetTongTien @checkIn , @checkOut", new Object[] { checkIn, checkOut });
                return tongtien;
            }
            else
                tongtien = 0;
            return tongtien;
        }
        public decimal GetTongtienkdk()
        {
            decimal tongtien = 0;
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT mahd as [Mã hóa đơn], manv as [Mã nhân viên], makh as [Mã khách hàng], ngaylap as [Ngày lập], tongtien as [Tổng tiền] FROM hoadonbanhang");
            if (data.Rows.Count > 0)
                tongtien = (decimal) DataProvider.Instance.ExecuteScalar("SELECT SUM(tongtien) FROM hoadonbanhang");
            else
                tongtien = 0;
            return tongtien;
        }
        public List<Hoadon> GetListHoadon()
        {
            List<Hoadon> list = new List<Hoadon>();
            String query = "SELECT * FROM hoadonbanhang";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                Hoadon hoadon = new Hoadon(item);
                list.Add(hoadon);
            }
            return list;
        }
        
        public string GetMahoadon()
        {
            string query = "SELECT TOP(1) mahd FROM hoadonbanhang ORDER BY mahd DESC";
            string data = (string)DataProvider.Instance.ExecuteScalar(query);
            return data;
        }
        public int CheckMahoadon()
        {
            string query = "SELECT COUNT(*) FROM hoadonbanhang";
            int data = (int)DataProvider.Instance.ExecuteScalar(query);
            return data;
        }
        public DataTable Searchhoadonbymahoadon(String mahd)
        {
            String query = String.Format("SELECT mahd as [Mã hóa đơn], manv as [Mã nhân viên], makh as [Mã khách hàng], ngaylap as [Ngày lập], tongtien as [Tổng tiền] FROM hoadonbanhang WHERE mahd like '%{0}%'", mahd);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }
        public Hoadon GetHoadonByMa(String mahd)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM hoadonbanhang WHERE mahd = '" + mahd + "'");
            foreach (DataRow item in data.Rows)
            {
                return new Hoadon(item);
            }
            return null;
        }
        public DataTable InHoaDon(string mahd)
        {
            String query = String.Format("select * from viewhoadonbanhang Where mahd = '{0}'", mahd);
            //String query = "select * from hoadonbanhangview Where [Mã hóa đơn] = 'HDBH1'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }
        public DataTable ThongKeDoanhThuTheoNgay(int thang, int nam)
        {
            String query = String.Format("select DAY(ngaylap) as thang, SUM(tongtien) as doanhthu FROM hoadonbanhang WHERE MONTH(ngaylap) = {0} AND YEAR(ngaylap) = {1} GROUP BY ngaylap", thang, nam);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }
        public DataTable ThongKeDoanhThuTheoThang( int nam)
        {
            String query = String.Format("select MONTH(ngaylap) as thang, SUM(tongtien) as doanhthu FROM hoadonbanhang WHERE YEAR(ngaylap) = {0} GROUP BY ngaylap", nam);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }
        public DataTable ThongKeDoanhThuTheoNam()
        {
            String query = String.Format("select YEAR(ngaylap) as thang, SUM(tongtien) as doanhthu FROM hoadonbanhang GROUP BY ngaylap");
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }
        public int DonHangMoi(DateTime ngaylap)
        {
            String query = String.Format("SELECT COUNT(mahd) FROM hoadonbanhang WHERE ngaylap = '{0}'", ngaylap);
            int data = (int)DataProvider.Instance.ExecuteScalar(query);
            return data;
        }
        public DataTable DanhSachDonHangMoi(DateTime ngaylap)
        {
            String query = String.Format("select mahd as [Mã hóa đơn], manv as [Mã nhân viên], makh as [Mã khách hàng], ngaylap as [Ngày lập], tongtien as [Tổng tiền] from hoadonbanhang where  hoadonbanhang.ngaylap = '{0}'", ngaylap);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }
        public DataTable DanhSachHoaDonByMaKH(String makh)
        {
            String query = String.Format("select mahd as [Mã hóa đơn], manv as [Mã nhân viên], makh as [Mã khách hàng], ngaylap as [Ngày lập], tongtien as [Tổng tiền] from hoadonbanhang where  makh = '{0}'", makh);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }
        public DataTable InBaoCaoBanHang(DateTime checkIn, DateTime checkOut)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC USP_Inbaocaobanhang @checkIn , @checkOut", new Object[] { checkIn, checkOut });
        }
    }
}

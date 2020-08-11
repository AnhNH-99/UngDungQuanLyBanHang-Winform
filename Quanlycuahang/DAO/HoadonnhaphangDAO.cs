using Quanlycuahang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlycuahang.DAO
{
    public class HoadonnhaphangDAO
    {
        private static HoadonnhaphangDAO instance;

        public static HoadonnhaphangDAO Instance
        {
            get { if (instance == null) instance = new HoadonnhaphangDAO(); return instance; }
            set { instance = value; }
        }
        HoadonnhaphangDAO() { }
        public String CheckMaHoaDon(String mahd)
        {
            String query = String.Format("SELECT * FROM hoadonnhaphang WHERE mahd = '{0}'", mahd);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            if (data.Rows.Count > 0)
            {
                Hoadonnhaphang hoadon = new Hoadonnhaphang(data.Rows[0]);
                return hoadon.Mahd;
            }
            return null;
        }
        public void InsertHoaDon(String mahd, String manv, String mancc, DateTime ngaylap, decimal tongtien)
        {
            String query = String.Format("INSERT INTO hoadonnhaphang VALUES( '{0}', '{1}', '{2}', '{3}', {4})", mahd, manv, mancc, ngaylap, tongtien);
            DataProvider.Instance.ExecuteQuery(query);
        }
        public bool LapHoaHoaDon(String mahd, decimal tongtien)
        {
            String query = String.Format("UPDATE hoadonnhaphang SET  tongtien = {0} WHERE mahd = '{1}'", tongtien, mahd);
            int data = DataProvider.Instance.ExecuteNonQuery(query);
            return data > 0;
        }
        public bool DeleteHoadonByMaHoaDon(String mahd)
        {
            String query = String.Format("DELETE FROM hoadonnhaphang WHERE mahd = '{0}'", mahd);
            int data = DataProvider.Instance.ExecuteNonQuery(query);
            return data > 0;
        }
        public DataTable LoadDanhSachHoaDonNhapHang()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT mahd as [Mã hóa đơn], manv as [Mã nhân viên], mancc as [Mã nhà cung cấp], ngaylap as [Ngày lập], tongtien as [Tổng tiền] FROM hoadonnhaphang");
        }
        public DataTable GetlistByDateHoaDonNhapHang(DateTime checkIn, DateTime checkOut)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC USP_GetListHoadonnhaphangByDate @checkIn , @checkOut", new Object[] { checkIn, checkOut });
        }
        public decimal GetTongtienHoaDonNhapHang(DateTime checkIn, DateTime checkOut)
        {
            decimal tongtien = 0;
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_GetListHoadonnhaphangByDate @checkIn , @checkOut", new Object[] { checkIn, checkOut });
            if (data.Rows.Count > 0)
            {
                tongtien = (decimal)DataProvider.Instance.ExecuteScalar("EXEC USP_GetTongTienNhapHang @checkIn , @checkOut", new Object[] { checkIn, checkOut });
                return tongtien;
            }
            else
                tongtien = 0;
            return tongtien;
        }
        public decimal GetTongtienkdkHoaDonNhapHang()
        {
            decimal tongtien = 0;
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT mahd as [Mã hóa đơn], manv as [Mã nhân viên], mancc as [Mã nhà cung cấp], ngaylap as [Ngày lập], tongtien as [Tổng tiền] FROM hoadonnhaphang");
            if (data.Rows.Count > 0)
                tongtien = (decimal)DataProvider.Instance.ExecuteScalar("SELECT SUM(tongtien) FROM hoadonnhaphang");
            else
                tongtien = 0;
            return tongtien;
        }
        public string GetMahoadon()
        {
            string query = "SELECT TOP(1) mahd FROM hoadonnhaphang ORDER BY mahd DESC";
            string data = (string)DataProvider.Instance.ExecuteScalar(query);
            return data;
        }
        public int CheckMahoadon()
        {
            string query = "SELECT COUNT(*) FROM hoadonnhaphang";
            int data = (int)DataProvider.Instance.ExecuteScalar(query);
            return data;
        }
        public DataTable Searchhoadonbymahoadon(String mahd)
        {
            String query = String.Format("SELECT mahd as [Mã hóa đơn], manv as [Mã nhân viên], mancc as [Mã nhà cung cấp], ngaylap as [Ngày lập], tongtien as [Tổng tiền] FROM hoadonnhaphang WHERE mahd like '%{0}%'", mahd);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }
        public Hoadonnhaphang GetHoadonByMa(String mahd)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM hoadonnhaphang WHERE mahd = '" + mahd + "'");
            foreach (DataRow item in data.Rows)
            {
                return new Hoadonnhaphang(item);
            }
            return null;
        }
        public DataTable InHoaDon(string mahd)
        {
            String query = String.Format("select * from viewhoadonnhaphang Where mahd = '{0}'", mahd);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }
        public DataTable InBaoCaoThongKeNhapHang(DateTime checkIn, DateTime checkOut)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC USP_Inbaocaonhaphang @checkIn , @checkOut", new Object[] { checkIn, checkOut });
        }
        public DataTable LoadDanhSachHoaDonNhapHangByMaNCC(string mancc)
        {
            return DataProvider.Instance.ExecuteQuery("SELECT mahd as [Mã hóa đơn], manv as [Mã nhân viên], mancc as [Mã nhà cung cấp], ngaylap as [Ngày lập], tongtien as [Tổng tiền] FROM hoadonnhaphang WHERE mancc = '"+mancc+"'");
        }
    }
}

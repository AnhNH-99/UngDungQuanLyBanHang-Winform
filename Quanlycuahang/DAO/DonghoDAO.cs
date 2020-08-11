using Quanlycuahang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlycuahang.DAO
{
    public class DonghoDAO
    {
        private static DonghoDAO instance;

        public static DonghoDAO Instance
        {
            get { if (instance == null) instance = new DonghoDAO(); return instance; }
            set { instance = value; }
        }
        private DonghoDAO() { }
        public DataTable LoadDanhSachDongHo()
        {
            String query = "SELECT madh AS [Mã đồng hồ], tendh AS [Tên đồng hồ], kieudang AS [Kiểu dáng], thuonghieu AS [Thương hiệu], namsanxuat AS [Năm sản xuất], mancc AS [Nhà cung cấp], gianhap AS [Giá nhập], soluong AS [Số lượng], giaban AS [Giá bán], baohanh AS [Bảo hành] FROM dongho";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public String GetTenDongHo(String madh)
        {
            String query = String.Format("SELECT tenncc FROM nhacungcap WHERE mancc = '{0}'", madh);
            String data = (String)DataProvider.Instance.ExecuteScalar(query);
            return data;
        }
        public String GetTenDongHoByMahoadon(String madh)
        {
            String query = String.Format("SELECT tendh FROM dongho WHERE madh = '{0}'", madh);
            String data = (String)DataProvider.Instance.ExecuteScalar(query);
            return data;
        }
        public bool InsertDongHo(String madh, String tendh, String kieudang, String thuonghieu, int namsanxuat, String nhacungcap, decimal gianhap, int soluong, decimal giaban, int baohanh)
        {
            String query = String.Format("INSERT INTO dongho VALUES('{0}', N'{1}', N'{2}', N'{3}', {4}, '{5}', {6}, {7}, {8}, {9})", madh, tendh, kieudang, thuonghieu, namsanxuat, nhacungcap, gianhap, soluong, giaban, baohanh);
            int data = DataProvider.Instance.ExecuteNonQuery(query);
            return data > 0;
        }
        public bool UpdateDongHo(String madh, String tendh, String kieudang, String thuonghieu, int namsanxuat, String nhacungcap, decimal gianhap, int soluong, decimal giaban, int baohanh)
        {
            String query = String.Format("UPDATE dongho SET tendh = N'{0}', kieudang = N'{1}', thuonghieu = N'{2}', namsanxuat = {3}, mancc = '{4}', gianhap = {5}, soluong = {6}, giaban = {7}, baohanh = {8} WHERE madh = '{9}'", tendh, kieudang, thuonghieu, namsanxuat, nhacungcap, gianhap, soluong, giaban, baohanh, madh);
            int data = DataProvider.Instance.ExecuteNonQuery(query);
            return data > 0;
        }
        public bool DeleteDongHo(String madh)
        {
            String query = String.Format("DELETE FROM dongho WHERE madh = '{0}'", madh);
            int data = DataProvider.Instance.ExecuteNonQuery(query);
            return data > 0;
        }
        public List<Dongho> GetDongho(string mancc)
        {
            List<Dongho> list = new List<Dongho>();
            String query = String.Format("SELECT * FROM dongho WHERE mancc = '{0}'", mancc);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                Dongho dongho = new Dongho(item);
                list.Add(dongho);
            }
            return list;
        }
       
        public List<Dongho> GetDongho()
        {
            List<Dongho> list = new List<Dongho>();
            String query = "SELECT * FROM dongho";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Dongho dongho = new Dongho(item);
                list.Add(dongho);
            }
            return list;
        }
        public int CheckBaoHanh(string mahd, string madh)
        {
            String qurey = "EXEC USP_Baohanh @mahd , @madh";
            int ck = (int)DataProvider.Instance.ExecuteScalar(qurey, new Object[] { mahd, madh });
            return ck;
        }
        public DataTable SearchDonghoByName(String name)
        {
            String query = String.Format("SELECT madh AS [Mã đồng hồ], tendh AS [Tên đồng hồ], kieudang AS [Kiểu dáng], thuonghieu AS [Thương hiệu], namsanxuat AS [Năm sản xuất], mancc AS [Nhà cung cấp], gianhap AS [Giá nhập], soluong AS [Số lượng], giaban AS [Giá bán], baohanh AS [Bảo hành] FROM dongho WHERE tendh like N'%{0}%'", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }

        public void UpdateSoLuongDongHoBanHang(String madh, int soluong)
        {
            String query = String.Format("UPDATE dongho SET soluong -= {0} WHERE madh = '{1}'", soluong, madh);
            DataProvider.Instance.ExecuteQuery(query);
        }
        public void UpdateSoLuongDongHoNhapHang(String madh, int soluong)
        {
            String query = String.Format("UPDATE dongho SET soluong += {0} WHERE madh = '{1}'", soluong, madh);
            DataProvider.Instance.ExecuteQuery(query);
        }
        public int DongHoSapHetHang()
        {
            String query = "SELECT COUNT(madh) FROM dongho WHERE soluong <= 2";
            int data = (int)DataProvider.Instance.ExecuteScalar(query);
            return data;
        }
        public DataTable DanhSachDongHoSapHetHang()
        {
            String query = "SELECT madh AS [Mã đồng hồ], tendh AS [Tên đồng hồ], kieudang AS [Kiểu dáng], thuonghieu AS [Thương hiệu], namsanxuat AS [Năm sản xuất], mancc AS [Nhà cung cấp], gianhap AS [Giá nhập], soluong AS [Số lượng], giaban AS [Giá bán], baohanh AS [Bảo hành] FROM dongho WHERE soluong <= 2";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }
        public int GetDongHoByMa(string madh)
        {
            String query = "SELECT COUNT(*) FROM dongho WHERE madh = '"+madh+"'";
            int dh = (int)DataProvider.Instance.ExecuteScalar(query);
            return dh;
        }
    }
}

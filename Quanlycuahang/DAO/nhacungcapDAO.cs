using Quanlycuahang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlycuahang.DAO
{
    public class nhacungcapDAO
    {
        private static nhacungcapDAO instance;

        public static nhacungcapDAO Instance
        {
            get { if (instance == null) instance = new nhacungcapDAO(); return instance; }
            set { instance = value; }
        }
        nhacungcapDAO() { }
        public DataTable LoadDanhSachNhaCungCap()
        {
            String query = "SELECT mancc AS [Mã nhà cung cấp], tenncc AS [Tên nhà cung cấp], diachi AS [Địa chỉ], email AS [Email], sdt AS [Số điện thoại] FROM nhacungcap";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public bool InsertNhaCungCap(String mancc, String tenncc, String diachi, String email, String sdt)
        {
            String query = String.Format("INSERT INTO nhacungcap VALUES('{0}', N'{1}', N'{2}', N'{3}', '{4}')", mancc, tenncc, diachi, email, sdt);
            int data = DataProvider.Instance.ExecuteNonQuery(query);
            return data > 0;
        }
        public bool UpdateNhaCungCap(String mancc, String tenncc, String diachi, String email, String sdt)
        {
            String query = String.Format("UPDATE nhacungcap SET  tenncc = N'{0}', diachi = N'{1}', email = N'{2}', sdt = '{3}' WHERE mancc = '{4}'", tenncc, diachi, email, sdt, mancc);
            int data = DataProvider.Instance.ExecuteNonQuery(query);
            return data > 0;
        }
        public bool DeleteNhaCungCap(String mancc)
        {
            String query = String.Format("DELETE FROM nhacungcap WHERE mancc = '{0}'", mancc);
            int data = DataProvider.Instance.ExecuteNonQuery(query);
            return data > 0;
        }
        public List<nhacungcap> GetListNhaCungCap()
        {
            List<nhacungcap> list = new List<nhacungcap>();
            String query = "SELECT * FROM nhacungcap";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                nhacungcap lnhacungcap = new nhacungcap(item);
                list.Add(lnhacungcap);
            }
            return list;
        }
        public string GetTenNhacungcapByMaNhacungcap(string mancc)
        {
            String query = String.Format("SELECT tenncc FROM nhacungcap WHERE mancc = '{0}'", mancc);
            String tenkh = (string)DataProvider.Instance.ExecuteScalar(query);
            return tenkh;
        }
        public string GetDiachiNhacungcapByNhacungcap(string mancc)
        {
            String query = String.Format("SELECT diachi FROM nhacungcap WHERE mancc = '{0}'", mancc);
            String diachi = (string)DataProvider.Instance.ExecuteScalar(query);
            return diachi;
        }
        public string GetSdtNhacungcapByNhacungcap(string mancc)
        {
            String query = String.Format("SELECT sdt FROM nhacungcap WHERE mancc = '{0}'", mancc);
            String sdt = (string)DataProvider.Instance.ExecuteScalar(query);
            return sdt;
        }
        public DataTable SearchNhacungcapByName(String name)
        {
            String query = String.Format("SELECT mancc AS [Mã nhà cung cấp], tenncc AS [Tên nhà cung cấp], diachi AS [Địa chỉ], email AS [Email], sdt AS [Số điện thoại] FROM nhacungcap WHERE tenncc like N'%{0}%'", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }
        public int GetNhaCungCapByMa(string mancc)
        {
            String query = String.Format("SELECT COUNT(*) FROM nhacungcap WHERE mancc = '{0}'", mancc);
            int data = (int)DataProvider.Instance.ExecuteScalar(query);
            return data;
        }
    }
}

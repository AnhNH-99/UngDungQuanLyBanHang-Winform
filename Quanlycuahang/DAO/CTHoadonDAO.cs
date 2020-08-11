using Quanlycuahang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlycuahang.DAO
{
    public class CTHoadonDAO
    {
        private static CTHoadonDAO instance;

        public static CTHoadonDAO Instance
        {
            get { if (instance == null) instance = new CTHoadonDAO(); return instance; }
            set { instance = value; }
        }
        private CTHoadonDAO() { }
        public List<CTHoadon> LoaddanhsachCTHoadon(String mahd)
        {
            List<CTHoadon> listMenu = new List<CTHoadon>();
            String query = "SELECT madh , giaban , soluong , (giaban * soluong) AS totalPrice FROM chitiethoadonbanhang WHERE mahd = '" + mahd+"'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                CTHoadon menu = new CTHoadon(item);
                listMenu.Add(menu);
            }
            return listMenu;
        }

        public void InsertCTHoadon( String mahd, String madh, decimal giaban, int soluong)
        {
            String query = String.Format("INSERT INTO chitiethoadonbanhang VALUES ( '{0}', '{1}', {2}, {3})", mahd, madh, giaban, soluong);
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void UpdateCTHoadon(String mahd, String madh, int soluong)
        {
            String query = String.Format("UPDATE chitiethoadonbanhang SET soluong += {0} WHERE madh = '{1}' AND mahd = '{2}'", soluong, madh, mahd);
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void DeleteCTHoadonByMaHoaDon(String mahd)
        {
            String query = String.Format("DELETE FROM chitiethoadonbanhang WHERE mahd = '{0}'", mahd);
            DataProvider.Instance.ExecuteQuery(query);
        }
        public String CheckMaHoaDon(String mahd, String madh)
        {
            String query = String.Format("SELECT * FROM chitiethoadonbanhang WHERE madh = '{0}' AND mahd = '{1}'", mahd, madh);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            if (data.Rows.Count > 0)
            {
                CTHoadon hoadon = new CTHoadon(data.Rows[0]);
                return hoadon.Madh;
            }
            return null;
        }
        public List<CTHoadon> GetMaDonghoByMaHoadon(String mahd)
        {
            List<CTHoadon> list = new List<CTHoadon>();
            String query = String.Format("SELECT * FROM chitiethoadonbanhang WHERE mahd = '{0}'", mahd);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                CTHoadon cthoadon = new CTHoadon(item);
                list.Add(cthoadon);
            }
            return list;
        }
        public DataTable ThongKeDongHoBanChay(int? nam, int? thang)
        {
            String query = null;
            if (thang == null)
            {
                query = String.Format("select madh, SUM(soluong) as soluong FROM hoadonbanhang, chitiethoadonbanhang WHERE YEAR(ngaylap) = {0} GROUP BY madh", nam);
            }
            else
            {
                query = String.Format("select madh, SUM(soluong) as soluong FROM hoadonbanhang, chitiethoadonbanhang WHERE YEAR(ngaylap) = {0} AND MONTH(ngaylap) = {1} GROUP BY madh", nam, thang);
            }
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }
    }
}

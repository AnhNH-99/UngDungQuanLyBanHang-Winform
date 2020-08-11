using Quanlycuahang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlycuahang.DAO
{
    public class CTHoadonnhaphangDAO
    {
        private static CTHoadonnhaphangDAO instance;

        public static CTHoadonnhaphangDAO Instance
        {
            get { if (instance == null) instance = new CTHoadonnhaphangDAO(); return instance; }
            set { instance = value; }
        }
        private CTHoadonnhaphangDAO() { }
        public List<CTHoadonnhaphang> LoaddanhsachCTHoadon(String mahd)
        {
            List<CTHoadonnhaphang> listMenu = new List<CTHoadonnhaphang>();
            String query = "SELECT madh , giaban , soluong , (giaban * soluong) AS totalPrice FROM chitiethoadonnhaphang WHERE mahd = '" + mahd + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                CTHoadonnhaphang menu = new CTHoadonnhaphang(item);
                listMenu.Add(menu);
            }
            return listMenu;
        }

        public void InsertCTHoadon(String mahd, String madh, decimal giaban, int soluong)
        {
            String query = String.Format("INSERT INTO chitiethoadonnhaphang VALUES ( '{0}', '{1}', {2}, {3})", mahd, madh, giaban, soluong);
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void UpdateCTHoadon(String mahd, String madh, int soluong)
        {
            String query = String.Format("UPDATE chitiethoadonnhaphang SET soluong += {0} WHERE madh = '{1}' AND mahd = '{2}'", soluong, madh, mahd);
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void DeleteCTHoadonByMaHoaDon(String mahd)
        {
            String query = String.Format("DELETE FROM chitiethoadonnhaphang WHERE mahd = '{0}'", mahd);
            DataProvider.Instance.ExecuteQuery(query);
        }
        public String CheckMaHoaDon(String mahd, String madh)
        {
            String query = String.Format("SELECT * FROM chitiethoadonnhaphang WHERE madh = '{0}' AND mahd = '{1}'", madh, mahd);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            if (data.Rows.Count > 0)
            {
                CTHoadonnhaphang hoadon = new CTHoadonnhaphang(data.Rows[0]);
                return hoadon.Madh;
            }
            return null;
        }
    }
}

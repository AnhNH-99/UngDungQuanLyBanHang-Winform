using Quanlycuahang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlycuahang.DAO
{
    public class MenunhaphangDAO
    {
        private static MenunhaphangDAO instance;

        public static MenunhaphangDAO Instance
        {
            get { if (instance == null) instance = new MenunhaphangDAO(); return instance; }
            set { instance = value; }
        }
        private MenunhaphangDAO() { }
        public List<Menunhaphang> LoadDanhSachHoadon(String mahd)
        {
            List<Menunhaphang> listMenu = new List<Menunhaphang>();
            String query = "SELECT c.madh , d.tendh, d.gianhap , c.soluong , (c.gianhap * c.soluong) AS thanhtien FROM chitiethoadonnhaphang as c, dongho as d WHERE c.madh = d.madh AND mahd = '" + mahd + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Menunhaphang menu = new Menunhaphang(item);
                listMenu.Add(menu);
            }
            return listMenu;
        }
    }
}

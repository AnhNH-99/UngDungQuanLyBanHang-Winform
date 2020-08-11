using Quanlycuahang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlycuahang.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return instance; }
            set { instance = value; }
        }
        private MenuDAO() { }
        public List<Menu> LoadDanhSachHoadon(String mahd)
        {
            List<Menu> listMenu = new List<Menu>();
            String query = "SELECT c.madh , d.tendh, d.giaban , c.soluong , (c.giaban * c.soluong) AS thanhtien FROM chitiethoadonbanhang as c, dongho as d WHERE c.madh = d.madh AND mahd = '" + mahd + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listMenu.Add(menu);
            }
            return listMenu;
        }
    }
}

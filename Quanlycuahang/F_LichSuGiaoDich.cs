using Quanlycuahang.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlycuahang
{
    public partial class F_LichSuGiaoDich : Form
    {
        public F_LichSuGiaoDich()
        {
            InitializeComponent();
            LoadDanhSachKhachHang();
        }
        void LoadDanhSachKhachHang()
        {
            dtgvlichsugiaodich.DataSource = KhachhangDAO.Instance.LoadDanhSachKhachHang();
        }

        private void dtgvlichsugiaodich_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            String makh = dtgvlichsugiaodich.CurrentRow.Cells[0].Value.ToString();
            F_Chitietgiaodich fctlsgd = new F_Chitietgiaodich(makh);
            this.Hide();
            fctlsgd.ShowDialog();
            this.Show();
        }
    }
}

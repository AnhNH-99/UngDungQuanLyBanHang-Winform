using Quanlycuahang.DAO;
using Quanlycuahang.DTO;
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
    public partial class F_Chitietgiaodich : Form
    {
        private String makh;
        public F_Chitietgiaodich(String makh)
        {
            InitializeComponent();
            this.makh = makh;
            dtgvdshdbh.DataSource = HoadonDAO.Instance.DanhSachHoaDonByMaKH(makh);
            txbcthdmakh.Text = makh;
            txbcthdtenkh.Text = KhachhangDAO.Instance.GetTenKhachhangByMaKhachhang(txbcthdmakh.Text);
            txbcthddiachi.Text = KhachhangDAO.Instance.GetDiachiKhachhangByMaKhachhang(txbcthdmakh.Text);
            txbcthdsdt.Text = KhachhangDAO.Instance.GetSdtKhachhangByMaKhachhang(txbcthdmakh.Text);
        }
        void ShowBillCTHD(String id)
        {
            listView1.Items.Clear();
            List<DTO.Menu> listbillInfors = MenuDAO.Instance.LoadDanhSachHoadon(id);
            foreach (DTO.Menu item in listbillInfors)
            {
                ListViewItem lsvItem = new ListViewItem(item.Madh.ToString());
                lsvItem.SubItems.Add(item.Tendh.ToString());
                lsvItem.SubItems.Add(item.Dongia.ToString());
                lsvItem.SubItems.Add(item.Soluong.ToString());
                lsvItem.SubItems.Add(item.Thanhtien.ToString());
                listView1.Items.Add(lsvItem);
            }

        }

        private void dtgvdshdbh_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txbmacthd.Text = dtgvdshdbh.CurrentRow.Cells[0].Value.ToString();
            txbcthdmnv.Text = dtgvdshdbh.CurrentRow.Cells[1].Value.ToString();
            txbcthdtennv.Text = NhanvienDAO.Instance.GetNameById(txbcthdmnv.Text);
            txbngaylap.Text = dtgvdshdbh.CurrentRow.Cells[3].Value.ToString();
            ShowBillCTHD(txbmacthd.Text);
            txbcthdtt.Text = dtgvdshdbh.CurrentRow.Cells[4].Value.ToString();
        }
    }
}

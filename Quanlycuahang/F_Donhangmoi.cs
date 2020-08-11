using DevExpress.XtraEditors.Filtering.Templates;
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
    public partial class F_Donhangmoi : Form
    {
        public F_Donhangmoi()
        {
            InitializeComponent();
            LoadDanhSachDonHangMoi();
        }
        void LoadDanhSachDonHangMoi()
        {
            DateTime ngaylap = DateTime.Now;
            dtgvdsdhm.DataSource = HoadonDAO.Instance.DanhSachDonHangMoi(ngaylap);
        }
        //void LoadDuLieu(Hoadon hoadon)
        //{
        //    txbmahd.Text = hoadon.Mahd;
        //    txbmanv.Text = hoadon.Manv;
        //    txbmakh.Text = hoadon.Makh;
        //    txbngaylap.Text = Convert.ToString(hoadon.Ngaylap);
        //    txbtnv.Text = NhanvienDAO.Instance.GetNameById(txbmanv.Text);
        //    txbtenkh.Text = KhachhangDAO.Instance.GetTenKhachhangByMaKhachhang(txbmakh.Text);
        //    txbdiachi.Text = KhachhangDAO.Instance.GetDiachiKhachhangByMaKhachhang(txbmakh.Text);
        //    txbsdt.Text = KhachhangDAO.Instance.GetSdtKhachhangByMaKhachhang(txbmakh.Text);
        //    ShowBill(txbmahd.Text);
        //}
        void ShowBill(String id)
        {
            lsvBill.Items.Clear();
            List<DTO.Menu> listbillInfors = MenuDAO.Instance.LoadDanhSachHoadon(id);
            //   float totalPrice = 0;
            foreach (DTO.Menu item in listbillInfors)
            {
                ListViewItem lsvItem = new ListViewItem(item.Madh.ToString());
                lsvItem.SubItems.Add(item.Tendh.ToString());
                lsvItem.SubItems.Add(item.Dongia.ToString());
                lsvItem.SubItems.Add(item.Soluong.ToString());
                lsvItem.SubItems.Add(item.Thanhtien.ToString());
                //   totalPrice += item.Thanhtien;
                lsvBill.Items.Add(lsvItem);
            }
            //CultureInfo culture = new CultureInfo("vi-VN");
            //Thread.CurrentThread.CurrentCulture = culture;
            //txbtotalPrice.Text = totalPrice.ToString("c", culture);
            // txbtotalPrice.Text = totalPrice.ToString();

        }

        private void dtgvdsdhm_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txbmahd.Text = dtgvdsdhm.CurrentRow.Cells[0].Value.ToString();
            txbmanv.Text = dtgvdsdhm.CurrentRow.Cells[1].Value.ToString();
            txbmakh.Text = dtgvdsdhm.CurrentRow.Cells[2].Value.ToString();
            txbtnv.Text = NhanvienDAO.Instance.GetNameById(txbmanv.Text);
            txbngaylap.Text = dtgvdsdhm.CurrentRow.Cells[3].Value.ToString();
            txbtenkh.Text = KhachhangDAO.Instance.GetTenKhachhangByMaKhachhang(txbmakh.Text);
            txbtenkh.Text = KhachhangDAO.Instance.GetTenKhachhangByMaKhachhang(txbmakh.Text);
            txbdiachi.Text = KhachhangDAO.Instance.GetDiachiKhachhangByMaKhachhang(txbmakh.Text);
            txbsdt.Text = KhachhangDAO.Instance.GetSdtKhachhangByMaKhachhang(txbmakh.Text);
            ShowBill(txbmahd.Text);
            txbtongtien.Text = dtgvdsdhm.CurrentRow.Cells[4].Value.ToString();
        }
    }
}

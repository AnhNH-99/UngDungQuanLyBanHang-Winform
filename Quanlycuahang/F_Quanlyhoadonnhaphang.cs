using DevExpress.XtraReports.UI;
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
    public partial class F_Quanlyhoadonnhaphang : Form
    {
        private Nhanvien nhanvien;

        public Nhanvien Nhanvien
        {
            get { return nhanvien; }
            set { nhanvien = value; }
        }
        public F_Quanlyhoadonnhaphang(Nhanvien nv)
        {
            InitializeComponent();
            this.nhanvien = nv;
            LoadNhanVien();
        }
        void LoadDuLieu()
        {
            LoadDanhSachNhaCungCap();
            Clear();
        }
        void LoadNhanVien()
        {
            txbmanv.Text = nhanvien.Manv;
            txbtnv.Text = nhanvien.Tennv;
        }
        void LoadDanhSachMaDongHo(string mancc)
        {
            
            cbmdh.DataSource = DonghoDAO.Instance.GetDongho(mancc);
            cbmdh.DisplayMember = "madh";
        }
        void LoadDanhSachNhaCungCap()
        {
            cbmncc.DataSource = nhacungcapDAO.Instance.GetListNhaCungCap();
            cbmncc.DisplayMember = "mancc";
        }
        void Thanhtien(NumericUpDown nm)
        {
            int soluong = (int)nm.Value;
            decimal dongia = decimal.Parse(txbdongia.Text);
            decimal thanhtien = dongia * soluong;
            txbthanhtien.Text = Convert.ToString(thanhtien);
        }
        void ShowBill(String id)
        {
            lsvBill1.Items.Clear();
            List<DTO.Menunhaphang> listbillInfors = MenunhaphangDAO.Instance.LoadDanhSachHoadon(id);
            foreach (DTO.Menunhaphang item in listbillInfors)
            {
                ListViewItem lsvItem = new ListViewItem(item.Madh.ToString());
                lsvItem.SubItems.Add(item.Tendh.ToString());
                lsvItem.SubItems.Add(item.Dongia.ToString());
                lsvItem.SubItems.Add(item.Soluong.ToString());
                lsvItem.SubItems.Add(item.Thanhtien.ToString());
                lsvBill1.Items.Add(lsvItem);
            }
            //CultureInfo culture = new CultureInfo("vi-VN");
            //Thread.CurrentThread.CurrentCulture = culture;
            //txbtotalPrice.Text = totalPrice.ToString("c", culture);
            // txbtotalPrice.Text = totalPrice.ToString();
        }
        void LapHoaDon(String mahd, decimal tongtien)
        {
            if (HoadonnhaphangDAO.Instance.LapHoaHoaDon(mahd, tongtien))
            {
                MessageBox.Show("Lập hóa đơn thành công", "Thông báo");
            }
            else
                MessageBox.Show("Có lỗi khi lập hóa đơn", "Thông báo");
        }

        void HuyHoaDon(String mahd)
        {
            CTHoadonnhaphangDAO.Instance.DeleteCTHoadonByMaHoaDon(mahd);
            if (HoadonnhaphangDAO.Instance.DeleteHoadonByMaHoaDon(mahd))
            {
                MessageBox.Show("Hủy hóa đơn thành công", "Thông báo");
            }
            else
                MessageBox.Show("Có lỗi khi hủy hóa đơn", "Thông báo");
        }
        string Mahoadon()
        {
            string mahdm;
            if (HoadonnhaphangDAO.Instance.CheckMahoadon() > 0)
            {
                string mahdc = HoadonnhaphangDAO.Instance.GetMahoadon();
                string x = mahdc.Remove(0, mahdc.LastIndexOf("H") + 1);
                x = x.Trim();
                string y = x.Remove(0, x.Length - 1);
                if (y == "9")
                {
                    x += "0";
                }
                int thutu = Convert.ToInt32(x);
                if (Convert.ToInt32(y) < 9)
                {
                    thutu++;
                }
                mahdm = string.Format("HDNH{0}", thutu);
            }
            else
            {
                mahdm = "HDNH0";
            }
            return mahdm;
        }
        void Clear()
        {
            cbmncc.Text = "";
            txbtenncc.Text = "";
            txbdiachi.Text = "";
            txbsdt.Text = "";
            cbmdh.Text = "";
            txbtendh.Text = "";
            txbdongia.Text = "0";
            nmsoluong.Value = 1;
            txbthanhtien.Text = "0";
            txbtongtien.Text = "0";
            txbmahd.Text = Mahoadon();
            bntthemdh.Enabled = false;
            bntlaphoadon.Enabled = false;
            bnthuyhoadon.Enabled = false;
            cbmdh.Enabled = false;
        }

        void Loaddanhsachhoadonbanhang()
        {
            dtgvdshdnh.DataSource = HoadonnhaphangDAO.Instance.LoadDanhSachHoaDonNhapHang();
        }

        void Capnhatsoluongdongho(String id)
        {
            List<DTO.Menunhaphang> listbillInfors = MenunhaphangDAO.Instance.LoadDanhSachHoadon(id);
            foreach (DTO.Menunhaphang item in listbillInfors)
            {
                string madh = item.Madh.ToString();
                int soluong = Convert.ToInt32(item.Soluong.ToString());
                DonghoDAO.Instance.UpdateSoLuongDongHoNhapHang(madh, soluong);
            }
        }
        

        private void Cbmdh_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            txbtendh.Text = (cbmdh.SelectedItem as Dongho).Tendh;
            decimal dg = (cbmdh.SelectedItem as Dongho).Gianhap;
            txbdongia.Text = Convert.ToString(dg);
            Thanhtien(nmsoluong);
            bntthemdh.Enabled = true;
        }

        private void Cbmncc_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbtenncc.Text = (cbmncc.SelectedItem as nhacungcap).Tencc;
            txbdiachi.Text = (cbmncc.SelectedItem as nhacungcap).Dc;
            txbsdt.Text = (cbmncc.SelectedItem as nhacungcap).Sdt;
            string mancc = cbmncc.Text;
            LoadDanhSachMaDongHo(mancc);
            cbmdh.Enabled = true;
        }

        private void Nmsoluong_ValueChanged(object sender, EventArgs e)
        {
            Thanhtien(nmsoluong);
        }
        decimal tongtien = 0;
        private void Bntthemdh_Click(object sender, EventArgs e)
        {
            String mahd = txbmahd.Text;
            String checkma = HoadonnhaphangDAO.Instance.CheckMaHoaDon(mahd);
            String manv = txbmanv.Text;
            String mancc = cbmncc.Text;
            DateTime ngaylap = dtpgngaylap.Value;
            String madh = cbmdh.Text;
            decimal giaban = decimal.Parse(txbdongia.Text);
            int soluong = Convert.ToInt32(nmsoluong.Value);
            String checkmaDH = CTHoadonnhaphangDAO.Instance.CheckMaHoaDon(mahd, madh);
            if (checkma == null)
            {
                tongtien = 0;
                HoadonnhaphangDAO.Instance.InsertHoaDon(mahd, manv, mancc, ngaylap, 0);
                if (checkmaDH == null)
                    CTHoadonnhaphangDAO.Instance.InsertCTHoadon(mahd, madh, giaban, soluong);
                else
                    CTHoadonnhaphangDAO.Instance.UpdateCTHoadon(mahd, madh, soluong);
            }
            else
            {
                if (checkmaDH == null)
                    CTHoadonnhaphangDAO.Instance.InsertCTHoadon(mahd, madh, giaban, soluong);
                else
                    CTHoadonnhaphangDAO.Instance.UpdateCTHoadon(mahd, madh, soluong);
            }
            tongtien += decimal.Parse(txbthanhtien.Text);
            txbtongtien.Text = Convert.ToString(tongtien);
            ShowBill(mahd);
            bntlaphoadon.Enabled = true;
            bnthuyhoadon.Enabled = true;
            cbmncc.Enabled = false;
        }

        private void Bntlaphoadon_Click(object sender, EventArgs e)
        {
            String mahd = txbmahd.Text;
            decimal tongtien = decimal.Parse(txbtongtien.Text);
            if (MessageBox.Show("Bạn có muốn lập hóa đơn", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                LapHoaDon(mahd, tongtien);
                Clear();
                lsvBill1.Items.Clear();
                cbmncc.Enabled = true;
                dtgvdshdnh.DataSource = HoadonnhaphangDAO.Instance.Searchhoadonbymahoadon(txbtimkiem.Text);
                Capnhatsoluongdongho(mahd);
                DataTable dt = HoadonnhaphangDAO.Instance.InHoaDon(mahd);
                if (MessageBox.Show("Bạn có muốn in hóa đơn?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    ReportHoaDonNhapHang hdbh = new ReportHoaDonNhapHang();
                    hdbh.DataSource = dt;
                    hdbh.ShowPreviewDialog();
                }
            }
            
        }

        private void Bnthuyhoadon_Click(object sender, EventArgs e)
        {
            String mahd = txbmahd.Text;
            if (MessageBox.Show("Bạn có muốn hủy hóa đơn", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                HuyHoaDon(mahd);
                Clear();
                ShowBill(mahd);
                cbmncc.Enabled = true;
                dtgvdshdnh.DataSource = HoadonnhaphangDAO.Instance.Searchhoadonbymahoadon(txbtimkiem.Text);
                
            }
        }

        private void F_Quanlyhoadonnhaphang_Load(object sender, EventArgs e)
        {
            LoadDuLieu();
            Loaddanhsachhoadonbanhang();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            dtgvdshdnh.DataSource = HoadonnhaphangDAO.Instance.Searchhoadonbymahoadon(txbtimkiem.Text);
        }
        void ShowBillCTHD(String id)
        {
            lsvBill.Items.Clear();
            List<DTO.Menunhaphang> listbillInfors = MenunhaphangDAO.Instance.LoadDanhSachHoadon(id);
            foreach (DTO.Menunhaphang item in listbillInfors)
            {
                ListViewItem lsvItem = new ListViewItem(item.Madh.ToString());
                double x = Convert.ToDouble(item.Thanhtien);
                lsvItem.SubItems.Add(item.Tendh.ToString());
                lsvItem.SubItems.Add(item.Dongia.ToString());
                lsvItem.SubItems.Add(item.Soluong.ToString());
                lsvItem.SubItems.Add(x.ToString());
                lsvBill.Items.Add(lsvItem);
            }
            //CultureInfo culture = new CultureInfo("vi-VN");
            //Thread.CurrentThread.CurrentCulture = culture;
            //txbtotalPrice.Text = totalPrice.ToString("c", culture);
            // txbtotalPrice.Text = totalPrice.ToString();

        }
        private void dtgvdshdnh_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txbctmahd.Text = dtgvdshdnh.CurrentRow.Cells[0].Value.ToString();
            txbctmanv.Text = dtgvdshdnh.CurrentRow.Cells[1].Value.ToString();
            txbctmancc.Text = dtgvdshdnh.CurrentRow.Cells[2].Value.ToString();
            txbcttennv.Text = NhanvienDAO.Instance.GetNameById(txbctmanv.Text);
            txbctngaylap.Text = dtgvdshdnh.CurrentRow.Cells[3].Value.ToString();
            txbcttenncc.Text = nhacungcapDAO.Instance.GetTenNhacungcapByMaNhacungcap(txbctmancc.Text);
            // txbtenkh.Text = KhachhangDAO.Instance.GetTenKhachhangByMaKhachhang(txbmakh.Text);
            txbctdiachi.Text = nhacungcapDAO.Instance.GetDiachiNhacungcapByNhacungcap(txbctmancc.Text);
            txbctsdt.Text = nhacungcapDAO.Instance.GetSdtNhacungcapByNhacungcap(txbctmancc.Text);
            ShowBillCTHD(txbctmahd.Text);
            txbcttongtien.Text = dtgvdshdnh.CurrentRow.Cells[4].Value.ToString();
        }
    }
}

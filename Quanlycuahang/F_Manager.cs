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
    public partial class F_Manager : Form
    {
        private Nhanvien nhanvien;

        public Nhanvien Nhanvien
        {
            get { return nhanvien; }
            set { nhanvien = value; }
        }
        public F_Manager(Nhanvien nv)
        {
            InitializeComponent();
            this.nhanvien = nv;
            if(this.nhanvien.Chucvu.Contains("Quản lý"))
            {
                menuquanlynhanvien.Enabled = true;
                menuquanlynhacungcap.Enabled = true;
            }
            LoadDonHangMoi();
            LoadSanPhamSapHetHang();
        }
        #region Methord

        private void ĐăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void XemThôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String mv = nhanvien.Manv;
            Nhanvien loginnhanvien = NhanvienDAO.Instance.GetAccountByUserName(mv);
            F_Thongtintaikhoan ftttk = new F_Thongtintaikhoan(loginnhanvien);
            ftttk.ShowDialog();
        }

        private void ĐổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String mv = nhanvien.Manv;
            Nhanvien loginnhanvien = NhanvienDAO.Instance.GetAccountByUserName(mv);
            F_Doimatkhau fdmk = new F_Doimatkhau(loginnhanvien);
            fdmk.ShowDialog();
        }

        private void NhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Quanlynhanvien fqlnv = new F_Quanlynhanvien();
            this.Hide();
            fqlnv.ShowDialog();
            this.Show();
        }
        #endregion

        #region Event
        #endregion

        private void KháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Quanlykhachhang fqlkh = new F_Quanlykhachhang();
            this.Hide();
            fqlkh.ShowDialog();
            this.LoadDonHangMoi();
            this.LoadSanPhamSapHetHang();
            this.Show();
        }

        private void NhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Quanlynhacungcap fqlncc = new F_Quanlynhacungcap();
            this.Hide();
            fqlncc.ShowDialog();
            this.LoadDonHangMoi();
            this.LoadSanPhamSapHetHang();
            this.Show();
        }

        private void ĐồngHồToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Quanlydongho fqldh = new F_Quanlydongho();
            this.Hide();
            fqldh.ShowDialog();
            this.LoadDonHangMoi();
            this.LoadSanPhamSapHetHang();
            this.Show();
        }

        private void BánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String mv = nhanvien.Manv;
            Nhanvien loginnhanvien = NhanvienDAO.Instance.GetAccountByUserName(mv);
            F_Quanlyhoadonbanhang fqlhdbh = new F_Quanlyhoadonbanhang(loginnhanvien);
            this.Hide();
            fqlhdbh.ShowDialog();
            this.LoadDonHangMoi();
            this.LoadSanPhamSapHetHang();
            this.Show();
        }

        private void NhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String mv = nhanvien.Manv;
            Nhanvien loginnhanvien = NhanvienDAO.Instance.GetAccountByUserName(mv);
            F_Quanlyhoadonnhaphang fqlhdnh = new F_Quanlyhoadonnhaphang(loginnhanvien);
            this.Hide();
            fqlhdnh.ShowDialog();
            this.LoadDonHangMoi();
            this.LoadSanPhamSapHetHang();
            this.Show();
        }

        

        private void ThốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Thongke ftk = new F_Thongke();
            this.Hide();
            ftk.ShowDialog();
            this.LoadDonHangMoi();
            this.LoadSanPhamSapHetHang();
            this.Show();
        }



        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            F_Quanlykhachhang fqlkh = new F_Quanlykhachhang();
            this.Hide();
            fqlkh.ShowDialog();
            this.LoadDonHangMoi();
            this.LoadSanPhamSapHetHang();
            this.Show();
        }

        private void F_Manager_Load(object sender, EventArgs e)
        {

        }

        private void danhSáchSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Quanlydongho fqldh = new F_Quanlydongho();
            this.Hide();
            fqldh.ShowDialog();
            this.LoadDonHangMoi();
            this.LoadSanPhamSapHetHang();
            this.Show();
        }

        private void nhậpHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            String mv = nhanvien.Manv;
            Nhanvien loginnhanvien = NhanvienDAO.Instance.GetAccountByUserName(mv);
            F_Quanlyhoadonnhaphang fqlhdnh = new F_Quanlyhoadonnhaphang(loginnhanvien);
            this.Hide();
            fqlhdnh.ShowDialog();
            this.LoadDonHangMoi();
            this.LoadSanPhamSapHetHang();
            this.Show();
        }

        

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bánHàngToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            String mv = nhanvien.Manv;
            Nhanvien loginnhanvien = NhanvienDAO.Instance.GetAccountByUserName(mv);
            F_Quanlyhoadonbanhang fqlhdbh = new F_Quanlyhoadonbanhang(loginnhanvien);
            this.Hide();
            fqlhdbh.ShowDialog();
            this.LoadDonHangMoi();
            this.LoadSanPhamSapHetHang();
            this.Show();
        }

        private void báoCáoBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Thongke ftk = new F_Thongke();
            this.Hide();
            ftk.ShowDialog();
            this.LoadDonHangMoi();
            this.LoadSanPhamSapHetHang();
            this.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            String mv = nhanvien.Manv;
            Nhanvien loginnhanvien = NhanvienDAO.Instance.GetAccountByUserName(mv);
            F_Quanlyhoadonbanhang fqlhdbh = new F_Quanlyhoadonbanhang(loginnhanvien);
            this.Hide();
            fqlhdbh.ShowDialog();
            this.LoadDonHangMoi();
            this.LoadSanPhamSapHetHang();
            this.Show();
        }
        void LoadDonHangMoi()
        {
            DateTime ngaylap = DateTime.Now;
            int x = HoadonDAO.Instance.DonHangMoi(ngaylap);
            if(x == 0)
            {
                btndonhangmoi.Text = "Ngày hôm nay chưa có đơn hàng nào";
                btndonhangmoi.Enabled = false;
            }
            else
            {
                btndonhangmoi.Text = x + " Đơn hàng mới";
                btndonhangmoi.Enabled = true;
            }
        }
        void LoadSanPhamSapHetHang()
        {
            int x = DonghoDAO.Instance.DongHoSapHetHang();
            if(x == 0)
            {
                btndhshh.Text = "Không có sản phẩm nào sắp hết hàng";
                btndhshh.Enabled = false;
            }
            else
            {
                btndhshh.Text = "Có " + x + " sản phẩm sắp hết hàng!";
                btndhshh.Enabled = true;
            }
        }

        private void btndonhangmoi_Click(object sender, EventArgs e)
        {
            F_Donhangmoi fdhm = new F_Donhangmoi();
            this.Hide();
            fdhm.ShowDialog();
            this.Show();
        }

        private void btndhshh_Click(object sender, EventArgs e)
        {
            String mv = nhanvien.Manv;
            Nhanvien loginnhanvien = NhanvienDAO.Instance.GetAccountByUserName(mv);
            F_Sanphamsaphethang fdhm = new F_Sanphamsaphethang(loginnhanvien);
            this.Hide();
            fdhm.ShowDialog();
            this.LoadDonHangMoi();
            this.LoadSanPhamSapHetHang();
            this.Show();
        }

        private void danhSáchKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Quanlykhachhang fqlkh = new F_Quanlykhachhang();
            this.Hide();
            fqlkh.ShowDialog();
            this.LoadDonHangMoi();
            this.LoadSanPhamSapHetHang();
            this.Show();
        }

        private void lịchSửGiaoDịchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_LichSuGiaoDich flsgd = new F_LichSuGiaoDich();
            this.Hide();
            flsgd.ShowDialog();
            this.LoadDonHangMoi();
            this.LoadSanPhamSapHetHang();
            this.Show();
        }

        private void menuquanlynhanvien_Click(object sender, EventArgs e)
        {
            F_Quanlynhanvien fqlnv = new F_Quanlynhanvien();
            this.Hide();
            fqlnv.ShowDialog();
            this.LoadDonHangMoi();
            this.LoadSanPhamSapHetHang();
            this.Show();
        }

        private void danhSáchNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Quanlynhacungcap fqlncc = new F_Quanlynhacungcap();
            this.Hide();
            fqlncc.ShowDialog();
            this.LoadDonHangMoi();
            this.LoadSanPhamSapHetHang();
            this.Show();
        }

        private void lịchSửGiaoDịchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            F_LichSuGiaoDichNCC flsgdncc = new F_LichSuGiaoDichNCC();
            this.Hide();
            flsgdncc.ShowDialog();
            this.LoadDonHangMoi();
            this.LoadSanPhamSapHetHang();
            this.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void hethongToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

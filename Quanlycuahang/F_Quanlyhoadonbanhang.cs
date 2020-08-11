using DevExpress.XtraReports.UI;
using Quanlycuahang.DAO;
using Quanlycuahang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlycuahang
{
    public partial class F_Quanlyhoadonbanhang : Form
    {
        private Nhanvien nhanvien;

        public Nhanvien Nhanvien
        {
            get { return nhanvien; }
            set { nhanvien = value; }
        }
        public F_Quanlyhoadonbanhang(Nhanvien nv)
        {
            InitializeComponent();
            this.nhanvien = nv;
            LoadNhanVien();
        }
        #region Method
        void ShowBill(String id)
        {
            lsvBill.Items.Clear();
            List<DTO.Menu> listbillInfors = MenuDAO.Instance.LoadDanhSachHoadon(id);
         //   decimal totalPrice = 0;
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
        void LoadNhanVien()
        {
            txbmanv.Text = nhanvien.Manv;
            txbtnv.Text = nhanvien.Tennv;
        }
        void LoadDanhSachMaDongHo()
        {
            cbmdh.DataSource = DonghoDAO.Instance.GetDongho();
            cbmdh.DisplayMember = "madh";
        }
        void LapHoaDon(String mahd, decimal tongtien)
        {
            if(HoadonDAO.Instance.LapHoaHoaDon(mahd, tongtien))
            {
                MessageBox.Show("Lập hóa đơn thành công", "Thông báo");
                Clear();
                
            }
            else
                MessageBox.Show("Có lỗi khi lập hóa đơn", "Thông báo");
        }
        
        void HuyHoaDon(String mahd)
        {
            CTHoadonDAO.Instance.DeleteCTHoadonByMaHoaDon(mahd);
            if (HoadonDAO.Instance.DeleteHoadonByMaHoaDon(mahd))
            {
                MessageBox.Show("Hủy hóa đơn thành công", "Thông báo");
                Clear();
            }
            else
                MessageBox.Show("Có lỗi khi hủy hóa đơn", "Thông báo");
        }

        void Thanhtien(NumericUpDown nm)
        {
            int soluong = (int)nm.Value;
            decimal dongia = decimal.Parse(txbdongia.Text);
            decimal thanhtien = dongia * soluong;
            txbthanhtien.Text = Convert.ToString(thanhtien);
        }
        string Mahoadon()
        {
            string mahdm;
            if (HoadonDAO.Instance.CheckMahoadon() > 0)
            {
                string mahdc = HoadonDAO.Instance.GetMahoadon();
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
                mahdm = string.Format("HDBH{0}", thutu);
            }
            else
            {
                mahdm = "HDBH0";
            }
            return mahdm;
        }
        void Clear()
        {
            txbtenkh.Text = "";
            txbdiachi.Text = "";
            txbsdt.Text = "";
            cbmdh.Text = "";
            txbtendh.Text = "";
            txbdongia.Text = "0";
            nmsoluong.Value = 1;
            txbthanhtien.Text = "0";
            txbtongtiennew.Text = "0";
            txbsoluongkho.Text = "0";
            txbmahd.Text = Mahoadon();
            bntlaphoadon.Enabled = false;
            bnthuyhoadon.Enabled = false;
            bntthemdh.Enabled = false;
        }
        void Loaddanhsachhoadonbanhang()
        {
            dtgvdshdbh.DataSource = HoadonDAO.Instance.LoadDanhSachHoaDon();
        }
        void Capnhatsoluongdongho(String id)
        {
            List<DTO.Menu> listbillInfors = MenuDAO.Instance.LoadDanhSachHoadon(id);
            foreach (DTO.Menu item in listbillInfors)
            {
                string madh = item.Madh.ToString();
                int soluong = Convert.ToInt32(item.Soluong.ToString());
                DonghoDAO.Instance.UpdateSoLuongDongHoBanHang(madh, soluong);
            }
        }
        #endregion
        #region Event
        private void F_Quanlyhoadonbanhang_Load(object sender, EventArgs e)
        {
            LoadDanhSachMaDongHo();
            Clear();
            Loaddanhsachhoadonbanhang();
        }


        private void Cbmdh_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbtendh.Text = (cbmdh.SelectedItem as Dongho).Tendh;
            decimal dg = (cbmdh.SelectedItem as Dongho).Giaban;
            txbdongia.Text = Convert.ToString(dg);
            Thanhtien(nmsoluong);
            txbsoluongkho.Text = Convert.ToString((cbmdh.SelectedItem as Dongho).Soluong);
            int soluong = Convert.ToInt32(txbsoluongkho.Text);
            bntthemdh.Enabled = true;
            //if (soluong > 0)
            //{
            //    bntthemdh.Enabled = true;
            //}
            //else
            //{
            //    bntthemdh.Enabled = false;
            //    MessageBox.Show("Sản phẩm đã hết hàng!", "Thông báo");
            //}
        }
       
        private void Nmsoluong_ValueChanged(object sender, EventArgs e)
        {
            Thanhtien(nmsoluong);
        }
        decimal tongtien = 0;
        private void Bntthemdh_Click(object sender, EventArgs e)
        {
            int soluongton = int.Parse(txbsoluongkho.Text);
            if(soluongton > 0)
            {
                String mahd = txbmahd.Text;
                String checkma = HoadonDAO.Instance.CheckMaHoaDon(mahd);
                String manv = txbmanv.Text;
                DateTime ngaylap = dtpgngaylap.Value;
                String madh = cbmdh.Text;
                decimal giaban = decimal.Parse(txbdongia.Text);
                int soluong = Convert.ToInt32(nmsoluong.Value);
                String checkmaDH = CTHoadonDAO.Instance.CheckMaHoaDon(madh, mahd);
                String sdt = txbsdt.Text;
                String tenkh = txbtenkh.Text;
                String dc = txbdiachi.Text;
                int makh = 0;
                if (tenkh == "" || sdt == "")
                {
                    MessageBox.Show("Vui lòng nhập thông tin khách hàng");
                }
                else
                {
                    if(soluong < soluongton)
                    {
                        makh = KhachhangDAO.Instance.GetMaKhachHangBySDT(sdt, tenkh);
                        if (makh <= 0)
                        {
                            KhachhangDAO.Instance.InsertKhachHang(tenkh, dc, sdt);
                        }
                        else
                        {
                            if (checkma == null)
                            {
                                tongtien = 0;
                                HoadonDAO.Instance.InsertHoaDon(mahd, manv, makh, ngaylap, 0);
                                if (checkmaDH == null)
                                    CTHoadonDAO.Instance.InsertCTHoadon(mahd, madh, giaban, soluong);
                                else
                                    CTHoadonDAO.Instance.UpdateCTHoadon(mahd, madh, soluong);
                            }
                            else
                            {
                                if (checkmaDH == null)
                                    CTHoadonDAO.Instance.InsertCTHoadon(mahd, madh, giaban, soluong);
                                else
                                    CTHoadonDAO.Instance.UpdateCTHoadon(mahd, madh, soluong);
                            }
                            tongtien += decimal.Parse(txbthanhtien.Text);
                            txbtongtiennew.Text = tongtien.ToString("#,##");
                            ShowBill(mahd);
                            bntlaphoadon.Enabled = true;
                            bnthuyhoadon.Enabled = true;
                            soluongton = soluongton - soluong;
                            txbsoluongkho.Text = Convert.ToString(soluongton);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không đủ sản phẩm cung cấp!", "Thông báo");
                    }

                }
                
            }
            else
            {
                MessageBox.Show("Sản phẩm đã hết hàng!", "Thông báo");
            }
            
            
        }
        private void Bntlaphoadon_Click(object sender, EventArgs e)
        {
            String mahd = txbmahd.Text;
            decimal tongtien = decimal.Parse(txbtongtiennew.Text);
            if (MessageBox.Show("Bạn có muốn lập hóa đơn?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                LapHoaDon(mahd, tongtien);
                lsvBill.Items.Clear();
                dtgvdshdbh.DataSource = HoadonDAO.Instance.Searchhoadonbymahoadon(txbtimkiemhdbh.Text);
                Capnhatsoluongdongho(mahd);
            
                DataTable dt = HoadonDAO.Instance.InHoaDon(mahd);
                if (MessageBox.Show("Bạn có muốn in hóa đơn?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    ReportHoaDonBanHang hdbh = new ReportHoaDonBanHang();
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
                dtgvdshdbh.DataSource = HoadonDAO.Instance.Searchhoadonbymahoadon(txbtimkiemhdbh.Text);
             
            }
            ShowBill(mahd);
        }
        private void btntimkiemhdbh_Click(object sender, EventArgs e)
        {
            dtgvdshdbh.DataSource = HoadonDAO.Instance.Searchhoadonbymahoadon(txbtimkiemhdbh.Text);
        }
        void ShowBillCTHD(String id)
        {
            listView1.Items.Clear();
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
                listView1.Items.Add(lsvItem);
            }
            //CultureInfo culture = new CultureInfo("vi-VN");
            //Thread.CurrentThread.CurrentCulture = culture;
            //txbtotalPrice.Text = totalPrice.ToString("c", culture);
            // txbtotalPrice.Text = totalPrice.ToString();

        }
        private void dtgvdshdbh_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txbmacthd.Text = dtgvdshdbh.CurrentRow.Cells[0].Value.ToString();
            txbcthdmnv.Text = dtgvdshdbh.CurrentRow.Cells[1].Value.ToString();
            txbcthdmakh.Text = dtgvdshdbh.CurrentRow.Cells[2].Value.ToString();
            txbcthdtennv.Text = NhanvienDAO.Instance.GetNameById(txbcthdmnv.Text);
            txbngaylap.Text = dtgvdshdbh.CurrentRow.Cells[3].Value.ToString();
            txbcthdtenkh.Text = KhachhangDAO.Instance.GetTenKhachhangByMaKhachhang(txbcthdmakh.Text);
            // txbtenkh.Text = KhachhangDAO.Instance.GetTenKhachhangByMaKhachhang(txbcthdmakh.Text);
            txbcthddiachi.Text = KhachhangDAO.Instance.GetDiachiKhachhangByMaKhachhang(txbcthdmakh.Text);
            txbcthdsdt.Text = KhachhangDAO.Instance.GetSdtKhachhangByMaKhachhang(txbcthdmakh.Text);
            ShowBillCTHD(txbmacthd.Text);
            txbcthdtt.Text = dtgvdshdbh.CurrentRow.Cells[4].Value.ToString();
        }

        #endregion
    }
}

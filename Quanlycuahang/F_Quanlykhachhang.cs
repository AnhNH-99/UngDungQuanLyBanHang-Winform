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
    public partial class F_Quanlykhachhang : Form
    {
        public F_Quanlykhachhang()
        {
            InitializeComponent();
            LoadDanhSachKhachHang();
            bntSua.Enabled = false;
            bntXoa.Enabled = false;
        }
        void LoadDanhSachKhachHang()
        {
            dtgvKhachang.DataSource = KhachhangDAO.Instance.LoadDanhSachKhachHang();
        }
        void InsertKhachHang(String tenkh, String dc, String sdt)
        {
            if (KhachhangDAO.Instance.InsertKhachHang(tenkh, dc, sdt))
            {
                MessageBox.Show("Thêm khách hàng thành công", "Thông báo");
            }
            else
                MessageBox.Show("Có lỗi khi thêm khách hàng", "Thông báo");
        }
        void UpdateKhachHang(String makh, String tenkh, String dc, String sdt)
        {
            if (KhachhangDAO.Instance.UpdateKhachHang(makh, tenkh, dc, sdt))
            {
                MessageBox.Show("Sửa khách hàng thành công", "Thông báo");
            }
            else
                MessageBox.Show("Có lỗi khi sửa khách hàng", "Thông báo");
        }
        void DeleteKhachHang(String makh)
        {
            if (KhachhangDAO.Instance.DeleteKhachHang(makh))
            {
                MessageBox.Show("Xóa khách hàng thành công", "Thông báo");
            }
            else
                MessageBox.Show("Có lỗi khi xóa khách hàng", "Thông báo");
        }
        

        private void DtgvKhachang_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txbmakh.Text = dtgvKhachang.CurrentRow.Cells[0].Value.ToString();
            txbtenkh.Text = dtgvKhachang.CurrentRow.Cells[1].Value.ToString();
            txbDiachi.Text = dtgvKhachang.CurrentRow.Cells[2].Value.ToString();
            txbsdt.Text = dtgvKhachang.CurrentRow.Cells[3].Value.ToString();
            bntSua.Enabled = true;
            bntXoa.Enabled = true;
            txbmakh.Enabled = false;
        }

        private void BntSua_Click(object sender, EventArgs e)
        {
            String makh = txbmakh.Text;
            String tenkh = txbtenkh.Text;
            String dc = txbDiachi.Text;
            String sdt = txbsdt.Text;
            UpdateKhachHang(makh, tenkh, dc, sdt);
            LoadDanhSachKhachHang();
        }

        private void BntXoa_Click(object sender, EventArgs e)
        {
            String makh = txbmakh.Text;
            DeleteKhachHang(makh);
            LoadDanhSachKhachHang();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txbTimkiem.Text;
            dtgvKhachang.DataSource = KhachhangDAO.Instance.SearchKhachhangByName(name);
        }

        private void bntlammoi_Click(object sender, EventArgs e)
        {
            txbmakh.Text = "";
            txbtenkh.Text = "";
            txbDiachi.Text = "";
            txbTimkiem.Text = "";
            txbsdt.Text = "";
            bntSua.Enabled = false;
            bntXoa.Enabled = false;
            txbmakh.Enabled = true;
        }
    }
}

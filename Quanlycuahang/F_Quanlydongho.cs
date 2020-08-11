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
    public partial class F_Quanlydongho : Form
    {
        public F_Quanlydongho()
        {
            InitializeComponent();
            LoadDanhSachDongHo();
            LoadNhaCungCap();
            bntSua.Enabled = false;
            bntXoa.Enabled = false;
        }
        void LoadDanhSachDongHo()
        {
            dtgvdongho.DataSource = DonghoDAO.Instance.LoadDanhSachDongHo();
        }
        void LoadNhaCungCap()
        {
            cbnhacungcap.DataSource = nhacungcapDAO.Instance.GetListNhaCungCap();
            cbnhacungcap.DisplayMember = "tencc";
        }
        void InsertDongHo(String madh, String tendh, String kieudang, String thuonghieu, int namsanxuat, String nhacungcap, decimal gianhap, int soluong, decimal giaban, int baohanh)
        {
            if (DonghoDAO.Instance.InsertDongHo(madh, tendh, kieudang, thuonghieu, namsanxuat, nhacungcap, gianhap, soluong, giaban, baohanh))
                MessageBox.Show("Thêm đồng hồ thành công", "Thông báo");
            else
                MessageBox.Show("Có lỗi khi thêm đồng hồ", "Thông báo");
        }
        void UpdateDongHo(String madh, String tendh, String kieudang, String thuonghieu, int namsanxuat, String nhacungcap, decimal gianhap, int soluong, decimal giaban, int baohanh)
        {
            if (DonghoDAO.Instance.UpdateDongHo(madh, tendh, kieudang, thuonghieu, namsanxuat, nhacungcap, gianhap, soluong, giaban, baohanh))
                MessageBox.Show("Sửa đồng hồ thành công", "Thông báo");
            else
                MessageBox.Show("Có lỗi khi sửa đồng hồ", "Thông báo");
        }
        void DeleteDongHo(String madh)
        {
            if (DonghoDAO.Instance.DeleteDongHo(madh))
                MessageBox.Show("Xóa đồng hồ thành công", "Thông báo");
            else
                MessageBox.Show("Có lỗi khi xóa đồng hồ", "Thông báo");
        }
        
        private void Bntthem_Click(object sender, EventArgs e)
        {
            if(txbmadh.Text == "" || txbtendh.Text == "" || txbthuonghieu.Text == "" || txbnsx.Text == "" || txbgiaban.Text == "" || 
                txbgiaban.Text == ""  || txbgianhap.Text == "" || txbbaohanh.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                String madh = txbmadh.Text;
                String tendh = txbtendh.Text;
                String kieudang;
                if (rbnam.Checked == true)
                    kieudang = "Đồng hồ nam";
                else
                    kieudang = "Đồng hồ nữ";
                String thuonghieu = txbthuonghieu.Text;
                String nhacungcap = (cbnhacungcap.SelectedItem as nhacungcap).Mancc;
                int namsanxuat = Convert.ToInt32(txbnsx.Text);
                decimal gianhap = decimal.Parse(txbgianhap.Text);
                int soluong = Convert.ToInt32(nmsoluong.Value.ToString());
                decimal giaban = decimal.Parse(txbgiaban.Text);
                int baohanh = Convert.ToInt32(txbbaohanh.Text);
                int dh = DonghoDAO.Instance.GetDongHoByMa(madh);
                if(giaban > gianhap)
                {
                    if (dh > 0)
                    {
                        MessageBox.Show("Mã đồng hồ đã tồn tại!");
                    }
                    else
                    {
                        InsertDongHo(madh, tendh, kieudang, thuonghieu, namsanxuat, nhacungcap, gianhap, soluong, giaban, baohanh);
                    }
                    LoadDanhSachDongHo();
                }
                else
                {
                    MessageBox.Show("Giá bán phải lớn hơn giá nhập");
                }
                
                
            }
            
        }

        private void BntSua_Click(object sender, EventArgs e)
        {
            if (txbmadh.Text == "" || txbtendh.Text == "" || txbthuonghieu.Text == "" || txbnsx.Text == "" || txbgiaban.Text == "" ||
                txbgiaban.Text == "" || txbgianhap.Text == "" || txbbaohanh.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                String madh = txbmadh.Text;
                String tendh = txbtendh.Text;
                String kieudang;
                if (rbnam.Checked == true)
                    kieudang = "Đồng hồ nam";
                else
                    kieudang = "Đồng hồ nữ";
                String thuonghieu = txbthuonghieu.Text;
                String nhacungcap = (cbnhacungcap.SelectedItem as nhacungcap).Mancc;
                int namsanxuat = Convert.ToInt32(txbnsx.Text);
                decimal gianhap = decimal.Parse(txbgianhap.Text);
                int soluong = Convert.ToInt32(nmsoluong.Value.ToString());
                decimal giaban = decimal.Parse(txbgiaban.Text);
                int baohanh = Convert.ToInt32(txbbaohanh.Text);
                if (giaban > gianhap)
                {
                    UpdateDongHo(madh, tendh, kieudang, thuonghieu, namsanxuat, nhacungcap, gianhap, soluong, giaban, baohanh);
                    LoadDanhSachDongHo();
                }
                else
                {
                    MessageBox.Show("Giá bán phải lớn hơn giá nhập");
                }

            }
            
        }

        private void Dtgvdongho_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txbmadh.Text = dtgvdongho.CurrentRow.Cells[0].Value.ToString();
            txbtendh.Text = dtgvdongho.CurrentRow.Cells[1].Value.ToString();
            String th = dtgvdongho.CurrentRow.Cells[2].Value.ToString();
            if (th == "Đồng hồ nam")
                rbnam.Checked = true;
            else
                rbNu.Checked = true;
            txbthuonghieu.Text = dtgvdongho.CurrentRow.Cells[3].Value.ToString();
            txbnsx.Text = dtgvdongho.CurrentRow.Cells[4].Value.ToString();
            cbnhacungcap.Text = DonghoDAO.Instance.GetTenDongHo(dtgvdongho.CurrentRow.Cells[5].Value.ToString());
            txbgianhap.Text = dtgvdongho.CurrentRow.Cells[6].Value.ToString();
            nmsoluong.Value = Convert.ToDecimal(dtgvdongho.CurrentRow.Cells[7].Value.ToString());
            txbgiaban.Text = dtgvdongho.CurrentRow.Cells[8].Value.ToString();
            txbbaohanh.Text = dtgvdongho.CurrentRow.Cells[9].Value.ToString();
            txbmadh.Enabled = false;
            bntthem.Enabled = false;
            bntSua.Enabled = true;
            bntXoa.Enabled = true;
        }

        private void BntXoa_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn xóa sẩn phẩm này?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                String madh = txbmadh.Text;
                DeleteDongHo(madh);
                LoadDanhSachDongHo();
            }
            
        }

        private void cbnhacungcap_SelectedIndexChanged(object sender, EventArgs e)
        {
           // LoadNhaCungCap();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txbTimkiem.Text;
            dtgvdongho.DataSource = DonghoDAO.Instance.SearchDonghoByName(name);
        }

        private void bntlammoi_Click(object sender, EventArgs e)
        {
            txbmadh.Text = "";
            txbmadh.Enabled = true;
            txbtendh.Text = "";
            txbthuonghieu.Text = "";
            txbTimkiem.Text = "";
            txbnsx.Text = "";
            txbgianhap.Text = "";
            txbgiaban.Text = "";
            txbbaohanh.Text = "";
            rbnam.Checked = true;
            nmsoluong.Value = 0;
            bntthem.Enabled = true;
            bntSua.Enabled = false;
            bntXoa.Enabled = false;
        }
    }
}

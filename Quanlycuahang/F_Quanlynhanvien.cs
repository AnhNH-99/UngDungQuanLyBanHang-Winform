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
    public partial class F_Quanlynhanvien : Form
    {
        public F_Quanlynhanvien()
        {
            InitializeComponent();
            LoadDanhSachNhanVien();
            LoadListChucVu();
            bntresetmk.Enabled = false;
            bntsua.Enabled = false;
            bntxoa.Enabled = false;
        }
        void LoadDanhSachNhanVien()
        {
            dtgvnhanvien.DataSource = NhanvienDAO.Instance.LoadDanhSachNhanVien();
        }
        void LoadListChucVu()
        {
            cbcv.Items.Add("Nhân viên");
            cbcv.Items.Add("Quản lý");
        }
        void AddNhanVienBinding()
        {
            txbmanv.DataBindings.Add(new Binding("Text", dtgvnhanvien.DataSource, "manv", true, DataSourceUpdateMode.Never));
            
        }
        void ResetMatKhau(String manv)
        {
            if (NhanvienDAO.Instance.ResertMatKhau(manv))
                MessageBox.Show("Reset mật khẩu thành công!", "Thông báo");
            else
                MessageBox.Show("Có lỗi khi Reset mật khẩu", "Thông báo");
        }
        void InsertNhanVien(String manv, String tennv, String gt, DateTime ngaysinh, String diachi, String email, String sdt, String chucvu)
        {
            if(NhanvienDAO.Instance.InsertNhanVien(manv, tennv, gt, ngaysinh, diachi, email, sdt, chucvu))
            {
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo");
            }
            else
                MessageBox.Show("Có lỗi khi thêm nhân viên!", "Thông báo");
        }
        void UpdateNhanVien(String manv, String tennv, String gt, DateTime ngaysinh, String diachi, String email, String sdt, String chucvu)
        {
            if (NhanvienDAO.Instance.UpdateNhanVien(manv, tennv, gt, ngaysinh, diachi, email, sdt, chucvu))
            {
                MessageBox.Show("Sửa nhân viên thành công!", "Thông báo");
            }
            else
                MessageBox.Show("Có lỗi khi sửa nhân viên!", "Thông báo");
        }
        void DeleteNhanVien(String manv)
        {
            if (NhanvienDAO.Instance.DeleteNhanVien(manv))
            {
                MessageBox.Show("Xóa nhân viên thành công!", "Thông báo");
            }
            else
                MessageBox.Show("Có lỗi khi xóa nhân viên!", "Thông báo");
        }
        
        private void Dtgvnhanvien_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txbmanv.Text =dtgvnhanvien.CurrentRow.Cells[0].Value.ToString();
            txbtenv.Text = dtgvnhanvien.CurrentRow.Cells[1].Value.ToString();
            String gt = dtgvnhanvien.CurrentRow.Cells[2].Value.ToString();
            if (gt == "Nam")
                rdNam.Checked = true;
            else
                rdNu.Checked = true;
            dtpkns.Text = dtgvnhanvien.CurrentRow.Cells[3].Value.ToString().Split(' ')[0];
            txbdc.Text = dtgvnhanvien.CurrentRow.Cells[4].Value.ToString();
            txbemail.Text = dtgvnhanvien.CurrentRow.Cells[5].Value.ToString();
            txbsdt.Text = dtgvnhanvien.CurrentRow.Cells[6].Value.ToString();
            cbcv.Text = dtgvnhanvien.CurrentRow.Cells[7].Value.ToString();
            txbmanv.Enabled = false;
            bntthem.Enabled = false;
            bntresetmk.Enabled = true;
            bntsua.Enabled = true;
            bntxoa.Enabled = true;
        }

        private void Bntresetmk_Click(object sender, EventArgs e)
        {
            String manv = txbmanv.Text;
            ResetMatKhau(manv);
            LoadDanhSachNhanVien();
        }

        private void Bntthem_Click(object sender, EventArgs e)
        {
            if(txbmanv.Text == "" || txbtenv.Text == "" || txbdc.Text == "" || txbemail.Text == "" || txbsdt.Text == "" || cbcv.Text == "" )
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                String manv = txbmanv.Text;
                String tennv = txbtenv.Text;
                String gt;
                if (rdNam.Checked == true)
                    gt = "Nam";
                else
                    gt = "Nữ";
                String dc = txbdc.Text;
                String email = txbemail.Text;
                String sdt = txbsdt.Text;
                String chucvu = cbcv.Text;
                DateTime ns = dtpkns.Value;
                int nv = NhanvienDAO.Instance.GetNhanVienByMa(manv);
                if (nv > 0)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!");
                }
                else
                {
                    InsertNhanVien(manv, tennv, gt, ns, dc, email, sdt, chucvu);
                }

                LoadDanhSachNhanVien();
            }
            
        }

        private void Bntsua_Click(object sender, EventArgs e)
        {
            if (txbmanv.Text == "" || txbtenv.Text == "" || txbdc.Text == "" || txbemail.Text == "" || txbsdt.Text == "" || cbcv.Text == "" )
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                String manv = txbmanv.Text;
                String tennv = txbtenv.Text;
                String gt;
                if (rdNam.Checked == true)
                    gt = "Nam";
                else
                    gt = "Nữ";
                String dc = txbdc.Text;
                String email = txbemail.Text;
                String sdt = txbsdt.Text;
                String chucvu = cbcv.Text;
                DateTime ns = dtpkns.Value;
                UpdateNhanVien(manv, tennv, gt, ns, dc, email, sdt, chucvu);
                LoadDanhSachNhanVien();
            }
            
        }

        private void Bntxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa nhân viên này?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                String manv = txbmanv.Text;
                DeleteNhanVien(manv);
                LoadDanhSachNhanVien();
            }
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name = txbTimkiem.Text;
            dtgvnhanvien.DataSource = NhanvienDAO.Instance.SearchnhanvienByName(name);
        }

        private void bntlammoi_Click(object sender, EventArgs e)
        {
            txbmanv.Text = "";
            txbtenv.Text = "";
            txbdc.Text = "";
            txbemail.Text = "";
            txbsdt.Text = "";
            txbTimkiem.Text = "";
            rdNam.Checked = true;
            cbcv.Text = "Nhân viên";
            bntthem.Enabled = true;
            bntresetmk.Enabled = false;
            LoadDanhSachNhanVien();
            bntsua.Enabled = false;
            bntxoa.Enabled = false;
            txbmanv.Enabled = true;
        }
    }
}

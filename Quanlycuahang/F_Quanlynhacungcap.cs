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
    public partial class F_Quanlynhacungcap : Form
    {
        public F_Quanlynhacungcap()
        {
            InitializeComponent();
            LoadDanhSachNhaCungCap();
            bntsua.Enabled = false;
            bntxoa.Enabled = false;
        }

       void LoadDanhSachNhaCungCap()
        {
            dtgvnhacungcap.DataSource = nhacungcapDAO.Instance.LoadDanhSachNhaCungCap();
        }
        void InsertNhaCungCap(String mancc, String tenncc, String diachi, String email, String sdt)
        {
            if (nhacungcapDAO.Instance.InsertNhaCungCap(mancc, tenncc, diachi, email, sdt))
                MessageBox.Show("Thêm nhà cung cấp thành công", "Thông báo");
            else
                MessageBox.Show("Có lỗi khi thêm nhà cung cấp", "Thông báo");
        }
        void UpdatetNhaCungCap(String mancc, String tenncc, String diachi, String email, String sdt)
        {
            if (nhacungcapDAO.Instance.UpdateNhaCungCap(mancc, tenncc, diachi, email, sdt))
                MessageBox.Show("Sửa nhà cung cấp thành công", "Thông báo");
            else
                MessageBox.Show("Có lỗi khi sửa nhà cung cấp", "Thông báo");
        }
        void DeleteNhaCungCap(String mancc)
        {
            if (nhacungcapDAO.Instance.DeleteNhaCungCap(mancc))
                MessageBox.Show("Xóa nhà cung cấp thành công", "Thông báo");
            else
                MessageBox.Show("Có lỗi khi xóa nhà cung cấp", "Thông báo");
        }

        private void Bntthem_Click(object sender, EventArgs e)
        {
            if(txbmancc.Text == "" || txbtenncc.Text == "" || txbdc.Text == "" || txbemail.Text == "" || txbsdt.Text == ""){
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                String mancc = txbmancc.Text;
                String tenncc = txbtenncc.Text;
                String diachi = txbdc.Text;
                String email = txbemail.Text;
                String sdt = txbsdt.Text;
                int ncc = nhacungcapDAO.Instance.GetNhaCungCapByMa(mancc);
                if(ncc > 0)
                {
                    MessageBox.Show("Mã nhà cung cấp đã tồn tại");
                }
                else
                {
                    InsertNhaCungCap(mancc, tenncc, diachi, email, sdt);
                }
                
                LoadDanhSachNhaCungCap();
            }
            
        }

        private void Dtgvnhacungcap_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txbmancc.Text = dtgvnhacungcap.CurrentRow.Cells[0].Value.ToString();
            txbtenncc.Text = dtgvnhacungcap.CurrentRow.Cells[1].Value.ToString();
            txbdc.Text = dtgvnhacungcap.CurrentRow.Cells[2].Value.ToString();
            txbemail.Text = dtgvnhacungcap.CurrentRow.Cells[3].Value.ToString();
            txbsdt.Text = dtgvnhacungcap.CurrentRow.Cells[4].Value.ToString();
            txbmancc.Enabled = false;
            bntthem.Enabled = false;
            bntsua.Enabled = true;
            bntxoa.Enabled = true;
        }

        private void Bntsua_Click(object sender, EventArgs e)
        {
            if (txbmancc.Text == "" || txbtenncc.Text == "" || txbdc.Text == "" || txbemail.Text == "" || txbsdt.Text == ""){
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                String mancc = txbmancc.Text;
                String tenncc = txbtenncc.Text;
                String diachi = txbdc.Text;
                String email = txbemail.Text;
                String sdt = txbsdt.Text;
                UpdatetNhaCungCap(mancc, tenncc, diachi, email, sdt);
                LoadDanhSachNhaCungCap();
            }
            
        }

        private void Bntxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa nhà cung cấp này?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                String mancc = txbmancc.Text;
                DeleteNhaCungCap(mancc);
                LoadDanhSachNhaCungCap();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txbTimkiem.Text;
            dtgvnhacungcap.DataSource = nhacungcapDAO.Instance.SearchNhacungcapByName(name);
        }

        private void bntlammoi_Click(object sender, EventArgs e)
        {
            txbmancc.Text = "";
            txbtenncc.Text = "";
            txbdc.Text = "";
            txbemail.Text = "";
            txbsdt.Text = "";
            txbTimkiem.Text = "";
            txbmancc.Enabled = true;
            bntsua.Enabled = false;
            bntxoa.Enabled = false;
            bntthem.Enabled = true;
        }
    }
}

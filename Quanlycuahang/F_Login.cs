using System;
using Quanlycuahang.DTO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quanlycuahang.DAO;

namespace Quanlycuahang
{
    public partial class F_Login : Form
    {
        
        public F_Login()
        {
            InitializeComponent();
        }
        #region Methord
        private void BntThoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát chương trình", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void BntDangNhap_Click(object sender, EventArgs e)
        {
            String manv = txbTenDangNhap.Text;
            String matkhau = txbmatkhau.Text;
            if(Dangnhap(manv, matkhau))
            {
                Nhanvien loginnhanvien = NhanvienDAO.Instance.GetAccountByUserName(manv);
                MessageBox.Show("Đăng nhập thành công", "Thông báo");
                F_Manager fm = new F_Manager(loginnhanvien);
                this.Hide();
                fm.ShowDialog();
                this.Show();
                
                
            }
            else
            {
                MessageBox.Show("Tài khoản mật khẩu không chính xác!", "Thông báo");
            }
        }
        #endregion
        #region Event
        bool Dangnhap(String manv, String matkhau)
        {
            return NhanvienDAO.Instance.Dangnhap(manv, matkhau);
        }
        #endregion
    }
}

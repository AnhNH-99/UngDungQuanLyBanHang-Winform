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
    public partial class F_Doimatkhau : Form
    {
        private Nhanvien nhanvien;

        public Nhanvien Nhanvien
        {
            get { return nhanvien; }
            set { nhanvien = value; }
        }
        public F_Doimatkhau(Nhanvien nv)
        {
            InitializeComponent();
            this.nhanvien = nv;
            Loaddulieu(nhanvien.Manv);
        }
        public void Loaddulieu(String manv)
        {
            txbTenDangNhap.Text = nhanvien.Manv;
        }
        #region Methord
        private void Bntcapnhat_Click(object sender, EventArgs e)
        {
            String manv = txbTenDangNhap.Text;
            String mkc = txbmatkhau.Text;
            String mkm = txbmatkhaumoi.Text;
            String nlmk = txbnhaplaimatkhau.Text;
            if (manv == "" || mkc == "" || mkm == "" || nlmk == "")
            {
                MessageBox.Show("Bạn cần điền đầy đủ thông tin", "Thông báo");
            }
            else
            { 
                if (MessageBox.Show("Bạn có muốn đổi mật khẩu", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    if (!mkm.Equals(nlmk))
                    {
                        MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới!", "Thông báo");
                    }
                    else
                    {
                        if (NhanvienDAO.Instance.Doimatkhau(manv, mkc, mkm))
                        {
                            MessageBox.Show("Đổi mật khẩu thành công", "Thông báo");
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng điền đúng mật khẩu!", "Thông báo");
                        }
                    }
                }
            }
        }
        #endregion
        #region Event
        #endregion
    }
}

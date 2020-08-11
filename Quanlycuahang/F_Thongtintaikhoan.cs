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
    public partial class F_Thongtintaikhoan : Form
    {
        private Nhanvien nhanvien;

        public Nhanvien Nhanvien
        {
            get { return nhanvien; }
            set { nhanvien = value; }
        }
        
        public F_Thongtintaikhoan(Nhanvien nv)
        {
            InitializeComponent();
            this.nhanvien = nv;
            Loaddulieu();
        }

        private void Bntthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Loaddulieu()
        {
            txbmanv.Text = nhanvien.Manv;
            txbtennv.Text = nhanvien.Tennv;
            txbgioitinh.Text = nhanvien.Gioitinh;
            txbngaysinh.Text = nhanvien.Ngaysinh.ToShortDateString();
            txbdiachi.Text = nhanvien.Diachi;
            txbemail.Text = nhanvien.Email;
            txbsdt.Text = nhanvien.Sdt;
            txbchucvu.Text = nhanvien.Chucvu;
        }
       
    }
}

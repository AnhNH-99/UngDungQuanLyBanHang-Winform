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
    public partial class F_Sanphamsaphethang : Form
    {
        private Nhanvien nhanvien;

        public Nhanvien Nhanvien
        {
            get { return nhanvien; }
            set { nhanvien = value; }
        }
        public F_Sanphamsaphethang(Nhanvien nv)
        {
            InitializeComponent();
            LoadDanhSach();
            this.nhanvien = nv;
        }
        void LoadDanhSach()
        {
            DataTable x = DonghoDAO.Instance.DanhSachDongHoSapHetHang();
            dtgvdsspshh.DataSource = DonghoDAO.Instance.DanhSachDongHoSapHetHang();
            if(x.Rows.Count <= 0)
            {
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String mv = nhanvien.Manv;
            Nhanvien loginnhanvien = NhanvienDAO.Instance.GetAccountByUserName(mv);
            F_Quanlyhoadonnhaphang fqlhdnh = new F_Quanlyhoadonnhaphang(loginnhanvien);
            this.Hide();
            fqlhdnh.ShowDialog();
            LoadDanhSach();
            this.Show();
        }
    }
}

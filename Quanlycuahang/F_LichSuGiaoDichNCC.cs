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
    public partial class F_LichSuGiaoDichNCC : Form
    {
        public F_LichSuGiaoDichNCC()
        {
            InitializeComponent();
            LoadDanhSachNhaCungCap();
        }
        void LoadDanhSachNhaCungCap()
        {
            dtgvlichsugiaodichncc.DataSource = nhacungcapDAO.Instance.LoadDanhSachNhaCungCap();
        }


        private void dtgvlichsugiaodichncc_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            String mancc = dtgvlichsugiaodichncc.CurrentRow.Cells[0].Value.ToString();
            F_Chitietgiaodichncc fctlsgd = new F_Chitietgiaodichncc(mancc);
            this.Hide();
            fctlsgd.ShowDialog();
           this.Show();
        }
    }
}

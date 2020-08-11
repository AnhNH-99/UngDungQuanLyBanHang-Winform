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
    public partial class F_Chitietgiaodichncc : Form
    {
        private String mancc;
        public F_Chitietgiaodichncc(String mancc)
        {
            InitializeComponent();
            this.mancc = mancc;
            dtgvdshdnh.DataSource = HoadonnhaphangDAO.Instance.LoadDanhSachHoaDonNhapHangByMaNCC(mancc);
            txbcthdmancc.Text = Convert.ToString(mancc);
            txbcthdtenncc.Text = nhacungcapDAO.Instance.GetTenNhacungcapByMaNhacungcap(txbcthdmancc.Text);
            txbcthddiachi.Text = nhacungcapDAO.Instance.GetSdtNhacungcapByNhacungcap(txbcthdmancc.Text);
            txbcthdsdt.Text = nhacungcapDAO.Instance.GetSdtNhacungcapByNhacungcap(txbcthdmancc.Text);
        }
        void ShowBillCTHD(String id)
        {
            listView1.Items.Clear();
            List<DTO.Menunhaphang> listbillInfors = MenunhaphangDAO.Instance.LoadDanhSachHoadon(id);
            foreach (DTO.Menunhaphang item in listbillInfors)
            {
                ListViewItem lsvItem = new ListViewItem(item.Madh.ToString());
                lsvItem.SubItems.Add(item.Tendh.ToString());
                lsvItem.SubItems.Add(item.Dongia.ToString());
                lsvItem.SubItems.Add(item.Soluong.ToString());
                lsvItem.SubItems.Add(item.Thanhtien.ToString());
                listView1.Items.Add(lsvItem);
            }

        }

        private void dtgvdshdnh_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txbmacthd.Text = dtgvdshdnh.CurrentRow.Cells[0].Value.ToString();
            txbcthdmnv.Text = dtgvdshdnh.CurrentRow.Cells[1].Value.ToString();
            txbcthdtennv.Text = NhanvienDAO.Instance.GetNameById(txbcthdmnv.Text);
            txbngaylap.Text = dtgvdshdnh.CurrentRow.Cells[3].Value.ToString();
            ShowBillCTHD(txbmacthd.Text);
            txbcthdtt.Text = dtgvdshdnh.CurrentRow.Cells[4].Value.ToString();
        }
    }
}

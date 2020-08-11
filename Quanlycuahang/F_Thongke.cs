using DevExpress.XtraEditors.Filtering.Templates;
using DevExpress.XtraReports.UI;
using Quanlycuahang.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlycuahang
{
    public partial class F_Thongke : Form
    {
        public F_Thongke()
        {
            InitializeComponent();
            LoadDanhSachHoaDon();
            LoadDateTimePickerBill();
            LoadTongtienkdk();
            LoadDanhSachHoaDonNhapHang();
            LoadDateTimePickerBillNhapHang();
            LoadTongtienkdkNhapHang();
            //Loadbieudo();
            LoadLoaiThongKe();
        }
        void Loadbieudo()
        {
            string kn = "Data Source=.;Initial Catalog=quanlyshopdongho1;Integrated Security=True";
            string cl = "select MONTH(ngaylap) as thang, SUM(tongtien) as doanhthu FROM hoadonnhaphang  GROUP BY ngaylap";
            SqlConnection con = new SqlConnection(kn);
            SqlCommand cmd = new SqlCommand(cl, con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            ad.Fill(ds);
            con.Open();
            ChartDBC.DataSource = ds;
            //ChartDBC.Series["ChartBDC"].XValueMember = "thang";
            //ChartDBC.Series["ChartBDC"].YValueMembers = "doanhthu";
            for (int i = 0; i < ds.Rows.Count; i++)
            {
                ChartDBC.Series["ChartBDC"].Points.AddXY(ds.Rows[i]["thang"], ds.Rows[i]["doanhthu"]);
            }
            //ChartDBC.Series["ChartBDC"].Points.AddXY("Tháng 1", 1000);
            //ChartDBC.Series["ChartBDC"].Points.AddXY("Tháng 2", 3000);
            //ChartDBC.Series["ChartBDC"].Points.AddXY("Tháng 3", 1500);
            //ChartDBC.Series["ChartBDC"].Points.AddXY("Tháng 4", 2000);
            //ChartDBC.Series["ChartBDC"].Points.AddXY("Tháng 5", 5000);
        }
        void LoadDanhSachHoaDon()
        {
            dtgvtkhdbh.DataSource = HoadonDAO.Instance.LoadDanhSachHoaDon();
        }
        void LoadDanhSachHoaDonNhapHang()
        {
            dtgvttnh.DataSource = HoadonnhaphangDAO.Instance.LoadDanhSachHoaDonNhapHang();
        }
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpghead.Value = new DateTime(today.Year, today.Month, 1);
            dtpgend.Value = dtpghead.Value.AddMonths(1).AddDays(-1);
        }
        void LoadDateTimePickerBillNhapHang()
        {
            DateTime today = DateTime.Now;
            dtpkhead.Value = new DateTime(today.Year, today.Month, 1);
            dtpkend.Value = dtpghead.Value.AddMonths(1).AddDays(-1);
        }
        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgvtkhdbh.DataSource = HoadonDAO.Instance.GetlistByDate(checkIn, checkOut);
        }
        void LoadListBillByDateNhapHang(DateTime checkIn, DateTime checkOut)
        {
            dtgvttnh.DataSource = HoadonnhaphangDAO.Instance.GetlistByDateHoaDonNhapHang(checkIn, checkOut);
        }
        void LoadTongtien(DateTime checkIn, DateTime checkOut)
        {
            txbtt.Text = Convert.ToString(HoadonDAO.Instance.GetTongtien(checkIn, checkOut));
        }
        void LoadTongtienNhapHang(DateTime checkIn, DateTime checkOut)
        {
            txbtongtien1.Text = Convert.ToString(HoadonnhaphangDAO.Instance.GetTongtienHoaDonNhapHang(checkIn, checkOut));
        }
        void LoadTongtienkdk()
        {
            txbtt.Text = Convert.ToString(HoadonDAO.Instance.GetTongtienkdk());
        }
        void LoadTongtienkdkNhapHang()
        {
            txbtongtien1.Text = Convert.ToString(HoadonnhaphangDAO.Instance.GetTongtienkdkHoaDonNhapHang());
        }
        private void Bntthongke_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpghead.Value.Date, dtpgend.Value.Date);
            LoadTongtien(dtpghead.Value.Date, dtpgend.Value.Date);
        }

        private void Bntthongke1_Click(object sender, EventArgs e)
        {
            LoadListBillByDateNhapHang(dtpkhead.Value, dtpkend.Value);
            LoadTongtienNhapHang(dtpkhead.Value, dtpkend.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kn = "Data Source=.;Initial Catalog=quanlyshopdongho1;Integrated Security=True";
            string cl = "select MONTH(ngaylap) as thang, SUM(tongtien) as doanhthu FROM hoadonnhaphang  GROUP BY ngaylap";
            SqlConnection con = new SqlConnection(kn);
            SqlCommand cmd = new SqlCommand(cl, con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            ad.Fill(ds);
            con.Open();
            ChartDBC.DataSource = ds;
            //ChartDBC.Series["ChartBDC"].XValueMember = "thang";
            //ChartDBC.Series["ChartBDC"].YValueMembers = "doanhthu";
            for (int i = 0; i < ds.Rows.Count; i++)
            {
                ChartDBC.Series["ChartBDC"].Points.AddXY(ds.Rows[i]["thang"], ds.Rows[i]["doanhthu"]);
            }
            //ChartDBC.Series["ChartBDC"].Points.AddXY("Tháng 1", 1000);
            //ChartDBC.Series["ChartBDC"].Points.AddXY("Tháng 2", 3000);
            //ChartDBC.Series["ChartBDC"].Points.AddXY("Tháng 3", 1500);
            //ChartDBC.Series["ChartBDC"].Points.AddXY("Tháng 4", 2000);
            //ChartDBC.Series["ChartBDC"].Points.AddXY("Tháng 5", 5000);
        }

        void LoadLoaiThongKe()
        {
            cbktk.Items.Add("Thống kê theo ngày");
            cbktk.Items.Add("Thống kê theo tháng");
            cbktk.Items.Add("Thống kê theo năm");
            cbtkdhbc.Items.Add("Thống kê theo tháng");
            cbtkdhbc.Items.Add("Thống kê theo năm");
            int thang = DateTime.Now.Month;
            int nam = DateTime.Now.Year;
            DataTable ds = HoadonDAO.Instance.ThongKeDoanhThuTheoNgay(thang, nam);
            if (ds.Rows.Count <= 0)
            {
                MessageBox.Show("Không có dữ liệu");
            }
            ChartDBC.DataSource = ds;
            ChartDBC.Titles.Clear();
            ChartDBC.Titles.Add("Biểu đồ thống kê doanh thu theo ngày trong " + thang + " năm " + nam + "");
            ChartDBC.ChartAreas["ChartArea1"].AxisX.Title = "Ngày";
            ChartDBC.ChartAreas["ChartArea1"].AxisY.Title = "Doanh Thu";
            ChartDBC.Series["ChartBDC"].Points.Clear();
            for (int i = 0; i < ds.Rows.Count; i++)
            {
                ChartDBC.Series["ChartBDC"].Points.AddXY(ds.Rows[i]["thang"], ds.Rows[i]["doanhthu"]);
            }
            DataTable ds1 = CTHoadonDAO.Instance.ThongKeDongHoBanChay(nam, thang);
            if (ds.Rows.Count <= 0)
            {
                MessageBox.Show("Không có dữ liệu");
            }
            ChartTKDT.DataSource = ds1;
            ChartTKDT.Titles.Clear();
            ChartTKDT.Titles.Add("Biểu đồ thống kê đồng hồ bán chạy trong tháng " + thang + "  năm " + nam + "");
            ChartTKDT.ChartAreas["ChartArea1"].AxisX.Title = "Đồng hồ";
            ChartTKDT.ChartAreas["ChartArea1"].AxisY.Title = "Số lượng";
            ChartTKDT.Series["ChartTKDT"].Points.Clear();
            for (int i = 0; i < ds1.Rows.Count; i++)
            {
                ChartTKDT.Series["ChartTKDT"].Points.AddXY(ds1.Rows[i]["madh"], ds1.Rows[i]["soluong"]);
            }
        }

        private void cbktk_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbktk.Text.Contains("Thống kê theo ngày"))
            {
                cbc.Items.Clear();
                cbcn.Items.Clear();
                cbc.Items.Add(1);
                cbc.Items.Add(2);
                cbc.Items.Add(3);
                cbc.Items.Add(4);
                cbc.Items.Add(5);
                cbc.Items.Add(6);
                cbc.Items.Add(7);
                cbc.Items.Add(8);
                cbc.Items.Add(9);
                cbc.Items.Add(10);
                cbc.Items.Add(11);
                cbc.Items.Add(12);
                int x = 2020;
                int a = x;
                DateTime y = DateTime.Now;
                int z = y.Year;
                if ((z - x) > 0)
                {
                    for (int i = 0; i <= (z - a); i++)
                    {
                        cbcn.Items.Add(x);
                        x++;
                    }
                }
                else
                {
                    cbcn.Items.Add(x);
                }
                cbc.Enabled = true;
                cbcn.Enabled = true;
                if(cbc.Text != null && cbcn !=null)
                {
                    button1.Enabled = true;
                }
            }
            else if (cbktk.Text.Contains("Thống kê theo tháng"))
            {
                cbc.Enabled = false;
                cbcn.Enabled = true;
                cbc.Items.Clear();
                cbcn.Items.Clear();
                int x = 2020;
                int a = x;
                DateTime y = DateTime.Now;
                int z = y.Year;
                if ((z - x) > 0)
                {
                    for (int i = 0; i <= (z - a); i++)
                    {
                        cbcn.Items.Add(x);
                        x++;
                    }
                }
                else
                {
                    cbcn.Items.Add(x);
                }
            }
            else if(cbktk.Text.Contains("Thống kê theo năm"))
            {
                cbc.Items.Clear();
                cbcn.Items.Clear();
                cbc.Enabled = false;
                cbcn.Enabled = false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (cbktk.Text.Contains("Thống kê theo ngày"))
            {
                if(cbc.Text != "" && cbcn.Text != "")
                {
                    int thang = int.Parse(cbc.Text);
                    int nam = int.Parse(cbcn.Text);
                    DataTable ds = HoadonDAO.Instance.ThongKeDoanhThuTheoNgay(thang, nam);
                    if (ds.Rows.Count <= 0)
                    {
                        MessageBox.Show("Không có dữ liệu");
                    }
                    ChartDBC.DataSource = ds;
                    ChartDBC.Titles.Clear();
                    ChartDBC.Titles.Add("Biểu đồ thống kê doanh thu theo ngày trong " + thang + " năm " + nam + "");
                    ChartDBC.ChartAreas["ChartArea1"].AxisX.Title = "Ngày";
                    ChartDBC.ChartAreas["ChartArea1"].AxisY.Title = "Doanh Thu";
                    ChartDBC.Series["ChartBDC"].Points.Clear();
                    for (int i = 0; i < ds.Rows.Count; i++)
                    {
                        ChartDBC.Series["ChartBDC"].Points.AddXY(ds.Rows[i]["thang"], ds.Rows[i]["doanhthu"]);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin thống kê");
                }
                
            }
            else if (cbktk.Text.Contains("Thống kê theo tháng"))
            {
                if(cbcn.Text != "")
                {
                    int nam = int.Parse(cbcn.Text);
                    DataTable ds = HoadonDAO.Instance.ThongKeDoanhThuTheoThang(nam);
                    if (ds.Rows.Count <= 0)
                    {
                        MessageBox.Show("Không có dữ liệu");
                    }
                    ChartDBC.DataSource = ds;
                    ChartDBC.Titles.Clear();
                    ChartDBC.Titles.Add("Biểu đồ thống kê doanh thu theo tháng trong năm " + nam + "");
                    ChartDBC.ChartAreas["ChartArea1"].AxisX.Title = "Tháng";
                    ChartDBC.ChartAreas["ChartArea1"].AxisY.Title = "Doanh Thu";
                    ChartDBC.Series["ChartBDC"].Points.Clear();
                    for (int i = 0; i < ds.Rows.Count; i++)
                    {
                        ChartDBC.Series["ChartBDC"].Points.AddXY(ds.Rows[i]["thang"], ds.Rows[i]["doanhthu"]);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin thống kê");
                }
                

            }
            else if (cbktk.Text.Contains("Thống kê theo năm"))
            {
                DataTable ds = HoadonDAO.Instance.ThongKeDoanhThuTheoNam();
                if (ds.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
                ChartDBC.DataSource = ds;
                ChartDBC.Titles.Clear();
                ChartDBC.Titles.Add("Biểu đồ thống kê doanh thu theo năm");
                ChartDBC.ChartAreas["ChartArea1"].AxisX.Title = "Năm";
                ChartDBC.ChartAreas["ChartArea1"].AxisY.Title = "Doanh Thu";
                ChartDBC.Series["ChartBDC"].Points.Clear();
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    ChartDBC.Series["ChartBDC"].Points.AddXY(ds.Rows[i]["thang"], ds.Rows[i]["doanhthu"]);
                }
            }
        }

        private void cbtkdhbc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbtkdhbc.Text.Contains("Thống kê theo tháng"))
            {
                cbcttk.Items.Clear();
                cbcttk.Items.Clear();
                cbcttk.Items.Add(1);
                cbcttk.Items.Add(2);
                cbcttk.Items.Add(3);
                cbcttk.Items.Add(4);
                cbcttk.Items.Add(5);
                cbcttk.Items.Add(6);
                cbcttk.Items.Add(7);
                cbcttk.Items.Add(8);
                cbcttk.Items.Add(9);
                cbcttk.Items.Add(10);
                cbcttk.Items.Add(11);
                cbcttk.Items.Add(12);
                int x = 2020;
                int a = x;
                DateTime y = DateTime.Now;
                int z = y.Year;
                if ((z - x) > 0)
                {
                    for (int i = 0; i <= (z - a); i++)
                    {
                        cbcntk.Items.Add(x);
                        x++;
                    }
                }
                else
                {
                    cbcntk.Items.Add(x);
                }
                cbcttk.Enabled = true;
                cbcntk.Enabled = true;
                if (cbcttk.Text != null && cbcntk.Text != null)
                {
                    button1.Enabled = true;
                }
            }
            else if (cbtkdhbc.Text.Contains("Thống kê theo năm"))
            {
                cbcttk.Enabled = false;
                cbcntk.Enabled = true;
                cbcttk.Items.Clear();
                cbcntk.Items.Clear();
                int x = 2020;
                int a = x;
                DateTime y = DateTime.Now;
                int z = y.Year;
                if ((z - x) > 0)
                {
                    for (int i = 0; i <= (z - a); i++)
                    {
                        cbcntk.Items.Add(x);
                        x++;
                    }
                }
                else
                {
                    cbcntk.Items.Add(x);
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cbtkdhbc.Text.Contains("Thống kê theo tháng"))
            {
                if(cbcttk.Text != "" && cbcntk.Text != "")
                {
                    int thang = int.Parse(cbcttk.Text);
                    int nam = int.Parse(cbcntk.Text);
                    DataTable ds = CTHoadonDAO.Instance.ThongKeDongHoBanChay(nam, thang);
                    if (ds.Rows.Count <= 0)
                    {
                        MessageBox.Show("Không có dữ liệu");
                    }
                    ChartTKDT.DataSource = ds;
                    ChartTKDT.Titles.Clear();
                    ChartTKDT.Titles.Add("Biểu đồ thống kê đồng hồ bán chạy trong tháng " + thang + "  năm " + nam + "");
                    ChartTKDT.ChartAreas["ChartArea1"].AxisX.Title = "Đồng hồ";
                    ChartTKDT.ChartAreas["ChartArea1"].AxisY.Title = "Số lượng";
                    ChartTKDT.Series["ChartTKDT"].Points.Clear();
                    for (int i = 0; i < ds.Rows.Count; i++)
                    {
                        ChartTKDT.Series["ChartTKDT"].Points.AddXY(ds.Rows[i]["madh"], ds.Rows[i]["soluong"]);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin thống kê");
                }


            }
            else if (cbtkdhbc.Text.Contains("Thống kê theo năm"))
            {
                if(cbcntk.Text != "")
                {
                    int nam = int.Parse(cbcntk.Text);
                    DataTable ds = CTHoadonDAO.Instance.ThongKeDongHoBanChay(nam, null);
                    if (ds.Rows.Count <= 0)
                    {
                        MessageBox.Show("Không có dữ liệu");
                    }
                    ChartTKDT.DataSource = ds;
                    ChartTKDT.Titles.Clear();
                    ChartTKDT.Titles.Add("Biểu đồ thống kê đồng hồ bán chạy trong năm " + nam + "");
                    ChartTKDT.ChartAreas["ChartArea1"].AxisX.Title = "Đồng hồ";
                    ChartTKDT.ChartAreas["ChartArea1"].AxisY.Title = "Số lượng";
                    ChartTKDT.Series["ChartTKDT"].Points.Clear();
                    for (int i = 0; i < ds.Rows.Count; i++)
                    {
                        ChartTKDT.Series["ChartTKDT"].Points.AddXY(ds.Rows[i]["madh"], ds.Rows[i]["soluong"]);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin thống kê");
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dl = HoadonDAO.Instance.InBaoCaoBanHang(dtpghead.Value, dtpgend.Value);
            if (MessageBox.Show("Bạn có muốn in báo cáo thống kê?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                ReportBaoCaoThongKeBanHang bctkhdbh = new ReportBaoCaoThongKeBanHang();
                bctkhdbh.DataSource = dl;
                bctkhdbh.ShowPreviewDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dl = HoadonnhaphangDAO.Instance.InBaoCaoThongKeNhapHang(dtpkhead.Value, dtpkend.Value);
            if (MessageBox.Show("Bạn có muốn in báo cáo thống kê?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                ReportBaoCaoThongKeNhapHanh bctkhdbh = new ReportBaoCaoThongKeNhapHanh();
                bctkhdbh.DataSource = dl;
                bctkhdbh.ShowPreviewDialog();
            }
        }
    }
}

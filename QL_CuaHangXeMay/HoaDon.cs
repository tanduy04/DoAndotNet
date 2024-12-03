using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_CuaHangXeMay
{
    public partial class HoaDon : Form
    {
        private string Mahd;
        public HoaDon(string mahd)
        {
            InitializeComponent();
            Mahd = mahd;
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                lb_MHD.Text = Mahd;

                DBConnect db = new DBConnect();
                DataTable dt = db.getDataTable("select hd.MaHD,kh.HoTenKH,hd.MaHD,hd.NgayLap,hd.TongTien from KhachHang kh,HoaDon hd where kh.MaKH = hd.MaKH and hd.MaHD = " + Mahd);
                lb_TenKH.Text = dt.Rows[0]["HoTenKH"].ToString();
                lb_NgayTao.Text = dt.Rows[0]["NgayLap"].ToString();
                lb_TongTien.Text = dt.Rows[0]["TongTien"].ToString();
                dataGridView1.DataSource = db.getDataTable("select *from ChiTietHoaDon where MaHD = " + Mahd);
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi không tìm thấy thông tin hoá đơn");
            }
        }
    }
}

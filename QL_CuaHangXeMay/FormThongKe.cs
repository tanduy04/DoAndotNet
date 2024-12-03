using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace QL_CuaHangXeMay
{
    public partial class FormThongKe : Form
    {
        private string filename = @"../Desktop/ThongKe_HoaDon.xlsx";
        public FormThongKe()
        {
            InitializeComponent();
        }

        private void FormThongKe_Load(object sender, EventArgs e)
        {
            LoadDataGv();

        }
        private void LoadDataGv()
        {
            DBConnect db = new DBConnect();
            dataGridView1.DataSource = db.getDataTable("select hd.MaHD,kh.HoTenKH,hd.MaHD,hd.NgayLap,hd.TongTien from KhachHang kh,HoaDon hd where kh.MaKH = hd.MaKH");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            txt_mahd.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
        }
        private void WriteExcel(string filename)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = excel.Workbooks.Open(filename);
            Worksheet ws = wb.Worksheets[1];

            for(int i = 1; i < dataGridView1.RowCount; i++)
            {
                Range cell = ws.Range["A"+i+":E"+i];
            }

            wb.SaveAs(filename);
            wb.Close();
            

            Process.Start(filename);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WriteExcel(filename);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                HoaDon fromHD = new HoaDon(txt_mahd.Text);
                fromHD.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi không tìm thấy thông tin hoá đơn");
            }
        }

        private void btn_DelHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DBConnect db = new DBConnect();
                    string sql = "delete from ChiTietHoaDon where MaHD = "+txt_mahd.Text;
                    int kq = db.getNonQuery(sql);
                    sql = "delete from HoaDon where MaHD =" + txt_mahd.Text;
                    kq = db.getNonQuery(sql);
                    if (kq == 0)
                    {
                        MessageBox.Show("Xóa không Thành Công!");
                        LoadDataGv();
                    }
                    else
                    {
                        MessageBox.Show("Xóa Thành Công!");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi không tìm thấy thông tin hoá đơn");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadDataGv();
        }
    }
}

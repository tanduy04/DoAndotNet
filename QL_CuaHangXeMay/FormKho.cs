using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;
using System.Data.SqlClient;

namespace QL_CuaHangXeMay
{
    public partial class FormKho : Form
    {
        DBConnect db = new DBConnect();
        public FormKho()
        {
            InitializeComponent();
        }


        private void FormKho_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = db.getDataTable("select MaXe, TenXe, SoLuongTonKho from XeMay");
            dataGridView2.DataSource = db.getDataTable("select * from PhieuNhap");

            NVNhap.DataSource = db.getDataTable("select * from NhanVien");
            NVNhap.DisplayMember = "HoTenNV";
            NVNhap.ValueMember = "MaNV";

            NhaCC.DataSource = db.getDataTable("select * from NhaCungCap");
            NhaCC.DisplayMember = "TenNCC";
            NhaCC.ValueMember = "MaNCC";

            LoaiXe.DataSource = db.getDataTable("select * from XeMay");
            LoaiXe.DisplayMember = "TenXE";
            LoaiXe.ValueMember = "MaXE";

            dataGridView3.ColumnCount = 6; // Số lượng cột
            dataGridView3.Columns[0].Name = "Nhà Cung Cấp";
            dataGridView3.Columns[1].Name = "Tên Xe";
            dataGridView3.Columns[2].Name = "Nhân Viên Nhập";
            dataGridView3.Columns[3].Name = "Giá Nhập";
            dataGridView3.Columns[4].Name = "Số Lượng";
            dataGridView3.Columns[5].Name = "Ngày Nhập";


            NgayNhap.Value = DateTime.Now;

        }




        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value.Date;
            string formattedDate = date.ToString("yyyy-MM-dd");


            string query = "SELECT * FROM PhieuNhap WHERE CAST(NgayLap AS DATE) = @NgayLap";
            using (SqlConnection conn = new SqlConnection(db.chuoiketnoi))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NgayLap", date);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);


                dataGridView2.DataSource = dataTable;
            }


        }



        private void tenSP_Click(object sender, EventArgs e)
        {
            if (tenSP.ForeColor == Color.Silver)
            {
                tenSP.Text = "";
            }
            tenSP.ForeColor = Color.Black;
        }
        private void tenSP_Leave(object sender, EventArgs e)
        {
            if (tenSP.Text.Length == 0)
            {
                tenSP.Text = "Tìm Kiếm";
                tenSP.ForeColor = Color.Silver;
            }
        }

        private void btnSearchKho_Click(object sender, EventArgs e)
        {
            string ten = "";
            btnSearch.Cursor = Cursors.Hand;
            if (tenSP.ForeColor == Color.Black)
            {
                ten = tenSP.Text;
            }

            DBConnect db = new DBConnect();
            string sql = "SELECT * FROM XeMay WHERE TenXe LIKE '%" + ten + "%'";
            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Mời Bạn Nhập Tên Xe!");
                dataGridView1.DataSource = db.getDataTable("select MaXe, TenXe, SoLuongTonKho from XeMay");
            }
            else
            {
                dataGridView1.DataSource = db.getDataTable(sql);

            }
        }



        // khong cho nhap ki tu
        private void GiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void SoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }






        private void button2_Click(object sender, EventArgs e)
        {

            DateTime ngaynhap = DateTime.Now;
            string nhanvien = NVNhap.Text;
            string ncc = NhaCC.Text;
            string tenxe = LoaiXe.Text;
            decimal gianhap = 0;
            int soluong = 0;
            if (!string.IsNullOrWhiteSpace(GiaNhap.Text))
            {
                gianhap = decimal.Parse(GiaNhap.Text);
            }
            if (!string.IsNullOrWhiteSpace(SoLuong.Text))
            {
                soluong = Int32.Parse(SoLuong.Text);
            }


            // Kiểm tra đầy đủ thông tin
            if (ngaynhap == DateTime.MinValue ||
                string.IsNullOrWhiteSpace(nhanvien) ||
                string.IsNullOrWhiteSpace(ncc) ||
                string.IsNullOrWhiteSpace(tenxe) || gianhap == 0 || soluong == 0)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            dataGridView3.Rows.Add(ncc, tenxe, nhanvien, gianhap, soluong, ngaynhap);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (dataGridView3.SelectedRows.Count > 0)
                {

                    foreach (DataGridViewRow row in dataGridView3.SelectedRows)
                    {

                        if (!row.IsNewRow)
                        {
                            dataGridView3.Rows.Remove(row);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một dòng để xóa!");
                }
            }
            catch
            {

            }
        }


        private void NhapHang_Click(object sender, EventArgs e)
        {
            DateTime ngaynhap = DateTime.Now;
            decimal tongtien = 0;

            foreach (DataGridViewRow row in dataGridView3.Rows)
            {

                if (row.IsNewRow) continue;

                decimal giaNhap = decimal.Parse(row.Cells[3].Value.ToString());
                int soLuong = int.Parse(row.Cells[4].Value.ToString());
                tongtien += (giaNhap * soLuong);

            }

            string sqlPhieuNhap = "insert into PhieuNhap(NgayLap, TongTien)" + " values('" + ngaynhap.ToString("yyyy-MM-dd") + "', '" + tongtien + "')";
            db.getNonQuery(sqlPhieuNhap);


            string sqllayMaPN = "select Max(MaPN) from PhieuNhap";

            int MaPN = 0;

            using (SqlConnection connection = new SqlConnection(db.chuoiketnoi))
            {
                try
                {
                    connection.Open(); // Mở kết nối

                    SqlCommand command = new SqlCommand(sqllayMaPN, connection);
                    MaPN = (int)command.ExecuteScalar(); // Thực thi câu lệnh và lấy giá trị đầu tiên (OrderCode)


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }


                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    // Kiểm tra tránh xóa dòng mới trống
                    if (row.IsNewRow) continue;

                    // Lấy các giá trị từ các ô trong dòng

                    string nhaCungCap = row.Cells[0].Value.ToString();
                    string tenxe = row.Cells[1].Value.ToString();
                    string nhanVien = row.Cells[2].Value.ToString();
                    decimal giaNhap = decimal.Parse(row.Cells[3].Value.ToString());
                    int soLuong = int.Parse(row.Cells[4].Value.ToString());


                    int manv = Convert.ToInt32(NVNhap.SelectedValue);
                    int maxe = Convert.ToInt32(LoaiXe.SelectedValue);
                    int mancc = Convert.ToInt32(NhaCC.SelectedValue);


                    tongtien += (giaNhap * soLuong);


                    string sqlCTPhieuNhap = "insert into ChiTietPhieuNhap(MaPN, MaXe, MaNCC, MaNV, SoLuong, GiaBan)" + " values('" + MaPN + "', '" + maxe + "', '" + mancc + "', '" + manv + "', '" + soLuong + "', '" + giaNhap + "')";


                    string sqlCapNhapSLTon = "UPDATE XeMay SET SoLuongTonKho = SoLuongTonKho + " + soLuong + " WHERE MaXe = '" + maxe + "'";

                                     
                    db.getNonQuery(sqlCTPhieuNhap);
                    db.getNonQuery(sqlCapNhapSLTon);
                }


            }
            MessageBox.Show("Nhập Hàng Thành Công!");
            dataGridView2.DataSource = db.getDataTable("select * from PhieuNhap");

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
               
                var value = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                CTPhieuNhap form2 = new CTPhieuNhap(Int32.Parse(value));
                form2.Show();
            }
            else
            {
                MessageBox.Show("Chưa chọn dòng nào.");
            }

            
        }
   
    



    
    }
}
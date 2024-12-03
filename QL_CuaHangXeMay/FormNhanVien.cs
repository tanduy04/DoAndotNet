using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace QL_CuaHangXeMay
{
    public partial class FormNhanVien : Form
    {
        public FormNhanVien()
        {
            InitializeComponent();
        }

        public void HienThiDS()
        {
            DBConnect db = new DBConnect();
            dataGridView1.DataSource = db.getDataTable("select * from NhanVien");

        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            HienThiDS();
            //maNV.ReadOnly = true;
            //maNV.Enabled = false;
        }


        // reset textbox
        private void btnReset_Click(object sender, EventArgs e)
        {
            maNV.Clear();
            hoten.Clear();
            sdt.Clear();
            quequan.Clear();
            email.Clear();
            taikhoan.Clear();
            matkhau.Clear();
            radioNam.Checked = false;
            radioNu.Checked = false;
        }

        // chuc nang them nv
        private void btnThem_Click(object sender, EventArgs e)
        {


            string hten = hoten.Text;
            string qquan = quequan.Text;
            string dthoai = sdt.Text;
            string mail = email.Text;
            string tk = taikhoan.Text;
            string mk = matkhau.Text;
            DateTime nsinh = ngaysinh.Value;

            string gtinh = "null";
            if (radioNam.Checked)
                gtinh = "Nam";
            else if (radioNu.Checked)
                gtinh = "Nữ";

            // check day du tt
            if (string.IsNullOrWhiteSpace(hten) ||
                string.IsNullOrWhiteSpace(qquan) ||
                string.IsNullOrWhiteSpace(dthoai) ||
                string.IsNullOrWhiteSpace(mail) ||
                string.IsNullOrWhiteSpace(tk) ||
                string.IsNullOrWhiteSpace(mk) ||
                nsinh == DateTime.MinValue ||
                gtinh == "null")

            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }


            DBConnect db = new DBConnect();
            string sql = "INSERT INTO NhanVien (HoTenNV, QueQuan, NgaySinhNV, SoDienThoaiNV, GioiTinh, EmailNV, TaiKhoan, MatKhau, QuyenID) " +
                         "VALUES ('" + hten + "', '" + qquan + "', '" + nsinh.ToString("yyyy-MM-dd") + "', '" +
                         dthoai + "', '" + gtinh + "', '" + mail + "', '" + tk + "', '" + mk + "', '" + 2 + "')";
            int kq = db.getNonQuery(sql);

            if (kq > 0)
            {
                MessageBox.Show("Đã Thêm Thành Công!");
            }
            else
            {
                MessageBox.Show("Thêm Thất Bại!");
            }

            HienThiDS();

        }

        // lay tt NV len textbox
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int i = dataGridView1.CurrentRow.Index;
            maNV.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            hoten.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            sdt.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            quequan.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            ngaysinh.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            email.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            taikhoan.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            matkhau.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();

            if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "Nam")
            {
                radioNam.Checked = true;
            }
            else
            {
                radioNu.Checked = true;
            }

        }


        // xoa nhan vien
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string manv = maNV.Text;

            if (string.IsNullOrWhiteSpace(manv))
            {
                MessageBox.Show("Không Tìm Thấy Nhân Viên!");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DBConnect db = new DBConnect();
                string sql = "delete from NhanVien where MaNV = '" + manv + "' ";
                int kq = db.getNonQuery(sql);
                if (kq == 0)
                {
                    MessageBox.Show("Xóa không Thành Công!");

                }
                else
                {
                    MessageBox.Show("Xóa Thành Công!");

                }
            }
            HienThiDS();

        }


        // sua thong tin nhan vien
        private void btnSua_Click(object sender, EventArgs e)
        {
            string manv = maNV.Text;
            if (string.IsNullOrWhiteSpace(manv))
            {
                MessageBox.Show("Không Tìm Thấy Nhân Viên!");
                return;
            }
            DateTime nsinh = ngaysinh.Value;
            string gioitinh;
            if (radioNam.Checked == true)
            {
                gioitinh = "Nam";
            }
            else
            {
                gioitinh = "Nữ";
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa lại thông tin của nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DBConnect db = new DBConnect();
                string sql = "UPDATE NhanVien SET HoTenNV = '" + hoten.Text + "', QueQuan = '" + quequan.Text + "', NgaySinhNV = '" + nsinh + "'," +
                    "SoDienThoaiNV = '" + sdt.Text + "', GioiTinh = '" + gioitinh + "', EmailNV = '" + email.Text + "', TaiKhoan = '" + taikhoan.Text + "', " +
                    "MatKhau = '" + matkhau.Text + "' where MaNV = '" + manv + "' ";
                int kq = db.getNonQuery(sql);
                if (kq == 0)
                {
                    MessageBox.Show("Sửa không Thành Công!");

                }
                else
                {
                    MessageBox.Show("Sửa Thành Công!");

                }
            }
            HienThiDS();
        }


        // chuc tim kiem
        private void textBox8_Click(object sender, EventArgs e)
        {
            if (textBox8.ForeColor == Color.Silver)
            {
                textBox8.Text = "";
            }
            textBox8.ForeColor = Color.Black;

        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (textBox8.Text.Length == 0)
            {
                textBox8.Text = "Tìm Kiếm";
                textBox8.ForeColor = Color.Silver;
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string ten = "";
            btnSearch.Cursor = Cursors.Hand;
            if (textBox8.ForeColor == Color.Black)
            {
                ten = textBox8.Text;
            }



            DBConnect db = new DBConnect();
            string sql = "SELECT * FROM NhanVien WHERE HoTenNV LIKE '%" + ten + "%'";
            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Mời Bạn Nhập Tên!");
                HienThiDS();
            }
            else
            {
                dataGridView1.DataSource = db.getDataTable(sql);

            }

        }


        // xuat file excel
        private void btnExcel_Click(object sender, EventArgs e)
        {

           
            Excel.Application app = new Excel.Application();
            app.Visible = true; 
            Excel.Workbook wbook = app.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet wsheet = (Excel.Worksheet)wbook.Worksheets[1];

     
            Excel.Range titleCell = wsheet.Range["D2"];
            titleCell.Font.Size = 20;
            titleCell.Font.Bold = true;
            titleCell.Value = "Danh Sách Nhân Viên";
            titleCell.Font.Color = Color.Red;


            string[] headers = {
                "Mã Nhân Viên",
                "Tên Nhân Viên",
                "Quê Quán",
                "Ngày Sinh",
                "Số Điện Thoại",
                "Giới Tính",
                "Email",
                "Tài Khoản",
                "Mật Khẩu",
                "Quyền"
            };

            for (int i = 0; i < headers.Length; i++)
            {
                Excel.Range cell = wsheet.Cells[4, i + 1]; 
                cell.Value = headers[i];
                cell.Font.Bold = true;
                cell.Interior.Color = Color.LightGray; 
            }


            int dong = 5;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                   
                    if (j < 10) 
                    {
                        //wsheet.Cells[dong + i, j + 1] = dataGridView1.Rows[i].Cells[j].Value?.ToString() ?? "";
                        object cellValue = dataGridView1.Rows[i].Cells[j].Value;

                        // Kiểm tra nếu cellValue khác null, chuyển đổi thành chuỗi; ngược lại, gán chuỗi trống
                        string cellText = (cellValue != null) ? cellValue.ToString() : "";

                        // Gán giá trị vào ô trong wsheet
                        wsheet.Cells[dong + i, j + 1] = cellText;

                    }
                }
            }

          
            wsheet.Columns.AutoFit();   
            wbook.Activate();

        

        }
    }
}
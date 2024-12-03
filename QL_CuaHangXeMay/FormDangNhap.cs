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
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Hiển thị mật khẩu
                txtMK.UseSystemPasswordChar = false;
            }
            else
            {
                // Ẩn mật khẩu
                txtMK.UseSystemPasswordChar = true;
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTK.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản");
                return;
            }
            if (string.IsNullOrEmpty(txtMK.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");
                return;
            }
            string taiKhoan = txtTK.Text;
            string matKhau = txtMK.Text;
            DBConnect db = new DBConnect();
            DataTable dt = new DataTable();
            string query = "SELECT COUNT(*) FROM NhanVien WHERE taiKhoan='" + taiKhoan + "' and MatKhau='" + matKhau + "'";
            int kq = db.getScalar(query);
            if (kq > 0)
            {
                string truyvan = "SELECT * FROM NhanVien,QuyenTruyCap WHERE TaiKhoan='" + taiKhoan + "' AND NhanVien.QuyenID=QuyenTruyCap.QuyenID";
                dt = db.getDataTable(truyvan);
                DataRow nv = dt.Rows[0]; // Lấy dòng đầu tiên

                // Truy xuất các giá trị từ các cột trong dòng đầu tiên
                string TENNV = nv["HoTenNV"].ToString(); // Thay 'ten_cot_1' bằng tên cột cụ thể
                string Quyen = nv["TenQuyen"].ToString();
                FormMenu menu = new FormMenu(TENNV,Quyen);
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại!");
            }




        }

        private void FormDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }






    }
}

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
    public partial class FormMenu : Form
    {
        string ten;
        string quyen;
        public FormMenu( string TenNV,string Quyen)
        {
            InitializeComponent();
            ten = TenNV;
            quyen = Quyen;
            InitializeMenu();
        }
        private void InitializeMenu()
        {
            // Hiển thị tên nhân viên
            label2.Text =quyen+":"+ ten;

            // Kiểm tra quyền để hiển thị/ẩn nút
            if (quyen=="Quản lý") // Quản lý
            {
                // Hiển thị tất cả các nút
                btnFormNV.Visible = true;
                btnFormThongKe.Visible = true;
            }
            else if (quyen == "Nhân viên bán hàng") // Nhân viên
            {
                // Ẩn nút nhân viên
                btnFormNV.Visible = false;
                btnFormThongKe.Visible = false;
            }
        }
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock= DockStyle.Fill;
            panel_body.Controls.Add(childForm);
            panel_body.Tag  = childForm;
            childForm.BringToFront();
            childForm.Show();
            nameform.Text = childForm.Text;

        }

        private void btnFormKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormKhachHang());
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            date.Text ="Ngày: "+ DateTime.Now.ToString();
            OpenChildForm(new FormTrangChu());
            
        }

        private void btnFormXe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormXe());
        }

        private void btnFormHangXe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormHangXe());
        }

        private void btnFormHoaDon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormTaoHoaDon());
        }

        private void btnFormNV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormNhanVien());
        }

        private void btnFormThongKe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormThongKe());
        }

        private void btn_FormTrangChu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormTrangChu());
        }

        private void btnFormDangXuat_Click(object sender, EventArgs e)
        {
            FormDangNhap dn= new FormDangNhap();
            dn.Show();
            this.Hide();
        }
        private void btn_Kho_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormKho());
        }

        private void FormMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đóng ứng dụng không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                e.Cancel = true; // Hủy sự kiện đóng form
            }
        }

        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        
    }
}

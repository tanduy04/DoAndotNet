// Chạy code nhớ: Sửa đường dẫn hình ảnh
// Chỗ btn_HinhAnh nếu thay đổi forder hình ảnh để lưu trữ -- nhớ sửa lại tên
// PictureBox thì cho SizeMode --> Zoom để lấy hết ảnh cho đẹp

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// -------------------------------------------
// su dung them 1 vaithu vien cua database
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.Sql;
using System.IO;
namespace QL_CuaHangXeMay
{
    public partial class FormXe : Form
    {
        public FormXe()
        {
            InitializeComponent();
        }

        void HienThi_DsXe()
        {

            // Goi xuat bang Xe
            string s = "select * from XeMay";
            DBConnect db = new DBConnect();
            DataTable dt = db.getDataTable(s);
            dgv_Xe.DataSource = dt;

            DataColumn[] XeMay = new DataColumn[1];

            XeMay[0] = dt.Columns["MaXe"];
            dt.PrimaryKey = XeMay;

        }
        private void FormXe_Load(object sender, EventArgs e)
        {
            // goi xuat bang xe may
            string s = @"select * from HangXe ";
            DBConnect db = new DBConnect();
            DataTable dt = db.getDataTable(s);

            // Them khoa Chinh
            DataColumn[] key = new DataColumn[1];
            key[0] = dt.Columns[0];
            dt.PrimaryKey = key;

            // Xuat dl ra ccb_Ma va ccb_Ten
            ccb_HangXe.DataSource = dt;
            ccb_HangXe.DisplayMember = "MaHX";
            ccb_HangXe.ValueMember = "MaHX";
            ccb_HangXe.SelectedIndex = 0;

            // xaut bang datagridview
            HienThi_DsXe();
        }


        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (dgv_Xe.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgv_Xe.SelectedRows[0];
                int maXe = Convert.ToInt32(selectedRow.Cells["MaXe"].Value); // Lấy mã xe

                    DBConnect db = new DBConnect();
                    string query = "DELETE FROM XeMay WHERE MaXe = @MaXe";
                    SqlCommand cmd = new SqlCommand(query, db.con);
                    cmd.Parameters.AddWithValue("@MaXe", maXe);

                    db.Open();
                    int result = cmd.ExecuteNonQuery();
                    db.Close();

                    if (result > 0)
                    {
                        MessageBox.Show("Xóa xe máy thành công.");
                        HienThi_DsXe(); // Cập nhật danh sách hiển thị
                        Xoa_CheckBox_DaNhap();
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công.");
                    }
             
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng xe máy để xóa.");
            }
        }


        private void Xoa_CheckBox_DaNhap()
        {
            txt_TenXe.Clear();
            txt_MauXe.Clear();
            txt_GiaXe.Clear();
            txt_SLTon.Clear();
            txt_HinhAnh.Clear();

            ccb_HangXe.SelectedIndex = -1; // Đặt lại ComboBox
            ck_ABS.Checked = false;
            ck_SmartKey.Checked = false;
            ck_SacDT.Checked = false;
        }

        private void btn_ChonHAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_file = new OpenFileDialog();
            // thêm một số tên từ bộ lọc với
            // "..tên 1..|định dạng của file (.png hay .jpg)|..tên 2.. | định dạng của file 2"
            open_file.Filter = "file hinh|*.jpg; *.png; *.gif; *.webp; *.sgv|all file|*.*";
            open_file.InitialDirectory = @"\ImagXe\";

            // Neu chon file --> an OK (DialogResult.OK) 
            // Khong chon file -- an Cancel (DialogResult.CANCEL)
            if (open_file.ShowDialog() == DialogResult.OK)
            {
                string[] dsfile = open_file.FileNames;
                foreach (string tenfile in dsfile)
                {
                    FileInfo f = new FileInfo(tenfile);
                    string[] catchuoi = tenfile.Split('\\'); // cat chuoi --> lay chuoi phia sau '\\'

                    string d = Directory.GetParent(Application.StartupPath).Parent.FullName; // dua chuoi vao sau 3 LOP CHA 
                                                                                             // LOP CHA 1 =.GetParent(Application.StartupPath) -- LOP CHA 2 = __Parent.__
                    string des = d + @"\ImagXe\" + catchuoi[catchuoi.Length - 1]; // file HinhAnh nay da duoc tao trong bai

                    if (File.Exists(des))
                        File.Delete(des);

                    // copy file da chon vào ImagXe
                    f.CopyTo(des);

                    // hienthi
                    picture_HinhAnh.Image = Image.FromFile(des);

                    // Hiển thị tên file mà không bao gồm đường dẫn
                    txt_HinhAnh.Text = System.IO.Path.GetFileName(tenfile);


                }

                MessageBox.Show("Chon File Hinh -- Thanh Cong");
                open_file.Dispose(); // xoa di cho giam bo nho
            }
            else
            {
                MessageBox.Show("Chon That Bai");
            }
        }

        private void txt_HinhAnh_TextChanged(object sender, EventArgs e)
        {
            // Lấy tên file từ TextBox
            string tenHinhAnh = txt_HinhAnh.Text.Trim();

            // Tạo đường dẫn đầy đủ tới hình ảnh
            string duongDanHinhAnh = "D:\\HUIT\\HK5\\dotNET\\DoAndotNet\\DoAn.Net\\QL_CuaHangXeMay\\ImagXe\\"+tenHinhAnh;

            // Kiểm tra xem file có tồn tại không
            if (System.IO.File.Exists(duongDanHinhAnh))
            {
                // Nếu file tồn tại, hiển thị hình ảnh trong PictureBox
                picture_HinhAnh.Image = Image.FromFile(duongDanHinhAnh);

                // Hiển thị tên file mà không bao gồm đường dẫn
                txt_HinhAnh.Text = System.IO.Path.GetFileName(tenHinhAnh);
            }
            else
            {
                // Nếu file không tồn tại, có thể đặt hình ảnh mặc định hoặc xóa hình ảnh
                picture_HinhAnh.Image = null; // Hoặc đặt hình ảnh mặc định
                //MessageBox.Show("Hình ảnh không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void dgv_Xe_Click(object sender, EventArgs e)
        {
            if (dgv_Xe.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgv_Xe.SelectedRows[0];
                // Lấy các thông tin cần thiết từ hàng đã chọn
                int maXe = Convert.ToInt32(selectedRow.Cells["MaXe"].Value);
                string tenXe = selectedRow.Cells["TenXe"].Value.ToString();
                // Lấy các thuộc tính khác từ cơ sở dữ liệu để cập nhật checkbox
                LoadXeMayDetails(maXe);
            }
        }


        private void LoadXeMayDetails(int maXe)
        {
            
                DBConnect db = new DBConnect();
                string query = "SELECT ABS, SmartKey, SacDT FROM XeMay WHERE MaXe = @MaXe"; // Điều chỉnh truy vấn nếu cần
                SqlCommand cmd = new SqlCommand(query, db.con);
                cmd.Parameters.AddWithValue("@MaXe", maXe);

                db.Open();
                
                db.Close();

        }

        private void logo_search_Click(object sender, EventArgs e)
        {
            string ten = "";
            logo_search.Cursor = Cursors.Hand;

            ten = txtSearch.Text;


            DBConnect db = new DBConnect();
            string sql = "SELECT * FROM XeMay WHERE TenXe LIKE '%" + ten + "%'";
            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Mời Bạn Nhập Tên!");
                HienThi_DsXe();
            }
            else
            {
                dgv_Xe.DataSource = db.getDataTable(sql);

            }
        }

        private void dgv_Xe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // khi click vao cac gia tri tren bang dgv -- se hien thi tren ccb, txt,... 
            int dongchon = e.RowIndex;
            //string ma = ccb_MaHangXe.SelectedValue.ToString();
            //string ten = ccb_TenHangXe .SelectedValue.ToString();

            ccb_HangXe.Text = dgv_Xe.Rows[dongchon].Cells["MaHX"].Value.ToString();

            txt_MaXe.Text = dgv_Xe.Rows[dongchon].Cells["MaXe"].Value.ToString();
            txt_TenXe.Text = dgv_Xe.Rows[dongchon].Cells["TenXe"].Value.ToString();
            txt_MauXe.Text = dgv_Xe.Rows[dongchon].Cells["MauXe"].Value.ToString();
            txt_GiaXe.Text = dgv_Xe.Rows[dongchon].Cells["Gia"].Value.ToString();
            txt_SLTon.Text = dgv_Xe.Rows[dongchon].Cells["SoLuongTonKho"].Value.ToString();
            txt_HinhAnh.Text = dgv_Xe.Rows[dongchon].Cells["AnhXe"].Value.ToString();

            XuLyCheckBox();


        }
        private void XuLyCheckBox()
        {
            // Lấy chỉ số hàng hiện tại trong DataGridView
            int i = dgv_Xe.CurrentRow.Index;

            // Lấy giá trị của cột CongNghe từ hàng hiện tại
            string congNghe = dgv_Xe.Rows[i].Cells["CongNghe"].Value.ToString();

            // Đặt trạng thái cho các CheckBox dựa trên giá trị congNghe
            ck_ABS.Checked = congNghe.Contains(ck_ABS.Text);
            ck_DongHo.Checked = congNghe.Contains(ck_DongHo.Text);
            ck_SacDT.Checked = congNghe.Contains(ck_SacDT.Text);
            ck_SmartKey.Checked = congNghe.Contains(ck_SmartKey.Text);
        }

       
        private void btn_Them_Click(object sender, EventArgs e)
        {
            // xu ly checkbox 
            // Khởi tạo danh sách chứa tên công nghệ
            List<string> congNgheList = new List<string>();

            // Kiểm tra từng CheckBox và thêm vào danh sách nếu được chọn
            if (ck_ABS.Checked)
            {
                congNgheList.Add(ck_ABS.Text);
            }
            if (ck_DongHo.Checked)
            {
                congNgheList.Add(ck_DongHo.Text);
            }
            if (ck_SacDT.Checked)
            {
                congNgheList.Add(ck_SacDT.Text);
            }
            if (ck_SmartKey.Checked)
            {
                congNgheList.Add(ck_SmartKey.Text);
            }
            // -----------
            string ma = "0";
            string ten = txt_TenXe.Text;
            string mau = txt_MauXe.Text;
            string hangxe = ccb_HangXe.Text;
            string gia = txt_GiaXe.Text;
            string slton = txt_SLTon.Text;
            string congnghe = string.Join("-", congNgheList);
            string anh = txt_HinhAnh.Text;

            // goi bang len
            DataTable dt = (DataTable)dgv_Xe.DataSource;

            // them moi de co dt moi
            DataRow dr = dt.NewRow();
            dr["MaXe"] = ma;      // -- vì mã xe đã được cho là tự động tăng, nên khi thêm vào thì không cần thêm mã xe ( nhưng chạy sẽ bị lỗi nếu để mã xe là trống )
            dr["TenXe"] = ten;
            dr["MauXe"] = mau;
            dr["MaHX"] = hangxe;
            dr["Gia"] = gia;
            dr["SoLuongTonKho"] = slton;
            dr["CongNghe"] = congnghe;
            dr["AnhXe"] = anh;

            dt.Rows.Add(dr);
            DBConnect db = new DBConnect();
            string chuoitruyvan = "select * from XeMay";
            int k = db.updateDataTable(dt, chuoitruyvan);

            if (k != 0)
            {
                MessageBox.Show("Da Them");
                HienThi_DsXe();
            }
            else
            {
                MessageBox.Show("Chua Them");
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgv_Xe.DataSource;
            // Tim dong du lieu co ma khoa trung voi ma khoa nhap trong textbox
            DataRow dr = dt.Rows.Find(txt_MaXe.Text);

            // xu ly checkbox
            List<string> congNgheList = new List<string>();

            // Kiểm tra từng CheckBox và thêm vào danh sách nếu được chọn
            if (ck_ABS.Checked)
            {
                congNgheList.Add(ck_ABS.Text);
            }
            if (ck_DongHo.Checked)
            {
                congNgheList.Add(ck_DongHo.Text);
            }
            if (ck_SacDT.Checked)
            {
                congNgheList.Add(ck_SacDT.Text);
            }
            if (ck_SmartKey.Checked)
            {
                congNgheList.Add(ck_SmartKey.Text);
            }
            string congnghe = string.Join("-", congNgheList);

            // Hieu chinh thong tin -- dong tin vua moi tim duoc
            if (dr != null)
            {
                dr["TenXe"] = txt_TenXe.Text;
                dr["MauXe"] = txt_MauXe.Text;
                dr["MaHX"] = ccb_HangXe.Text;
                dr["Gia"] = txt_GiaXe.Text;
                dr["SoLuongTonKho"] = txt_SLTon.Text;
                dr["CongNghe"] = congnghe;
                dr["AnhXe"] = txt_HinhAnh.Text;

            }

            // CAP NHAT
            DBConnect db = new DBConnect();
            string chuoitruyvan = "select * from XeMay";
            int k = db.updateDataTable(dt, chuoitruyvan);

            if (k != 0)
            {
                MessageBox.Show("Da Sua");
            }
            else
            {
                MessageBox.Show("Chua Sua");
            }


        }
    }
}

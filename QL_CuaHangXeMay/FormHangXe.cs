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
namespace QL_CuaHangXeMay
{
    public partial class FormHangXe : Form
    {
        public FormHangXe()
        {
            InitializeComponent();
            //txtSearch.KeyDown += new KeyEventHandler(txtSearch_KeyDown);
            //ccb_TenHangXe.SelectedIndexChanged += new EventHandler(ccb_TenHangXe_SelectedIndexChanged);
            // Đăng ký sự kiện KeyDown cho txt_Search
            // this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
        }

        private void FormHangXe_Load(object sender, EventArgs e)
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
            ccb_MaHangXe.DataSource = dt;
            ccb_MaHangXe.DisplayMember = "MaHX";
            ccb_MaHangXe.ValueMember = "MaHX";
            ccb_MaHangXe.SelectedIndex = 0;

            ccb_TenHangXe.DataSource = dt;
            ccb_TenHangXe.DisplayMember = "TenHX";
            ccb_TenHangXe.ValueMember = "MaHX";
            ccb_TenHangXe.SelectedIndex = 0;

            HienThi_DsHangXe();

            //DataRow row = dt.Rows[0];
            //txt_SDT.Text = row["SDT"].ToString();
            //txt_DiaChi.Text = row["DiaChi"].ToString();
            //txt_Email.Text = row["Email"].ToString();

            //--------------------------------------------------------//


        }
      
        void HienThi_DsHangXe()
        {

            // Goi xuat bang SP
            string s = "select * from HangXe";
            DBConnect db = new DBConnect();
            DataTable dt = db.getDataTable(s);
            dgv_HangXe.DataSource = dt;

            DataColumn[] HangXe = new DataColumn[1];

            HangXe[0] = dt.Columns["MaHangXe"];
            dt.PrimaryKey = HangXe;

        }


        private void btn_Them_Click(object sender, EventArgs e)
        {
            string ma = ccb_MaHangXe.Text;
            string ten = ccb_TenHangXe.Text;
            string email = txt_Email.Text;
            string dc = txt_DiaChi.Text;
            string sdt = txt_SDT.Text;
            // goi bang len
            DataTable dt = (DataTable)dgv_HangXe.DataSource;
            // them moi de co dt moi
            DataRow dr = dt.NewRow();
            dr["MaHX"] = ma;
            dr["TenHX"] = ten;
            dr["EmailHX"] = email;
            dr["DiaChiHX"] = dc;
            dr["SoDienThoaiHX"] = sdt;
            dt.Rows.Add(dr);
            DBConnect db = new DBConnect();
            string chuoitruyvan = "select * from HangXe";
            int k = db.updateDataTable(dt, chuoitruyvan);

            if (k != 0)
            {
                MessageBox.Show("Da Them");
                HienThi_DsHangXe();
            }
            else
            {
                MessageBox.Show("Chua Them");
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            // Kiểm tra xem có hàng nào được chọn không
            if (dgv_HangXe.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgv_HangXe.SelectedRows[0];
                int maHangXe = Convert.ToInt32(selectedRow.Cells["MaHX"].Value); // Lấy mã hàng xe

                // Lấy dữ liệu từ các TextBox
                string tenHangXe = ccb_TenHangXe.Text;
                string diaChi = txt_DiaChi.Text;
                string soDienThoai = txt_SDT.Text;
                string email = txt_Email.Text;

                // Kiểm tra tính hợp lệ của tên hàng xe
                if (string.IsNullOrEmpty(tenHangXe))
                {
                    MessageBox.Show("Vui lòng điền tên hàng xe.");
                    return;
                }

                try
                {

                    string query = "UPDATE HangXe SET TenHX = @TenHX, DiaChiHX = @DiaChiHX, SoDienThoaiHX = @SoDienThoaiHX, EmailHX = @EmailHX WHERE MaHX = @MaHX";
                    SqlCommand cmd = new SqlCommand(query, db.con);
                    cmd.Parameters.AddWithValue("@TenHX", tenHangXe);
                    cmd.Parameters.AddWithValue("@MaHX", maHangXe);

                    // Gán giá trị cho các tham số, cho phép null ( Vì lúc nhập sẽ có lúc bỏ trống vài dl )
                    cmd.Parameters.AddWithValue("@DiaChiHX", string.IsNullOrEmpty(diaChi) ? (object)DBNull.Value : diaChi);
                    cmd.Parameters.AddWithValue("@SoDienThoaiHX", string.IsNullOrEmpty(soDienThoai) ? (object)DBNull.Value : soDienThoai);
                    cmd.Parameters.AddWithValue("@EmailHX", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);

                    db.Open(); // Mở kết nối
                    int k = cmd.ExecuteNonQuery(); // Thực hiện truy vấn
                    db.Close(); // Đóng kết nối

                    // Kiểm tra kết quả
                    if (k > 0)
                    {
                        MessageBox.Show("Sửa thành công.");
                        HienThi_DsHangXe(); // Cập nhật lại danh sách
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                finally
                {
                    db.Close(); // Đảm bảo rằng kết nối luôn được đóng
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hàng để sửa.");
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (dgv_HangXe.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgv_HangXe.SelectedRows[0];
                int maHangXe = Convert.ToInt32(selectedRow.Cells["MaHX"].Value); // Lấy mã hàng xe

                DBConnect db = new DBConnect();
                string query = "DELETE FROM HangXe WHERE MaHX = @MaHX";
                SqlCommand cmd = new SqlCommand(query, db.con);
                cmd.Parameters.AddWithValue("@MaHX", maHangXe);

                db.Open();
                int result = cmd.ExecuteNonQuery();
                db.Close();

                if (result > 0)
                {
                    MessageBox.Show("Xóa thành công.");
                    HienThi_DsHangXe(); // Cập nhật lại danh sách
                }
                else
                {
                    MessageBox.Show("Xóa không thành công.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hàng để xóa.");
            }

        }

        private void ccb_MaHangXe_Click(object sender, EventArgs e)
        {
            string ma = ccb_MaHangXe.SelectedValue.ToString();
            DBConnect data = new DBConnect();
            string chuoitruyvan = @"select * from HangXe
                                    where MaHX = '" + ma + "'";
            DataTable dt = data.getDataTable(chuoitruyvan);

             // thay đoi thong tin khi click vao ccb_MaHangXe
            txt_DiaChi.Text = dt.Rows[0]["DiaChiHX"].ToString();
            txt_Email.Text = dt.Rows[0]["EmailHX"].ToString();
            txt_SDT.Text = dt.Rows[0]["SoDienThoaiHX"].ToString();
        }

        private void dgv_HangXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // khi click vao cac gia tri tren bang dgv -- se hien thi tren ccb, txt,... \
            int dongchon = e.RowIndex;
            //string ma = ccb_MaHangXe.SelectedValue.ToString();
            //string ten = ccb_TenHangXe .SelectedValue.ToString();

            ccb_MaHangXe.Text = dgv_HangXe.Rows[dongchon].Cells["MaHX"].Value.ToString();
            ccb_TenHangXe.Text = dgv_HangXe.Rows[dongchon].Cells["TenHX"].Value.ToString();

            txt_Email .Text = dgv_HangXe.Rows[dongchon].Cells["EmailHX"].Value.ToString();
            txt_SDT .Text = dgv_HangXe.Rows[dongchon].Cells["SoDienThoaiHX"].Value.ToString();
            txt_DiaChi.Text = dgv_HangXe.Rows[dongchon].Cells["DiaChiHX"].Value.ToString();
        }

        private void logo_search_Click(object sender, EventArgs e)
        {
            string ten = "";
            logo_search.Cursor = Cursors.Hand;
            
            ten = txtSearch.Text;
            

            DBConnect db = new DBConnect();
            string sql = "SELECT * FROM HangXe WHERE TenHX LIKE '%" + ten + "%'";
            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Mời Bạn Nhập Tên!");
                HienThi_DsHangXe();
            }
            else
            {
                dgv_HangXe.DataSource = db.getDataTable(sql);

            }
        }

        //private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        //{
        //    string ten = "";
        //    logo_search.Cursor = Cursors.Hand;
        //    if (txtSearch.ForeColor == Color.Black)
        //    {
        //        ten = txtSearch.Text;
        //    }

        //    DBConnect db = new DBConnect();
        //    string sql = "SELECT * FROM HangXe WHERE TenHX LIKE '%" + ten + "%'";
            
        //        dgv_HangXe.DataSource = db.getDataTable(sql);

            
        //}
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_CuaHangXeMay
{
    public partial class FormTaoHoaDon : Form
    {
        
        public FormTaoHoaDon()
        {
            InitializeComponent();
            loadcbMaNV();
            loadcbSanPham();
        }
        private void loadcbMaNV()
        {
            DBConnect DB = new DBConnect();
            string chuoitruyvan = "select * from NhanVien";
            DataTable dt = DB.getDataTable(chuoitruyvan);
            comboBox1.DataSource= dt;
            comboBox1.DisplayMember= "HoTenNV";
            comboBox1.ValueMember= "MaNV";
        }
        private void loadcbSanPham()
        {
            DBConnect DB = new DBConnect();
            string chuoitruyvan = "select * from XeMay";
            DataTable dt = DB.getDataTable(chuoitruyvan);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "TenXe"; 
            comboBox2.ValueMember = "Maxe";
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                textBox1.Text = string.Empty;
            }
            else
            {
                string maxe = comboBox2.SelectedValue.ToString();
                DBConnect DB = new DBConnect();
                string chuoitruyvan = "select * from XeMay where MaXe = "+maxe+"";
                DataTable dt = DB.getDataTable(chuoitruyvan);

                textBox6.Text = dt.Rows[0]["SoLuongTonKho"].ToString();
            }

        }
        List<XeMay> lst = new List<XeMay>();
        private void addItem(XeMay a)
        {
            if (lst.Count > 0)
            {
                if (lst.Select(r=>r.MaXe).FirstOrDefault() == a.MaXe)
                {
                    lst.Where(r => r.MaXe == a.MaXe).ToList().ForEach(r => r.Soluong += a.Soluong);
                    lst.Where(r => r.MaXe == a.MaXe).ToList().ForEach(r => r.Giatien += a.Giatien);
                }
                else
                {
                    lst.Add(a);
                }
            }
            else
            {
                lst.Add(a);
            }
        }
        private void delItem(XeMay a)
        {
            if (lst.Count > 0)
            {
               lst.Remove(a);
            }
            else
            {
                return;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string maxe = comboBox2.SelectedValue.ToString();
            DBConnect DB = new DBConnect();
            string chuoitruyvan = "select * from XeMay where MaXe = " + maxe + "";
            DataTable dt = DB.getDataTable(chuoitruyvan);



            XeMay a = new XeMay();
            a.MaXe = Int32.Parse( dt.Rows[0]["MaXe"].ToString());
            a.TenXe = dt.Rows[0]["TenXe"].ToString();
            a.Soluong = Int32.Parse(textBox5.Text.ToString());
            a.Giatien = Double.Parse(dt.Rows[0]["Gia"].ToString())* Int32.Parse(textBox5.Text.ToString());
            addItem(a);
            BindingSource source = new BindingSource();
            source.DataSource = lst;
            dataGridView1.DataSource = source;
        }
        private int ThemKH(string ten,string sdt,string diachi)
        {

            try
            {
                DBConnect db = new DBConnect();
                string insert = "INSERT INTO KhachHang VALUES (N'" + ten + "',NULL,'" + sdt + "',NULL,N'" + diachi + "')";
                int kq = db.getNonQuery(insert);
                if (kq > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống" + ex.Message);
            }
            return 0;
        }
        private int ThemDH(string makh,string manv, DateTime date,double tongtien)
        {
            try
            {
                DBConnect db = new DBConnect();
                string insert = "INSERT INTO HoaDon VALUES ("+makh+", "+manv+", '"+date+"', "+tongtien+")";
                int kq = db.getNonQuery(insert);
                if (kq > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống" + ex.Message);
            }
            return 0;
        }
        private int ThemCHDH(int MaHD,int MaXe,int SoLuong,double GiaBan)
        {
            try
            {
                DBConnect db = new DBConnect();
                string insert = "INSERT INTO ChiTietHoaDon (MaHD, MaXe, SoLuong, GiaBan) VALUES ("+MaHD+", "+MaXe+", "+SoLuong+", "+GiaBan+")";
                int kq = db.getNonQuery(insert);
                if (kq > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống" + ex.Message);
            }
            return 0;
        }
        private bool checkIsNull(TextBox a)
        {
            if(a.Text == "") return false; return true;
        }
        private KhachHang checkexisted(KhachHang a)
        {
            DBConnect DB = new DBConnect();
            string chuoitruyvan = "select * from KhachHang where HoTenKH=N'"+a.HoTenKH+"' and SoDienThoaiKH ='"+a.SoDienThoaiKH+"'and DiaChi='"+a.DiaChi+"';";
            DataTable dt = DB.getDataTable(chuoitruyvan);
            try
            {
                if (dt.Rows[0]["HoTenKH"].ToString() == a.HoTenKH && dt.Rows[0]["SoDienThoaiKH"].ToString() == a.SoDienThoaiKH && dt.Rows[0]["DiaChi"].ToString() == a.DiaChi)
                {
                    a.MaKH = dt.Rows[0]["MaKH"].ToString();
                    return a;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
                
            }
;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if(checkIsNull(textBox2) == false || checkIsNull(textBox3)==false || checkIsNull(textBox4)==false)
            {
                MessageBox.Show("Vui lòng Nhập thông tin khách hàng");
                return;
            }
            else
            {
                int flag = 0;
                //Kiểm tra và tạo mới khách hàng
                KhachHang a = new KhachHang();
                a.HoTenKH= textBox2.Text.Trim();
                a.SoDienThoaiKH= textBox3.Text.Trim();
                a.DiaChi= textBox4.Text.Trim();
                if (checkexisted(a) != null)
                {
                    Console.WriteLine("khach hang da khoi tao");
                    flag = -1;
                }
                ThemKH(textBox2.Text, textBox3.Text, textBox4.Text);

                //Tạo hoá đơn 
                double tongtien = 0;
                foreach(var x in lst)
                {
                    tongtien += x.Giatien;
                }
                KhachHang b = checkexisted(a);
                ThemDH(a.MaKH, comboBox1.SelectedValue.ToString(), dateTimePicker1.Value,tongtien);

                //Tạo chi tiết hoá đơn
                DBConnect DB = new DBConnect();
                string chuoitruyvan = "select * from HoaDon where MaKH = "+ a.MaKH + " and MaNV = "+ comboBox1.SelectedValue.ToString() + " and NgayLap = '"+ dateTimePicker1.Value + "'";
                DataTable dt = DB.getDataTable(chuoitruyvan);
                try
                {
                    foreach (var x in lst)
                    {
                        ThemCHDH(int.Parse(dt.Rows[0]["MaHD"].ToString()), x.MaXe, x.Soluong, x.Giatien);
                    }
                }
                catch (Exception)
                {
                    flag = -1;
                }

                if (flag == 0) MessageBox.Show("tạo hoá đơn thành công");
                else MessageBox.Show("tạo hoá đơn không thành công");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XeMay a = new XeMay();
            int maxetemp = int.Parse(comboBox2.SelectedValue.ToString());

            a = lst.Where(r=>r.MaXe == maxetemp).FirstOrDefault();
            delItem(a);

            BindingSource source = new BindingSource();
            source.DataSource = lst;
            dataGridView1.DataSource = source;
        }

        private void FormTaoHoaDon_Load(object sender, EventArgs e)
        {

        }
    }
    public class KhachHang
    {
        public string MaKH { get; set; }
        public string HoTenKH { get; set; }
        public string SoDienThoaiKH { get; set; }
        public string DiaChi { get; set; }
    }
    public class XeMay
    {
        public int MaXe { get; set; }
        public string TenXe { get; set; }
        public int Soluong{ get; set; }
        public double Giatien { get; set; }
    }
}

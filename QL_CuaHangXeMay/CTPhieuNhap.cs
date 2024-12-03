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
    
    public partial class CTPhieuNhap : Form
    {

        DBConnect db = new DBConnect();

        private int receivedId;
        public CTPhieuNhap(int id)
        {
            InitializeComponent();
            receivedId = id;
            dataGridView1.DataSource = db.getDataTable("Select * from ChiTietPhieuNhap where MaPN = '" + id + "'");
        }

        private void CTPhieuNhap_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

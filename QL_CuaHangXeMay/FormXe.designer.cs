namespace QL_CuaHangXeMay
{
    partial class FormXe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormXe));
            this.grp_DanhSach = new System.Windows.Forms.GroupBox();
            this.dgv_Xe = new System.Windows.Forms.DataGridView();
            this.grp_ThongTinXe = new System.Windows.Forms.GroupBox();
            this.picture_HinhAnh = new System.Windows.Forms.PictureBox();
            this.btn_ChonHAnh = new System.Windows.Forms.Button();
            this.txt_HinhAnh = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_MauXe = new System.Windows.Forms.TextBox();
            this.ck_DongHo = new System.Windows.Forms.CheckBox();
            this.ck_SacDT = new System.Windows.Forms.CheckBox();
            this.ck_SmartKey = new System.Windows.Forms.CheckBox();
            this.ck_ABS = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.logo_search = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txt_SLTon = new System.Windows.Forms.TextBox();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.txt_GiaXe = new System.Windows.Forms.TextBox();
            this.txt_TenXe = new System.Windows.Forms.TextBox();
            this.ccb_HangXe = new System.Windows.Forms.ComboBox();
            this.txt_MaXe = new System.Windows.Forms.TextBox();
            this.btn_Them = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grp_DanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Xe)).BeginInit();
            this.grp_ThongTinXe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_HinhAnh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo_search)).BeginInit();
            this.SuspendLayout();
            // 
            // grp_DanhSach
            // 
            this.grp_DanhSach.Controls.Add(this.dgv_Xe);
            this.grp_DanhSach.Location = new System.Drawing.Point(22, 531);
            this.grp_DanhSach.Margin = new System.Windows.Forms.Padding(4);
            this.grp_DanhSach.Name = "grp_DanhSach";
            this.grp_DanhSach.Padding = new System.Windows.Forms.Padding(4);
            this.grp_DanhSach.Size = new System.Drawing.Size(1842, 452);
            this.grp_DanhSach.TabIndex = 49;
            this.grp_DanhSach.TabStop = false;
            this.grp_DanhSach.Text = "Danh sách các loại xe";
            // 
            // dgv_Xe
            // 
            this.dgv_Xe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Xe.Location = new System.Drawing.Point(46, 46);
            this.dgv_Xe.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_Xe.Name = "dgv_Xe";
            this.dgv_Xe.RowHeadersWidth = 82;
            this.dgv_Xe.RowTemplate.Height = 33;
            this.dgv_Xe.Size = new System.Drawing.Size(1764, 348);
            this.dgv_Xe.TabIndex = 36;
            this.dgv_Xe.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Xe_CellClick);
            this.dgv_Xe.Click += new System.EventHandler(this.dgv_Xe_Click);
            // 
            // grp_ThongTinXe
            // 
            this.grp_ThongTinXe.Controls.Add(this.picture_HinhAnh);
            this.grp_ThongTinXe.Controls.Add(this.btn_ChonHAnh);
            this.grp_ThongTinXe.Controls.Add(this.txt_HinhAnh);
            this.grp_ThongTinXe.Controls.Add(this.label8);
            this.grp_ThongTinXe.Controls.Add(this.txt_MauXe);
            this.grp_ThongTinXe.Controls.Add(this.ck_DongHo);
            this.grp_ThongTinXe.Controls.Add(this.ck_SacDT);
            this.grp_ThongTinXe.Controls.Add(this.ck_SmartKey);
            this.grp_ThongTinXe.Controls.Add(this.ck_ABS);
            this.grp_ThongTinXe.Controls.Add(this.label7);
            this.grp_ThongTinXe.Controls.Add(this.logo_search);
            this.grp_ThongTinXe.Controls.Add(this.txtSearch);
            this.grp_ThongTinXe.Controls.Add(this.txt_SLTon);
            this.grp_ThongTinXe.Controls.Add(this.btn_Sua);
            this.grp_ThongTinXe.Controls.Add(this.btn_Xoa);
            this.grp_ThongTinXe.Controls.Add(this.txt_GiaXe);
            this.grp_ThongTinXe.Controls.Add(this.txt_TenXe);
            this.grp_ThongTinXe.Controls.Add(this.ccb_HangXe);
            this.grp_ThongTinXe.Controls.Add(this.txt_MaXe);
            this.grp_ThongTinXe.Controls.Add(this.btn_Them);
            this.grp_ThongTinXe.Controls.Add(this.label6);
            this.grp_ThongTinXe.Controls.Add(this.label5);
            this.grp_ThongTinXe.Controls.Add(this.label4);
            this.grp_ThongTinXe.Controls.Add(this.label3);
            this.grp_ThongTinXe.Controls.Add(this.label2);
            this.grp_ThongTinXe.Controls.Add(this.label1);
            this.grp_ThongTinXe.Location = new System.Drawing.Point(22, 21);
            this.grp_ThongTinXe.Margin = new System.Windows.Forms.Padding(4);
            this.grp_ThongTinXe.Name = "grp_ThongTinXe";
            this.grp_ThongTinXe.Padding = new System.Windows.Forms.Padding(4);
            this.grp_ThongTinXe.Size = new System.Drawing.Size(1842, 465);
            this.grp_ThongTinXe.TabIndex = 48;
            this.grp_ThongTinXe.TabStop = false;
            this.grp_ThongTinXe.Text = "Thông tin xe";
            // 
            // picture_HinhAnh
            // 
            this.picture_HinhAnh.Location = new System.Drawing.Point(999, 175);
            this.picture_HinhAnh.Margin = new System.Windows.Forms.Padding(6);
            this.picture_HinhAnh.Name = "picture_HinhAnh";
            this.picture_HinhAnh.Size = new System.Drawing.Size(509, 254);
            this.picture_HinhAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_HinhAnh.TabIndex = 80;
            this.picture_HinhAnh.TabStop = false;
            // 
            // btn_ChonHAnh
            // 
            this.btn_ChonHAnh.Location = new System.Drawing.Point(1266, 100);
            this.btn_ChonHAnh.Margin = new System.Windows.Forms.Padding(6);
            this.btn_ChonHAnh.Name = "btn_ChonHAnh";
            this.btn_ChonHAnh.Size = new System.Drawing.Size(150, 44);
            this.btn_ChonHAnh.TabIndex = 79;
            this.btn_ChonHAnh.Text = "Chọn tệp ...";
            this.btn_ChonHAnh.UseVisualStyleBackColor = true;
            this.btn_ChonHAnh.Click += new System.EventHandler(this.btn_ChonHAnh_Click);
            // 
            // txt_HinhAnh
            // 
            this.txt_HinhAnh.Location = new System.Drawing.Point(1000, 106);
            this.txt_HinhAnh.Margin = new System.Windows.Forms.Padding(6);
            this.txt_HinhAnh.Name = "txt_HinhAnh";
            this.txt_HinhAnh.Size = new System.Drawing.Size(228, 31);
            this.txt_HinhAnh.TabIndex = 78;
            this.txt_HinhAnh.TextChanged += new System.EventHandler(this.txt_HinhAnh_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(994, 52);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 25);
            this.label8.TabIndex = 77;
            this.label8.Text = "Ảnh";
            // 
            // txt_MauXe
            // 
            this.txt_MauXe.Location = new System.Drawing.Point(158, 152);
            this.txt_MauXe.Margin = new System.Windows.Forms.Padding(4);
            this.txt_MauXe.Name = "txt_MauXe";
            this.txt_MauXe.Size = new System.Drawing.Size(424, 31);
            this.txt_MauXe.TabIndex = 76;
            // 
            // ck_DongHo
            // 
            this.ck_DongHo.AutoSize = true;
            this.ck_DongHo.Location = new System.Drawing.Point(704, 240);
            this.ck_DongHo.Margin = new System.Windows.Forms.Padding(6);
            this.ck_DongHo.Name = "ck_DongHo";
            this.ck_DongHo.Size = new System.Drawing.Size(230, 29);
            this.ck_DongHo.TabIndex = 75;
            this.ck_DongHo.Text = "Đồng hồ kĩ thuật số";
            this.ck_DongHo.UseVisualStyleBackColor = true;
            // 
            // ck_SacDT
            // 
            this.ck_SacDT.AutoSize = true;
            this.ck_SacDT.Location = new System.Drawing.Point(704, 196);
            this.ck_SacDT.Margin = new System.Windows.Forms.Padding(6);
            this.ck_SacDT.Name = "ck_SacDT";
            this.ck_SacDT.Size = new System.Drawing.Size(181, 29);
            this.ck_SacDT.TabIndex = 74;
            this.ck_SacDT.Text = "Sạc điện thoại";
            this.ck_SacDT.UseVisualStyleBackColor = true;
            // 
            // ck_SmartKey
            // 
            this.ck_SmartKey.AutoSize = true;
            this.ck_SmartKey.Location = new System.Drawing.Point(704, 150);
            this.ck_SmartKey.Margin = new System.Windows.Forms.Padding(6);
            this.ck_SmartKey.Name = "ck_SmartKey";
            this.ck_SmartKey.Size = new System.Drawing.Size(143, 29);
            this.ck_SmartKey.TabIndex = 73;
            this.ck_SmartKey.Text = "Smart Key";
            this.ck_SmartKey.UseVisualStyleBackColor = true;
            // 
            // ck_ABS
            // 
            this.ck_ABS.AutoSize = true;
            this.ck_ABS.Location = new System.Drawing.Point(704, 106);
            this.ck_ABS.Margin = new System.Windows.Forms.Padding(6);
            this.ck_ABS.Name = "ck_ABS";
            this.ck_ABS.Size = new System.Drawing.Size(86, 29);
            this.ck_ABS.TabIndex = 72;
            this.ck_ABS.Text = "ABS";
            this.ck_ABS.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(676, 44);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 25);
            this.label7.TabIndex = 71;
            this.label7.Text = "CÔNG NGHỆ";
            // 
            // logo_search
            // 
            this.logo_search.Image = ((System.Drawing.Image)(resources.GetObject("logo_search.Image")));
            this.logo_search.Location = new System.Drawing.Point(830, 385);
            this.logo_search.Margin = new System.Windows.Forms.Padding(4);
            this.logo_search.Name = "logo_search";
            this.logo_search.Size = new System.Drawing.Size(46, 44);
            this.logo_search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo_search.TabIndex = 70;
            this.logo_search.TabStop = false;
            this.logo_search.Click += new System.EventHandler(this.logo_search_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(46, 387);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(770, 37);
            this.txtSearch.TabIndex = 69;
            this.txtSearch.Text = "Tìm kiếm";
            // 
            // txt_SLTon
            // 
            this.txt_SLTon.Location = new System.Drawing.Point(226, 316);
            this.txt_SLTon.Margin = new System.Windows.Forms.Padding(4);
            this.txt_SLTon.Name = "txt_SLTon";
            this.txt_SLTon.Size = new System.Drawing.Size(356, 31);
            this.txt_SLTon.TabIndex = 43;
            // 
            // btn_Sua
            // 
            this.btn_Sua.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btn_Sua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Sua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sua.ForeColor = System.Drawing.Color.White;
            this.btn_Sua.Image = global::QL_CuaHangXeMay.Properties.Resources.file_edit;
            this.btn_Sua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Sua.Location = new System.Drawing.Point(1600, 269);
            this.btn_Sua.Margin = new System.Windows.Forms.Padding(6);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(210, 60);
            this.btn_Sua.TabIndex = 40;
            this.btn_Sua.Text = "      Sửa";
            this.btn_Sua.UseVisualStyleBackColor = false;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btn_Xoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa.ForeColor = System.Drawing.Color.White;
            this.btn_Xoa.Image = global::QL_CuaHangXeMay.Properties.Resources.trash__1_;
            this.btn_Xoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Xoa.Location = new System.Drawing.Point(1600, 175);
            this.btn_Xoa.Margin = new System.Windows.Forms.Padding(6);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(210, 62);
            this.btn_Xoa.TabIndex = 43;
            this.btn_Xoa.Text = "      Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = false;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // txt_GiaXe
            // 
            this.txt_GiaXe.Location = new System.Drawing.Point(158, 262);
            this.txt_GiaXe.Margin = new System.Windows.Forms.Padding(4);
            this.txt_GiaXe.Name = "txt_GiaXe";
            this.txt_GiaXe.Size = new System.Drawing.Size(424, 31);
            this.txt_GiaXe.TabIndex = 41;
            // 
            // txt_TenXe
            // 
            this.txt_TenXe.Location = new System.Drawing.Point(158, 98);
            this.txt_TenXe.Margin = new System.Windows.Forms.Padding(4);
            this.txt_TenXe.Name = "txt_TenXe";
            this.txt_TenXe.Size = new System.Drawing.Size(424, 31);
            this.txt_TenXe.TabIndex = 40;
            // 
            // ccb_HangXe
            // 
            this.ccb_HangXe.FormattingEnabled = true;
            this.ccb_HangXe.Location = new System.Drawing.Point(158, 206);
            this.ccb_HangXe.Margin = new System.Windows.Forms.Padding(4);
            this.ccb_HangXe.Name = "ccb_HangXe";
            this.ccb_HangXe.Size = new System.Drawing.Size(424, 33);
            this.ccb_HangXe.TabIndex = 39;
            // 
            // txt_MaXe
            // 
            this.txt_MaXe.Enabled = false;
            this.txt_MaXe.Location = new System.Drawing.Point(158, 44);
            this.txt_MaXe.Margin = new System.Windows.Forms.Padding(4);
            this.txt_MaXe.Name = "txt_MaXe";
            this.txt_MaXe.Size = new System.Drawing.Size(424, 31);
            this.txt_MaXe.TabIndex = 38;
            // 
            // btn_Them
            // 
            this.btn_Them.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btn_Them.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Them.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Them.ForeColor = System.Drawing.Color.White;
            this.btn_Them.Image = ((System.Drawing.Image)(resources.GetObject("btn_Them.Image")));
            this.btn_Them.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Them.Location = new System.Drawing.Point(1600, 85);
            this.btn_Them.Margin = new System.Windows.Forms.Padding(6);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(210, 62);
            this.btn_Them.TabIndex = 39;
            this.btn_Them.Text = "      Thêm";
            this.btn_Them.UseVisualStyleBackColor = false;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 322);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 25);
            this.label6.TabIndex = 37;
            this.label6.Text = "SỐ LƯỢNG TỒN";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 160);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 25);
            this.label5.TabIndex = 36;
            this.label5.Text = "MÀU XE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 268);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 25);
            this.label4.TabIndex = 35;
            this.label4.Text = "GIÁ XE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 214);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 25);
            this.label3.TabIndex = 34;
            this.label3.Text = "HÃNG XE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 25);
            this.label2.TabIndex = 33;
            this.label2.Text = "TÊN XE ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 25);
            this.label1.TabIndex = 32;
            this.label1.Text = "MÃ XE";
            // 
            // FormXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1944, 1075);
            this.Controls.Add(this.grp_DanhSach);
            this.Controls.Add(this.grp_ThongTinXe);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormXe";
            this.Text = "Xe";
            this.Load += new System.EventHandler(this.FormXe_Load);
            this.grp_DanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Xe)).EndInit();
            this.grp_ThongTinXe.ResumeLayout(false);
            this.grp_ThongTinXe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_HinhAnh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo_search)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_DanhSach;
        private System.Windows.Forms.DataGridView dgv_Xe;
        private System.Windows.Forms.GroupBox grp_ThongTinXe;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txt_SLTon;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.TextBox txt_GiaXe;
        private System.Windows.Forms.TextBox txt_TenXe;
        private System.Windows.Forms.ComboBox ccb_HangXe;
        private System.Windows.Forms.TextBox txt_MaXe;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ck_DongHo;
        private System.Windows.Forms.CheckBox ck_SacDT;
        private System.Windows.Forms.CheckBox ck_SmartKey;
        private System.Windows.Forms.CheckBox ck_ABS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox picture_HinhAnh;
        private System.Windows.Forms.Button btn_ChonHAnh;
        private System.Windows.Forms.TextBox txt_HinhAnh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_MauXe;
        private System.Windows.Forms.PictureBox logo_search;
    }
}
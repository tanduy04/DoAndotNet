-- Bảng KhachHang
CREATE DATABASE QL_XeMay
go
use QL_XeMay

CREATE TABLE QuyenTruyCap(
	QuyenID INT PRIMARY KEY IDENTITY(1,1),
	TenQuyen NVARCHAR(50) NOT NULL
)

-- Bảng NhanVien
CREATE TABLE NhanVien (
    MaNV int PRIMARY KEY IDENTITY(101,1),
    HoTenNV NVARCHAR(100) ,
	QueQuan NVARCHAR(100),
    NgaySinhNV DATE,
    SoDienThoaiNV VARCHAR(20) ,
	GioiTinh NVARCHAR(10),
    EmailNV VARCHAR(100) ,
	TaiKhoan VARCHAR(100),
	MatKhau VARCHAR(100),
    QuyenID INT NOT NULL FOREIGN KEY REFERENCES QuyenTruyCap(QuyenID),
);

CREATE TABLE KhachHang (
    MaKH int PRIMARY KEY IDENTITY(10001,1),
    HoTenKH NVARCHAR(100) ,
    NgaySinhKH DATE,
    SoDienThoaiKH VARCHAR(20) ,
    EmailKH VARCHAR(100) ,
	DiaChi NVARCHAR(250)
);

-- Bảng XeMay

CREATE TABLE HangXe (
    MaHX int PRIMARY KEY IDENTITY(1,1),
    TenHX NVARCHAR(100)  ,
    DiaChiHX NVARCHAR(255) ,
    SoDienThoaiHX VARCHAR(20) ,
    EmailHX VARCHAR(100)
);
CREATE TABLE XeMay (
    MaXe int PRIMARY KEY IDENTITY(101,1),
	AnhXe VARCHAR(200),
    TenXe NVARCHAR(100)  ,
    MaHX INT  FOREIGN KEY REFERENCES HangXe(MaHX) ON DELETE CASCADE,
    MauXe NVARCHAR(50),
	CongNghe NVARCHAR(200),
    Gia FLOAT ,
    SoLuongTonKho INT 
);
-- Bảng HoaDon
CREATE TABLE HoaDon (
    MaHD int PRIMARY KEY IDENTITY(10001,1),
    MaKH int FOREIGN KEY REFERENCES KHACHHANG(MAKH) ON DELETE CASCADE,
    MaNV INT NOT NULL FOREIGN KEY REFERENCES NhanVien(MaNV) ON DELETE CASCADE,
    NgayLap DATETIME ,
    TongTien FLOAT  
);


-- Bảng ChiTietHoaDon
CREATE TABLE ChiTietHoaDon (
    MaHD int NOT NULL FOREIGN KEY REFERENCES HoaDon(MaHD) ON DELETE CASCADE,
    MaXe int NOT NULL FOREIGN KEY REFERENCES XeMay(MaXe) ON DELETE CASCADE,
    SoLuong INT  ,
    GiaBan FLOAT  ,
	CONSTRAINT PK_CTHD PRIMARY KEY (MAHD,MaXe) 
);
-- Nhập dữ liệu cho bảng QuyenTruyCap
INSERT INTO QuyenTruyCap (TenQuyen)
VALUES 
(N'Quản lý'),
(N'Nhân viên bán hàng');

-- Nhập dữ liệu cho bảng NhanVien
INSERT INTO NhanVien ( HoTenNV,QueQuan, NgaySinhNV, SoDienThoaiNV, GioiTinh, EmailNV,TaiKhoan, MatKhau, QuyenID)
VALUES 
(N'Nguyễn Hoàng Giang',N'TP HCM', '1985-01-15', '0912345678', 'Nam', 'nv1@gmail.com','nv01','123', 1),
(N'Trần Thị Bích Tuyền',N'Hà Nội', '1990-06-20', '0987654321', 'Nữ', 'nv2@gmail.com','nv02','123', 2),
(N'Lê Văn Việt',N'Long An' ,'1988-03-10', '0934567890', 'Nữ', 'nv3@gmail.com','nv03','123', 2),
(N'Hồ Quế Trân',N'Yên Bái','1988-03-10', '0934567890', 'Nữ', 'nv4@gmail.com','nv04','123', 2);


-- Nhập dữ liệu cho bảng KhachHang
-- Nhập thêm dữ liệu cho bảng KhachHang
INSERT INTO KhachHang (HoTenKH, NgaySinhkh, SoDienThoaikh, EmailKH,DiaChi)
VALUES 
(N'Nguyễn Thị Giang','1990-05-12', '0909876543', 'ntg@gmail.com','TP.HCM'),
(N'Trần Văn Hiệp', '1985-02-25', '0912345679', 'tvh@gmail.com','Bến Tre'),
(N'Lê Thị Ái Quyên', '1995-08-30', '0923456780', 'lti@gmail.com','TP.HCM'),
(N'Ngô Văn Phú', '1989-10-15', '0934567891', 'nvj@gmail.com','TP.HCM'),
(N'Phạm Thị Khánh Huyền', '1993-12-05', '0945678902', 'ptk@gmail.com','TP.HCM'),
(N'Vũ Văn Linh', '1987-03-20', '0956789013', 'vvl@gmail.com','TP.HCM'),
(N'Lê Văn Phụng', '1988-06-30', '0990123457', 'lvp@gmail.com','TP.HCM');
-- Nhập thêm dữ liệu cho bảng HangXe
INSERT INTO HangXe (TenHX, DiaChiHX, SoDienThoaiHX, EmailHX)
VALUES 
('Yamaha', N'Số 1, Đường 1, TP.HCM', '02812345678', 'yamaha@gmail.com'),
('Honda', N'Số 2, Đường 2, TP.HCM', '02823456789', 'honda@gmail.com'),
('Piaggio', N'Số 3, Đường 3, TP.HCM', '02834567890', 'piaggio@gmail.com');
-- Xóa dữ liệu hiện tại trong bảng XeMay


-- Nhập lại dữ liệu cho bảng XeMay với các mẫu xe phổ thông
INSERT INTO XeMay (AnhXe, TenXe, MaHX, MauXe, CongNghe, Gia, SoLuongTonKho)
VALUES 
('XE001_Honda_SH_160i.png', N'Honda SH 160i', 2, N'Xám', N'Sạc điện thoại - Đồng hồ kỹ thuật số', 90000000, 50),
('XE002_Honda_Future_125i.png', N'Honda Future 125i', 2, N'Xanh', N'ABS - Đồng hồ cơ', 40000000, 45),
('XE003_Vespa_946.jpg', N'Vespa 946', 3, N'Đen', N'ABS - Đồng hồ kỹ thuật số', 62000000, 30),
('XE004_Vespa_Primaver_2018.jpg', N'Vespa Primaver 2018', 3, N'Xanh rêu', N'ABS - Smart Key', 70000000, 20),
('XE005_Piaggio_Liberty_2018.jpg', N'Piaggio Liberty 2018', 3, N'Đỏ', N'Sạc điện thoại - Đồng hồ kỹ thuật số', 32000000, 35),
('XE006_Yamaha_Exciter_150.png', N'Yamaha Exciter 150', 1, N'Đen', N'Smart Key - ABS', 40000000, 40),
('XE007_Yamaha_Jupiter_Fi.png', N'Yamaha Jupiter Fi', 1, N'Đỏ', N'ABS - Đồng hồ kỹ thuật số', 27000000, 25),
('XE008_Vario_160.png', N'Vario 160', 2, N'Đỏ', N'Smart Key - Đồng hồ cơ', 60000000, 15),
('XE009_Vision.png', N'Vision', 2, N'Kem', N'Smart Key - Đồng hồ kỹ thuật số', 42000000, 10),
('XE0010_Sirius.png', N'Sirius', 1, N'Xanh rêu', N'Smart Key - ABS', 23000000, 5),
('XE0011_Honda_Wave_RSX.png', N'Honda Wave RSX', 2, N'Xanh', N'ABS - Đồng hồ kỹ thuật số', 30000000, 8),
('XE0012_Honda_SH_Mode.png', N'Honda SH Mode', 2, N'Xám', N'ABS - Smart Key', 60000000, 2),
('XE0013_Grande.jpg', N'Grande', 1, N'Xanh', N'Sạc điện thoại - Đồng hồ cơ', 30000000, 60),
('XE0014_XE005_Yamaha_Janus_125.jpg', N'Yamaha Janus 125', 1, N'Trắng', N'Smart Key - ABS', 37000000, 12),
('XE0015_Honda_Cub_C125.png',N'Honda Cub C125', 2, N'Xanh', N'Smart Key - ABS', 120000000, 20);
INSERT INTO HoaDon (MaKH, MaNV, NgayLap, TongTien)
VALUES 
(10001, 102, '2024-09-15', 90000000),
(10002, 102, '2024-09-16', 32000000),
(10003, 103, '2024-09-17', 62000000),
(10004, 104, '2024-05-18', 80000000),
(10005, 103,'2024-09-1', 102000000),
(10006, 102, '2024-02-18', 42000000),
(10007, 102, '2024-09-12', 42000000)


INSERT INTO ChiTietHoaDon (MaHD, MaXe, SoLuong, GiaBan)
VALUES 
(10001, 101, 1, 20000000),
(10002, 105, 1, 32000000),
(10003, 103, 1, 000000),
(10004, 106, 2, 40000000),
(10005, 108, 1, 60000000),
(10005, 109, 2, 42000000),
(10006, 109, 1, 42000000),
(10007, 109, 1, 42000000)












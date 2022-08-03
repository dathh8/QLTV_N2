USE [QLTV_N2]
GO
/****** Object:  Table [dbo].[T_Khoa]    Script Date: 9/12/2021 12:45:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Khoa](
	[Makhoa] [nchar](10) NOT NULL,
	[Tenkhoa] [nvarchar](50) NULL,
	[Tentruongkhoa] [nvarchar](50) NULL,
	[Sdtkhoa] [nchar](12) NULL,
	[Email] [nchar](50) NULL,
 CONSTRAINT [PK_T_Khoa] PRIMARY KEY CLUSTERED 
(
	[Makhoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Muontra]    Script Date: 9/12/2021 12:45:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Muontra](
	[Maphieumuon] [nchar](10) NOT NULL,
	[Masv] [varchar](10) NULL,
	[Masach] [varchar](10) NULL,
	[Soluong] [int] NULL,
	[Ngaymuon] [nvarchar](20) NULL,
	[Ngaytra] [nvarchar](20) NULL,
	[Tinhtrang] [nvarchar](50) NULL,
 CONSTRAINT [PK_T_Muontra] PRIMARY KEY CLUSTERED 
(
	[Maphieumuon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Nhanvien]    Script Date: 9/12/2021 12:45:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Nhanvien](
	[Manv] [nchar](10) NOT NULL,
	[Mknv] [nvarchar](50) NULL,
	[Tennv] [nvarchar](50) NULL,
	[Ngaysinh] [nvarchar](20) NULL,
	[Gioitinh] [nvarchar](50) NULL,
	[Diachi] [nvarchar](50) NULL,
	[Sdt] [nchar](20) NULL,
	[Email] [varchar](50) NULL,
 CONSTRAINT [PK_T_Nhanvien] PRIMARY KEY CLUSTERED 
(
	[Manv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Nxb]    Script Date: 9/12/2021 12:45:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Nxb](
	[Manxb] [nchar](10) NOT NULL,
	[Tennxb] [nvarchar](50) NULL,
	[Diachi] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Sdt] [nchar](20) NULL,
 CONSTRAINT [PK_T_Nxb] PRIMARY KEY CLUSTERED 
(
	[Manxb] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Sach]    Script Date: 9/12/2021 12:45:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Sach](
	[Masach] [varchar](10) NOT NULL,
	[Tensach] [nvarchar](50) NULL,
	[Manxb] [nchar](10) NULL,
	[Tacgia] [nvarchar](50) NULL,
	[Theloai] [nvarchar](50) NULL,
	[Soluong] [int] NULL,
 CONSTRAINT [PK_T_Sach] PRIMARY KEY CLUSTERED 
(
	[Masach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Sinhvien]    Script Date: 9/12/2021 12:45:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Sinhvien](
	[Masv] [varchar](10) NOT NULL,
	[Tensv] [nvarchar](50) NULL,
	[Lop] [nchar](10) NULL,
	[Makhoa] [nchar](10) NULL,
	[Ngaysinh] [nvarchar](20) NULL,
	[Gioitinh] [nvarchar](50) NULL,
	[Sdt] [nchar](12) NULL,
	[Email] [nchar](50) NULL,
	[Diachi] [nvarchar](50) NULL,
 CONSTRAINT [PK_T_Sinhvien] PRIMARY KEY CLUSTERED 
(
	[Masv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[T_Khoa] ([Makhoa], [Tenkhoa], [Tentruongkhoa], [Sdtkhoa], [Email]) VALUES (N'CNTT      ', N'Công nghệ thông tin', N'Lê Văn B', N'4325        ', N'cntt@gmail.com                                    ')
INSERT [dbo].[T_Khoa] ([Makhoa], [Tenkhoa], [Tentruongkhoa], [Sdtkhoa], [Email]) VALUES (N'KT        ', N'Kế toán', N'Hờ Uê Huệ', N'0902421     ', N'kt@gmail.com                                      ')
INSERT [dbo].[T_Khoa] ([Makhoa], [Tenkhoa], [Tentruongkhoa], [Sdtkhoa], [Email]) VALUES (N'KTB       ', N'Kinh tế biển', N'Bờ Yên Biển', N'087654      ', N'ktbien@gmail.com                                  ')
INSERT [dbo].[T_Khoa] ([Makhoa], [Tenkhoa], [Tentruongkhoa], [Sdtkhoa], [Email]) VALUES (N'KTTN      ', N'Kinh tế tài nguyên', N'Vũ Văn B', N'0851485     ', N'kttn@gmail,com                                    ')
INSERT [dbo].[T_Khoa] ([Makhoa], [Tenkhoa], [Tentruongkhoa], [Sdtkhoa], [Email]) VALUES (N'LUAT      ', N'Luật', N'Nguyễn Thị Quỳnh', N'76543       ', N'luat@gmail.com                                    ')
INSERT [dbo].[T_Khoa] ([Makhoa], [Tenkhoa], [Tentruongkhoa], [Sdtkhoa], [Email]) VALUES (N'QTKD      ', N'Quản trị kin doanh', N'Dờ Onh Doanh', N'65432145    ', N'qtkd@gmail.com                                    ')
GO
INSERT [dbo].[T_Muontra] ([Maphieumuon], [Masv], [Masach], [Soluong], [Ngaymuon], [Ngaytra], [Tinhtrang]) VALUES (N'PM001     ', N'SV001     ', N'S003      ', 2, N'2021-05-05', N'2021-05-08', N'Mới')
INSERT [dbo].[T_Muontra] ([Maphieumuon], [Masv], [Masach], [Soluong], [Ngaymuon], [Ngaytra], [Tinhtrang]) VALUES (N'PM002     ', N'SV004     ', N'S004      ', 20, N'5/13/2021', N'5/21/2021', N'Mới')
INSERT [dbo].[T_Muontra] ([Maphieumuon], [Masv], [Masach], [Soluong], [Ngaymuon], [Ngaytra], [Tinhtrang]) VALUES (N'PM003     ', N'SV002     ', N'S005      ', 10, N'5/13/2021', N'5/22/2021', N'Mới')
INSERT [dbo].[T_Muontra] ([Maphieumuon], [Masv], [Masach], [Soluong], [Ngaymuon], [Ngaytra], [Tinhtrang]) VALUES (N'PM004     ', N'SV008', N'S004      ', 2, N'5/13/2021', N'5/13/2021', N'Cũ')
INSERT [dbo].[T_Muontra] ([Maphieumuon], [Masv], [Masach], [Soluong], [Ngaymuon], [Ngaytra], [Tinhtrang]) VALUES (N'PM005     ', N'SV003     ', N'S004      ', 2, N'5/13/2021', N'5/13/2021', N'')
INSERT [dbo].[T_Muontra] ([Maphieumuon], [Masv], [Masach], [Soluong], [Ngaymuon], [Ngaytra], [Tinhtrang]) VALUES (N'PM006     ', N'SV010', N'S004      ', 3, N'5/13/2021', N'5/18/2021', N'Mới')
INSERT [dbo].[T_Muontra] ([Maphieumuon], [Masv], [Masach], [Soluong], [Ngaymuon], [Ngaytra], [Tinhtrang]) VALUES (N'PM007     ', N'SV001     ', N'S003      ', 3, N'5/24/2021', N'5/24/2021', N'Mới')
INSERT [dbo].[T_Muontra] ([Maphieumuon], [Masv], [Masach], [Soluong], [Ngaymuon], [Ngaytra], [Tinhtrang]) VALUES (N'PM008     ', N'SV009', N'S007', 10, N'5/24/2021', N'5/24/2021', N'Cũ')
INSERT [dbo].[T_Muontra] ([Maphieumuon], [Masv], [Masach], [Soluong], [Ngaymuon], [Ngaytra], [Tinhtrang]) VALUES (N'PM009     ', N'SV001     ', N'S003      ', 2, N'5/5/2021', N'5/8/2021', N'Mới')
INSERT [dbo].[T_Muontra] ([Maphieumuon], [Masv], [Masach], [Soluong], [Ngaymuon], [Ngaytra], [Tinhtrang]) VALUES (N'PM010     ', N'SV005     ', N'S004      ', 21, N'9/11/2021', N'9/11/2021', N'')
INSERT [dbo].[T_Muontra] ([Maphieumuon], [Masv], [Masach], [Soluong], [Ngaymuon], [Ngaytra], [Tinhtrang]) VALUES (N'PM011     ', N'SV003     ', N'S001      ', 1, N'9/12/2021', N'9/12/2021', N'')
GO
INSERT [dbo].[T_Nhanvien] ([Manv], [Mknv], [Tennv], [Ngaysinh], [Gioitinh], [Diachi], [Sdt], [Email]) VALUES (N'123       ', N'123', N'123', N'5/27/2021', N'Nam', N'123', N'123                 ', N'421')
INSERT [dbo].[T_Nhanvien] ([Manv], [Mknv], [Tennv], [Ngaysinh], [Gioitinh], [Diachi], [Sdt], [Email]) VALUES (N'12544     ', N'321', N'Vũ đức lâm', N'8/25/2021', N'Nữ', N'ninh bình', N'0125                ', N'lam170920@gmail.com')
INSERT [dbo].[T_Nhanvien] ([Manv], [Mknv], [Tennv], [Ngaysinh], [Gioitinh], [Diachi], [Sdt], [Email]) VALUES (N'admin     ', N'123', N'Hờ Oang Hoang', N'9/23/2000', N'Nam', N'Cộng Hòa-Chí Linh-Hải Dương', N'19001005            ', N'Oang@gmail.com')
INSERT [dbo].[T_Nhanvien] ([Manv], [Mknv], [Tennv], [Ngaysinh], [Gioitinh], [Diachi], [Sdt], [Email]) VALUES (N'admin1    ', N'123', N'Hờ Yên Huyên', N'9/9/2000', N'Nữ', N'Hải Dương', N'18008198            ', N'Huyên@gmail.com')
INSERT [dbo].[T_Nhanvien] ([Manv], [Mknv], [Tennv], [Ngaysinh], [Gioitinh], [Diachi], [Sdt], [Email]) VALUES (N'q31312    ', N'', N'123', N'9/9/2000', N'Nữ', N'', N'                    ', N'')
GO
INSERT [dbo].[T_Nxb] ([Manxb], [Tennxb], [Diachi], [Email], [Sdt]) VALUES (N'GIAODUC   ', N'NXB Giáo dục', N'Hải Dương', N'giaoduc@gmail.com   ', N'65432456            ')
INSERT [dbo].[T_Nxb] ([Manxb], [Tennxb], [Diachi], [Email], [Sdt]) VALUES (N'KIMDONG   ', N'NXB Kim Đồng', N'Hà Nội', N'5643                ', N'kimdong@gmail,com   ')
INSERT [dbo].[T_Nxb] ([Manxb], [Tennxb], [Diachi], [Email], [Sdt]) VALUES (N'TIENPHONG ', N'NXB Tiền Phong', N'TP Hồ Chí Minh', N'tienphong@gmail.com', N'13245342            ')
INSERT [dbo].[T_Nxb] ([Manxb], [Tennxb], [Diachi], [Email], [Sdt]) VALUES (N'TUOITRE   ', N'NXB Tuổi trẻ', N'Hà Nam', N'76543456            ', N'tuoitre@gmail.com   ')
GO
INSERT [dbo].[T_Sach] ([Masach], [Tensach], [Manxb], [Tacgia], [Theloai], [Soluong]) VALUES (N'S001      ', N'Tập đọc lớp 1', N'GIAODUC   ', N'Nguyễn Thị M', N'Giáo dục', 10)
INSERT [dbo].[T_Sach] ([Masach], [Tensach], [Manxb], [Tacgia], [Theloai], [Soluong]) VALUES (N'S002      ', N'Dế mèn phiêu lưu ký', N'KIMDONG   ', N'Tô Hoài', N'Truyện', 3)
INSERT [dbo].[T_Sach] ([Masach], [Tensach], [Manxb], [Tacgia], [Theloai], [Soluong]) VALUES (N'S003      ', N'10 vạn câu hỏi vì sao', N'TUOITRE   ', N'Đinh Văn Tới', N'Khám phá', 4)
INSERT [dbo].[T_Sach] ([Masach], [Tensach], [Manxb], [Tacgia], [Theloai], [Soluong]) VALUES (N'S004      ', N'Bạn và Tôi', N'TIENPHONG ', N'Lệ Thu', N'Tiểu thuyết', 34)
INSERT [dbo].[T_Sach] ([Masach], [Tensach], [Manxb], [Tacgia], [Theloai], [Soluong]) VALUES (N'S005      ', N'Lập trình Web', N'GIAODUC   ', N'Lê Hồng Nhân', N'Lập trình', 50)
INSERT [dbo].[T_Sach] ([Masach], [Tensach], [Manxb], [Tacgia], [Theloai], [Soluong]) VALUES (N'S006      ', N'Tôi đi tìm tôi', N'TIENPHONG ', N'Phạm Đức', N'Tiểu thuyết', 122)
INSERT [dbo].[T_Sach] ([Masach], [Tensach], [Manxb], [Tacgia], [Theloai], [Soluong]) VALUES (N'S007', N'Tuyển tập Đô Rê Mon truyện ngắn', N'KIMDONG   ', N'jâja', N'Truyện tranh', 34)
GO
INSERT [dbo].[T_Sinhvien] ([Masv], [Tensv], [Lop], [Makhoa], [Ngaysinh], [Gioitinh], [Sdt], [Email], [Diachi]) VALUES (N'SV001     ', N'Hoàng Văn An', N'DH8C6     ', N'CNTT      ', N'2000-03-04', N'Nam', N'12345       ', N'An@gmail.com                                      ', N'Hải Dương')
INSERT [dbo].[T_Sinhvien] ([Masv], [Tensv], [Lop], [Makhoa], [Ngaysinh], [Gioitinh], [Sdt], [Email], [Diachi]) VALUES (N'SV002     ', N'Lờ Âm Lâm', N'DH8C6     ', N'CNTT      ', N'9/8/2000', N'Nam', N'52411       ', N'hh@gmail.com                                      ', N'Quảng Ngãi')
INSERT [dbo].[T_Sinhvien] ([Masv], [Tensv], [Lop], [Makhoa], [Ngaysinh], [Gioitinh], [Sdt], [Email], [Diachi]) VALUES (N'SV003     ', N'Cơ Yên Kiên', N'DH8KT4    ', N'KT        ', N'6/30/2000', N'Nam', N'48512       ', N'hue@gmail.com                                     ', N'TP.Hồ Chí Minh')
INSERT [dbo].[T_Sinhvien] ([Masv], [Tensv], [Lop], [Makhoa], [Ngaysinh], [Gioitinh], [Sdt], [Email], [Diachi]) VALUES (N'SV004     ', N'Đờ Ức Đức', N'CB5       ', N'LUAT      ', N'9/19/2000', N'Nam', N'43213       ', N'vlllam@gmail.com                                  ', N'Hoa Lư -Ninh Bình')
INSERT [dbo].[T_Sinhvien] ([Masv], [Tensv], [Lop], [Makhoa], [Ngaysinh], [Gioitinh], [Sdt], [Email], [Diachi]) VALUES (N'SV005     ', N'1234', N'234       ', N'KT        ', N'6/19/2000', N'Nữ', N'324         ', N'1243                                              ', N'1243')
INSERT [dbo].[T_Sinhvien] ([Masv], [Tensv], [Lop], [Makhoa], [Ngaysinh], [Gioitinh], [Sdt], [Email], [Diachi]) VALUES (N'SV006', N'Cờ Ương Cương', N'DH8C6     ', N'CNTT      ', N'12/7/2000', N'Nam', N'00000000    ', N'vCuong@gmail.com                                  ', N'Cộng Hòa-Chí Linh Hải Dương')
INSERT [dbo].[T_Sinhvien] ([Masv], [Tensv], [Lop], [Makhoa], [Ngaysinh], [Gioitinh], [Sdt], [Email], [Diachi]) VALUES (N'SV008', N'123', N'123       ', N'QTKD      ', N'5/10/2021', N'Nam', N'123         ', N'123                                               ', N'123')
INSERT [dbo].[T_Sinhvien] ([Masv], [Tensv], [Lop], [Makhoa], [Ngaysinh], [Gioitinh], [Sdt], [Email], [Diachi]) VALUES (N'SV009', N'123', N'123       ', N'QTKD      ', N'5/10/2021', N'Nam', N'123         ', N'123                                               ', N'123')
INSERT [dbo].[T_Sinhvien] ([Masv], [Tensv], [Lop], [Makhoa], [Ngaysinh], [Gioitinh], [Sdt], [Email], [Diachi]) VALUES (N'SV010', N'123', N'123       ', N'KTTN      ', N'5/10/2021', N'', N'            ', N'                                                  ', N'')
INSERT [dbo].[T_Sinhvien] ([Masv], [Tensv], [Lop], [Makhoa], [Ngaysinh], [Gioitinh], [Sdt], [Email], [Diachi]) VALUES (N'SV011', N'123123', N'          ', N'KTTN      ', N'5/13/2021', N'Nữ', N'            ', N'                                                  ', N'')
GO
ALTER TABLE [dbo].[T_Muontra]  WITH CHECK ADD  CONSTRAINT [FK_T_Muontra_T_Sach] FOREIGN KEY([Masach])
REFERENCES [dbo].[T_Sach] ([Masach])
GO
ALTER TABLE [dbo].[T_Muontra] CHECK CONSTRAINT [FK_T_Muontra_T_Sach]
GO
ALTER TABLE [dbo].[T_Muontra]  WITH CHECK ADD  CONSTRAINT [FK_T_Muontra_T_Sinhvien] FOREIGN KEY([Masv])
REFERENCES [dbo].[T_Sinhvien] ([Masv])
GO
ALTER TABLE [dbo].[T_Muontra] CHECK CONSTRAINT [FK_T_Muontra_T_Sinhvien]
GO
ALTER TABLE [dbo].[T_Sach]  WITH CHECK ADD  CONSTRAINT [FK_T_Sach_T_Nxb] FOREIGN KEY([Manxb])
REFERENCES [dbo].[T_Nxb] ([Manxb])
GO
ALTER TABLE [dbo].[T_Sach] CHECK CONSTRAINT [FK_T_Sach_T_Nxb]
GO
ALTER TABLE [dbo].[T_Sinhvien]  WITH CHECK ADD  CONSTRAINT [FK_T_Sinhvien_T_Khoa] FOREIGN KEY([Makhoa])
REFERENCES [dbo].[T_Khoa] ([Makhoa])
GO
ALTER TABLE [dbo].[T_Sinhvien] CHECK CONSTRAINT [FK_T_Sinhvien_T_Khoa]
GO

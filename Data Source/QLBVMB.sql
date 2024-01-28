DROP DATABASE QLBVMB
use master
CREATE DATABASE QLBVMB
GO

USE QLBVMB
GO
--Tạo bảng Account--
CREATE TABLE Account(
	Id_Account varchar(10),
	Username varchar(100),
	Password varchar(100),
	Position nvarchar(100),
	DisplayName nvarchar(100),
	CONSTRAINT pk_account PRIMARY KEY(Id_Account)
)

--Tạo bảng Plane--
CREATE TABLE Plane(
	Id_Plane varchar(10),
	Type_Plane varchar(100),
	Brand varchar(100),
	CONSTRAINT pk_plane PRIMARY KEY(Id_Plane)
)
--Tạo bảng Airport--
CREATE TABLE Airport(
	Id_Airport varchar(10),
	Name_Airport nvarchar(100),
	Id_Locate varchar(10),
	CONSTRAINT pk_airport PRIMARY KEY(Id_Airport)
)
--Tạo bảng Flight--
CREATE TABLE Flight(
	Id_Flight varchar(10),
	Time_Start datetime,
	Time_End datetime,
	Id_Plane varchar(10),
	Airport_Take_Off varchar(10),
	Airport_Landing varchar(10),
	Total_Seat tinyint,
	CONSTRAINT pk_flight PRIMARY KEY(Id_Flight)
)

--Tạo bảng Locate--
CREATE TABLE Locate(
	Id_Locate varchar(10),
	Name_Locate nvarchar(100),
	CONSTRAINT pk_locate PRIMARY KEY(Id_Locate)
)
--Tạo bảng Customer--
CREATE TABLE Customer(
	Id_Customer varchar(10),
	Name nvarchar(100),
	Age tinyint,
	Sex nvarchar(100),
	Email varchar(100),
	Tel varchar(100),
	Locate varchar(10),
	CONSTRAINT pk_customer PRIMARY KEY(Id_Customer)
)
--Tạo bảng Booked--
CREATE TABLE Booked(
	Id_Booked varchar(10),
	Date datetime,
	Id_Flight varchar(10),
	Id_Ticket varchar(10),
	Id_Customer varchar(10),
	Id_CB varchar(10),
	Id_AccountSeller varchar(10),
	CONSTRAINT pk_booked PRIMARY KEY(Id_Booked)
)
--Tạo bảng Ticket--
CREATE TABLE Ticket(
	Id_Ticket varchar(10),
	Type_Ticket varchar(100),
	Id_Seat varchar(10),
	Price money,
	Status varchar(100),
	Id_Flight varchar(10),
	CONSTRAINT pk_ticket PRIMARY KEY(Id_Ticket)
)
--Tạo bảng Checked Baggage--
CREATE TABLE Checked_Baggage(
	Id_CB varchar(10),
	Type_CB varchar(100),
	Extra_Price money,
	CONSTRAINT pk_cb PRIMARY KEY(Id_CB)
)

--Tạo bảng RolePosition--
CREATE TABLE RolePosition(
	Id_Position varchar(10),
	DisplayName nvarchar(100),
	CONSTRAINT pk_ps PRIMARY KEY(Id_Position)
)

--Thêm thuộc tính Position
INSERT INTO RolePosition VALUES ('1','Nhân viên')
INSERT INTO RolePosition VALUES ('2','Quản lý')
select * from RolePosition

--Thêm khóa ngoại cho Flight
ALTER TABLE Flight ADD CONSTRAINT fk01_flight FOREIGN KEY(Id_Plane) REFERENCES Plane(Id_Plane)
ALTER TABLE Flight ADD CONSTRAINT fk02_flight FOREIGN KEY(Airport_Take_Off) REFERENCES Airport(Id_Airport)
ALTER TABLE Flight ADD CONSTRAINT fk03_flight FOREIGN KEY(Airport_Landing) REFERENCES Airport(Id_Airport)
--Thêm khóa ngoại Airport
ALTER TABLE Airport ADD CONSTRAINT fk_airport FOREIGN KEY(Id_Locate) REFERENCES Locate(Id_Locate)
--Thêm khóa ngoại Ticket
ALTER TABLE Ticket ADD CONSTRAINT fk_ticket FOREIGN KEY(Id_Flight) REFERENCES Flight(Id_Flight)
--Thêm khóa ngoại Booked
ALTER TABLE Booked ADD CONSTRAINT fk01_booked FOREIGN KEY(Id_Flight) REFERENCES Flight(Id_Flight)
ALTER TABLE Booked ADD CONSTRAINT fk02_booked FOREIGN KEY(Id_Ticket) REFERENCES Ticket(Id_Ticket)
ALTER TABLE Booked ADD CONSTRAINT fk03_booked FOREIGN KEY(Id_Customer) REFERENCES Customer(Id_Customer)
ALTER TABLE Booked ADD CONSTRAINT fk04_booked FOREIGN KEY(Id_CB) REFERENCES Checked_Baggage(Id_CB)
ALTER TABLE Booked ADD CONSTRAINT fk05_booked FOREIGN KEY(Id_AccountSeller) REFERENCES Account(Id_Account)
--Thêm khóa ngoại Customer
ALTER TABLE Customer ADD CONSTRAINT fk_customer FOREIGN KEY(Locate) REFERENCES Locate(Id_Locate)

--Thêm thuộc tính Account
INSERT INTO Account VALUES ('NV001','staff','staff','Nhân viên','staff')
INSERT INTO Account VALUES ('QL001','admin','admin','Quản lý','admin')
INSERT INTO Account VALUES ('NV002','lam','1234567890','Nhân viên','lam')
INSERT INTO Account VALUES ('QL002','phat','1234567890','Quản lý','phat')
SELECT * FROM account

--Thêm thuộc tính Locate
INSERT INTO Locate VALUES ('72', 'BR-VT')
INSERT INTO Locate VALUES ('77', 'Bình Định')
INSERT INTO Locate VALUES ('69', 'Cà Mau')
INSERT INTO Locate VALUES ('65', 'Cần Thơ')
INSERT INTO Locate VALUES ('47', 'Đắk Lắk')
INSERT INTO Locate VALUES ('43', 'Đà Nẵng')
INSERT INTO Locate VALUES ('27', 'Điện Biên')
INSERT INTO Locate VALUES ('59', 'TPHCM')
INSERT INTO Locate VALUES ('33', 'Hà Nội')
INSERT INTO Locate VALUES ('81', 'Gia Lai')
INSERT INTO Locate VALUES ('15', 'Hải Phòng')
INSERT INTO Locate VALUES ('79', 'Khánh Hòa')
INSERT INTO Locate VALUES ('68', 'Kiên Giang')
INSERT INTO Locate VALUES ('49', 'Lâm Đồng')
INSERT INTO Locate VALUES ('37', 'Nghệ An')
INSERT INTO Locate VALUES ('78', 'Phú Yên')
INSERT INTO Locate VALUES ('73', 'Quảng Bình')
INSERT INTO Locate VALUES ('92', 'Quảng Nam')
INSERT INTO Locate VALUES ('75', 'Thừa Thiên Huế')
INSERT INTO Locate VALUES ('36', 'Thanh Hóa')
INSERT INTO Locate VALUES ('14', 'Quảng Ninh')
SELECT * FROM Locate

--Thêm thuộc tính Plane
INSERT INTO Plane VALUES ('VNA-A1','Boeing 787','Vietnam Airline')
INSERT INTO Plane VALUES ('VJ-8','Airbus A350','Vietjet Air')
INSERT INTO Plane VALUES ('VJ-9','Airbus A353','Vietjet Air')
INSERT INTO Plane VALUES ('BA-B4','Boeing 787-9','Bamboo Airways')
INSERT INTO Plane VALUES ('BA-B5','Boeing 787-9','Bamboo Airways')
INSERT INTO Plane VALUES ('PA-A550','Airbus A320','Pacific Airlines')
INSERT INTO Plane VALUES ('VTA-V7','Airbus A321','Vietravel Airlines')
INSERT INTO Plane VALUES ('VC-C230','ATR 72-500','VASCO')
SELECT * FROM plane

--Thêm thuộc tính Checked_Baggage
INSERT INTO Checked_Baggage VALUES ('FCB','Free',0)
INSERT INTO Checked_Baggage VALUES ('10CB','10kg',181000)
INSERT INTO Checked_Baggage VALUES ('23CB','23kg',300000)
SELECT * FROM checked_baggage

--Thêm thuộc tính Airport
INSERT INTO Airport VALUES ('VCS', 'Côn đảo', '72')
INSERT INTO Airport VALUES ('UIH', 'Phù Cát', '77')
INSERT INTO Airport VALUES ('CAH', 'Cà Mau', '69')
INSERT INTO Airport VALUES ('VCA', 'Cần Thơ', '65')
INSERT INTO Airport VALUES ('BMV', 'Buôn Ma Thuột', '47')
INSERT INTO Airport VALUES ('DAD', 'Đà Nẵng', '43')
INSERT INTO Airport VALUES ('DIN', 'Điện Biên Phủ', '27')
INSERT INTO Airport VALUES ('TSN', 'Tân Sơn Nhất', '59')
INSERT INTO Airport VALUES ('NB', 'Nội Bài', '33')
INSERT INTO Airport VALUES ('PXU', 'Pleiku', '81')
INSERT INTO Airport VALUES ('HPH', 'Cát Bi', '15')
INSERT INTO Airport VALUES ('CXR', 'Cam Ranh', '79')
INSERT INTO Airport VALUES ('VKG', 'Rạch Giá', '68')
INSERT INTO Airport VALUES ('PQC', 'Phú Quốc', '68')
INSERT INTO Airport VALUES ('DLI', 'Liên Khương', '49')
INSERT INTO Airport VALUES ('VII', 'Vinh', '37')
INSERT INTO Airport VALUES ('TBB', 'Tuy Hòa', '78')
INSERT INTO Airport VALUES ('VDH', 'Đồng Hới', '73')
INSERT INTO Airport VALUES ('VCL', 'Chu Lai', '92')
INSERT INTO Airport VALUES ('HUI', 'Phú Bài', '75')
INSERT INTO Airport VALUES ('THD', 'Thọ Xuân', '36')
INSERT INTO Airport VALUES ('VDO', 'Vân Đồn', '14')
SELECT * FROM airport

--Thêm thuộc tính Flight
INSERT INTO Flight VALUES ('BA101', '2024-02-05 07:45:00', '2024-02-05 09:05:00', 'BA-B5', 'DLI', 'NB', 62)
INSERT INTO Flight VALUES ('BA102', '2024-02-05 13:15:00', '2024-02-05 14:35:00', 'BA-B4', 'DLI', 'NB', 62)
INSERT INTO Flight VALUES ('VJ452', '2024-02-10 11:30:00', '2024-02-10 13:35:00', 'VJ-8', 'NB', 'VCA', 22)
INSERT INTO Flight VALUES ('VJ623', '2024-02-15 17:00:00', '2024-02-15 18:15:00', 'VJ-9', 'DAD', 'TSN', 48)
INSERT INTO Flight VALUES ('VNA114', '2024-03-20 09:30:00', '2024-03-20 11:30:00', 'VNA-A1', 'TSN', 'NB', 25)
INSERT INTO Flight VALUES ('VNA085', '2024-02-09 00:10:00', '2024-02-09 02:25:00', 'VNA-A1', 'TSN', 'NB', 25)
INSERT INTO Flight VALUES ('PA6000', '2024-02-09 06:15:00', '2024-02-09 08:25:00', 'PA-A550', 'TSN', 'NB', 88)
INSERT INTO Flight VALUES ('VJ156', '2024-02-09 19:40:00', '2024-02-09 21:50:00', 'VJ-9', 'TSN', 'NB', 48)
SELECT * FROM flight

--Thêm thuộc tính Customer
INSERT INTO Customer VALUES ('F203W3','Nguyễn Văn A',32,'Nam','nva89@gmail.com','0946205345','43')
INSERT INTO Customer VALUES ('J385H3','Trần Văn B',19,'Nam','tvb77@gmail.com','0396233535','69')
INSERT INTO Customer VALUES ('H32K24','Trần Thị Hoa',29,'Nữ','tth66@gmail.com','0462453238','33')
INSERT INTO Customer VALUES ('KF2014','Lê Quốc Phong',43,'Nam','lqp11@gmail.com','0592857144','59')
SELECT * FROM customer

--Thêm thuộc tính Ticket
INSERT INTO Ticket VALUES ('VJ623001', 'Skyboss', '1A', 4780000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623002', 'Skyboss', '1B', 4780000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623003', 'Skyboss', '1C', 4780000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623004', 'Skyboss', '1D', 4780000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623005', 'Skyboss', '2A', 4780000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623006', 'Skyboss', '2B', 4780000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623007', 'Skyboss', '2C', 4780000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623008', 'Skyboss', '2D', 4780000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623009', 'Skyboss', '3A', 4780000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623010', 'Skyboss', '3B', 4780000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623011', 'Skyboss', '3C', 4780000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623012', 'Skyboss', '3D', 4780000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623013', 'Deluxe', '4A', 3650000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623014', 'Deluxe', '4B', 3650000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623015', 'Deluxe', '4C', 3650000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623016', 'Deluxe', '4D', 3650000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623017', 'Deluxe', '4E', 3650000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623018', 'Deluxe', '4F', 3650000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623019', 'Deluxe', '5A', 3650000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623020', 'Deluxe', '5B', 3650000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623021', 'Deluxe', '5C', 3650000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623022', 'Deluxe', '5D', 3650000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623023', 'Deluxe', '5E', 3650000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623024', 'Deluxe', '5F', 3650000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623025', 'Economic', '6A', 1380000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623026', 'Economic', '6B', 1380000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623027', 'Economic', '6C', 1380000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623028', 'Economic', '6D', 1380000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623029', 'Economic', '6E', 1380000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623030', 'Economic', '6F', 1380000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623031', 'Economic', '7A', 1380000, 'Booked', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623032', 'Economic', '7B', 1380000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623033', 'Economic', '7C', 1380000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623034', 'Economic', '7D', 1380000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623035', 'Economic', '7E', 1380000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623036', 'Economic', '7F', 1380000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623037', 'Economic', '8A', 1380000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623038', 'Economic', '8B', 1380000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623039', 'Economic', '8C', 1380000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623040', 'Economic', '8D', 1380000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623041', 'Economic', '8E', 1380000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623042', 'Economic', '8F', 1380000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623043', 'Economic', '9A', 1380000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623044', 'Economic', '9B', 1380000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623045', 'Economic', '9C', 1380000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623046', 'Economic', '9D', 1380000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623047', 'Economic', '9E', 1380000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('VJ623048', 'Economic', '9F', 1380000, 'Remained', 'VJ623')
INSERT INTO Ticket VALUES ('BA102001', 'Luxury', '1A', 5500000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102002', 'Luxury', '1B', 5500000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102003', 'Luxury', '2A', 5500000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102004', 'Luxury', '2B', 5500000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102005', 'Luxury', '3A', 5500000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102006', 'Luxury', '3B', 5500000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102007', 'Luxury', '4A', 5500000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102008', 'Luxury', '4B', 5500000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102009', 'Deluxe', '5A', 4200000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102010', 'Deluxe', '5B', 4200000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102011', 'Deluxe', '5C', 4200000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102012', 'Deluxe', '5D', 4200000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102013', 'Deluxe', '6A', 4200000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102014', 'Deluxe', '6B', 4200000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102015', 'Deluxe', '6C', 4200000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102016', 'Deluxe', '6D', 4200000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102017', 'Deluxe', '7A', 4200000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102018', 'Deluxe', '7B', 4200000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102019', 'Deluxe', '7C', 4200000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102020', 'Deluxe', '7D', 4200000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102021', 'Deluxe', '8A', 4200000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102022', 'Deluxe', '8B', 4200000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102023', 'Deluxe', '8C', 4200000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102024', 'Deluxe', '8D', 4200000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102025', 'Deluxe', '9A', 4200000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102026', 'Deluxe', '9B', 4200000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102027', 'Deluxe', '9C', 4200000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102028', 'Deluxe', '9D', 4200000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102029', 'Deluxe', '10A', 4200000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102030', 'Deluxe', '10B', 4200000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102031', 'Deluxe', '10C', 4200000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102032', 'Deluxe', '10D', 4200000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102033', 'Economic', '11A', 1694000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102034', 'Economic', '11B', 1694000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102035', 'Economic', '11C', 1694000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102036', 'Economic', '11D', 1694000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102037', 'Economic', '11E', 1694000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102038', 'Economic', '11F', 1694000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102039', 'Economic', '12A', 1694000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102040', 'Economic', '12B', 1694000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102041', 'Economic', '12C', 1694000, 'Booked', 'BA102')
INSERT INTO Ticket VALUES ('BA102042', 'Economic', '12D', 1694000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102043', 'Economic', '12E', 1694000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102044', 'Economic', '12F', 1694000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102045', 'Economic', '13A', 1694000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102046', 'Economic', '13B', 1694000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102047', 'Economic', '13C', 1694000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102048', 'Economic', '13D', 1694000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102049', 'Economic', '13E', 1694000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102050', 'Economic', '13F', 1694000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102051', 'Economic', '14A', 1694000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102052', 'Economic', '14B', 1694000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102053', 'Economic', '14C', 1694000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102054', 'Economic', '14D', 1694000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102055', 'Economic', '14E', 1694000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102056', 'Economic', '14F', 1694000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102057', 'Economic', '15A', 1694000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102058', 'Economic', '15B', 1694000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102059', 'Economic', '15C', 1694000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102060', 'Economic', '15D', 1694000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102061', 'Economic', '15E', 1694000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('BA102062', 'Economic', '15F', 1694000, 'Remained', 'BA102')
INSERT INTO Ticket VALUES ('VJ452001', 'Deluxe', '1A', 2450000, 'Remained', 'VJ452')
INSERT INTO Ticket VALUES ('VJ452002', 'Deluxe', '1B', 2450000, 'Remained', 'VJ452')
INSERT INTO Ticket VALUES ('VJ452003', 'Deluxe', '2A', 2450000, 'Remained', 'VJ452')
INSERT INTO Ticket VALUES ('VJ452004', 'Deluxe', '2B', 2450000, 'Remained', 'VJ452')
INSERT INTO Ticket VALUES ('VJ452005', 'Deluxe', '3A', 2450000, 'Remained', 'VJ452')
INSERT INTO Ticket VALUES ('VJ452006', 'Deluxe', '3B', 2450000, 'Remained', 'VJ452')
INSERT INTO Ticket VALUES ('VJ452007', 'Economic', '4A', 2150000, 'Remained', 'VJ452')
INSERT INTO Ticket VALUES ('VJ452008', 'Economic', '4B', 2150000, 'Remained', 'VJ452')
INSERT INTO Ticket VALUES ('VJ452009', 'Economic', '4C', 2150000, 'Remained', 'VJ452')
INSERT INTO Ticket VALUES ('VJ452010', 'Economic', '4D', 2150000, 'Remained', 'VJ452')
INSERT INTO Ticket VALUES ('VJ452011', 'Economic', '5A', 2150000, 'Remained', 'VJ452')
INSERT INTO Ticket VALUES ('VJ452012', 'Economic', '5B', 2150000, 'Remained', 'VJ452')
INSERT INTO Ticket VALUES ('VJ452013', 'Economic', '5C', 2150000, 'Remained', 'VJ452')
INSERT INTO Ticket VALUES ('VJ452014', 'Economic', '5D', 2150000, 'Remained', 'VJ452')
INSERT INTO Ticket VALUES ('VJ452015', 'Economic', '6A', 2150000, 'Remained', 'VJ452')
INSERT INTO Ticket VALUES ('VJ452016', 'Economic', '6B', 2150000, 'Remained', 'VJ452')
INSERT INTO Ticket VALUES ('VJ452017', 'Economic', '6C', 2150000, 'Remained', 'VJ452')
INSERT INTO Ticket VALUES ('VJ452018', 'Economic', '6D', 2150000, 'Remained', 'VJ452')
INSERT INTO Ticket VALUES ('VJ452019', 'Economic', '7A', 2150000, 'Remained', 'VJ452')
INSERT INTO Ticket VALUES ('VJ452020', 'Economic', '7B', 2150000, 'Booked', 'VJ452')
INSERT INTO Ticket VALUES ('VJ452021', 'Economic', '7C', 2150000, 'Remained', 'VJ452')
INSERT INTO Ticket VALUES ('VJ452022', 'Economic', '7D', 2150000, 'Remained', 'VJ452')
INSERT INTO Ticket VALUES ('VNA114001', 'Business Flexible', '1A', 8776000, 'Remained', 'VNA114')
INSERT INTO Ticket VALUES ('VNA114002', 'Business Flexible', '1B', 8776000, 'Remained', 'VNA114')
INSERT INTO Ticket VALUES ('VNA114003', 'Business Flexible', '1C', 8776000, 'Remained', 'VNA114')
INSERT INTO Ticket VALUES ('VNA114004', 'Business Flexible', '2A', 8776000, 'Remained', 'VNA114')
INSERT INTO Ticket VALUES ('VNA114005', 'Business Flexible', '2B', 8776000, 'Remained', 'VNA114')
INSERT INTO Ticket VALUES ('VNA114006', 'Business Flexible', '2C', 8776000, 'Remained', 'VNA114')
INSERT INTO Ticket VALUES ('VNA114007', 'Business Flexible', '3A', 8776000, 'Remained', 'VNA114')
INSERT INTO Ticket VALUES ('VNA114008', 'Business Flexible', '3B', 8776000, 'Remained', 'VNA114')
INSERT INTO Ticket VALUES ('VNA114009', 'Business Flexible', '3C', 8776000, 'Remained', 'VNA114')
INSERT INTO Ticket VALUES ('VNA114010', 'Business Classic', '4A', 3525000, 'Booked', 'VNA114')
INSERT INTO Ticket VALUES ('VNA114011', 'Business Classic', '4B', 3525000, 'Remained', 'VNA114')
INSERT INTO Ticket VALUES ('VNA114012', 'Business Classic', '4C', 3525000, 'Remained', 'VNA114')
INSERT INTO Ticket VALUES ('VNA114013', 'Business Classic', '4D', 3525000, 'Remained', 'VNA114')
INSERT INTO Ticket VALUES ('VNA114014', 'Business Classic', '5A', 3525000, 'Remained', 'VNA114')
INSERT INTO Ticket VALUES ('VNA114015', 'Business Classic', '5B', 3525000, 'Remained', 'VNA114')
INSERT INTO Ticket VALUES ('VNA114016', 'Business Classic', '5C', 3525000, 'Remained', 'VNA114')
INSERT INTO Ticket VALUES ('VNA114017', 'Business Classic', '5D', 3525000, 'Remained', 'VNA114')
INSERT INTO Ticket VALUES ('VNA114018', 'Business Classic', '6A', 3525000, 'Remained', 'VNA114')
INSERT INTO Ticket VALUES ('VNA114019', 'Business Classic', '6B', 3525000, 'Remained', 'VNA114')
INSERT INTO Ticket VALUES ('VNA114020', 'Business Classic', '6C', 3525000, 'Remained', 'VNA114')
INSERT INTO Ticket VALUES ('VNA114021', 'Business Classic', '6D', 3525000, 'Remained', 'VNA114')
INSERT INTO Ticket VALUES ('VNA114022', 'Business Classic', '7A', 3525000, 'Remained', 'VNA114')
INSERT INTO Ticket VALUES ('VNA114023', 'Business Classic', '7B', 3525000, 'Remained', 'VNA114')
INSERT INTO Ticket VALUES ('VNA114024', 'Business Classic', '7C', 3525000, 'Remained', 'VNA114')
INSERT INTO Ticket VALUES ('VNA114025', 'Business Classic', '7D', 3525000, 'Reained', 'VNA114')

INSERT INTO Ticket VALUES ('BA101001', 'Luxury', '1A', 5500000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101002', 'Luxury', '1B', 5500000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101003', 'Luxury', '2A', 5500000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101004', 'Luxury', '2B', 5500000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101005', 'Luxury', '3A', 5500000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101006', 'Luxury', '3B', 5500000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101007', 'Luxury', '4A', 5500000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101008', 'Luxury', '4B', 5500000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101009', 'Deluxe', '5A', 4200000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101010', 'Deluxe', '5B', 4200000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101011', 'Deluxe', '5C', 4200000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101012', 'Deluxe', '5D', 4200000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101013', 'Deluxe', '6A', 4200000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101014', 'Deluxe', '6B', 4200000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101015', 'Deluxe', '6C', 4200000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101016', 'Deluxe', '6D', 4200000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101017', 'Deluxe', '7A', 4200000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101018', 'Deluxe', '7B', 4200000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101019', 'Deluxe', '7C', 4200000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101020', 'Deluxe', '7D', 4200000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101021', 'Deluxe', '8A', 4200000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101022', 'Deluxe', '8B', 4200000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101023', 'Deluxe', '8C', 4200000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101024', 'Deluxe', '8D', 4200000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101025', 'Deluxe', '9A', 4200000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101026', 'Deluxe', '9B', 4200000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101027', 'Deluxe', '9C', 4200000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101028', 'Deluxe', '9D', 4200000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101029', 'Deluxe', '10A', 4200000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101030', 'Deluxe', '10B', 4200000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101031', 'Deluxe', '10C', 4200000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101032', 'Deluxe', '10D', 4200000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101033', 'Economic', '11A', 1694000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101034', 'Economic', '11B', 1694000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101035', 'Economic', '11C', 1694000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101036', 'Economic', '11D', 1694000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101037', 'Economic', '11E', 1694000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101038', 'Economic', '11F', 1694000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101039', 'Economic', '12A', 1694000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101040', 'Economic', '12B', 1694000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101041', 'Economic', '12C', 1694000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101042', 'Economic', '12D', 1694000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101043', 'Economic', '12E', 1694000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101044', 'Economic', '12F', 1694000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101045', 'Economic', '13A', 1694000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101046', 'Economic', '13B', 1694000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101047', 'Economic', '13C', 1694000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101048', 'Economic', '13D', 1694000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101049', 'Economic', '13E', 1694000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101050', 'Economic', '13F', 1694000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101051', 'Economic', '14A', 1694000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101052', 'Economic', '14B', 1694000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101053', 'Economic', '14C', 1694000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101054', 'Economic', '14D', 1694000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101055', 'Economic', '14E', 1694000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101056', 'Economic', '14F', 1694000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101057', 'Economic', '15A', 1694000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101058', 'Economic', '15B', 1694000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101059', 'Economic', '15C', 1694000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101060', 'Economic', '15D', 1694000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101061', 'Economic', '15E', 1694000, 'Remained', 'BA101')
INSERT INTO Ticket VALUES ('BA101062', 'Economic', '15F', 1694000, 'Remained', 'BA101')

INSERT INTO Ticket VALUES ('VNA085001', 'Business Flexible', '1A', 9800000, 'Remained', 'VNA085')
INSERT INTO Ticket VALUES ('VNA085002', 'Business Flexible', '1B', 9800000, 'Remained', 'VNA085')
INSERT INTO Ticket VALUES ('VNA085003', 'Business Flexible', '1C', 9800000, 'Remained', 'VNA085')
INSERT INTO Ticket VALUES ('VNA085004', 'Business Flexible', '2A', 9800000, 'Remained', 'VNA085')
INSERT INTO Ticket VALUES ('VNA085005', 'Business Flexible', '2B', 9800000, 'Remained', 'VNA085')
INSERT INTO Ticket VALUES ('VNA085006', 'Business Flexible', '2C', 9800000, 'Remained', 'VNA085')
INSERT INTO Ticket VALUES ('VNA085007', 'Business Flexible', '3A', 9800000, 'Remained', 'VNA085')
INSERT INTO Ticket VALUES ('VNA085008', 'Business Flexible', '3B', 9800000, 'Remained', 'VNA085')
INSERT INTO Ticket VALUES ('VNA085009', 'Business Flexible', '3C', 9800000, 'Remained', 'VNA085')
INSERT INTO Ticket VALUES ('VNA085010', 'Business Classic', '4A', 5860000, 'Remained', 'VNA085')
INSERT INTO Ticket VALUES ('VNA085011', 'Business Classic', '4B', 5860000, 'Remained', 'VNA085')
INSERT INTO Ticket VALUES ('VNA085012', 'Business Classic', '4C', 5860000, 'Remained', 'VNA085')
INSERT INTO Ticket VALUES ('VNA085013', 'Business Classic', '4D', 5860000, 'Remained', 'VNA085')
INSERT INTO Ticket VALUES ('VNA085014', 'Business Classic', '5A', 5860000, 'Remained', 'VNA085')
INSERT INTO Ticket VALUES ('VNA085015', 'Business Classic', '5B', 5860000, 'Remained', 'VNA085')
INSERT INTO Ticket VALUES ('VNA085016', 'Business Classic', '5C', 5860000, 'Remained', 'VNA085')
INSERT INTO Ticket VALUES ('VNA085017', 'Business Classic', '5D', 5860000, 'Remained', 'VNA085')
INSERT INTO Ticket VALUES ('VNA085018', 'Business Classic', '6A', 5860000, 'Remained', 'VNA085')
INSERT INTO Ticket VALUES ('VNA085019', 'Business Classic', '6B', 5860000, 'Remained', 'VNA085')
INSERT INTO Ticket VALUES ('VNA085020', 'Business Classic', '6C', 5860000, 'Remained', 'VNA085')
INSERT INTO Ticket VALUES ('VNA085021', 'Business Classic', '6D', 5860000, 'Remained', 'VNA085')
INSERT INTO Ticket VALUES ('VNA085022', 'Business Classic', '7A', 5860000, 'Remained', 'VNA085')
INSERT INTO Ticket VALUES ('VNA085023', 'Business Classic', '7B', 5860000, 'Remained', 'VNA085')
INSERT INTO Ticket VALUES ('VNA085024', 'Business Classic', '7C', 5860000, 'Remained', 'VNA085')
INSERT INTO Ticket VALUES ('VNA085025', 'Business Classic', '7D', 5860000, 'Remained', 'VNA085')

INSERT INTO Ticket VALUES ('PA6000001', 'Economy Flex', '1A', 3525000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000002', 'Economy Flex', '1B', 3525000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000003', 'Economy Flex', '1C', 3525000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000004', 'Economy Flex', '1D', 3525000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000005', 'Economy Flex', '2A', 3525000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000006', 'Economy Flex', '2B', 3525000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000007', 'Economy Flex', '2C', 3525000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000008', 'Economy Flex', '2D', 3525000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000009', 'Economy Flex', '3A', 3525000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000010', 'Economy Flex', '3B', 3525000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000011', 'Economy Flex', '3C', 3525000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000012', 'Economy Flex', '3D', 3525000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000013', 'Economy Flex', '4A', 3525000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000014', 'Economy Flex', '4B', 3525000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000015', 'Economy Flex', '4C', 3525000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000016', 'Economy Flex', '4D', 3525000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000017', 'Economy Flex', '5A', 3525000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000018', 'Economy Flex', '5B', 3525000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000019', 'Economy Flex', '5C', 3525000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000020', 'Economy Flex', '5D', 3525000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000021', 'Economy Flex', '6A', 3525000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000022', 'Economy Flex', '6B', 3525000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000023', 'Economy Flex', '6C', 3525000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000024', 'Economy Flex', '6D', 3525000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000025', 'Economy Flex', '7A', 3525000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000026', 'Economy Flex', '7B', 3525000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000027', 'Economy Flex', '7C', 3525000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000028', 'Economy Flex', '7D', 3525000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000029', 'Economy Classic', '8A', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000030', 'Economy Classic', '8B', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000031', 'Economy Classic', '8C', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000032', 'Economy Classic', '8D', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000033', 'Economy Classic', '8E', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000034', 'Economy Classic', '8F', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000035', 'Economy Classic', '9A', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000036', 'Economy Classic', '9B', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000037', 'Economy Classic', '9C', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000038', 'Economy Classic', '9D', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000039', 'Economy Classic', '9E', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000040', 'Economy Classic', '9F', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000041', 'Economy Classic', '10A', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000042', 'Economy Classic', '10B', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000043', 'Economy Classic', '10C', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000044', 'Economy Classic', '10D', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000045', 'Economy Classic', '10E', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000046', 'Economy Classic', '10F', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000047', 'Economy Classic', '11A', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000048', 'Economy Classic', '11B', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000049', 'Economy Classic', '11C', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000050', 'Economy Classic', '11D', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000051', 'Economy Classic', '11E', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000052', 'Economy Classic', '11F', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000053', 'Economy Classic', '12A', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000054', 'Economy Classic', '12B', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000055', 'Economy Classic', '12C', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000056', 'Economy Classic', '12D', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000057', 'Economy Classic', '12E', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000058', 'Economy Classic', '12F', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000059', 'Economy Classic', '13A', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000060', 'Economy Classic', '13B', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000061', 'Economy Classic', '13C', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000062', 'Economy Classic', '13D', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000063', 'Economy Classic', '13E', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000064', 'Economy Classic', '13F', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000065', 'Economy Classic', '14A', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000066', 'Economy Classic', '14B', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000067', 'Economy Classic', '14C', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000068', 'Economy Classic', '14D', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000069', 'Economy Classic', '14E', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000070', 'Economy Classic', '14F', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000071', 'Economy Classic', '15A', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000072', 'Economy Classic', '15B', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000073', 'Economy Classic', '15C', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000074', 'Economy Classic', '15D', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000075', 'Economy Classic', '15E', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000076', 'Economy Classic', '15F', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000077', 'Economy Classic', '16A', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000078', 'Economy Classic', '16B', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000079', 'Economy Classic', '16C', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000080', 'Economy Classic', '16D', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000081', 'Economy Classic', '16E', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000082', 'Economy Classic', '16F', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000083', 'Economy Classic', '17A', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000084', 'Economy Classic', '17B', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000085', 'Economy Classic', '17C', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000086', 'Economy Classic', '17D', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000087', 'Economy Classic', '17E', 2847000, 'Remained', 'PA6000')
INSERT INTO Ticket VALUES ('PA6000088', 'Economy Classic', '17F', 2847000, 'Remained', 'PA6000')

INSERT INTO Ticket VALUES ('VJ156001', 'Skyboss', '1A', 3690000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156002', 'Skyboss', '1B', 3690000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156003', 'Skyboss', '1C', 3690000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156004', 'Skyboss', '1D', 3690000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156005', 'Skyboss', '2A', 3690000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156006', 'Skyboss', '2B', 3690000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156007', 'Skyboss', '2C', 3690000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156008', 'Skyboss', '2D', 3690000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156009', 'Skyboss', '3A', 3690000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156010', 'Skyboss', '3B', 3690000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156011', 'Skyboss', '3C', 3690000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156012', 'Skyboss', '3D', 3690000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156013', 'Deluxe', '4A', 2280000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156014', 'Deluxe', '4B', 2280000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156015', 'Deluxe', '4C', 2280000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156016', 'Deluxe', '4D', 2280000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156017', 'Deluxe', '4E', 2280000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156018', 'Deluxe', '4F', 2280000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156019', 'Deluxe', '5A', 2280000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156020', 'Deluxe', '5B', 2280000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156021', 'Deluxe', '5C', 2280000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156022', 'Deluxe', '5D', 2280000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156023', 'Deluxe', '5E', 2280000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156024', 'Deluxe', '5F', 2280000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156025', 'Economic', '6A', 1920000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156026', 'Economic', '6B', 1920000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156027', 'Economic', '6C', 1920000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156028', 'Economic', '6D', 1920000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156029', 'Economic', '6E', 1920000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156030', 'Economic', '6F', 1920000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156031', 'Economic', '7A', 1920000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156032', 'Economic', '7B', 1920000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156033', 'Economic', '7C', 1920000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156034', 'Economic', '7D', 1920000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156035', 'Economic', '7E', 1920000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156036', 'Economic', '7F', 1920000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156037', 'Economic', '8A', 1920000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156038', 'Economic', '8B', 1920000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156039', 'Economic', '8C', 1920000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156040', 'Economic', '8D', 1920000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156041', 'Economic', '8E', 1920000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156042', 'Economic', '8F', 1920000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156043', 'Economic', '9A', 1920000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156044', 'Economic', '9B', 1920000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156045', 'Economic', '9C', 1920000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156046', 'Economic', '9D', 1920000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156047', 'Economic', '9E', 1920000, 'Remained', 'VJ156')
INSERT INTO Ticket VALUES ('VJ156048', 'Economic', '9F', 1920000, 'Remained', 'VJ156')

SELECT * FROM ticket

--Thêm thuộc tính Booked
INSERT INTO Booked VALUES ('100132','12-11-2023','VNA114','VNA114015','F203W3','FCB','NV001')
INSERT INTO Booked VALUES ('100043','4-6-2023','BA102','BA102041','J385H3','23CB','NV001')
INSERT INTO Booked VALUES ('100234','1-4-2023','VJ623','VJ623031','H32K24','FCB','NV001')
INSERT INTO Booked VALUES ('104323','2023-09-30','VJ452','VJ452020','KF2014','10CB','NV002')
SELECT * FROM booked

SELECT * FROM account
SELECT * FROM airport
SELECT * FROM locate
SELECT * FROM plane
SELECT * FROM flight
SELECT * FROM ticket
SELECT * FROM customer
SELECT * FROM booked
SELECT * FROM checked_baggage
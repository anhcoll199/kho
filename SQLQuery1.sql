CREATE DATABASE QLKHO
GO
USE QLKHO
GO
create table Unit
(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(max)
)
GOg

CREATE TABLE Suplier
(	
	Id int identity(1,1),
	IdSuplier NVARCHAR(10) PRIMARY KEY,
	DisplayName nvarchar(1000),
	Address nvarchar(100),
	Phone nvarchar(20),
	Email nvarchar(200),
)
GO

create table Users
(
	Id nvarchar(10) primary key,
	DisplayName nvarchar(max),
	Address nvarchar(max),
	Phone varchar(20),
	Email varchar(200),
	Username nvarchar(50),
	Password nvarchar(50),
	IdUserRole varchar(10)
)
go
create table Object
(
	Id nvarchar(128) primary key,
	DisplayName nvarchar(max),
	IdUnit int not null,
	SoLuongTon INT,
    IdSuplier NVARCHAR(10)
)
go

create table UserRole
(
	Id VARCHAR(10) primary key,
	DisplayName nvarchar(max)
)
GO
create table Input
(
	Id nvarchar(128) primary key,
	DateInput DATETIME,
    IdUser NVARCHAR(10),
	IdSuplier NVARCHAR(10)
)
GO
create table InputInfo
(
	Id nvarchar(128) not null,
	IdObject nvarchar(128) not null,
	Quantity int,
	InputPrice float default 0,
	OutputPrice float default 0,
	Status nvarchar(max)
)
go
create table Output
(
	Id nvarchar(128) primary key,
	DateOutput DATETIME,
	IdUser NVARCHAR(10)
)
go

create table OutputInfo
(
	Id nvarchar(128) NOT null,
	IdObject nvarchar(128) not null,
	Quantity int,	
	Status nvarchar(max)
)
GO

DROP DATABASE QLKHO
------------------------------------------------------------------------
ALTER TABLE dbo.Users ADD CONSTRAINT fk_quyen FOREIGN KEY(IdUserRole) REFERENCES dbo.UserRole(Id)
ALTER TABLE dbo.Input ADD CONSTRAINT fk_ncc FOREIGN KEY(IdSuplier) REFERENCES dbo.Suplier(IdSuplier)
ALTER TABLE dbo.Input ADD CONSTRAINT fk_nv FOREIGN KEY(IdUser) REFERENCES dbo.Users(Id)
ALTER TABLE dbo.Output ADD CONSTRAINT fk_nv1 FOREIGN KEY(IdUser) REFERENCES dbo.Users(Id)
ALTER TABLE dbo.Object ADD CONSTRAINT fk_ob FOREIGN KEY(IdUnit) REFERENCES dbo.Unit(Id)
ALTER TABLE dbo.Object ADD CONSTRAINT pk_sup FOREIGN KEY(IdSuplier) REFERENCES dbo.Suplier(IdSuplier)


ALTER TABLE dbo.InputInfo ADD CONSTRAINT pk_phieu_sp PRIMARY KEY(IdObject,Id)
ALTER TABLE dbo.InputInfo ADD CONSTRAINT fk_ctphieu FOREIGN KEY(Id) REFERENCES dbo.Input(Id) 
ALTER TABLE dbo.InputInfo ADD CONSTRAINT fk_ctphieu1 FOREIGN KEY(IdObject) REFERENCES dbo.Object(Id) 

ALTER TABLE dbo.OutputInfo ADD CONSTRAINT pk_phieu_sp1 PRIMARY KEY(Id,IdObject)
ALTER TABLE dbo.OutputInfo ADD CONSTRAINT fk_ctphieusuat1 FOREIGN KEY(Id) REFERENCES dbo.Output(Id) 
ALTER TABLE dbo.OutputInfo ADD CONSTRAINT fk_ctphieusuat2 FOREIGN KEY(IdObject) REFERENCES dbo.Object(Id) 

---------------------------------------------------------------------------------------------------

SELECT* FROM dbo.Object
SELECT* FROM dbo.Output
SELECT* FROM dbo.OutputInfo
SELECT* FROM dbo.Input
SELECT* FROM dbo.InputInfo
SELECT* FROM dbo.Suplier
SELECT* FROM dbo.Unit
SELECT* FROM dbo.Users
SELECT* FROM dbo.UserRole


-----------Them NCC--------------
INSERT dbo.Suplier
        ( IdSuplier ,
          DisplayName ,
          Address ,
          Phone ,
          Email 
        )

VALUES  ( N'NCC001' , -- IdSuplier - nvarchar(10)
          N'Vinavilk' , -- DisplayName - nvarchar(1000)
          N'273 An Duong Vuong' , -- Address - nvarchar(100)
          N'0374659500' , -- Phone - nvarchar(20)
          N'vinamilk@gmial.com'  -- Email - nvarchar(200)
        )
INSERT dbo.Suplier
        ( IdSuplier ,
          DisplayName ,
          Address ,
          Phone ,
          Email 
        )
VALUES  ( N'NCC002' , -- IdSuplier - nvarchar(10)
          N'CocaCola' , -- DisplayName - nvarchar(1000)
          N'273 An Duong Vuong' , -- Address - nvarchar(100)
          N'0374659500' , -- Phone - nvarchar(20)
          N'vinamilk@gmial.com'  -- Email - nvarchar(200)
        )

INSERT dbo.Suplier
        ( IdSuplier ,
          DisplayName ,
          Address ,
          Phone ,
          Email 
        )
VALUES  ( N'NCC003' , -- IdSuplier - nvarchar(10)
          N'PepSi' , -- DisplayName - nvarchar(1000)
          N'273 An Duong Vuong' , -- Address - nvarchar(100)
          N'0374659500' , -- Phone - nvarchar(20)
          N'vinamilk@gmial.com'  -- Email - nvarchar(200)
        )
-------------Them Don Vi Tinh-----------------
INSERT dbo.Unit
        ( DisplayName )
VALUES  ( N'Thung'  -- DisplayName - nvarchar(max)
          )

INSERT dbo.Unit
        ( DisplayName )
VALUES  ( N'Bao'  -- DisplayName - nvarchar(max)
          )

INSERT dbo.Unit
        ( DisplayName )
VALUES  ( N'Goi'  -- DisplayName - nvarchar(max)
          )

--------------Them Sp----------------
INSERT dbo.Object
        ( Id ,
          DisplayName ,
          IdUnit ,
          SoLuongTon ,
          IdSuplier
        )
VALUES  ( N'SP001' , -- Id - nvarchar(128)
          N'Sua tuoi ko duong' , -- DisplayName - nvarchar(max)
          1 , -- IdUnit - int
          10 , -- SoLuongTon - int
          N'NCC001'  -- IdSuplier - nvarchar(10)
        )

INSERT dbo.Object
        ( Id ,
          DisplayName ,
          IdUnit ,
          SoLuongTon ,
          IdSuplier
        )
VALUES  ( N'SP002' , -- Id - nvarchar(128)
          N'Sua tuoi co duong' , -- DisplayName - nvarchar(max)
          1 , -- IdUnit - int
          10 , -- SoLuongTon - int
          N'NCC001'  -- IdSuplier - nvarchar(10)
        )

INSERT dbo.Object
        ( Id ,
          DisplayName ,
          IdUnit ,
          SoLuongTon ,
          IdSuplier
        )
VALUES  ( N'SP003' , -- Id - nvarchar(128)
          N'Nuoc ngot Pepsi' , -- DisplayName - nvarchar(max)
          1 , -- IdUnit - int
          10 , -- SoLuongTon - int
          N'NCC003'  -- IdSuplier - nvarchar(10)
        )

INSERT dbo.Object
        ( Id ,
          DisplayName ,
          IdUnit ,
          SoLuongTon ,
          IdSuplier
        )
VALUES  ( N'SP004' , -- Id - nvarchar(128)
          N'Nuoc ngot CocaCola' , -- DisplayName - nvarchar(max)
          1 , -- IdUnit - int
          10 , -- SoLuongTon - int
          N'NCC002'  -- IdSuplier - nvarchar(10)
        )
--------------------Them Quyen----------------
INSERT dbo.UserRole
        ( Id, DisplayName )
VALUES  ( 'QLK', -- Id - varchar(10)
          N'Quan Ly Kho'  -- DisplayName - nvarchar(max)
          )

INSERT dbo.UserRole
        ( Id, DisplayName )
VALUES  ( 'NV', -- Id - varchar(10)
          N'Nhân viên'  -- DisplayName - nvarchar(max)
          )
------------Them Nhan Vien--------------------
INSERT dbo.Users
        ( Id ,
          DisplayName ,
          Address ,
          Phone ,
          Email ,
          Username ,
          Password ,
          IdUserRole
        )
VALUES  ( N'NV001' , -- Id - nvarchar(10)
          N'Nguyen Van A' , -- DisplayName - nvarchar(max)
          N'273 An Duong Vuong' , -- Address - nvarchar(max)
          '0374659500' , -- Phone - varchar(20)
          'khaitriuenguyen@gmail.com' , -- Email - varchar(200)
          N'user1' , -- Username - nvarchar(50)
          N'user1' , -- Password - nvarchar(50)
          'QLK'  -- IdUserRole - varchar(10)
        )
INSERT dbo.Users
        ( Id ,
          DisplayName ,
          Address ,
          Phone ,
          Email ,
          Username ,
          Password ,
          IdUserRole
        )
VALUES  ( N'NV002' , -- Id - nvarchar(10)
          N'Tran Van B' , -- DisplayName - nvarchar(max)
          N'Quận 1' , -- Address - nvarchar(max)
          '0929087540' , -- Phone - varchar(20)
          'thanhnc@gmail.com' , -- Email - varchar(200)
          N'user2' , -- Username - nvarchar(50)
          N'123123' , -- Password - nvarchar(50)
          'QLK'  -- IdUserRole - varchar(10)
        )
----Them phieu nhap------------
INSERT dbo.Input 
        ( Id, DateInput, IdUser, IdSuplier )
VALUES  ( N'PN001', -- Id - nvarchar(128)
          GETDATE(), -- DateInput - datetime
          N'NV001', -- IdUser - nvarchar(10)
          N'NCC001'  -- IdSuplier - nvarchar(10)
          )

----------Them ct phieu nhap---------
INSERT dbo.InputInfo
        ( Id ,
          IdObject ,
          Quantity ,
          InputPrice ,
          OutputPrice 
        )
VALUES  ( N'PN001' , -- Id - nvarchar(128)
          N'SP001' , -- IdObject - nvarchar(128)
          10 , -- Quantity - int
          100000 , -- InputPrice - float
          150000  -- OutputPrice - float
        )

INSERT dbo.InputInfo
        ( Id ,
          IdObject ,
          Quantity ,
          InputPrice ,
          OutputPrice 
        )
VALUES  ( N'PN001' , -- Id - nvarchar(128)
          N'SP002' , -- IdObject - nvarchar(128)
          10 , -- Quantity - int
          100000 , -- InputPrice - float
          150000  -- OutputPrice - float
        )

-----------Them phieu xuat----------
INSERT dbo.Output
        ( Id, DateOutput, IdUser )
VALUES  ( N'PX001', -- Id - nvarchar(128)
          GETDATE(), -- DateOutput - datetime
          N'NV001'  -- IdUser - nvarchar(10)
          )

-----Them ct phieu xuat-------
INSERT dbo.OutputInfo
        ( Id, IdObject, Quantity )
VALUES  ( N'PX001', -- Id - nvarchar(128)
          N'SP001', -- IdObject - nvarchar(128)
          3 -- Quantity - int
          )

INSERT dbo.OutputInfo
        ( Id, IdObject, Quantity )
VALUES  ( N'PX001', -- Id - nvarchar(128)
          N'SP002', -- IdObject - nvarchar(128)
          5 -- Quantity - int
          )
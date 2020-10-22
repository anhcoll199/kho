CREATE DATABASE QLKHO

create table Unit
(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(max)
)
GO

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

create table Object
(
	Id nvarchar(128) primary key,
	DisplayName nvarchar(max),
	IdUnit int not null,
	SoLuongTon int
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

SELECT* FROM dbo.Suplier
SELECT* FROM dbo.Object
SELECT* FROM dbo.Output
SELECT* FROM dbo.OutputInfo
SELECT* FROM dbo.Users



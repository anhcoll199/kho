CREATE DATABASE StorageDB 
GO 
USE StorageDB 
GO 
USE StorageDB
GO
CREATE TABLE Unit
(
	Id_Unit NVARCHAR(10)
	DisplayName nvarchar(50) NOT NULL,

	PRIMARY KEY(Id_Unit)
)
GO

CREATE TABLE Suplier
(	
	IdSuplier NVARCHAR(10),
	DisplayName nvarchar(50) NOT NULL,
	Address nvarchar(100) NOT NULL,
	Phone nvarchar(20) NOT NULL,
	Email nvarchar(200) NOT NULL,

	PRIMARY KEY(IdSuplier)
)
GO

CREATE TABLE UserRole
(
	IdRole NVARCHAR(10),
	DisplayName nvarchar(50) NOT NULL,

	PRIMARY KEY(IdRole)
)
GO

CREATE TABLE Users
(
	Id NVARCHAR(10),
	DisplayName NVARCHAR(50) NOT NULL,
	Address NVARCHAR(200) NOT NULL,
	Phone NVARCHAR(20) NOT NULL,
	Email NVARCHAR(200) NOT NULL,
	Username NVARCHAR(50) NOT NULL,
	Password NVARCHAR(50) NOT NULL,
	IdUserRole NVARCHAR(10) NOT NULL,

	PRIMARY KEY(Id),
	FOREIGN KEY (IdUserRole) REFERENCES UserRole(IdRole)
)
GO

CREATE TABLE Product
(
	IdProduct NVARCHAR(10),
	DisplayName NVARCHAR(50) NOT NULL,

	PRIMARY KEY(IdProduct)
)
GO


CREATE TABLE Package
(
	IdPackage NVARCHAR(10),
	IdProduct NVARCHAR(10),
	IdSuplier NVARCHAR(10),
	Amount INT NOT NULL,
	ExpiryDate DATETIME NOT NULL,
	Id_Unit NVARCHAR(10) NOT NULL,
	Id_OrderForm NVARCHAR(10) NOT NULL,

	PRIMARY KEY(IdPackage, IdProduct, IdSuplier)
)
GO

CREATE TABLE OrderProduct
(
	IdOrderProduct NVARCHAR(10),
	CreatedDate DATETIME NOT NULL,
	StatusOrderProduct BIT DEFAULT 0 NOT NULL,
	IdUsers NVARCHAR(10) NOT NULL,

	PRIMARY KEY(IdOrderProduct)
)
GO

CREATE TABLE OrderProductDetail
(
	IdOrderProduct NVARCHAR(10),
	IdProduct NVARCHAR(10),
	Amount INT NOT NULL,
	Id_Unit NVARCHAR(10) NOT NULL,
	IdSuplier NVARCHAR(10) NOT NULL,

	PRIMARY KEY(IdOrderProduct, IdProduct)
)
GO

CREATE TABLE ImportProduct
(
	IdImportProduct NVARCHAR(10),
	IdOrderProduct NVARCHAR(10) NOT NULL,
	TotalPrice DECIMAL(18,0) NOT NULL,
	CreatedDate DATETIME NOT NULL,
	StatusImportProduct BIT DEFAULT 0 NOT NULL,
	IdPackage NVARCHAR(10)NOT NULL,
	IdUsers NVARCHAR(10) NOT NULL,

	PRIMARY KEY(IdImportProduct)
)
GO

CREATE TABLE ImportProductDetail
(
	IdImportProduct NVARCHAR(10),
	IdProduct NVARCHAR(10),
	Amount INT NOT NULL,
	UnitPrice DECIMAL(18,0) NOT NULL,
	IntoPrice DECIMAL(18,0) NOT NULL,
	ExpiryDate DATETIME NOT NULL,
	Id_Unit NVARCHAR(10) NOT NULL,
	IdSuplier NVARCHAR(10) NOT NULL,


	PRIMARY KEY(IdImportProduct, IdProduct)
)
GO

CREATE TABLE OutputProduct
(
	ID VARCHAR(10) PRIMARY KEY,
	DATEOUTPUT DATETIME,
	ID_USER NVARCHAR(10)
)

CREATE TABLE DetailOutputProduct
(
	ID VARCHAR(10),
	ID_PRODUCT NVARCHAR(10) ,
	QUANTITY INT NOT NULL,
	ID_Package NVARCHAR(10) 

	PRIMARY KEY(ID,ID_PRODUCT,ID_Package)
)

INSERT dbo.OutputProduct
        ( ID, DATEOUTPUT, ID_USER )
VALUES  ( 'EX001', -- ID - varchar(10)
          GETDATE(), -- DATEOUTPUT - datetime
          N'3117410274'  -- ID_USER - nvarchar(10)
          )

INSERT dbo.OutputProduct
        ( ID, DATEOUTPUT, ID_USER )
VALUES  ( 'EX002', -- ID - varchar(10)
          GETDATE(), -- DATEOUTPUT - datetime
          N'3117410231'  -- ID_USER - nvarchar(10)
          )
----------------------INSERT VALUE to DetailOutputProduct  ----------------------
INSERT dbo.DetailOutputProduct
        ( ID ,
          ID_PRODUCT ,
          QUANTITY ,
          ID_Package
        )
VALUES  ( 'EX001', -- ID - varchar(10)
          N'SP01' , -- ID_PRODUCT - nvarchar(10)
          1 , -- QUANTITY - int
          N'PACK001'  -- ID_Package - nvarchar(10)
        )

INSERT dbo.DetailOutputProduct
        ( ID ,
          ID_PRODUCT ,
          QUANTITY ,
          ID_Package
        )
VALUES  ( 'EX001', -- ID - varchar(10)
          N'SP02' , -- ID_PRODUCT - nvarchar(10)
          4 , -- QUANTITY - int
          N'PACK001'  -- ID_Package - nvarchar(10)
        )

GO
CREATE TRIGGER phieuxuathang ON dbo.DetailOutputProduct FOR INSERT AS
BEGIN
	UPDATE dbo.Package
	SET Amount = Amount - ( SELECT c.QUANTITY
									FROM INSERTED i, dbo.DetailOutputProduct c
									WHERE i.ID_PRODUCT=c.ID_PRODUCT AND i.ID_Package = c.ID_Package AND i.ID = c.ID) 
	FROM dbo.Package s, Inserted i
	WHERE s.IdPackage = i.ID_Package AND s.IdProduct = i.ID_PRODUCT	
END
GO

----------------------ADD FOREIGN KEY ----------------------
ALTER TABLE dbo.Package ADD CONSTRAINT fk_package_product FOREIGN KEY(IdProduct) REFERENCES dbo.Product(IdProduct) 
ALTER TABLE dbo.Package ADD CONSTRAINT fk_package_suplier FOREIGN KEY(IdSuplier) REFERENCES dbo.Suplier(IdSuplier) 
ALTER TABLE dbo.Package ADD CONSTRAINT fk_package_unit FOREIGN KEY(Id_Unit) REFERENCES dbo.Unit(Id_Unit) 

ALTER TABLE dbo.OrderProduct ADD CONSTRAINT fk_OrderProduct_User FOREIGN KEY(IdUsers) REFERENCES dbo.Users(Id) 

ALTER TABLE dbo.OrderProductDetail ADD CONSTRAINT fk_OrderProductDetail_product FOREIGN KEY(IdProduct) REFERENCES dbo.Product(IdProduct) 
ALTER TABLE dbo.OrderProductDetail ADD CONSTRAINT fk_OrderProductDetail_suplier FOREIGN KEY(IdSuplier) REFERENCES dbo.Suplier(IdSuplier) 
ALTER TABLE dbo.OrderProductDetail ADD CONSTRAINT fk_OrderProductDetail_unit FOREIGN KEY(Id_Unit) REFERENCES dbo.Unit(Id_Unit) 
ALTER TABLE dbo.OrderProductDetail ADD CONSTRAINT fk_OrderProductDetail_OrderProduct FOREIGN KEY(IdOrderProduct) REFERENCES dbo.OrderProduct(IdOrderProduct) 

ALTER TABLE dbo.ImportProduct ADD CONSTRAINT fk_ImportProduct_OrderProduct FOREIGN KEY(IdOrderProduct) REFERENCES dbo.OrderProduct(IdOrderProduct) 


ALTER TABLE dbo.ImportProductDetail ADD CONSTRAINT fk_ImportProductDetail_product FOREIGN KEY(IdProduct) REFERENCES dbo.Product(IdProduct) 
ALTER TABLE dbo.ImportProductDetail ADD CONSTRAINT fk_ImportProductDetail_suplier FOREIGN KEY(IdSuplier) REFERENCES dbo.Suplier(IdSuplier) 
ALTER TABLE dbo.ImportProductDetail ADD CONSTRAINT fk_ImportProductDetail_unit FOREIGN KEY(Id_Unit) REFERENCES dbo.Unit(Id_Unit) 
ALTER TABLE dbo.ImportProductDetail ADD CONSTRAINT fk_ImportProductDetail_ImportProduct FOREIGN KEY(IdImportProduct) REFERENCES dbo.ImportProduct(IdImportProduct) 

ALTER TABLE dbo.OutputProduct ADD CONSTRAINT fk_op FOREIGN KEY(ID_USER) REFERENCES dbo.Users(Id)
ALTER TABLE dbo.DetailOutputProduct ADD CONSTRAINT fk_dt1 FOREIGN KEY(ID) REFERENCES dbo.OutputProduct(ID)
ALTER TABLE dbo.DetailOutputProduct ADD CONSTRAINT fk_dt2 FOREIGN KEY(ID_PRODUCT) REFERENCES dbo.Product(IdProduct)

----------------------INSERT VALUE Product ----------------------
INSERT INTO dbo.Product
        ( IdProduct, DisplayName )
VALUES  ( N'SP01', -- IdProduct - nvarchar(10)
          N'Sữa ensure'  -- DisplayName - nvarchar(50)
          )
INSERT INTO dbo.Product
        ( IdProduct, DisplayName )
VALUES  ( N'SP02', -- IdProduct - nvarchar(10)
          N'Nước Pepsi'  -- DisplayName - nvarchar(50)
          )
INSERT INTO dbo.Product
        ( IdProduct, DisplayName )
VALUES  ( N'SP03', -- IdProduct - nvarchar(10)
          N'Nước Coca'  -- DisplayName - nvarchar(50)
          )
INSERT INTO dbo.Product
        ( IdProduct, DisplayName )
VALUES  ( N'SP04', -- IdProduct - nvarchar(10)
          N'Snack Slay'  -- DisplayName - nvarchar(50)
          )
INSERT INTO dbo.Product
        ( IdProduct, DisplayName )
VALUES  ( N'SP05', -- IdProduct - nvarchar(10)
          N'Mì Gói Hảo Hảo'  -- DisplayName - nvarchar(50)
          )

----------------------INSERT VALUE Role ----------------------
INSERT INTO dbo.UserRole
        ( IdRole, DisplayName )
VALUES  ( N'MS', -- IdRole - nvarchar(10)
          N'Management Staff'  -- DisplayName - nvarchar(50)
          )
INSERT INTO dbo.UserRole
        ( IdRole, DisplayName )
VALUES  ( N'S', -- IdRole - nvarchar(10)
          N'Staff'  -- DisplayName - nvarchar(50)
          )
INSERT INTO dbo.UserRole
        ( IdRole, DisplayName )
VALUES  ( N'AD', -- IdRole - nvarchar(10)
          N'ADMIN'  -- DisplayName - nvarchar(50)
          )


----------------------INSERT VALUE Role ----------------------
INSERT INTO dbo.Users
        ( Id ,
          DisplayName ,
          Address ,
          Phone ,
          Email ,
          Username ,
          Password ,
          IdUserRole
        )
VALUES  ( N'3117410231' , -- Id - nvarchar(10)
          N'Nguyễn Thành' , -- DisplayName - nvarchar(50)
          N'273 An Dương Dương, P5, Q3, HCM' , -- Address - nvarchar(200)
          N'0929087540' , -- Phone - nvarchar(20)
          N'thanhnc.it17.sgu@gmail.com' , -- Email - nvarchar(200)
          N'SGU0231' , -- Username - nvarchar(50)
          N'16c5fcbc3dc60840f1105316c29bdfef' , -- Password - nvarchar(50)
          N'MS'  -- IdUserRole - nvarchar(10)
        )

INSERT INTO dbo.Users
        ( Id ,
          DisplayName ,
          Address ,
          Phone ,
          Email ,
          Username ,
          Password ,
          IdUserRole
        )
VALUES  ( N'3117410274' , -- Id - nvarchar(10)
          N'Nguyễn Khải Triều' , -- DisplayName - nvarchar(50)
          N'273 An Dương Dương, P5, Q3, HCM' , -- Address - nvarchar(200)
          N'0374659500' , -- Phone - nvarchar(20)
          N'nguyenkhaitrieu@gmail.com' , -- Email - nvarchar(200)
          N'SGU0274' , -- Username - nvarchar(50)
          N'e97cae3186c8702c1acd975f63d4eb2f' , -- Password - nvarchar(50)
          N'MS'  -- IdUserRole - nvarchar(10)
        )

----------------------INSERT VALUE Unit ----------------------
INSERT INTO dbo.Unit
        ( Id_Unit, DisplayName )
VALUES  ( N'PCS1', -- Id_Unit - nvarchar(10)
          N'Đơn vị'  -- DisplayName - nvarchar(50)
          )
----------------------INSERT VALUE Suplier ----------------------
INSERT INTO dbo.Suplier
        ( IdSuplier ,
          DisplayName ,
          Address ,
          Phone ,
          Email
        )
VALUES  ( N'SUP01' , -- IdSuplier - nvarchar(10)
          N'Công ty cung cấp thực phẩm số 01' , -- DisplayName - nvarchar(50)
          N'88A Đinh Hội Đống Đa Hà Nội' , -- Address - nvarchar(100)
          N'0929007443' , -- Phone - nvarchar(20)
          N'congtythucpham01@gmail.com'  -- Email - nvarchar(200)
        )
INSERT INTO dbo.Suplier
        ( IdSuplier ,
          DisplayName ,
          Address ,
          Phone ,
          Email
        )
VALUES  ( N'SUP02' , -- IdSuplier - nvarchar(10)
          N'Công ty cung cấp thực phẩm số 02' , -- DisplayName - nvarchar(50)
          N'90A Đinh Hội Đống Đa Hà Nội' , -- Address - nvarchar(100)
          N'0929007443' , -- Phone - nvarchar(20)
          N'congtythucpham02@gmail.com'  -- Email - nvarchar(200)
        )
INSERT INTO dbo.Suplier
        ( IdSuplier ,
          DisplayName ,
          Address ,
          Phone ,
          Email
        )
VALUES  ( N'SUP03' , -- IdSuplier - nvarchar(10)
          N'Công ty cung cấp thực phẩm số 03' , -- DisplayName - nvarchar(50)
          N'92A Đinh Hội Đống Đa Hà Nội' , -- Address - nvarchar(100)
          N'0929007443' , -- Phone - nvarchar(20)
          N'congtythucpham03@gmail.com'  -- Email - nvarchar(200)
        )


----------------------INSERT VALUE order ----------------------
INSERT INTO dbo.OrderProduct
        ( IdOrderProduct ,
          CreatedDate ,
          IdUsers
        )
VALUES  ( N'OR001' , -- IdOrderProduct - nvarchar(10)
          '2020-1-20 14:35:45.067' , -- CreatedDate - datetime -- StatusOrderProduct - bit (mac dinh la 0)
          N'3117410231'  -- IdUsers - nvarchar(10)
        )

INSERT INTO dbo.OrderProduct
        ( IdOrderProduct ,
          CreatedDate ,
          IdUsers
        )
VALUES  ( N'OR002' , -- IdOrderProduct - nvarchar(10)
          '2020-1-25 14:35:45.067' , -- CreatedDate - datetime -- StatusOrderProduct - bit (mac dinh la 0)
          N'3117410231'  -- IdUsers - nvarchar(10)
        )

INSERT INTO dbo.OrderProduct
        ( IdOrderProduct ,
          CreatedDate ,
          IdUsers
        )
VALUES  ( N'OR003' , -- IdOrderProduct - nvarchar(10)
          '2020-1-25 14:35:45.067' , -- CreatedDate - datetime -- StatusOrderProduct - bit (mac dinh la 0)
          N'3117410274'  -- IdUsers - nvarchar(10)
        )
----------------------INSERT VALUE order infor for OR001 ----------------------
INSERT INTO dbo.OrderProductDetail
        ( IdOrderProduct ,
          IdProduct ,
          Amount ,
          Id_Unit ,
          IdSuplier
        )
VALUES  ( N'OR001' , -- IdOrderProduct - nvarchar(10)
          N'SP01' , -- IdProduct - nvarchar(10)
          12 , -- Amount - int
          N'PCS1' , -- Id_Unit - nvarchar(10)
          N'SUP01'  -- IdSuplier - nvarchar(10)
        )
INSERT INTO dbo.OrderProductDetail
        ( IdOrderProduct ,
          IdProduct ,
          Amount ,
          Id_Unit ,
          IdSuplier
        )
VALUES  ( N'OR001' , -- IdOrderProduct - nvarchar(10)
          N'SP02' , -- IdProduct - nvarchar(10)
          24 , -- Amount - int
          N'PCS1' , -- Id_Unit - nvarchar(10)
          N'SUP01'  -- IdSuplier - nvarchar(10)
        )
----------------------INSERT VALUE import ----------------------
INSERT INTO dbo.ImportProduct
        ( IdImportProduct ,
          IdOrderProduct ,
          TotalPrice ,
          CreatedDate ,
          StatusImportProduct ,
          IdPackage ,
          IdUsers
        )
VALUES  ( N'IP001' , -- IdImportProduct - nvarchar(10)
          N'OR001' , -- IdOrderProduct - nvarchar(10)
          0.0 , -- TotalPrice - decimal
          '2020-01-26 14:35:45.067' , -- CreatedDate - datetime 
		  0,-- StatusImportProduct - bit
          N'PACK001' , -- IdPackage - nvarchar(10)
          N'3117410231'  -- IdUsers - nvarchar(10)
        )

----------------------INSERT VALUE import infor for IP001 ----------------------
INSERT INTO dbo.ImportProductDetail
        ( IdImportProduct ,
          IdProduct ,
          Amount ,
          UnitPrice ,
          IntoPrice ,
          ExpiryDate ,
          Id_Unit ,
          IdSuplier
        )
VALUES  ( N'IP001' , -- IdImportProduct - nvarchar(10)
          N'SP01' , -- IdProduct - nvarchar(10)
          12 , -- Amount - int
          10000.0 , -- UnitPrice - decimal
          120000.0 , -- IntoPrice - decimal
          '2021-01-01 14:35:45.067' , -- ExpiryDate - datetime
          N'PCS1' , -- Id_Unit - nvarchar(10)
          N'SUP01'  -- IdSuplier - nvarchar(10)
        )

INSERT INTO dbo.ImportProductDetail
        ( IdImportProduct ,
          IdProduct ,
          Amount ,
          UnitPrice ,
          IntoPrice ,
          ExpiryDate ,
          Id_Unit ,
          IdSuplier
        )
VALUES  ( N'IP001' , -- IdImportProduct - nvarchar(10)
          N'SP02' , -- IdProduct - nvarchar(10)
          24 , -- Amount - int
          12000.0 , -- UnitPrice - decimal
          288000.0 , -- IntoPrice - decimal
          '2021-02-01 14:35:45.067' , -- ExpiryDate - datetime
          N'PCS1' , -- Id_Unit - nvarchar(10)
          N'SUP01'  -- IdSuplier - nvarchar(10)
        )
----------------------INSERT VALUE to package  ----------------------
INSERT INTO dbo.Package
        ( IdPackage ,
          IdProduct ,
          IdSuplier ,
          Amount ,
          ExpiryDate ,
          Id_Unit ,
          Id_OrderForm
        )
VALUES  ( N'PACK001' , -- IdPackage - nvarchar(10)
          N'SP01' , -- IdProduct - nvarchar(10)
          N'SUP01' , -- IdSuplier - nvarchar(10)
          12 , -- Amount - int
          '2021-01-01 14:35:45.067' , -- ExpiryDate - datetime
          N'PCS1' , -- Id_Unit - nvarchar(10)
          N'OR001'  -- Id_OrderForm - nvarchar(10)
        )

INSERT INTO dbo.Package
        ( IdPackage ,
          IdProduct ,
          IdSuplier ,
          Amount ,
          ExpiryDate ,
          Id_Unit ,
          Id_OrderForm
        )
VALUES  ( N'PACK001' , -- IdPackage - nvarchar(10)
          N'SP02' , -- IdProduct - nvarchar(10)
          N'SUP01' , -- IdSuplier - nvarchar(10)
          24 , -- Amount - int
          '2021-02-01 14:35:45.067' , -- ExpiryDate - datetime
          N'PCS1' , -- Id_Unit - nvarchar(10)
          N'OR001'  -- Id_OrderForm - nvarchar(10)
        )

GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(N'[USP_GET_Product]') AND OBJECTPROPERTY(ID, N'IsProcedure')=1)
	DROP PROC [USP_GET_Product]
GO

CREATE PROC USP_GET_Product
AS
BEGIN
	SELECT * FROM dbo.Product
END
GO

-- EXEC dbo.USP_GET_Product
GO 

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(N'[USP_INSERT_Product]') AND OBJECTPROPERTY(ID, N'IsProcedure')=1)
	DROP PROC [USP_INSERT_Product]
GO

CREATE PROC USP_INSERT_Product (@nvcIDproduct NVARCHAR(10), @nvcDisplayName NVARCHAR(50))
AS
BEGIN
	IF EXISTS (SELECT * FROM dbo.Product WHERE IdProduct = @nvcIDproduct)
		RETURN 0
	-- Tasking
	INSERT INTO dbo.Product ( IdProduct, DisplayName )
	VALUES  ( @nvcIDproduct, @nvcDisplayName )
END
GO

-- EXEC dbo.USP_INSERT_Product N'SP09', N'Bugger phomai'
GO 

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(N'[USP_UPDATE_Product]') AND OBJECTPROPERTY(ID, N'IsProcedure')=1)
	DROP PROC [USP_UPDATE_Product]
GO

CREATE PROC USP_UPDATE_Product (@nvcIDproduct NVARCHAR(10), @nvcDisplayName NVARCHAR(50))
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM dbo.Product WHERE IdProduct = @nvcIDproduct)
		RETURN 0
	-- Tasking
	UPDATE dbo.Product
	SET DisplayName = @nvcDisplayName
	WHERE IdProduct = @nvcIDproduct
END
GO

-- EXEC USP_UPDATE_Product N'SP08', N'Buggr Bul'
GO

-- Không cho xoá sản phẩm nha nên k có Store Procude Xoá

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(N'[USP_INSERT_UNIT]') AND OBJECTPROPERTY(ID, N'IsProcedure')=1)
	DROP PROC [USP_INSERT_UNIT]
GO

CREATE PROC USP_INSERT_UNIT (@nvcIDUnit NVARCHAR(10), @nvcDisplayName NVARCHAR(50))
AS
BEGIN
	IF EXISTS (SELECT * FROM dbo.Unit WHERE Id_Unit = @nvcIDUnit)
		RETURN 0
	-- Tasking
	INSERT INTO dbo.Unit ( Id_Unit, DisplayName )
	VALUES  ( @nvcIDUnit, @nvcDisplayName )
END
GO
-- EXEC USP_INSERT_UNIT N'PCS2', N'Thùng'

-- store lấy dữ liệu Unit
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(N'[USP_GET_UNIT]') AND OBJECTPROPERTY(ID, N'IsProcedure')=1)
	DROP PROC [USP_GET_UNIT]
GO

CREATE PROC USP_GET_UNIT
AS
BEGIN
	SELECT * FROM dbo.Unit
END
GO

-- EXEC dbo.USP_GET_UNIT
GO


-- Nhà cung cấp
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(N'[USP_INSERT_SUPLIER]') AND OBJECTPROPERTY(ID, N'IsProcedure')=1)
	DROP PROC [USP_INSERT_SUPLIER]
GO

CREATE PROC USP_INSERT_SUPLIER (@nvcIDSuplier NVARCHAR(10), @nvcDisplayName NVARCHAR(50), @nvcAdd NVARCHAR(100), @nvcPhone NVARCHAR(20), @nvcMail NVARCHAR(200))
AS
BEGIN
	IF EXISTS (SELECT * FROM dbo.Suplier WHERE IdSuplier = @nvcIDSuplier)
		RETURN 0
	-- Tasking
	INSERT INTO dbo.Suplier( IdSuplier ,DisplayName ,Address ,Phone ,Email)
	VALUES  (@nvcIDSuplier, @nvcDisplayName, @nvcAdd, @nvcPhone, @nvcMail)
END
GO
-- store lấy dữ liệu nhà cung cấp
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(N'[USP_GET_SUPLIER]') AND OBJECTPROPERTY(ID, N'IsProcedure')=1)
	DROP PROC [USP_GET_SUPLIER]
GO

CREATE PROC USP_GET_SUPLIER
AS
BEGIN
	SELECT * FROM dbo.Suplier
END
GO
-- store insert phiếu đặt (order) này phải đc gọi trước insert_orderdetail
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(N'[USP_INSERT_ORDER]') AND OBJECTPROPERTY(ID, N'IsProcedure')=1)
	DROP PROC [USP_INSERT_ORDER]
GO

CREATE PROC USP_INSERT_ORDER (@nvcIdOrderProduct NVARCHAR(10), @nvcCreatedDate DATETIME, @nvcStatus BIT, @nvcIdUser NVARCHAR(10))
AS
BEGIN
	IF EXISTS (SELECT * FROM dbo.OrderProduct WHERE IdOrderProduct = @nvcIdOrderProduct)
		RETURN 0
	-- Tasking
	INSERT INTO dbo.OrderProduct( IdOrderProduct ,CreatedDate ,StatusOrderProduct ,IdUsers)
	VALUES  ( @nvcIdOrderProduct, @nvcCreatedDate, @nvcStatus, @nvcIdUser)
END
GO

-- store xác nhận đơn đặt hàng (là khi bạn t 1 bộ dữ liệu của bảng nhập hàng thì tức là phiếu đặt hàng 
--này đã được xử lí nên mới có chuyện nhập hàng vậy nên giá trị status của mã đặt hàng đó sẽ đc chuyện thành true()
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(N'[USP_CONFIRM_ORDER]') AND OBJECTPROPERTY(ID, N'IsProcedure')=1)
	DROP PROC [USP_CONFIRM_ORDER]
GO

CREATE PROC USP_CONFIRM_ORDER (@nvcIdOrderProduct NVARCHAR(10), @nvcStatus BIT)
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM dbo.OrderProduct WHERE IdOrderProduct = @nvcIdOrderProduct)
		RETURN 0
	-- Tasking
	UPDATE dbo.OrderProduct
	SET StatusOrderProduct = @nvcStatus
	WHERE IdOrderProduct = @nvcIdOrderProduct
END
GO

-- store insert chi tiết tiết phiếu đặt (bên code sẽ phải loop và gọi pro này nhiều lần)
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(N'[USP_INSERT_ORDERDETAIL]') AND OBJECTPROPERTY(ID, N'IsProcedure')=1)
	DROP PROC [USP_INSERT_ORDERDETAIL]
GO

CREATE PROC USP_INSERT_ORDERDETAIL (@nvcIdOrderProduct NVARCHAR(10), @nvcIdProduct NVARCHAR(10), @nvcAmount INT, @nvcIdUnit NVARCHAR(10), @nvcIdSuplier NVARCHAR(10))
AS
BEGIN
	IF EXISTS (SELECT * FROM dbo.OrderProductDetail WHERE IdOrderProduct = @nvcIdOrderProduct AND IdProduct = @nvcIdProduct)
		RETURN 0
	-- Tasking
	INSERT INTO dbo.OrderProductDetail( IdOrderProduct ,IdProduct ,Amount ,Id_Unit ,IdSuplier)
	VALUES  (@nvcIdOrderProduct, @nvcIdProduct, @nvcAmount, @nvcIdUnit, @nvcIdSuplier)
END
GO
-- store lấy dữ liệu đặt hàng
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(N'[USP_GET_ORDER]') AND OBJECTPROPERTY(ID, N'IsProcedure')=1)
	DROP PROC [USP_GET_ORDER]
GO

CREATE PROC USP_GET_ORDER
AS
BEGIN
	SELECT o.IdOrderProduct, o.CreatedDate, o.StatusOrderProduct, o.IdUsers, u.DisplayName, u.IdUserRole
	FROM dbo.OrderProduct o, dbo.Users u
	WHERE o.IdUsers = u.Id 
END
GO

--search data order
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(N'[USP_GETDATA_FILTER_ORDER]') AND OBJECTPROPERTY(ID, N'IsProcedure')=1)
	DROP PROC [USP_GETDATA_FILTER_ORDER]
GO

CREATE PROC USP_GETDATA_FILTER_ORDER (@nvcStatusOrderProduct NVARCHAR(10), @nvcIdUser NVARCHAR(10))
AS
BEGIN
	DECLARE @StatusOrderProduct NVARCHAR(10)
	SET @StatusOrderProduct = @nvcStatusOrderProduct

	DECLARE @IdUser NVARCHAR(10)
	SET @IdUser = @nvcIdUser


	SELECT * INTO tempTable
	FROM dbo.OrderProduct
	WHERE StatusOrderProduct = IIF(@StatusOrderProduct IS NULL, StatusOrderProduct, @StatusOrderProduct) AND
	IdUsers = IIF(@IdUser IS NULL, IdUsers, @IdUser)

	SELECT o.IdOrderProduct, o.CreatedDate, o.StatusOrderProduct, o.IdUsers, u.DisplayName, u.IdUserRole
	FROM tempTable o, dbo.Users u
	WHERE o.IdUsers = u.Id

	DROP TABLE tempTable

END
GO

-- store lấy dữ liệu chi tiết đặt hàng
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(N'[USP_GET_ORDERDETAIL]') AND OBJECTPROPERTY(ID, N'IsProcedure')=1)
	DROP PROC USP_GET_ORDERDETAIL
GO

CREATE PROC USP_GET_ORDERDETAIL
AS
BEGIN
	SELECT * FROM dbo.OrderProductDetail
END
GO


--store đăng nhập
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(N'[USP_LOGIN]') AND OBJECTPROPERTY(ID, N'IsProcedure')=1)
	DROP PROC [USP_LOGIN]
GO

CREATE PROC USP_LOGIN (@nvcIdUser NVARCHAR(50), @nvcPasswd NVARCHAR(50))
AS
BEGIN
	SELECT * FROM dbo.Users WHERE Id = @nvcIdUser AND Password = @nvcPasswd
END
GO

-- store lấy dữ liệu nhập hàng
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(N'[USP_GET_IMPORT]') AND OBJECTPROPERTY(ID, N'IsProcedure')=1)
	DROP PROC [USP_GET_IMPORT]
GO

CREATE PROC USP_GET_IMPORT
AS
BEGIN
	SELECT o.IdImportProduct, o.IdOrderProduct, o.CreatedDate, o.StatusImportProduct, o.IdUsers, o.IdPackage, o.TotalPrice, u.DisplayName, u.IdUserRole
	FROM dbo.ImportProduct o, dbo.Users u
	WHERE o.IdUsers = u.Id 
END
GO
-- store lấy dữ liệu chi tiết nhập hàng
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(N'[USP_GET_IMPORTDETAIL]') AND OBJECTPROPERTY(ID, N'IsProcedure')=1)
	DROP PROC [USP_GET_IMPORTDETAIL]
GO

CREATE PROC USP_GET_IMPORTDETAIL (@nvcIdImport NVARCHAR(10))
AS
BEGIN
	SELECT * FROM dbo.ImportProductDetail WHERE IdImportProduct = @nvcIdImport
END
GO

-- store insert cho bảng import
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(N'[USP_INSERT_IMPORT]') AND OBJECTPROPERTY(ID, N'IsProcedure')=1)
	DROP PROC [USP_INSERT_IMPORT]
GO

CREATE PROC USP_INSERT_IMPORT (@nvcIdImportProduct NVARCHAR(10), @nvcIdOrderProduct NVARCHAR(10), @nvcTotalPrice DECIMAL, @nvcCreatedDate DATETIME, @nvcStatus BIT, @nvcIDPackage NVARCHAR(10), @nvcIdUser NVARCHAR(10))
AS
BEGIN
	IF EXISTS (SELECT * FROM dbo.ImportProduct WHERE IdImportProduct = @nvcIdImportProduct)
		RETURN 0
	-- Tasking
	INSERT INTO dbo.ImportProduct( IdImportProduct ,IdOrderProduct ,TotalPrice ,CreatedDate ,StatusImportProduct ,IdPackage ,IdUsers)
	VALUES  ( @nvcIdImportProduct, @nvcIdOrderProduct, @nvcTotalPrice, @nvcCreatedDate, @nvcStatus, @nvcIDPackage, @nvcIdUser)
END
GO

-- store insert cho bảng importdetail
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(N'[USP_INSERT_IMPORTDETAIL]') AND OBJECTPROPERTY(ID, N'IsProcedure')=1)
	DROP PROC USP_INSERT_IMPORTDETAIL
GO

CREATE PROC USP_INSERT_IMPORTDETAIL (@nvcIdImportProduct NVARCHAR(10), @nvcIdProduct NVARCHAR(10), @nvcAmount INT, @nvcUnitPrice DECIMAL, @nvcIntoPrice DECIMAL, @nvcExpDate DATETIME, @nvcIdUnit NVARCHAR(10), @nvcIdSuplier NVARCHAR(10))
AS
BEGIN
	IF EXISTS (SELECT * FROM dbo.ImportProductDetail WHERE IdImportProduct = @nvcIdImportProduct AND IdProduct = @nvcIdProduct)
		RETURN 0
	-- Tasking
	INSERT INTO dbo.ImportProductDetail( IdImportProduct ,IdProduct ,Amount ,UnitPrice ,IntoPrice ,ExpiryDate ,Id_Unit ,IdSuplier)
	VALUES  ( @nvcIdImportProduct, @nvcIdProduct, @nvcAmount, @nvcUnitPrice, @nvcIntoPrice, @nvcExpDate, @nvcIdUnit, @nvcIdSuplier )
END
GO

-- store xác nhận phiếu nhập hàng được đưa mọi sản phẩm vào kho (vào lô - package) 
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(N'[USP_CONFIRM_IMPORT]') AND OBJECTPROPERTY(ID, N'IsProcedure')=1)
	DROP PROC [USP_CONFIRM_IMPORT]
GO

CREATE PROC USP_CONFIRM_IMPORT (@nvcIdImportProduct NVARCHAR(10), @nvcStatus BIT)
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM dbo.ImportProduct WHERE IdImportProduct = @nvcIdImportProduct)
		RETURN 0
	-- Tasking
	UPDATE dbo.ImportProduct
	SET StatusImportProduct = @nvcStatus
	WHERE IdImportProduct = @nvcIdImportProduct
END
GO

--store lấy dữ liệu của lô hàng
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(N'[USP_GET_PACKAGE]') AND OBJECTPROPERTY(ID, N'IsProcedure')=1)
	DROP PROC [USP_GET_PACKAGE]
GO

CREATE PROC USP_GET_PACKAGE
AS
BEGIN
	SELECT * FROM dbo.Package
END
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(N'[USP_GETDATA_PACKAGE]') AND OBJECTPROPERTY(ID, N'IsProcedure')=1)
	DROP PROC [USP_GETDATA_PACKAGE]
GO

CREATE PROC USP_GETDATA_PACKAGE
AS
BEGIN
	SELECT pack.IdPackage, pack.IdProduct, pro.DisplayName, pack.Amount, pack.ExpiryDate, u.DisplayName, sup.DisplayName, sup.IdSuplier
FROM dbo.Package pack,  dbo.Product pro, dbo.Unit u, dbo.Suplier sup
WHERE pack.IdProduct = pro.IdProduct AND
	  pack.Id_Unit = u.Id_Unit AND
	  pack.IdSuplier = sup.IdSuplier 
END
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(N'[USP_GETDATA_FILTER_PACKAGE]') AND OBJECTPROPERTY(ID, N'IsProcedure')=1)
	DROP PROC [USP_GETDATA_FILTER_PACKAGE]
GO

CREATE PROC USP_GETDATA_FILTER_PACKAGE (@nvcIdProduct NVARCHAR(10), @nvcProductName NVARCHAR(50))
AS
BEGIN
 
	IF (@nvcProductName = '')
		SELECT pack.IdPackage, pack.IdProduct, pro.DisplayName, pack.Amount, pack.ExpiryDate, u.DisplayName, sup.DisplayName, sup.IdSuplier
		FROM dbo.Package pack,  dbo.Product pro, dbo.Unit u, dbo.Suplier sup
		WHERE pack.IdProduct = pro.IdProduct AND
			  pack.Id_Unit = u.Id_Unit AND
			  pack.IdSuplier = sup.IdSuplier AND
			  pack.IdProduct = @nvcIdProduct 
	ELSE
		SELECT pack.IdPackage, pack.IdProduct, pro.DisplayName, pack.Amount, pack.ExpiryDate, u.DisplayName, sup.DisplayName, sup.IdSuplier
		FROM dbo.Package pack,  dbo.Product pro, dbo.Unit u, dbo.Suplier sup
		WHERE pack.IdProduct = pro.IdProduct AND
			  pack.Id_Unit = u.Id_Unit AND
			  pack.IdSuplier = sup.IdSuplier AND
			  pack.IdProduct = @nvcIdProduct AND
			  pro.DisplayName LIKE '%'+@nvcProductName+'%'
END
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(N'[USP_INSERT_PACKAGE]') AND OBJECTPROPERTY(ID, N'IsProcedure')=1)
	DROP PROC [USP_INSERT_PACKAGE]
GO

CREATE PROC USP_INSERT_PACKAGE (@nvcIdPackage NVARCHAR(10), @nvcIdProduct NVARCHAR(10), @nvcIdSuplier NVARCHAR(10), @nvcAmount INT, @nvcExpDate DATETIME, @nvcIdUnit NVARCHAR(10), @nvcIdOrder NVARCHAR(10))
AS
BEGIN
	IF EXISTS (SELECT * FROM dbo.Package WHERE IdPackage = @nvcIdPackage AND IdProduct = @nvcIdProduct)
		RETURN 0
	-- Tasking
	INSERT INTO dbo.Package (IdPackage ,IdProduct ,IdSuplier ,Amount ,ExpiryDate ,Id_Unit ,Id_OrderForm)
	VALUES  ( @nvcIdPackage, @nvcIdProduct, @nvcIdSuplier, @nvcAmount, @nvcExpDate, @nvcIdUnit, @nvcIdOrder)
END
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(N'[USP_CHART_ORDER_YEAR]') AND OBJECTPROPERTY(ID, N'IsProcedure')=1)
	DROP PROC [USP_CHART_ORDER_YEAR]
GO

CREATE PROC USP_CHART_ORDER_YEAR (@nvcYear NVARCHAR(4))
AS
BEGIN
	-- Tasking
	DECLARE @nvcStart NVARCHAR(10)
	SET @nvcStart = @nvcYear + '/01/01'
	DECLARE @nvcEnd NVARCHAR(10)
	SET @nvcEnd = @nvcYear + '/12/31'

	SELECT 
	  SUM(CASE datepart(month,CreatedDate) WHEN 1 THEN 1 ELSE 0 END) AS 'January',
	  SUM(CASE datepart(month,CreatedDate) WHEN 2 THEN 1 ELSE 0 END) AS 'February',
	  SUM(CASE datepart(month,CreatedDate) WHEN 3 THEN 1 ELSE 0 END) AS 'March',
	  SUM(CASE datepart(month,CreatedDate) WHEN 4 THEN 1 ELSE 0 END) AS 'April',
	  SUM(CASE datepart(month,CreatedDate) WHEN 5 THEN 1 ELSE 0 END) AS 'May',
	  SUM(CASE datepart(month,CreatedDate) WHEN 6 THEN 1 ELSE 0 END) AS 'June',
	  SUM(CASE datepart(month,CreatedDate) WHEN 7 THEN 1 ELSE 0 END) AS 'July',
	  SUM(CASE datepart(month,CreatedDate) WHEN 8 THEN 1 ELSE 0 END) AS 'August',
	  SUM(CASE datepart(month,CreatedDate) WHEN 9 THEN 1 ELSE 0 END) AS 'September',
	  SUM(CASE datepart(month,CreatedDate) WHEN 10 THEN 1 ELSE 0 END) AS 'October',
	  SUM(CASE datepart(month,CreatedDate) WHEN 11 THEN 1 ELSE 0 END) AS 'November',
	  SUM(CASE datepart(month,CreatedDate) WHEN 12 THEN 1 ELSE 0 END) AS 'December',
	  SUM(CASE datepart(year,CreatedDate) WHEN @nvcYear THEN 1 ELSE 0 END) AS 'TOTAL'
	FROM
		dbo.OrderProduct
	WHERE
	  CreatedDate BETWEEN @nvcStart AND @nvcEnd
END
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(N'[USP_CHART_SP_YEAR]') AND OBJECTPROPERTY(ID, N'IsProcedure')=1)
	DROP PROC [USP_CHART_SP_YEAR]
GO

CREATE PROC USP_CHART_SP_YEAR (@nvcIdProduct NVARCHAR(10), @nvcStart DATETIME, @nvcEnd DATETIME)
AS
BEGIN
	-- Tasking	
	SELECT SUM(q.Amount) AS SL
	FROM dbo.ImportProductDetail q, dbo.ImportProduct e
	WHERE e.CreatedDate BETWEEN @nvcStart AND @nvcEnd AND 
	q.IdImportProduct = e.IdImportProduct AND
	q.IdProduct = @nvcIdProduct 
END
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(N'[USP_CHART_SPX_YEAR]') AND OBJECTPROPERTY(ID, N'IsProcedure')=1)
	DROP PROC [USP_CHART_SPX_YEAR]
GO
CREATE PROC USP_CHART_SPX_YEAR (@nvcIdProduct NVARCHAR(10), @nvcStart DATETIME, @nvcEnd DATETIME)
AS
BEGIN
	-- Tasking	
	SELECT SUM(d.QUANTITY) AS SLX
	FROM dbo.OutputProduct o, dbo.DetailOutputProduct d
	WHERE o.ID = d.ID AND
	o.DATEOUTPUT BETWEEN @nvcStart AND @nvcEnd AND
	d.ID_PRODUCT = @nvcIdProduct
END
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(N'[USP_EXPORT]') AND OBJECTPROPERTY(ID, N'IsProcedure')=1)
	DROP PROC [USP_EXPORT]
GO

CREATE PROC USP_EXPORT
AS
BEGIN
	-- Tasking	
	SELECT o.ID, o.DATEOUTPUT, o.ID_USER, u.DisplayName, u.IdUserRole
	FROM dbo.OutputProduct o, dbo.Users u
	WHERE o.ID_USER = u.Id;
END



IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID(N'[USP_EXPORT_DETAIL]') AND OBJECTPROPERTY(ID, N'IsProcedure')=1)
	DROP PROC [USP_EXPORT_DETAIL]
GO

CREATE PROC USP_EXPORT_DETAIL (@nvcIdExport VARCHAR(10))
AS
BEGIN
	-- Tasking	
	SELECT * 
	FROM dbo.DetailOutputProduct o, dbo.Product p
	WHERE o.ID_PRODUCT = p.IdProduct AND o.ID = @nvcIdExport
END
GO



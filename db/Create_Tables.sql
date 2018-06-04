Create Table UserApp
(
	IdUser	int identity(1,1),
	NmUser	varchar(100),
	NmEmail	varchar(100),
	NmPassword	varchar(20),
	Constraint PK_UserApp Primary Key(IdUser)
)

Create Table UserList
(
	IdList	int identity(1,1),
	IdUser	int,
	NmList	varchar(100),
	Constraint PK_UserList Primary Key(IdList),
	Constraint FK_UserLIst_UserApp_IdUser Foreign Key(IdUser) References UserApp(IdUser)
)

Create Table TypeProduct
(
	IdTypeProduct	smallint identity(1,1),
	NmTypeProduct	varchar(100),
	NmURL	varchar(800),
	Constraint PK_TypeProduct Primary Key(IdTypeProduct)
)

Create Table Product
(
	IdProduct	int identity(1,1),
	NmProduct	varchar(200),
	IdTypeProduct	smallint,
	Constraint PK_Product Primary Key(IdProduct),
	Constraint FK_Product_TypeProduct_IdTypeProduct Foreign Key(IdTypeProduct) References TypeProduct(IdTypeProduct)
)

Create Table ProductStatus
(
	CdStatus	smallint identity(1,1),
	NmStatus	varchar(100),
	Constraint PK_ProductStats Primary Key(CdStatus)
)

Create Table ListProduct
(
	IdList int,
	--IdTypeProduct
	IdProduct int,
	CdStatus smallint,
	Constraint PK_ListProduct Primary Key(IdList, IdProduct),
	Constraint FK_ListProduct_UserList_IdList Foreign Key(IdList) References UserList(IdList),
	Constraint FK_ListProduct_Product_IdProduct Foreign Key(IdProduct) References Product(IdProduct),
	Constraint FK_ListProduct_ProductStatus_CdStatus Foreign Key(CdStatus) References ProductStatus(CdStatus)
)
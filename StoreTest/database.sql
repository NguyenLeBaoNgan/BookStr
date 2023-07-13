use master

create database Storetest
go
use Storetest
go
create table Account(
	Username varchar(50) primary key,
	[Password] char (20)
)
go
create table Category(
	ID int identity(1000,1) primary key,
	[Name] nvarchar(100) not null,
	[Image] ntext,
	IsDeleted bit default 0
)
go
create table TacGia(
	ID int identity(1000,1) primary key,
	[Name] nvarchar(100) not null,
	[Image] ntext,
	IsDeleted bit default 0
)
go
create table Product(
	ID int identity(1000,1) primary key,
	[Name] nvarchar(100) not null,
	Cost int not null,
	[Description] ntext,
	Details ntext,
	[Image] ntext,
	IsSeller bit default 0,
	OnTop bit default 0,
	IDCategory int not null constraint fk_1 foreign key(IDCategory) references Category(ID),
	IDTacGia int not null constraint fk_2 foreign key(IDTacGia) references TacGia(ID),
	IsDeleted bit default 0
)
go
create table ImageProduct(
	ID int identity(1000,1) primary key,
	[Image] ntext,
	[IDProduct] int not null constraint fk_3 foreign key(IDProduct) references Product(ID)
)
go
create table Slider(
	ID int identity(1000,1) primary key,
	[Image] ntext,
	IsShow bit default 0
)
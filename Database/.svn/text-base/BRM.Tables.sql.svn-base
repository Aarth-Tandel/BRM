use Training2017;
go
create schema BRM;
go

create table BRM.Application
(
	ID int IDENTITY(1,1) PRIMARY KEY,
	Name varchar(30),
	Username nvarchar(30),
	Password nvarchar(30)
)

create table BRM.Release 
(
	 ID int IDENTITY(1,1) PRIMARY KEY,
	Name varchar(30),
	Status varchar(30),
	Application_ID int foreign key references BRM.Application(ID),
	SVN varchar(30),
	Change_ID int foreign key references BRM.Changes(ID)
)

create table BRM.Changes 
(
	 ID int IDENTITY(1,1) PRIMARY KEY,
	value varchar(30)
)

create table BRM.Environment 
(
	 ID int IDENTITY(1,1) PRIMARY KEY,
	value varchar(30),
	Release_ID int foreign key references BRM.Release(ID),
)

create table BRM.Server 
(
	 ID int IDENTITY(1,1) PRIMARY KEY,
	Directory varchar(30),
	Name varchar(30),
	IP varchar(30),
	Username varchar(30),
	Password varchar(30),
	Environment_ID int foreign key references BRM.Environment(ID)
)

create table BRM.UserDetails
(
	 ID int IDENTITY(1,1) PRIMARY KEY,
	FirstName varchar(30),
	LastName varchar(30),
	Username varchar(30),
	Password varchar(30)
)

create table BRM.Logs 
(
	 ID int IDENTITY(1,1) PRIMARY KEY,
	Application_ID int foreign key references BRM.Application(ID),
	Release_ID int foreign key references BRM.Release(ID),
	Environment_ID int foreign key references BRM.Environment(ID),
	Server_ID int foreign key references BRM.Server(ID),
	Change_ID int foreign key references BRM.Changes(ID),
	Users_ID int foreign key references BRM.UserDetails(ID),
	StartDate varchar(30),
	CompleteDate varchar(30)
)
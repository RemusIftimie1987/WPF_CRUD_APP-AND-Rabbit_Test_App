drop database if exists TasksDB 
go

create database TasksDB
go
use TasksDB

drop table if exists Categories
go

create table Categories
(
	CategoriesID int Not Null Identity Primary Key,
	CategoryName nvarchar(50) Null
)
go

drop table if exists Users
go

create table Users
(
	UserID int Not Null Identity Primary Key,
	UserName nvarchar(50) Null
)
go

drop table if exists Tasks
go

create table Tasks
(
	TasksID int Not Null Identity Primary Key,
	Description varchar(50) Null,
	Done bit Null,
	DateDone date Null,
	CategoriesID int Null,
	UserID int Null,

	Foreign Key (CategoriesID) References Categories (CategoriesID),
	Foreign Key (UserID) References Users (UserID)
)
go

Insert into Users Values('Tom')
Insert into Users Values('Bob')
Insert into Users Values('Harry')
Insert into Categories Values('Programming')
Insert into Categories Values('Admin')
Insert into Categories Values('Personal')
Insert into Tasks Values('Test_Task 1',1,'2019-11-26',1,1)
Insert into Tasks Values('Test_Task 2',0,'2019-11-25',2,2)
Insert into Tasks Values('Test_Task 3',1,'2019-11-24',3,3)

Select * From Tasks
Select * From Users
Select * From Categories
drop database if exists StudentTutorDatabase
go

create database StudentTutorDatabase
go
use StudentTutorDatabase

drop table if exists Tutors
go
create table Tutors
(
TutorID int Not Null Identity Primary Key,
TutorName nvarchar(50) Null,
)

drop table if exists Students
go
create table Students
(
StudentID int Not Null Identity Primary Key,
Studentname nvarchar(50) Null,
TutorID int Null,
Foreign Key (TutorID) References Tutors (TutorID)
)

INSERT INTO Tutors VALUES ('Aamir')
INSERT INTO Tutors VALUES ('Rose')
INSERT INTO Tutors VALUES ('Hassan')
INSERT INTO Students VALUES ('Remus', 1)
INSERT INTO Students VALUES ('Isaac', 3)
INSERT INTO Students VALUES ('Ramon', 2)

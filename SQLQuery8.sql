drop database AdvancedDB

create database AdvancedDB

use AdvancedDB

create table Employee
(EmpId int primary key identity(101,1),
FName nvarchar(50) not null,
LName nvarchar(50) not null,
BirthDate date,
Salary float
)

create table Products
(PId int primary key identity(1001,2),
PName nvarchar(50) not null,
PDescription nvarchar(50) not null,
PPrice money not null,
PReleaseDate datetime
)

create table Orders
(OId int primary key identity(10001,2),
OrderDate datetime,
OQuantity smallint,
ODiscount float,
OIsShipped bit
)

insert into Employee(FName,LName,Salary,BirthDate) values ('Andrew','Simons',88000.90,'02/12/1998'),
('Naina','Talwar',89000.55,'12/07/1999'),
('Simran','Kaur',56000.55,'10/10/1998')

insert into Products (PName,PDescription,PPrice,PReleaseDate) values 
('Smartphone','Innovation at Finger Tips',45000.00,'12/12/2022 11:00:00'),
('Laptop','Innovation-Next Gen',75000.00,'02/02/2023 17:30:00'),
('Earpods','Noise Proof Experience',8500.00,'09/09/2023 20:30:30')

insert into Orders (OrderDate,OQuantity,ODiscount,OIsShipped) values
('09/12/2022 09:00:15',15,7.5,1),
('01/26/2023 12:40:15',20,5.5,0),
('01/09/2023 18:55:15',25,3.5,1)

select * from Employee
select * from Products
select * from Orders


IF DB_ID('EmployeeManagement') IS NULL
BEGIN
    CREATE DATABASE EmployeeManagement;
END
GO

USE EmployeeManagement;
GO


IF OBJECT_ID('Employees','U') IS NOT NULL
DROP TABLE Employees;

IF OBJECT_ID('Departments','U') IS NOT NULL
DROP TABLE Departments;
GO


CREATE TABLE Departments
(
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);
GO


CREATE TABLE Employees
(
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT,
    Salary DECIMAL(10,2),
    JoinDate DATE,
    FOREIGN KEY (DepartmentID)
    REFERENCES Departments(DepartmentID)
);
GO


INSERT INTO Departments VALUES
(1,'HR'),
(2,'Finance'),
(3,'IT'),
(4,'Marketing');
GO


INSERT INTO Employees
(
FirstName,
LastName,
DepartmentID,
Salary,
JoinDate
)
VALUES
('John','Doe',1,5000,'2020-01-15'),
('Jane','Smith',2,6000,'2019-03-22'),
('Michael','Johnson',3,7000,'2018-07-30'),
('Emily','Davis',4,5500,'2021-11-05');
GO


CREATE PROCEDURE sp_InsertEmployee
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Salary DECIMAL(10,2),
    @JoinDate DATE
AS
BEGIN

INSERT INTO Employees
(
FirstName,
LastName,
DepartmentID,
Salary,
JoinDate
)

VALUES
(
@FirstName,
@LastName,
@DepartmentID,
@Salary,
@JoinDate
);

END;
GO


EXEC sp_InsertEmployee
'David',
'Wilson',
3,
7500,
'2024-01-10';
GO

SELECT *
FROM Employees;
GO
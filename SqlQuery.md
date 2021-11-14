CREATE TABLE Employees
(
    Id UNIQUEIDENTIFIER PRIMARY KEY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL
)

CREATE TABLE SickLeaves
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	EmployeeId UNIQUEIDENTIFIER REFERENCES Employees (Id),
	[Start] DATETIME NOT NULL,
	Finish DATETIME NOT NULL
)

CREATE TABLE Vacations
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	EmployeeId UNIQUEIDENTIFIER REFERENCES Employees (Id),
	[Start] DATETIME NOT NULL,
	Finish DATETIME NOT NULL
)

CREATE PROC spGetEmployees
AS
	SELECT * FROM Employees; 
GO

CREATE PROCEDURE spGetSickLeaves
AS
	SELECT s.Id, e.Id as EmployeeId, e.FirstName as FirstName, e.LastName as LastName, s.[Start], s.Finish FROM SickLeaves s
	JOIN Employees e ON s.EmployeeId = e.Id;
GO

CREATE PROC spGetVacation
AS
	SELECT v.Id, e.Id as EmployeeId, e.FirstName as FirstName, e.LastName as LastName, v.[Start], v.Finish FROM Vacations v
		JOIN Employees e ON v.EmployeeId = e.Id
GO

EXEC spGetEmployees

EXEC spGetSickLeaves

EXEC spGetVacation

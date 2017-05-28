/***** CTRL+Shift+R - clears cashe *****/

/* add use */
USE TelerikAcademy

/* Simple select */
SELECT * FROM Employees

/* Select column */
SELECT FirstName FROM Employees

/* filter selection */
SELECT FirstName, LastName FROM Employees WHERE FirstName = 'Linda'

/* use alias for column */
/* can use >, <, >=, <=, BETWEEN x AND y, IN(1, 2, 3), NOT IN(), LIKE '%or', '_ter', %[a-z]%*/
SELECT FirstName, LastName, EmployeeID AS ID FROM Employees WHERE EmployeeID = '1' 
SELECT FirstName, LastName, EmployeeID FROM Employees WHERE EmployeeID IN(1, 4, 6, 32) 
SELECT FirstName, LastName, EmployeeID FROM Employees WHERE FirstName LIKE '%ter' 
SELECT FirstName, LastName, EmployeeID FROM Employees WHERE LastName LIKE '%[x, y, z]%' ORDER BY FirstName

/* aritmetic operations, braces for space */
SELECT LastName, Salary, Salary + 300 AS [Salary Bonus] FROM Employees

/* top */
SELECT TOP 10 EmployeeID, FirstName, LastName FROM Employees  

/* NULL (show all managers), concatenate columns */
SELECT FirstName + ' ' + LastName AS [Full Name], Salary, ManagerID FROM Employees WHERE ManagerID IS Null

/* remove duplicates */
SELECT DISTINCT DepartmentID FROM Employees

/* union - combine colums */
SELECT FirstName AS Name FROM Employees UNION SELECT LastName AS Name FROM Employees

/* union - combine colums - all shows duplocates */
SELECT FirstName AS Name FROM Employees UNION ALL SELECT LastName AS Name FROM Employees

/* intersect - returns distinct rows that are output by both the left and right input queries operator */
SELECT FirstName AS Name FROM Employees INTERSECT SELECT LastName AS Name FROM Employees

/* except - returns distinct rows from the left input query that aren’t output by the right input query */
SELECT FirstName AS Name FROM Employees EXCEPT SELECT LastName AS Name FROM Employees

/* AND, OR filters */
SELECT FirstName FROM Employees WHERE ManagerID IS NOT NULL AND (Salary < 10000 OR LastName LIKE '%[p, q]%') 

/* ORDER BY */
SELECT * FROM Employees WHERE ManagerID IS NOT NULL ORDER BY FirstName DESC /* ASC is default */

/* JOIN - Cartesian Product / CROSS JOIN (not usable) */
SELECT LastName, Name AS Department FROM Employees, Departments

/* Equijoins ( no JOIN written, same as INNER JOIN ) */
SELECT e.EmployeeID, e.LastName, e.DepartmentID, d.DepartmentID, d.Name AS Department
FROM Employees e, Departments d
WHERE e.DepartmentID = d.DepartmentID

/* INNER JOIN - gives all that only have the IDs */
SELECT e.EmployeeID, e.LastName, e.DepartmentID, d.DepartmentID, d.Name AS Department 
FROM Employees AS e INNER JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID

/* LEFT OUTER JOIN, Self Join */
SELECT e.FirstName, e.LastName, e.ManagerID, m.EmployeeID, m.FirstName + ' ' + m.LastName AS Manager 
FROM Employees AS e LEFT OUTER JOIN Employees AS m
ON e.ManagerID = m.EmployeeID

/* RIGHT OUTER JOIN */
SELECT e.FirstName, e.LastName, e.ManagerID, m.EmployeeID, m.FirstName + ' ' + m.LastName AS Manager 
FROM Employees AS e RIGHT OUTER JOIN Employees AS m
ON e.ManagerID = m.EmployeeID

/* 3 way join */
SELECT e.FirstName, e.LastName, t.Name AS Town, t.TownID AS [Town ID], a.AddressText AS Address
FROM Employees e 
JOIN Addresses a ON e.AddressID = a.AddressID 
JOIN Towns t ON a.TownID = t.TownID
WHERE t.TownID < 5 ORDER BY t.TownID

/* INSERT */
INSERT INTO Towns VALUES('Pernik')
SELECT  TOP 1 * FROM Towns ORDER BY TownID DESC /* shows last added town */

INSERT INTO Departments (Name, ManagerID) VALUES ('Vinkeli', 1)
SELECT d.*, e.FirstName + ' ' + e.LastName AS [Department Manager] 
FROM Departments d JOIN Employees e ON d.ManagerID = e.EmployeeID 
WHERE Name = 'Vinkeli'

INSERT INTO Towns SELECT FirstName FROM Employees WHERE LastName = 'Nakov'

INSERT INTO EmployeesProjects VALUES (229, 25)
INSERT INTO Projects(Name, StartDate) SELECT Name + ' Restructing', GETDATE() FROM Departments WHERE DepartmentID = '1'
SELECT * FROM Projects WHERE Name LIKE '%Restructing'

/* bulk insert */
INSERT INTO Towns VALUES ('Chepelare'), ('Haskovo'), ('Ihtiman')
SELECT  TOP 5 * FROM Towns ORDER BY TownID DESC

/************************************************ UPDATE ****************************************************/

/* UPDATE Data */
UPDATE Employees 
SET JobTitle = 'Senior ' + JobTitle
FROM Employees e JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE d.Name LIKE '%Sales%'
SELECT e.*, d.Name FROM Employees e JOIN Departments d ON e.DepartmentID = d.DepartmentID WHERE e.JobTitle LIKE 'Senior%'

/* DELETE */
DELETE FROM Employees 
FROM Employees e JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales' AND e.FirstName = 'David'

/* NESTED SELECTS */
SELECT FirstName, LastName, Salary
FROM Employees WHERE Salary = (SELECT MAX(Salary) FROM Employees)

SELECT e.FirstName, e.LastName, d.Name AS Department, e.Salary
FROM Employees e JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE d.DepartmentID IN (SELECT DepartmentID FROM Departments WHERE Name = 'Sales') ORDER BY e.Salary

/* EXISTS */
SELECT FirstName, LastName, ManagerID FROM Employees e
WHERE EXISTS (SELECT EmployeeID FROM Employees m WHERE m.EmployeeID = e.ManagerID AND m.DepartmentID = 1)

/* GROUP FUNCTIONS - COUNT(*), SUM(column), AVG(column), MAX(column), MIN(column)*/
SELECT
	AVG(Salary) [Average Salary],
	MAX(Salary) [Max Salary],
	MIN(Salary) [Min Salary],
	SUM(Salary) [Salary Sum],
	COUNT(Salary) [Number of Persons]
FROM Employees
WHERE JobTitle LIKE '%Sales%'

SELECT MIN(LastName) [First Last Name], MAX(LastName) [Last Last Name] FROM Employees
SELECT MIN(HireDate) [Eariest Hire Date], MAX(HireDate) [Latest Hire Date] FROM Employees
SELECT COUNT(*) AS [Number Of Persons Taking More Than 40k] FROM Employees WHERE DepartmentID = 3 AND Salary > 40000
SELECT AVG(ManagerID) AS [Average], SUM(ManagerID) / COUNT(*) AS [Average All] FROM Employees

/* Group Data By Several Columns */
SELECT DepartmentID, JobTitle, SUM(Salary) AS [Salaries], COUNT(*) AS [Count] FROM Employees 
GROUP BY DepartmentID, JobTitle

/* For Group Functions use HAVING */
SELECT e.JobTitle, AVG(Salary) AS [Average], MAX(Salary) AS [MAX], MIN(Salary) AS [MIN] FROM Employees e
GROUP BY e.JobTitle 
HAVING AVG(Salary) > 40000

SELECT COUNT(*) AS [Employee Count], d.Name AS [Department Name]
FROM Employees e JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate BETWEEN '1999-2-1' AND '2012-12-31'
GROUP BY d.Name HAVING COUNT(*) > 5 
ORDER BY [Employee Count] DESC

/* ISNULL(<value>,<default_value>) */
SELECT Name AS [Project Name], p.StartDate AS [Start Date],
ISNULL(EndDate, GETDATE()) AS [End Date]
FROM Projects p

/* COALESCE(<value>,<value>,<value>) */
SELECT COALESCE(ManagerID, 1000)
FROM Employees

SELECT Name AS [Project Name], COALESCE(CONVERT(nvarchar(50), EndDate), 'Not Finished') 
AS [Date Finished] FROM Projects

/* STRING FUNCTIONS, also SUBSTRING, REPLACE */
SELECT FirstName AS [Normal Case], 
UPPER(FirstName) AS [Upper Case], 
LOWER(FirstName) AS [Lower Case],
LEN(FirstName) AS [Length],
LEFT(FirstName, 3) AS [Left 3 Symbols],
RIGHT(FirstName, 3) AS [Last 3 Symbols],
RTRIM(LTRIM(FirstName)) AS [Trimmed Both Sides]
FROM Employees

SELECT FLOOR(3.14) AS [PI]
SELECT ROUND(5.86, 0) AS [Rounded] 

/* CONVERT, CAST datetime http://www.sqlusa.com/bestpractices/datetimeconversion/ */
SELECT CONVERT(DATETIME, '20051231', 112) AS [Converted to Date] /* iso date codes in ms sql server */
SELECT CONVERT(nvarchar(50), GETDATE()) AS [Tochno Vreme v Momenta] 

/************************************************ DDL ****************************************************/

/* DATA DEFINITION LANGUAGE */
/* CREATE */
CREATE TABLE Persons (
	PersonID int IDENTITY NOT NULL, 
	Name nvarchar(50) NOT NULL,
	CONSTRAINT PK_Persons PRIMARY KEY CLUSTERED (PersonID ASC)
)
GO

/* Create View */
CREATE VIEW [First 10 Persons] AS 
SELECT TOP 10 Name FROM Persons
GO

INSERT INTO Persons VALUES('Gosho'),('Pesho'),('Ivan'),('Petkan')
SELECT * FROM Persons
INSERT INTO Persons SELECT FirstName FROM Employees WHERE Salary BETWEEN 50000 AND 60000

/* ADD COnstraint */
CREATE TABLE Countries (
 CountryID int IDENTITY PRIMARY KEY,
 Name NVARCHAR(50) NOT NULL 
 CONSTRAINT CHK_Name CHECK(LEN(Name) > 3)
)
GO

/* Drop Constraint */
ALTER TABLE Countries 
DROP CONSTRAINT CHK_Name
GO

/* Add Constraint to existing table */
ALTER TABLE Countries 
ADD CONSTRAINT CHK_Name CHECK(LEN(Name) >=3)
GO

/* Add unique */
ALTER TABLE Countries
ADD CONSTRAINT Name UNIQUE(Name)

INSERT INTO Countries VALUES('Bulgaria'),('USA'),('Romania')
SELECT * FROM Countries

/* FOREIGN KEY */
ALTER TABLE Persons
ADD CountryID int FOREIGN KEY(CountryID)
REFERENCES Countries(CountryID)

SELECT * FROM Persons p JOIN Countries c ON p.CountryID = c.CountryID

/* DROP TABLE, TRIGGER, INDEX */
DROP TABLE Persons

/* ACCESS PERMISIONS - GRANT, DENY, REVOKE */
GRANT SELECT ON Persons TO public
REVOKE SELECT ON Employees FROM public

/********************************************** T-SQL ******************************************************/

/* TRANSACTIONS */

BEGIN TRAN                        /* start a transaction */
DELETE FROM EmployeesProjects;
DELETE FROM Projects;
ROLLBACK TRAN                     /* rollback a transaction */

SET IMPLICIT_TRANSACTIONS ON      /* turn implicit on transaction (not good) */

/* ALTER TABLE */
ALTER TABLE Persons
ALTER COLUMN Name nvarchar(100)

/* BATCH DIRECTIVES */
DECLARE @query nvarchar(50) = 'SELECT * FROM Employees'
EXEC(@query)

USE TelerikAcademy
GO

DECLARE @table varchar(50) = 'Projects'
SELECT 'The table is: ' + @table
PRINT ('The table is: ' + @table)
SET @table = 'Employees'
DECLARE @query varchar(50) = 'Select * FROM ' + @table;
EXEC(@query)
GO

/******** FUNCTIONS **********/
/* aggregate */

SELECT AVG(Salary) AS [Average Salary] FROM Employees
/* scalar */

SELECT DB_NAME() AS [Active Database]
/* rowset */
SELECT * FROM OPENDATASOURCE('SQLNCLI', 'Data Source = London\Payroll;Integrated Sequrity = SSPI').AdventureWorks.HumanResources.Employee

/* expressions - DATEDIFF() */
SELECT DATEDIFF(Year, HireDate, GETDATE()) * Salary / 1000 AS [Anual Bonus] FROM Employees

/********* IF - ELSE *********/
IF ((SELECT COUNT(*) FROM Employees) >= 100)
	BEGIN
		PRINT 'Employees are at least 100'
	END
ELSE
	BEGIN
		PRINT 'Employees are less than 100'
	END

/********* WHILE *********/
DECLARE @n int = 10
PRINT 'Calculating factorial of ' +
	CAST(@n as varchar) + ' ...'

DECLARE @factorial numeric(38) = 1

WHILE(@n > 1)
	BEGIN
		SET @factorial = @factorial * @n
		SET @n = @n - 1
	END
PRINT @factorial

/********** CASE **********/
SELECT FirstName + ' ' + LastName, Salary, [Salary Level] = 
	CASE
		WHEN Salary BETWEEN 0 AND 9999 THEN 'Low'
		WHEN Salary BETWEEN 10000 AND 30000 THEN 'Average'
		WHEN Salary > 30000 THEN 'High'
		ELSE 'Unknown'
	END
FROM Employees
GO

/*********************** STORED PROCEDURE ****************************/

/* CREATE */
CREATE PROC usp_SelectAllFromTable @tableName nvarchar(20)
AS
BEGIN
	DECLARE @query varchar(50) = 'Select * FROM ' + @tableName;
	EXEC(@query)
END
GO

/* ALTER */
ALTER PROCEDURE usp_SelectAllFromTable @tableName nvarchar(20)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @query varchar(50) = 'Select * FROM ' + @tableName;
	EXEC(@query)
END
GO

/* EXECUTE */
EXEC usp_SelectAllFromTable 'Projects'
EXEC sp_who

/* DROP */
DROP PROC usp_SelectAllFromTable
GO

/* OUTPUT PARAMETERS */
CREATE PROC usp_AddMyNumbers
	@firstNumber smallint,
	@secondNumber smallint,
	@result int OUTPUT
AS
	SET  @result = @firstNumber + @secondNumber
GO 

DECLARE @res INT
EXEC usp_AddMyNumbers 234, 453, @res OUTPUT
PRINT(@res)
GO

/* RETURN - SCOPE_IDENTITY() */
CREATE PROC usp_AddNewTown
	@townName nvarchar(100)
AS
BEGIN
	INSERT INTO Towns VALUES(@townName)
	RETURN SCOPE_IDENTITY()
END
GO

DECLARE @id int
EXEC @id = usp_AddNewTown 'Shumen'
PRINT(@id)
SELECT TOP 1 * FROM Towns ORDER BY TownID DESC
GO

/**************************** TRIGGERS *******************************/
/* AFTER, INSTEAD OF */
CREATE TRIGGER urt_PrintDeletedRecord ON Towns
AFTER UPDATE
AS
BEGIN
	SELECT * FROM deleted
	SELECT * FROM inserted
END
GO

ALTER TRIGGER urt_PrintDeletedRecord ON Towns
INSTEAD OF UPDATE
AS
BEGIN
	PRINT ('Cannot Update!')
END
GO

UPDATE Towns SET Name = 'Silistra' WHERE TownID = 40
GO 

/************ FUNCTIONS *************/
/* Scalar */
CREATE FUNCTION ufn_CalcBonus(@salary money = 100)
	RETURNS money
AS
BEGIN
	IF (@salary < 10000)
		RETURN 1000
	ELSE IF (@salary BETWEEN 10000 AND 30000)
		RETURN @salary / 20
	RETURN 3500
END
GO

SELECT FirstName + ' ' + LastName, Salary, [Bonus] = dbo.ufn_CalcBonus(Salary) FROM Employees
GO

/* Table */
CREATE FUNCTION ufn_ReturnPernik()
RETURNS TABLE
AS
RETURN (
	SELECT * FROM Towns WHERE TownID > 30
)
GO

SELECT * FROM ufn_ReturnPernik()

/************ CURSORS *************/
DECLARE @name nvarchar(50)

DECLARE myCursor CURSOR FOR SELECT Name FROM Towns

OPEN myCursor
FETCH NEXT FROM myCursor INTO @name
IF @@FETCH_STATUS <> 0
	PRINT '<< None >>'
WHILE @@FETCH_STATUS = 0
BEGIN
	PRINT(@name)
	FETCH NEXT FROM myCursor INTO @name
END
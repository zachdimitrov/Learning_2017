-- 05. Advanced SQL Homework --

-- 1.	Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
	-- *	Use a nested `SELECT` statement.
SELECT FirstName, LastName, Salary FROM Employees
WHERE Salary = (SELECT MIN(Salary) FROM Employees)

-- 2.	Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.
SELECT FirstName, LastName, Salary FROM Employees
WHERE Salary < (SELECT MIN(Salary) FROM Employees)*1.1

-- 3.	Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
	-- *	Use a nested `SELECT` statement.
SELECT e.FirstName + ' ' + e.Lastname, e.Salary, d.Name AS [Department]
FROM Employees e 
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary = (SELECT MIN(p.Salary) FROM Employees p WHERE p.DepartmentID = e.DepartmentID)

-- 4.	Write a SQL query to find the average salary in the department #1.
SELECT AVG(Salary) AS [Average Salaries] FROM Employees WHERE DepartmentID = 1

-- 5.	Write a SQL query to find the average salary  in the "Sales" department.
SELECT AVG(e.Salary) AS [Average Salary of "Sales"] FROM Employees e 
JOIN Departments d ON e.DepartmentID = d.DepartmentID 
WHERE d.Name = 'Sales'

-- 6.	Write a SQL query to find the number of employees in the "Sales" department.
SELECT COUNT(*) AS [Number of Employees in Department] FROM Employees e 
JOIN Departments d ON e.DepartmentID = d.DepartmentID 
WHERE d.Name = 'Sales'

-- 7.	Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(*) AS [Employees With Manager] FROM Employees WHERE ManagerID IS NOT NULL

-- 8.	Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(*) AS [Employees With No Manager] FROM Employees WHERE ManagerID IS NULL

-- 9.	Write a SQL query to find all departments and the average salary for each of them.
SELECT d.Name AS [Department], AVG(e.Salary) AS [Average Salary] FROM Employees e 
JOIN Departments d ON e.DepartmentID = d.DepartmentID 
GROUP BY d.Name

-- 10.	Write a SQL query to find the count of all employees in each department and for each town.
	-- Department
SELECT COUNT(*) AS [Number Of Employees by Department], d.Name AS [Department] FROM Employees e 
JOIN Departments d ON e.DepartmentID = d.DepartmentID GROUP BY d.Name

	-- Town
SELECT COUNT(*) AS [Number Of Employees by Town], t.Name AS [Town] FROM Employees e 
JOIN Addresses s ON e.AddressID = s.AddressID
JOIN Towns t ON s.TownID = t.TownID 
GROUP BY t.Name

-- 11.	Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
SELECT m.FirstName, m.LastName FROM Employees m
JOIN Employees e ON e.ManagerID = m.EmployeeID
WHERE (SELECT COUNT(*) FROM Employees WHERE ManagerID = m.EmployeeID) = 5

-- 12.	Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".
SELECT e.FirstName + ' ' + e.LastName AS [Full Name], CASE WHEN e.ManagerId IS NULL THEN '(no manager)' ELSE m.FirstName + ' ' + m.LastName END AS [Manager]
FROM Employees e 
LEFT OUTER JOIN Employees m ON e.ManagerID = m.EmployeeID

-- 13.	Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in `LEN(str)` function.
SELECT FirstName, LastName FROM Employees WHERE LEN(LastName) = 5

-- 14.	Write a SQL query to display the current date and time in the following format "`day.month.year hour:minutes:seconds:milliseconds`".
	-- *	Search in Google to find how to format dates in SQL Server.
PRINT CONVERT(VARCHAR(24),GETDATE(),113)
PRINT FORMAT(getdate(), N'dd.MM.yyyy hh:mm:ss:ms')

-- 15.	Write a SQL statement to create a table `Users`. Users should have username, password, full name and last login time.
	-- *	Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
	-- *	Define the primary key column as identity to facilitate inserting records.
	-- *	Define unique constraint to avoid repeating usernames.
	-- *	Define a check constraint to ensure the password is at least 5 characters long.
CREATE TABLE Users
(
	UserID int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	UserName nvarchar(50) UNIQUE,
	Password nvarchar(50) CHECK(LEN(Password) >= 5),
	FullName nvarchar(100),
	LastLogin smalldatetime,
)
GO

-- 16.	Write a SQL statement to create a view that displays the users from the `Users` table that have been in the system today.
	-- *	Test if the view works correctly.
	-- Add users
BEGIN TRAN
INSERT INTO Users Values
('Pesho', '12345', 'Petar Petrov', GETDATE()),
('Gosho', 'qwert', 'Georgi Ivanov', '2016-12-01'),
('Ivan', 'q1w2e', 'Ivan Ivanov', '2017-05-29'),
('Ceco', '1q2w3', 'Cvetan Petrov', '2017-05-28')
GO

	-- create view
CREATE VIEW LoggedToday AS
SELECT * FROM Users
WHERE LastLogin = GETDATE()
GO

	-- query using view 
SELECT * FROM LoggedToday

-- 17.	Write a SQL statement to create a table `Groups`. Groups should have unique name (use unique constraint).
	-- *	Define primary key and identity column.
CREATE TABLE Groups 
(
	GroupID int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	Name nvarchar(50) UNIQUE
)
GO

-- 18.	Write a SQL statement to add a column `GroupID` to the table `Users`.
	-- *	Fill some data in this new column and as well in the `Groups table.
ALTER TABLE Users
ADD GroupID int
GO

INSERT INTO Groups Values
('Lion'),('Tiger'),('Jaguar'),('Puma')
GO

UPDATE Users SET GroupID = 2 WHERE UserName = 'Pesho'
UPDATE Users SET GroupID = 1 WHERE UserName = 'Gosho'
UPDATE Users SET GroupID = 3 WHERE UserName = 'Ivan'
UPDATE Users SET GroupID = 4 WHERE UserName = 'Ceco'
GO

	-- *	Write a SQL statement to add a foreign key constraint between tables `Users` and `Groups` tables.
ALTER TABLE Users
ADD FOREIGN KEY (GroupID) REFERENCES Groups(GroupID)
GO

-- 19.	Write SQL statements to insert several records in the `Users` and `Groups` tables.
INSERT INTO Groups Values
('Cheetah'),
('Lynx'),
('Leopard'),
('Cougar')
GO

INSERT INTO Users Values
('Tsonko', '4321432', 'Tsonko Tsonev', GETDATE(), 5),
('Gegata', 'uyjyyty', 'Georgi Georgiev', '2015-01-01', 6),
('Ivan2', 'fsdfds', 'Ivan Petrov', '2011-02-21', 7),
('CecCo', 'sadffdsfsd', 'Cvetan Cvetkov', '2017-05-28', 8)
GO

-- 20.	Write SQL statements to update some of the records in the `Users` and `Groups` tables.
UPDATE Users SET Password = '987654321' WHERE UserName = 'Pesho'
UPDATE Users SET GroupID = 4 WHERE UserName = 'Tsonko'
UPDATE Groups SET Name = 'Gepard' WHERE Name = 'Cheetah'

-- 21.	Write SQL statements to delete some of the records from the `Users` and `Groups` tables.
DELETE FROM Users Where UserName LIKE '%2'
DELETE FROM Groups Where GroupID = 5

-- 22.	Write SQL statements to insert in the `Users` table the names of all employees from the `Employees` table.
	-- *	Combine the first and last names as a full name.
	-- *	For username use the first letter of the first name + the last name (in lowercase).
	-- *	Use the same for the password, and `NULL` for last login time.
INSERT INTO Users
SELECT LEFT(FirstName, 1) + LastName,
LOWER(LEFT(FirstName, 1)) + LastName + '12345',
FirstName + ' ' + LastName,
NULL,
(SELECT TOP(1) GroupID FROM Groups ORDER BY RAND())
FROM Employees WHERE LastName <> 'Hill'

SELECT RIGHT(Password, 5) FROM Users

UPDATE Users
SET Password = REPLACE(Password, RIGHT(Password, 5), '') 
WHERE LEN(Password) >= 10

-- 23.	Write a SQL statement that changes the password to `NULL` for all users that have not been in the system since 10.03.2010.
UPDATE Users 
SET LastLogin = '2008-12-01' 
WHERE UserName = 'Gosho'

UPDATE Users 
SET Password = NULL 
WHERE CONVERT(DATE, LastLogin) < CONVERT(DATE, '2010-03-10') AND LastLogin IS NOT NULL

-- 24.	Write a SQL statement that deletes all users without passwords (`NULL` password).
DELETE FROM Users
WHERE Password IS NULL

-- 25.	Write a SQL query to display the average employee salary by department and job title.
SELECT AVG(Salary), d.Name AS [Department], e.JobTItle
FROM EMployees e JOIN Departments d ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle

-- 26.	Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.
SELECT MIN(Salary), 
(SELECT TOP(1) FirstName + ' ' + LastName FROM Employees WHERE JobTitle = e.JobTitle) AS [Top Employee], 
d.Name AS [Department], e.JobTItle
FROM Employees e JOIN Departments d ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle

-- 27.	Write a SQL query to display the town where maximal number of employees work.
SELECT TOP(1) t.Name AS [Town with MAX EMployees], COUNT(*) AS [Number Of Employees] 
FROM Employees e 
JOIN Addresses s ON e.AddressID = s.AddressID
JOIN Towns t ON s.TownID = t.TownID
GROUP BY t.Name
ORDER BY [Number Of Employees] DESC

-- 28.	Write a SQL query to display the number of managers from each town.
	-- option 1
CREATE TABLE #temp
(
	Name nvarchar(100),
	Town nvarchar(50)
)

INSERT INTO #temp
SELECT DISTINCT m.FirstName + ' ' + m.LastName AS [Name], t.Name FROM Employees m 
JOIN Employees e ON m.EmployeeID = e.ManagerID 
JOIN Addresses a ON m.AddressID = a.AddressID
JOIN Towns t ON a.TownID = t.TownID

SELECT Town, COUNT(*) AS [Number Of Managers] FROM #temp GROUP BY Town
DROP TABLE #temp

	-- option 2 - Better
DECLARE @temp TABLE
(
	Name nvarchar(100),
	Town nvarchar(50)
)
INSERT INTO @temp
SELECT DISTINCT m.FirstName + ' ' + m.LastName AS 'Name', t.Name AS 'Town' FROM Employees m 
JOIN Employees e ON m.EmployeeID = e.ManagerID 
JOIN Addresses a ON m.AddressID = a.AddressID
JOIN Towns t ON a.TownID = t.TownID

SELECT Town, COUNT(*) AS [Number Of Managers] FROM @temp GROUP BY Town

-- 29.	Write a SQL to create table `WorkHours` to store work reports for each employee (employee id, date, task, hours, comments).
	-- *	Don't forget to define  identity, primary key and appropriate foreign key. 
	-- *	Issue few SQL statements to insert, update and delete of some data in the table.
	-- *	Define a table `WorkHoursLogs` to track all changes in the `WorkHours` table with triggers.
	-- *	For each change keep the old record data, the new record data and the command (insert / update / delete).
CREATE TABLE WorkHours
(
	EmployeeID int PRIMARY KEY,
	FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID),
	Date smalldatetime,
	Task nvarchar(255),
	Hours int,
	Comments nvarchar(255)
)

INSERT INTO WorkHours Values
(1, '2015-01-02', 'Do something', 15, 'Very bad idea'),
(2, '2007-02-12', 'Do this', 33, 'Start a database transaction!'),
(3, '2012-04-22', 'Write something', 2, 'For each change keep the old record data!'),
(4, '2011-11-04', 'No task', 543, 'Now how you could restore back the lost table data?'),
(5, '2016-02-08', 'Very hard task', 23, 'Delete all employees!')
GO

CREATE TABLE WorkHourLogs
(
	ChangeID int IDENTITY(1, 1) PRIMARY KEY,
	Name nvarchar(50),
	Type nvarchar(15),
	OldDate smalldatetime,
	OldTask nvarchar(255),
	OldHours int,
	OldComments nvarchar(255),
	NewDate smalldatetime,
	NewTask nvarchar(255),
	NewHours int,
	NewComments nvarchar(255),
)
GO

CREATE TRIGGER urt_WorkingHourLog ON WorkHours
FOR UPDATE
AS
BEGIN
	-- Variables
DECLARE @Type nvarchar(15),
		@Date smalldatetime,
		@Task nvarchar(255),
		@Hours int,
		@Comments nvarchar(255)

	-- Action
IF EXISTS (SELECT * FROM inserted)
       IF EXISTS (SELECT * FROM deleted)
               SELECT @Type = 'Update'
       ELSE
               SELECT @Type = 'Insert'
ELSE
       SELECT @Type = 'Delete'

	-- Select Data
SELECT * INTO #ins FROM deleted
SELECT * INTO #del FROM inserted

	-- Insert Data
INSERT INTO WorkHourLogs (Type) Values (@Type)

INSERT INTO WorkHourLogs (NewDate, NewTask, NewHours, NewComments)
SELECT Date, Task, Hours, Comments FROM #ins

INSERT INTO WorkHourLogs (OldDate, OldTask, OldHours, OldComments)
SELECT Date, Task, Hours, Comments FROM #del
END
GO

	-- Test it
UPDATE WorkHours SET Task = 'Changed your task' WHERE EmployeeID = 1
UPDATE WorkHours SET Comments = 'Start a database transaction and drop the table!' WHERE EmployeeID = 2
DELETE FROM WorkHours WHERE EmployeeID = 3

-- 30.	Start a database transaction, delete all employees from the '`Sales`' department along with all dependent records from the pother tables.
	-- *	At the end rollback the transaction.


-- 31.	Start a database transaction and drop the table `EmployeesProjects`.
	-- *	Now how you could restore back the lost table data?


-- 32.	Find how to use temporary tables in SQL Server.
	-- *	Using temporary tables backup all records from `EmployeesProjects` and restore them back after dropping and re-creating the table.

-- 06. Transact SQL - Homework
--1.	Create a database with two tables: `Persons(Id(PK), FirstName, LastName, SSN)` and `Accounts(Id(PK), PersonId(FK), Balance)`.
	--	Insert few records for testing.
	--	Write a stored procedure that selects the full names of all persons.
CREATE DATABASE MyBank
GO
USE MyBank
GO
CREATE TABLE Persons
(
	Id int IDENTITY PRIMARY KEY,
	FirstName nvarchar(50),
	LastName nvarchar(50),
	SSN nvarchar(15)
)
GO

CREATE TABLE Accounts
(
	Id int IDENTITY PRIMARY KEY,
	PersonID int FOREIGN KEY REFERENCES Persons(Id),
	Balance money
)
GO

INSERT INTO Persons Values
('Ivan', 'Ivanov', '8512319594'),
('Petar', 'Georgiev', '7602243345'),
('Georgi', 'Stoyanov', '4504234566'),
('Martin', 'Kulov', '8103032330'),
('George', 'Denchev', '6511234455'),
('Jose', 'Saraiva', '8709115698'),
('John', 'Smith', '9107124575'),
('Guy', 'Gilberts', '3901234566')
GO

INSERT INTO Accounts Values
(1, 345.78),
(2, 2000),
(2, 1000000),
(3, 123.56),
(4, 3443),
(5, 20000),
(5, 2322.34),
(6, 44.90),
(6, 0),
(6, 34500),
(7, 1.5),
(8, 12),
(8, 230.50),
(8, 333.33),
(8, 300000)
GO

CREATE PROC usp_SelectFullNames 
	@tableName nvarchar(50)
AS
	DECLARE @query varchar(100) = 'SELECT FirstName + '' '' + LastName AS [Full Name] FROM ' + @tableName
	EXEC(@query)
GO

EXEC usp_SelectFullNames 'Persons'

--2.	Create a stored procedure that accepts a number as a parameter and returns all persons who have more money in their accounts than the supplied number.
CREATE PROC usp_HaveMoreThan 
	@amount money
AS 
 SELECT p.FirstName, p.LastName, a.Balance
 FROM Persons p JOIN Accounts a ON p.Id = a.PersonID 
 WHERE Balance > @amount
GO
	
EXEC usp_HaveMoreThan 5000
GO 

--3.	Create a function that accepts as parameters – sum, yearly interest rate and number of months.
	--	It should calculate and return the new sum.
	--	Write a `SELECT` to test whether the function works as expected.
CREATE FUNCTION ufn_CalcInterest(@sum money = 100, @yearInterest numeric(4) = 5.0000, @months int = 1)
	RETURNS money
AS
BEGIN
	IF (@sum <= 0 OR @months <= 0 OR @yearInterest < 0) RETURN @sum
	ELSE RETURN @sum + @sum*(@yearInterest / 1200)*@months
	RETURN @sum
END
GO

DECLARE @int numeric(4) = 15
SELECT FirstName + ' ' + LastName AS [Client Name], a.Balance AS [Initial], 
dbo.ufn_CalcInterest(a.Balance, @int, 1) AS [1 Mon], 
dbo.ufn_CalcInterest(a.Balance, @int, 2) AS [2 Mon], 
dbo.ufn_CalcInterest(a.Balance, @int, 3) AS [3 Mon], 
dbo.ufn_CalcInterest(a.Balance, @int, 4) AS [4 Mon], 
dbo.ufn_CalcInterest(a.Balance, @int, 5) AS [5 Mon], 
dbo.ufn_CalcInterest(a.Balance, @int, 7) AS [7 Mon], 
dbo.ufn_CalcInterest(a.Balance, @int, 8) AS [8 Mon], 
dbo.ufn_CalcInterest(a.Balance, @int, 6) AS [6 Mon], 
dbo.ufn_CalcInterest(a.Balance, @int, 9) AS [9 Mon], 
dbo.ufn_CalcInterest(a.Balance, @int, 10) AS [10 Mon], 
dbo.ufn_CalcInterest(a.Balance, @int, 11) AS [11 Mon], 
dbo.ufn_CalcInterest(a.Balance, @int, 12) AS [12 Mon]
FROM Accounts a JOIN Persons p ON p.Id = a.PersonID
GO

--4.	Create a stored procedure that uses the function from the previous example to give an interest to a person's account for one month.
	--	It should take the `AccountId` and the interest rate as parameters.
ALTER PROC usp_MonthInterest
	@id int,
	@int numeric(4)
AS
	SELECT p.FirstName, p.LastName, a.Balance AS [Initial Money], dbo.ufn_CalcInterest(a.Balance, @int, 1) AS [Money After 1 Month]
	FROM Persons p JOIN Accounts a ON p.Id = a.PersonID WHERE a.Id = @id
GO

EXEC usp_MonthInterest 5, 3.56
GO

--5.	Add two more stored procedures `WithdrawMoney(AccountId, money)` and `DepositMoney(AccountId, money)` that operate in transactions.
ALTER PROC [dbo].[usp_WithdrawMoney]
	@id int,
	@money money
AS
	BEGIN TRAN [withdraw]

BEGIN TRY

	DECLARE @result money = (SELECT Balance FROM Accounts WHERE Id = @id) - @money 
	IF @result < 0 ROLLBACK
	ELSE
	UPDATE Accounts SET Balance = @result WHERE Id = @id
	COMMIT TRANSACTION [withdraw]

END TRY
BEGIN CATCH
  ROLLBACK TRANSACTION [withdraw]
END CATCH  
GO

------------
ALTER PROC [dbo].[usp_DepositMoney]
	@id int,
	@money money
AS
	BEGIN TRAN [deposit]

	BEGIN TRY

	UPDATE Accounts SET Balance = Balance + @money WHERE Id = @id
	COMMIT TRANSACTION [deposit]

END TRY
BEGIN CATCH
  ROLLBACK TRANSACTION [deposit]
END CATCH  
GO
------------

EXEC usp_WithdrawMoney 1, 100
EXEC usp_DepositMoney 9, 9999.99
EXEC usp_WithdrawMoney 1, 500

DBCC opentran()
exec sp_who2 53
exec sp_lock 53
KILL 53

--6.	Create another table – `Logs(LogID, AccountID, OldSum, NewSum)`.
	--	Add a trigger to the `Accounts` table that enters a new entry into the `Logs` table every time the sum on an account changes.
CREATE TABLE Logs
(
	Id int IDENTITY PRIMARY KEY,
	AccountId int FOREIGN KEY REFERENCES Accounts(Id),
	OldSum money,
	NewSum money
)
GO

ALTER TRIGGER utr_LogActivity ON Accounts
FOR UPDATE
AS
BEGIN
	DECLARE @oldSum money,
	@newSum money
	
SELECT Id, Balance AS OldSum INTO #del FROM deleted
SELECT Id, Balance AS NewSum INTO #ins FROM inserted

INSERT INTO Logs (AccountId, OldSum, NewSum) 
SELECT d.Id, d.OldSum, i.NewSum FROM #del d JOIN #ins i ON d.Id = i.Id 
END
GO

TRUNCATE TABLE Logs

EXEC usp_DepositMoney 9, 1111.11
EXEC usp_WithdrawMoney 15, 9999.99
SELECT * FROM Logs

--7.	Define a function in the database `TelerikAcademy` that returns all Employee's names (first or middle or last name) and all town's names that are comprised of given set of letters.
	--	_Example_: '`oistmiahf`' will return '`Sofia`', '`Smith`', … but not '`Rob`' and '`Guy`'.


--8.	Using database cursor write a T-SQL script that scans all employees and their addresses and prints all pairs of employees that live in the same town.


--9.	Write a T-SQL script that shows for each town a list of all employees that live in it.
	--	_Sample output_:	
		-- Sofia -> Martin Kulov, George Denchev
		-- Ottawa -> Jose Saraiva


--10.	Define a .NET aggregate function `StrConcat` that takes as input a sequence of strings and return a single string that consists of the input strings separated by '`,`'.
	--	For example the following SQL statement should return a single string:
		-- SELECT StrConcat(FirstName + ' ' + LastName)
		-- FROM Employees

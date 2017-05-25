## SQL Server Management Studio
#### Connect to DB
ways to connect to DB - computername, localhost, or .  
`TEST-PC\SQLEXPRESS`   
`localhost\sqlexpress`  
`.\sqlexpress`  
new user  
`Security` -> `New Login`

#### Create DB
options -> allow save chages

#### Create Table
id - add primary key, Identification -> yes  
data type - int, nvarCar(50)

#### DataBase diagrams 
drag key from many to single (workers -> departments)

#### New Query to write and then Execute
only selected is executed  
get the database to use  
work with DataBase   
```sql
USE A1Work
SELECT Workers.FirstName FROM dbo.A1Work
```

#### Stored Procedures
Programability -> Stored Procedures  
EXECUTE stored procedure name  
Create Stored Procedure to use later  

#### Views
create view (predefined query)   
```sql
CREATE VIEW fnames AS
/* query text */
```
- change view   
```sql
ALTER VIEW fnames AS
/* query text */
```

#### Triggers
this will create a trigger to write something in the Logs table   
```sql
CREATE TRIGGER UpdateDate
ON Workers
AFTER INSERT
AS
BEGIN
    INSERT INTO Logs VALUES('date to insert')
END
```
gain access to **inserted**, **updated**, **deleted** tables

#### Transactions
sequence of DataBase operations which are executed as a single unit  
if operations fail nothing is written in the DataBase  

## Setup DataBase

#### Types in SQL
**numbers:**  
- bit*, int, bigint
- float, real, numeric(scale, precision)
- money

**strings:** 
- char(size) - fixed size
- varchar(size) - max size
- nvarchar(size) - unicode varchar
- text / ntext - text data block

**binary:**
- varbinary(size)
- image - up to 1 GB

**Date and Time:**  
- datetime - 1/300 sec precision
- smalldatetime - 1-minute precision

**Other:**  
- timestamp - generate unique number
- uniqueidentifier - GUID identifier
- xml - data in xml format

##### Nullable
set in table design

##### Primary keys
always use **ID**

##### Identity
automatically increased - **int**

#### One to One connection
join 2 primary keys

#### One to Many connection
join 1 primary to 1 foreign key

#### Many to Many connection
create intermediate table with 2 primary keys

## SQL Language

#### search
```sql
/* simple select */
SELECT FirstName, LastName, JobTitle FROM Employees
/* name new column */
SELECT FirstName, 0.1*Salary AS [Bonus] FROM Employees
/* join column names */
SELECT FirstName + ' ' + LastName AS [Full Name], Id AS [No.] FROM Employees
/* all in one column */
SELECT FirstName AS [Name] FROM Employees UNION SELECT LastName AS [Name] FROM Employees
INTERSECT, EXCEPT /* other ways to union */
/* add condition, always with update and delete */
SELECT * FROM Projects WHERE StartDate = '1/1/2006' 
/* between, we have NOT, AND, OR */
SELECT LastName, Salary FROM Employees WHERE Salary BETWEEN 1000 AND 2000 
/* filter by ManagerId */
SELECT FirstName, LastName FROM Employees WHERE ManagerID IN (10, 22, 23) 
/* specify pattern %-0 or more chars, _ means one char */
SELECT FirstName FROM Employees WHERE FirstName LIKE 'S%' 
/* way to check null */
SELECT FirstName FROM Employees WHERE ManagerId IS NOT NULL  
/* more complex where filter */
SELECT LastName FROM Employees WHERE NOT (ManagerId = 3 OR ManagerId = 4) AND (Salary >= 1000) 
/* distinct values */
SELECT DISTINCT column1, column2 FROM table_name 
/* selecs only 10  */
SELECT TOP(10) 
/* nested select, can include WHERE too */
SELECT FirstName, LastName, Salary FROM Employees WHERE Salary = (SELECT MAX(Salary) FROM Employees) 
/* compare first select with nested one */
SELECT FirstName, Salary FROM Employees e WHERE Salary = (SELECT MAX(Salary) FROM Employees WHERE DepartmentID = e.DepartmentID) ORDER BY DepartmentID
/* */
```

#### join
```sql
SELECT e.Id, e.LastName, e.DepartmentId, d.Id, d.Name AS DeptName FROM Employees e INNER JOIN Departments d ON e.DepartmentId = d.Id  /* default is INNER */

SELECT e.LastName, m.LastName FROM Employees e JOIN Employees m ON e.ManagerId = m.Id /* join a table with itself */

LEFT OUTER JOIN /* gets from the left table all and matching from the right */
RIGHT OUTER JOIN /* same but opposite tables */
FULL OUTER JOIN /* joins all data */
CROSS JOIN /* every with every */
```

#### order
```sql
/* SELECT ... FROM ... WHERE */
ORDER BY Salary DESC /* default is ASC */

ORDER BY Salary, LastName /* by 2 criterias */
```

#### insert
```sql
INSERT INTO Projects(Name, StartDate) VALUES('Introduction to SQL', '1/1/2016') /* ako podredbata ne e dadena se podrejdat pored */

INSERT INTO Projects(Name, StartDate) SELECT Name + ' Destructuring', GETDATE() FROM Employees /* select something and insert */
```

#### update
```sql
UPDATE Projects SET EndDate = '8/31/2016' WHERE StartDate = '1/1/2016' /* dont forget WHERE */
```

#### delete
```sql
DELETE FROM Projects WHERE StartDate = '1/1/2016'

TRUNCATE TABLE Users /* delete all data */
```
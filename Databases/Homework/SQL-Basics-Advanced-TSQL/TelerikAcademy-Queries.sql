-- HOMEWORK - Intro to SQL --

-- 1. What is SQL? What is DML? What is DDL? Recite the most important SQL commands.

-- 2. What is Transact-SQL (T-SQL)?

-- 3. Start SQL Management Studio and connect to the database TelerikAcademy. Examine the major tables in the "TelerikAcademy" database.

-- 4. Write a SQL query to find all information about all departments (use "TelerikAcademy" database).
SELECT * FROM Departments

-- 5. Write a SQL query to find all department names.
SELECT Name FROM Departments

-- 6. Write a SQL query to find the salary of each employee.
SELECT FirstName + ' ' + LastName as [Full Name], Salary FROM Employees

-- 7. Write a SQL to find the full name of each employee.
SELECT FirstName + ' ' + LastName as [Full Name] FROM Employees

-- 8. Write a SQL query to find the email addresses of each employee (by his first and last name). Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". The produced column should be named "Full Email Addresses".
SELECT FirstName + '.' + LastName + '@telerik.com' AS [Email] FROM Employees

-- 9. Write a SQL query to find all different employee salaries.
SELECT DISTINCT Salary FROM Employees

-- 10. Write a SQL query to find all information about the employees whose job title is “Sales Representative“.
SELECT * FROM Employees WHERE JobTitle = 'Sales Representative'

-- 11. Write a SQL query to find the names of all employees whose first name starts with "SA".
SELECT FirstName, LastName FROM Employees WHERE FirstName LIKE 'Sa%'

-- 12. Write a SQL query to find the names of all employees whose last name contains "ei".
SELECT FirstName, LastName FROM Employees WHERE LastName LIKE '%ei%'

-- 13. Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].
SELECT FirstName, LastName, Salary FROM Employees WHERE Salary BETWEEN 20000 AND 30000 ORDER BY Salary

-- 14. Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
SELECT FirstName, LastName, Salary FROM Employees WHERE Salary=25000 OR Salary=14000 OR Salary=12500 OR Salary=23600 ORDER BY Salary

-- 15. Write a SQL query to find all employees that do not have manager.
SELECT FirstName, LastName, CASE WHEN ManagerId IS NULL THEN 'NO' ELSE 'YES' END AS [Has Manager] FROM Employees WHERE ManagerID IS NULL

-- 16. Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.
SELECT FirstName, LastName, Salary FROM Employees WHERE Salary > 50000 ORDER BY Salary DESC

-- 17. Write a SQL query to find the top 5 best paid employees.
SELECT TOP(5) FirstName, LastName, Salary FROM Employees ORDER BY Salary DESC


-- 18. Write a SQL query to find all employees along with their address. Use inner join with ON clause.
SELECT e.FirstName, e.LastName, a.AddressText + ', ' + t.Name AS [Address]
FROM Employees e 
JOIN Addresses a ON e.AddressID = a.AddressID 
JOIN Towns t ON a.TownID = t.TownID

-- 19. Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).
SELECT e.FirstName, e.LastName, a.AddressText AS [Address], t.Name AS [Town]
FROM Employees e, Addresses a, Towns t
WHERE e.AddressID = a.AddressID AND a.TownID = t.TownID

-- 20. Write a SQL query to find all employees along with their manager.
SELECT e.FirstName + ' ' + e.LastName AS [Full Name], m.FirstName + ' ' + m.LastName AS [Manager] 
FROM Employees e JOIN Employees m ON e.ManagerID = m.EmployeeID

-- 21. Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: Employees e, Employees m and Addresses a.
SELECT e.FirstName + ' ' + e.LastName AS [Full Name], m.FirstName + ' ' + m.LastName AS [Manager], a.AddressText AS [Address]
FROM Employees e 
JOIN Employees m ON e.ManagerID = m.EmployeeID
JOIN Addresses a ON e.AddressID = a.AddressID

-- 22. Write a SQL query to find all departments and all town names as a single list. Use UNION.
SELECT Name FROM Departments UNION
SELECT Name FROM Towns

-- 23. Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. Use right outer join. Rewrite the query to use left outer join.
SELECT e.FirstName + ' ' + e.LastName AS [Full Name], m.FirstName + ' ' + m.LastName AS [Manager] 
FROM Employees m 
RIGHT OUTER JOIN Employees e ON e.ManagerID = m.EmployeeID

SELECT e.FirstName + ' ' + e.LastName AS [Full Name], m.FirstName + ' ' + m.LastName AS [Manager] 
FROM Employees e 
LEFT OUTER JOIN Employees m ON e.ManagerID = m.EmployeeID

-- 24. Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.
SELECT e.FirstName, e.LastName, YEAR(e.HireDate) AS [Year Hired], d.Name AS [Department] FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE (d.Name = 'Sales' OR d.Name = 'Finance') AND (YEAR(e.HireDate) BETWEEN 1995 AND 2005)
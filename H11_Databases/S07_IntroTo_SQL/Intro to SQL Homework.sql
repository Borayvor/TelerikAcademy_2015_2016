--1. SQL или Език за структурирани запитвания (на английски: Structured Query Language, SQL) е
-- популярен език за програмиране, предназначен за създаване, видоизменяне, извличане и обработване
-- на данни от релационни системи за управление на бази данни. Стандартизиран е от ANSI / ISO.

--2. T-SQL (Transact SQL) е разширение на стандартния SQL език.
-- T-SQL е стандартният език, използван в MS SQL Server.
-- Поддържа if-else операции, цикли, изключения. Конструкции, използвани в процедурните езици за
-- програмиране от високо ниво.
-- T-SQL се използва за писане на съхранени процедури, функции, тригери, и т.н.

--4. Write a SQL query to find all information about all departments (use "TelerikAcademy" database).
SELECT *
FROM [TelerikAcademy].[dbo].[Departments]
GO

--5. Write a SQL query to find all department names.
SELECT Name
FROM [TelerikAcademy].[dbo].[Departments]
GO

--6. Write a SQL query to find the salary of each employee.
SELECT Salary
FROM [TelerikAcademy].[dbo].[Employees]
GO

--7. Write a SQL to find the full name of each employee.
SELECT FirstName + ' ' + LastName AS [Full Name]
FROM [TelerikAcademy].[dbo].[Employees]
GO

--8. Write a SQL query to find the email addresses of each employee (by his first and last name). 
-- Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com".
-- The produced column should be named "Full Email Addresses".
SELECT FirstName + '.' + LastName + '@telerik.com' AS [Full Email Addresses]
FROM [TelerikAcademy].[dbo].[Employees]
GO

--9. Write a SQL query to find all different employee salaries.
SELECT DISTINCT Salary
FROM [TelerikAcademy].[dbo].[Employees]
GO

--10. Write a SQL query to find all information about the employees whose job title is “Sales Representative“.
SELECT *
FROM [TelerikAcademy].[dbo].[Employees]
WHERE JobTitle = 'Sales Representative'
GO

--11. Write a SQL query to find the names of all employees whose first name starts with "SA".
SELECT *
FROM [TelerikAcademy].[dbo].[Employees]
WHERE FirstName LIKE 'SA%'
GO

--12. Write a SQL query to find the names of all employees whose last name contains "ei".
SELECT *
FROM [TelerikAcademy].[dbo].[Employees]
WHERE LastName LIKE '%ei%'
GO

--13. Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].
SELECT *
FROM [TelerikAcademy].[dbo].[Employees]
WHERE Salary BETWEEN 20000 AND 30000
GO

--14. Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
SELECT *
FROM [TelerikAcademy].[dbo].[Employees]
WHERE Salary IN (25000, 14000, 12500, 23600)
GO

--15. Write a SQL query to find all employees that do not have manager.
SELECT *
FROM [TelerikAcademy].[dbo].[Employees]
WHERE ManagerID IS NULL
GO

--16. Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing 
-- order by salary.
SELECT *
FROM [TelerikAcademy].[dbo].[Employees]
WHERE Salary > 50000
ORDER BY Salary DESC
GO

--17. Write a SQL query to find the top 5 best paid employees.
SELECT TOP 5 FirstName, LastName, Salary
FROM [TelerikAcademy].[dbo].[Employees]
ORDER BY Salary DESC
GO

--18. Write a SQL query to find all employees along with their address. Use inner join with ON clause.
SELECT e.FirstName, e.LastName, e.AddressID, d.AddressID, d.AddressText
FROM [TelerikAcademy].[dbo].[Employees] e
INNER JOIN [TelerikAcademy].[dbo].[Addresses] d
	ON e.AddressID = d.AddressID
GO

--19. Write a SQL query to find all employees and their address. Use equijoins (conditions in the
-- WHERE clause).
SELECT e.FirstName, e.LastName, d.AddressText
FROM [TelerikAcademy].[dbo].[Employees] e, [TelerikAcademy].[dbo].[Addresses] d
WHERE e.AddressID = d.AddressID
GO

--20. Write a SQL query to find all employees along with their manager.
SELECT e.FirstName + ' ' + e.LastName + ' is managed by ' + m.FirstName + ' ' + m.LastName AS Message
FROM [TelerikAcademy].[dbo].[Employees] e 
JOIN [TelerikAcademy].[dbo].[Employees] m
	ON e.ManagerID = m.EmployeeID
GO

--21. Write a SQL query to find all employees, along with their manager and their address. Join the
-- 3 tables: Employees e, Employees m and Addresses a.
SELECT e.FirstName + ' ' + e.LastName AS [Employee Full Name],
	   a.AddressText AS [Employee Address],
       m.FirstName + ' ' + m.LastName AS [Manager Full Name]
FROM [TelerikAcademy].[dbo].[Employees] e 
JOIN [TelerikAcademy].[dbo].[Employees] m 
	ON e.ManagerID = m.EmployeeID
JOIN [TelerikAcademy].[dbo].[Addresses] a
	ON e.AddressID = a.AddressID
GO

--22. Write a SQL query to find all departments and all town names as a single list. Use UNION.
SELECT Name AS [Departments and Towns]
FROM [TelerikAcademy].[dbo].[Departments]
UNION
SELECT Name AS [Departments and Towns]
FROM [TelerikAcademy].[dbo].[Towns]
GO

--23. Write a SQL query to find all the employees and the manager for each of them along with
-- the employees that do not have manager. Use right outer join. Rewrite the query to use left outer join.
SELECT e.FirstName + ' ' + e.LastName + ' is managed by ' + m.FirstName + ' ' + m.LastName AS Message
FROM [TelerikAcademy].[dbo].[Employees] e 
RIGHT OUTER JOIN [TelerikAcademy].[dbo].[Employees] m 
	ON e.ManagerID = m.EmployeeID

SELECT e.FirstName + ' ' + e.LastName + ' is managed by ' + m.FirstName + ' ' + m.LastName AS Message
FROM [TelerikAcademy].[dbo].[Employees] e 
LEFT OUTER JOIN [TelerikAcademy].[dbo].[Employees] m
	ON e.ManagerID = m.EmployeeID
GO

--24. Write a SQL query to find the names of all employees from the departments "Sales" and "Finance"
-- whose hire year is between 1995 and 2005.
SELECT e.FirstName + ' ' + e.LastName AS [Employee Full Name],
       e.HireDate,
	   d.Name
FROM [TelerikAcademy].[dbo].[Employees] e
JOIN [TelerikAcademy].[dbo].[Departments] d
	ON e.DepartmentID = d.DepartmentID
WHERE (d.Name = 'Sales' OR d.Name = 'Finance') AND
	  (e.HireDate BETWEEN '1995-01-01 00:00:00' AND '2005-01-01 00:00:00')
GO

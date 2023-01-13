CREATE DATABASE OLExercises;
USE OLExercises

---------------Customers SQL----------------------
CREATE TABLE Customers(
Id int IDENTITY(1, 1) PRIMARY KEY,
Name nvarchar(50),  
City nvarchar(50),
Country nvarchar(50)
);

INSERT INTO Customers(
	Name,
	City,
	Country
)
Values
(
	'Alice',
	'London',
	'UK'
),
(
	'Bob',
	'New York',
	'USA'
),
(
	'Eve',
	'Paris',
	'France'
),
(
	'Frank',
	'Berlin',
	'Germany'
),
(
	'Grace',
	'Mubai',
	'India'
);

SELECT NAME FROM Customers
WHERE City = 'London' OR City = 'Paris'

----------------Orders SQL-------------------------
CREATE TABLE orders (
    Id INT PRIMARY KEY,
    CustomerId INT,
    ProductName VARCHAR(255),
    Quantity INT,
    FOREIGN KEY (CustomerId) REFERENCES customers(Id)
);

INSERT INTO orders (Id, CustomerId, ProductName, Quantity)
VALUES (1, 1, 'Phone', 2),
       (2, 1, 'Tablet', 1),
       (3, 2, 'Laptop', 3),
       (4, 3, 'Smartwatch', 1),
       (5, 4, 'Headphones', 2),
       (6, 5, 'Speaker', 1);

SELECT c.Name, SUM(o.Quantity) as TotalProducts
FROM orders o
JOIN customers c ON o.CustomerId = c.Id
GROUP BY c.Name;

----------Employees SQL-----------------------------
CREATE TABLE employees (
    Id INT PRIMARY KEY,
    Name VARCHAR(255),
    Salary INT,
    Department VARCHAR(255)
);

INSERT INTO employees (Id, Name, Salary, Department)
VALUES (1, 'John', 1000, 'Sales'),
       (2, 'Jane', 1200, 'Marketing'),
       (3, 'Bill', 1500, 'Engineering'),
       (4, 'Rachel', 1200, 'Marketing'),
       (5, 'Steve', 1000, 'Sales');

SELECT Department, AVG(Salary) as AverageSalary
FROM employees
GROUP BY Department
ORDER BY AVG(Salary) DESC;


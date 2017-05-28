-- 1. Create Cities
CREATE TABLE Cities
(
	CityID INT IDENTITY PRIMARY KEY,
	Name varchar(15)
)

-- 2. Insert Cities
INSERT INTO Cities
SELECT DISTINCT e.City FROM (
	SELECT DISTINCT City FROM Employees
		UNION
	SELECT DISTINCT City FROM Suppliers
		UNION
	SELECT DISTINCT City FROM Customers
) e

-- 3. Add CityId
ALTER TABLE Employees
ADD CityID int 
FOREIGN KEY (CityID) REFERENCES Cities(CityID)

ALTER TABLE Suppliers
ADD CityID int 
FOREIGN KEY (CityID) REFERENCES Cities(CityID)

ALTER TABLE Customers
ADD CityID int 
FOREIGN KEY (CityID) REFERENCES Cities(CityID)

-- 4. Update CityID
UPDATE Employees SET CityID = (
SELECT CityID FROM Cities 
WHERE Cities.Name = Employees.City
)

UPDATE Customers SET CityID = (
SELECT CityID FROM Cities 
WHERE Cities.Name = Customers.City
)

UPDATE Suppliers SET CityID = (
SELECT CityID FROM Cities 
WHERE Cities.Name = Suppliers.City
)

-- 5. Cities Name - Unique
CREATE UNIQUE INDEX UK_Unique_Name
ON Cities (Name)

-- 6. ShipCity
INSERT INTO Cities
SELECT DISTINCT ShipCity FROM Orders
WHERE ShipCity NOT IN (SELECT Name FROM Cities)

-- 7. Add Foreign Key
ALTER TABLE Orders 
ADD CityID int
FOREIGN KEY (CityID) REFERENCES Cities(CityID)

-- 8. Rename
USE Northwind
GO
EXEC sys.sp_rename 'Orders.CityID', 'ShipCityId'
GO

-- 9. Update ShipCityId
UPDATE Orders SET ShipCityId = (
SELECT CityID FROM Cities 
WHERE Cities.Name = Orders.ShipCity
)
GO

-- 10. Drop ShipCity
ALTER TABLE Orders
DROP COLUMN ShipCity

-- 11. Create Countries
CREATE TABLE Countries
(
	CountryID INT IDENTITY PRIMARY KEY,
	Name varchar(15) UNIQUE,
)

-- 12. Add Foreign Key to Cities
ALTER TABLE Cities
ADD CountryID int 
FOREIGN KEY (CountryID) REFERENCES Countries(CountryID)

-- 13. Insert All Countries
INSERT INTO Countries
SELECT DISTINCT e.Country FROM (
	SELECT DISTINCT Country FROM Employees
		UNION
	SELECT DISTINCT Country FROM Suppliers
		UNION
	SELECT DISTINCT Country FROM Customers
			UNION
	SELECT DISTINCT o.ShipCountry FROM Orders o
) e

-- 14. Update Country ID
UPDATE Cities
SET Cities.CountryID = CitiesInCountries.CountryID
FROM (
		(SELECT DISTINCT UnionCountries.CityId,
						 UnionCountries.Country,
						 Countries.CountryID 
		FROM 
			(SELECT Country, CityId 
				FROM Employees 
				WHERE CityId IS NOT NULL 
			UNION 
			SELECT Country, CityId 
				FROM Suppliers 
				WHERE CityId IS NOT NULL 
			UNION 
			SELECT Country, CityId 
				FROM Customers 
				WHERE CityId IS NOT NULL 
			UNION 
			SELECT ShipCountry, ShipCityId 
				FROM Orders 
				WHERE ShipCityId IS NOT NULL) UnionCountries 
		JOIN Countries ON
			Countries.Name = UnionCountries.Country)
		) CitiesInCountries
WHERE 
    Cities.CityID = CitiesInCountries.CityID
GO
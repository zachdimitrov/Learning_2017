-- INSERT DATABASE --
CREATE DATABASE Community
GO
USE Community
GO
CREATE TABLE Continents
(
	Id int IDENTITY PRIMARY KEY,
	Name varchar(15) UNIQUE
)
GO
CREATE TABLE Countries
(
	Id int IDENTITY PRIMARY KEY,
	Name varchar(15) UNIQUE,
	ContinentId int FOREIGN KEY (ContinentId) REFERENCES Continents (Id)
)
GO
CREATE TABLE Towns
(
	Id int IDENTITY PRIMARY KEY,
	Name varchar(15) UNIQUE,
	CountryId int FOREIGN KEY (CountryId) REFERENCES Countries (Id)
)
GO
CREATE TABLE Addresses
(
	Id int IDENTITY PRIMARY KEY,
	Name varchar(15) UNIQUE,
	TownId int FOREIGN KEY (TownId) REFERENCES Towns (Id)
)
GO
CREATE TABLE Persons
(
	Id int IDENTITY PRIMARY KEY,
	FirstName varchar(50) NOT NULL,
	MiddleName varchar(50),
	LastName varchar(50) NOT NULL,
	AddressId int FOREIGN KEY (AddressId) REFERENCES Addresses (Id)
)
GO
-- INSERT DATA --
INSERT INTO Continents Values
('Europe'),
('Asia'),
('Africa'),
('North America'),
('South America'),
('Australia')
GO

INSERT INTO Countries Values
('Bulgaria', '1'),
('France', '1'),
('Germany', '1'),
('China', '2'),
('India', '2'),
('Ghana', '3'),
('Mozambic', '3'),
('USA', '4'),
('Mexico', '4'),
('Argentina', '5'),
('Brasil', '5'),
('Australia', '6')
GO

INSERT INTO Towns Values
('Sofia','1'),
('Plovdiv','1'),
('Burgas','1'),
('Varna','1'),
('Paris','2'),
('Lyon','2'),
('Berlin','3'),
('Hanover','3'),
('Beijing','4'),
('Hong Kong','4'),
('Delhi','5'),
('Accra','6'),
('Maputo','7'),
('New York','8'),
('Washington D.C.','8'),
('Mexico','9'),
('Chihuahua','9'),
('Buenos Aires', '10'),
('Brazilia', '11'),
('Rio De Janeiro', '11'),
('Melbourne','12'),
('Cidney','12'),
('Canbera','12')
GO

--ABS(Checksum(NewID()) % 12) + 1
 
INSERT INTO Addresses (Address, TownId)
SELECT TOP (50) Address, CAST(CAST ((ABS(Checksum(NewID()) % 12) + 1) AS NUMERIC(19,4)) AS INT) 
FROM SampleData

INSERT INTO Persons (FirstName, MiddleName, LastName, AddressId)
SELECT TOP (50) FirstName, State, LastName, CAST(CAST ((ABS(Checksum(NewID()) %50) + 1) AS NUMERIC(19,4)) AS INT) 
FROM SampleData
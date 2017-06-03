-- 1. List all superheroes in Earth
SELECT s.Id,  s.Name 
FROM Superheroes s
JOIN PlanetSuperheroes ps ON s.Id = ps.Superhero_Id
JOIN Planets p ON ps.Planet_Id = p.Id 
WHERE p.Name = 'Earth'
GO

--------------------------------------------------------------------------------------------
-- 2. List all superheroes with their powers and powerTypes
SELECT s.Name AS [Superhero], p.Name + ' (' + t.Name + ')' AS [Power]
FROM Superheroes s 
JOIN PowerSuperheroes ps ON s.Id = ps.Superhero_Id
JOIN Powers p ON ps.Power_Id = p.Id
JOIN PowerTypes t ON p.PowerTypeId = t.Id
GO

--------------------------------------------------------------------------------------------
--3. List the top 5 planets, sorted by count of superheroes with alignment 'Good', then by Planet Name
SELECT TOP(5) p.Name AS [Planet], COUNT(a.Id) AS [Protectors]
FROM Superheroes s 
LEFT OUTER JOIN Alignments a ON s.Alignment_Id = a.Id
LEFT OUTER JOIN PlanetSuperheroes ps ON s.Id = ps.Superhero_Id
LEFT OUTER JOIN Planets p ON ps.Planet_Id = p.Id 
GROUP BY p.Name, a.Name
HAVING a.Name = 'Good'
ORDER BY Protectors DESC, p.Name
GO

--------------------------------------------------------------------------------------------
--4. Create a stored procedure to edit superheroes Bio, by provided Superhero's Id and the new bio
	--Name it usp_UpdateSuperheroBio
CREATE PROC usp_UpdateSuperheroBio
	@superheroId int, 
	@newBio ntext
AS
BEGIN
	UPDATE Superheroes SET Bio = @newBio
	WHERE Id = @superheroId;
END
GO

-- test the above
SELECT Id, Bio FROM Superheroes WHERE Id = 1
EXEC usp_UpdateSuperheroBio 1, 'New bio!'
SELECT Id, Bio FROM Superheroes WHERE Id = 1
GO

--------------------------------------------------------------------------------------------
--5. Create a stored prodecure, that gives full information about a superhero, by provided Superhero's Id
	--Name it usp_GetSuperheroInfo
CREATE PROC usp_GetSuperheroInfo
	@superheroId int
AS
BEGIN
	SELECT 
	s.Id, 
	s.Name, 
	s.SecretIdentity AS [Secret Identity],
	s.Bio,
	a.Name AS [Alignment],
	pl.Name AS [Planet],	
	po.Name AS [Power]
	FROM Superheroes s
	JOIN Alignments a ON s.Alignment_Id = a.Id
	JOIN PlanetSuperheroes pls ON s.Id = pls.Superhero_Id
	JOIN Planets pl ON pls.Planet_Id = pl.Id 
	JOIN PowerSuperheroes pos ON s.Id = pos.Superhero_Id
	JOIN Powers po ON pos.Power_Id = po.Id
	JOIN PowerTypes t ON po.PowerTypeId = t.Id
	WHERE s.Id = @superheroId
END
GO

	--test the above
EXEC usp_GetSuperheroInfo 3
GO

--------------------------------------------------------------------------------------------
--6. Create a stored procedure that prints the number of heroes with Good, Evil and Neutral alignment for each Planet
	--Name it usp_GetPlanetsWithHeroesCount

CREATE PROC usp_GetPlanetsWithHeroesCount
AS
BEGIN
	CREATE TABLE Neutrals(PlanetId int FOREIGN KEY REFERENCES Planets(Id), Name nvarchar(50), [Neutral heroes] int);
	INSERT INTO Neutrals
	SELECT p.Id, p.Name, COUNT(*) FROM Superheroes s
	JOIN Alignments a ON s.Alignment_Id = a.Id
	JOIN PlanetSuperheroes ps ON s.Id = ps.Superhero_Id
	JOIN Planets p ON ps.Planet_Id = p.Id 
	WHERE a.Name = 'Neutral'
	GROUP BY p.Name, p.Id
	
	CREATE TABLE Evils(PlanetId int FOREIGN KEY REFERENCES Planets(Id), Name nvarchar(50), [Evil Heroes] int);
	INSERT INTO Evils
	SELECT  p.Id, p.Name, COUNT(*) FROM Superheroes s
	JOIN Alignments a ON s.Alignment_Id = a.Id
	JOIN PlanetSuperheroes ps ON s.Id = ps.Superhero_Id
	JOIN Planets p ON ps.Planet_Id = p.Id 
	WHERE a.Name = 'Evil'
	GROUP BY p.Name, p.Id

	CREATE TABLE Goods(PlanetId int FOREIGN KEY REFERENCES Planets(Id), Name nvarchar(50), [Good Heroes] int);
	INSERT INTO Goods
	SELECT  p.Id, p.Name, COUNT(*) FROM Superheroes s
	JOIN Alignments a ON s.Alignment_Id = a.Id
	JOIN PlanetSuperheroes ps ON s.Id = ps.Superhero_Id
	JOIN Planets p ON ps.Planet_Id = p.Id 
	WHERE a.Name = 'Good'
	GROUP BY p.Name, p.Id

	CREATE TABLE PlanetAlignments (Planet nvarchar(50), [Good Heroes] int, [Neutral heroes] int, [Evil Heroes] int)

	INSERT INTO PlanetAlignments
	SELECT p.Name, 
	g.[Good heroes], 
	n.[Neutral heroes], 
	e.[Evil heroes]
	FROM Planets p 
	LEFT JOIN Goods g ON p.Id = g.PlanetId
	LEFT JOIN Neutrals n ON p.Id = n.PlanetId
	LEFT JOIN Evils e ON p.Id = e.PlanetId

	UPDATE PlanetAlignments SET [Good Heroes] = 0 WHERE [Good Heroes] is NULL
	UPDATE PlanetAlignments SET [Evil Heroes] = 0 WHERE [Evil Heroes] is NULL
	UPDATE PlanetAlignments SET [Neutral Heroes] = 0 WHERE [Neutral Heroes] is NULL

	SELECT * FROM PlanetAlignments

	DROP TABLE Evils
	DROP TABLE Neutrals
	DROP TABLE Goods
	DROP TABLE PlanetAlignments
END
GO

 --test the above
EXEC usp_GetPlanetsWithHeroesCount
GO

---------------------------------------------------------------------------------
--7. Create a stored procedure for creating a Superhero, with provided name, secret identity, bio, alignment, a planet and 3 powers (with their types)
 --Powers, power types, planet and alignement should be reused, if they are already in the database

CREATE PROC usp_CreateSuperhero
	@name nvarchar(40),
	@secretIdentity nvarchar(40),
	@bio ntext,
	@alignment nvarchar(40),
		@alignmentId int,
	@planet nvarchar(40),
		@planetId int,
	@power1 nvarchar(40),
		@power1Id int,
	@power1type int,
	@power2 nvarchar(40),
		@power2Id int,
	@power2type int,
	@power3 nvarchar(40),
		@power3Id int,
	@power3type int
AS
BEGIN

IF (SELECT Id FROM Alignments WHERE NAME = @alignment) IS NULL 
INSERT INTO Alignments VALUES (@alignment)
SET @alignmentId = (SELECT Id FROM Alignments WHERE NAME = @alignment)

IF (SELECT Id FROM Planets WHERE NAME = @planet) IS NULL 
INSERT INTO Planets VALUES (@planet)
SET @planetId = (SELECT Id FROM Planets WHERE NAME = @planet)

IF (SELECT Id FROM Powers WHERE NAME = @power1) IS NULL 
INSERT INTO Powers VALUES (@power1, @power1Id)
SET @power1Id = (SELECT Id FROM Powers WHERE NAME = @power1)

IF (SELECT Id FROM Powers WHERE NAME = @power2) IS NULL 
INSERT INTO Powers VALUES (@power2, @power2Id)
SET @power2Id = (SELECT Id FROM Powers WHERE NAME = @power2)

IF (SELECT Id FROM Powers WHERE NAME = @power3) IS NULL 
INSERT INTO Powers VALUES (@power3, @power3Id)
SET @power3Id = (SELECT Id FROM Powers WHERE NAME = @power3)

INSERT INTO Superheroes (Name, SecretIdentity, Alignment_Id, Bio) VALUES
(@name, @secretIdentity, @alignmentId, @bio)

INSERT INTO PlanetSuperheroes (Superhero_Id)
(SELECT Id FROM Superheroes WHERE Name = @name)

UPDATE PlanetSuperheroes SET Planet_Id = @planetId WHERE Planet_Id IS NULL
END
GO

--8. Create a stored procedure that prints the number of powers by alignment of their superheroes
  --Name it usp_PowersUsageByAlignment
CREATE PROC usp_PowersUsageByAlignment
AS
BEGIN
	SELECT a.Name, COUNT(*) FROM Alignments a
	JOIN Superheroes s ON a.Id = s.Alignment_Id
	JOIN PlanetSuperheroes pls ON s.Id = pls.Superhero_Id
	JOIN Planets pl ON pls.Planet_Id = pl.Id 
	JOIN PowerSuperheroes pos ON s.Id = pos.Superhero_Id
	JOIN Powers po ON pos.Power_Id = po.Id
	GROUP BY a.Name
END
GO
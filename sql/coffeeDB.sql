CREATE DATABASE coffeeDB;
GO

USE coffeeDB;
GO

IF OBJECT_ID('Coffee', 'U') IS NOT NULL
	DROP TABLE Coffee
GO

IF OBJECT_ID('BrewMethods', 'U') IS NOT NULL
    DROP TABLE BrewMethods;
GO

CREATE TABLE BrewMethods (
	BrewMethodID INT PRIMARY KEY,
	MethodName NVARCHAR(50) NOT NULL
);
GO

INSERT INTO BrewMethods (BrewMethodID, MethodName) 
VALUES
	(1, 'Moccamaster'),
	(2, 'Aeropress'),
	(3, 'Restaurant');
GO

CREATE TABLE Coffee (
	CoffeeID INT PRIMARY KEY,
	Cups INT NOT NULL,
	BrewMethodID INT NOT NULL,
	DrinkDate DATE,
	CONSTRAINT FK_BrewMethod FOREIGN KEY (BrewMethodID) REFERENCES BrewMethods (BrewMethodID)
);
GO

INSERT INTO Coffee (CoffeeID, Cups, BrewMethodID, DrinkDate)
VALUES
    (1, 2, 1, '2025-01-15'), 
    (2, 3, 2, '2025-01-16'), 
    (3, 1, 3, '2025-01-17');
GO

SELECT 
    C.CoffeeID,
    C.Cups,
    B.MethodName AS BrewMethod,
    C.DrinkDate
FROM 
    Coffee C
    INNER JOIN BrewMethods B ON C.BrewMethodID = B.BrewMethodID;
GO
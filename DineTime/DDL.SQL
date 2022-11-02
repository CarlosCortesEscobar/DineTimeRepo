USE Master;
GO

IF DB_ID('DineTimeDb') IS NOT NULL
DROP DATABASE DineTimeDb;
GO

CREATE DATABASE DineTimeDb;
GO

USE DineTimeDb

CREATE TABLE Categories (
	CategoryID INT NOT NULL IDENTITY(1,1),
	Category NVarChar(64) NOT NULL,
	CONSTRAINT CategoryID_PK PRIMARY KEY(CategoryID),

);

CREATE TABLE Clients (
	ClientID INT NOT NULL IDENTITY(1,1),
	FirstName NVarChar(64) NOT NULL, 
	LastName NVarChar(64) NOT NULL, 
	PhoneNumber VarChar(12) NOT NULL,
	CONSTRAINT ClientID_PK PRIMARY KEY(ClientID)

);

CREATE TABLE Restaurant (
	RestaurantID INT NOT NULL IDENTITY(1,1),
	[Name] NVarChar(64) NOT NULL, 
	PhoneNumber VarChar(12) NOT NULL,
	OpenTime TIME NOT NULL,
	CloseTime TIME NOT NULL,
	SeatsAvailable INT NOT NULL,
	CategoryID INT NOT NULL,
	CONSTRAINT RestaurantID_PK PRIMARY KEY(RestaurantID),
	CONSTRAINT CategoryID_FK FOREIGN KEY(CategoryID)
		REFERENCES [Categories](CategoryID)
);

CREATE TABLE Reservations (
	ReservationID INT NOT NULL IDENTITY(1,1),
	RestaurantID INT NOT NULL,
	ClientID INT NOT NULL, 
	ReservationTime TIME NOT NULL, 
	ReservationDate DATE NOT NULL,
	NumberInParty INT NOT NULL,
	CONSTRAINT ReservationID_PK PRIMARY KEY(ReservationID),
	CONSTRAINT ClientID_FK FOREIGN KEY(ClientID)
		REFERENCES [Clients](ClientID),
	CONSTRAINT RestaurantID_FK FOREIGN KEY(RestaurantID)
		REFERENCES [Restaurant](RestaurantID)
);

CREATE TABLE Reviews (
	ReviewID INT NOT NULL IDENTITY(1,1),
	Rating INT NOT NULL,
	Comments NVarChar(256),
	CONSTRAINT ReviewID_PK PRIMARY KEY(ReviewID)
);

INSERT INTO Categories(Category)
VALUES ('Steakhouse')
INSERT INTO Categories(Category)
VALUES ('Taqueria')
INSERT INTO Categories(Category)
VALUES ('Sandwich')

INSERT INTO Clients(FirstName, LastName, PhoneNumber)
VALUES ('Cole', 'Woodard', '555-123-4444')

INSERT INTO Restaurant([Name], PhoneNumber, OpenTime, CloseTime, CategoryID, SeatsAvailable)
VALUES ('Fieris Bar & Grill', '582-123-2545', '9:00:00', '16:00:00', 1, 60);


INSERT INTO Restaurant([Name], PhoneNumber, OpenTime, CloseTime, CategoryID, SeatsAvailable)
VALUES ('La Casa Tacos', '582-123-2545', '9:00:00', '16:00:00', 2, 20);


INSERT INTO Restaurant([Name], PhoneNumber, OpenTime, CloseTime, CategoryID, SeatsAvailable)
VALUES ('Santana Sandwiches', '503-823-2575', '9:00:00', '16:00:00', 3, 15);

SELECT * FROM Restaurant

SELECT * FROM Clients

SELECT * FROM Reservations
USE [Airport] 
GO

--Таблица Авиакомпании
CREATE TABLE [Aircompany]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
	[AircompanyName] NVARCHAR (50),
	[AircompanyPhone] NVARCHAR (20),
	[AirCompanyAdress] NVARCHAR (100)
)
GO

--Таблица самолет
CREATE TABLE [Plane]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
	[idAircompany] INT NOT NULL,
	[PlaneModel] NVARCHAR (20),
	[PlaneNumber] NVARCHAR (50)
)
ALTER TABLE [Plane]

ADD CONSTRAINT FK_PlaneToAircompany FOREIGN KEY ([idAircompany]) 
REFERENCES [Aircompany]([id]);
GO

-- Таблица страна
CREATE TABLE [Country]
(
	[id] INT  NOT NULL PRIMARY KEY IDENTITY (1, 1),
	[name] NVARCHAR (50)
)
GO

--Таблица город
CREATE TABLE [City]
(--NO IDENTITY
	[id] INT NOT NULL PRIMARY KEY,
	[idCountry] INT NOT NULL,
	[Name] NVARCHAR (50),
	[Population] BIGINT,
	[GMT] DATETIME,
	[SignGMT] NVARCHAR(1)
);

ALTER TABLE [City]

ADD CONSTRAINT FK_CityToCountry FOREIGN KEY ([idCountry])
REFERENCES [Country]([id]);
GO
	

--Таблица аэропорт
CREATE TABLE [AirPort]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
	[idCity] INT NOT NULL,
	[Name] NVARCHAR (50)
)

ALTER TABLE [AirPort]
ADD CONSTRAINT FK_AirPortToCity FOREIGN KEY ([idCity])
REFERENCES [City]([id]);
GO

--Таблица Рейс
CREATE TABLE [Flight]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
	[idAircompany] INT NOT NULL,
	[idPlane] INT NOT NULL,
	[idAirPort] INT NOT NULL,
	[FlightType] NVARCHAR (20),
	[DateTimeStart] DATETIME,
	[Duration] DATETIME,
	[DateTimeArrival] DATETIME,
	[NumOfFlights] INT,
	[Periodicity] DATETIME,
	[PriceEconom] MONEY,
	[PriceBusiness] MONEY,
	[PriceFirst] MONEY,
	[DateTimeStartGMT] DATETIME,
	[DateTimeArrivalGMT] DATETIME,
	[Status] NVARCHAR (20)
)

ALTER TABLE [Flight]
ADD CONSTRAINT FK_FlightToAircompany FOREIGN KEY ([idAircompany])
REFERENCES [Aircompany]([id]);

ALTER TABLE [Flight]
ADD CONSTRAINT FK_FlightToPlane FOREIGN KEY ([idPlane])
REFERENCES [Plane]([id]);

ALTER TABLE [Flight]
ADD CONSTRAINT FK_FlightToAirPort FOREIGN KEY ([idAirPort])
REFERENCES [AirPort]([id]);
GO


--Таблица События, связанные с самолетом
CREATE TABLE [Events]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
	[idFlight] INT NOT NULL,
	[EventType] NVARCHAR (50),
	[DateTimeEvent] DATETIME
)

ALTER TABLE [Events]
ADD CONSTRAINT FK_EventsToFlight FOREIGN KEY ([idFlight])
REFERENCES [Flight]([id]);
GO


--Таблица НЕпредвиденные события, связанные с самолетом
CREATE TABLE [UnexpectedEvents]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
	[idFlight] INT NOT NULL,
	[EventType] NVARCHAR (50),
	[DateTimeEvent] DATETIME,
	[Duration] DATETIME,
	[Reason] NVARCHAR (MAX)
)

ALTER TABLE [UnexpectedEvents]
ADD CONSTRAINT FK_UnexpEventsToFlight FOREIGN KEY ([idFlight])
REFERENCES [Flight]([id]);
GO



--Таблица Способ оплаты
CREATE TABLE [Payment]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
	[Name] NVARCHAR (50),
	[AddCost] DECIMAL (4, 2),
)
GO


--Таблица Вид документа
CREATE TABLE [DocType]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
	[Name] NVARCHAR (50),
	[Description] NVARCHAR (50),
	[RegularExpression] NVARCHAR (100)
)
GO


--Таблица Покупатель
CREATE TABLE [Buyer]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
	[idPayment] INT NOT NULL,
	[LastName] NVARCHAR (50),
	[FirstName] NVARCHAR (50),
	[Phone] NVARCHAR (15),
	[AltPhone] NVARCHAR (15),
	[TimeToConnect] NVARCHAR (100),
	[DeliveryAdress] NVARCHAR (100)
)

ALTER TABLE [Buyer]
ADD CONSTRAINT FK_BuyerToPayment FOREIGN KEY ([idPayment])
REFERENCES [Payment]([id])



--Таблица Пассажиры
CREATE TABLE [Passengers]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
	[idDocType] INT NOT NULL,
	[LastName] NVARCHAR (50),
	[FirstName] NVARCHAR (50),
	[BirthDate] DATE,
	[Gender] NVARCHAR (10),
	[DocNumber] NVARCHAR (20)
)

ALTER TABLE [Passengers]
ADD CONSTRAINT FK_PassengersToDocType FOREIGN KEY ([idDocType])
REFERENCES [DocType]([id]);
GO


--Таблица Билеты
CREATE TABLE [Tickets]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
	[idFlight] INT NOT NULL,
	[idPassenger] INT NOT NULL,
	[idBuyer] INT NOT NULL,
	[Class] NVARCHAR (20)
)

ALTER TABLE [Tickets]
ADD CONSTRAINT FK_TicketsToFlight FOREIGN KEY ([idFlight])
REFERENCES [Flight]([id]);

ALTER TABLE [Tickets]
ADD CONSTRAINT FK_TicketsToPassengers FOREIGN KEY ([idPassenger])
REFERENCES [Passengers]([id]);

ALTER TABLE [Tickets]
ADD CONSTRAINT FK_TicketsToBuyer FOREIGN KEY ([idBuyer])
REFERENCES [Buyer]([id]);

GO
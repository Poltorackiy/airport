USE Airport 
GO
--Показывает все города и информацию о них
CREATE PROCEDURE [AllCity]
AS

SELECT 
	S.[Name] AS [Город],
	[Population] AS [Население],
	[SignGMT] AS [Зн],
	CONVERT (NVARCHAR, [GMT], 8) AS [GMT],
	C.[name] AS [Страна]
FROM [dbo].[City] S
INNER JOIN [dbo].Country C
ON C.[id] = S.[idCountry] 
ORDER BY S.[idCountry] 

GO


--Вывод информации о ближайших рейсах за определённый период времени

--Переменная @FutureDate - это дата, ограничивающая промежуток времени, должна быть позже настоящего времени

CREATE PROCEDURE [FutureFlights]
@FutureDate DATETIME
AS

SELECT 
	AC.[AircompanyName] AS [Авиакомпания],
	C.[Name] AS [Город],
	AP.[Name] AS [Аэропорт],
	--[DateTimeStartGMT] AS [Вылет] = 
	CONVERT (NVARCHAR, [DateTimeStartGMT], 13) AS [Вылет],
	CONVERT (NVARCHAR, [DateTimeArrivalGMT], 13) AS [Прибытие],
	[FlightType] AS [Тип рейса],
	[Status] AS [Статус],
	[Вид рейса] = (
	CASE
		WHEN C.[idCountry] = 1 THEN N'Внутренний'
		ELSE N'Международный'
	END
	)
FROM [dbo].[Flight] F
	INNER JOIN 
		[dbo].[Aircompany] AC
	ON
		AC.[id] = F.[idAircompany]
	INNER JOIN 
		[dbo].[AirPort] AP
	ON
		AP.[id] = F.[idAirPort]
	INNER JOIN		
		[dbo].[City] C
	ON		
		AP.[idCity] = C.[id]
GROUP BY
	C.[idCountry], F.[FlightType], F.[DateTimeStartGMT], F.[DateTimeArrivalGMT],
	C.[Name], AC.[AirCompanyName], AP.[Name], F.[Status] 
HAVING 
	F.[DateTimeStartGMT] >= GETDATE () AND
	F.[DateTimeArrivalGMT] <= @FutureDate 
	
GO


--Вывод данных о рейсе по городу
CREATE PROCEDURE [FlightsByCity]
@City NVARCHAR (50)
AS

SELECT 
	AC.[AircompanyName] AS [Авиакомпания],
	C.[Name] AS [Город],
	AP.[Name] AS [Аэропорт],
	CONVERT (NVARCHAR, F.[DateTimeStartGMT], 13) AS [Вылет],
	CONVERT (NVARCHAR, F.[DateTimeArrivalGMT], 13) AS [Прибытие],
	[FlightType] AS [Тип рейса],
	[Вид рейса] = (
	CASE
		WHEN C.[idCountry] = 1 THEN N'Внутренний'
		ELSE N'Международный'
	END
	),
	[Status] AS [Статус]
FROM [dbo].[Flight] F
	INNER JOIN 
		[dbo].[Aircompany] AC
	ON
		AC.[id] = F.[idAircompany]
	INNER JOIN 
		[dbo].[AirPort] AP
	ON
		AP.[id] = F.[idAirPort]
	INNER JOIN		
		[dbo].[City] C
	ON		
		AP.[idCity] = C.[id]
GROUP BY
	C.[idCountry], F.[FlightType], F.[DateTimeStartGMT], F.[DateTimeArrivalGMT],
	C.[Name], AC.[AirCompanyName], AP.[Name], F.[Status] 
HAVING 
	C.[Name]  = @City 
	
GO


--Вывод информации о событиях, связанных с самолетом на рейсе
CREATE PROCEDURE [FlightsWithEvents]
AS

SELECT 
	F.[ID] AS [ID],
	AC.[AirCompanyName] AS [Авиакомпания],
	C.[Name] AS [Город],
	AP.[Name] AS [Аэропорт],
	F.[FlightType] AS [Тип рейса],
	P.[PlaneModel] AS [Самолёт],
	P.[PlaneNumber] AS [Бортовой номер],
	CONVERT (NVARCHAR, F.[DateTimeStart], 13) AS [Вылет],
	CONVERT (NVARCHAR, ES.[DateTimeEvent], 13) AS [Вылетел],
	CONVERT (NVARCHAR, EA.[DateTimeEvent], 13) AS [Прибыл],
	CONVERT (NVARCHAR, [DateTimeArrival], 13) AS [Прибытие],
	[Вид рейса] = (
	CASE
		WHEN [idCountry] = 1 THEN N'Внутренний'
		ELSE N'Международный'
	END
	),
	[Status] AS [Статус]
FROM [dbo].[Flight] F
	INNER JOIN 
		[dbo].[Aircompany] AC
	ON 
		F.[idAircompany] = AC.[id]
	INNER JOIN
		[dbo].[AirPort] AP
	ON 
		F.[idAirPort] = AP.[id] 
	INNER JOIN
		[dbo].[City] C
	ON
		AP.[idCity] = C.[id]
	LEFT OUTER JOIN 
		[dbo].[Events] ES
	ON 
		F.[id] = ES.[idFlight] AND ES.[EventType] = N'Вылетел' 
	LEFT OUTER JOIN
		[dbo].[Events] EA
	ON
		F.[id] = EA.[idFlight] AND EA.[EventType] = N'Прибыл'
	INNER JOIN 
		[dbo].[Plane] P
	ON 
		F.[idPlane] = P.[id] 
GO


--Вывод непредвиденных событий, связанных с самолётом
CREATE PROCEDURE [UEvents]
AS

SELECT
	F.[ID] AS [ID],
	AC.[AirCompanyName] AS [Авиакомпания],
	P.[PlaneModel] AS [Самолёт],
	P.[PlaneNumber] AS [Бортовой номер],
	C.[Name] AS [Город],
	AP.[Name] AS [Аэропорт],
	CONVERT (NVARCHAR, F.[DateTimeStart], 13) AS [Вылет],
	CONVERT (NVARCHAR, F.[DateTimeArrival], 13) AS [Прибытие],
	[EventType] AS [Событие],
	F.[Status] AS [Статус],
	CONVERT (NVARCHAR, UE.[DateTimeEvent], 13) AS [Время события],
	CONVERT (NVARCHAR, UE.[Duration], 13) AS [Продолжительность],
	UE.[Reason] AS [Причина]
FROM [dbo].[Flight] F
	INNER JOIN
		[dbo].[Aircompany] AC
	ON
		F.[idAircompany] = AC.[id] 
	INNER JOIN
		[dbo].[AirPort] AP
	ON 
		F.[idAirPort] = AP.[id] 
	INNER JOIN 
		[dbo].[City] C
	ON
		AP.[idCity] = C.[id] 
	INNER JOIN 
		[dbo].[Plane] P
	ON
		F.[idPlane] = P.[id] 
	INNER JOIN
		[dbo].[UnexpectedEvents] UE
	ON
		F.[id] = UE.[idFlight] 
GROUP BY
	AC.[AircompanyName], P.[id], UE.[DateTimeEvent], F.[id], P.[PlaneModel], P.[PlaneNumber],
	C.[Name], AP.[Name], F.[FlightType], F.[DateTimeStart], F.[DateTimeArrival], UE.[EventType],
	F.[Status], UE.[DateTimeEvent], UE.[Duration], UE.[Reason] 
GO

--Отчёт о движении самолетов

CREATE PROCEDURE [PastFlights]
@PastDate DATETIME
AS

SELECT 
	AC.[AircompanyName] AS [Авиакомпания],
	C.[Name] AS [Город],
	AP.[Name] AS [Аэропорт],
	--[DateTimeStartGMT] AS [Вылет] = 
	CONVERT (NVARCHAR, [DateTimeStartGMT], 13) AS [Вылет],
	CONVERT (NVARCHAR, [DateTimeArrivalGMT], 13) AS [Прибытие],
	[FlightType] AS [Тип рейса],
	[Status] AS [Статус],
	[Вид рейса] = (
	CASE
		WHEN C.[idCountry] = 1 THEN N'Внутренний'
		ELSE N'Международный'
	END
	)
FROM [dbo].[Flight] F
	INNER JOIN 
		[dbo].[Aircompany] AC
	ON
		AC.[id] = F.[idAircompany]
	INNER JOIN 
		[dbo].[AirPort] AP
	ON
		AP.[id] = F.[idAirPort]
	INNER JOIN		
		[dbo].[City] C
	ON		
		AP.[idCity] = C.[id]
GROUP BY
	C.[idCountry], F.[FlightType], F.[DateTimeStartGMT], F.[DateTimeArrivalGMT],
	C.[Name], AC.[AirCompanyName], AP.[Name], F.[Status] 
HAVING 
	F.[DateTimeStartGMT] <= GETDATE () AND
	F.[DateTimeStartGMT] >= @PastDate 
	
GO

--Вывод информации об авиакомпаниях и принадлежащих им самолётах
CREATE PROCEDURE [AircompWithPlanes]
AS

SELECT
	AC.[AirCompanyName] AS [Авиакомпания],
	P.[PlaneModel] AS [Самолёт],
	P.[PlaneNumber] AS [Бортовой номер]
FROM [dbo].[Aircompany] AC
	INNER JOIN
		[dbo].[Plane] P
	ON 
		AC.[id] = P.[idAircompany] 
	GROUP BY
		AC.[AircompanyName] ,
		P.[PlaneModel] ,
		P.[PlaneNumber];

SELECT
	[AirCompanyName] AS [Авиакомпания],
	[AirCompanyPhone] AS [Телефон],
	[AirCompanyAdress] AS [Адрес офиса]
FROM [dbo].[Aircompany] 

GO


--Вывод информации о рейсах по стране
CREATE PROCEDURE [FlightsByCountry]
@Country NVARCHAR (50)
AS

SELECT 
	CO.[name] AS [Страна],
	AC.[AircompanyName] AS [Авиакомпания],
	C.[Name] AS [Город],
	AP.[Name] AS [Аэропорт],
	CONVERT (NVARCHAR, F.[DateTimeStartGMT], 13) AS [Вылет],
	CONVERT (NVARCHAR, F.[DateTimeArrivalGMT], 13) AS [Прибытие],
	[FlightType] AS [Тип рейса],
	[Вид рейса] = (
	CASE
		WHEN C.[idCountry] = 1 THEN N'Внутренний'
		ELSE N'Международный'
	END
	),
	[Status] AS [Статус]
FROM [dbo].[Flight] F
	INNER JOIN 
		[dbo].[Aircompany] AC
	ON
		AC.[id] = F.[idAircompany]
	INNER JOIN 
		[dbo].[AirPort] AP
	ON
		AP.[id] = F.[idAirPort]
	INNER JOIN		
		[dbo].[City] C
	ON		
		AP.[idCity] = C.[id]
	INNER JOIN
		[dbo].[Country] CO
	ON
		C.[idCountry] = CO.[id] 
GROUP BY
	CO.[Name], C.[idCountry], F.[FlightType], F.[DateTimeStartGMT], F.[DateTimeArrivalGMT],
	C.[Name], AC.[AirCompanyName], AP.[Name], F.[Status]
HAVING 
	CO.[Name]  = @Country
	
GO


--Подсчёт количества билетов, приобретённых покупателем
CREATE PROCEDURE [CountTickets]
@idBuyer INT
AS
	SELECT 
		COUNT ([id])
	FROM [dbo].[Tickets] 
	WHERE
		[idBuyer] = @idBuyer;
GO


--Подсчёт общей стоимости купленных билетов
CREATE PROCEDURE [TotalCost]
@idBuyer INT
AS
	SELECT 
		SUM (CASE
			WHEN T.[Class] = N'Эконом' THEN F.[PriceEconom] 
			WHEN T.[Class] = N'Бизнес' THEN F.[PriceBusiness] 
			WHEN T.[Class] = N'Первый' THEN F.[PriceFirst]
			END
			)
	FROM [dbo].[Flight] F
	INNER JOIN
		[dbo].[Tickets] T
	ON
		F.[id] = T.[idFlight] 
	INNER JOIN
		[dbo].[Buyer] B
	ON
		T.[idBuyer] = B.[id] 
	WHERE B.[id] = @idBuyer
GO

--Вывод информации о покупателях

CREATE PROCEDURE [Buyers]

AS

SELECT
	B.[LastName] AS [Фамилия],
	B.[FirstName] AS [Имя],
	B.[Phone] AS [Телефон],
	B.[AltPhone] AS [Альт. тел.],
	B.[TimeToConnect] AS [Время д/связи],
	B.[DeliveryAdress] AS [Адрес доставки],
	[CountOfTickets] = (
	
	SELECT 
		COUNT ([id])
	FROM [dbo].[Tickets] 
	WHERE [idBuyer] = B.[id] 
	
	),
	[Стоимость] = (
	
	SELECT 
		SUM (CASE
			WHEN T.[Class] = N'Эконом' THEN F.[PriceEconom] 
			WHEN T.[Class] = N'Бизнес' THEN F.[PriceBusiness] 
			WHEN T.[Class] = N'Первый' THEN F.[PriceFirst]
			END
			)
	FROM [dbo].[Flight] F
	INNER JOIN
		[dbo].[Tickets] T
	ON
		F.[id] = T.[idFlight] 
	INNER JOIN
		[dbo].[Buyer] Bu
	ON
		T.[idBuyer] = Bu.[id] 
	WHERE Bu.[id] = B.[id]
	
	),
	
	[К оплате] = (
	
	SELECT 
		SUM (CASE
			WHEN T.[Class] = N'Эконом' THEN F.[PriceEconom] 
			WHEN T.[Class] = N'Бизнес' THEN F.[PriceBusiness] 
			WHEN T.[Class] = N'Первый' THEN F.[PriceFirst]
			END
			)
	FROM [dbo].[Flight] F
	INNER JOIN
		[dbo].[Tickets] T
	ON
		F.[id] = T.[idFlight] 
	INNER JOIN
		[dbo].[Buyer] Bu
	ON
		T.[idBuyer] = Bu.[id] 
	WHERE Bu.[id] = B.[id]
	
	) * (1 + Pay.[AddCost] )
FROM [dbo].[Buyer] B
	INNER JOIN
		[dbo].[Payment] Pay
	ON
		B.[idPayment] = Pay.[id] 
	
GO


--Вывод информации о билетах, которые купил определённый человек

CREATE PROCEDURE [Passeng]
@LastName NVARCHAR (50),
@FirstName NVARCHAR (50)
AS

SELECT
	P.[LastName] AS [Фамилия],
	P.[FirstName] AS [Имя],
	CONVERT (NVARCHAR, P.[BirthDate], 13) AS [Дата Рождения],
	P.[Gender] AS [Пол],
	D.[Name] AS [Документ],
	P.[DocNumber] AS [Номер документа],
	B.[LastName] AS [Фамилия покупателя],
	B.[FirstName] AS [Имя покупателя],
	AC.[AirCompanyName] AS [Авиакомпания],
	C.[Name] AS [Город],
	AP.[Name] AS [Аэропорт],
	Pl.[PlaneModel] AS [Борт],
	F.[FlightType] AS [Тип рейса],
	F.[DateTimeStartGMT] AS [Время вылета],
	F.[DateTimeArrival] AS [Время прибытия],
	[Цена] = (CASE
		WHEN T.[Class] = N'Эконом' THEN F.[PriceEconom] 
		WHEN T.[Class] = N'Бизнес' THEN F.[PriceBusiness] 
		WHEN T.[Class] = N'Первый' THEN F.[PriceFirst]
	END),
	[Стоимость] = (
	
	CASE
		WHEN T.[Class] = N'Эконом' THEN F.[PriceEconom] 
		WHEN T.[Class] = N'Бизнес' THEN F.[PriceBusiness] 
		WHEN T.[Class] = N'Первый' THEN F.[PriceFirst]
	END
	) * (1 + Pay.[AddCost] )
FROM [dbo].[Passengers] P
	INNER JOIN
		[dbo].[DocType] D
	ON 
		P.[idDocType] = D.[id] 
	INNER JOIN
		[dbo].[Tickets] T
	ON
		P.[id] = T.[idPassenger] 
	INNER JOIN
		[dbo].[Buyer] B
	ON
		T.[idBuyer] = B.[id] 
	INNER JOIN 
		[dbo].[Flight] F
	ON
		T.[idFlight] = F.[id]
	INNER JOIN
		[dbo].[AirPort] AP
	ON
		F.[idAirPort] = AP.[id] 
	INNER JOIN
		[dbo].[City] C
	ON
		AP.[idCity] = C.[id] 
	INNER JOIN
		[dbo].[Aircompany] AC
	ON
		F.[idAircompany] = AC.[id] 
	INNER JOIN
		[dbo].[Plane] Pl
	ON
		F.[idPlane] = Pl.[id] 
	INNER JOIN
		[dbo].[Payment] Pay
	ON
		B.[idPayment] = Pay.[id] 
WHERE 		
	B.[LastName] LIKE N'%'+@LastName+N'%' OR B.[LastName] LIKE N'%'+@FirstName+N'%'
ORDER BY
	B.[id], F.[id]

GO

--Хранимые процедуры для интерфейса

CREATE PROCEDURE [AirCompanySelect]
AS
	SELECT [ID], [AircompanyName], [AircompanyPhone], [AirCompanyAdress]
	FROM [dbo].[Aircompany] 
GO

CREATE PROC [AirCompanyInsert]
@name NVARCHAR (50), @phone NVARCHAR (20), @address NVARCHAR (100)
AS
	INSERT INTO [dbo].[Aircompany] ([AircompanyName], [AircompanyPhone] , [AirCompanyAdress] )
	VALUES (@name, @phone, @address);
GO

CREATE PROC [AirCompanyUpdate]
@name NVARCHAR (50), @phone NVARCHAR (20), @address NVARCHAR (100), @id int
AS
	UPDATE [dbo].[Aircompany]
	SET [AircompanyName] = @name
	, [AircompanyPhone] = @phone
	, [AirCompanyAdress] = @address
	WHERE [ID] = @id;
GO

CREATE PROC [AirCompanyDelete]
@id int
AS
	DELETE FROM [dbo].[Aircompany] WHERE [ID] = @id;
GO

--exec [AirCompanySelect] ;



CREATE PROC [CountryInsert]
@name NVARCHAR (50)
AS
	INSERT INTO [dbo].[Country] ([name] )
	VALUES (@name);
GO

CREATE PROC [CountryUpdate]
@name NVARCHAR (50), @id INT
AS
	UPDATE [dbo].[Country] 
	SET [name] = @name
	WHERE [ID] = @id;
GO

CREATE PROC [CountryDelete]
@id INT
AS
	DELETE FROM [dbo].[Country] 
	WHERE [ID] = @id;
GO

CREATE PROC [GetCountry]
@id INT
AS
	SELECT [id], [name] 
	FROM [dbo].[Country]
	WHERE [ID] = @id;
GO

CREATE PROC [CountriesSelect]
AS
	SELECT [ID], [NAME] 
	FROM [dbo].[Country] ;
GO


--Список стран для фильтров или внешнего ключа
CREATE PROC [RefCountriesSelect]
AS
	SELECT [ID], [NAME] 
	FROM [dbo].[Country] ;
GO


--Города
CREATE PROC [SelectCitiesList]
AS
	SELECT CI.[ID] 
	, CO.[name] AS [CountryName]
	, CI.[Name] AS [CityName]
	, CI.[idCountry] AS [CountryID]	--Надо ли вставлять имя страны
	, [GMT] AS [CityGMT]
	, [SignGMT] 
	FROM [dbo].[City] CI
	INNER JOIN [dbo].[Country] CO
	ON CI.[idCountry] = CO.[id] 
GO

CREATE PROC [CityInsert]
@CountryID INT,
@CityName NVARCHAR (50),
@Population BIGINT,
@GMT DATETIME,
@SignGMT NVARCHAR (1)
AS
	DECLARE @ID INT;
	SELECT TOP (1) @ID = [ID]
	FROM [dbo].[City] 
	ORDER BY [ID] DESC;
	INSERT INTO [dbo].[City] ([id]
	,[idCountry] 
	,[Name] 
	,[Population] 
	,[GMT] 
	,[SignGMT] )
	VALUES (@ID+1
	,@CountryID
	,@CityName
	,@Population
	,@GMT
	,@SignGMT);
GO

CREATE PROC [CityUpdate]
@CityID INT,
@CountryID INT,
@CityName NVARCHAR (50),
@Population BIGINT,
@GMT DATETIME,
@SignGMT NVARCHAR (1)
AS
	UPDATE [dbo].[City]  SET [idCountry] = @CountryID
	,[Name] = @CityName
	,[Population] = @Population
	,[GMT] = @GMT
	,[SignGMT] = @SignGMT
	WHERE [ID] = @CityID;
GO

CREATE PROC [CityDelete]
@CityID INT
AS
	DELETE FROM [dbo].[City] WHERE [ID] = @CityID;
GO

CREATE PROC [GetCity]
@CityID INT
AS
	SELECT [ID]
	,[idCountry]
	,[Name] 
	,[Population]
	,[GMT]
	,[SignGMT]
	FROM [dbo].[City] 
	WHERE [ID] = @CityID;
GO



--Аэропорты
CREATE PROC [SelectAirPortList]
AS
	SELECT A.[id] 
	,A.[Name] AS [AirPortName]
	,CI.[Name] AS [CityName]
	,CO.[name] AS [CountryName]
	FROM [dbo].[AirPort] A
	INNER JOIN [dbo].[City] CI
		ON A.[idCity] = CI.[id] 
	INNER JOIN [dbo].[Country] CO
		ON CI.[idCountry] = CO.[id];
GO


--Список аэропортов для внешнего ключа по городу
CREATE PROC [SelectRefAirportListByCity]
@idCity INT
AS
	SELECT A.[id] , A.[Name] 
	FROM [dbo].[AirPort] A
	WHERE A.[idCity] = @idCity;
GO


--Список городов по ID страны (для внешнего ключа)
CREATE PROC [RefSelectCitiesListByID]
@CountryID INT
AS
	SELECT [id], [Name]
	FROM [dbo].[City] 
	WHERE [idCountry] = @CountryID;
GO


--Аэропорт инфо по номеру
CREATE PROC [GetAirport]
@AirportID INT
AS
	SELECT [id], [idCity], [Name] 
	FROM [dbo].[AirPort] 
	WHERE [id] = @AirportID;
GO


--Удаление аэропорта
CREATE PROC [DeleteAirport]
@AirportID INT
AS
	DELETE FROM [AirPort] 
	WHERE [AirPort].[id] = @AirportID;
GO


--Обновление аэропорта
CREATE PROC [UpdateAirport]
@AirportID INT, @AirportName NVARCHAR (50), @CityID INT
AS
	BEGIN TRANSACTION;
		UPDATE [dbo].[AirPort] 
		SET
			[Name] = @AirportName,
			[idCity] = @CityID
		WHERE
			[dbo].[AirPort].[id] = @AirportID;
	COMMIT;
GO


--Вставка нового аэропорта
CREATE PROC [InsertAirport]
@AirportName NVARCHAR (50), @CityID INT
AS
	BEGIN TRANSACTION;
		INSERT INTO [dbo].[AirPort] ([Name], [idCity])
		VALUES (
			@AirportName, @CityID
		);
	COMMIT;
GO


--Список самолётов
CREATE PROC [SelectAirplaneList]
AS
	SELECT P.[id], P.[idAircompany], P.[PlaneModel], P.[PlaneNumber], A.[AircompanyName] 
	FROM [dbo].[Plane] P
	INNER JOIN [dbo].[Aircompany] A
	ON	P.[idAircompany] = A.[id] 
GO


--Список авиакомпаний для внешнего ключа
CREATE PROC [SelectRefAircompaniesList]
AS
	SELECT [id], [AircompanyName] 
	FROM [dbo].[Aircompany] 
GO


--Получение информации о самолёте
CREATE PROC [GetPlaneInfo]
@PlaneID INT
AS
	SELECT [id], [idAircompany], [PlaneModel], [PlaneNumber]
	FROM [dbo].[Plane] 
	WHERE [id] = @PlaneID;
GO


--Обновление информации о самолете
CREATE PROC [UpdatePlane]
@PlaneID INT, @AircompanyID INT, @PlaneModel NVARCHAR (20), @PlaneNumber NVARCHAR (50)
AS
	UPDATE [Plane] 
	SET
		[idAircompany] = @AircompanyID,
		[PlaneModel] = @PlaneModel,
		[PlaneNumber] = @PlaneNumber
	WHERE [Plane].[id] = @PlaneID;
GO


--Добавление информации о самолете
CREATE PROC [InsertPlane]
@AircompanyID INT, @PlaneModel NVARCHAR (20), @PlaneNumber NVARCHAR (50)
AS
	INSERT INTO [dbo].[Plane] ([idAircompany] 
		,[PlaneModel] 
		,[PlaneNumber]
	)
	VALUES (@AircompanyID
		,@PlaneModel
		,@PlaneNumber
	)
GO


--Удаление информации о самолёте
CREATE PROC [DeletePlane]
@PlaneID INT
AS
	DELETE FROM [dbo].[Plane] 
	WHERE [dbo].[Plane].[id] = @PlaneID;
GO


CREATE PROC [SelectRefPlaneList]
AS
	SELECT P.[id]
		, P.[PlaneModel] + ' : ' + P.[PlaneNumber] + ' (' + A.[AircompanyName] + ')' AS [PlaneName]
	FROM [dbo].[Plane] P
	INNER JOIN [dbo].[Aircompany] A
		ON P.[idAircompany] = A.[id] 
GO

--Получение полной информации об одном рейсе
CREATE PROC [GetFlightInfo]
@idFlight INT
AS
	SELECT F.[ID]
		,F.[idAircompany] 
		,F.[idPlane] 
		,F.[idAirPort] 
		,F.[FlightType] 
		,F.[DateTimeStart] 
		,CONVERT(NVARCHAR, F.[Duration], 108) AS [Duration]
		,F.[DateTimeArrival] 
		,F.[PriceEconom] 
		,F.[PriceBusiness] 
		,F.[PriceFirst] 
		,F.[DateTimeStartGMT] 
		,F.[DateTimeArrivalGMT] 
		,F.[Status] 
	FROM [dbo].[Flight] F
	WHERE F.[id] = @idFlight;
GO


--Вставка рейса
CREATE PROC [InsertFlight]
@idAircompany INT,
@idPlane INT,
@idAirPort INT,
@FlightType NVARCHAR (20),
@DateTimeStart DATETIME,
@Duration DATETIME,
@NumOfFlights INT,
@Periodicity DATETIME,
@PriceEconom MONEY,
@PriceBusiness MONEY,
@PriceFirst MONEY
AS
	BEGIN TRANSACTION;
	IF (@Duration NOT BETWEEN '1900-01-01 00:00:00' AND '1900-02-01 00:00:00')
	BEGIN
		RAISERROR (N'Самолёт не может лететь больше суток', 8, 10);
		ROLLBACK TRANSACTION;
	END
	IF (@Periodicity NOT BETWEEN '1900-01-01 00:00:00' AND '1900-30-01 00:00:00')
	BEGIN
		RAISERROR (N'Периодичные рейсы не могут быть реже одного раза в месяц', 8, 11)
		ROLLBACK TRANSACTION;
	END
	IF (@NumOfFlights < 1)
	BEGIN
		RAISERROR (N'При добавлении записи должно быть не меньше одного рейса', 8, 12);
		ROLLBACK TRANSACTION;
	END
	INSERT INTO [dbo].[Flight] ([idAircompany]
		,[idPlane] 
		,[idAirPort] 
		,[FlightType] 
		,[DateTimeStart] 
		,[Duration] 
		,[NumOfFlights] 
		,[Periodicity] 
		,[PriceEconom] 
		,[PriceBusiness] 
		,[PriceFirst] 
	)
	VALUES (@idAircompany 
		,@idPlane 
		,@idAirPort 
		,@FlightType 
		,@DateTimeStart 
		,@Duration 
		,@NumOfFlights 
		,@Periodicity
		,@PriceEconom 
		,@PriceBusiness 
		,@PriceFirst 
	);
	COMMIT;
GO


--Обновление данных о рейсе
CREATE PROC [UpdateFlight]
@idFlight INT,
@idAircompany INT,
@idPlane INT,
@idAirPort INT,
@FlightType NVARCHAR (20),
@DateTimeStart DATETIME,
@Duration DATETIME,
@PriceEconom MONEY,
@PriceBusiness MONEY,
@PriceFirst MONEY
AS
	BEGIN TRANSACTION;
	IF (@Duration NOT BETWEEN '1900-01-01 00:00:00' AND '1900-02-01 00:00:00')
	BEGIN
		RAISERROR (N'Самолёт не может лететь больше суток', 8, 10);
		ROLLBACK TRANSACTION;
	END
		UPDATE [dbo].[Flight] 
		SET
			[idAircompany] = @idAircompany,
			[idPlane] = @idPlane,
			[idAirPort] = @idAirPort,
			[FlightType] = @FlightType,
			[DateTimeStart] = @DateTimeStart,
			[Duration] = @Duration,
			[PriceEconom] = @PriceEconom,
			[PriceBusiness] = @PriceBusiness,
			[PriceFirst] = @PriceFirst 
		WHERE [dbo].[Flight].[id] = @idFlight;
	COMMIT;
GO


--Удаление данных о рейсе
CREATE PROC [DeleteFlight]
@idFlight INT
AS
	BEGIN TRANSACTION;
		DELETE FROM [dbo].[Flight]
		WHERE [dbo].[Flight].[id] = @idFlight;
	COMMIT;
GO


--Список рейсов
CREATE PROC [SelectFlights]
@BeginDate DATETIME = '1900-01-01 00:00:00',
@EndDate DATETIME = '2050-01-01 00:00:00',
@idCountry INT = 0,
@idCity INT = 0,
@idAirport INT = 0
AS
	SELECT F.[ID]
		,F.[idAircompany] 
		,F.[idPlane] 
		,F.[idAirPort] 
		,F.[FlightType] 
		,F.[DateTimeStart] 
		,CONVERT(NVARCHAR, F.[Duration], 108) AS [Duration]
		,F.[DateTimeArrival] 
		,F.[PriceEconom] 
		,F.[PriceBusiness] 
		,F.[PriceFirst] 
		,F.[DateTimeStartGMT] 
		,F.[DateTimeArrivalGMT] 
		,F.[Status] 
		,AC.[AircompanyName] 
		,P.[PlaneModel] 
		,AP.[Name] AS [AirPortName]
		,CI.[Name] AS [CityName]
		,CO.[name] AS [CountryName]
	FROM [dbo].[Flight] F
	INNER JOIN [dbo].[Aircompany] AC
		ON F.[idAircompany] = AC.[id] 
	INNER JOIN [dbo].[Plane] P
		ON F.[idPlane] = P.[id] 
	INNER JOIN [dbo].[AirPort] AP
		ON F.[idAirPort] = AP.[id] 
	INNER JOIN [dbo].[City] CI
		ON AP.[idCity] = CI.[id]  
	INNER JOIN [dbo].[Country] CO
		ON CI.[idCountry] = CO.[id] 
	WHERE 
		(
			((F.[DateTimeStart] BETWEEN @BeginDate AND @EndDate) 
			AND F.[FlightType] = N'Исходящий')
		OR 
			((F.[DateTimeArrival] BETWEEN @BeginDate AND @EndDate) 
			AND F.[FlightType] = N'Входящий')
		)
		AND
		(
			(CO.[id] = @idCountry) OR (@idCountry = 0)
		)
		AND
		(
			(CI.[id] = @idCity) OR (@idCity = 0)
		)
		AND
		(
			(AP.[id] = @idAirport) OR (@idAirport = 0)
		);
GO











/*
--sys.database_permissions, sp_helpuser
SELECT * FROM "sys"."database_permissions" where "major_id" = 2021582240
select OBJECT_NAME(2021582240)
select USER_NAME(2)
select USER
select CURRENT_USER
exec sp_helpuser 
SELECT OBJECT_ID('InsertFlight', 'P'); 
select OBJECT_ID('selectflights', 'P');
declare @a decimal;
set @a = scope_identity();
print @a;
exec sp_helprotect @username = 'KPoltarackiy'
select * from sys.procedures WHERE name NOT LIKE 'sp_%'
*/
/*
WHERE (@id = [id] OR @id = 0) AND ...

*/
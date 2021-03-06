USE [Airport] 
GO

--Представление, показывающее города и страны
CREATE VIEW [allCityCountry]
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
GO

SELECT * FROM [allCityCountry];
GO

--Вывод информации о событиях, связанных с самолетом на рейсе
CREATE VIEW [FlightsAndEvents]
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

--Вывод непредвиденных событий, связанных с самолетом
CREATE VIEW [UnexpEv]
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


--Авиакомпании с самолетами


--Вывод информации о покупателях:
CREATE VIEW [Buy]
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
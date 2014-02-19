USE "Airport" 
GO

--Курсор, отображающий 5 ближайших вылетов
DECLARE "Top5Flights" CURSOR
FOR
SELECT TOP(5) "FROM" =((SELECT "name" FROM "dbo"."Country" WHERE "id" = 1) + ', ' + (SELECT "Name" FROM "dbo"."City" WHERE "id" = 1))
	, CO."name" + ', ' + CI."Name" AS "TO"
	, AC."AircompanyName" AS "Aircompany"
	, CONVERT(NVARCHAR, F."DateTimeStart", 120) AS "DateTimeStart"
	, CONVERT(NVARCHAR, F."DateTimeArrival", 120) AS "DateTimeArrival"
	, CONVERT(NVARCHAR, F."DateTimeArrivalGMT", 120) AS "DateTimeArrivalGMT"
	, F."Status"
	, F."id"
FROM "dbo"."Flight" F
INNER JOIN "dbo"."Aircompany" AC
	ON F."idAircompany" = AC."id" 
INNER JOIN "dbo"."Plane" P
	ON F."idPlane" = P."id" 
INNER JOIN "dbo"."AirPort" AP
	ON F."idAirPort" = AP."id" 
INNER JOIN "dbo"."City" CI
	ON AP."idCity" = CI."id" 
INNER JOIN "dbo"."Country" CO
	ON CI."idCountry" = CO."id" 
WHERE F."DateTimeStart" > GETDATE() AND F."FlightType" = N'Исходящий'
ORDER BY F."DateTimeStart";

OPEN "Top5Flights";

DECLARE @FROM NVARCHAR(100);
DECLARE @TO NVARCHAR(100);
DECLARE @Aircompany NVARCHAR(50);
DECLARE @DateTimeStart NVARCHAR(30);
DECLARE @DateTimeArrival NVARCHAR(30);
DECLARE @DateTimeArrivalGMT NVARCHAR(30);
DECLARE @Status NVARCHAR(20);
DECLARE @id INT;

FETCH NEXT FROM "Top5Flights" INTO @FROM
	, @TO
	, @Aircompany
	, @DateTimeStart
	, @DateTimeArrival
	, @DateTimeArrivalGMT
	, @Status
	, @id;

WHILE @@FETCH_STATUS <> -1
BEGIN

PRINT N'Рейс номер ' + CONVERT(NVARCHAR, @id);
PRINT N'				  		  Куда:	' + @TO;
PRINT N'				 		    Из:	' + @FROM;
PRINT N'				 	  Вылетает:	' + @DateTimeStart;
PRINT N' Прибывает по текущему времени:	' + @DateTimeArrival;
PRINT N' Прибывает по местному времени:	' + @DateTimeArrivalGMT;
PRINT N'				  Статус рейса: ' + @Status;
PRINT N'				  Авиакомпания: ' + @Aircompany;
PRINT '';
PRINT '';

FETCH NEXT FROM "Top5Flights" INTO @FROM
	, @TO
	, @Aircompany
	, @DateTimeStart
	, @DateTimeArrival
	, @DateTimeArrivalGMT
	, @Status
	, @id;

END

PRINT 'Приятного путешествия!';

CLOSE "Top5Flights";
DEALLOCATE "Top5Flights";
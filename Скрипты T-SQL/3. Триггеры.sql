--�������� ���������
USE [Airport] 
GO

--������� �� �������������� ���������� ������� �������� � �������� �������.

CREATE TRIGGER [AutoDateTimeArrival]
ON [dbo].[Flight]
AFTER INSERT, UPDATE
AS
	UPDATE [dbo].[Flight]
	SET [DateTimeArrival] = [Flight].[DateTimeStart] + [Flight].[Duration]
	FROM inserted
	DECLARE @GMT DATETIME = (
		SELECT DISTINCT [GMT]
		FROM [dbo].[City] c
			INNER JOIN 
				[AirPort] a
		ON 
			c.[id] = a.[idCity] AND a.[id] = (SELECT DISTINCT [idAirPort] FROM inserted)
	)
	
	DECLARE @GMTSign NVARCHAR(1) = (
		SELECT DISTINCT [SignGMT] 
		FROM [dbo].[City] c
			INNER JOIN 
				[AirPort] a
		ON 
			c.[id] = a.[idCity] AND a.[id] = (SELECT DISTINCT [idAirPort] FROM inserted)
	)
	
	DECLARE @MyGMT DATETIME = (
		SELECT [GMT] FROM [dbo].[City] WHERE [id] = 1
	)
	
	DECLARE @FlightType NVARCHAR (20) = (
	SELECT DISTINCT [FlightType] FROM inserted
	)
	
	IF (@GMTSign = '+' AND @FlightType = '��������')
	BEGIN
		UPDATE [dbo].[Flight]
		SET [DateTimeStartGMT] = [Flight].[DateTimeStart] + @GMT - @MyGMT
		FROM inserted
		
		UPDATE [dbo].[Flight]
		SET [DateTimeArrivalGMT] = [Flight].[DateTimeArrival]
		FROM inserted
	END
	
	IF (@GMTSign = '-' AND @FlightType = '��������')
	BEGIN
		UPDATE [dbo].[Flight]
		SET [DateTimeStartGMT] = [Flight].[DateTimeStart] - @GMT - @MyGMT
		FROM inserted
		
		UPDATE [dbo].[Flight]
		SET [DateTimeArrivalGMT] = [Flight].[DateTimeArrival] + @GMT - @MyGMT
		FROM inserted
	END
	
	IF (@GMTSign = '+' AND @FlightType = '���������')
	BEGIN
		UPDATE [dbo].[Flight]
		SET [DateTimeArrivalGMT] = [Flight].[DateTimeArrival] + @GMT - @MyGMT
		FROM inserted
		
		UPDATE [dbo].[Flight]
		SET [DateTimeStartGMT] = [Flight].[DateTimeStart]
		FROM inserted
	END
	
	IF (@GMTSign = '-' AND @FlightType = '���������')
	BEGIN
		UPDATE [dbo].[Flight]
		SET [DateTimeArrivalGMT] = [Flight].[DateTimeArrival] - @GMT - @MyGMT
		FROM inserted
		
		UPDATE [dbo].[Flight]
		SET [DateTimeStartGMT] = [Flight].[DateTimeStart]
		FROM inserted
	END
GO

--���������� ������������� ������

--���������� ������� � ������������� ����� � ������� ����� WHILE 
CREATE TRIGGER [AutoAddPeriodicalFlights]
ON [dbo].[Flight]
AFTER INSERT
AS
	DECLARE @Count INT = 0;
	DECLARE @GlobalCount INT = (SELECT [NumOfFlights] FROM inserted);
	SET @Count = (SELECT [NumOfFlights] FROM inserted);
	DECLARE @DateTimeStartGlobal DATETIME = (SELECT [DateTimeStart] FROM inserted);
	
	UPDATE [dbo].[Flight]
	SET [Status] = N'�� ����������'
	WHERE [id] = (SELECT [id] FROM inserted)
	
	DECLARE @id INT;
		DECLARE @idAirCompany INT;
		DECLARE @idPlane INT;
		DECLARE @idAirPort INT;
		DECLARE @FlightType NVARCHAR (20);
		DECLARE @DateTimeStart DATETIME;
		DECLARE @Duration DATETIME;
		DECLARE @Periodicity DATETIME;
		DECLARE @PriceEconom INT;
		DECLARE @PriceBusiness INT;
		DECLARE @PriceFirst INT;

		SET @idAirCompany = (SELECT [idAirCompany] FROM inserted);
		SET @idAirPort = (SELECT [idAirPort] FROM inserted);
		SET @idPlane = (SELECT [idPlane] FROM inserted);
		SET @FlightType = (SELECT [FlightType] FROM inserted);
		SET @Periodicity = (SELECT [Periodicity] FROM inserted);
		SET @DateTimeStart = (SELECT [DateTimeStart] FROM inserted)
		
		SET @Duration = (SELECT [Duration] FROM inserted);
		SET @PriceEconom = (SELECT [PriceEconom] FROM inserted);
		SET @PriceBusiness = (SELECT [PriceBusiness] FROM inserted);
		SET @PriceFirst = (SELECT [PriceFirst] FROM inserted);
	
	WHILE (@Count > 1)
	BEGIN
		SET @id = (SELECT TOP (1) [id]  FROM [dbo].[Flight] ORDER BY [id] DESC) + 1;
		SET @DateTimeStart = @DateTimeStart + @Periodicity;
		SET @Count = @Count - 1;
		
		INSERT INTO [dbo].[Flight] 
		([idAirCompany],[idPlane], [idAirPort], [FlightType], [DateTimeStart], [Duration], [NumOfFlights], [Periodicity], [PriceEconom], [PriceBusiness], [PriceFirst], [Status])
		VALUES
		(@idAirCompany, @idPlane, @idAirPort, @FlightType, @DateTimeStart, @Duration, @Count, @Periodicity, @PriceEconom, @PriceBusiness, @PriceFirst, N'�� ����������')
	END
GO


--�������, ������� ���������, ��� ��� ������� ����� �� ������ ������ ������� "�������"

CREATE TRIGGER [NoMoreThanOneStartEvent]
ON [dbo].[Events] 
AFTER INSERT, UPDATE
AS
	DECLARE @idFlight INT = (SELECT [idFlight] FROM inserted);
	DECLARE @EventCount INT;
	SET @EventCount = (SELECT COUNT (*)
	FROM [dbo].[Events]
	WHERE [idFlight] = @idFlight AND [EventType] = N'�������');
	IF (@EventCount > 1)
	BEGIN
		RAISERROR (N'������� �� ����� �������� 2 ���� ������. ������ ���� ������� ��� ����', 5, 1);
		ROLLBACK TRAN;
	END
GO

--�������, ������� ���������, ��� ��� ������� ����� �� ����� ������ ������� "������"
CREATE TRIGGER [NoMoreThanOneArrivalEvent]
ON [dbo].[Events] 
AFTER INSERT, UPDATE
AS
	DECLARE @idFlight INT = (SELECT [idFlight] FROM inserted);
	DECLARE @EventCount INT;
	SET @EventCount = (SELECT COUNT (*)
	FROM [dbo].[Events]
	WHERE [idFlight] = @idFlight AND [EventType] = N'������');
	IF (@EventCount > 1)
	BEGIN
		RAISERROR (N'������� �� ����� ������� 2 ���� ������. ������ ���� ������� ��� ����', 5, 2);
		ROLLBACK TRAN;
	END
GO

--�������, ������� ���������, ��� ������� "������" ��� ���������� ������ �� �����������
CREATE TRIGGER [NoArriveWithoutStart]
ON [dbo].[Events] 
AFTER INSERT, UPDATE
AS
	DECLARE @idFlight INT = (SELECT [idFlight] FROM inserted);
	DECLARE @EventCount INT;
	DECLARE @EventType NVARCHAR(50) = (SELECT [EventType] FROM inserted);
	SET @EventCount = (SELECT COUNT (*)
	FROM [dbo].[Events]
	WHERE [idFlight] = @idFlight AND [EventType] = N'�������');
	IF (@EventCount = 0 AND @EventType = N'������')
	BEGIN
		RAISERROR (N'������� �� ����� �������, ��� ��� �� �� �������. �������� ������� ������', 5, 2);
		ROLLBACK TRAN;
	END
GO

--�������, �����������, ��� ������� "�������" ������, ��� "������"
--DROP TRIGGER [StartIsEarlierThanArrive]
CREATE TRIGGER [StartIsEarlierThanArrive]
ON [dbo].[Events]
AFTER INSERT, UPDATE
AS
	DECLARE @DateTimeStart DATETIME;
	DECLARE @DateTimeArrive DATETIME;
	DECLARE @FlightID INT = (SELECT [idFlight] FROM inserted)
	DECLARE @Count INT = (SELECT COUNT (*) FROM [dbo].[Events] WHERE [idFlight] = @FlightID AND [EventType] = N'�������');
	IF (@Count = 1)
	BEGIN
		SET @DateTimeStart = (SELECT [DateTimeEvent] FROM [dbo].[Events] WHERE [idFlight] = @FlightID AND [EventType] = N'�������')
		SET @DateTimeArrive = (SELECT [DateTimeEvent] FROM inserted);
		IF (@DateTimeStart > @DateTimeArrive)
		BEGIN
			RAISERROR (N'������� �� ����� ������� ������, ��� �������. ��������� ������������ ����������� ������ ��� �������������� ������� ������', 5, 2);
			ROLLBACK TRAN;
		END
	END
GO

--������� �� �������������� ������������ ������� ����� �������
CREATE TRIGGER [StatusStart]
ON [dbo].[Events]
FOR INSERT, UPDATE
AS
	DECLARE @idFlight INT;
	SET @idFlight = (SELECT [idFlight] FROM inserted);
	DECLARE @EventType NVARCHAR (50) = (SELECT [EventType] FROM inserted);
	DECLARE @Arrived INT = (SELECT COUNT (*) FROM [dbo].[Events] WHERE [idFlight] = @idFlight AND [EventType] = N'������')
	IF (@EventType = N'�������' AND @Arrived = 0)
	BEGIN
		UPDATE [dbo].[Flight]
		SET [Status] = N'�������'
		WHERE [id] = @idFlight
	END
GO

--������� �� ������������ ������� "������"
CREATE TRIGGER [AutoArrived]
ON [dbo].[Events]
FOR INSERT, UPDATE
AS
	DECLARE @EventType NVARCHAR (50) = (SELECT [EventType] FROM inserted);
	DECLARE @idFlight INT = (SELECT [idFlight] FROM inserted);
	IF (@EventType = N'������')
	BEGIN
		UPDATE [dbo].[Flight]
		SET [Status] = N'������'
		WHERE [id] = @idFlight
	END
GO

--�������, ����������� ��������� �������, ���� ���� �������
CREATE TRIGGER [NoEventsIfCancelled]
ON [dbo].[Events]
AFTER INSERT, UPDATE
AS
	DECLARE @CountCancelEvents INT;
	DECLARE @idFlight INT = (SELECT [idFlight] FROM inserted);
	SET @CountCancelEvents = (
	SELECT COUNT (*) 
	FROM [dbo].[UnexpectedEvents] 
	WHERE [idFlight] = @idFlight AND [EventType] = N'������');
	IF (@CountCancelEvents >= 1)
	BEGIN
		RAISERROR (N'���� ������, ������� ������� ����������', 5, 1)
		ROLLBACK TRAN;
	END
GO

--�������, ����������� ��������� ������� "�������������" ��� "������", ���� ������� ��� �������
CREATE TRIGGER [NoDelayOrCancellIfStarted]
ON [dbo].[UnexpectedEvents]
AFTER INSERT, UPDATE
AS
	DECLARE @CountStartEvents INT;
	DECLARE @idFlight INT = (SELECT [idFlight] FROM inserted);
	SET @CountStartEvents = (
	SELECT COUNT (*) 
	FROM [dbo].[Events] 
	WHERE [idFlight] = @idFlight AND [EventType] = N'�������');
	IF (@CountStartEvents = 1)
	BEGIN
		RAISERROR (N'������ ��� �������, ���� �� ����� ���� �������� ��� ������', 5, 1)
		ROLLBACK TRAN;
	END
GO


--�������, ����������� ������ "�������������" ��� "������"
CREATE TRIGGER [DelayedOrCalcelled]
ON [dbo].[UnexpectedEvents]
AFTER INSERT, UPDATE
AS
	DECLARE @idFlight INT = (
	SELECT [idFlight] 
	FROM 
	inserted);
	UPDATE [Flight]
	SET [Status] = (SELECT [EventType] FROM inserted)
	WHERE [id] = @idFlight;
GO


--�������, �����������, ��� ����������� ���� "����� ���������", ��������������� �������� ���������, ������������� ����������� ���������
CREATE TRIGGER [DocNumberMatchesToRE]
ON [dbo].[Passengers]
AFTER INSERT, UPDATE
AS
	DECLARE @Doc INT = (SELECT [idDocType] FROM inserted);
	DECLARE @RE NVARCHAR (100) = (SELECT [RegularExpression] FROM [dbo].[DocType] WHERE [id] = @Doc);
	DECLARE @DocNum NVARCHAR (20) = (SELECT [DocNumber] FROM inserted);
	IF (@DocNum NOT LIKE @RE)
	BEGIN
		RAISERROR (N'������� ����� ����� ���������.', 5, 6);
		ROLLBACK TRAN;
	END
GO
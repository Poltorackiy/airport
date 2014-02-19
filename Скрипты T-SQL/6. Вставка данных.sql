--��������� �������
USE Airport 
GO
BEGIN TRANSACTION;

--��������� ������
INSERT INTO [dbo].[Country] ([Name]) VALUES
(N'���������� ���������'),
(N'���������'),
(N'������'),
(N'�����'),
(N'���');

--��������� ������
INSERT INTO [dbo].[City] ([id], [idCountry], [Name], [Population], [GMT], [SignGMT]) VALUES
(1, 1, N'�����������', 1500000, '07:00:00', '+'),
(2, 1, N'������', 8500000, '04:00:00', '+'),
(3, 2, N'������', 2000000, '06:00:00', '+'),
(4, 3, N'�����', 10000000, '09:00:00', '+'),
(5, 4, N'������', 7000000, '08:00:00', '+'),
(6, 5, N'���-�������', 8000000, '07:00:00', '-'),
(7, 1, N'����������', 1000000, '08:00:00', '+'),
(8, 1, N'��������', 400000, '05:00:00', '+');

-- ��������� ���������
INSERT INTO [dbo].[Airport] ([idCity], [Name]) VALUES
(1, N'���������'),
(2, N'�����������'),
(2, N'����������'),
(2, N'�������'),
(3, N'��������'),
(5, N'������������� �������� ������'),
(5, N'���������� �������� ������'),
(6, N'������������� �������� ���-��������'),
(7, N'����������'),
(2, N'�����');

--��������� ������������
INSERT INTO [dbo].[Aircompany] ([AircompanyName], [AircompanyPhone], [AircompanyAdress])
VALUES
(N'S7 Airlines', '+7 (383) 2237518', N'���-�� � ������������'),
(N'��������', '+7 (383) 2482938', N'���-�� � ����������� ������'),
(N'���� �������', '+7 (383) 2212121', N'� ����� �� ��������');

--��������� ��������
INSERT INTO [dbo].[Plane] ([idAircompany], [PlaneModel], [PlaneNumber]) VALUES
(1, N'��-86', N'S7-IL86-293'),
(1, N'BOEING-747', N'S7-BOE747-492'),
(2, N'FELIX-F', N'AF-FELF-201'),
(2, N'VOLODYA', N'AF-VOL-184'),
(3, N'��-160', N'JV-TU160-124'),
(3, N'MATIS-G6', N'JV-MATG6-134');
GO



--��������� �����
INSERT INTO [dbo].[Flight] 
([idAircompany], [idPlane], [idAirPort], [FlightType], [DateTimeStart], [Duration], [NumOfFlights], [Periodicity], [PriceEconom], [PriceBusiness], [PriceFirst])
VALUES
(1, 1, 2, N'���������', '2012-14-06 07:00:00', '04:00:00', 5, '1900-02-01 00:00:00', 12400, 15000, 20000);

INSERT INTO [dbo].[Flight] 
([idAircompany], [idPlane], [idAirPort], [FlightType], [DateTimeStart], [Duration], [NumOfFlights], [Periodicity], [PriceEconom], [PriceBusiness], [PriceFirst])
VALUES
(1, 1, 3, N'��������', '2012-20-06 22:00:00', '04:00:00', 4, '1900-07-01 00:00:00', 12400, 15000, 20000);

INSERT INTO [dbo].[Flight] 
([idAircompany], [idPlane], [idAirPort], [FlightType], [DateTimeStart], [Duration], [NumOfFlights], [Periodicity], [PriceEconom], [PriceBusiness], [PriceFirst])
VALUES
(2, 3, 10, N'���������', '2012-08-06 19:00:00', '06:00:00', 2, '1900-02-01 00:00:00', 20000, 21000, 22000);

INSERT INTO [dbo].[Flight] 
([idAircompany], [idPlane], [idAirPort], [FlightType], [DateTimeStart], [Duration], [NumOfFlights], [Periodicity], [PriceEconom], [PriceBusiness], [PriceFirst])
VALUES
(2, 3, 5, N'��������', '2012-08-06 05:00:00', '06:00:00', 1, '1900-01-01 00:00:00', 20000, 21000, 22000);

INSERT INTO [dbo].[Flight] 
([idAircompany], [idPlane], [idAirPort], [FlightType], [DateTimeStart], [Duration], [NumOfFlights], [Periodicity], [PriceEconom], [PriceBusiness], [PriceFirst])
VALUES
(2, 3, 7, N'��������', '2012-08-06 05:00:00', '06:00:00', 2, '1900-07-01 00:00:00', 20000, 21000, 22000);

--DELETE FROM [Flight] WHERE [id] <= 100;



--��������� �������
INSERT INTO [dbo].[Events] ([idFlight], [EventType], [DateTimeEvent])
VALUES
(10, N'�������', '2012-08-06 07:10:00');
INSERT INTO [dbo].[Events] ([idFlight], [EventType], [DateTimeEvent])
VALUES
(10, N'������', '2012-08-06 11:10:00');
INSERT INTO [dbo].[Events] ([idFlight], [EventType], [DateTimeEvent])
VALUES
(1, N'�������', '2012-08-06 19:40:00');
INSERT INTO [dbo].[Events] ([idFlight], [EventType], [DateTimeEvent])
VALUES
(2, N'�������', '2012-09-06 20:00:00');
INSERT INTO [dbo].[Events] ([idFlight], [EventType], [DateTimeEvent])
VALUES
(2, N'������', '2012-09-06 23:00:00');

INSERT INTO [dbo].[Events] ([idFlight], [EventType], [DateTimeEvent])
VALUES
(5, N'�������', '2012-09-06 20:00:00');
GO
--DELETE FROM [DBO].[EVENTS] WHERE [ID] <= 100;


--��������� ����������������� �������
INSERT INTO [dbo].[UnexpectedEvents] ([idFlight], [EventType], [DateTimeEvent], [Duration], [Reason])
VALUES
(3, N'�������������', '2012-07-08 12:35', '1900-02-01 00:00:00', N'������� ������');

INSERT INTO [dbo].[UnexpectedEvents] ([idFlight], [EventType], [DateTimeEvent], [Duration], [Reason])
VALUES
(4, N'������', '2012-27-05 16:15', NULL, N'�������� � �����������������');
GO


--��������� ������� ������
INSERT INTO [dbo].[Payment] ([Name], [AddCost])
VALUES
(N'����� ������������', 0),
(N'�������� ������� PayPal', 0.05),
(N'������ �������', 0.1);
GO

--��������� ���� ����������, �������������� ��������
INSERT INTO [dbo].[DocType] ([Name], [Description], [RegularExpression])
VALUES
(N'������� ���������� ��', N'10 ����: ����� � ����� ������', N'[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]');

INSERT INTO [dbo].[DocType] ([Name], [Description], [RegularExpression])
VALUES
(N'����������� �������', N'11 ����', N'[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]');
GO


--��������� ������ � �����������
INSERT INTO [dbo].[Buyer] ([idPayment], [LastName], [FirstName], [Phone], [AltPhone], [TimeToConnect], [DeliveryAdress])
VALUES
(1, N'���������', N'��������', N'+79230192857', NULL, N'�������, ����� 19', N'��. �����������, 35, ��. 124'),
(1, N'��������', N'�������', N'+79135748383', NULL, N'����� ��������', N'��. ������� �������');

--��������� ������ � ����������
INSERT INTO [dbo].[Passengers] ([idDocType], [LastName], [FirstName], [BirthDate], [Gender], [DocNumber])
VALUES
(1, N'�����������', N'����������', '1990-11-05', N'�������', N'5004630007');

INSERT INTO [dbo].[Passengers] ([idDocType], [LastName], [FirstName], [BirthDate], [Gender], [DocNumber])
VALUES
(1, N'���������', N'��������', '1990-10-15', N'�������', N'5008392837');

INSERT INTO [dbo].[Passengers] ([idDocType], [LastName], [FirstName], [BirthDate], [Gender], [DocNumber])
VALUES
(2, N'������', N'���������', '1985-12-23', N'�������', N'50204639307');

INSERT INTO [dbo].[Passengers] ([idDocType], [LastName], [FirstName], [BirthDate], [Gender], [DocNumber])
VALUES
(1, N'��������', N'�������', '1945-05-09', N'�������', N'5004630283');

INSERT INTO [dbo].[Passengers] ([idDocType], [LastName], [FirstName], [BirthDate], [Gender], [DocNumber])
VALUES
(1, N'�������', N'�����', '1991-10-07', N'�������', N'5004672007');


--��������� ������ � �������
INSERT INTO [dbo].[Tickets] 
([idFlight], [idPassenger], [idBuyer], [Class])
VALUES
(1, 1, 1, N'������'),
(1, 2, 1, N'������'),
(1, 3, 1, N'������'),
(6, 1, 1, N'������'),
(6, 2, 1, N'������'),
(6, 3, 1, N'������'),
(10, 4, 2, N'������'),
(10, 5, 2, N'������');

COMMIT;
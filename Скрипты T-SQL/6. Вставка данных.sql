--Заполняем таблицы
USE Airport 
GO
BEGIN TRANSACTION;

--Заполняем страны
INSERT INTO [dbo].[Country] ([Name]) VALUES
(N'Российская Федерация'),
(N'Казахстан'),
(N'Япония'),
(N'Китай'),
(N'США');

--Заполняем города
INSERT INTO [dbo].[City] ([id], [idCountry], [Name], [Population], [GMT], [SignGMT]) VALUES
(1, 1, N'Новосибирск', 1500000, '07:00:00', '+'),
(2, 1, N'Москва', 8500000, '04:00:00', '+'),
(3, 2, N'Астана', 2000000, '06:00:00', '+'),
(4, 3, N'Токио', 10000000, '09:00:00', '+'),
(5, 4, N'Шанхай', 7000000, '08:00:00', '+'),
(6, 5, N'Лос-Анжелес', 8000000, '07:00:00', '-'),
(7, 1, N'Красноярск', 1000000, '08:00:00', '+'),
(8, 1, N'Урюпинск', 400000, '05:00:00', '+');

-- Заполняем аэропорты
INSERT INTO [dbo].[Airport] ([idCity], [Name]) VALUES
(1, N'Толмачево'),
(2, N'Шереметьево'),
(2, N'Домодедово'),
(2, N'Внуково'),
(3, N'Астаново'),
(5, N'Международный аэропорт Шанхая'),
(5, N'Внутренний аэропорт Шанхая'),
(6, N'Международный Аэропорт Лос-Анжелеса'),
(7, N'Емельяново'),
(2, N'Малый');

--Заполняем авиакомпании
INSERT INTO [dbo].[Aircompany] ([AircompanyName], [AircompanyPhone], [AircompanyAdress])
VALUES
(N'S7 Airlines', '+7 (383) 2237518', N'Где-то в Новосибирске'),
(N'Аэрофлот', '+7 (383) 2482938', N'Где-то в центральном районе'),
(N'Джек Воробей', '+7 (383) 2212121', N'У черта на куличках');

--Заполняем самолеты
INSERT INTO [dbo].[Plane] ([idAircompany], [PlaneModel], [PlaneNumber]) VALUES
(1, N'ИЛ-86', N'S7-IL86-293'),
(1, N'BOEING-747', N'S7-BOE747-492'),
(2, N'FELIX-F', N'AF-FELF-201'),
(2, N'VOLODYA', N'AF-VOL-184'),
(3, N'ТУ-160', N'JV-TU160-124'),
(3, N'MATIS-G6', N'JV-MATG6-134');
GO



--Заполняем рейсы
INSERT INTO [dbo].[Flight] 
([idAircompany], [idPlane], [idAirPort], [FlightType], [DateTimeStart], [Duration], [NumOfFlights], [Periodicity], [PriceEconom], [PriceBusiness], [PriceFirst])
VALUES
(1, 1, 2, N'Исходящий', '2012-14-06 07:00:00', '04:00:00', 5, '1900-02-01 00:00:00', 12400, 15000, 20000);

INSERT INTO [dbo].[Flight] 
([idAircompany], [idPlane], [idAirPort], [FlightType], [DateTimeStart], [Duration], [NumOfFlights], [Periodicity], [PriceEconom], [PriceBusiness], [PriceFirst])
VALUES
(1, 1, 3, N'Входящий', '2012-20-06 22:00:00', '04:00:00', 4, '1900-07-01 00:00:00', 12400, 15000, 20000);

INSERT INTO [dbo].[Flight] 
([idAircompany], [idPlane], [idAirPort], [FlightType], [DateTimeStart], [Duration], [NumOfFlights], [Periodicity], [PriceEconom], [PriceBusiness], [PriceFirst])
VALUES
(2, 3, 10, N'Исходящий', '2012-08-06 19:00:00', '06:00:00', 2, '1900-02-01 00:00:00', 20000, 21000, 22000);

INSERT INTO [dbo].[Flight] 
([idAircompany], [idPlane], [idAirPort], [FlightType], [DateTimeStart], [Duration], [NumOfFlights], [Periodicity], [PriceEconom], [PriceBusiness], [PriceFirst])
VALUES
(2, 3, 5, N'Входящий', '2012-08-06 05:00:00', '06:00:00', 1, '1900-01-01 00:00:00', 20000, 21000, 22000);

INSERT INTO [dbo].[Flight] 
([idAircompany], [idPlane], [idAirPort], [FlightType], [DateTimeStart], [Duration], [NumOfFlights], [Periodicity], [PriceEconom], [PriceBusiness], [PriceFirst])
VALUES
(2, 3, 7, N'Входящий', '2012-08-06 05:00:00', '06:00:00', 2, '1900-07-01 00:00:00', 20000, 21000, 22000);

--DELETE FROM [Flight] WHERE [id] <= 100;



--Заполняем события
INSERT INTO [dbo].[Events] ([idFlight], [EventType], [DateTimeEvent])
VALUES
(10, N'Вылетел', '2012-08-06 07:10:00');
INSERT INTO [dbo].[Events] ([idFlight], [EventType], [DateTimeEvent])
VALUES
(10, N'Прибыл', '2012-08-06 11:10:00');
INSERT INTO [dbo].[Events] ([idFlight], [EventType], [DateTimeEvent])
VALUES
(1, N'Вылетел', '2012-08-06 19:40:00');
INSERT INTO [dbo].[Events] ([idFlight], [EventType], [DateTimeEvent])
VALUES
(2, N'Вылетел', '2012-09-06 20:00:00');
INSERT INTO [dbo].[Events] ([idFlight], [EventType], [DateTimeEvent])
VALUES
(2, N'Прибыл', '2012-09-06 23:00:00');

INSERT INTO [dbo].[Events] ([idFlight], [EventType], [DateTimeEvent])
VALUES
(5, N'Вылетел', '2012-09-06 20:00:00');
GO
--DELETE FROM [DBO].[EVENTS] WHERE [ID] <= 100;


--Добавляем незапланированные события
INSERT INTO [dbo].[UnexpectedEvents] ([idFlight], [EventType], [DateTimeEvent], [Duration], [Reason])
VALUES
(3, N'Задерживается', '2012-07-08 12:35', '1900-02-01 00:00:00', N'Нелётная погода');

INSERT INTO [dbo].[UnexpectedEvents] ([idFlight], [EventType], [DateTimeEvent], [Duration], [Reason])
VALUES
(4, N'Отменён', '2012-27-05 16:15', NULL, N'Проблемы с законодательством');
GO


--Добавляем способы оплаты
INSERT INTO [dbo].[Payment] ([Name], [AddCost])
VALUES
(N'Кассы авиакомпаний', 0),
(N'Платёжная система PayPal', 0.05),
(N'Оплата курьеру', 0.1);
GO

--Заполняем виды документов, удостоверяющих личность
INSERT INTO [dbo].[DocType] ([Name], [Description], [RegularExpression])
VALUES
(N'Паспорт гражданина РФ', N'10 цифр: серия и номер слитно', N'[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]');

INSERT INTO [dbo].[DocType] ([Name], [Description], [RegularExpression])
VALUES
(N'Заграничный паспорт', N'11 цифр', N'[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]');
GO


--Заполняем данные о покупателях
INSERT INTO [dbo].[Buyer] ([idPayment], [LastName], [FirstName], [Phone], [AltPhone], [TimeToConnect], [DeliveryAdress])
VALUES
(1, N'Ежевикова', N'Виктория', N'+79230192857', NULL, N'Вечером, после 19', N'ул. Челюскинцев, 35, кв. 124'),
(1, N'Петросян', N'Евгений', N'+79135748383', NULL, N'После концерта', N'ул. Кривого зеркала');

--Заполняем данные о пассажирах
INSERT INTO [dbo].[Passengers] ([idDocType], [LastName], [FirstName], [BirthDate], [Gender], [DocNumber])
VALUES
(1, N'Полтарацкий', N'Константин', '1990-11-05', N'Мужской', N'5004630007');

INSERT INTO [dbo].[Passengers] ([idDocType], [LastName], [FirstName], [BirthDate], [Gender], [DocNumber])
VALUES
(1, N'Ежевикова', N'Виктория', '1990-10-15', N'Женский', N'5008392837');

INSERT INTO [dbo].[Passengers] ([idDocType], [LastName], [FirstName], [BirthDate], [Gender], [DocNumber])
VALUES
(2, N'Болгов', N'Станислав', '1985-12-23', N'Мужской', N'50204639307');

INSERT INTO [dbo].[Passengers] ([idDocType], [LastName], [FirstName], [BirthDate], [Gender], [DocNumber])
VALUES
(1, N'Медведев', N'Дмитрий', '1945-05-09', N'Мужской', N'5004630283');

INSERT INTO [dbo].[Passengers] ([idDocType], [LastName], [FirstName], [BirthDate], [Gender], [DocNumber])
VALUES
(1, N'Головач', N'Елена', '1991-10-07', N'Женский', N'5004672007');


--Заполняем данные о билетах
INSERT INTO [dbo].[Tickets] 
([idFlight], [idPassenger], [idBuyer], [Class])
VALUES
(1, 1, 1, N'Бизнес'),
(1, 2, 1, N'Бизнес'),
(1, 3, 1, N'Бизнес'),
(6, 1, 1, N'Первый'),
(6, 2, 1, N'Первый'),
(6, 3, 1, N'Первый'),
(10, 4, 2, N'Эконом'),
(10, 5, 2, N'Эконом');

COMMIT;
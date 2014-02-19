--Создание логина
USE [Airport] 
GO

GRANT EXECUTE ON "SelectFlights" TO "public";
GRANT EXECUTE ON "RefCountriesSelect" TO "public";
GRANT EXECUTE ON "SelectRefAirportListByCity" TO "public";
GRANT EXECUTE ON "RefSelectCitiesListByID" TO "public";
GRANT EXECUTE ON "SelectRefAircompaniesList" TO "public";
GRANT EXECUTE ON "SelectRefPlaneList" TO "public";
GRANT EXECUTE ON "GetAirport" TO "public";
GRANT EXECUTE ON "GetCity" TO "public";

CREATE ROLE "TopManagers"
CREATE ROLE "Dispatchers"
CREATE ROLE "AircompanyManager"
CREATE ROLE "TicketBuyer"

CREATE LOGIN "KPoltarackiy" WITH PASSWORD = 'junior';
CREATE USER "KPoltarackiy" FOR LOGIN "KPoltarackiy";

CREATE LOGIN "NikitaShetinin" WITH PASSWORD = 'junior';
CREATE USER "NikitaShetinin" FOR LOGIN "NikitaShetinin";

CREATE LOGIN "VladislavBoriskin" WITH PASSWORD = 'junior';
CREATE USER "VladislavBoriskin" FOR LOGIN "VladislavBoriskin";

CREATE LOGIN "AlexanderBorsh" WITH PASSWORD = 'junior';
CREATE USER "AlexanderBorsh" FOR LOGIN "AlexanderBorsh";

CREATE LOGIN "SergeyBushma" WITH PASSWORD = 'junior';
CREATE USER "SergeyBushma" FOR LOGIN "SergeyBushma";


EXEC sp_addrolemember @rolename = 'TopManagers', @membername = 'KPoltarackiy';
EXEC sp_addrolemember @rolename = 'Dispatchers', @membername = 'NikitaShetinin';
EXEC sp_addrolemember @rolename = 'Dispatchers', @membername = 'VladislavBoriskin';
EXEC sp_addrolemember @rolename = 'AircompanyManager', @membername = 'AlexanderBorsh';
EXEC sp_addrolemember @rolename = 'TicketBuyer', @membername = 'SergeyBushma';

--руководители
GRANT EXECUTE ON "AirCompanySelect" TO "TopManagers";
GRANT EXECUTE ON "AirCompanyInsert" TO "TopManagers";
GRANT EXECUTE ON "AirCompanyUpdate" TO "TopManagers";
GRANT EXECUTE ON "AirCompanyDelete" TO "TopManagers";

GRANT EXECUTE ON "CountriesSelect" TO "TopManagers";
GRANT EXECUTE ON "CountryInsert" TO "TopManagers";
GRANT EXECUTE ON "CountryUpdate" TO "TopManagers";
GRANT EXECUTE ON "CountryDelete" TO "TopManagers";
GRANT EXECUTE ON "GetCountry" TO "TopManagers";

GRANT EXECUTE ON "SelectCitiesList" TO "TopManagers";
GRANT EXECUTE ON "CityInsert" TO "TopManagers";
GRANT EXECUTE ON "CityUpdate" TO "TopManagers";
GRANT EXECUTE ON "CityDelete" TO "TopManagers";
GRANT EXECUTE ON "GetCity" TO "TopManagers";

GRANT EXECUTE ON "SelectAirPortList" TO "TopManagers";
GRANT EXECUTE ON "GetAirport" TO "TopManagers";
GRANT EXECUTE ON "DeleteAirport" TO "TopManagers";
GRANT EXECUTE ON "UpdateAirport" TO "TopManagers";
GRANT EXECUTE ON "InsertAirport" TO "TopManagers";

GRANT EXECUTE ON "SelectFlights" TO "TopManagers"


--Диспетчеры
GRANT EXECUTE ON "SelectFlights" TO "Dispatchers";
GRANT EXECUTE ON "GetFlightInfo" TO "Dispatchers";
GRANT EXECUTE ON "InsertFlight" TO "Dispatchers";
GRANT EXECUTE ON "UpdateFlight" TO "Dispatchers";
GRANT EXECUTE ON "DeleteFlight" TO "Dispatchers";

GRANT EXECUTE ON "SelectAirplaneList" TO "Dispatchers";
GRANT EXECUTE ON "GetPlaneInfo" TO "Dispatchers";

GRANT EXECUTE ON "AirCompanySelect" TO "Dispatchers";

GRANT EXECUTE ON "CountriesSelect" TO "Dispatchers";
GRANT EXECUTE ON "GetCountry" TO "Dispatchers";

GRANT EXECUTE ON "SelectCitiesList" TO "Dispatchers";
GRANT EXECUTE ON "GetCity" TO "Dispatchers";

GRANT EXECUTE ON "SelectAirPortList" TO "Dispatchers";
GRANT EXECUTE ON "GetAirport" TO "Dispatchers";


--Менеджеры авиакомпаний
GRANT EXECUTE ON "SelectFlights" TO "AircompanyManager";
GRANT EXECUTE ON "GetFlightInfo" TO "AircompanyManager";
GRANT EXECUTE ON "InsertFlight" TO "AircompanyManager";
GRANT EXECUTE ON "UpdateFlight" TO "AircompanyManager";
GRANT EXECUTE ON "DeleteFlight" TO "AircompanyManager";

GRANT EXECUTE ON "SelectAirplaneList"  TO "AircompanyManager";
GRANT EXECUTE ON "GetPlaneInfo" TO "AircompanyManager";
GRANT EXECUTE ON "UpdatePlane" TO "AircompanyManager";
GRANT EXECUTE ON "InsertPlane" TO "AircompanyManager";
GRANT EXECUTE ON "DeletePlane" TO "AircompanyManager";

GRANT EXECUTE ON "AirCompanySelect" TO "AircompanyManager";

GRANT EXECUTE ON "CountriesSelect" TO "AircompanyManager";
GRANT EXECUTE ON "GetCountry" TO "AircompanyManager";

GRANT EXECUTE ON "SelectCitiesList" TO "AircompanyManager";
GRANT EXECUTE ON "GetCity" TO "AircompanyManager";

GRANT EXECUTE ON "SelectAirPortList" TO "AircompanyManager";
GRANT EXECUTE ON "GetAirport" TO "AircompanyManager";


--Покупатели
GRANT EXECUTE ON "SelectFlights" TO "TicketBuyer";
GRANT EXECUTE ON "GetFlightInfo" TO "TicketBuyer";
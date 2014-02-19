airport
=======

В данном репозитории содержится исходный код курсовой работы по дисциплине "Операционные системы, базы данных и сетевые технологии", тема курсовой работы: "Проектирование базы данных для аэропорта".

Отчёт можно загрузить по ссылке https://github.com/Poltorackiy/airport/blob/master/Аэропорт.doc

В папке "Скрипты T-SQL" содержатся скрипты SQL, используемые в курсовой работе, в папке "Резервная копия БД" содержится готовая база данных для Microsoft SQL Server 2008 R2, в папке "Проект клиентского приложения" содержится проект Visual Studio. 

Для того, чтобы запустить приложение, понадобится .NET Framework версии 4.5
После открытия проекта необходимо отредактировать файл UserSettings.Settings, находящийся в решении AirportLibrary. В Visual Studio или в блокноте (формат XML) нужно отредактировать параметры "ServerName" - заполнить NetBIOS имя компьютера, а параметр "DBEngineName" - название экземпляра СУБД Microsoft SQL Server.

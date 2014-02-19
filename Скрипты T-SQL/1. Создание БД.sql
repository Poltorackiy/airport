USE [master]
GO

/****** Object:  Database [Airport]    Script Date: 06/07/2012 18:52:39 ******/
CREATE DATABASE [Airport] ON  PRIMARY 
( NAME = N'Airport', FILENAME = N'C:\Database\Airport.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Airport_log', FILENAME = N'C:\Database\Airport_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
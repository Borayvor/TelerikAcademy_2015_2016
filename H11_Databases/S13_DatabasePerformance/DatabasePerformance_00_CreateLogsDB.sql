-- Create Logs DB
USE master
GO

CREATE DATABASE LogsDB
GO

USE LogsDB
GO

CREATE TABLE Logs(LogID int NOT NULL PRIMARY KEY IDENTITY,
 LogDate datetime2(7), 
 LogText nvarchar(100))


-- Task 1
-- Create a table in SQL Server with 10 000 000 log entries (date + text).
-- Search in the table by date range. Check the speed (without caching).

INSERT INTO Logs(LogDate, LogText) VALUES ('1990-01-01', 'Sample log ');
--Insert records in the format Date | SampleLog1, Date | SampleLog2...
DECLARE @Counter int = 0
WHILE (SELECT COUNT(*) FROM Logs) < 11000000
BEGIN
INSERT INTO Logs(LogDate, LogText)
SELECT DATEADD(MONTH, @Counter + 3, LogDate), LogText + CONVERT(nvarchar, @Counter) FROM Logs
SET @Counter = @Counter + 1
END
--Empty the SQL Server cache
CHECKPOINT; DBCC DROPCLEANBUFFERS;
--Test search by date before adding index
SELECT LogText FROM Logs WHERE LogDate
BETWEEN CONVERT(datetime, '1990-01-01') AND CONVERT(datetime, '1995-01-01'); 

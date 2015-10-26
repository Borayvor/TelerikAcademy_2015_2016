-- Task 2
-- Add an index to speed-up the search by date. Test the search speed (after cleaning the cache).
-- Add a index to the date column
CREATE INDEX IDX_OnLogsDateColumn ON Logs(LogDate);
--Empty the SQL Server cache
CHECKPOINT; DBCC DROPCLEANBUFFERS;
--Test search by date after adding index
SELECT LogText FROM Logs WHERE LogDate
BETWEEN CONVERT(datetime2, '2013-07-19 11:59:21') AND CONVERT(datetime2, '2013-07-19 11:59:25'); 

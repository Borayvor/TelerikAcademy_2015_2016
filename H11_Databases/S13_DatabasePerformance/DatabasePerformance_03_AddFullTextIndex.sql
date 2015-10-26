-- Task 3
-- Add a full text index for the text column. Try to search with and without the full-text index and compare the speed.
CREATE FULLTEXT CATALOG LogsFullTextForLogText
WITH ACCENT_SENSITIVITY = OFF
CREATE FULLTEXT INDEX ON Logs(LogText)
KEY INDEX PK_Logs
ON LogsFullTextForLogText
WITH CHANGE_TRACKING AUTO
--Empty the SQL Server cache
CHECKPOINT; DBCC DROPCLEANBUFFERS;
--Search from full text
SELECT * FROM Logs
WHERE LogText LIKE '% 1256789'
--Empty the SQL Server cache
CHECKPOINT; DBCC DROPCLEANBUFFERS;
--Search from full text
SELECT * FROM Logs
WHERE CONTAINS(LogText,'1256789')

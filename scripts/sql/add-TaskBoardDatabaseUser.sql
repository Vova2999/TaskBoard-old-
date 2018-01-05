USE [master]
GO
IF SUSER_ID('TaskBoardDatabaseUser') IS NULL
BEGIN
	CREATE LOGIN [TaskBoardDatabaseUser] WITH PASSWORD='1230', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF;
END
USE [TaskBoardDatabase]
GO
IF USER_ID('TaskBoardDatabaseUser') IS NULL
BEGIN
	CREATE USER [TaskBoardDatabaseUser] FOR LOGIN [TaskBoardDatabaseUser]
	ALTER USER [TaskBoardDatabaseUser] WITH DEFAULT_SCHEMA=[dbo]
	ALTER ROLE [db_owner] ADD MEMBER [TaskBoardDatabaseUser]
END
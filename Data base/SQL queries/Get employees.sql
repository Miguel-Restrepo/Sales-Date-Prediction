--Get employees
USE [StoreSample]
GO

SELECT [empid] AS Empid
      ,[lastname] + ' ' + [firstname] AS FullName
  FROM [HR].[Employees]

GO



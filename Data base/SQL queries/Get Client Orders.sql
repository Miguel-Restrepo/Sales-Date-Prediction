--Get Client Orders
USE [StoreSample]
GO

SELECT o.[orderid] AS Orderid
      ,o.[requireddate] AS Requireddate
      ,o.[shippeddate] AS Shippeddate
      ,o.[shipname] AS Shipname
      ,o.[shipaddress] AS Shipaddress
      ,o.[shipcity] AS Shipcity
  FROM 
   [Sales].[Customers] c
JOIN 
    [Sales].[Orders] o ON c.[custid] = o.[custid]
	Where 
	c.[custid] = 1

GO



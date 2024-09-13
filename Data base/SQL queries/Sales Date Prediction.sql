--Sales Date PredictionWITH OrderIntervals AS (
    SELECT 
        o.[custid],
        DATEDIFF(DAY, LAG(o.OrderDate) OVER (PARTITION BY o.[custid] ORDER BY o.[orderdate]), o.[orderdate]) AS DaysBetweenOrders
    FROM 
        [Sales].[Orders] o
)
SELECT 
    c.[companyname],
    MAX(o.[orderdate]) AS LastOrderDate,
    DATEADD(DAY, AVG(oi.[DaysBetweenOrders]), MAX(o.[orderdate])) AS NextPredictedOrder
FROM 
    [Sales].[Customers] c
JOIN 
    [Sales].[Orders] o ON c.[custid] = o.[custid]
LEFT JOIN 
    OrderIntervals oi ON o.[custid] = oi.[custid]
GROUP BY 
    c.[companyname], o.[custid]
HAVING 
    COUNT(o.[orderid]) > 1;

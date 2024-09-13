--Add New Order
BEGIN TRANSACTION;

DECLARE @OrderID INT;

INSERT INTO [Sales].[Orders] (Empid, Shipperid, Shipname, Shipaddress, Shipcity, Orderdate, Requireddate, Shippeddate, Freight, Shipcountry)
VALUES (
    1, -- Empid
    2, -- Shipperid
    'John Doe', -- Shipname
    '123 Shipping St.', -- Shipaddress
    'New York', -- Shipcity
    GETDATE(), -- Orderdate
    DATEADD(DAY, 7, GETDATE()), -- Requireddate
    NULL, -- Shippeddate
    50.00, -- Freight
    'USA' -- Shipcountry
);

-- Get ID new order
SET @OrderID = SCOPE_IDENTITY();

-- 2. Insert  product in OrderDetails 
INSERT INTO [Sales].[OrderDetails] (Orderid, Productid, Unitprice, Qty, Discount)
VALUES (
    @OrderID, -- ID 
    59, -- Productid
    20.00, -- Unitprice 
    5, -- Qty 
    0.10 -- Discount 
);

COMMIT TRANSACTION;

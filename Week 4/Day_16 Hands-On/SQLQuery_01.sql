
-- Problem 1 

-- Stored Procedure – Total Sales Per Store

CREATE PROCEDURE sp_TotalSalesPerStore
@StoreID INT = NULL
AS
BEGIN
SELECT 
s.store_id,
SUM(oi.quantity * oi.list_price) AS TotalSales
FROM orders o
JOIN order_items oi
ON o.order_id = oi.order_id
JOIN stores s
ON o.store_id = s.store_id
WHERE (@StoreID IS NULL OR s.store_id = @StoreID)
GROUP BY s.store_id
END;

EXEC sp_TotalSalesPerStore

GO

-- Orders by Date Range

CREATE PROCEDURE sp_GetOrdersByDate
@StartDate DATE,
@EndDate DATE
AS
BEGIN
SELECT *
FROM orders
WHERE order_date BETWEEN @StartDate AND @EndDate
END;

EXEC sp_GetOrdersByDate '2024-01-01','2024-12-31'


-- Calculate Discount


CREATE FUNCTION fn_CalculateDiscount
(
@Price DECIMAL(10,2),
@Discount DECIMAL(5,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN

DECLARE @FinalPrice DECIMAL(10,2)

SET @FinalPrice = @Price - (@Price * @Discount)

RETURN @FinalPrice

END;

SELECT dbo.fn_CalculateDiscount(1000,0.10) AS FinalPrice

-- Top 5 Selling Products
CREATE FUNCTION fn_TopSellingProducts()
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 5
        p.product_name,
        SUM(oi.quantity) AS TotalSold
    FROM order_items oi
    JOIN products p
    ON oi.product_id = p.product_id
    GROUP BY p.product_name
    ORDER BY TotalSold DESC
)

SELECT * FROM dbo.fn_TopSellingProducts()
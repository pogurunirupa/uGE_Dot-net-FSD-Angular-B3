
-- Problem 4 – Cursor Based Revenue Calculation

BEGIN TRY

BEGIN TRANSACTION

DECLARE @OrderID INT
DECLARE @StoreID INT
DECLARE @Revenue DECIMAL(10,2)

CREATE TABLE #RevenueTemp
(
    store_id INT,
    order_id INT,
    revenue DECIMAL(10,2)
)

DECLARE OrderCursor CURSOR FOR
SELECT order_id, store_id
FROM orders
WHERE order_status = 4

OPEN OrderCursor

FETCH NEXT FROM OrderCursor INTO @OrderID, @StoreID

WHILE @@FETCH_STATUS = 0
BEGIN

    SELECT @Revenue = SUM(quantity * list_price * (1-discount))
    FROM order_items
    WHERE order_id = @OrderID

    INSERT INTO #RevenueTemp
    VALUES(@StoreID, @OrderID, @Revenue)

    FETCH NEXT FROM OrderCursor INTO @OrderID, @StoreID

END

CLOSE OrderCursor
DEALLOCATE OrderCursor

SELECT store_id,
SUM(revenue) AS TotalRevenue
FROM #RevenueTemp
GROUP BY store_id

COMMIT TRANSACTION

END TRY

BEGIN CATCH
ROLLBACK TRANSACTION
PRINT ERROR_MESSAGE()
END CATCH
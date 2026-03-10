
-- Problem 2: Atomic Order Cancellation with SAVEPOINT

-- Stored Procedure for Order Cancellation 

DECLARE @order_id INT
SET @order_id = 1  

BEGIN TRY

BEGIN TRANSACTION


SAVE TRANSACTION RestorePoint


UPDATE s
SET s.quantity = s.quantity + oi.quantity
FROM stocks s
JOIN order_items oi
ON s.product_id = oi.product_id
WHERE oi.order_id = @order_id


UPDATE orders
SET order_status = 3
WHERE order_id = @order_id

COMMIT TRANSACTION

PRINT 'Order cancelled successfully'

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION RestorePoint

PRINT 'Error occurred during cancellation'

END CATCH


SELECT * FROM orders;
SELECT * FROM order_items;
SELECT * FROM stocks;
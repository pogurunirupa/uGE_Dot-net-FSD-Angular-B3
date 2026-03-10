USE RetailDB;
GO
-- Problem 1: Transactions and Trigger Implementation

-- Trigger to Reduce Stock Automatically

CREATE TRIGGER trg_reduce_stock
ON order_items
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    
    IF EXISTS (
        SELECT 1
        FROM stocks s
        JOIN inserted i ON s.product_id = i.product_id
        WHERE s.quantity < i.quantity
    )
    BEGIN
        RAISERROR('Insufficient stock available',16,1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

  
    UPDATE s
    SET s.quantity = s.quantity - i.quantity
    FROM stocks s
    JOIN inserted i
    ON s.product_id = i.product_id;
END



BEGIN TRY

BEGIN TRANSACTION

-- Insert order
INSERT INTO orders (order_status)
VALUES (1)

DECLARE @order_id INT
SET @order_id = SCOPE_IDENTITY()

-- Insert order items
INSERT INTO order_items
(order_id, product_id, quantity, list_price, discount)
VALUES
(@order_id, 1, 2, 5000, 0),
(@order_id, 2, 1, 3000, 0)

COMMIT TRANSACTION

PRINT 'Order placed successfully'

END TRY

BEGIN CATCH
    ROLLBACK TRANSACTION
    PRINT 'Transaction Failed'
END CATCH

SELECT * FROM orders;

SELECT * FROM order_items;

SELECT * FROM stocks;
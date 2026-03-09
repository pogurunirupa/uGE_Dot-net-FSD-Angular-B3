-- Problem 2 – Stock Auto Update Trigger

CREATE TRIGGER trg_UpdateStock
ON order_items
AFTER INSERT
AS
BEGIN
    BEGIN TRY

        IF EXISTS (
            SELECT 1
            FROM stocks s
            JOIN inserted i ON s.product_id = i.product_id
            WHERE s.quantity < i.quantity
        )
        BEGIN
            RAISERROR('Insufficient stock available.',16,1)
            ROLLBACK TRANSACTION
            RETURN
        END

        UPDATE s
        SET s.quantity = s.quantity - i.quantity
        FROM stocks s
        JOIN inserted i
        ON s.product_id = i.product_id

    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION
        THROW
    END CATCH
END
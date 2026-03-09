
-- Problem 3 – Order Status Validation Trigger

CREATE TRIGGER trg_OrderStatusValidation
ON orders
AFTER UPDATE
AS
BEGIN
    BEGIN TRY

        IF EXISTS (
            SELECT 1
            FROM inserted
            WHERE order_status = 4
            AND shipped_date IS NULL
        )
        BEGIN
            RAISERROR('Shipped date must be provided when order is completed.',16,1)
            ROLLBACK TRANSACTION
        END

    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION
        THROW
    END CATCH
END
CREATE DATABASE BookStoreDb;

USE BookStoreDb;

CREATE TABLE Books (
    BookID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(150) NOT NULL,
    Stock INT NOT NULL CHECK (Stock >= 0),
    Price DECIMAL(10,2) NOT NULL
);

CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    BookID INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    OrderDate DATETIME2 DEFAULT SYSDATETIME(),
    FOREIGN KEY (BookID) REFERENCES Books(BookID)
);

GO

-- Task 1 – Stored Procedure to Add New Book

CREATE PROCEDURE sp_AddNewBook
    @Title NVARCHAR(150),
    @Stock INT,
    @Price DECIMAL(10,2)
AS
BEGIN
    BEGIN TRY

        INSERT INTO Books (Title, Stock, Price)
        VALUES (@Title, @Stock, @Price);

        PRINT 'Book added successfully.';

    END TRY

    BEGIN CATCH

        PRINT 'Error occurred while adding book.';
        PRINT ERROR_MESSAGE();

    END CATCH
END;

GO

-- Task 2 – Main Stored Procedure - Place Order with Transaction

CREATE PROCEDURE sp_PlaceOrder
    @BookID INT,
    @Quantity INT
AS
BEGIN

    SET XACT_ABORT ON;

    BEGIN TRY

        BEGIN TRANSACTION;

        -- Check stock availability
        IF NOT EXISTS (
            SELECT 1 FROM Books 
            WHERE BookID = @BookID 
            AND Stock >= @Quantity
        )
        BEGIN
            RAISERROR('Not enough stock or book not found.',16,1);
        END

        -- Reduce stock
        UPDATE Books
        SET Stock = Stock - @Quantity
        WHERE BookID = @BookID;

        -- Insert order
        INSERT INTO Orders (BookID, Quantity)
        VALUES (@BookID, @Quantity);

        COMMIT TRANSACTION;

        PRINT 'Order placed successfully.';

    END TRY

    BEGIN CATCH

        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        PRINT 'Error ' + CAST(ERROR_NUMBER() AS VARCHAR) + ': ' + ERROR_MESSAGE();

    END CATCH

END;

-- Task 3: Testing & Output

-- Inserting Sample Books

EXEC sp_AddNewBook 'SQL Basics', 10, 450;
EXEC sp_AddNewBook 'C# Programming', 8, 550;
EXEC sp_AddNewBook 'Web Development', 5, 600;
EXEC sp_AddNewBook 'Data Structures', 3, 700;

SELECT * FROM Books;

-- Case 1 – Successful Order

EXEC sp_PlaceOrder 1, 2;

SELECT * FROM Books;
SELECT * FROM Orders;

-- Case 2 – Insufficient Stock

EXEC sp_PlaceOrder 4, 10;

-- Case 3 – Invalid BookID

EXEC sp_PlaceOrder 100, 1;

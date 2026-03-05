
-- Problem 1 – Product Analysis Using Nested Queries

USE AutoDB;

SELECT 
    product_name + ' (' + CAST(model_year AS VARCHAR) + ')' AS Product_Info,
    list_price,
    
    list_price -
    (
        SELECT AVG(list_price)
        FROM products p2
        WHERE p2.category_id = p1.category_id
    ) AS Price_Difference

FROM products p1

WHERE list_price >
(
    SELECT AVG(list_price)
    FROM products p2
    WHERE p2.category_id = p1.category_id
);
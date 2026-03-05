
-- Problem 2 – Customer Activity Classification

USE AutoDB;

SELECT 
    c.first_name + ' ' + c.last_name AS Customer_Name,
    total_amount,
    
    CASE
        WHEN total_amount > 10000 THEN 'Premium'
        WHEN total_amount BETWEEN 5000 AND 10000 THEN 'Regular'
        ELSE 'Basic'
    END AS Customer_Type

FROM customers c
JOIN
(
    SELECT o.customer_id,
           SUM(quantity * list_price - discount) AS total_amount
    FROM orders o
    JOIN order_items oi
    ON o.order_id = oi.order_id
    GROUP BY o.customer_id
) AS customer_total

ON c.customer_id = customer_total.customer_id

UNION

SELECT
    first_name + ' ' + last_name,
    NULL,
    'No Orders'
FROM customers
WHERE customer_id NOT IN
(
    SELECT customer_id FROM orders
);
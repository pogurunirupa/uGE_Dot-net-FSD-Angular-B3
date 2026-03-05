
--Problem 4 – Order Cleanup and Data Maintenance

-- To Create Archive Table
CREATE TABLE archived_orders
(
order_id INT,
customer_id INT,
order_date DATE,
order_status INT
);
-- For Insert old orders

INSERT INTO archived_orders
SELECT order_id, customer_id, order_date, order_status
FROM orders
WHERE order_status = 3;

-- For Delete old rejected orders

DELETE FROM orders
WHERE order_status = 3
AND order_date < DATEADD(YEAR,-1,GETDATE());

-- for Order Delay

SELECT 
order_id,
DATEDIFF(day,order_date,shipped_date) AS Delay_Days,

CASE
WHEN shipped_date > required_date THEN 'Delayed'
ELSE 'On Time'
END AS Status

FROM orders;
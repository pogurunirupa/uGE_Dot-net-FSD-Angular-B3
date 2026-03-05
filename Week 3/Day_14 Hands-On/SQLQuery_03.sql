
--Problem 3 – Store Performance and Stock Validation

USE AutoDB;

SELECT 
    s.store_name,
    p.product_name,
    SUM(oi.quantity) AS Total_Sold,
    SUM(oi.quantity * oi.list_price - oi.discount) AS Revenue

FROM order_items oi
JOIN products p
ON oi.product_id = p.product_id

JOIN stocks st
ON st.product_id = p.product_id

JOIN stores s
ON s.store_id = st.store_id

GROUP BY s.store_name, p.product_name;
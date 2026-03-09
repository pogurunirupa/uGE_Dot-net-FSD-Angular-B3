
CREATE DATABASE RetailDB;

USE RetailDB;


CREATE TABLE stores(
store_id INT PRIMARY KEY,
store_name VARCHAR(100)
);


CREATE TABLE products(
product_id INT PRIMARY KEY,
product_name VARCHAR(100)
);


CREATE TABLE stocks(
product_id INT,
store_id INT,
quantity INT,
PRIMARY KEY(product_id,store_id)
);


CREATE TABLE orders(
order_id INT PRIMARY KEY,
store_id INT,
order_date DATE,
shipped_date DATE NULL,
order_status INT
);


CREATE TABLE order_items(
order_id INT,
item_id INT,
product_id INT,
quantity INT,
list_price DECIMAL(10,2),
discount DECIMAL(5,2),
PRIMARY KEY(order_id,item_id)
);


INSERT INTO stores VALUES
(1,'Hyderabad Store'),
(2,'Vizag Store');


INSERT INTO products VALUES
(101,'Laptop'),
(102,'Mobile'),
(103,'Headphones'),
(104,'Keyboard'),
(105,'Mouse');


INSERT INTO stocks VALUES
(101,1,50),
(102,1,100),
(103,1,80),
(104,2,60),
(105,2,120);


INSERT INTO orders VALUES
(1,1,'2024-01-10','2024-01-12',4),
(2,1,'2024-02-15',NULL,1),
(3,2,'2024-03-01','2024-03-05',4);


INSERT INTO order_items VALUES
(1,1,101,2,50000,0.10),
(1,2,103,1,2000,0.05),
(3,1,102,3,20000,0.15);
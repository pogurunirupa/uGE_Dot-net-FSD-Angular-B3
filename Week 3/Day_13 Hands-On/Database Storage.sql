CREATE DATABASE StoreDB;

USE StoreDB;

CREATE TABLE customers (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50)
);

CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100)
);

CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    store_id INT,
    order_date DATE,
    order_status INT,
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

CREATE TABLE brands (
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(100)
);

CREATE TABLE categories (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(100)
);

CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    brand_id INT,
    category_id INT,
    model_year INT,
    list_price DECIMAL(10,2),
    FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

CREATE TABLE order_items (
    order_id INT,
    product_id INT,
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(4,2),
    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

CREATE TABLE stocks (
    store_id INT,
    product_id INT,
    quantity INT,
    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

INSERT INTO customers VALUES
(1, 'Nirupa', 'Poguru'),
(2, 'Charan', 'Royal');

INSERT INTO stores VALUES
(1, 'Bangalore Store'),
(2, 'Hyderabad Store');

INSERT INTO brands VALUES
(1, 'dressberry'),
(2, 'H&M');

INSERT INTO categories VALUES
(1, 'Accessories'),
(2, 'Clothing');

INSERT INTO products VALUES
(1, 'HandBag', 1, 1, 2023, 600),
(2, 'Women Jeans', 2, 2, 2024, 400);

INSERT INTO orders VALUES
(1, 1, 1, '2025-03-01', 4),
(2, 2, 2, '2025-03-03', 1);

INSERT INTO order_items VALUES
(1, 1, 2, 600, 0.10),
(2, 2, 1, 400, 0.00);

INSERT INTO stocks VALUES
(1, 1, 50),
(2, 2, 30);


CREATE DATABASE EcommDb;

USE EcommDb;


CREATE TABLE categories (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(50)
);



CREATE TABLE brands (
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(50)
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

CREATE TABLE customers (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    city VARCHAR(50)
);

CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100),
    city VARCHAR(50)
);

CREATE TABLE staffs (
    staff_id INT PRIMARY KEY,
    staff_name VARCHAR(100),
    store_id INT,

    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    store_id INT,
    staff_id INT,
    order_date DATE,

    FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (staff_id) REFERENCES staffs(staff_id)
);

INSERT INTO categories VALUES
(1,'Cars'),
(2,'Bikes'),
(3,'Trucks'),
(4,'Electric Vehicles'),
(5,'SUV');

INSERT INTO brands VALUES
(1,'Toyota'),
(2,'Honda'),
(3,'Tesla'),
(4,'Ford'),
(5,'BMW');

INSERT INTO products VALUES
(1,'Toyota Corolla',1,1,2022,20000),
(2,'Honda Civic',2,1,2023,22000),
(3,'Tesla Model 3',3,4,2024,40000),
(4,'Ford F150',4,3,2021,35000),
(5,'BMW X5',5,5,2022,60000);

INSERT INTO customers VALUES
(1,'Rahul','Sharma','Hyderabad'),
(2,'Anita','Reddy','Chennai'),
(3,'Kiran','Kumar','Hyderabad'),
(4,'Sneha','Patel','Mumbai'),
(5,'Vikram','Singh','Delhi');

INSERT INTO stores VALUES
(1,'AutoHub','Hyderabad'),
(2,'CarZone','Chennai'),
(3,'DriveWorld','Mumbai'),
(4,'MotorMart','Delhi'),
(5,'SpeedAuto','Bangalore');

INSERT INTO staffs VALUES
(1,'Amit',1),
(2,'Ravi',2),
(3,'Priya',3),
(4,'Karthik',4),
(5,'Neha',5);

INSERT INTO orders VALUES
(1,1,1,1,'2024-01-10'),
(2,2,2,2,'2024-02-15'),
(3,3,1,1,'2024-03-05'),
(4,4,3,3,'2024-03-20'),
(5,5,4,4,'2024-04-01');
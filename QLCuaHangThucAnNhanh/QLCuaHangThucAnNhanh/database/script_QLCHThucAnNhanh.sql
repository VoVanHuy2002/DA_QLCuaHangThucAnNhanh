USE master;
GO
DROP DATABASE QLCuaHangThucAnNhanh;
GO
CREATE DATABASE QLCuaHangThucAnNhanh;
GO
USE QLCuaHangThucAnNhanh;
GO
CREATE TABLE roles
(
    role_id   INT PRIMARY KEY IDENTITY,
    role_name NVARCHAR(255) NOT NULL
);
INSERT INTO roles(role_name)
VALUES (N'Chủ cửa hàng'),
       (N'Nhân viên pha chế'),
       (N'Nhân viên order'),
	   (N'Nhân viên thu ngân');
GO
CREATE TABLE user_account
(
    user_id   INT PRIMARY KEY IDENTITY,
    username  VARCHAR(255)  NOT NULL,
    password  VARCHAR(255)  NOT NULL,
    full_name NVARCHAR(255) NULL,
    gender    NVARCHAR(50)  NULL,
    age       INT           NULL,
    address   NVARCHAR(500) NULL,
    phone     NVARCHAR(20)  NULL,
    role_id   INT           NULL,
    status    VARCHAR(100) DEFAULT 'ACTIVE',
    CONSTRAINT fk_user_role FOREIGN KEY (role_id) REFERENCES roles (role_id),
    CONSTRAINT ck_gender CHECK (gender IN ('Nam', N'Nữ')),
    CONSTRAINT ck_status_userAccount CHECK (status IN ('ACTIVE', 'INACTIVE'))
);
INSERT INTO user_account(username, password, role_id)
VALUES ('admin', '1234qwer', 1);
INSERT INTO user_account(username, full_name, password, role_id, gender)
VALUES ('huy123', N'Lê Văn Huy' ,'1234qwer', 2, 'Nam');
INSERT INTO user_account(username, full_name, password, role_id, gender)
VALUES ('huyenvu', N'Vũ Thị Khánh Huyền' ,'1234qwer', 3, N'Nữ');
INSERT INTO user_account(username, full_name, password, role_id, gender)
VALUES ('hoadtp', N'Đào Thị Phương hoa' ,'1234qwer', 4, N'Nữ');

GO
CREATE TABLE table_order
(
	table_id INT PRIMARY KEY IDENTITY,
	table_name NVARCHAR(100) NOT NULL,
	description NVARCHAR(MAX) NULL,
	available VARCHAR(100) DEFAULT 'YES',
	status VARCHAR(100) DEFAULT 'ACTIVE',
	CONSTRAINT ck_status_table CHECK (status IN ('ACTIVE', 'INACTIVE')),
	CONSTRAINT ck_avaiable CHECK(available IN ('YES', 'NO'))
);

GO
CREATE TABLE food
(
	food_id INT PRIMARY KEY IDENTITY,
	food_name NVARCHAR(255) NOT NULL,
	food_image NVARCHAR(MAX) NULL,
	food_image_adr NVARCHAR(MAX) NULL,
	price FLOAT NULL,
	description NVARCHAR(MAX) NULL,
	status VARCHAR(100) DEFAULT 'ACTIVE',
	CONSTRAINT ck_status_food CHECK (status IN ('ACTIVE', 'INACTIVE')) 
);
GO
INSERT INTO food(food_name, price) VALUES (N'Đùi gà rán', '35000');  -- 1
INSERT INTO food(food_name, price) VALUES (N'Cánh gà rán', '25000');  -- 2
INSERT INTO food(food_name, price) VALUES (N'Đùi gà rán 1/4', '45000'); --3
INSERT INTO food(food_name, price) VALUES (N'Combo 3 cánh gà', '55000'); --4
INSERT INTO food(food_name, price) VALUES (N'Khoai tây chiên', '20000'); --5
INSERT INTO food(food_name, price) VALUES (N'Coca cola', '15000');  --6
INSERT INTO food(food_name, price) VALUES (N'Hambergur trứng', '25000');
INSERT INTO food(food_name, price) VALUES (N'Hambergur bò', '35000'); --8

GO
CREATE TABLE customer
(
	customer_id INT PRIMARY KEY IDENTITY,
	customer_name NVARCHAR(255) NOT NULL,
	phone VARCHAR(20) UNIQUE NOT NULL, 
	point FLOAT DEFAULT 0,
	status VARCHAR(100) DEFAULT 'ACTIVE',
	CONSTRAINT ck_status_customer CHECK (status IN ('ACTIVE', 'INACTIVE'))
);
GO
INSERT INTO customer(customer_name, phone) VALUES (N'Lê Văn Huy', '0339646858');
INSERT INTO customer(customer_name, phone) VALUES (N'Trần Thị Hà Linh', '0978646859');
INSERT INTO customer(customer_name, phone) VALUES (N'Hà Thị Tường Vi', '0376522343');
INSERT INTO customer(customer_name, phone) VALUES (N'Ngô Văn Lượng', '0522333565');
INSERT INTO customer(customer_name, phone) VALUES (N'Hứa Văn Mai', '0988333115');
INSERT INTO customer(customer_name, phone) VALUES (N'Bành Thị Bưởi', '0565898787');

GO
CREATE TABLE orders
(
	order_id INT PRIMARY KEY IDENTITY,
	customer_id INT,
	table_id INT,
	employe_id INT,
	total FLOAT,	-- so tien tong
	discount FLOAT,		-- % bill		0 -> 100%
	net_total FLOAT DEFAULT 0, -- so tien khach hang phai tinh		--> 10.000d : 1đ
	date_buy DATETIME DEFAULT GETDATE(),
	status NVARCHAR(100) DEFAULT 'PENDING',
	progress NVARCHAR(100) DEFAULT 'WAITING',
	CONSTRAINT ck_status_order CHECK (status IN ('PENDING', 'CANCEL' ,'CASH', 'BANK')),
	CONSTRAINT ck_progress CHECK (progress IN ('WAITING', 'IN PROGRESS', 'DONE')),
	CONSTRAINT fk_order_customer FOREIGN KEY(customer_id) REFERENCES customer(customer_id),
	CONSTRAINT fk_order_table FOREIGN KEY(table_id) REFERENCES table_order(table_id),
	CONSTRAINT fk_order_employee FOREIGN KEY(employe_id) REFERENCES user_account(user_id)
	-- pending: chua tinh tien, 
	-- Cancel: Khach huy don
	-- cash: thanh toan tien mat, 
	-- bank: thanh toan chuyen khoan online(momo, bank, vnpay...)
);
GO
CREATE TABLE order_items
(
	order_item_id INT PRIMARY KEY IDENTITY,
	order_id INT,
	food_id INT,
	quantity INT,
	total FLOAT,
	CONSTRAINT fk_orderItem_order FOREIGN KEY(order_id) REFERENCES orders(order_id),
	CONSTRAINT fk_orderItem_food FOREIGN KEY(food_id) REFERENCES food(food_id)
);
GO
DECLARE @i INT;
SET @i = 1;
WHILE @i < 30
BEGIN
	INSERT INTO table_order(table_name) VALUES(CAST(@i AS VARCHAR(10)));
	SET @i = @i + 1;
END;
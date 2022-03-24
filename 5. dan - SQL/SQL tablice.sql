CREATE TABLE Employee
(
Id INT,
FirstName VARCHAR(30),
LastName VARCHAR(30),
EmploymentStatus BIT,
Gender CHAR(1),
CONSTRAINT PkEmployee PRIMARY KEY(Id),
CONSTRAINT CheckGenderInput CHECK (Gender IN('M','F'))	
);


--CREATE DATABASE vjezba;

--DROP DATABASE vjezba;

CREATE TABLE Product
(
Price DECIMAL(10,2),
Title VARCHAR(30),
Id UNIQUEIDENTIFIER default NEWID(),
Stock INT, 
CountryOfOrigin VARCHAR(50),
CONSTRAINT PkProduct PRIMARY KEY(Id),
CONSTRAINT CheckStockInput CHECK (Stock>0)
);


CREATE TABLE Receipt
(
ReceiptNumber INT,
PurchasedProduct UNIQUEIDENTIFIER,
TimeOfPurchase DATETIME default GETDATE(),
EmployeeId INT, 
CONSTRAINT PkReceipt PRIMARY KEY(ReceiptNumber),
CONSTRAINT FkReceipt FOREIGN KEY(PurchasedProduct) REFERENCES product(Id),
CONSTRAINT FkEmployeeId FOREIGN KEY(EmployeeId) REFERENCES employee(Id)
);


INSERT INTO Receipt (ReceiptNumber, PurchasedProduct, EmployeeId) VALUES('45', '725018C6-2B1B-41F8-A3E8-17A55C709535', '3');

INSERT INTO Receipt (ReceiptNumber, PurchasedProduct, EmployeeId) VALUES('13', '3862D277-521E-4FFD-8DDE-4E5C2EC12AA8', '2');

INSERT INTO Receipt (ReceiptNumber, PurchasedProduct, EmployeeId) VALUES('16', '3862D277-521E-4FFD-8DDE-4E5C2EC12AA8', '1');

ALTER TABLE Receipt ADD PaymentMethod VARCHAR(10);

ALTER TABLE Employee ADD DateOfBirth DATETIME;

ALTER TABLE Receipt DROP COLUMN PaymentMethod;

ALTER TABLE Receipt ADD CONSTRAINT CheckPaymentMethodInput CHECK (PaymentMethod IN ('CASH', 'CARD'));

INSERT INTO Employee VALUES(
'1',
'Hrvoje',
'Horvat',
'TRUE',
'M'
);

INSERT INTO Employee VALUES(
'2','Marko', 'Maric','FALSE','M'),
('3', 'Ivana', 'Ivic', 'TRUE','F');

INSERT INTO Product (Price,Title,Stock,CountryOfOrigin)VALUES(
'59.99',
'Keyboard',
'150',	
'Switzerland'
);

INSERT INTO Product (Price,Title,Stock,CountryOfOrigin)VALUES(
'35.00',
'Mouse',
'60',
'France'
);


SELECT* FROM Product;

SELECT * FROM Receipt;

Select * FROM Employee;

SELECT* FROM Employee WHERE Gender='M';

UPDATE Employee SET EmploymentStatus = 'TRUE' WHERE Id='2';

DELETE FROM Employee WHERE	EmploymentStatus = 'FALSE';

SELECT DISTINCT LastName FROM Employee ORDER BY LastName ASC;

SELECT Receipt.ReceiptNumber, Product.Price, Product.Title, Receipt.TimeOfPurchase
FROM Product
INNER JOIN Receipt
ON Product.Id=Receipt.PurchasedProduct;

SELECT Employee.FirstName, Employee.LastName, Receipt.ReceiptNumber
FROM Employee
FULL OUTER JOIN Receipt ON Employee.Id=Receipt.EmployeeId
ORDER BY ReceiptNumber DESC;

SELECT Price FROM Product GROUP BY Price HAVING Price > 40;
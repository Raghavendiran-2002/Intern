Create database dbEmployeeTracker;

use dbEmployeeTracker;




CREATE TABLE DEPARTMENT ( deptname VARCHAR(30) CONSTRAINT pk_dept PRIMARY KEY, deptfloor INT, deptphone VARCHAR(10), managerid INT NOT NULL)

CREATE TABLE EMP ( empno INT IDENTITY(1,1) CONSTRAINT pk_empid  PRIMARY KEY, empname VARCHAR(30), salary FLOAT, deptname VARCHAR(30) CONSTRAINT fk_dept FOREIGN KEY REFERENCES  DEPARTMENT(deptname),bossno INT CONSTRAINT fk_boss_no FOREIGN KEY(bossno) REFERENCES EMP(empno))

CREATE TABLE ITEM(itemname VARCHAR(50) PRIMARY KEY, itemtype VARCHAR(40), itemcolor VARCHAR(40))

ALTER TABLE DEPARTMENT ADD CONSTRAINT fk_emp FOREIGN KEY (managerid) REFERENCES EMP(empno);

CREATE TABLE SALES (salesno INT PRIMARY KEY, saleqty INT, itemname VARCHAR(50) NOT NULL CONSTRAINT fk_itemname FOREIGN KEY  REFERENCES ITEM(itemname), deptname VARCHAR(30) NOT NULL CONSTRAINT fk_deptsales FOREIGN KEY REFERENCES DEPARTMENT(deptname))


sp_help DEPARTMENT
sp_help EMP
sp_help ITEM
sp_help SALES

DROP TABLE SALES
DROP TABLE ITEM
DROP TABLE EMP
ALTER TABLE EMP DROP CONSTRAINT fk_emp
DROP TABLE DEPARTMENT


INSERT INTO EMP (empno, empname, salary, deptname, bossno) VALUES (1, 'Alice', 75000, NULL, NULL),    (2, 'Ned', 45000, NULL, 1),    (3, 'Andrew', 25000, NULL, 2),    (4, 'Clare', 22000, NULL, 2),    (5, 'Todd', 38000, NULL, 1),    (6, 'Nancy', 22000, NULL, 5),    (7, 'Brier', 43000, NULL, 1),    (8, 'Sarah', 56000, NULL, 7),    (9, 'Sophile', 35000, NULL, 1),    (10, 'Sanjay', 15000, NULL, 3),    (11, 'Rita', 15000, NULL, 4),    (12, 'Gigi', 16000, NULL, 4),    (13, 'Maggie', 11000, NULL, 4),    (14, 'Paul', 15000, NULL, 3),    (15, 'James', 15000, NULL, 3),   (16, 'Pat', 15000, NULL, 3), (17, 'Mark', 15000, NULL, 3);

select * from EMP;

INSERT INTO DEPARTMENT (deptname, dfloor, dphone, managerid) VALUES    ('Management', 5, '34', 1),    ('Books', 1, '81', 4),    ('Clothes', 2, '24', 4),    ('Equipment', 3, '57', 3),    ('Furniture', 4, '14', 3),    ('Navigation', 1, '41', 3),   ('Recreation', 2, '29', 4),    ('Accounting', 5, '35', 5),    ('Purchasing', 5, '36', 7),   ('Personnel', 5, '37', 9),    ('Marketing', 5, '38', 2);

select * from DEPARTMENT;

INSERT INTO ITEM (itemname, itemtype, itemcolor)
VALUES
    ('Pocket Knife-Nile', 'E', 'Brown'),
    ('Pocket Knife-Avon', 'E', 'Brown'),
    ('Compass', 'N', NULL),
    ('Geo positioning system', 'N', NULL),
    ('Elephant Polo stick', 'R', 'Bamboo'),
    ('Camel Saddle', 'R', 'Brown'),
    ('Sextant', 'N', NULL),
    ('Map Measure', 'N', NULL),
    ('Boots-snake proof', 'C', 'Green'),
    ('Pith Helmet', 'C', 'Khaki'),
    ('Hat-polar Explorer', 'C', 'White'),
    ('Exploring in 10 Easy Lessons', 'B', NULL),
    ('Hammock', 'F', 'Khaki'),
    ('How to win Foreign Friends', 'B', NULL),
    ('Map case', 'E', 'Brown'),
    ('Safari Chair', 'F', 'Khaki'),
    ('Safari cooking kit', 'F', 'Khaki'),
    ('Stetson', 'C', 'Black'),
    ('Tent - 2 person', 'F', 'Khaki'),
    ('Tent -8 person', 'F', 'Khaki');

SELECT * FROM ITEM;

INSERT INTO SALES (saleqty, itemname, deptname)
VALUES
    (2, 'Boots-snake proof', 'Clothes'),
    (1, 'Pith Helmet', 'Clothes'),
    (1, 'Sextant', 'Navigation'),
    (3, 'Hat-polar Explorer', 'Clothes'),
    (5, 'Pith Helmet', 'Equipment'),
    (2, 'Pocket Knife-Nile', 'Clothes'),
    (3, 'Pocket Knife-Nile', 'Recreation'),
    (1, 'Compass', 'Navigation'),
    (2, 'Geo positioning system', 'Navigation'),
    (5, 'Map Measure', 'Navigation'),
    (1, 'Geo positioning system', 'Books'),
    (1, 'Sextant', 'Books'),
    (3, 'Pocket Knife-Nile', 'Books'),
    (1, 'Pocket Knife-Nile', 'Navigation'),
    (1, 'Pocket Knife-Nile', 'Equipment'),
    (1, 'Sextant', 'Clothes'),
	(1, 'Exploring in 10 easy lessons', 'Books'),
	(1, 'Elephant Polo stick', 'Recreation'),
    (1, 'Camel Saddle', 'Recreation');
 
SELECT * FROM SALES;

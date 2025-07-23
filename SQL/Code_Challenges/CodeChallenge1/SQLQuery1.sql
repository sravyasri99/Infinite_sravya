create database SQL_CodeChallenges
use SQL_CodeChallenges
create table books (
    id int primary key,
    title varchar(50),
    author varchar(50),
    isbn varchar(50) unique,
    published_date datetime);

drop table Studentdetails

create table reviews (
    id INT PRIMARY KEY,
    book_id INT REFERENCES books(id),
    reviewer_name VARCHAR(50),
    content VARCHAR(100),
    rating INT ,
    published_date DATETIME,
);

create table customer (
    Id INT ,
    NAME VARCHAR(50),
    AGE INT,
    ADDRESS VARCHAR(100),
    SALARY DECIMAL
);

create table Employee (
    Id INT ,
    NAME VARCHAR(50),
    AGE INT,
    ADDRESS VARCHAR(100),
    SALARY DECIMAL
);

create table ORDERS (
    OID INT ,
    DATE DATETIME,
    CUSTOMER_ID INT,
    AMOUNT DECIMAL
);

create table Studentdetails (
    RegisterNo INT ,
    Name VARCHAR(50),
    Age INT,
    Qualification VARCHAR(50),
    MobileNo VARCHAR(10),
    Mail_id VARCHAR(50),
    Location VARCHAR(50),
    Gender VARCHAR(1)
);

insert into books values
(1, 'My First SQL book', 'Mary Parker', '981483029127', '2012-02-22 12:08:17'),
(2, 'My Second SQL book', 'John Mayer', '857300923713', '1972-07-03 09:22:45'),
(3, 'My Third SQL book', 'Cary Flint', '523120967812', '2015-10-18 14:05:44');

insert into reviews values
(1, 1, 'John Smith', 'My first review', 4, '2017-12-10 05:50:11'),
(2, 2, 'John Smith', 'My second review', 5, '2017-10-13 15:05:12'),
(3, 2, 'Alice Walker', 'Another review', 1, '2017-10-22 23:47:10');

insert into customer values
(1, 'Ramesh', 32, 'Ahmedabad', 2000.00),
(2, 'Khilan', 25, 'Delhi', 1500.00),
(3, 'Kaushik', 23, 'Kota', 2000.00),
(4, 'Chaitali', 25, 'Mumbai', 6500.00),
(5, 'Hardik', 27, 'Bhopal', 8500.00),
(6, 'Komal', 22, 'MP', 4500.00),
(7, 'Muffy', 24, 'Indore', 10000.00);

insert into Employee values
(1, 'Ramesh', 32, 'Ahmedabad', 2000.00),
(2, 'Khilan', 25, 'Delhi', 1500.00),
(3, 'Kaushik', 23, 'Kota', 2000.00),
(4, 'Chaitali', 25, 'Mumbai', 6500.00),
(5, 'Hardik', 27, 'Bhopal', 8500.00),
(6, 'Komal', 22, 'MP', null),
(7, 'Muffy', 24, 'Indore', null);

insert into ORDERS values
(102, '2009-10-08 00:00:00', 3, 3000.00),
(100, '2009-10-08 00:00:00', 3, 1500.00),
(101, '2009-11-20 00:00:00', 2, 1560.00),
(103, '2008-05-20 00:00:00', 4, 2060.00);

insert into Studentdetails values
(2, 'Sai', 22, 'B.E', '9952836777', 'Sai@gmail.com', 'Chennai', 'M'),
(3, 'Kumar', 20, 'BSC', '7890125648', 'Kumar@gmail.com', 'Madurai', 'M'),
(4, 'Selvi', 22, 'B.Tech', '8904567342', 'selvi@gmail.com', 'Selam', 'F'),
(5, 'Nisha', 25, 'M.E', '7834672310', 'Nisha@gmail.com', 'Theni', 'F'),
(6, 'SaiSaran', 21, 'B.A', '7890345678', 'saran@gmail.com', 'Madurai', 'F'),
(7, 'Tom', 23, 'BCA', '8901234675', 'Tom@gmail.com', 'Pune', 'M');


--Query 1 Write a query to fetch the details of the books written by author whose name ends with er.

select * from books where author like '%er';


--Query 2 Display the Title ,Author and ReviewerName for all the books from the above table

SELECT t1.title, t1.author, t2.reviewer_name 
FROM books t1 JOIN reviews t2 
ON t1.id = t2.book_id;

--Query 3 Display the reviewer name who reviewed more than one book.

SELECT reviewer_name FROM reviews
GROUP BY reviewer_name
HAVING COUNT(book_id) > 1;

--Query 4 Display the Name for the customer from above customer table who live in same address which has character o anywhere in address

SELECT NAME as 'Name of the Customer' FROM customer WHERE ADDRESS LIKE '%o%';

--Query 5 Write a query to display the Date,Total no of customer placed order on same Date

SELECT DATE, COUNT(CUSTOMER_ID) AS 'Total no of Customers' FROM ORDERS
GROUP BY DATE;

--Query 6 Display the Names of the Employee in lower case, whose salary is null

SELECT LOWER(name) AS 'Names of the Employee' FROM Employee
WHERE SALARY IS NULL;

--Query 7 Write a sql server query to display the Gender,Total no of male and female from the aboverelation

SELECT Gender, COUNT(*) AS 'Total Count' FROM Studentdetails
GROUP BY Gender;

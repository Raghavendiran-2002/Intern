--1) Create a stored PROCEDURE that will take the author firstname and print all the books polished by him with the publisher's name
 
 CREATE PROCEDURE GetBooksByAuthor
    @AuthorFirstName varchar(50)
AS
BEGIN
    SELECT t.title "Book Title", p.pub_name "Publisher Name"
    FROM titles t
    JOIN titleauthor ta ON t.title_id = ta.title_id
    JOIN authors a ON ta.au_id = a.au_id
    JOIN publishers p ON t.pub_id = p.pub_id
    WHERE a.au_fname = @AuthorFirstName;
END;

exec GetBooksByAuthor 'Ann'
DROP PROCEDURE GetBooksByAuthor

--2) Create a sp that will take the employee's firtname and print all the titles sold by him/her, price, quantity and the cost.

 CREATE PROCEDURE get_titles_sold_by_employee
    @employee_firstname varchar(50)
AS
BEGIN
    SELECT t.title "Book Title", t.price, s.qty, t.price * s.qty  "Cost"
    FROM sales s
    JOIN titles t ON s.title_id = t.title_id
    JOIN employee e ON e.pub_id = t.pub_id
    WHERE e.fname = @employee_firstname;
END;

get_titles_sold_by_employee 'Paolo';

--3) Create a query that will print all names FROM authors and employees
SELECT au_fname AS name FROM authors
UNION
SELECT fname AS name FROM employee;
 
--4) Create a  query that will float the data FROM sales,titles, publisher and authors table to print title name, Publisher's name, author's full name with quantity ordered and price for the order for all orders, print first 5 orders after sorting them based ON the price of order

 
SELECT TOP 5 t.title AS BookTitle, p.pub_name, a.au_fname + ' ' + a.au_lname AS AuthorName,
s.qty AS "Quantity Ordered", t.Price * s.qty AS OrderTotalPrice
FROM sales s 
JOIN titles t ON s.title_id = t.title_id 
JOIN publishers p ON t.pub_id = p.pub_id
JOIN titleauthor ta ON t.title_id = ta.title_id
JOIN authors a ON ta.au_id = a.au_id
ORDER BY t.price;

use pubs

-- 1) Print the storeid and number of orders for the store

SELECT stor_id "store ID",COUNT(*) "number of orders" FROM sales GROUP BY stor_id
SELECT stor_id "store ID",qty "number of orders" FROM sales 

-- 2) print the numebr of orders for every title

SELECT s.title_id , s.ord_num FROM titles t JOIN sales s on s.title_id = t.title
SELECT t.title, COUNT(*) "Number of Orders"  FROM sales s JOIN titles t ON s.title_id = t.title_id GROUP BY t.title
-- 3) print the publisher name and book name

SELECT t.title, p.pub_name FROM publishers p JOIN titles t ON t.pub_id  = p.pub_id

-- 4) Print the author full name for al the authors

SELECT a.au_fname +' ' + a.au_lname "Author Full Name" FROM authors a
SELECT CONCAT(au_fname, au_lname) "Author Full Name" FROM authors

-- 5) Print the price or every book with tax (price+price*12.36/100)

SELECT title, price,price + (price * 12.36 / 100) "price with tax" FROM titles

-- 6) Print the author name, title name

SELECT a.au_fname + ' ' + a.au_lname "Author Name",t.title "Title Name" FROM titleauthor ta JOIN titles t ON ta.title_id = t.title_id JOIN authors a ON ta.au_id = a.au_id

-- 7) print the author name, title name and the publisher name

SELECT a.au_fname + ' ' + a.au_lname "Author Name",t.title "Title Name",p.pub_name "Publisher Name" FROM titleauthor ta JOIN titles t ON ta.title_id = t.title_id JOIN authors a ON ta.au_id = a.au_id JOIN publishers p ON t.pub_id = p.pub_id

-- 8) Print the average price of books pulished by every publicher

SELECT p.pub_name ,AVG(t.price) "Average Price of Books" FROM titles t JOIN publishers p ON p.pub_id = t.pub_id GROUP BY p.pub_name

-- 9) print the books published by 'Marjorie'

SELECT * FROM publishers p JOIN titles t ON p.pub_id = t.pub_id WHERE p.pub_name = 'Marjorie'

-- 10) Print the order numbers of books published by 'New Moon Books'

SELECT s.ord_num FROM sales s JOIN titles t ON t.title = s.title_id JOIN publishers p ON p.pub_id = t.pub_id WHERE p.pub_name = 'New Moon Books'

-- 11) Print the number of orders for every publisher

SELECT p.pub_name "Publisher" ,COUNT(s.ord_num) "Number of Orders"  FROM sales s JOIN titles t ON s.title_id = t.title_id JOIN publishers p ON p.pub_id = t.pub_id GROUP BY p.pub_name

-- 12) print the order number , book name, quantity, price and the total price for all orders

SELECT s.ord_num, t.title "Book Name", s.qty, t.price, (s.qty * t.price) "Total Price" FROM sales s JOIN titles t ON s.title_id = t.title_id;

-- 13) print he total order quantity fro every book

SELECT t.title "Book Name", SUM(s.qty) "Total Order Quantity" FROM sales s JOIN titles t ON s.title_id = t.title_id GROUP BY t.title;

-- 14) print the total ordervalue for every book

SELECT t.title "Book Name", SUM(s.qty * t.price) "Total Order Value" FROM sales s JOIN titles t ON s.title_id = t.title_id GROUP BY t.title;

-- 15) print the orders that are for the books published by the publisher for which 'Paolo' works for

SELECT s.* FROM sales s JOIN titles t ON s.title_id = t.title_id JOIN pub_info pi ON t.pub_id = pi.pub_id JOIN employee e ON pi.pub_id = e.pub_id WHERE e.fname = 'Paolo';
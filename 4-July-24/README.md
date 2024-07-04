# Setting up PostgreSQL Database with Docker

1. Pull the latest PostgreSQL image:

   ```
   docker pull postgres:latest
   ```

2. Run a PostgreSQL container:

   ```
   docker run --name db -e POSTGRES_PASSWORD=mysecretpassword -d postgres
   ```

3. Access the PostgreSQL container:

   ```
   docker exec -it db psql -U postgres
   ```

4. Create a database named `dbDocker`:

   ```
   CREATE DATABASE dbDocker;
   ```

5. Access the `dbDocker` database:

   ```
   docker exec -it db psql -U postgres -d dbDocker
   ```

6. Create tables for Department, Employee, and Salary:

   ```
   CREATE TABLE Department (
   Department_ID SERIAL PRIMARY KEY,
   Department_Name VARCHAR(100) NOT NULL
   );

   CREATE TABLE Employee (
   Employee_ID SERIAL PRIMARY KEY,
   Employee_Name VARCHAR(100) NOT NULL,
   Age INT,
   Phone VARCHAR(15),
   Department_ID INT,
   FOREIGN KEY (Department_ID) REFERENCES Department(Department_ID)
   );

   CREATE TABLE Salary (
   Salary_ID SERIAL PRIMARY KEY,
   Employee_ID INT,
   Salary DECIMAL(10, 2),
   FOREIGN KEY (Employee_ID) REFERENCES Employee(Employee_ID)
   );
   ```

7. Insert sample data into the tables:

   ```
   INSERT INTO Department (Department_Name) VALUES ('HR'), ('Finance'), ('IT');

   INSERT INTO Employee (Employee_Name, Age, Phone, Department_ID) VALUES
   ('John Doe', 30, '123-456-7890', 1),
   ('Jane Smith', 25, '987-654-3210', 2),
   ('Alice Johnson', 28, '555-666-7777', 3);

   INSERT INTO Salary (Employee_ID, Salary) VALUES
   (1, 50000),
   (2, 60000),
   (3, 70000);
   ```

8. Query data to retrieve information about employees, their departments, and salaries:

   ```
   SELECT
   e.Employee_Name,
   e.Age,
   e.Phone,
   d.Department_Name,
   s.Salary
   FROM
   Employee e
   JOIN
   Department d ON e.Department_ID = d.Department_ID
   JOIN
   Salary s ON e.Employee_ID = s.Employee_ID;
   ```

9. Log off the PostgreSQL instance:
   \q

10. Stop and start the Docker container as needed:

```
docker stop db
docker start db
```

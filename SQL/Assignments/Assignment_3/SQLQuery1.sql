use SQL_Assignment1

--1st Query Retrieve a list of MANAGERS.

select ename, job, mgr_id from emp where job = 'Manager'

--2nd Query Find out the names and salaries of all employees earning more than 1000 per month.

select ename, salary from emp where salary > 1000

--3rd Query Display the names and salaries of all employees except JAMES. 

select ename, salary from emp where ename != 'JAMES'

--4th Query Find out the details of employees whose names begin with ‘S’. 

select * from emp where ename like 'S%'

--5th Query  Find out the names of all employees that have ‘A’ anywhere in their name. 

select ename from emp where ename like '%A%'

--6th Query Find out the names of all employees that have ‘L’ as their third character in their name. 

select ename from emp where ename like '__L%'

--7th Query Compute daily salary of JONES. 

select ename, salary /30 as Dail_Salary from emp where ename = 'JONES'

--8th Query  Calculate the total monthly salary of all employees. 

select sum(salary) as Total_Monthly_Salary from emp 

--9th Query Print the average annual salary . 

select avg(salary * 12) as Average_Monthly_Salary from emp 

--10th Query Select the name, job, salary, department number of all employees except SALESMAN from department number 30. 

select ename, job, salary, deptno from emp where NOT( job ='SALESMAN' AND deptno = 30)

--11th Query  List unique departments of the EMP table. 

select distinct deptno from emp 


--12th Query List the name and salary of employees who earn more than 1500 and are in department 10 or 30. Label the columns Employee and Monthly Salary respectively.

select ename as Employee, salary as 'Monthly Salary' from emp where (salary > 1500) and (deptno = 10 or deptno = 30) 

/* 13th Query Display the name, job, and salary of all the employees whose job is MANAGER or ANALYST and their salary 
is not equal to 1000, 3000, or 5000. */

select ename, job, salary from emp where (job = 'MANAGER' or job = 'ANALYST') and salary not in (1000, 3000, 5000)

/* 14th Query Display the name, salary and commission for all employees whose commission amount is greater
than their salary increased by 10%. */

select ename, salary, comm from emp where comm > salary * 1.10

/* 15th Query Display the name of all employees who have two Ls in their name and are in 
department 30 or their manager is 7782. */

select ename from emp where ename like '%L%L%' and (deptno = 30 or mgr_id = 7782)

/* 16th Query Display the names of employees with experience of over 30 years and under 40 yrs.
 Count the total number of employees. */

select ename, DATEDIFF(MONTH, hire_date, GETDATE()) / 12 as experience_years from emp
where (DATEDIFF(MONTH, hire_date, GETDATE()) / 12 > 30) AND (DATEDIFF(MONTH, hire_date, GETDATE()) / 12 < 40)

select count(*) as Total_Employees from emp where (DATEDIFF(MONTH, hire_date, GETDATE()) / 12 > 30) AND (DATEDIFF(MONTH, hire_date, GETDATE()) / 12 < 40)

--17th Query Retrieve the names of departments in ascending order and their employees in descending order. 

select D.dname, E.ename from dept D 
join emp E on D.deptno = E.deptno 
order by D.dname asc, E.ename desc

--18th Query Find out experience of MILLER.

select ename, DATEDIFF(MONTH, hire_date, GETDATE()) / 12 as experience from emp
where ename = 'MILLER'

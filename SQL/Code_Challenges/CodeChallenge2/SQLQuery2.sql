--Query 1 Write a query to display your birthday( day of week)

select  convert(date, '2003-11-05') as Birth_Date,datename(weekday, '2003-11-05') as Day_Of_Week;

--Query 2 Write a query to display your age in days

select datediff(day, '2003-11-05', getdate()) as Age_In_Days;

--Query 3 Write a query to display all employees information those who joined before 5 years in the current month
 
select * from emp
select * from dept

update emp set hire_date = '2020-07-10' where empno = 7369
update emp set hire_date = '1981-07-12' where empno = 7499
update emp set hire_date = '1970-07-11' where empno = 7521



select * from emp where datepart(month, hire_date) = datepart(month, GETDATE()) and datediff(year, hire_date, GETDATE()) >= 5;           


/*Query 4 Create table Employee with empno, ename, sal, doj columns or use your emp table and perform the following operations in a single transaction
	a. First insert 3 rows 
	b. Update the second row sal with 15% increment  
        c. Delete first row.
After completing above all actions, recall the deleted row without losing increment of second row. */

begin transaction

insert into emp values
(101, 'sravya', 'IT',7839,'2025-05-05',8000,200,10),
(102, 'srI', 'CLERK',7839,'2021-05-05',7000,200,20),
(103, 'Lilli', 'Sales',7839,'2022-05-05',6000,200,30)
save tran t1

update emp set salary = salary * 1.15 where empno = 102
save tran t2

delete from emp where empno = 101

rollback tran t2
commit

/*Query 5 Create a user defined function calculate Bonus for all employees of a  given dept using 	following conditions
	a.     For Deptno 10 employees 15% of sal as bonus.
	b.     For Deptno 20 employees  20% of sal as bonus
	c      For Others employees 5%of sal as bonus */

create function fnCalculateBonus (@deptno int, @sal decimal(10))
returns decimal(10)
as
begin
    declare @bonus decimal(10)

    if @deptno = 10
        set @bonus = @sal * 0.15;
    else if @deptno = 20
        set @bonus = @sal * 0.20;
    else
        set @bonus = @sal * 0.05;

    return @bonus
end
select empno,ename,salary,deptno,dbo.fnCalculateBonus(deptno, salary) as Bonus from emp;


--Query 6 Create a procedure to update the salary of employee by 500 whose dept name is Sales and current salary is below 1500 (use emp table)

create proc update_sales_salary
as
begin
    update emp set salary = salary + 500 from emp
    join dept on emp.deptno = dept.deptno
    where dept.dname = 'sales' and emp.salary < 1500;
end
exec update_sales_salary

update emp set salary = 1000 where empno = 103 --for observing the increment in salary 

select emp.empno,emp.ename,emp.salary,emp.deptno,dept.dname from emp join dept on emp.deptno = dept.deptno
where dept.dname = 'sales'and emp.salary < 2000 ;





create table Department
( Deptid int primary key,
DeptName varchar(30) not null,
DeptBudget float ) 

select * from Department

--insert some rows into department
insert into Department values(2,'HR',15000),(4,'Operations',20000),
(6,'Accounts',10000),(3,'Admin',50000), (5,'Testing',12000)

--update some value in the table
update Department set DeptBudget = 75000 where Deptid=1

sp_help Department

drop table Employee
drop table Department

create table Employee
(EmpId int not null,
EmpName varchar(50)not null,
Gender char(7),
Salary decimal,
DepartmentId int references Department(deptid)
)

select * from Employee
insert into Employee(EmpId,EmpName,gender,Salary,DepartmentId) values(105,'Shreya','Female',6000,2),
(102,'Hemachandra','Male',6200,4)


insert into employee values(104,'Nithin','Male',5800,1,'12345')
--altering table to add a primary key constraint
alter table Employee
add constraint pkemp primary key(EmpId)

--drop the primary key constraint
alter table Employee
drop constraint pkemp

--drop the foreign key constraint from Employee
alter table Employee
drop constraint [FK__Employee__Depart__29572725]

--add foreign key constraint
alter table employee
add constraint fkdeptid foreign key(departmentid) references Department (Deptid)

--drop a unique key constraint
alter table employee
drop constraint UQ__Employee__5C7E359EBCF4F2E9

--adding a column after table creation
/* column name , size, constraints */

alter table Employee
add Phone varchar(12) 

--dropping a column from a table
alter table employee
drop column phone

alter table employee
add constraint uphone unique(phone)

--adding check constraint
alter table employee
add constraint salcheck check(salary >=6000)

sp_help Employee

--creating table level constraints

create table dummy
(did int,
dname varchar(20),
dref int,
constraint PK_dummy primary key (did, dname),
constraint Fk_dref foreign key(dref) references Department(deptid))

sp_help employee

-- disabling check constraint
alter table employee nocheck constraint salcheck

select * from employee
insert into employee values(103, 'Adithya','Male',6300,2,'212345'),
(104,'Poorna','Female',6250,3,333333)

--enabling check constraint
alter table employee check constraint salcheck

--deleting 
insert into dummy values(1,'aa',1),(2,'bb',2)
select * from dummy

delete from dummy where did = 1
truncate table dummy

update employee set phone='88777' where EmpName='hemachandra'

alter table employee
add constraint UPhone unique (phone)

--default constraints
alter table department
add constraint defbudget default 5000 for deptbudget

--to effect the default values, we have to avoid the column in the insert statement
insert into Department (Deptid,DeptName) values(7,'Purchase')
select * from employee
select * from Department

--selection and projection
select * from employee
select Empname, salary from employee

--top records
select top 3 * from employee

--top percentage
select top 10 percent empname from employee

--alias
select empid EmployeeIdentificationNumber from employee
select empid 'Employee Identification Number' from employee
select empid as [Employee Identification Number] from employee

--computational columns/arithemetic operators
select empname as 'Employee Name', salary 'Monthly Salary', (salary*12) as 'Annual Salary',
(salary/30) 'Daily Salary' from employee

--calculated or computed columns at the definition 
drop table dummy
create table dummy
(did int,
dprice int,
dqty int,
dtotal as(dprice*dqty))

insert into dummy values(2,null,10)
select * from dummy

--relational operators
select * from employee where gender = 'male'
select * from employee where salary > 6000
select * from employee where DepartmentId <> 1
select empname, (salary+1000) from employee where DepartmentId =2

--logical operator
select * from employee where (salary > 6000 and salary < 6300) or DepartmentId=2
select * from employee where not DepartmentId = 1

--between and not between (for inclusive range values)
select * from employee where salary between 6000 and 6300

select * from employee where salary not between 6000 and 6300

--null values
select * from employee where DepartmentId is null

select * from employee where DepartmentId is not null

--in operator
-- fetch all employees who work for dept 1 and 2

select * from employee where DepartmentId in (1,3)

select * from employee where DepartmentId not in(1,3)

--aggregates 
select max(salary) from employee
select avg(salary) 'Average Salary ' from employee
select max(salary) as 'Maximum Salary', min(salary) as 'Minimum Salary', avg(salary) as 'Average Salary'
from Employee

select count(departmentid) from employee  -- count ignores nulls and counts duplicates

select distinct(departmentid) from employee -- distinct includes null and ignores duplicates

select count(distinct(departmentid))from employee

select count(*)departmentid from employee

--wild card characters with like 
--% [percentile] - substitution of 0,1,or more characters
-- _[underscore] - substitutes exactly one character
-- [range] - substitutes characters within the given range
-- ^[caret] -  substitutes characters not within the given range

select * from employee where empname like 'A%'
select * from employee where empname like '%A'
select * from employee where empname like '%h%'

--get employee names which have i,e,h as their second character
select * from employee where empname not like '_[ieh]%'
select * from employee where empname like '_[^ieh]%'
select * from employee where empname like 'a__[ti]%'

--string operations
select concat('Happy' , ' Birthday ' , 'to ', ' you' , ' 2025')
select replace('Jack and Jill', 'J','Bl')
select ASCII('d')

--date operations
select getdate()
select convert(varchar(11),getdate())
select datename(dw,getdate())

select substring(convert(varchar(11),getdate(),113),4,8) as [Month YYYY]

--sorting
select * from employee
order by EmpName desc

--multiple column sorting
select * from employee order by DepartmentId, salary desc

--alias name
select empname as 'Employee Name', salary as 'Employee Salary',departmentid from employee
order by DepartmentId, [Employee Salary] desc

--columns not in select list
select empname as 'Employee Name', salary as 'Employee Salary' from employee
order by DepartmentId, [Employee Salary] desc

--group by
--write a query to find all employees who earn more than the average of the salary

select DepartmentId,sum(salary) from employee
group by DepartmentId

select sum(salary) from employee
group by DepartmentId

--find dept wise average salary
select Departmentid, avg(salary) 'Average Salary' from employee
group by DepartmentId
order by [Average Salary]

--depet wise , gender wise average salary
select departmentid, gender, avg(salary) as Average from employee
group by departmentid,gender
order by DepartmentId

--count no.of males and females 

select gender,count(gender) from employee
group by gender

--count no of males and females per department
select departmentid, gender,count(*) from employee
group by DepartmentId,gender
order by DepartmentId

--write a query to find all employees who earn more than the average of the salary

--find dept wise avg salary where avg salary > 5700
select departmentid, avg(salary) 'Average Salary' from employee
group by DepartmentId
having avg(salary) >5700

--deptwise count of male and female employees where the count is  >=2
select Departmentid, Gender, count(*) 'Employee Count' from employee
group by DepartmentId, gender
having count(*) >=2

--rewrite the above query to list deptname wise avg salary being > 5700
--the query involves 2 tables

select * from department
select * from employee

select DeptName, avg(salary) as 'Average Salary' from employee, Department
where employee.DepartmentId = Department.Deptid
group by deptname having avg(salary)> 5700
order by deptname

--above query with table aliases and references
select d.DeptName, avg(e.salary) as 'Average Salary' 
from Department d, employee e
where d.Deptid = e.DepartmentId
group by deptname having avg(salary)> 5700
order by deptname

--for each deptname, find the sum of salary where sum > 11000
select d.DeptName, sum(e.salary) as 'Average Salary' 
from Department d, employee e
where d.Deptid = e.DepartmentId
group by deptname having sum(salary)> 11000
order by deptname

select round(45.926,2)

--joins
/*
-- cross joins  (cartesian product)
-- Equi/Natural/Inner Join (exact matching of records from 2 or more tables)
-- Non Equi Join
-- outer Join (matching + non matching records)
    -- left outer join
	-- right outer join
	-- full outer join
-- self join */

--1. cross join
 select * from employee, department

 --or
 select * from employee cross join Department

 --2. Equi/Natural/Inner Join
 select deptname, empname,salary 
 from department,employee where department.Deptid = employee.DepartmentId

 --or
 select deptname,empname,salary 
 from department inner join employee
 on Department.Deptid = Employee.DepartmentId

 --or
  select deptname,empname,salary 
 from department join employee
 on Department.Deptid = Employee.DepartmentId

 --3. outer join
    --left outer
select deptname,empname,salary 
 from department left outer join employee
 on Department.Deptid = Employee.DepartmentId

 --or
 select deptname,empname,salary 
 from department left join employee
 on Department.Deptid = Employee.DepartmentId

 --right outer join
 select deptname,empname,salary 
 from department right outer join employee
 on Department.Deptid = Employee.DepartmentId

 --or
 select deptname,empname,salary 
 from department right join employee
 on Department.Deptid = Employee.DepartmentId

 --full outer join
 select deptname,empname,salary 
 from department full outer join employee
 on Department.Deptid = Employee.DepartmentId

 --or
 select deptname,empname,salary 
 from department full join employee
 on Department.Deptid = Employee.DepartmentId

 --self join
 --display all supervisors names and their subordinate names 

 select t1.empname as 'Supervisors Name', t2.empname as 'Subordinates Name'
 from employee t1 join employee t2
 on t1.EmpId = t2.mgrid

--find all employees who earn more than 'Hemachandra'
 select salary from employee where empname ='hemachandra'
 select * from employee where salary > 6200

 --subquery
 select * from employee where salary >   --main query
                          (select salary from employee where empname ='hemachandra') --subquery

--multi row subquery
select empname,salary from employee where salary >any
                                     (select salary from employee where departmentid in(1,3))

select empname,salary from employee where salary <any  --(6000,6200,6250)
                                     (select salary from employee where departmentid in(1,3))


select empname,salary from employee where salary <all  --(6000,6200,6250)
                                     (select salary from employee where departmentid in(1,3))

select empname,salary from employee where salary >all  --(6000,6200,6250)
                                     (select salary from employee where departmentid in(1,3))


select empname,salary from employee where salary =any  --(6000,6200,6250)
                                     (select salary from employee where departmentid in(1,3))


select empname,salary from employee where salary in  --(6000,6200,6250)
                                     (select salary from employee where departmentid in(1,3))


select empname,salary from employee where salary in
                                     (select salary from employee where empname like '_[ieh]%' )

--display list of employees who work in dept as that of employee 102 and earns salary >  employee 100
-- this involves 2 separate subqueries joined with alogical and

select empname,salary,DepartmentId from employee where DepartmentId = --1 and salary > 6000
                                               (select departmentid from employee where empid=102)
								  and salary > (select salary from employee where empid=100)

--find employees name and salary, whose salary is equal to the minimum salary 
select empname, salary from employee where salary =
                                        (select min(salary) from employee)

-- group by and having clause in subqueries
--list dept wise minimum salary that are > than the minimum salary of dept 3

select departmentid , min(salary) MinimumSalary from employee 
group by DepartmentId
having min(salary) > 6000
                  (select min(salary) as Minimum from employee where DepartmentId= 3)

select * from employee
select * from department
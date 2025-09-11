--misc functions

--isnull()

select isnull('Hello','replace value of null')as 'is null'
select isnull(null,'replace value of null')as 'is null'

create table NullFunctionCheck
(serialNo int, name varchar(20), loc varchar(20),
age int, occupation varchar(20))

insert into NullFunctionCheck values(1,'Hemasai','India',22,'software Engg'),
(2,'Rakesh','UK',null,'Artist'),(3,'Shrinivas','USA',null,'Writer'),
(4,'Nithin','India',23,'Professor')

select * from NullFunctionCheck

select *,isnull(age,30)as 'New Age' from NullFunctionCheck

update NullFunctionCheck set age = isnull(age,30)where loc ='UK'

update NullFunctionCheck set age = null where serialNo=2

insert into NullFunctionCheck values(5,'Thamarai','Canada',isnull(null,25),'Banker')

--coalesce
declare @str1 char,@str2 char,@str3 char
--all values are null
select coalesce(@str1,@str2)as 'Coalesce Results',
case
 when @str1 is not null then @str1
 when @str2 is null then 'is a null value'
 end as 'Cae Result'

 select coalesce(null,null,null,5,null)  
 --to apply the above using isnull
 select isnull(null,isnull(null,isnull(null,isnull(5,null))))

 use Pract

 select * from Employees

 --1.
 select titleofcourtesy,firstname,titleofcourtesy + ' ' +
 coalesce(firstname,' ') + ' ' + coalesce(lastname,' ')as [Employee Full Name] from
 employees

 --rollup
 select DepartmentId,sum(salary)as 'Total Salary' from employee
 group by DepartmentId

  select DepartmentId,sum(salary)as 'Total Salary' from employee
 group by rollup(DepartmentId)

 --to display the totals with a meaningful column value, we can coalesce
   select coalesce(DepartmentId,500)as Department,sum(salary)as 'Total Salary' from employee
 group by rollup(DepartmentId)

 --subtotals and grand totals deptwise,gender wise
 select coalesce(departmentid,500)as Deaprtment,coalesce(gender,'All genders subtotal'),
 sum(salary)as 'Total Salary' from employee
 group by rollup(DepartmentId,gender)

 select * from employee
 insert into employee values(107,'poorna','Female',6800,null,9999)

 --the above without coalesce
 select departmentid as Deaprtment, gender, sum(Salary)TotalSalary from Employee
 group by rollup(DepartmentId,gender)

 --cube
 select coalesce(departmentid,500)as Deaprtment,coalesce(gender,'All genders subtotal') as Gender,
 sum(salary)as 'Total Salary' from employee
 group by cube(DepartmentId,gender)
 order by DepartmentId,gender

 --addl func.
 create table Students(StdName varchar(25),Subject varchar(20),Marks_Scored int)

 insert into Students values('Tarun','Maths',80),('Tarun','Science',70),('Tarun','English',65),
 ('Nishitha','Maths',68),('Nishitha','Science',85),('Nishitha','English',90),
 ('Susmitha','Maths',65),('Susmitha','Science',90),('Susmitha','English',60)
 update Students set Marks_Scored = 60 where subject  = 'English' and stdname = 'susmitha'
 select * from students

 --rownumber() -- allocates numbers based on the rows over a particular column
 select stdname,subject,marks_scored,ROW_NUMBER() over(order by marks_scored desc)as Row_Numbers 
 from Students

 --rank() --allocates numbers based ont he rows over a particular column, but skips the sequence of the next
 --in case there are more rows with the same value

 select stdname,subject,marks_scored,rank() over(order by marks_scored desc)as Rank_Numbers 
 from Students

 --dense_rank() -allocates numbers based ont he rows over a particular column,without skipping any sequence
  select stdname,subject,marks_scored,dense_rank() over(order by marks_scored desc)as Rank_Numbers 
 from Students

 --seggregation based on particular columns can be used with partition
   select stdname,subject,marks_scored,rank() over(partition by subject order by marks_scored desc)as Rank_Numbers 
 from Students

   select stdname,subject,marks_scored,rank() over(partition by stdname order by marks_scored desc)as Rank_Numbers 
 from Students

--calculated columns
alter table employee
add AnnunalSalary as (salary * 12) persisted

drop index employee.idxannsal
alter table employee
drop column annunalsalary

select  * from employee where annunalsalary > 79000

create index idxannsal on employee(annunalsalary)

select  * from employee order by annunalsalary

--normalization
drop table empnormal
create table empnormal
(eno CHAR(4),
dept varchar(5),
prjcode varchar(5),
Hours int,
primary key (eno,prjcode))

insert into empnormal values('E1','D1','P100',5),('E1','D1','P50',3),
('E2','D2','P100',8),('E3','D3','P100',4),('E3','D3','P50',4),('E4','D4','P100',8)

select dept from empnormal where eno='E1' and prjcode='p100'

select hours from empnormal where eno='E1' and prjcode
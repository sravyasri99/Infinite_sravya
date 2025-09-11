use Pract
--drop table Employee
create table Department
( Deptid int primary key,
DeptName varchar(30) not null,
DeptBudget float ) 

insert into Department values(2,'HR',15000),(4,'Operations',20000),
(6,'Accounts',10000),(3,'Admin',50000), (5,'Testing',12000)
update Department set DeptBudget = 75000 where Deptid=1

create table Employee
(EmpId int not null,
EmpName varchar(50)not null,
Gender char(7),
Salary decimal,
DepartmentId int references Department(Deptid)
)

insert into Employee(EmpId,EmpName,gender,Salary,DepartmentId) values(105,'Shreya','Female',6000,null),
(102,'Hemachandra','Male',6200,1)


--set commands
create table Utable1(uid int identity, uname varchar(20), ugrade char(1), upercentage int)

insert into Utable1 values('Manoj','A',85),('Nandini','A',80),('Mehrun','B',65),('Nithin','B',60)

create table Utable2(uid int identity, uname varchar(20), ugrade char(1), upercentage int)

insert into Utable2 values('Yogesh','A',85),('Susmitha','A',82),('Monali','B',65),('Mahesh','B',60)

select * from utable1
select * from utable2

--union
select uname,ugrade,upercentage from Utable1
union
select uname,ugrade,upercentage from Utable2

update utable2 set uname='Manoj' where uname='Yogesh'

select uname,ugrade,upercentage from Utable1
union all
select uname,ugrade,upercentage from Utable2

--intersect
select uname,ugrade,upercentage from Utable1
intersect
select uname,ugrade,upercentage from Utable2

--except
select uname,ugrade,upercentage from Utable1
except
select uname,ugrade,upercentage from Utable2

--for except
create table empdata(Id int identity, Ename varchar(20),Age int, City varchar(20))

insert into empdata values('Rahul',21,'Noida'),('Vikram',21,'Chennai'),('Dinesh',21,'Vizag')

create table BonusData(Bid int, Eid int, BonusAmt int)

insert into BonusData values(100,4,5000),(101,2,6000),(102,1,7000)

select * from empdata
select * from BonusData

--CTE'S
--constructing our first cte
with firstcte (EmployeeName, AnnualSalary, Department)
as (select ename,(salary*12), dept.dname from emp join dept
on emp.deptno = dept.deptno),

--select * from firstcte where AnnualSalary > 1000

--query 2

cte2 as (select Department, avg(AnnualSalary) 'Dept Annual Salary' from firstcte
group by departmentname having avg(annualsalary)>76500)


with dmlcte(DepartmentNumber, DepartmentName, NewBudget)
as (select deptno, dname, loc from dept)
 
 --select * from dept
--insertion
--insert into dmlcte values(11,'New Department',2500000)
--select * from dept
 
--updation
--update dmlcte set NewBudget = 0 where DepartmentNumber = 11
--select * from dept


/*delete from dept
where deptno in (
    select DepartmentNumber
    from dmlcte
    where DepartmentNumber = 10
);*/

delete from dmlcte where DepartmentNumber = 11;
select * from dept

--recursive ctes
with cte_week(n, wkDay)
as(select 0, DATENAME(dw,0)
union all
select n + 1, datename(dw,n+1) from cte_week where n < 6)

--using the cte
select n,wkDay from cte_week

with cte_months(n, month_name) 
as (select 1, datename(month, datefromparts(year(getdate()), 1, 1))
union all
select n + 1, datename(month, datefromparts(year(getdate()), n + 1, 1)) from cte_months where n < 12)

select n , month_name from cte_months;
-----------------
With cte_month(n, mName) as (
    Select 1, DATENAME(month, 0)     
    Union all
    select n + 1, DATENAME(month, n)
    FROM cte_month
    WHERE n < 12                
)
SELECT n, mName FROM cte_month;



--Hierarchial queries with recursive cte
with hcte(EmpNo,EName,Manager,EmpLevel)
as(select empno,ename,mgr_id, 1 EmpLevel
from emp where mgr_id is null  --intial or first level
union all
select e.empno, e.ename, e.mgr_id, oq.emplevel + 1 --recursive values
from emp e join hcte oq on e.mgr_id = oq.empno where e.mgr_id is not null)
--using the above cte
select * from hcte 
order by EmpLevel

--create a recursive query to display values from 1 to 10
with ctr(intialvalue) as 
(select 1 
union all
select intialvalue + 1 from ctr
where intialvalue < 10)
select * from ctr

--T-Sql
--eg1.

begin
declare @v1 int=50, @v2 int=100
declare @sum int =@v1
--set @sum = @v1
print @sum
if(@v1 > @v2)
	print 'V1 is grater'
else
	print 'V2 is greater'
end

--eg 2. using tsql increase the salary of all employees who are earning less than 106
select * from emp

begin
	declare @esal int
	declare @name varchar(30)
	select @name = ename, @esal = salary from emp where empno = 7900

	if(@esal <= 1250)
	begin
	set @esal = @esal + 100
		print 'The revised salary is ' + @name+' ' + cast(@esal as varchar(8))
		end
		else
			begin
			print 'Current salary is OK'
			end
		end
--eg 3

declare @ctr int = 1
while @ctr <= 5
begin
	print @ctr
	set @ctr  = @ctr + 1
	if @ctr = 4
	break
end

--while with continue
declare @ctr2 int = 0
	while @ctr2 <= 5
	begin
	set @ctr2 = @ctr2 +1
	if @ctr2 = 4
	continue
	print @ctr2
	end

--updating records using while loop
select * from emp
declare @min_id int
select @min_id = min(empno) from emp
print @min_id

declare @row_count bigint = 0
declare @sal float, @rsal float

--get the count of total rows to process
select @row_count = max(empno) from emp
select @sal = salary from emp where empno = @min_id
--print @row_count
while @min_id <= @row_count
begin
	select @rsal  = salary from emp where empno = @min_id
	if(@rsal <@sal)
	begin
	update emp set salary  = @rsal + 100
	where empno = @min_id
	end
	else
	begin
		print 'Salry seems to be ok'
	end
	set @min_id = @min_id  + 1
end

select * from dept

--stored procedures
create procedure sp_greetings
as
begin
select 'Hello and weclome to SQL Procedures'
end

execute sp_greetings
exec sp_greetings
sp_greetings

create proc sp_employeedata
as begin
select * from emp where deptno = 10
end

sp_employeedata

sp_helptext sp_employeedata

create or alter proc sp_dmlops
as
begin 
	insert into em values(108,'Naveen',6300,1,'123456789')
	select * from employee

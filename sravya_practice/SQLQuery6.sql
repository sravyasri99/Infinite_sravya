
--multi statement table valued functions , going to return structure 


create or alter function fn_GetEmp_ByGender (@egen varchar(8))
returns
@EmpBygender table(EmpNumber int, EmployeeName varchar(30), Gender vasrchar(8))
as
begin
  --bluk insertion
  insert into @EmpBygender select empno,ename,gender from emp
  where gender  = @egen
  --incase there wer issues in bluk insertion
  --we can try to handle exception
  if @@ROWCOUNT = 0
  begin
   insert into @EmpBygender values(0, 'No Employee found with the given gender', null)
  end
  return
end

--to execite the above
select * from dbo.fn_GetEmp_Bygender('Female')
select * from customers

create or alter function fn_GetCustomer_ByCountry (@CountryName varchar(50))
returns
@CustomerByCountry table (CustomerID nvarchar(100),ContactName varchar(100),Country varchar(50))
as
begin
    
    insert into @CustomerByCountry select CustomerID, ContactName, Country from Customers
    where Country = @CountryName

    
    if @@ROWCOUNT = 0
    begin
        insert into @CustomerByCountry 
        values (0, 'No Customers found for given country', NULL)
    end
   return
end

select * from dbo.fn_GetCustomer_ByCountry('Germany')

--Indexes

create table TestTable 
(TestId int,
TestName varchar(max),
TestDate date)

insert into TestTable values(4,'Jquey','2025/07/14'),(6,'CSharp','2025/07/23'),(null,'SQL','2025/07/25'),
(1,'API','2025/08/21')

select * from TestTable
--creating a clustered index
create clustered index indxt_tid on TestTable(testid)

--the above only sorts the physical order

--dropping an index from a table
drop index Testtable.indxt_tid

--create a unique clustered index
create unique clustered index idxu on TestTable(testid)

--non clusterd indexes

create index idxtestname on testtable(testdate)

--the above way of creating indexes will always create a non-clusterd, non-unique index only
create unique nonclustered index idxdname on department()

--filtered indexes
create index idxsalary on emp(salary) where salary > 1600

select * from emp where salary between 2000 and 500


--views
--1. single table view
create view vwEmpdata
as select empno,ename,salary from emp

select * from vwEmpdata

insert into vwEmpdata values(800,'Dinesh',5000)

--trigger for creating log data
select * from emp
create table AuditLog(msg nvarchar(max))

create or alter trigger trgAudit
on emp
for delete
as 
 begin
 declare @id int
 select @id = empno from inserted

 insert into AuditLog
 values('New Employee with Employee Id : ' + ' ' +cast(@id as varchar(5)) +
 ' ' + 'is deleted at' + cast(getdate() as varchar(20)))
 end

 --let us create a row into employee
 insert into emp values(110,'Taraka lakshmi','clerk',7489,'15-dec-30',5000,null,10)

 select * from AuditLog

 -- trigger for updation along withaudit lod details
  alter table auditlog
  add auditdate date 

  create or alter trigger trgUpdateAudit
  on emp
  for update
  as
  begin
   declare @id int, @olddept int, @newdept int
   declare @oldename varchar(40), @newename varchar(40)
   declare @oldsal float, @newsal float

   -- declare a variable to build the audit string 
   declare @auditdata varchar(max)
   select * from deleted
   select * from inserted
   --store the inserted data into temporary table or we can directly use the inserted 
   select * into #temptable from inserted 
   select * from #temptable
   --loop thru all the updated records incase we have updated many records
   while(exists(select empno from #temptable))
    begin
	 set @auditdata = ' '

	 --let us select the first row of the temporary table
	 select top 1 @id=empno, @newename=ename, @newsal = salary,@newdept=deptno from #temptable

	 --let us also select the data from the deleted table
	 select @oldename = ename, @oldsal=salary, @olddept = deptno from deleted

	 set @auditdata = 'Employee with ID : ' + cast(@id as varchar(5)) + ' Changed '
	 --if old data is updated with new data, we should track individually
	 if(@oldename <> @newename)
	  begin
	   set @auditdata = @auditdata + ' the Name from ' + @oldename + ' to ' + @newename
	   end
	   --for salary
	   if(@oldsal <> @newsal)
	    begin
		set @auditdata = @auditdata + ' Salary from ' + cast(@oldsal as varchar(8)) + ' to ' + 
		cast(@newsal as varchar(10))
	   end
	   --for dept
	   if(@olddept <> @newdept)
	    begin
		set @auditdata = @auditdata + ' Department from ' + cast(@olddept as varchar(5)) + ' to '
		+ cast(@newdept as varchar(5))
	   end
	   insert into Auditlog values(@auditdata,getdate())
   --next row selection
   delete from #temptable where empno=@id 
	   end
	   end

	   update emp set salary = salary + 50 where deptno = 10

	select * from AuditLog

--instead of triggers
select * from vwEmpdata

insert into vwEmpdata values(300,'Ajay',6000,'Purchase')

--instead of triggers are used to resolve issues with view updations

create or alter view vwEmpbyDept  
as select empno, ename,salary,dept.dname from emp join dept  
on emp.deptno = dept.deptno


create or alter trigger trg_ViewIns_Insteadof
on vwempbydept    -- trigger on a view relation
instead of insert
as
 begin
  declare @departmentid int
  --first let us check if the given department in the insert clause is valid ('Accounts')
  set @departmentid = (SELECT deptno FROM dept d, inserted WHERE inserted.dname = d.dname)

  --now we will check the data  in the variable @departmentid
  if(@departmentid is null)
    begin
	 raiserror('Invalid Department name.. terminating', 16,1)
	 return
	 end

	 --if the @departmentid is valid
	 insert into emp(empno,ename,salary,deptno)
	 select empno,ename,salary,@departmentid from inserted
end

insert into vwEmpbyDept values(250,'Vijay',6000,50) 

select * from emp
select * from dept
select * from AuditLog


update vwEmpbyDept set dname='Operations' where empno=110

--ex write an instead of trigger on the view to ensure updation of the departmentid 
--in the employee table for a given employee, and not in the department table as seen

create or alter trigger trg_ViewUpdate_Insteadof

on vwempbydept

instead of update

as

begin

    -- Variable declarations

    declare @newdeptid int;

    declare @empid int;

    declare @deptname varchar(50);
 
    -- Get updated values from inserted pseudo-table

    select @empid = empno, @deptname = dname from inserted;
 
    -- Lookup the deptid from the department table

    select @newdeptid = deptno

    from dept

    where dname = @deptname;
 
    -- Validate the department name

    if @newdeptid is null

    begin

        raiserror('Invalid department name for update', 16, 1);

        return;

    end
 
    -- Update the employee table’s departmentid

    update emp

    set deptno = @newdeptid

    where empno = @empid;

end;
 
update vwEmpbyDept set dname='sales' where empno=110
 
select * from emp
select * from dept
select * from vwEmpdata

--database scoped trigger:
create or alter trigger trg_restrict_create_table
on database
for create_table
as
begin
  print 'Access Denied'
  rollback transaction
end

create procedure sp_testproc
as
begin
select * from emp
end

sp_testproc

--to drop database level triggers
drop trigger if exists trg_restrict_create_Table on database

create table sample (sampleid int, sname char(8))

--server scoped trigger
create or alter trigger trg_restrict_all
on all server
for create_table,alter_table,drop_table
as
begin
 print 'you are not allowes to create, alter or drop any database tables in this server'
 rollback
end
--test any options now
drop table sample

create database northwind
use northwind
create table test(testid char(6),testname varchar(20))

drop trigger if exists trg_restrict_all on all server


--cursors
--eg 1
--if we need any variables we can declare it first
declare @pname varchar(25), @price int, @qty int
--declare a cursor
declare prd_cursor cursor
for select productname,price,quantityavailable from products_new

--open the cursor
open prd_cursor
--read the data from the cursor
fetch next from prd_cursor into @pname,@price,@qty

--iterate the cursor set till we have no more rows
while @@FETCH_STATUS = 0
 begin
  print 'The product named' +@pname+' '+' costs ' + cast(@price as varchar(10)) +
  ' and the available quantity is ' + cast(@qty as varchar(5))
  --start to fetch the next record
  fetch next from prd_cursor into @pname,@price,@qty
end

--close the cursor
close prd_cursor
--deallocate the cursor
deallocate prd_cursor

--eg3
--static cursor
declare @staticename varchar(30),@staticsal float
declare emp_static cursor static
for select ename,salary from emp

open emp_static
fetch relative 3 from emp_static into @staticename, @staticsal
while @@FETCH_STATUS = 0
 begin
 if(@staticsal > 6500)
  print @staticename + 'Earns' + cast(@staticsal as varchar(8))
 end
 else
 begin
 print @staticename + 'needs an increment'
 end
 fetch prior from emp_static into @staticename,@staticsal
 end
 
 --
 select * from employee

 --eg 4 dynamic cursor
 declare @empname varchar(40), @empsal float
 declare emp_dynamic cursor dynamic
 for select empname,salary from employee
 open emp_dynamic
 fetch next from emp_dynamic into @empname, @empsal

 while @@FETCH_STATUS = 0
  begin
   if(@empsal < 6500)
    begin
	 print 'Current salary of : ' + @empname + ' is ' + cast(@empsal as varchar(8))
	  update employee 
	   set salary = salary + 500 where current of emp_dynamic

	   --let us get the updated salary from tne table
	   select @empsal = salary from employee where empname=@empname
	   print ' Revised Salary of : ' + @empname + ' is ' + cast(@empsal as varchar(8))
	   end
	   else
	   begin
	    print @empname + ' is earning well '
		end

		 fetch next from emp_dynamic into @empname, @empsal
		end

		close emp_dynamic
		deallocate emp_dynamic

create or alter view vwEmpbyDept  
as select empid, empname,salary, phone,department.deptname from employee join department  
on employee.departmentid = department.deptid

create or alter trigger trg_ViewUpdate_Insteadof

on vwempbydept

instead of update

as

begin
 
-- Variable declarations

declare @newdeptid int;

declare @empid int;

declare @deptname varchar(50)
 
-- Get updated values from inserted pseudo-table

select @empid = empid, @deptname = deptname from inserted;
 
-- Lookup the deptid from the department table

select @newdeptid = deptid

from department

where deptname = @deptname
 
 
-- Validate the department name

if @newdeptid is null

begin

raiserror('Invalid department name for update', 16, 1)

return

end
 
-- Update the employee table’s departmentid

update employee set departmentid = @newdeptid where empid = @empid

end
 
update vwempbydept set deptname = 'Testing' where empid = 103

select * from vwEmpbyDept
select * from employee
select * from Department

--file groups
create database FilesDB on primary
(
--primary group
Name='FilesDB',
filename = 'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\FilesD.mdf',
size = 5mb,
maxsize = unlimited,
filegrowth  = 1024kb
),

--secondary file group
filegroup FDgrp1
(
 Name = 'FilesDbFile1',
 filename = 'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\FilesDbFile1.ndf',
 size = 1mb,
 maxsize = unlimited,
 filegrowth = 1024kb),

--like the above we can create more secondary groups
--now let us create a group for the log
filegroup FileDBLog
(Name='FilesDBLog',
filename='C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\FileDbLog.ldf',
size = 5mb,
maxsize = unlimited,
filegrowth = 1024kb)
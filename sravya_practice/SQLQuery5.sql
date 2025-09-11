select (salary*12) from emp
select * from emp
--Procedures
--write a procedure that calculates whether an employee is eligible for tax or not

create or alter proc sp_Taxcalculator @eid int, @annualsal float output
as
begin
	declare @tempsal float
	select @tempsal = (salary *12) from emp where empno = @eid
	if(@tempsal > 25000)
		begin
		set @annualsal = @tempsal
		end
	else
		begin
		print 'no tax levied as annunal salary is within the limits'
		end
end

--to execute
declare @outannsal float, @tax float
exec sp_Taxcalculator 7369, @outannsal output
set @tax = @outannsal *10/100
print 'salary earned is '+cast(@outannsal as varchar(8))
print 'Tax amount to be deducted : ' + cast(@tax as varchar(8))


create or alter proc sp_GetManagerInfo @eid int, @salary float output, @managername varchar(50) output
as
begin
    select @salary = E.salary, @managername = E.ename from emp E
    left join emp M ON E.mgr_id = M.EmpNo
    where E.empno = @eid
end

declare @sal float, @mgrname varchar(100)
exec sp_GetManagerInfo 7369, @sal OUTPUT, @mgrname OUTPUT
print'Employee Salary: ' + cast(@sal AS VARCHAR(10))
print 'Manager Name: ' + ISNULL(@mgrname, 'No manager assigned')

--procedures with return type
--create a proc that takes an empid and returns the deptid where the employee works
create or alter proc sp_getDept @eid int
as
begin
	return (select deptno from emp where empno = @eid)
	end

declare @did int
exec @did = sp_getDept 7369
select 'The department of the emplouee is :' + cast(@did as varchar(5))

create or alter proc sp_getempcount @did int
as
begin
	return (Select count(empno) from emp where deptno = @did)
end

declare @totemp int
exec @totemp = sp_getempcount 10
print @totemp

--eg: create a proc that takes deptno as input

create or alter proc sp_getavgsal_empcount (@did int, @avgsal float output)
as
begin
	select @avgsal = avg(salary) from emp where deptno = @did
	return (Select count(empno) from emp where deptno =@did)
	end

	--execute the above
declare @sal float
declare @count int
exec @count = sp_getavgsal_empcount 10,@sal output
print 'total employees in Dept :' + cast(@count as varchar(3)) +
' and the dept avg is : '+cast(@sal as varchar(8))

drop procedure sp_chkerror

--error handling
create proc sp_chkerror
as
begin
 begin try
 select salary + ename from emp where empno = 7369
 end try
 begin catch
 select 'some conversion error occured..check it'
 end catch
end

sp_chkerror

select * from sysmessages where msglangid=1033

create table Products_new
(ProductId int primary key,
ProductName varchar(40),
Price int,
QuantityAvailable int)

insert into products_new values(101,'Laptops',55000,100),
(102,'Desktops',38000,50),(103,'Tablets',65000,35),(104,'Mobiles',75000,70)

--create a productssales table to record sales
create table Productsales
(productSalesID int primary key,
PrdID int,
QuantitySold int)

alter table productsales
add constraint fkprodid foreign key(prdid) references Products(productid)

--will create a procedure to have the sales entry made to update the products table
create or alter proc sp_Product_salesMade
@prdid int,@qtyto_sell int
as
begin
--first 
 declare @stockavailable int
 select @stockavailable = QuantityAvailable from products_new where productid = @prdid
 --if the qty_tosell is more than the stock available 
 if(@stockavailable is null)
 begin 
  raiserror('wrongproduct',15,1)
  end
  if(@stockavailable < @qtyto_sell)
  begin
	raiserror('Not enough stock availble',16,1)
	end
	else
	 begin
	 --let us now start the dml 
	 --first we will reduce the qty available in products table
	 update products set QuantityAvailable = QuantityAvailable - @qtyto_sell
	 where productid=@prdid
	 
	 --after the updation, we will make an insertion int the productsales table
	 -- check if the table is having any data. If no, then some value, else value + 1
	 declare @maxsaleid int

	 select @maxsaleid = case
	  when max(productsalesid) is null then 0
	  else max(productsalesid)
	  end
	  from productsales

	  --increment @maxsaleid by 1, to avoid pk violation
	  set @maxsaleid = @maxsaleid + 1

	  --we can start inserting
	  insert into productsales values(@maxsaleid, @prdid, @qtyto_sell)
	  end
	  --@@error - a global variable that has non 0 value if there was an error, else 0
	  if(@@ERROR <> 0)
	   begin
	    print 'Error ... rolling back'
		end
		else
		begin
		  print 'success'
		  end
end

exec sp_Product_salesMade 102, 10

--Functions
--eg 1
create function fnDisplayDetails(@ename varchar(30), @doj date)
returns nvarchar(100) --tells the db engine that the function return type is nvarch
as
 begin
 return (select @ename + ' ' + 'Joined on'+cast(@doj as varchar(12)))
 end

 -- to execute the functions 
 select fnDisplayDetails(ename,hire_date) from emp

 --can call functions either with a 2 part qualifications/refernce or 3 part
 --2 part
 select dbo.fnDisplayDetails(ename,hire_date) from emp

 --option 2. 3 part qualifier
 select SQL_Assignment1.dbo.fnDisplayDetails(ename,hire_date) from emp

 --ex 1.
 -- write a function that takes employee number and returns the salary

 --write a function to calculate the area of a rectangle
 create or alter function fn_findArea(@ln int,@bd int)
 returns int
 as
 begin
	declare @area int
	set @area  = @ln * @bd
	return @area
	end

	select dbo.fn_findArea(5,6) as 'Area of Rectangle'

	--inline table valued
	create function fn_getEmployeedata(@dept int)
	returns table
	as
	return (select empno,ename,job,deptno,salary from emp where deptno = @dept)

	--to execute
	select ename,job,salary from dbo.fn_getEmployeedata(20)

	select job, avg(salary) from dbo.fn_getEmployeedata(20) group by job
	having avg(salary)>1000
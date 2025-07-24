/* Query 1  Write a T-Sql based procedure to generate complete payslip of a given employee with respect to the following condition
   a) HRA as 10% of Salary
   b) DA as 20% of Salary
   c) PF as 8% of Salary
   d) IT as 5% of Salary
   e) Deductions as sum of PF and IT
   f) Gross Salary as sum of Salary, HRA, DA
   g) Net Salary as Gross Salary - Deduction
Print the payslip neatly with all details*/
create or alter proc payslip_generation @empid int
as
begin
    declare 
        @empname varchar(50),
        @Salary decimal(10,3),
        @HRA decimal(10,3),
        @DA decimal(10,3),
        @PF decimal(10,3),
        @IT decimal(10,3),
        @Deductions decimal(10,3),
        @GrossSalary decimal(10,3),
        @NetSalary decimal(10,3)

    select @empname = empname, @salary = salary from employee where empid = @empid

    set @HRA = @Salary * 0.10
    set @DA = @Salary * 0.20
    set @PF = @Salary * 0.08
    set @IT = @Salary * 0.05
    set @Deductions = @PF + @IT
    set @GrossSalary = @Salary + @HRA + @DA
    set @NetSalary = @GrossSalary - @Deductions

    print '------------ All the Details Employee Payslip -----------'
    print 'Employee ID    : ' + cast(@empid as varchar)
    print 'Employee Name  : ' + @empname
    print 'Current Salary : ' + cast(@Salary as varchar)
    print 'HRA (10%)      : ' + cast(@HRA as varchar)
    print 'DA (20%)       : ' + cast(@DA as varchar)
    print 'PF (8%)        : ' + cast(@PF as varchar)
    print 'IT (5%)        : ' + cast(@IT as varchar)
    print 'Deductions     : ' + cast(@Deductions as varchar)
    print 'Gross Salary   : ' + cast(@GrossSalary as varchar)
    print 'Net Salary     : ' + cast(@NetSalary as varchar)
    print '-------------------------------------------------------'
end

exec payslip_generation @empid = 101

--Query 2 
drop table holidays
create table holidays (
    Holiday_Date date primary key,
    Holiday_Name varchar(50))

insert into holidays values
('2025-07-24', 'independence day'),--for observing the whether the trigger is working or not we can give current date for any holiday
('2025-08-27', 'Ganesh Chaturthi'),
('2025-11-01', 'diwali'),
('2025-10-02', 'gandhi jayanti')

create or alter trigger trg_block_dml_on_holiday
on emp
after insert, update, delete
as
begin
    declare @today date = cast(getdate() as date)
    declare @holiday_name varchar(50)

    select @holiday_name = Holiday_Name from holidays where Holiday_Date = @today;

    if @holiday_name is not null
    begin
        rollback transaction;
        raiserror('-------Due to %s, you cannot manipulate the data Today.-------', 16, 1, @holiday_name);
    end
end

select * from emp
 
insert into emp values(105,'Rosy','MANAGER', 7788, '2019-02-11', 1298, null, 20)
delete from emp where empno=102
update emp set salary = salary + 5000 where empno = 101

drop trigger if exists trg_block_dml_on_holiday on database

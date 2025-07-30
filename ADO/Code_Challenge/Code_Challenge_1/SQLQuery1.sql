create table Employee_Details (
    EmpId INT IDENTITY(1001,1) PRIMARY KEY,
    Name NVARCHAR(100),
    Salary DECIMAL(10,2),
    NetSalary DECIMAL(10,2),
    Gender CHAR(1)
);

Create or alter proc InsertEmployeeDetails
    @Name VARCHAR(100),
    @Salary DECIMAL(10,2),
    @Gender CHAR(1),
    @GeneratedEmpId INT OUTPUT,
    @NetSalary DECIMAL(10,2) OUTPUT
as
begin
    
    set @NetSalary = @Salary - (@Salary * 0.10);

    insert into Employee_Details (Name, Salary, NetSalary, Gender)
    values (@Name, @Salary, @NetSalary, @Gender);

    set @GeneratedEmpId = SCOPE_IDENTITY();
end

select * from Employee_Details


--2

create or alter proc UpdateAndFetchSalary
    @EmpId INT,
    @UpdatedSalary DECIMAL(10,2) OUTPUT
as
begin
   
    update Employee_Details SET Salary = Salary + 100 where EmpId = @EmpId;

    select @UpdatedSalary = Salary from Employee_Details where EmpId = @EmpId;
end

select * from Employee_Details
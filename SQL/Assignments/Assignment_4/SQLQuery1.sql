--1st Query Write a T-SQL Program to find the factorial of a given number.

declare @number int = 10
declare @factorial bigint = 1
while @number > 1
begin
  set @factorial = @factorial * @number
  set @number -= 1
end
print 'Factorial of given number is ' + cast(@factorial as varchar)

--2nd Query Create a stored procedure to generate multiplication table that accepts a number and generates up to a given number. 

create or alter proc Multiplication_Table @number int, @upto_extent int
as
begin
  declare @count int =1
  while @count <= @upto_extent
  begin
    print cast(@number as varchar) + ' x ' + cast(@count as varchar) +' = '+ cast(@number * @count as varchar)
	set @count += 1
  end
end
exec Multiplication_Table 10,10


--3rd Query Create a function to calculate the status of the student. If student score >=50 then pass, else fail. Display the data neatly

create table students (
S_id int primary key,
Sname varchar(10))

create table marks (
Mid int,
S_id int references students(S_id),
Score int)

insert into students values
(1, 'Jack'),
(2, 'Rithvik'),
(3, 'Jaspreeth'),
(4, 'Praveen'),
(5, 'Bisa'),
(6, 'Suraj')

insert into marks values
(1, 1, 23),
(2, 6, 95),
(3, 4, 98),
(4, 2, 17),
(5, 3, 53),
(6, 5, 13)

--3rd Query Create a function to calculate the status of the student. If student score >=50 then pass, else fail. Display the data neatly

create or alter function fn_ResultStatus(@score int)
returns varchar(10)
as
begin
  declare @result varchar(4)
  if(@score >= 50)
    set @result = 'Pass'
  else
    set @result = 'Fail'
  return @result
end

select S.Sname, M.Score, dbo.fn_ResultStatus(M.Score) as Result from Students S
join Marks M on S.S_id = M.S_id


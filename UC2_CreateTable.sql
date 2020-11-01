--UC2 ability to create table to manage employee payrolls
create table employee_payroll
(
id int identity(1,1),
name VARCHAR(25) not null,
salary money not null,
start date not null
);
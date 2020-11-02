--UC8 Extend the employee data table to store phone address and department
use payroll_service
alter table employee_payroll add phone varchar(15);
alter table employee_payroll add department varchar(50);
alter table employee_payroll add address varchar(50);
alter table employee_payroll add constraint df_address default 'India' for address;
select * from employee_payroll;
insert into employee_payroll (name, salary, start) values
('Billi',20000.00,'2018-04-07');
insert into employee_payroll(name, salary, gender, start) values
('Mohan',250000.00,'M','2019-10-10');

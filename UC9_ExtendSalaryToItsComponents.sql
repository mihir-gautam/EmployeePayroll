--UC9 Query to show salary in its components
use payroll_service
alter table employee_payroll
sp_rename 'employee_payroll.salary', 'net_pay';

alter table employee_payroll
add basic_pay money default 40000,
add taxable_pay money default 0,
add income_tax money default 0

insert into employee_payroll (name, net_pay, start) values
('Sam',20000.00,'2018-04-07');
insert into employee_payroll(name, net_pay, gender, start) values
('Naman',250000.00,'M','2019-10-10')

select * from employee_payroll;
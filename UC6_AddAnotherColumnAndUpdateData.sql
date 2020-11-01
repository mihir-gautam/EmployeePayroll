--UC6 ability to add new column on given table
use payroll_service
alter table employee_payroll add gender varchar(1);
select * from employee_payroll
update employee_payroll set gender = 'M' where name = 'Bill' or name = 'Charlie'
update employee_payroll set gender = 'F' where name = 'Terisa'
select * from employee_payroll;
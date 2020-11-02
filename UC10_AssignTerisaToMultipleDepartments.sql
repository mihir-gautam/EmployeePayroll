--UC10 Query to assign terissa to multiple departments
update employee_payroll
set department = 'sales' where name = 'Terisa'

--insert into employee_payroll (name,net_pay,start,gender,department) 
insert into employee_payroll(name,net_pay,start,gender,department)
values ('Terisa',200000.00,'2019-11-13','F','marketing');

select * from employee_payroll;
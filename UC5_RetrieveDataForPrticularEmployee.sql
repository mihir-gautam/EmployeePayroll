--UC5 
-- ability to retrieve data for particular employee
use payroll_service
select salary from employee_payroll
where name = 'Bill'

-- ability to retrieve data for employees after given joining date
select * from employee_payroll
where start between cast('2019-01-01' as date) and getdate()
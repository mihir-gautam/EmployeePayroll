--UC7 ability to find sum, average, min, max and number of male and female employees
use payroll_service
select sum(salary) as sum_of_salary, avg(salary) as avg_of_salary,
min(salary) as min_of_salary, max(salary) as max_of_salary, count(name) as number_of_female_employees
from employee_payroll where gender = 'F' 
group by gender

select sum(salary) as sum_of_salary, avg(salary) as avg_of_salary,
min(salary) as min_of_salary, max(salary) as max_of_salary, count(name) as number_of_male_employees
from employee_payroll where gender = 'M' 
group by gender;
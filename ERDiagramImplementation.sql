--Implement ER Diagram--

/*Create Employee Table*/
Create table Employee
(
EId int identity(1,1) primary key,
EName varchar(20) not null,
Gender char(1) not null,
PhoneNo varchar(15) not null,
Address varchar(50) not null,
StartDate date not null,
)

Insert into Employee values
('Bill','M','9999999999','Mumbai','2018-01-03'),
('Terissa','F','8888888888','Bangalore','2019-05-04'),
('Charlie','M','5555555555','Delhi','2020-02-01');

select * from Employee

/*Create Department Table*/
Create table Department
(
DeptId varchar(5) not null primary key,
DeptName varchar(20) not null
)

Insert into Department values
('D01','Marketing'),
('D02','Sales'),
('D03','Finance');

select * from Department

/*Create Employee_Department Table*/
Create table Employee_Department
(
EmpId int FOREIGN KEY REFERENCES Employee(EId),
DeptId varchar(5) FOREIGN KEY REFERENCES Department(DeptId),
)

Insert into Employee_Department values
(1,'D01'),
(2,'D01'),
(2,'D02'),
(3,'D03');

select * from Employee_Department

/*Create Employee Payroll Table*/
Create table Emp_Payroll
(
EId int not null FOREIGN KEY REFERENCES Employee(EId),
BasicPay money not null,
Deduction money not null,
TaxablePay money not null,
IncomeTax money not null,
NetPay money not null,
)

Insert into Emp_Payroll values
(1,20000,5000,15000,1000,14000),
(2,30000,6000,24000,3000,21000),
(3,40000,10000,30000,5000,25000);

select * from Emp_Payroll

select Gender,SUM(BasicPay) as SUM,
AVG(BasicPay) as AVG, MIN(BasicPay) as MIN,
MAX(BasicPay) as MAX from Employee INNER JOIN Emp_Payroll 
ON Employee.EId = Emp_Payroll.EId GROUP BY Gender;

select BasicPay from Emp_Payroll INNER JOIN Employee ON Emp_Payroll.EId = Employee.EId where EName = 'Bill';

select Employee.EId ,EName,BasicPay,StartDate,Gender,PhoneNo,Address,DeptName,Deduction,TaxablePay,IncomeTax,NetPay from Employee 
INNER JOIN Employee_Department ON Employee.EId = Employee_Department.EmpId
INNER JOIN  Emp_Payroll ON Employee.EId = Emp_Payroll.EId
INNER JOIN Department ON Department.DeptId = Employee_Department.DeptId;
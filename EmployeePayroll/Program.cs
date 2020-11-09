using System;

namespace EmployeePayroll
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to employee payroll program");
            EmployeeRepo employeeRepo = new EmployeeRepo();
            EmployeeModel employee = new EmployeeModel();
            employee.EmployeeName = "Indal";
            employee.Department = "Tech";
            employee.PhoneNumber = "6302907918";
            employee.Address = "02-Khajauli";
            employee.Gender = 'M';
            employee.BasicPay = 10000.00M;
            employee.Deductions = 1500;
            employee.StartDate = employee.StartDate = Convert.ToDateTime("2020-11-03");

            Console.WriteLine("Enter your choice: \n1.Insert New Employee data \n2.Show all employees \n3.Update salary of an employee \n4. Exit");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    employeeRepo.AddEmployee(employee);
                    break;
                case 2:
                    employeeRepo.GetAllEmployee();
                    break;
                case 3:
                    Console.Write("Enter name of the employee: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter new salary: ");
                    int salary = int.Parse(Console.ReadLine());
                    employeeRepo.UpdateSalary(name,salary);
                    break;
            }
        }
    }
}

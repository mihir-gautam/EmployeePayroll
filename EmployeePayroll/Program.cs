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

            Console.WriteLine("Enter your choice: \n1.Insert New Employee data \n2.Show all employees \n3.Update salary of an employee \n4.Get employee joined on a given date range" +
                "\n5.Get salary details group by gender");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.WriteLine("Enter Name ,Department, Phone no, Address, Gender, BasicPay, Deduction, Taxable Pay, Tax, NetPay ");
                    string[] details = Console.ReadLine().Split(",");

                    EmployeeModel newEmp = new EmployeeModel();
                    newEmp.EmployeeName = details[0];
                    newEmp.Department = details[1];
                    newEmp.PhoneNumber = details[2];
                    newEmp.Address = details[3];
                    newEmp.Gender = Convert.ToChar(details[4]);
                    newEmp.StartDate = DateTime.Today;
                    newEmp.BasicPay = Convert.ToDecimal(details[5]);
                    newEmp.Deductions = Convert.ToInt32(details[6]);
                    newEmp.TaxablePay = Convert.ToInt32(details[7]);
                    newEmp.Tax = Convert.ToInt32(details[8]);
                    newEmp.NetPay = Convert.ToInt32(details[5]);
                    bool result = employeeRepo.AddEmployee(employee);
                    if (result == false)
                    {
                        Console.WriteLine("Employee can not be added.");
                        break;
                    }
                    Console.WriteLine("Records added successfully");
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
                case 4:
                    Console.WriteLine("Enter Dates");
                    string[] dates = Console.ReadLine().Split(",");
                    employeeRepo.GetEmployeesGivenDateRange(Convert.ToDateTime(dates[0]), Convert.ToDateTime(dates[1]));
                    break;
                case 5:
                    employeeRepo.GetSalaryDetailsByGender();
                    break;
            }
        }
    }
}

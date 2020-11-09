using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayroll;
using System;

namespace EmployeePayrollMSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Given_NameAndSalary_UpdateSalary_Should_Return_True()
        {
            EmployeeRepo employeeRepo = new EmployeeRepo();
            string name = "Terissa";
            decimal salary = 3000000M;

            bool result = employeeRepo.UpdateSalary(name, salary);

            Assert.AreEqual(true, result);
        }
        EmployeeRepo employeeRepo = new EmployeeRepo();
        [TestMethod]
        public void Given_NewEmployeeWhenAdded_Should_SyncWithDB()
        {
            EmployeeModel employee = new EmployeeModel();
            employee.EmployeeName = "Ankit";
            employee.Department = "Marketing";
            employee.PhoneNumber = "245342636";
            employee.Address = "Uttam nagar";
            employee.Gender = 'F';
            employee.StartDate = DateTime.Now;
            employee.BasicPay = 200000;
            employee.Deductions = 15000;
            employee.TaxablePay = 150000;
            employee.Tax = 20000;
            employee.NetPay = 110000;

            bool result = employeeRepo.AddEmployee(employee);
            Assert.AreEqual(result, true);
        }
    }
}

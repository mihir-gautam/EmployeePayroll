using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayroll
{
    public class SalaryUpdateModel
    {
        public int SalaryId { get; set; }
        public string Month { get; set; }
        public int EmployeeSalary { get; set; }
        public int EmployeeId { get; set; }
    }
}

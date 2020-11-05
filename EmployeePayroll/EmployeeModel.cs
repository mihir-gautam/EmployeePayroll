using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayroll
{
    class EmployeeModel
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public char Gender { get; set; }
        public decimal BasicPay { get; set; }
        public int Deductions { get; set; }
        public int TaxablePay { get; set; }
        public int Tax { get; set; }
        public double NetPay { get; set; }
        public DateTime StartDate { get; set; }
        public string City { get; set; }
        public double Country { get; set; }

    }


}

using System;
using System.Linq;

namespace Data.Models
{
    public class EmployeeValidator
    {
        readonly Employee _employee;

        public EmployeeValidator(Employee employee)
        {
            _employee = employee ?? throw new ArgumentNullException();
        }

        public bool IsValidAustralianAddress()
        {
            return _employee.Addresses?.Any(e => e.PostCode == "6000") ?? false;
        }
    }
}

using System;
using System.Linq;

namespace Data.Models
{
    public class AustralianAddressValidator
    {
        readonly Employee _employee;

        public AustralianAddressValidator(Employee employee)
        {
            _employee = employee ?? throw new ArgumentNullException();
        }

        public bool IsValidate()
        {
            return _employee.Addresses?.Any(e => e.PostCode == "6000") ?? false;
        }
    }
}

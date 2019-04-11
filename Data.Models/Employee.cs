using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{ 
    public class Employee
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public IList<Address> Addresses { get; set; }
    }
}

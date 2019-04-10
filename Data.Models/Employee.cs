using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderLibraryTests.DataModels
{
    public class Employee
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
    }
}

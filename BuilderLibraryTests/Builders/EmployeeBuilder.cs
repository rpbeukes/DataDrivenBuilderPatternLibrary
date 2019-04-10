using BuilderLibrary;
using BuilderLibraryTests.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderLibraryTests.Builders
{
    public class EmployeeBuilder : BuilderBase<Employee, EmployeeBuilder>
    {
        AddressBuilder _addressBuilder = new AddressBuilder();

        public EmployeeBuilder WithAParticularRequirements()
        {
            _concreteObject = new Employee()
            {
                Name = "The Name",
                LastName = "The LastName",

                Addresses = new List<Address>
                {
                    //default values
                    _addressBuilder.WithDefaultTestValues().Build(),
                    // change some values
                    _addressBuilder.WithDefaultTestValues()
                                   .With(x => x.PostCode = "7777")
                                   .Build(),
                    // null values
                    _addressBuilder.Build()
                }
            };

            return this;
        }
    }
}

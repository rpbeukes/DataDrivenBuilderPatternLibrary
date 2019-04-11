using BuilderLibrary;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderLibraryTests.Builders
{
    public class EmployeeBuilder : BuilderBase<Employee, EmployeeBuilder>
    {
        AddressBuilder _addressBuilder = new AddressBuilder();

        public EmployeeBuilder WithParticularScenarionOfRequirements()
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

        public EmployeeBuilder WithEmployeeFromAustralia()
        {
            _concreteObject = new Employee()
            {
                Name = "Bruce",
                LastName = "Ozzy",

                Addresses = new List<Address>
                {
                    //default values
                    _addressBuilder.WithAustralianAddress().Build(),
                }
            };

            return this;
        }

        public EmployeeBuilder WithEmployeeFromSouthAfrica()
        {
            _concreteObject = new Employee()
            {
                Name = "John",
                LastName = "Long",

                Addresses = new List<Address>
                {
                    //default values
                    _addressBuilder.WithSouthAfricanAddress().Build(),
                }
            };

            return this;
        }
    }
}

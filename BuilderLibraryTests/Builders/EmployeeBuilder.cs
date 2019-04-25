using BuilderLibrary;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuilderLibraryTests.Builders
{
    public class EmployeeBuilder : BuilderBase<Employee, EmployeeBuilder>
    {
        AddressBuilder _addressBuilder = new AddressBuilder();

        public EmployeeBuilder WithParticularScenarioOfRequirements()
        {
            _concreteObject = new Employee()
            {
                Name = "The Name",
                LastName = "The LastName",

                Addresses = new List<Address>
                {
                    // default values
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
                    // default values
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
                    // default values
                    _addressBuilder.WithSouthAfricanAddress().Build(),
                }
            };

            return this;
        }

        /// <summary>
        /// Only add address when not in address list
        /// </summary>
        public EmployeeBuilder AddSouthAfricanAddress()
        {
            return AddAddress(() => _addressBuilder.WithSouthAfricanAddress().Build());
        }

        /// <summary>
        /// Only add address when not in address list
        /// </summary>
        public EmployeeBuilder AddAustralianAddress()
        {
            return AddAddress(() => _addressBuilder.WithAustralianAddress().Build());
        }

        private EmployeeBuilder AddAddress(Func<Address> addressCreator)
        {
            var address = addressCreator?.Invoke();

            // let's assume the post code is unique and identifies an address
            // we only add when if it doesn't exist in the list.
            if (!_concreteObject.Addresses.Any(a => a.PostCode == address?.PostCode))
                _concreteObject.Addresses.Add(address);

            return this;
        }
    }
}

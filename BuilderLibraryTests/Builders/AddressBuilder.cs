using BuilderLibrary;
using Data.Models;
using System;

namespace BuilderLibraryTests.Builders
{
    public class AddressBuilder : BuilderBase<Address, AddressBuilder>
    {
        public AddressBuilder WithDefaultTestValues()
        {
            _concreteObject = new Address()
            {
                Suburb = "Suburb",
                PostCode = "1234",
                StreetNumber = 88
            };

            return this;
        }

        public AddressBuilder WithAustralianAddress()
        {
            _concreteObject = new Address()
            {
                Suburb = "Perth",
                PostCode = "6000",
                StreetNumber = 22
            };

            return this;
        }

        public AddressBuilder WithSouthAfricanAddress()
        {
            _concreteObject = new Address()
            {
                Suburb = "Sandton",
                PostCode = "2066",
                StreetNumber = 11
            };

            return this;
        }
    }
}

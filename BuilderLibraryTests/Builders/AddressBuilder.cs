using BuilderLibrary;
using BuilderLibraryTests.DataModels;
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
    }
}

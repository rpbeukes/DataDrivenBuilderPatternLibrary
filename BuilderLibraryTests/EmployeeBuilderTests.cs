using BuilderLibraryTests.Builders;
using Data.Models;
using Shouldly;
using System;
using System.Linq;
using Xunit;

namespace BuilderLibraryTests
{
    public class EmployeeBuilderTests
    {
        [Fact]
        public void SimpleEmployeeBuilder()
        {
            const string expectedText = "Test name";

            var builder = new EmployeeBuilder();

            var actual = builder.With(x => x.Name = expectedText)
                                .Build();

            actual.Name.ShouldBe(expectedText);
        }

        [Fact]
        public void SimpleEmployeeBuilderSetMoreThanOneValue()
        {
            var builder = new EmployeeBuilder();

            var actual = builder.With(x =>
            {
                x.Name = "First";
                x.LastName = "Last";
            })
            .Build();

            actual.Name.ShouldBe("First");
            actual.LastName.ShouldBe("Last");
        }

        [Fact]
        public void SpecificRequirementsCall()
        {
            var builder = new EmployeeBuilder();

            var actual = builder.WithParticularScenarionOfRequirements()
                                .Build();

            actual.Name.ShouldBe("The Name");
            actual.LastName.ShouldBe("The LastName");
            actual.Addresses.Count().ShouldBe(3);
        }

        [Fact]
        public void EmployeeMustAtLeastHaveOneAussieAddress()
        {
            var builder = new EmployeeBuilder();

            var actual = builder.WithEmployeeFromAustralia()
                                .With(e => e.Addresses.Add(new AddressBuilder()
                                                                    .WithSouthAfricanAddress()
                                                                    .Build())
                                     )
                                .Build();

            actual.Addresses.Count().ShouldBeGreaterThan(1);
            actual.Addresses.Any(a => a.PostCode == "6000").ShouldBeTrue("No Aussie address detected.");
        }

        [Fact]
        public void AustralianAddressValidator_EmployeeAddressShouldBeValidWhenAnyPostCodeFromAustralia()
        {
            //arrange
            var builder = new EmployeeBuilder();

            var employee = builder.WithEmployeeFromAustralia()
                                  .Build();

            //act
            //system under test
            var sut = new AustralianAddressValidator(employee);

            //assert
            sut.IsValidate().ShouldBeTrue();
        }

        [Fact]
        public void AustralianAddressValidator_EmployeeAddressShouldBeInvalidWhenNoAustralianPostCodeDetected()
        {
            var builder = new EmployeeBuilder();

            var employee = builder.WithEmployeeFromSouthAfrica()
                                  .Build();
            //system under test
            var sut = new AustralianAddressValidator(employee);

            sut.IsValidate().ShouldBeFalse();
        }
    }
}

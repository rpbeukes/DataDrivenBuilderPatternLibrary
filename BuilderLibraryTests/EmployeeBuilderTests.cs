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

            var actual = builder.WithParticularScenarioOfRequirements()
                                .Build();

            actual.Name.ShouldBe("The Name");
            actual.LastName.ShouldBe("The LastName");
            actual.Addresses.Count().ShouldBe(3);
        }

        [Fact]
        public void UsingAnotherBuilderInSetup_EmployeeMustAtLeastHaveOneAussieAddress()
        {
            var builder = new EmployeeBuilder();

            var actual = builder.WithEmployeeFromAustralia()
                                // mix things up a bit and add another address manually by instantiating a new AddressBuilder
                                .With(e => e.Addresses.Add(new AddressBuilder()
                                                                    .WithSouthAfricanAddress()
                                                                    .Build())
                                     )
                                .Build();

            actual.Addresses.Count().ShouldBeGreaterThan(1);
            actual.Addresses.Any(a => a.PostCode == "6000").ShouldBeTrue("No Aussie address detected.");

            
            // same test BUT this time request a builder via the .With<TRequestBuilder> instead of instantiating it.
            builder = new EmployeeBuilder();
            actual = builder.WithEmployeeFromAustralia()
                                .With<AddressBuilder>((e, addressBuilder) => e.Addresses.Add(addressBuilder
                                                                                       .WithSouthAfricanAddress()
                                                                                       .Build())
                                                     )
                                .Build();

            actual.Addresses.Count().ShouldBeGreaterThan(1);
            actual.Addresses.Any(a => a.PostCode == "6000").ShouldBeTrue("No Aussie address detected.");
        }

        [Fact]
        public void RemoveManualAddingAnAddressIntoAIntoANiceAddMethod_EmployeeMustAtLeastHaveOneAussieAddressJustAnotherWayToCreateTest()
        {
            var builder = new EmployeeBuilder();

            var actual = builder.WithEmployeeFromAustralia()
                                .AddSouthAfricanAddress()
                                .Build();

            actual.Addresses.Count().ShouldBeGreaterThan(1);
            actual.Addresses.Any(a => a.PostCode == "6000").ShouldBeTrue("No Aussie address detected.");
        }

        [Fact]
        public void AddMethodShouldOnlyAddOnce_EmployeeMustAtLeastHaveOneAussieAddressJustAnotherWayToCreateTest()
        {
            var builder = new EmployeeBuilder();

            var actual = builder.WithEmployeeFromAustralia() //addresses 1 => aus 
                                .AddSouthAfricanAddress()    //addresses 2 => aus, south afr. address
                                .AddSouthAfricanAddress()    //must not add a third address
                                .Build();

            actual.Addresses.Count().ShouldNotBe(3);
            actual.Addresses.Count().ShouldBe(2);
            actual.Addresses.Any(a => a.PostCode == "6000").ShouldBeTrue("No Aussie address detected.");
        }
    }
}

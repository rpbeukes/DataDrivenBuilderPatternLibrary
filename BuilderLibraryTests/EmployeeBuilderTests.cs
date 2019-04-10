using BuilderLibraryTests.Builders;
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

            var actual = builder.WithAParticularRequirements()
                                .Build();

            actual.Name.ShouldBe("The Name");
            actual.LastName.ShouldBe("The LastName");
            actual.Addresses.Count().ShouldBe(3);
        }
    }
}

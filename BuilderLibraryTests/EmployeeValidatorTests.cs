using BuilderLibraryTests.Builders;
using Data.Models;
using Shouldly;
using System;
using System.Linq;
using Xunit;

namespace BuilderLibraryTests
{
    public class EmployeeValidatorTests
    {
        [Fact]
        public void EmployeeValidatorTests_EmployeeAddressShouldBeVALIDWhenAnyPostCodeFromAustraliaDetected()
        {
            //arrange
            var builder = new EmployeeBuilder();

            var employee = builder.WithEmployeeFromAustralia()
                                  .Build();

            //act
            //system under test
            var sut = new EmployeeValidator(employee);

            //assert
            sut.IsValidAustralianAddress().ShouldBeTrue();
        }

        [Fact]
        public void EmployeeValidatorTests_EmployeeAddressShouldBeINVALIDWhenNoAustralianPostCodeDetected()
        {
            //arrange
            var builder = new EmployeeBuilder();

            var employee = builder.WithEmployeeFromSouthAfrica()
                                  .Build();
            //act
            //system under test
            var sut = new EmployeeValidator(employee);

            //assert
            sut.IsValidAustralianAddress().ShouldBeFalse();
        }
    }
}

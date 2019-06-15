using ApprovalTests;
using ApprovalTests.Reporters;
using Data.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using Xunit;

namespace BuilderLibraryTests.ApprovalTests
{
    public class SimpleApprovalTests
    {
        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public void ThisIsASimpleTests()
        {
            var address = new Address()
            {
                PostCode = "6000",
                StreetNumber = 12,
                Suburb = "Wallaby"
            };

            var jsonAddress = JsonConvert.SerializeObject(address, Formatting.Indented);

            Approvals.Verify(jsonAddress);
        }
    }
}

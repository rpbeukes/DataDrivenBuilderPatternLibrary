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

            var jsonAddress = JsonConvert.SerializeObject(address);

            Approvals.VerifyJson(jsonAddress);
            
            // few other cool features I'd like to use when the scenario calls for it.
            // Approvals.VerifyHtml(htmlString);
            // Approvals.VerifyPdfFile(pdfFilePath);
            // Approvals.VerifyXml(xmlString);
            
        }
    }
}

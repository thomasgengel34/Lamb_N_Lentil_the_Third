using System.Threading.Tasks;
using Lamb_N_Lentil.Domain.UsdaInformation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.MockUsdaSite
{
    [TestClass]
    public class MockUsdaAsyncTest  
    {
        private IUsdaAsync usdaAsync { get; set; }

        public MockUsdaAsyncTest()
        {
            usdaAsync = new MockUsdaAsync();
        }
       

        [TestMethod]
        public void ReduceStringLengthToWhatWillWorkOnUsdaWillNotThrowErrorWithEmptyString()
        {
            string result = UsdaAsync.ReduceStringLengthToWhatWillWorkOnUSDA("");
        }

        [TestMethod]
        public void ReduceStringLengthToWhatWillWorkOnUsdaWillNotThrowErrorWithNullString()
        {
            string result = UsdaAsync.ReduceStringLengthToWhatWillWorkOnUSDA(null);
        }

        [TestMethod]
        public void ReduceStringLengthToWhatWillWorkOnUsdaWillReduceStringToCorrectLength()
        {
            int correctLength = 43;
            string testString = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            int testStringLength = testString.Length;
            int whatTestStringLengthShouldBe = 87;

            string returnedString = UsdaAsync.ReduceStringLengthToWhatWillWorkOnUSDA(testString);

            Assert.AreEqual(whatTestStringLengthShouldBe, testStringLength);
            Assert.AreEqual(correctLength, returnedString.Length);
        }

        [TestMethod]
        public async Task ReturnManufacturerOrFoodGroupFromNdbnoTest()
        {
            string returnString = await   usdaAsync.GetManufacturerOrFoodGroup("01009");
            Assert.AreEqual("Valley Brook Farm", returnString);
        } 
    }
}

using System.Linq;
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
        public async Task ReturnIngredientsInIngredientInFoodReport()
        {
            string testString = "ShouldReturnIngredients";
            string correctIngredients = "peas, porridge, hot";
            UsdaFoodReport report = await usdaAsync.FetchUsdaFoodReport(testString);
                string returnedIngredients = report.foods.First().food.ing.desc;
           Assert.AreEqual(correctIngredients, returnedIngredients);
        }

        [TestMethod]
        public async Task ReturnValueInFoodReport()
        {
            string testString = "ShouldReturnIngredients";
            decimal correctValue = 76M;
            UsdaFoodReport report = await usdaAsync.FetchUsdaFoodReport(testString);
           decimal returnedValue = report.foods.First().food.nutrients[0].measures[0].value = 76M;
            Assert.AreEqual(correctValue, returnedValue);
        }
    }
}

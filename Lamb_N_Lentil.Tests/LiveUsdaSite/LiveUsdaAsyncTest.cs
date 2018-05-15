using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lamb_N_Lentil.Domain;
using Lamb_N_Lentil.Domain.UsdaInformation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.LiveUsdaSite
{
    [TestClass]
    public class LiveUsdaAsyncTest 
    { 
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
       public async Task  ShouldGetListOfIngredientsFromTextSearch()
        {
            string testString = "cream";
               List<IIngredient> list = await new UsdaAsync().GetListOfIngredientsFromTextSearch(testString );

            Assert.IsNotNull(list);
            Assert.IsInstanceOfType(list, typeof(List<IIngredient>));
        }

        [TestMethod]
        public async Task ShouldCreateNewIngredientsListWhenNoResultsASreFound()
        {
            string testString = "qq";
            List<IIngredient> list = await new UsdaAsync().GetListOfIngredientsFromTextSearch(testString );

            Assert.IsNotNull(list);
            Assert.IsInstanceOfType(list, typeof(List<IIngredient>));
        }

          

        [TestMethod]
        public async Task ReturnIngredientsListInFoodReport()
        {
            IUsdaAsync usdaAsync = new UsdaAsync();
            string testNdbno = "45032698";
            string correctIngredients = "DICED PEACHES, WATER, SUGAR, NATURAL FLAVORS, ASCORBIC ACID (VITAMIN C) TO PROTECT COLOR, CITRIC ACID.";
             
            UsdaFoodReport report = await usdaAsync.FetchUsdaFoodReport(testNdbno);
            string returnedIngredients = report.foods.First().food.ing.desc;
            Assert.AreEqual(correctIngredients, returnedIngredients);
        }

        [TestMethod]
        public async Task ReturnIngredientsListInFoodReportFor078895122565()
        {
            IUsdaAsync usdaAsync = new UsdaAsync();
            string testString = "078895122565";
            string correctIngredients = "SUGAR, SALTED PLUMS (PLUMS, SALT), WATER, RICE VINEGAR, MODIFIED CORN STARCH, GINGER, CITRIC ACID, SODIUM CITRATE, CHILI PEPPERS, XANTHAN GUM.";

            List<IIngredient> list = await new UsdaAsync().GetListOfIngredientsFromTextSearch(testString);
            UsdaFoodReport report = await usdaAsync.FetchUsdaFoodReport(list.First().Ndbno);
            string returnedIngredients = report.foods.First().food.ing.desc;
            Assert.AreEqual(correctIngredients, returnedIngredients);
        } 
    }
}

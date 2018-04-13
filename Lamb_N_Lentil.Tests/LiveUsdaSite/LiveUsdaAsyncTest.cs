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
        public async Task ReturnManufacturerFromNdbnoRealDatabase()
        {
            string aRealNdbno = "45059050";
            string realManufacturerOrFoodGroup = "Valley Brook Farm";
            string returnedValue = await new UsdaAsync().GetManufacturerOrFoodGroup(aRealNdbno);
            Assert.AreEqual(realManufacturerOrFoodGroup, returnedValue);
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
        public async Task ShouldIgnoreAnIngredientInStandardReferenceWhenBuildingAList()
        { 
            string testNdbno = "1050";  //  this is in search for cream, is the second, is in SR
            string testString = "cream";
            List<IIngredient> list = await new UsdaAsync().GetListOfIngredientsFromTextSearch(testString, "");

            var ndbnosReturned = from r in list
                                 where r.Ndbno == testNdbno
                                 select r.Ndbno;

            string  ndbnoReturned = ndbnosReturned.FirstOrDefault();

            Assert.AreEqual(null, ndbnoReturned);  
        }


        [TestMethod]
       public async Task  ShouldGetListOfIngredientsFromTextSearch()
        {
            string testString = "cream";
               List<IIngredient> list = await new UsdaAsync().GetListOfIngredientsFromTextSearch(testString,"");

            Assert.IsNotNull(list);
            Assert.IsInstanceOfType(list, typeof(List<IIngredient>));
        }

        [TestMethod]
        public async Task ShouldCreateNewIngredientsListWhenNoResultsASreFound()
        {
            string testString = "qq";
            List<IIngredient> list = await new UsdaAsync().GetListOfIngredientsFromTextSearch(testString, "");

            Assert.IsNotNull(list);
            Assert.IsInstanceOfType(list, typeof(List<IIngredient>));
        }

         

        [TestMethod]
        public async Task ReturnSomethingFromTheDataBaseWhenBothDatabasesAreSpecified()
        {
            string searchString = "Butter";
            string dbSearchParameter = UsdaDataSource.Both.ToString();
            IUsdaAsync usdaAsync = new UsdaAsync();

            List<IIngredient> list = await usdaAsync.GetListOfIngredientsFromTextSearch(searchString, dbSearchParameter);

            Assert.AreEqual(4415,usdaAsync.FetchedTotalFromSearch);
        }
    }
}

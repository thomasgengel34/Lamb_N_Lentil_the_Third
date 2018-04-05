using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lamb_N_Lentil.Domain;
using Lamb_N_Lentil.Domain.UsdaInformation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.LiveUsdaSite
{
    [TestClass]
    public class LiveUsdaAsyncTest : IUsdaAsync, IMapUsdaFoodToIngredient
    {
        async Task<string> IMapUsdaFoodToIngredient.GetManufacturerOrFoodGroup(int ndbno)
        {
            string foo = "this is a test";
            await Task.Delay(0);
            return foo;
        }

         Task<List<IIngredient>> GetListOfIngredientsFromTextSearch(string searchString, string dataSource = "") => throw new NotImplementedException();

        async Task<string> IUsdaAsync.GetManufacturerOrFoodGroup(int ndbno)
        {
            string foo = "this is fake for now";
            await Task.Delay(0);
            return foo;
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
            int testNdbno = 1050;  //  this is in search for cream, is the second, is in SR
            string testString = "cream";
            List<IIngredient> list = await new UsdaAsync().GetListOfIngredientsFromTextSearch(testString, "");

            var ndbnosReturned = from r in list
                                 where r.Ndbno == testNdbno
                                 select r.Ndbno;

            int? ndbnoReturned = ndbnosReturned.FirstOrDefault();

            Assert.AreEqual(0, ndbnoReturned);  
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


         Task<List<IIngredient>> IUsdaAsync.GetListOfIngredientsFromTextSearch(string searchString, string dataSource) => throw new NotImplementedException();
    }
}

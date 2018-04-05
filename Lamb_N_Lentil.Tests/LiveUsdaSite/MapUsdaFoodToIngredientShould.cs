using System.Threading.Tasks;
using Lamb_N_Lentil.Domain.UsdaInformation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.LiveUsdaSite

{
    [TestClass]
    public class MapUsdaFoodToIngredientShould
    {
        IMapUsdaFoodToIngredient tester = new LiveUsdaAsyncTest();

       [TestMethod]
        public async Task  ReturnManufacturerOrFoodGroupFromNdbnoTest()
        {
            string returnString = await   tester.GetManufacturerOrFoodGroup(1);
            Assert.AreEqual("this is a test", returnString);
        }

        [TestMethod]
        public async Task ReturnManufacturerFromNdbnoRealDatabase()
        {
            int aRealNdbno = 45059050;
            string realManufacturerOrFoodGroup = "Valley Brook Farm";
            string returnedValue = await new MapUsdaFoodToIngredient().GetManufacturerOrFoodGroup(  aRealNdbno);
            Assert.AreEqual(realManufacturerOrFoodGroup, returnedValue);
           
        }

        [TestMethod]
        public async Task ReturnFoodGroupFromNdbnoRealDatabase()
        {
            int aRealNdbno = 11090;
            string realManufacturerOrFoodGroup = "Vegetables and Vegetable Products";
            string returnedValue = await new MapUsdaFoodToIngredient().GetManufacturerOrFoodGroup(aRealNdbno);
            Assert.AreEqual(realManufacturerOrFoodGroup, returnedValue); 
        }
    }
}

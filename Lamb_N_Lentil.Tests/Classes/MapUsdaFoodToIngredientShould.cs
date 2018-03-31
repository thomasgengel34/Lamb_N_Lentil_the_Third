using System;
using System.Threading.Tasks;
using Lamb_N_Lentil.Domain;
using Lamb_N_Lentil.Domain.UsdaInformation;
using Lamb_N_Lentil.Tests.Controllers;
using Lamb_N_Lentil.Tests.UsdaInformationTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.Classes
{
    [TestClass]
    public class MapUsdaFoodToIngredientShould
    {
        IMapUsdaFoodToIngredient tester = new UsdaAsyncTest();

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

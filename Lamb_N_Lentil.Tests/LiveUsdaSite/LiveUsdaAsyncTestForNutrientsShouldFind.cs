using System;
using System.Linq;
using System.Threading.Tasks;
using Lamb_N_Lentil.Domain.UsdaInformation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.LiveUsdaSite
{
    [TestClass]
    public class LiveUsdaAsyncTestForNutrientsShouldFind
    {
        [TestMethod]
        public async Task ServingSizeForKiwiNdbno45209709()
        {
            IUsdaAsync usdaAsync = new UsdaAsync();
            string testNdbno = "45209709";
            string correctServingSize = "cup";
                 UsdaFoodReport report = await usdaAsync.FetchUsdaFoodReport(testNdbno);
            string returnedServingSize = report.foods.First().food.nutrients.First().measures.First().label;
            Assert.AreEqual(correctServingSize, returnedServingSize);
        }

        [TestMethod]
        public async Task CaloriesForParfaitShooter45086582()
        {
            IUsdaAsync usdaAsync = new UsdaAsync();
            string testNdbno = "45086582";
            int correctkcal = 190;
            UsdaFoodReport report = await usdaAsync.FetchUsdaFoodReport(testNdbno);
            int returnedkcal = Convert.ToInt16(report.foods[0].food.nutrients[0].measures[0].value);
            Assert.AreEqual(correctkcal, returnedkcal);
        } 
    }
}

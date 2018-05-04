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

        [TestMethod]
        public async Task TotalFatFor45322307SpumoniIceCream()
        {
            IUsdaAsync usdaAsync = new UsdaAsync();
            string testNdbno = "45322307";
            decimal correctTotalFat = 9.72M;
            UsdaFoodReport report = await usdaAsync.FetchUsdaFoodReport(testNdbno);
            decimal returnedTotalFat = Convert.ToDecimal(report.foods[0].food.nutrients[2].value);
            Assert.AreEqual(correctTotalFat, returnedTotalFat);
        }

        [TestMethod]
        public async Task TotalCarbohydratesFor45034705CreamOfWheatInstantHotCereal()
        {
            IUsdaAsync usdaAsync = new UsdaAsync();
            string testNdbno = "45034705";
            decimal correctTotalCarbohydrates = 71.43M;
            UsdaFoodReport report = await usdaAsync.FetchUsdaFoodReport(testNdbno);
            decimal returnedTotalCarbohydrates = Convert.ToDecimal(report.foods[0].food.nutrients[3].value);
            Assert.AreEqual(correctTotalCarbohydrates, returnedTotalCarbohydrates);
        }

        [TestMethod]
        public async Task SodiumFor45169419OrganicPepperSauce()
        {
            IUsdaAsync usdaAsync = new UsdaAsync();
            string testNdbno = "45169419";
            decimal correctSodium = 10M;
            UsdaFoodReport report = await usdaAsync.FetchUsdaFoodReport(testNdbno);
            decimal returnedSodium = Convert.ToDecimal((from c in report.foods[0].food.nutrients
                                                       where c.nutrient_id == 307
                                                       select c.measures[0].value).First());
            Assert.AreEqual(correctSodium, returnedSodium);
        }

        [TestMethod]
        public async Task SaturatedFatFor45169419OrganicPepperSauce()
        { 
            IUsdaAsync usdaAsync = new UsdaAsync();
            string testNdbno = "45169419";
            int thisIsNotFoundSoShouldBeZero = 0;
            UsdaFoodReport report = await usdaAsync.FetchUsdaFoodReport(testNdbno);
            var returned  = (from c in report.foods[0].food.nutrients
                                                        where c.nutrient_id == 606
                                                        select c.measures[0].value).FirstOrDefault() ;
            Assert.AreEqual(thisIsNotFoundSoShouldBeZero, returned);
        }

        [TestMethod]
        public async Task PolyunsaturatedFatFor45035274SandwichWhiteBread()
        {
            IUsdaAsync usdaAsync = new UsdaAsync();
            string testNdbno = "45035274";
            decimal correctResult = 0.499M;
            UsdaFoodReport report = await usdaAsync.FetchUsdaFoodReport(testNdbno);
            var returned = (from c in report.foods[0].food.nutrients
                            where c.nutrient_id == 646
                            select c.measures[0].value).FirstOrDefault();
            Assert.AreEqual(correctResult, returned);
        }
   
         
        [TestMethod]
        public async Task SaturatedFatForYellowClingPeaches45032698()
        {
            IUsdaAsync usdaAsync = new UsdaAsync();
            string testNdbno = "45032698";
            decimal correctSaturatedFat = 0.00m;
            UsdaFoodReport report = await usdaAsync.FetchUsdaFoodReport(testNdbno);
            var returned = (from c in report.foods[0].food.nutrients
                            where c.nutrient_id == 606
                            select c.measures[0].value).FirstOrDefault();
            Assert.AreEqual(correctSaturatedFat, returned);
        }

        [TestMethod]
        public async Task TransFatForSoftMargineUPC041250040538_45037282()
        {
            IUsdaAsync usdaAsync = new UsdaAsync();
            string testNdbno = "45037282";
            decimal correct = 1.00m;
            UsdaFoodReport report = await usdaAsync.FetchUsdaFoodReport(testNdbno);
            var returned = (from c in report.foods[0].food.nutrients
                            where c.nutrient_id == 605
                            select c.measures[0].value).FirstOrDefault();
            Assert.AreEqual(correct , returned);
        }
    }
}

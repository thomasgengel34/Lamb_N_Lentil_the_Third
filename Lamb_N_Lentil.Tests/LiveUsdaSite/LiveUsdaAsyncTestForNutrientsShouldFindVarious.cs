using System;
using System.Linq;
using System.Threading.Tasks;
using Lamb_N_Lentil.Domain.UsdaInformation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.LiveUsdaSite
{
    [TestClass]
    public class LiveUsdaAsyncTestForNutrientsShouldFindVarious
    { 
        IUsdaAsyncFoodReport usdaAsync;

        public LiveUsdaAsyncTestForNutrientsShouldFindVarious()
        {
            usdaAsync  = new UsdaAsyncFoodReport();
        }

        [TestMethod]
        public async Task CaloriesForVanillaIceCream19095()
        { 
            string testNdbno = "19095";
            int correctkcal = 137;
            UsdaFoodReport report = await usdaAsync.FetchUsdaFoodReport(testNdbno);
            var result = from r in report.foods[0].food.nutrients
                         where r.name == "Energy"
                         select r.measures[0].value;
    int returnedkcal = Convert.ToInt16(result.First());
            Assert.AreEqual(correctkcal, returnedkcal);
        }

        [TestMethod]
        public async Task TotalFatFor45322307SpumoniIceCream()
        { 
            string testNdbno = "45322307";
            decimal correctTotalFat = 9.72M;
            UsdaFoodReport report = await usdaAsync.FetchUsdaFoodReport(testNdbno);
            decimal returnedTotalFat = Convert.ToDecimal(report.foods[0].food.nutrients[2].value);
            Assert.AreEqual(correctTotalFat, returnedTotalFat);
        }

        [TestMethod]
        public async Task TotalCarbohydratesFor45034705CreamOfWheatInstantHotCereal()
        { 
            string testNdbno = "45034705";
            decimal correctTotalCarbohydrates = 71.43M;
            UsdaFoodReport report = await usdaAsync.FetchUsdaFoodReport(testNdbno);
            decimal returnedTotalCarbohydrates = Convert.ToDecimal(report.foods[0].food.nutrients[3].value);
            Assert.AreEqual(correctTotalCarbohydrates, returnedTotalCarbohydrates);
        }


        [TestMethod]
        public async Task PolyunsaturatedFatFor04585Margarine_LikeMargarine_Butter_Blend_Soybean_Oil_And_Butter()
        { 
            string testNdbno = "04585";
            decimal correctResult = 3.408M;
            UsdaFoodReport report = await usdaAsync.FetchUsdaFoodReport(testNdbno);
            var returned = (from c in report.foods[0].food.nutrients
                            where c.nutrient_id == 646
                            select c.measures[0].value).FirstOrDefault();
            Assert.AreEqual(correctResult, returned);
        }
   
         
        [TestMethod]
        public async Task SaturatedFatForYellowClingPeaches45032698()
        { 
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
            string testNdbno = "45037282";
            decimal correct = 1.00m;
            UsdaFoodReport report = await usdaAsync.FetchUsdaFoodReport(testNdbno);
            var returned = (from c in report.foods[0].food.nutrients
                            where c.nutrient_id == 605
                            select c.measures[0].value).FirstOrDefault();
            Assert.AreEqual(correct , returned);
        }

        [TestMethod]
        public async Task PotassiumFoKrogerBlendedGradeALowFatStrawberryYogurtUPC011110452979()
        { 
            string testNdbno = "45114174";
            decimal correct = 330M;
            UsdaFoodReport report = await usdaAsync.FetchUsdaFoodReport(testNdbno);
            var returned = (from c in report.foods[0].food.nutrients
                            where c.nutrient_id == 306
                            select c.measures[0].value).FirstOrDefault();
            Assert.AreEqual(correct, returned);
        } 
    }
}

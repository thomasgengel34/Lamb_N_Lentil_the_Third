using System;
using Lamb_N_Lentil.Domain;
using Lamb_N_Lentil.Domain.UsdaInformation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.Models
{
    [TestClass]
    public class MapUsdaFoodReportToIngredientShould
    {
        private food food;
        private string correctName = "test name";
        private string correctNumber = "test number";
        private string correctDesc = "test desc";
        private string correctDate = "4/17/2017";
        private decimal correctCalories = 99M;
        private decimal correctTotalFat = 987654.2M;
        private decimal correctSaturatedFat = 12345.67M;
        private decimal correctTotalCarbohydrate = 99.012M;
        private decimal correctSodium = 98.6M;
        private decimal correctProtein = 7.15M;
        private decimal correctVitaminA = 3.11M;

        private IIngredient ingredient;


        public MapUsdaFoodReportToIngredientShould()
        {
            food = new food();
            food.desc = new desc();
            food.desc.name = correctName;
            food.desc.ndbno = correctNumber;
            food.ing = new ing();
            food.ing.desc = correctDesc;
            food.ing.upd = correctDate;
            int setHigherThanEverExpected = 40;
            food.nutrients = new nutrients[setHigherThanEverExpected];
            food.nutrients[0] = new nutrients();

            food.nutrients[0].measures = new measures[1];
            food.nutrients[0].name = "Energy";
            food.nutrients[0].nutrient_id = 208;
            food.nutrients[0].measures[0] = new measures();
            food.nutrients[0].measures[0].value = correctCalories;

            food.nutrients[2] = new nutrients();
            food.nutrients[2].name = "Total lipid(fat)";
            food.nutrients[2].nutrient_id = 204;
            food.nutrients[2].measures = new measures[1];
            food.nutrients[2].measures[0] = new measures();
            food.nutrients[2].measures[0].value = correctTotalFat;

            food.nutrients[3] = new nutrients();
            food.nutrients[3].name = "Fatty acids, total saturated";
            food.nutrients[3].nutrient_id = 606;
            food.nutrients[3].measures = new measures[1];
            food.nutrients[3].measures[0] = new measures();
            food.nutrients[3].measures[0].value = correctSaturatedFat;

            food.nutrients[4] = new nutrients();
            food.nutrients[4].name = "Fiber, total dietary";
            food.nutrients[4].nutrient_id =291;
            food.nutrients[4].measures = new measures[1];
            food.nutrients[4].measures[0] = new measures();
            food.nutrients[4].measures[0].value = correctSaturatedFat;
             
            food.nutrients[5] = new nutrients();
            food.nutrients[5].name = "Vitamin A, IU";
            food.nutrients[5].nutrient_id = 318;
            food.nutrients[5].measures = new measures[1];
            food.nutrients[5].measures[0] = new measures();
            food.nutrients[5].measures[0].value = correctVitaminA;

            food.nutrients[9] = new nutrients();
            food.nutrients[9].name = "Protein";
            food.nutrients[9].nutrient_id = 203;
            food.nutrients[9].measures = new measures[1];
            food.nutrients[9].measures[0] = new measures();
            food.nutrients[9].measures[0].value = 7.15M;

            food.nutrients[10] = new nutrients();
            food.nutrients[10].name = "Sodium, Na";
            food.nutrients[10].nutrient_id =307;
            food.nutrients[10].measures = new measures[1];
            food.nutrients[10].measures[0] = new measures();
            food.nutrients[10].measures[0].value = correctSodium;

            food.nutrients[11] = new nutrients();
           food.nutrients[11].name = "Carbohydrate, by difference";
            food.nutrients[11].nutrient_id = 205;
            food.nutrients[11].measures = new measures[1];
            food.nutrients[11].measures[0] = new measures();
            food.nutrients[11].measures[0].value = correctTotalCarbohydrate;

            ingredient = MapUsdaFoodReportToIIngredient.ConvertUsdaFoodReportToIIngredient(food);
        }

        [TestMethod]
        public void ConvertName()
        {
            Assert.AreEqual(correctName, ingredient.InstanceName);
        }

        [TestMethod]
        public void ConvertUpdateDate()
        {
            Assert.AreEqual(correctDate, ingredient.UpdateDate);
        }

        [TestMethod]
        public void ConvertCaloriesValue()
        {
            Assert.AreEqual(correctCalories, ingredient.Calories);
        }

        [TestMethod]
        public void ConvertTotalFat()
        {
            Assert.AreEqual(correctTotalFat, ingredient.TotalFat);
        }

        [TestMethod]
        public void ConvertSaturatedFat()
        {
            Assert.AreEqual(correctSaturatedFat, ingredient.SaturatedFat);
        }

        [TestMethod]
        public void ConvertTotalCarbohydrate()
        {
            Assert.AreEqual(correctTotalCarbohydrate, ingredient.TotalCarbohydrate);
        }

        [TestMethod]
        public void ConvertSodium()
        {
            Assert.AreEqual(correctSodium, ingredient.Sodium);
        }

        [TestMethod]
        public void ConvertProtein()
        {
            Assert.AreEqual(correctProtein, ingredient.Protein);
        }

        [TestMethod]
        public void ConvertVitaminA()
        {
            decimal correct = 3.11M;
            Assert.AreEqual(correct , ingredient.VitaminA);
        }
    }
}

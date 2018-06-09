using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Lamb_N_Lentil.Domain.UsdaInformation;
using Lamb_N_Lentil.Tests.MockUsdaAsyncSiteFoodList;
using Lamb_N_Lentil.Tests.MockUsdaSiteFoodReport;
using Lamb_N_Lentil.UI.Controllers;
using Lamb_N_Lentil.UI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.Controllers
{
    [TestClass]
    public class IngredientControllerDetailsActionMethodTotalPercentageShould 
    {
       private readonly IUsdaAsync asyncFoodList = new MockUsdaAsyncFoodList();
       private   readonly IUsdaAsyncFoodReport asyncFoodReport = new MockUsdaAsyncForFoodReport();
        private IngredientDetailViewModel model;
        private ViewResult vr;

        public IngredientsController Controller { get; set; }

        [TestInitialize]
        public new void GetViewResultAsync()
        {
            Controller = new IngredientsController(null, asyncFoodList, asyncFoodReport); 
        }


        [TestMethod]
        public async Task ReturnPercentDailyValueOfZeroForTotalFatOfZero()
        {
            vr = await Controller.Details("ShouldReturnIngredientsWithPercentageDailyValueTotalFat0");
            model = (IngredientDetailViewModel)vr.Model;
            int correct = 0;
            int returned = model.TotalFatPercentageDailyValue;
            Assert.AreEqual(correct,returned);
        }

        [TestMethod]
        public async Task ReturnPercentDailyValueOfZeroForTotalFatOf65()
        {
            vr = await Controller.Details("ShouldReturnIngredientsWithPercentageDailyValueTotalFat65");
            model = (IngredientDetailViewModel)vr.Model;
            int correct = 100;
            int returned = model.TotalFatPercentageDailyValue;
            Assert.AreEqual(correct, returned);
        }

        [TestMethod]
        public async Task ReturnPercentDailyValueOfZeroForSaturatedFatOfZero()
        {
            vr = await Controller.Details("ShouldReturnIngredientsWithPercentageDailyValueSaturatedFat0");
            model = (IngredientDetailViewModel)vr.Model;
            int correct = 0;
            int returned = model.SaturatedFatPercentageDailyValue;
            Assert.AreEqual(correct, returned);
        }

        [TestMethod]
        public async Task ReturnPercentDailyValueOfZeroForSaturatedFatOf20()
        {
            vr = await Controller.Details("ShouldReturnIngredientsWithPercentageDailyValueSaturatedFat20");
            model = (IngredientDetailViewModel)vr.Model;
            int correct = 100;
            int returned = model.SaturatedFatPercentageDailyValue;
            Assert.AreEqual(correct, returned);
        }

        [TestMethod]
        public async Task ReturnPercentDailyValueOfZeroForCholesterolOfZero()
        {
            vr = await Controller.Details("ShouldReturnIngredientsWithPercentageDailyValueCholesterol0");
            model = (IngredientDetailViewModel)vr.Model;
            int correct = 0;
            int returned = model.CholesterolPercentageDailyValue;
            Assert.AreEqual(correct, returned);
        }

        [TestMethod]
        public async Task ReturnPercentDailyValueOfZeroForCholesterolOf300()
        {
            vr = await Controller.Details("ShouldReturnIngredientsWithPercentageDailyValueCholesterol300");
            model = (IngredientDetailViewModel)vr.Model;
            int correct = 100;
            int returned = model.CholesterolPercentageDailyValue;
            Assert.AreEqual(correct, returned);
        }

        [TestMethod]
        public async Task ReturnPercentDailyValueOfZeroForSodiumOfZero()
        {
            vr = await Controller.Details("ShouldReturnIngredientsWithPercentageDailyValueSodium0");
            model = (IngredientDetailViewModel)vr.Model;
            int correct = 0;
            int returned = model.SodiumPercentageDailyValue;
            Assert.AreEqual(correct, returned);
        }

        [TestMethod]
        public async Task ReturnPercentDailyValueOfZeroForSodiumOf2400()
        {
            vr = await Controller.Details("ShouldReturnIngredientsWithPercentageDailyValueSodium2400");
            model = (IngredientDetailViewModel)vr.Model;
            int correct = 100;
            int returned = model.SodiumPercentageDailyValue;
            Assert.AreEqual(correct, returned);
        }

        [TestMethod]
        public async Task ReturnPercentDailyValueOfZeroForPotassiumOfZero()
        {
            vr = await Controller.Details("ShouldReturnIngredientsWithPercentageDailyValuePotassium0");
            model = (IngredientDetailViewModel)vr.Model;
            int correct = 0;
            int returned = model.PotassiumPercentageDailyValue;
            Assert.AreEqual(correct, returned);
        }

        [TestMethod]
        public async Task ReturnPercentDailyValueOfZeroForPotassiumOf3500()
        {
            vr = await Controller.Details("ShouldReturnIngredientsWithPercentageDailyValuePotassium3500");
            model = (IngredientDetailViewModel)vr.Model;
            int correct = 100;
            int returned = model.PotassiumPercentageDailyValue;
            Assert.AreEqual(correct, returned);
        }

        [TestMethod]
        public async Task ReturnPercentDailyValueOfZeroForTotalCarbohydrateOfZero()
        {
            vr = await Controller.Details("ShouldReturnIngredientsWithPercentageDailyValueTotalCarbohydrate0");
            model = (IngredientDetailViewModel)vr.Model;
            int correct = 0;
            int returned = model.TotalCarbohydratePercentageDailyValue;
            Assert.AreEqual(correct, returned);
        }

        [TestMethod]
        public async Task ReturnPercentDailyValueOfZeroForTotalCarbohydrateOf300()
        {
            vr = await Controller.Details("ShouldReturnIngredientsWithPercentageDailyValueTotalCarbohydrate300");
            model = (IngredientDetailViewModel)vr.Model;
            int correct = 100;
            int returned = model.TotalCarbohydratePercentageDailyValue;
            Assert.AreEqual(correct, returned);
        }

        [TestMethod]
        public async Task ReturnPercentDailyValueOfZeroForDietaryFiberOfZero()
        {
            vr = await Controller.Details("ShouldReturnIngredientsWithPercentageDailyValueDietaryFiber0");
            model = (IngredientDetailViewModel)vr.Model;
            int correct = 0;
            int returned = model.DietaryFiberPercentageDailyValue;
            Assert.AreEqual(correct, returned);
        }

        [TestMethod]
        public async Task ReturnPercentDailyValueOfZeroForDietaryFiberOf25()
        {
            vr = await Controller.Details("ShouldReturnIngredientsWithPercentageDailyValueDietaryFiber25");
            model = (IngredientDetailViewModel)vr.Model;
            int correct = 100;
            int returned = model.DietaryFiberPercentageDailyValue;
            Assert.AreEqual(correct, returned);
        }
        // under development
        //[TestMethod]
        //public async Task ReturnPercentDailyValueOfZeroForVitaminAOfZero()
        //{
        //    vr = await Controller.Details("ShouldReturnIngredientsWithPercentageDailyValueVitaminA0");
        //    model = (IngredientDetailViewModel)vr.Model;
        //    int correct = 0;
        //    int returned = model.VitaminAPercentageDailyValue;
        //    Assert.AreEqual(correct, returned);
        //}

        //[TestMethod]
        //public async Task ReturnPercentDailyValueOfZeroForVitaminAOf1000()
        //{
        //    vr = await Controller.Details("ShouldReturnIngredientsWithPercentageDailyValueVitaminA1000");
        //    model = (IngredientDetailViewModel)vr.Model;
        //    int correct = 100;
        //    int returned = model.VitaminAPercentageDailyValue;
        //    Assert.AreEqual(correct, returned);
        //}

    } 
}

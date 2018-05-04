using System.Threading.Tasks;
using System.Web.Mvc;
using Lamb_N_Lentil.Tests.MockUsdaSite;
using Lamb_N_Lentil.UI.Controllers;
using Lamb_N_Lentil.UI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Lamb_N_Lentil.Tests.Controllers
{
    [TestClass]
    public class IngredientControllerDetailsActionMethodShould
    {
        MockUsdaAsync async = new MockUsdaAsync();

        public IngredientsController Controller { get; set; }

        public IngredientControllerDetailsActionMethodShould()
        {
            Controller = new IngredientsController(null, async);
        }


        [TestMethod]
        public async Task ProduceAnIngredientDetailViewModelWithALabel()
        {
            ViewResult vr = await Controller.Details("ShouldReturnIngredients");
            var model = (IngredientDetailViewModel)vr.Model;
            string returnedLabel = model.Label;
            Assert.IsNotNull(returnedLabel);
            Assert.AreEqual("I am a label", returnedLabel);
        }

        [TestMethod]
        public async Task ProduceAnIngredientDetailViewModelWithAnEqv()
        {
            ViewResult vr = await Controller.Details("ShouldReturnIngredients");
            var model = (IngredientDetailViewModel)vr.Model;
            decimal returnedEqv = model.Eqv;
            Assert.IsNotNull(returnedEqv);
            Assert.AreEqual(3.1415926M, returnedEqv);
        }

        [TestMethod]
        public async Task ProduceAnIngredientDetailViewModelWithTotalFat()
        {
            ViewResult vr = await Controller.Details("ShouldReturnIngredients");
            var model = (IngredientDetailViewModel)vr.Model;
            decimal correctTotalFat = 987654.2M;
            decimal returnedTotalFat = model.TotalFat;
            Assert.IsNotNull(returnedTotalFat);
            Assert.AreEqual(correctTotalFat, returnedTotalFat);
        }

        [TestMethod]
        public async Task ProduceAnIngredientDetailViewModelWithSodium()
        {
            ViewResult vr = await Controller.Details("ShouldReturnIngredients");
            decimal correctSodium = 143.0M;
            var model = (IngredientDetailViewModel)vr.Model;
            decimal returnedSodium = model.Sodium;
            Assert.IsNotNull(returnedSodium);
            Assert.AreEqual(correctSodium, returnedSodium);
        }

        [TestMethod]
        public async Task ProduceAnIngredientDetailViewModelWithTotalCarbohydrate()
        {
            ViewResult vr = await Controller.Details("ShouldReturnIngredients");
            decimal correctTotalCarbohydrate = 77.04M; 
            var model = (IngredientDetailViewModel)vr.Model;
            decimal returnedTotalCarbohydrate = model.TotalCarbohydrate;
            Assert.IsNotNull(returnedTotalCarbohydrate);
            Assert.AreEqual(correctTotalCarbohydrate, returnedTotalCarbohydrate); 
        }

        [TestMethod]
        public async Task ProduceAnIngredientDetailViewModelWithPolyunsaturatedFat()
        {
            ViewResult vr = await Controller.Details("ShouldReturnIngredients");
            decimal correctFat = 736.08M;
            var model = (IngredientDetailViewModel)vr.Model;
            decimal returnedFat = model.PolyunsaturatedFat; 
            Assert.AreEqual(correctFat, returnedFat);
        }

        [TestMethod]
        public async Task ProduceAnIngredientDetailViewModelWithMonounsaturatedFat()
        {
            ViewResult vr = await Controller.Details("ShouldReturnIngredients");
            decimal correctFat = 81.92M;
            var model = (IngredientDetailViewModel)vr.Model;
            decimal returnedFat = model.MonounsaturatedFat;
            Assert.AreEqual(correctFat, returnedFat);
        }

        [TestMethod]
        public async Task ProduceAnIngredientDetailViewModelWithCholesterol()
        {
            ViewResult vr = await Controller.Details("ShouldReturnIngredients");
            decimal correct  = 82.93M;
            var model = (IngredientDetailViewModel)vr.Model;
            decimal returned  = model.Cholesterol;
            Assert.AreEqual(correct , returned );
        }

        [TestMethod]
        public async Task ProduceAnIngredientDetailViewModelWithTransFat()
        {
            ViewResult vr = await Controller.Details("ShouldReturnIngredients");
            decimal correct = 101.01M;
            var model = (IngredientDetailViewModel)vr.Model;
            decimal returned = model.TransFat;
            Assert.AreEqual(correct, returned);
        }

        [TestMethod]
        public async Task ProduceAnIngredientDetailViewModelWithSugars()
        {
            ViewResult vr = await Controller.Details("ShouldReturnIngredients");
            decimal correct = 14.30M;
            var model = (IngredientDetailViewModel)vr.Model;
            decimal returned = model.Sugars;
            Assert.AreEqual(correct, returned);
        }

        [TestMethod]
        public async Task ProduceAnIngredientDetailViewModelWithProtein()
        {
            ViewResult vr = await Controller.Details("ShouldReturnIngredients");
            decimal correct = 7.15M;
            var model = (IngredientDetailViewModel)vr.Model;
            decimal returned = model.Protein;
            Assert.AreEqual(correct, returned);
        }
    }
}

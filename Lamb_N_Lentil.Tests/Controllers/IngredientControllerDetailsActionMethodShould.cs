using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Lamb_N_Lentil.Tests.MockUsdaSite;
using Lamb_N_Lentil.UI.Controllers;
using Lamb_N_Lentil.UI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Lamb_N_Lentil.Domain.UsdaInformation;
using Lamb_N_Lentil.Domain ;


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
        public void MyTestMethod()
        {
            
            foods[] foods = new foods[1];
            food food = new food() { ing = new ing() { desc = "peas, porridge, hot" } };
            foods testfoods = new foods { food = food };

             foods[0] = testfoods;
            food.nutrients = new nutrients[1];
            food.nutrients[0] = new nutrients(); 
              food.nutrients[0].measures  = new measures[1];
              food.nutrients[0].measures[0]  = new measures() ;  
              food.nutrients[0].measures[0].label = "I am a label";

            //food.nutrients.First().measures.First().eqv = 3.1415926M; 
        }
    }
}

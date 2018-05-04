using System.Threading.Tasks;
using Lamb_N_Lentil.Domain.UsdaInformation;
using Lamb_N_Lentil.UI.Controllers;
using Lamb_N_Lentil.UI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.LiveUsdaSite
{
    [TestClass]
    public class IngredientControllerDetailMethodShould
    {
        private IUsdaAsync usdaAsync { get; set; }
        private IngredientsController Controller { get; set; }
        private int standardTotal { get; set; } = 2699;
        private int brandedTotal { get; set; } = 14;
        private int Total { get; set; } = 4411; 
        private int correctEqv=113;
        private decimal correctCholesterol = 25;
        

        public IngredientControllerDetailMethodShould()
        {
            usdaAsync = new UsdaAsync();
            Controller = new IngredientsController(null, usdaAsync);
        }



        [TestMethod]
        public async Task HaveUpdateDateInTheViewModelForGreatValueDicedPeaches45032698()
        {
            var viewResult = await Controller.Details("45032698");
            var model = (IngredientDetailViewModel)viewResult.Model; 
            string correctUpDateDate = "07/14/2017";
            string returnedUpdateDate = model.UpdateDate;
            Assert.AreEqual(correctUpDateDate, returnedUpdateDate);
        }

        [TestMethod]
        public async Task HaveLabelInTheViewModelForGreatValueDicedPeaches45032698()
        {
            var viewResult = await Controller.Details("45032698");
            var model = (IngredientDetailViewModel)viewResult.Model;
         
            string correctLabel = "BOWL";
            string returnedLabel = model.Label;
            Assert.AreEqual(correctLabel, returnedLabel);
        }

        [TestMethod]
        public async Task HaveBowlEqvInTheViewModelForGreatValueDicedPeaches45032698()
        {
            var viewResult = await Controller.Details("45032698");
            var model = (IngredientDetailViewModel)viewResult.Model; 
            decimal returnedEqv = model.Eqv;
            Assert.AreEqual(correctEqv, returnedEqv);
        }

        [TestMethod]
        public async Task HaveCholesterolInTheViewModelForLightChurnedStyleIcecream45039512()
        {
            var viewResult = await Controller.Details("45039512");
            var model = (IngredientDetailViewModel)viewResult.Model;
            decimal returned  = model.Cholesterol;
            Assert.AreEqual(correctCholesterol, returned );
        }

        [TestMethod]
        public async Task HavePotassiumInTheViewModelForDannonLightStrawberryBananaYogurt45035088()
        {
            var viewResult = await Controller.Details("45035088");
            var model = (IngredientDetailViewModel)viewResult.Model;
            var correct = 250.00M;
            decimal returned = model.Potassium;
            Assert.AreEqual(correct, returned);
        }

        [TestMethod]
        public async Task HaveDietaryFiberInTheViewModelForWheaties45310806()
        {
            var viewResult = await Controller.Details("45310806");
            var model = (IngredientDetailViewModel)viewResult.Model;
            var correct = 3.00M;
            decimal returned = model.DietaryFiber;
            Assert.AreEqual(correct, returned);
        }
    }
}

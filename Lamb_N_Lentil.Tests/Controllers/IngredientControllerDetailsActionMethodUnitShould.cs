using Lamb_N_Lentil.Domain.UsdaInformation;
using Lamb_N_Lentil.Tests.MockUsdaAsyncSiteFoodList;
using Lamb_N_Lentil.Tests.MockUsdaSiteFoodReport;
using Lamb_N_Lentil.UI.Controllers;
using Lamb_N_Lentil.UI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Lamb_N_Lentil.Tests.Controllers
{
    [TestClass]
    public class IngredientControllerDetailsActionMethodUnitShould
    {
        private readonly IUsdaAsync asyncFoodList = new MockUsdaAsyncFoodList();
        private readonly IUsdaAsyncFoodReport asyncFoodReport = new MockUsdaAsyncForFoodReport();
        private IngredientDetailViewModel model;
        private ViewResult vr;

        public IngredientsController Controller { get; set; }

        [TestInitialize]
        public async Task GetViewResultAsync()
        {
            Controller = new IngredientsController(null, asyncFoodList, asyncFoodReport);
            vr = await Controller.Details("ShouldReturnIngredients");
            model = (IngredientDetailViewModel)vr.Model;
        }


        [TestMethod]
        public void ReturnCorrectUnitForTotalFat()
        { 
            string correct = "unit for total fat";
            string returned = model.TotalFatUnit;
            Assert.AreEqual(correct, returned);
        }

        [TestMethod]
        public void ReturnCorrectUnitForSaturatedFat()
        {
            string correct = "unit for saturated fat";
            string returned = model.SaturatedFatUnit;
            Assert.AreEqual(correct, returned);
        }

        [TestMethod]
        public void ReturnCorrectUnitForTransFat()
        {
            string correct = "unit for trans fat";
            string returned = model.TransFatUnit;
            Assert.AreEqual(correct, returned);
        }

        [TestMethod]
        public void ReturnCorrectUnitForPolyunsaturatedFat()
        {
            string correct = "unit for polyunsaturated fat";
            string returned = model.PolyunsaturatedFatUnit;
            Assert.AreEqual(correct, returned);
        } 

        [TestMethod]
        public void ReturnCorrectUnitForMonounsaturatedFat()
        {
            string correct = "unit for monounsaturated fat";
            string returned = model.MonounsaturatedFatUnit;
            Assert.AreEqual(correct, returned);
        }

        [TestMethod]
        public void ReturnCorrectUnitForCholesterol()
        {
            string correct = "unit for cholesterol";
            string returned = model.CholesterolUnit;
            Assert.AreEqual(correct, returned);
        }

        [TestMethod]
        public void ReturnCorrectUnitForSodium()
        {
            string correct = "unit for sodium";
            string returned = model.SodiumUnit;
            Assert.AreEqual(correct, returned);
        }
    }
}

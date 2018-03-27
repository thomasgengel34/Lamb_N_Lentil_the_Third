using System.Threading.Tasks;
using System.Web.Mvc;
using Lamb_N_Lentil.Domain;
using Lamb_N_Lentil.UI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.Controllers
{
    [TestClass]
    public class EnteringTextInTheSearchBoxOnTheIngredientsIndexViewShouldReturn
    {
        private IngredientsController controller;

        [TestInitialize]
        public void Setup()
        {
          controller = new IngredientsController(new TestUsdaAsyncController()); 
        }

        [TestMethod]
        public async Task  AnIngredientViewModelContainingAListOfFoodsWithDataSource()
        {
            ActionResult ar = await controller.ShowResults(" 076606619663");
            ViewResult vr = (ViewResult)ar;
            IIngredient ingredient = (IIngredient)vr.Model;
            string dataSource = ingredient.UsdaDataSource.ToString();
            Assert.AreEqual("salt, pepper, butter, garlic, turmeric, egg", dataSource);

        }

        [TestMethod]
        public void  AnIngredientViewModelContainingAListOfFoodsWithNdbno()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void  IngredientViewModelContainingAListOfFoodsWithDescriptionAndManufacturereOrFoodGroup()
        {
            Assert.Fail();
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Lamb_N_Lentil.Domain;
using Lamb_N_Lentil.UI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Lamb_N_Lentil.UI.Models;
using Lamb_N_Lentil.Tests.MockUsdaSite;

namespace Lamb_N_Lentil.Tests.Controllers
{
    [TestClass]
    public class EnteringTextInTheSearchBoxOnTheIngredientsIndexViewShouldReturn
    {
        private IngredientsController controller;

        [TestInitialize]
        public void Setup()
        {
          controller = new IngredientsController(null,new  MockUsdaAsync()); 
        }

        [TestMethod]
        public async Task  AnIngredientViewModelContainingAListOfFoodsWithDataSource()
        {
            IIngredient ingredient = await GetTheIngredient();
            string dataSource = ingredient.UsdaDataSource.ToString();
            Assert.AreEqual("BrandedFoodProducts", dataSource);

        }

        private async Task<IIngredient> GetTheIngredient()
        {
            ActionResult ar = await controller.ShowResults(" 076606619663");
            ViewResult vr = (ViewResult)ar;
            List<IngredientListViewModel> ingredients = (List<IngredientListViewModel>)(vr.Model);
            IIngredient ingredient = IngredientListViewModel.MapIIngredientListViewModelToIngredient(ingredients.First());
            return ingredient;
        }

        [TestMethod]
        public async Task AnIngredientViewModelContainingAListOfFoodsWithNdbno()
        {
            IIngredient ingredient = await GetTheIngredient();
            string ndbno = ingredient.Ndbno;
            Assert.AreEqual("45237067", ndbno);
        }

        [TestMethod]
        public async Task  IngredientViewModelContainingAListOfFoodsWithDescriptionAndManufacturereOrFoodGroup()
        {
            IIngredient ingredient = await GetTheIngredient();
            string descriptionAndManufacturereOrFoodGroup = "Sample Manufacturer Or Food Group For Empty String";
            Assert.AreEqual(descriptionAndManufacturereOrFoodGroup, ingredient.ManufacturerOrFoodGroup);
        }
    }
}

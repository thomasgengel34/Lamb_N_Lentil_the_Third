using System.Threading.Tasks;
using System.Web.Mvc;
using Lamb_N_Lentil.Domain.UsdaInformation;
using Lamb_N_Lentil.Tests.MockUsdaSite;
using Lamb_N_Lentil.UI.Controllers;
using Lamb_N_Lentil.UI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Lamb_N_Lentil.Tests.Controllers
{
    [TestClass]
    public class IngredientControllerActionMethodsShould
    {
        MockUsdaAsync  async = new MockUsdaAsync();

        public IngredientsController Controller { get; set; }

        public IngredientControllerActionMethodsShould()
        {
            Controller = new IngredientsController(null, async);
        }
         

        [TestMethod]
        public async Task HaveShowResultsReturnNullMessageinViewBagResultsIfIngredientsCountIsOverZero()
        { 
            string expectedResult = "";
            ActionResult actionResult = await Controller.ShowResults("cream");
            ViewResult viewResult = (ViewResult)actionResult;
            string noResults = viewResult.ViewBag.NoResults;
            Assert.AreEqual(expectedResult, noResults);
        }

        [TestMethod]
        public async Task HaveShowResultsReturnNullMessageinViewBagResultsIfIngredientsCountIsZero()
        { 
            string expectedResult = "Nothing was found.  Please try a different search.";
            ActionResult actionResult = await Controller.ShowResults("This Should Return No Ingredients");
            ViewResult viewResult = (ViewResult)actionResult;
            string noResults = viewResult.ViewBag.NoResults;
            Assert.AreEqual(expectedResult, noResults);
        }

        [TestMethod]
        public async Task HaveShowResultsReturnDefaultDatabaseAsAllWhenNoValueIsProvided()
        {
            ActionResult actionResult = await Controller.ShowResults("0000");
            ViewResult viewResult = (ViewResult)actionResult;
            UsdaDataSource  databaseSelection = Controller.ViewBag.DatabaseSelection;

            Assert.AreEqual(UsdaDataSource.Both, databaseSelection);
        }

        [TestMethod]
        public async Task HaveShowResultsReturnStandardDatabaseInViewBagAsStandardWhenStandardDatabaseValueIsProvided()
        {
            ActionResult actionResult = await Controller.ShowResults("0000", UsdaDataSource.StandardReference);
            ViewResult viewResult = (ViewResult)actionResult;
            UsdaDataSource  databaseSelection = Controller.ViewBag.DatabaseSelection;

            Assert.AreEqual(UsdaDataSource.StandardReference, databaseSelection);
        }

        [TestMethod]
        public async Task HaveShowResultsReturnStandardDatabaseAsBrandedWhenBrandedFoodProductsValueIsProvided()
        {
            ActionResult actionResult = await Controller.ShowResults("0000", UsdaDataSource.BrandedFoodProducts);
            ViewResult viewResult = (ViewResult)actionResult; 
            var model = (System.Collections.Generic.List<IngredientListViewModel>)viewResult.Model; 
            string returnedManuOrFoodGroup   = model.First().ManufacturerOrFoodGroup; 
             string correctDatabase = "Sample Manufacturer Or Food Group For Branded Products String";
             Assert.AreEqual(correctDatabase, returnedManuOrFoodGroup);
        }

        [TestMethod]
        public async Task HaveShowResultsReturnStandardDatabaseAsStandardWhenStandardDatabaseValueIsProvided()
        {
            ActionResult actionResult = await Controller.ShowResults("0000", UsdaDataSource.StandardReference);
            ViewResult viewResult = (ViewResult)actionResult;
            var model = (System.Collections.Generic.List<IngredientListViewModel>)viewResult.Model;
            string returnedManuOrFoodGroup = model.First().ManufacturerOrFoodGroup;
            string correctDatabase = "Sample Manufacturer Or Food Group For Standard String";
            Assert.AreEqual(correctDatabase, returnedManuOrFoodGroup);
        }

        [TestMethod]
        public async Task HaveShowResultsReturnAllDatabaseAsStandardWhenBothDatabaseValueIsProvided()
        {
            ActionResult actionResult = await Controller.ShowResults("0000", UsdaDataSource.Both);
            ViewResult viewResult = (ViewResult)actionResult;
            var model = (System.Collections.Generic.List<IngredientListViewModel>)viewResult.Model;
            string returnedManuOrFoodGroup = model.First().ManufacturerOrFoodGroup;
            string correctDatabase = "Sample Manufacturer Or Food Group For Empty String";
            Assert.AreEqual(correctDatabase, returnedManuOrFoodGroup);
        }
    }
}

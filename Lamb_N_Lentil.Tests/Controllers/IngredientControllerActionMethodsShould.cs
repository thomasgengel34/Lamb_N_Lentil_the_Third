using System.Threading.Tasks;
using System.Web.Mvc;
using Lamb_N_Lentil.Domain.UsdaInformation;
using Lamb_N_Lentil.Tests.MockUsdaSite;
using Lamb_N_Lentil.UI.Controllers;
using Lamb_N_Lentil.UI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

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
            var model = ( List<IngredientListViewModel>)viewResult.Model;
            string returnedManuOrFoodGroup = model.First().ManufacturerOrFoodGroup;
            string correctDatabase = "Sample Manufacturer Or Food Group For Empty String";
            Assert.AreEqual(correctDatabase, returnedManuOrFoodGroup);
        }

        [TestMethod]
        public async Task HaveShowResultsReturnTheCorrectTotalOfItemsShownInTheView()
        {
            int correctCount = 3;
            ActionResult actionResult = await Controller.ShowResults("1003", UsdaDataSource.Both);
            ViewResult viewResult = (ViewResult)actionResult;
            var model = (List<IngredientListViewModel>)viewResult.Model;
            int total = model.Count();
            Assert.AreEqual(correctCount, total);
        }

        [TestMethod]
        public async Task HaveShowResultsReturnTheCorrectTotalOfItemsShownInTheViewWhenTotalIsZero()
        {
            int correctCount = 0;
            ActionResult actionResult = await Controller.ShowResults("1000", UsdaDataSource.Both);
            ViewResult viewResult = (ViewResult)actionResult;
            var model = (List<IngredientListViewModel>)viewResult.Model;
            int total = model.Count();
            Assert.AreEqual(correctCount, total);
        }

        [TestMethod]
        public async Task HaveShowResultsReturnTheCorrectTotalOfItemsShownInTheViewAsFiftyWhenTotalIsFortyNine()
        {
            int correctCount = 49;
            ActionResult actionResult = await Controller.ShowResults("1049", UsdaDataSource.Both);
            ViewResult viewResult = (ViewResult)actionResult;
            var model = (List<IngredientListViewModel>)viewResult.Model;
            int total = model.Count();
            Assert.AreEqual(correctCount, total);
        }

        [TestMethod]
        public async Task HaveShowResultsReturnTheCorrectTotalOfItemsShownInTheViewAsFiftyWhenTotalIsFifty()
        {
            int correctCount = 50;
            ActionResult actionResult = await Controller.ShowResults("1050", UsdaDataSource.Both);
            ViewResult viewResult = (ViewResult)actionResult;
            var model = (List<IngredientListViewModel>)viewResult.Model;
            int total = model.Count();
            Assert.AreEqual(correctCount, total);
        }

        [TestMethod]
        public async Task HaveShowResultsReturnTheCorrectTotalOfItemsShownInTheViewAsFiftyWhenTotalIsOverFifty()
        {
            int correctCount = 51;
            ActionResult actionResult = await Controller.ShowResults("1051", UsdaDataSource.Both);
            ViewResult viewResult = (ViewResult)actionResult;
            var model = (List<IngredientListViewModel>)viewResult.Model;
            int total = model.Count();
            Assert.AreEqual(correctCount, total);
        }

        [TestMethod]
        public async Task HaveShowResultsReturnTheCorrectTotalOfItemsFoundInTheSearch()
        {
            int correctTotal = 445321;
            ActionResult actionResult = await Controller.ShowResults("total", UsdaDataSource.Both);
            ViewResult viewResult = (ViewResult)actionResult;
            var model = (List<IngredientListViewModel>)viewResult.Model;
            int total = viewResult.ViewBag.SearchTotal;
            Assert.AreEqual(correctTotal, total);
        }

    }
}

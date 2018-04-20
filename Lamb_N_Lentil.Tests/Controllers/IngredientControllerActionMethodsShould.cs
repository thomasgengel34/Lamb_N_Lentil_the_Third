using System.Threading.Tasks;
using System.Web.Mvc;
using Lamb_N_Lentil.Domain.UsdaInformation;
using Lamb_N_Lentil.Tests.MockUsdaSite;
using Lamb_N_Lentil.UI.Controllers;
using Lamb_N_Lentil.UI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using Lamb_N_Lentil.Domain;

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
        public async Task HaveShowResultsReturnTheCorrectTotalOfItemsShownInTheView()
        {
            int correctCount = 3;
            ActionResult actionResult = await Controller.ShowResults("1003" );
            ViewResult viewResult = (ViewResult)actionResult;
            var model = (List<IngredientListViewModel>)viewResult.Model;
            int total = model.Count();
            Assert.AreEqual(correctCount, total);
        }

        [TestMethod]
        public async Task HaveShowResultsReturnTheCorrectTotalOfItemsShownInTheViewWhenTotalIsZero()
        {
            int correctCount = 0;
            ActionResult actionResult = await Controller.ShowResults("1000");
            ViewResult viewResult = (ViewResult)actionResult;
            var model = (List<IngredientListViewModel>)viewResult.Model;
            int total = model.Count();
            Assert.AreEqual(correctCount, total);
        }

        [TestMethod]
        public async Task HaveShowResultsReturnTheCorrectTotalOfItemsShownInTheViewAsFiftyWhenTotalIsFortyNine()
        {
            int correctCount = 49;
            ActionResult actionResult = await Controller.ShowResults("1049" );
            ViewResult viewResult = (ViewResult)actionResult;
            var model = (List<IngredientListViewModel>)viewResult.Model;
            int total = model.Count();
            Assert.AreEqual(correctCount, total);
        }

        [TestMethod]
        public async Task HaveShowResultsReturnTheCorrectTotalOfItemsShownInTheViewAsFiftyWhenTotalIsFifty()
        {
            int correctCount = 50;
            ActionResult actionResult = await Controller.ShowResults("1050" );
            ViewResult viewResult = (ViewResult)actionResult;
            var model = (List<IngredientListViewModel>)viewResult.Model;
            int total = model.Count();
            Assert.AreEqual(correctCount, total);
        }

        [TestMethod]
        public async Task HaveShowResultsReturnTheCorrectTotalOfItemsShownInTheViewAsFiftyWhenTotalIsOverFifty()
        {
            int correctCount = 51;
            ActionResult actionResult = await Controller.ShowResults("1051" );
            ViewResult viewResult = (ViewResult)actionResult;
            var model = (List<IngredientListViewModel>)viewResult.Model;
            int total = model.Count();
            Assert.AreEqual(correctCount, total);
        }

        [TestMethod]
        public async Task HaveShowResultsReturnTheCorrectTotalOfItemsFoundInTheSearch()
        {
            int correctTotal = 445321;
            ActionResult actionResult = await Controller.ShowResults("total" );
            ViewResult viewResult = (ViewResult)actionResult;
            var model = (List<IngredientListViewModel>)viewResult.Model;
            int total = viewResult.ViewBag.SearchTotal;
            Assert.AreEqual(correctTotal, total);
        }
        
    }
}

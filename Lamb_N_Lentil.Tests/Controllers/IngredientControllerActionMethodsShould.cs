using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Lamb_N_Lentil.UI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.Controllers
{
    [TestClass]
    public class IngredientControllerActionMethodsShould
    {
        Type type { get; set; }
        public IngredientsController Controller { get; set; }

        public IngredientControllerActionMethodsShould()
        { 
            Controller = new IngredientsController();
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
            ActionResult actionResult = await Controller.ShowResults("qqqq");
            ViewResult viewResult = (ViewResult)actionResult;
            string noResults = viewResult.ViewBag.NoResults;
            Assert.AreEqual(expectedResult, noResults);
        }

        [TestMethod]
        public async Task HaveShowResultsReturnDefaultDatabaseAsAllWhenNoValueIsProvided()
        {
            ActionResult actionResult = await Controller.ShowResults("0000");
            ViewResult viewResult = (ViewResult)actionResult;

        }
    }
}

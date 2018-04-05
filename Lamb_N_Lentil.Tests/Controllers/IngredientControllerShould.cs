using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Lamb_N_Lentil.UI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.Controllers
{
    [TestClass]
    public class IngredientControllerShould
    {
        Type type { get; set; }

        public IngredientControllerShould()
        {
            type = Type.GetType("Lamb_N_Lentil.UI.Controllers.IngredientsController, Lamb_N_Lentil.UI", true);
        }


        [TestMethod]
       public void InheritEntityController()
        {
            bool IsEntityController = type.IsSubclassOf(typeof(EntityController));

            Assert.IsTrue(IsEntityController);
        }

        [TestMethod]
        public void HaveDefaultConstructor()
        {
            var constructor = type.GetConstructor(Type.EmptyTypes);
            Assert.IsNotNull(constructor);
        }

        [TestMethod]
        public void HasTwoConstructors()
        {
            var ctors = type.GetConstructors();
            int count = ctors.Length;
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void HaveIndexMethod()
        {
            var methodSought = type.GetMethod("Index");
            Assert.IsNotNull(methodSought);
        }

        [TestMethod]
        public void HaveShowResultsMethod()
        {
            var methodSought = type.GetMethod("ShowResults");
            Assert.IsNotNull(methodSought);
        }

        [TestMethod]
        public async Task HaveShowResultsReturnNullMessageinViewBagResultsIfIngredientsCountIsOverZero()
        {
            IngredientsController controller = new IngredientsController();
            string expectedResult = "";
           ActionResult actionResult =  await controller.ShowResults("cream");
            ViewResult viewResult = (ViewResult)actionResult;
            string noResults = viewResult.ViewBag.NoResults;
            Assert.AreEqual(expectedResult, noResults);
        }

        [TestMethod]
        public async Task HaveShowResultsReturnNullMessageinViewBagResultsIfIngredientsCountIsZero()
        {
            IngredientsController controller = new IngredientsController();
            string expectedResult = "Nothing was found.  Please try a different search.";
            ActionResult actionResult = await controller.ShowResults("qqqq");
            ViewResult viewResult = (ViewResult)actionResult;
            string noResults = viewResult.ViewBag.NoResults;
            Assert.AreEqual(expectedResult, noResults);
        }
    }
}

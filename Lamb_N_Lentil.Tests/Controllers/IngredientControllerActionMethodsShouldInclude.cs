using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Lamb_N_Lentil.Tests.MockUsdaSite;
using Lamb_N_Lentil.UI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.Controllers
{
    [TestClass]
    public class IngredientControllerActionMethodsShouldInclude
    {
        Type type { get; set; }
        public IngredientsController Controller { get; set; }

        public IngredientControllerActionMethodsShouldInclude()
        {
            type = Type.GetType("Lamb_N_Lentil.UI.Controllers.IngredientsController, Lamb_N_Lentil.UI", true);
            Controller = new IngredientsController(null,new MockUsdaAsync());
        }
        [TestMethod]
        public void CorrectNumberOfMethods()
        {
            int correctCount = 2;
            IController baseController = new EntityController();

            var baseMethods = Type.GetType("Lamb_N_Lentil.UI.Controllers.EntityController, Lamb_N_Lentil.UI", true).GetMethods().ToList();
            var baseCount = baseMethods.Count();
            var methods = type.GetMethods().ToList();
            var methodCount = methods.Count(); 
            Assert.AreEqual(correctCount, methodCount-baseCount);
        }

        [TestMethod]
        public void Index()
        {
            var methodSought = type.GetMethod("Index");
            Assert.IsNotNull(methodSought);
        }

        [TestMethod]
        public void ShowResults()
        {
            var methodSought = type.GetMethod("ShowResults");
            Assert.IsNotNull(methodSought);
        }


    }
}

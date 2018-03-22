using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Lamb_N_Lentil.Domain;
using Lamb_N_Lentil.UI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.Controllers
{
    [TestClass]
    public class EntityControllerShould
    {
        private EntityController controller;

        [TestInitialize]
        public void Setup()
        {
            controller = new EntityController(new TestEntityAsyncController());
        }



        [TestMethod]
        public void Index()
        {
            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task ShowResults()
        {
              ActionResult  ar = await controller.ShowResults(" 076606619663");
            ViewResult vr = (ViewResult)ar;
            Entity entity = (Entity)vr.Model;
            string ingredientsList=  entity.IngredientsList;
            Assert.AreEqual("salt, pepper, butter, garlic, turmeric, egg", ingredientsList);
              
        }

        [TestMethod]
        public async Task DetailsActionMethodNotProduceNullResult()
        {
            ViewResult result = await controller.Details("test") as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}

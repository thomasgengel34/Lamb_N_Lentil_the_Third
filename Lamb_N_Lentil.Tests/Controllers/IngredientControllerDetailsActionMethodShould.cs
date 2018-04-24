using System;
using Lamb_N_Lentil.Tests.MockUsdaSite;
using Lamb_N_Lentil.UI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.Controllers
{
    [TestClass]
    public class IngredientControllerDetailsActionMethodShould
    {
        MockUsdaAsync async = new MockUsdaAsync();

        public IngredientsController Controller { get; set; }

        public IngredientControllerDetailsActionMethodShould()
        {
            Controller = new IngredientsController(null, async);
        }


        [TestMethod]
        public void MyTestMethod()
        {

        }
    }
}

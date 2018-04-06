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
    }
}

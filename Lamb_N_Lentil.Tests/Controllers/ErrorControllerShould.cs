using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Lamb_N_Lentil.UI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.Controllers
{
    [TestClass]
    public class ErrorControllerShould
    {
        Type type { get; set; }

        public ErrorControllerShould()
        {
            type = Type.GetType("Lamb_N_Lentil.UI.Controllers.ErrorController, Lamb_N_Lentil.UI", true);
        }


        [TestMethod]
       public void InheritController()
        {
            bool IsController = type.IsSubclassOf(typeof(Controller));

            Assert.IsTrue(IsController);
        }

        [TestMethod]
        public void HaveDefaultConstructor()
        {
            var constructor = type.GetConstructor(Type.EmptyTypes);
            Assert.IsNotNull(constructor);
        }

        [TestMethod]
        public void HasOneConstructor()
        {
            var ctors = type.GetConstructors();
            int count = ctors.Length;
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void HaveIndexMethod()
        {
            var methodSought = type.GetMethod("Index");
            Assert.IsNotNull(methodSought);
        } 
    }
}

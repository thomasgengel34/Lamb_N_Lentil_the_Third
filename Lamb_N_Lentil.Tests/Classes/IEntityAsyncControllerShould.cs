using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Lamb_N_Lentil.UI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.Classes
{
    [TestClass]
    public class IEntityAsyncControllerShould
    {
        List<MethodInfo> listOfMethodInfos;

        public IEntityAsyncControllerShould()
        {
            MethodInfo[] methodInfos = typeof(IEntityAsyncController).GetMethods();
            listOfMethodInfos = methodInfos.Select(i => i).ToList();
        }

        [TestMethod]
        public void HaveGetIngredientsFromDescriptionMethod() => VerifyMethodIsValid("GetIngredientsFromDescription");

        [TestMethod]
        public void HaveGetNdbnoFromSearchStringAsyncMethod() => VerifyMethodIsValid("GetNdbnoFromSearchStringAsync");

       

        private void VerifyMethodIsValid(string value)
        {
            var methodName = from c in listOfMethodInfos
                             where c.Name == value
                             select c.Name;

            Assert.AreEqual(methodName.First(), value);
            Assert.IsNotNull(methodName.Count());
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Lamb_N_Lentil.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.Classes
{ 
    [TestClass]
    public class IIngredientShouldContain:Common
    { 

        public IIngredientShouldContain()
        {
            PropertyInfo[] propertyInfos = typeof(IIngredient).GetProperties();
            listOfPropertyInfos = propertyInfos.Select(i => i).ToList();
        }

        [TestMethod]
        public void NdbnoProperty() => VerifyPropertyIsValid("Ndbno");

        [TestMethod]
        public void LabelProperty() => VerifyPropertyIsValid("Label");

        [TestMethod]
        public void EqvProperty() => VerifyPropertyIsValid("Eqv");
    }
}

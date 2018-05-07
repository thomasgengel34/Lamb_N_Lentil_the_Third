using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Lamb_N_Lentil.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.Classes
{
    [TestClass]
    public class IEntityShouldContain:Common
    { 
        public IEntityShouldContain()
        {
            PropertyInfo[] propertyInfos = typeof(IEntity).GetProperties();
            listOfPropertyInfos = propertyInfos.Select(i => i).ToList();
        }
        
        [TestMethod]
        public void IDProperty() => VerifyPropertyIsValid("ID");

        [TestMethod]
        public void InstanceNameProperty() => VerifyPropertyIsValid("InstanceName"); 

        [TestMethod]
        public void IngredientsListProperty() => VerifyPropertyIsValid("IngredientsInIngredient");

        [TestMethod]
        public void Sodium() => VerifyPropertyIsValid("Sodium");

        [TestMethod]
        public void DietaryFiber() => VerifyPropertyIsValid("DietaryFiber");

        [TestMethod]
        public void VitaminA() => VerifyPropertyIsValid("VitaminA");

    } 
}

using System;
using Lamb_N_Lentil.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.Classes
{
    [TestClass]
    public class EntityClassShould
    {
        [TestMethod]
        public void ImplementIEntity()
        {
            Type type = typeof(Entity);
            Type implementedInterface=type.GetInterface("IEntity");
            Assert.AreEqual(typeof(IEntity), implementedInterface);
        }

        [TestMethod]
        public void ShouldHaveIDProperty()
        {
            var pInfo = typeof(Entity).GetProperty("ID");
            Assert.AreEqual("ID", pInfo.Name);
        }

        [TestMethod]
        public void ShouldHaveInstanceNameProperty()
        {
            var pInfo = typeof(Entity).GetProperty("InstanceName");
            Assert.AreEqual("InstanceName", pInfo.Name);
        }

        [TestMethod]
        public void ShouldHaveIngredientsInIngredientProperty()
        {
            var pInfo = typeof(Entity).GetProperty("IngredientsInIngredient");
            Assert.AreEqual("IngredientsInIngredient", pInfo.Name);
        }

        [TestMethod]
        public void ShouldHaveSaturatedFatProperty()
        {
            var pInfo = typeof(Entity).GetProperty("SaturatedFat");
            Assert.AreEqual("SaturatedFat", pInfo.Name);
        }

        [TestMethod]
        public void ShouldHavePolyunsaturatedFatProperty()
        {
            var pInfo = typeof(Entity).GetProperty("PolyunsaturatedFat");
            Assert.AreEqual("PolyunsaturatedFat", pInfo.Name);
        }

    }
} 
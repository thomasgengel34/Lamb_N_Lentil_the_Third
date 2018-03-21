using System;
using Lamb_N_Lentil.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
        public void ShouldHaveIngredientsListProperty()
        {
            var pInfo = typeof(Entity).GetProperty("IngredientsList");
            Assert.AreEqual("IngredientsList", pInfo.Name);
        }

        [TestMethod]
        public void ShouldHaveDisplayNamePropertyOnInstanceName()
        {
            var attributes = typeof(Entity).GetProperty("InstanceName").GetCustomAttributes(false);
            var attribute = attributes[0];
            var name = attribute.GetType().Name;
            Assert.AreEqual("DisplayAttribute", name); 
        }

        [TestMethod]
        public void ShouldHaveDisplayNamePropertyOnListOfIngredients()
        {
            var attributes = typeof(Entity).GetProperty( "IngredientsList").GetCustomAttributes(false);
            var attribute = attributes[0];
            var name = attribute.GetType().Name;
            Assert.AreEqual("DisplayAttribute", name);
        }

        [TestMethod]
        public void ShouldHaveDisplayNamePropertyOfDisplayOnInstanceName()
        { 
            var pInfo = typeof(Entity).GetProperty("InstanceName")
                                .GetCustomAttributes(typeof(DisplayAttribute), false)
                                .Cast<DisplayAttribute>().FirstOrDefault();
            var name = pInfo.Name;
            
            Assert.AreEqual("Name", name);
        }

        [TestMethod]
        public void ShouldHaveDisplayNamePropertyOfList_ofIngredients_OnListOfIngredients()
        { 
            var pInfo = typeof(Entity).GetProperty("IngredientsList")
                                .GetCustomAttributes(typeof(DisplayAttribute), false)
                                .Cast<DisplayAttribute>().FirstOrDefault();
            var name = pInfo.Name;
            
            Assert.AreEqual("List of Ingredients", name);
        } 
    }
} 
using System;
using System.Reflection;
using Lamb_N_Lentil.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Lamb_N_Lentil.Tests.Infrastructure
{
    [TestClass]
    public class UITypeShould
    {
       private static FieldInfo[] fields;
        private  static Type type;


        public UITypeShould()
        {
              type = typeof(UIType);
             fields = type.GetFields();
        }

        [TestMethod]
        public void HaveCorrectUnderlyingType() => Assert.AreEqual("Int32 value__", fields[0].ToString());

        [TestMethod]
        public void HaveCorrectNumberOfOptions()
        {
            int numberOfOptions = 6;
            Assert.AreEqual(numberOfOptions+1,fields.Count());
        }


        [TestMethod]
        public void HasAbout()
        {
            var name = (from f in fields
                        where f.Name == "About"
                        select f.Name).First();

            Assert.AreEqual("About", name);
        }

        [TestMethod]
        public void HasContact()
        {
            var name = (from f in fields
                        where f.Name == "Contact"
                        select f.Name).First();

            Assert.AreEqual("Contact", name);
        }

        [TestMethod]
        public void HasEntity()
        {
            var name = (from f in fields
                        where f.Name == "Entity"
                        select f.Name).First();

            Assert.AreEqual("Entity", name);
        }


        [TestMethod]
        public void HasIngredient()
        {
            var name = (from f in fields
                        where f.Name == "Ingredient"
                        select f.Name).First();

            Assert.AreEqual("Ingredient", name);
        }

        [TestMethod]
        public void HasHome()
        {
            var name = (from f in fields
                        where f.Name == "Home"
                        select f.Name).First();

            Assert.AreEqual("Home", name);
        }

        [TestMethod]
        public void HasIndex()
        {
            var name = (from f in fields
                        where f.Name == "Index"
                        select f.Name).First();

            Assert.AreEqual("Index", name);
        }
    }
}

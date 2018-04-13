using System;
using System.Linq;
using System.Reflection;
using Lamb_N_Lentil.Domain.UsdaInformation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.Infrastructure
{
    [TestClass]
    public class UsdaDataSourceShould
    {
        private static FieldInfo[] fields;
        private static Type type;


        public UsdaDataSourceShould()
        {
            type = typeof(UsdaDataSource);
            fields = type.GetFields();
        }

        [TestMethod]
        public void HaveCorrectUnderlyingType() => Assert.AreEqual("Int32 value__", fields[0].ToString());

        [TestMethod]
        public void HaveCorrectNumberOfOptions()
        {
            int numberOfOptions = 3;
            Assert.AreEqual(numberOfOptions + 1, fields.Count());
        }


        [TestMethod]
        public void HaveBrandedDatabase()
        {
            var name = (from f in fields
                        where f.Name == "BrandedFoodProducts"
                        select f.Name).First();

            Assert.AreEqual("BrandedFoodProducts", name);
        }

        [TestMethod]
        public void HaveStandardReference()
        {
            var name = (from f in fields
                        where f.Name == "StandardReference"
                        select f.Name).First();

            Assert.AreEqual("StandardReference", name);
        }

        [TestMethod]
        public void HaveBoth()
        {
            var name = (from f in fields
                        where f.Name == "Both"
                        select f.Name).First();

            Assert.AreEqual("Both", name);
        }

        /*
         * The following tests are brittle because they are based on the enum values being in the right order, which is the fields[n] where n is the order.  Consider this in modifying the enum.
         */

        [TestMethod]
        public void HaveCorrectDisplayNameOnBrandedDatabase()
        {
            var bar = fields[1].CustomAttributes.First().NamedArguments[0].TypedValue.Value;

            Assert.AreEqual("Branded Food Products", bar);
        }

        [TestMethod]
        public void HaveCorrectDisplayNameOnStandardDatabase()
        {
            var bar = fields[2].CustomAttributes.First().NamedArguments[0].TypedValue.Value;

            Assert.AreEqual("Standard Reference", bar);
        }

        [TestMethod]
        public void HaveCorrectDisplayNameOnBoth()
        {
            var bar = fields[3].CustomAttributes.First().NamedArguments[0].TypedValue.Value;

            Assert.AreEqual("All Data Sources", bar);
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Lamb_N_Lentil.UI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.ViewModelTest
{
    [TestClass]
    public class IngredientDetailViewModelDisplayNamesShouldBeOn
    {
        [TestMethod]
        public void ShouldHaveCorrectDisplayNamePropertyOnSaturatedFat()
        {
            var pInfo = typeof(IngredientDetailViewModel).GetProperty("SaturatedFat")
                                .GetCustomAttributes(typeof(DisplayAttribute), false)
                                .Cast<DisplayAttribute>().FirstOrDefault();
            var name = pInfo.Name;

            Assert.AreEqual("Saturated Fat", name);
        }

        [TestMethod]
        public void ShouldHaveCorrectDisplayNamePropertyOnTransFat()
        {
            var pInfo = typeof(IngredientDetailViewModel).GetProperty("TransFat")
                                .GetCustomAttributes(typeof(DisplayAttribute), false)
                                .Cast<DisplayAttribute>().FirstOrDefault();
            var name = pInfo.Name;

            Assert.AreEqual("Trans Fat", name);
        }

        [TestMethod]
        public void ShouldHaveCorrectDisplayNamePropertyOnPolyunsaturatedFat()
        {
            var pInfo = typeof(IngredientDetailViewModel).GetProperty("PolyunsaturatedFat")
                                .GetCustomAttributes(typeof(DisplayAttribute), false)
                                .Cast<DisplayAttribute>().FirstOrDefault();
            var name = pInfo.Name;

            Assert.AreEqual("Polyunsaturated Fat", name);
        }

        [TestMethod]
        public void ShouldHaveCorrectDisplayNamePropertyOnMonunsaturatedFat()
        {
            var pInfo = typeof(IngredientDetailViewModel).GetProperty("MonounsaturatedFat")
                                .GetCustomAttributes(typeof(DisplayAttribute), false)
                                .Cast<DisplayAttribute>().FirstOrDefault();
            var name = pInfo.Name;

            Assert.AreEqual("Monounsaturated Fat", name);
        }
    }
}

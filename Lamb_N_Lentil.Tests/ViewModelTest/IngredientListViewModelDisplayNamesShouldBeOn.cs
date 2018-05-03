using System.ComponentModel.DataAnnotations;
using Lamb_N_Lentil.UI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Lamb_N_Lentil.Tests.ViewModelTest
{
    [TestClass]
    public class IngredientListViewModelDisplayNamesShouldBeOn
    { 

        [TestMethod]
        public void ShouldHaveDisplayNamePropertyOnUsdaDataSource()
        { 
            var attributes = typeof(IngredientListViewModel).GetProperty("UsdaDataSource").GetCustomAttributes(false);
            var attribute = attributes[0];
            var name = attribute.GetType().Name;
            Assert.AreEqual("DisplayAttribute", name);
        }
         

        [TestMethod]
        public void ShouldHaveCorrectDisplayNamePropertyOnUsdaDataSource()
        {
            var pInfo = typeof(IngredientListViewModel).GetProperty("UsdaDataSource")
                                .GetCustomAttributes(typeof(DisplayAttribute), false)
                                .Cast<DisplayAttribute>().FirstOrDefault();
            var name = pInfo.Name;

            Assert.AreEqual("USDA Data Source", name);
        }

       
    }
}

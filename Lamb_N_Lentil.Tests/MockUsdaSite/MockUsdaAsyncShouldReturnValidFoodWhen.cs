using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lamb_N_Lentil.Domain;
using Lamb_N_Lentil.Domain.UsdaInformation;
using Lamb_N_Lentil.UI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.MockUsdaSite
{
    [TestClass]
    public class MockUsdaAsyncShouldReturnValidFoodWhen
    {
        private IUsdaAsync usdaAsync { get; set; }
        private IngredientsController Controller  { get; set; }

        public MockUsdaAsyncShouldReturnValidFoodWhen()
        {
            usdaAsync = new MockUsdaAsync();
            Controller = new IngredientsController(null, usdaAsync);
        }



        [TestMethod]
        public async Task TheDatabaseIsAnEmptyString()
        {
            string correctAnswer = "Sample Manufacturer Or Food Group For Empty String";
            var list = await usdaAsync.GetListOfIngredientsFromTextSearch("food", "");
            Assert.IsInstanceOfType(list, typeof(List<IIngredient>));
            var result = list.First().ManufacturerOrFoodGroup;
            Assert.AreEqual(correctAnswer, result);
        }

        [TestMethod]
        public async Task TheDatabaseIsBoth()
        {
            string correctAnswer = "Sample Manufacturer Or Food Group For Empty String";
            var list = await usdaAsync.GetListOfIngredientsFromTextSearch("food", UsdaDataSource.Both.ToString());
            Assert.IsInstanceOfType(list, typeof(List<IIngredient>));
            var result = list.First().ManufacturerOrFoodGroup;
            Assert.AreEqual(correctAnswer, result);
        }

        [TestMethod]
        public async Task TheDatabaseIsBrandedProducts()
        {
            string correctAnswer = "Sample Manufacturer Or Food Group For Branded Products String";
            var list = await usdaAsync.GetListOfIngredientsFromTextSearch("food", UsdaDataSource.BrandedFoodProducts.ToString());
            Assert.IsInstanceOfType(list, typeof(List<IIngredient>));
            var result = list.First().ManufacturerOrFoodGroup;
            Assert.AreEqual(correctAnswer, result);
        }

        [TestMethod]
        public async Task TheDatabaseIsStandardDatabase()
        {
            string correctAnswer = "Sample Manufacturer Or Food Group For Standard String";
            var list = await usdaAsync.GetListOfIngredientsFromTextSearch("food", UsdaDataSource.StandardReference.ToString());
            Assert.IsInstanceOfType(list, typeof(List<IIngredient>));
            var result = list.First().ManufacturerOrFoodGroup;
            Assert.AreEqual(correctAnswer, result);
        }
    }
}

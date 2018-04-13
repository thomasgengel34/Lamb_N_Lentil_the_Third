using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lamb_N_Lentil.Domain;
using Lamb_N_Lentil.Domain.UsdaInformation;
using Lamb_N_Lentil.UI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.LiveUsdaSite
{
    [TestClass]
    public class LiveUsdaAsyncShouldReturnValidFoodWhen
    {
        private IUsdaAsync usdaAsync { get; set; }
        private IngredientsController Controller  { get; set; }
        private int standardTotal { get; set; } = 2699;
        private int brandedTotal { get; set; } = 14;
        private int Total { get; set; } = 4411;

        public LiveUsdaAsyncShouldReturnValidFoodWhen()
        {
            usdaAsync = new UsdaAsync();
            Controller = new IngredientsController(null, usdaAsync);
        }



        [TestMethod]
        public async Task TheDatabaseIsAnEmptyString()
        {
            int correctCount = Total; 
            var list = await usdaAsync.GetListOfIngredientsFromTextSearch("food", "");
            Assert.IsInstanceOfType(list, typeof(List<IIngredient>));
            var result = list.First().ManufacturerOrFoodGroup; 
            Assert.IsTrue(correctCount <= usdaAsync.FetchedTotalFromSearch);
        }

        [TestMethod]
        public async Task TheDatabaseIsBoth()
        { 
            int correctCount =Total;
            var list = await usdaAsync.GetListOfIngredientsFromTextSearch("food", UsdaDataSource.Both.ToString());
            Assert.IsInstanceOfType(list, typeof(List<IIngredient>));
            var result = list.First().ManufacturerOrFoodGroup;
            Assert.IsTrue(correctCount > 0);
            Assert.IsTrue(correctCount <= usdaAsync.FetchedTotalFromSearch);
        }

        [TestMethod]
        public async Task TheDatabaseIsBrandedProducts()
        { 
            int correctCount = brandedTotal;
            var list = await usdaAsync.GetListOfIngredientsFromTextSearch("food", UsdaDataSource.BrandedFoodProducts.ToString());
            Assert.IsInstanceOfType(list, typeof(List<IIngredient>));
            var result = list.First().ManufacturerOrFoodGroup; 
            Assert.IsTrue(correctCount>0);
            Assert.IsTrue(correctCount<=usdaAsync.FetchedTotalFromSearch);
        }

        [TestMethod]
        public async Task TheDatabaseIsStandardDatabase()
        { 
            int correctCount = 2699;
            var list = await usdaAsync.GetListOfIngredientsFromTextSearch("a", UsdaDataSource.StandardReference.ToString());
            Assert.IsInstanceOfType(list, typeof(List<IIngredient>));
            var result = list.First().ManufacturerOrFoodGroup;
            Assert.IsTrue(correctCount > 0);
            Assert.IsTrue(correctCount <= usdaAsync.FetchedTotalFromSearch);
        }
         
    }
}

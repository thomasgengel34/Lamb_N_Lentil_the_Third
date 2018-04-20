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
        private IngredientsController Controller { get; set; }
        private int standardTotal { get; set; } = 2699;
        private int brandedTotal { get; set; } = 14;
        private int Total { get; set; } = 4411;

        public LiveUsdaAsyncShouldReturnValidFoodWhen()
        {
            usdaAsync = new UsdaAsync();
            Controller = new IngredientsController(null, usdaAsync);
        }

         

        [TestMethod]
        public async Task WhenUPC078742212050IsSearchText()
        {
            string searchText = "078742212050";
            string correctIngredients = "DICED PEACHES, WATER, SUGAR, NATURAL FLAVOR, ASCORBIC ACID (VITAMIN C) TO PROTECT COLOR, CITRIC ACID.";
            int correctCount = 1;
            var list = await usdaAsync.GetListOfIngredientsFromTextSearch(searchText, UsdaDataSource.StandardReference.ToString());
            IIngredient ingredient = (Entity)list.First();
            var mfr = await usdaAsync.FetchUsdaFoodReport(ingredient.Ndbno);
            string returnedIngredients = usdaAsync.FetchedIngredientsInIngredient;
            Assert.AreEqual(correctCount ,usdaAsync.FetchedTotalFromSearch);
            Assert.AreEqual(correctIngredients, returnedIngredients);
        }
    }
}

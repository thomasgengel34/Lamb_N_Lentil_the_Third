using Lamb_N_Lentil.Domain;
using Lamb_N_Lentil.Domain.UsdaInformation;
using Lamb_N_Lentil.UI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace Lamb_N_Lentil.Tests.LiveUsdaSite
{
    [TestClass]
    public class LiveUsdaAsyncShouldReturnValidFoodWhen
    {
        private readonly IUsdaAsync usdaAsync = new UsdaAsync();
        private UsdaFoodReport report;
        private IngredientsController Controller;
        private string ndbno;

        public LiveUsdaAsyncShouldReturnValidFoodWhen()
        {
            Controller = new IngredientsController(null, usdaAsync);
        }

        [TestInitialize]
        public async Task CallFetchReport()
        {
            await FetchReport();
        }

        private async Task FetchReport()
        {
            report = await usdaAsync.FetchUsdaFoodReport(ndbno);
        }

        [TestMethod]
        public async Task WhenUPC078742212050IsSearchText()
        {
            string searchText = "078742212050";
            string correctIngredients = "DICED PEACHES, WATER, SUGAR, NATURAL FLAVORS, ASCORBIC ACID (VITAMIN C) TO PROTECT COLOR, CITRIC ACID.";
            int correctCount = 1;
            var list = await usdaAsync.GetListOfIngredientsFromTextSearch(searchText, UsdaDataSource.StandardReference.ToString());
            IIngredient ingredient = (Entity)list.First();
            var mfr = await usdaAsync.FetchUsdaFoodReport(ingredient.Ndbno);
            string returnedIngredients = ingredient.IngredientsInIngredient;
            Assert.AreEqual(correctCount, usdaAsync.FetchedTotalFromSearch);
            Assert.AreEqual(correctIngredients, returnedIngredients);
        }


    }
}

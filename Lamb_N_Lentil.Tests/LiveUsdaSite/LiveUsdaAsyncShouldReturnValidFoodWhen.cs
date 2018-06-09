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
        private readonly IUsdaAsync usdaAsync= new UsdaAsync();
        private readonly IUsdaAsyncFoodReport usdaAsyncFoodReport= new UsdaAsyncFoodReport();
        private IngredientsController Controller; 

        public LiveUsdaAsyncShouldReturnValidFoodWhen()
        {  
            Controller = new IngredientsController(null, usdaAsync);
        }

         

        [TestMethod]
        public async Task WhenUPC078742212050IsSearchText()
        {
            string searchText = "078742212050";
            string correctIngredients = "DICED PEACHES, WATER, SUGAR, NATURAL FLAVORS, ASCORBIC ACID (VITAMIN C) TO PROTECT COLOR, CITRIC ACID.";
            int correctCount = 1;
            var list = await usdaAsync.GetListOfIngredientsFromTextSearch(searchText, UsdaDataSource.StandardReference.ToString());
            IIngredient ingredient = (Entity)list.First();
            var mfr = await usdaAsyncFoodReport.FetchUsdaFoodReport(ingredient.Ndbno);
            string returnedIngredients = ingredient.IngredientsInIngredient;
            Assert.AreEqual(correctCount ,usdaAsync.FetchedTotalFromSearch);
            Assert.AreEqual(correctIngredients, returnedIngredients);
        }

       
    }
}

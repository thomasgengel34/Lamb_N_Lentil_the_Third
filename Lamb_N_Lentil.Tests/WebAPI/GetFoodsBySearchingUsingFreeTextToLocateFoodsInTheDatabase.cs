using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lamb_N_Lentil.UI.Controllers;
using Lamb_N_Lentil.Domain;
using System.Collections.Generic;
using System.Linq;
using Lamb_N_Lentil.Domain.UsdaInformation;

namespace Lamb_N_Lentil.Tests.WebAPI
{
    [TestClass]
    public class GetFoodsBySearchingUsingFreeTextToLocateFoodsInTheDatabase
    {

        UsdaAsync  controller = new UsdaAsync();

        [TestMethod]
        public async Task ReturnCorrectIngredientsFor076606619663OnSingleItemSearchAsync()
        {
            //	single item search: 076606619663 will return ingredients for PICKLED ASPARAGUS , SPICY!, UPC: 076606619663 

            string searchString = " 076606619663";
            string correctIngredients = "INGREDIENTS: GREEN ASPARAGUS, WATER, VINEGAR, SUGAR, SALT, MUSTARD SEEDS, BLACK PEPPER, RED HOT PEPPER, GARLIC";

            string listOfReturnedIngredients = await controller.GetListOfIngredientPropertyFromTextSearch(searchString);

            Assert.AreEqual(correctIngredients, listOfReturnedIngredients);

        }


        [TestMethod]
        public async Task ReturnAListOf50IngredientsFromTextSearchOnCream()
        {
            string searchString = "cream";
            await Task.Delay(0);

            var returnedList = await controller.GetListOfIngredients(searchString);
            Assert.AreEqual(50, returnedList.list.item.Length);
        }
    }
}

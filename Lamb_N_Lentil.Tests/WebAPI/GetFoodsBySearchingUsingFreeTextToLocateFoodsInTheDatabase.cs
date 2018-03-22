using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lamb_N_Lentil.UI.Controllers;
using Lamb_N_Lentil.Domain;

namespace Lamb_N_Lentil.Tests.WebAPI
{
    [TestClass]
    public class GetFoodsBySearchingUsingFreeTextToLocateFoodsInTheDatabase
    {

        EntityAsyncController controller = new EntityAsyncController();

        [TestMethod]
        public async Task ReturnCorrectIngredientsFor076606619663OnSingleItemSearchAsync()
        {
            //	single item search: 076606619663 will return ingredients for PICKLED ASPARAGUS , SPICY!, UPC: 076606619663 

            string searchString = " 076606619663";
            string correctIngredients = "INGREDIENTS: GREEN ASPARAGUS, WATER, VINEGAR, SUGAR, SALT, MUSTARD SEEDS, BLACK PEPPER, RED HOT PEPPER, GARLIC";
           
            Entity entity = await controller.GetIngredientFromSearchText(searchString);

            Assert.AreEqual(correctIngredients, entity.IngredientsList);

        }
    }
}

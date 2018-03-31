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
        public async Task  ReturnAListOf50IngredientsFromTextSearchOnSingleSpace()
        {
            string searchString = " ";
            await Task.Delay(0); 
            List<IIngredient> returnedList = await controller.GetListOfIngredientsFromTextSearch(searchString);
            Assert.AreEqual(50, returnedList.Count); 
        }
    }
}

using System;
using Lamb_N_Lentil.Domain;
using Lamb_N_Lentil.Domain.UsdaInformation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.Models
{
    [TestClass]
    public class MapUsdaFoodReportToIngredientShould
    {
        private food food;
        private string correctName="test name";
        private string correctNumber="test number";
        private string correctDesc="test desc";
        private string correctDate = "4/17/2017";

        private IIngredient ingredient;


        public MapUsdaFoodReportToIngredientShould()
        {
              food = new food();
            food.desc = new desc();
            food.desc.name = correctName;
            food.desc.ndbno = correctNumber;
            food.ing = new ing();
            food.ing.desc = correctDesc;
            food.ing.upd = correctDate;
             ingredient = MapUsdaFoodReportToIIngredient.ConvertUsdaFoodReportToIIngredient(food);
        }

        [TestMethod]
        public void ConvertName()
        {
            Assert.AreEqual(correctName, ingredient.InstanceName);
        }

        [TestMethod]
        public void ConvertUpdateDate()
        {
            Assert.AreEqual(correctDate, ingredient.UpdateDate);
        }
    }
}

using System;
using Lamb_N_Lentil.Domain;
using Lamb_N_Lentil.UI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.Models
{
    [TestClass]
    public class IngredientDetailViewModelShould
    {
        private IIngredient ingredient;
        private string correctDescription = "description";
        private string correctIngredientsInIngredient = "various";
        private string correctNdbno = "test ndbno";
        private string correctUpdateDate = "2/4/1932";
        private string correctLabel = "cup for label";
        private decimal correctEqv = 113.0M;
        private decimal correctCalories = 43.0M;
        private decimal correctTotalCarbohydrate = 810.1M;
        private decimal correctTotalFat = 11.0M;
        private decimal correctSugars = 0.01M;

        private IngredientDetailViewModel idvm;


        public IngredientDetailViewModelShould()
        {
            ingredient = new Entity();
            ingredient.Description = correctDescription;
            ingredient.IngredientsInIngredient = correctIngredientsInIngredient;
            ingredient.Ndbno = correctNdbno;
            ingredient.UpdateDate = correctUpdateDate;
            ingredient.Label = correctLabel;
            ingredient.Eqv = correctEqv;
            ingredient.Calories = correctCalories;
            ingredient.TotalFat = correctTotalFat;
            ingredient.TotalCarbohydrate = correctTotalCarbohydrate;
            ingredient.Sugars = correctSugars;
            idvm = IngredientDetailViewModel.MapIIngredientToIngredientDetailViewModel(ingredient);
        }

        [TestMethod]
        public void HaveCorrectDescrption()
        {
            Assert.AreEqual(correctDescription, idvm.Description);
        }

        [TestMethod]
        public void HaveCorrectIngredientsInIngredient()
        {
            Assert.AreEqual(correctIngredientsInIngredient, idvm.IngredientsInIngredient);
        }

        [TestMethod]
        public void HaveCorrectNdbno()
        {
            Assert.AreEqual(correctNdbno, idvm.Ndbno);
        }

        [TestMethod]
        public void HaveCorrectUpdateDate()
        {
            Assert.AreEqual(correctUpdateDate, idvm.UpdateDate);
        }

        [TestMethod]
        public void HaveCorrectLabel()
        {
            Assert.AreEqual(correctLabel, idvm.Label);
        }

        [TestMethod]
        public void HaveCorrectEqv()
        {
            Assert.AreEqual(correctEqv, idvm.Eqv);
        }

        [TestMethod]
        public void HaveCorrectCalories()
        {
            Assert.AreEqual(correctCalories, idvm.Calories);
        }

        [TestMethod]
        public void HaveCorrectCaloriesFromFat()
        { 
            Assert.AreEqual(9 * correctTotalFat, idvm.CaloriesFromFat);
        }

        [TestMethod]
        public void HaveCorrectTotalCarbohydrate()
        {
            Assert.AreEqual( correctTotalCarbohydrate, idvm.TotalCarbohydrate);
        }

        [TestMethod]
        public void HaveCorrectSugars()
        {
            Assert.AreEqual(correctSugars, idvm.Sugars);
        }
    }
}

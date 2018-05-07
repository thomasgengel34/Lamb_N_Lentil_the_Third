using Lamb_N_Lentil.Domain;
using Lamb_N_Lentil.Tests.Classes;
using Lamb_N_Lentil.UI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lamb_N_Lentil.Tests.ViewModelTest
{
    [TestClass]
    public class IngredientDetailViewModelShould : Common
    {

        Type type;

        public IngredientDetailViewModelShould()
        {
            type = typeof(IngredientDetailViewModel);
        }

        [TestMethod]
        public void HaveNdbnoProperty()
        {
            var pInfo = type.GetProperty("Ndbno");
            Assert.AreEqual("Ndbno", pInfo.Name);
        }

        [TestMethod]
        public void HaveDescriptionProperty()
        {
            var pInfo = type.GetProperty("Description");
            Assert.AreEqual("Description", pInfo.Name);
        }

        [TestMethod]
        public void HaveTotalFromSearchProperty()
        {
            var pInfo = type.GetProperty("TotalFromSearch");
            Assert.AreEqual("TotalFromSearch", pInfo.Name);
        }

        [TestMethod]
        public void HaveIngredientInIngredientsProperty()
        {
            var pInfo = type.GetProperty("IngredientsInIngredient");
            Assert.AreEqual("IngredientsInIngredient", pInfo.Name);
        }

        [TestMethod]
        public void HaveSaturatedFatProperty()
        {
            var pInfo = type.GetProperty("SaturatedFat");
            Assert.AreEqual("SaturatedFat", pInfo.Name);
        }

        [TestMethod]
        public void HaveSodiumProperty()
        {
            var pInfo = type.GetProperty("Sodium");
            Assert.AreEqual("Sodium", pInfo.Name);
        }

        [TestMethod]
        public void HaveUpdateDateProperty()
        {
            var pInfo = type.GetProperty("UpdateDate");
            Assert.AreEqual("UpdateDate", pInfo.Name);
        }

        [TestMethod]
        public void HaveLabelProperty()
        {
            var pInfo = type.GetProperty("Label");
            Assert.AreEqual("Label", pInfo.Name);
        }

        [TestMethod]
        public void HaveTransFatProperty()
        {
            var pInfo = type.GetProperty("TransFat");
            Assert.AreEqual("TransFat", pInfo.Name);
        }


        [TestMethod]
        public void HavePolyunsaturatedFatProperty()
        {
            var pInfo = type.GetProperty("PolyunsaturatedFat");
            Assert.AreEqual("PolyunsaturatedFat", pInfo.Name);
        }

        [TestMethod]
        public void HaveMonounsaturatedFatProperty()
        {
            var pInfo = type.GetProperty("MonounsaturatedFat");
            Assert.AreEqual("MonounsaturatedFat", pInfo.Name);
        }

        [TestMethod]
        public void HaveCholesterolProperty()
        {
            var pInfo = type.GetProperty("Cholesterol");
            Assert.AreEqual("Cholesterol", pInfo.Name);
        }

        [TestMethod]
        public void HavePotassiumProperty()
        {
            var pInfo = type.GetProperty("Potassium");
            Assert.AreEqual("Potassium", pInfo.Name);
        }

        [TestMethod]
        public void HaveDietaryFiberProperty()
        {
            var pInfo = type.GetProperty("DietaryFiber");
            Assert.AreEqual("DietaryFiber", pInfo.Name);
        }

        [TestMethod]
        public void HaveSugarsProperty()
        {
            var pInfo = type.GetProperty("Sugars");
            Assert.AreEqual("Sugars", pInfo.Name);
        }

        [TestMethod]
        public void HaveProteinProperty()
        {
            var pInfo = type.GetProperty("Protein");
            Assert.AreEqual("Protein", pInfo.Name);
        }

        [TestMethod]
        public void HaveVitaminAProperty()
        {
            var pInfo = type.GetProperty("VitaminA");
            Assert.AreEqual("VitaminA", pInfo.Name);
        }

        [TestMethod]
        public void HaveVitaminCProperty()
        {
            var pInfo = type.GetProperty("VitaminC");
            Assert.AreEqual("VitaminC", pInfo.Name);
        }


        [TestMethod]
        public void HaveCalciumProperty()
        {
            var pInfo = type.GetProperty("Calcium");
            Assert.AreEqual("Calcium", pInfo.Name);
        }


        [TestMethod]
        public void HaveMapIIngredientToIngredientDetailViewModelMethod()
        {
            var mInfo = type.GetMethod("MapIIngredientToIngredientDetailViewModel");
            Assert.AreEqual("MapIIngredientToIngredientDetailViewModel", mInfo.Name);
        }


    }
}

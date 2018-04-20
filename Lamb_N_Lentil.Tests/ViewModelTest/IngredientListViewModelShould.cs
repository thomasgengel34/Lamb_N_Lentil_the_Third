using System.Collections.Generic;
using Lamb_N_Lentil.Domain;
using Lamb_N_Lentil.UI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lamb_N_Lentil.Domain.UsdaInformation;

namespace Lamb_N_Lentil.Tests.ViewModelTest
{
    [TestClass]
    public class IngredientListViewModelShould
    {
        private IIngredient Ingredient { get; set; }
        private IIngredient Ingredient_2 { get; set; }
        private IngredientListViewModel Vm { get; set; }
        private IngredientListViewModel Vm_2 { get; set; }

        public IngredientListViewModelShould()
        {
            Ingredient = new Entity(); 
            Ingredient.Description = "this is for a test";
            Ingredient.IngredientsInIngredient = "x,y,z";

            Vm = IngredientListViewModel.MapIIngredientToIngredientListViewModel(Ingredient);

            Vm_2 = new IngredientListViewModel()
            { 
                UsdaDataSource = UsdaDataSource.BrandedFoodProducts,
                Description = "vm text", 
                IngredientsInIngredient= "this is a test list of ingredients"
            }; 
        }

         

        
        [TestMethod]
        public void CopyDescriptionFromIIngredient()
        {
            Assert.AreEqual(Ingredient.Description, Vm.Description);
        }
         
          
        [TestMethod]
        public void CopyDescriptionFromIngredientListViewModelToIIngredient()
        {
            Ingredient_2 = IngredientListViewModel.MapIIngredientListViewModelToIngredient(Vm_2); Assert.AreEqual(Vm_2.Description, Ingredient_2.Description);
            Assert.AreEqual("vm text", Vm_2.Description);
        }

        [TestMethod]
        public void CopyIngredientsListFromIIngredient() 
        {
            Assert.AreEqual(Ingredient.IngredientsInIngredient, Vm.IngredientsInIngredient);
        }

        [TestMethod]
        public void CopyIngredientsListFromIngredientListViewModelToIIngredient()
        {
            Ingredient_2 = IngredientListViewModel.MapIIngredientListViewModelToIngredient(Vm_2);
            Assert.AreEqual(Vm_2.IngredientsInIngredient, Ingredient_2.IngredientsInIngredient);
            Assert.AreEqual("this is a test list of ingredients", Vm_2.IngredientsInIngredient);
        }
    }
}

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
            Ingredient.Ndbno = 101;
            Ingredient.UsdaDataSource = UsdaDataSource.StandardReference;
            Ingredient.Description = "this is for a test";
            Ingredient.ManufacturerOrFoodGroup = "Jawa";

            Vm = IngredientListViewModel.MapIIngredientToIngredientListViewModel(Ingredient);

            Vm_2 = new IngredientListViewModel()
            {
                Ndbno = 7890,
                UsdaDataSource = UsdaDataSource.BrandedFoodProducts,
                Description = "vm text",
                ManufacturerOrFoodGroup = "Wookie"
            }; 
        }


        [TestMethod]
        public void CopyFoodDataSourceFromIIngredient()
        {
            Assert.AreEqual(UsdaDataSource.StandardReference, Vm.UsdaDataSource);
        }

        [TestMethod]
        public void CopyNbndoFromIIngredient()
        {
            Assert.AreEqual(Ingredient.Ndbno, Vm.Ndbno);
        }

        [TestMethod]
        public void CopyDescriptionFromIIngredient()
        {
            Assert.AreEqual(Ingredient.Description, Vm.Description);
        }

        [TestMethod]
        public void CopyManufacturerOrFoodGroupFromIIngredient()
        {
            Assert.AreEqual(Ingredient.ManufacturerOrFoodGroup, Vm.ManufacturerOrFoodGroup);
        }
         
        [TestMethod]
        public void CopyNdbnoFromIngredientListViewModelToIIngredient()
        {
            Ingredient_2 = IngredientListViewModel.MapIIngredientListViewModelToIngredient(Vm_2); Assert.AreEqual(Vm_2.Ndbno, Ingredient_2.Ndbno);
            Assert.AreEqual(7890, Vm_2.Ndbno);
        }

        [TestMethod]
        public void CopyDescriptionFromIngredientListViewModelToIIngredient()
        {
            Ingredient_2 = IngredientListViewModel.MapIIngredientListViewModelToIngredient(Vm_2); Assert.AreEqual(Vm_2.Description, Ingredient_2.Description);
            Assert.AreEqual("vm text", Vm_2.Description);
        }
       
        [TestMethod]
        public void CopyUsdaDataSourceFromIngredientListViewModelToIIngredient()
        {
            Ingredient_2 = IngredientListViewModel.MapIIngredientListViewModelToIngredient(Vm_2); Assert.AreEqual(Vm_2.UsdaDataSource, Ingredient_2.UsdaDataSource);
            Assert.AreEqual(UsdaDataSource.BrandedFoodProducts, Vm_2.UsdaDataSource);
        }
      
        [TestMethod]
        public void CopyManufacturerOrFoodGroupFromIngredientListViewModelToIIngredient()
        {
            Ingredient_2 = IngredientListViewModel.MapIIngredientListViewModelToIngredient(Vm_2); Assert.AreEqual(Vm_2.ManufacturerOrFoodGroup, Ingredient_2.ManufacturerOrFoodGroup);
            Assert.AreEqual("Wookie", Vm_2.ManufacturerOrFoodGroup);

        }
    }
}

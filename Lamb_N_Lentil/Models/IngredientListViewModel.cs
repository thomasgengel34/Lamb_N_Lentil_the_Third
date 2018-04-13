using System.ComponentModel.DataAnnotations;
using Lamb_N_Lentil.Domain;
using Lamb_N_Lentil.Domain.UsdaInformation;

namespace Lamb_N_Lentil.UI.Models
{
    public class IngredientListViewModel
    {
        public string Ndbno { get; set; }

        [Display(Name = "USDA Data Source")]
        public UsdaDataSource UsdaDataSource { get; set; }


        public string Description { get; set; }

        [Display(Name = "Manufacturer Or Food Group")]
        public string ManufacturerOrFoodGroup { get; set; }


        public static IngredientListViewModel MapIIngredientToIngredientListViewModel(IIngredient ingredient)
        {
            IngredientListViewModel Vm = new IngredientListViewModel()
            {
                Ndbno = ingredient.Ndbno,
                UsdaDataSource = ingredient.UsdaDataSource,
                Description = ingredient.Description,
                ManufacturerOrFoodGroup = ingredient.ManufacturerOrFoodGroup
            };
            return Vm;
        }

        public static IIngredient MapIIngredientListViewModelToIngredient(IngredientListViewModel vm)
        {
            IIngredient ingredient = new Entity();
            ingredient.Ndbno = vm.Ndbno;
            ingredient.UsdaDataSource = vm.UsdaDataSource;
            ingredient.Description = vm.Description;
            ingredient.ManufacturerOrFoodGroup = vm.ManufacturerOrFoodGroup;

            return ingredient; 
        } 
    }
}
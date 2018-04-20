using System.ComponentModel.DataAnnotations;
using Lamb_N_Lentil.Domain;
using Lamb_N_Lentil.Domain.UsdaInformation;

namespace Lamb_N_Lentil.UI.Models
{
    public class IngredientListViewModel
    {
        public string Ndbno { get; set; }

        public string DataSourceDisplayName { get; set; }

        [Display(Name = "USDA Data Source")]
        public UsdaDataSource UsdaDataSource { get; set; }

        [Display(Name = "Ingredient")]
        public string Description { get; set; }

        public int TotalFromSearch { get; set; }

        [Display(Name = "List of Ingredients")]
        public string  IngredientsInIngredient { get; set; }


        public static IngredientListViewModel MapIIngredientToIngredientListViewModel(IIngredient ingredient)
        {
            IngredientListViewModel Vm = new IngredientListViewModel()
            {
                Description = ingredient.Description,
                 IngredientsInIngredient = ingredient.IngredientsInIngredient
            };
            return Vm;
        }

        public static IIngredient MapIIngredientListViewModelToIngredient(IngredientListViewModel vm)
        {
            IIngredient ingredient = new Entity();
            ingredient.Description = vm.Description;
            ingredient.IngredientsInIngredient = vm.IngredientsInIngredient;


            return ingredient;
        }

        private static string GetDisplayNameOfUsdaDataSource(string source)
        {
            if (source == UsdaDataSource.BrandedFoodProducts.ToString())
            {
                return "Branded Food Products";
            }
            else if (source == UsdaDataSource.StandardReference.ToString())
            {
                return "Standard Reference";
            }
            else return "Other or Not Provided";
        }
    }
}
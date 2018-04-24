using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Lamb_N_Lentil.Domain;

namespace Lamb_N_Lentil.UI.Models
{
    public class IngredientDetailViewModel
    {
        public string Ndbno { get; set; } 

        [Display(Name = "Ingredient")]
        public string Description { get; set; }

        public int TotalFromSearch { get; set; }

        [Display(Name = "List of Ingredients")]
        public string IngredientsInIngredient { get; set; }

        [Display(Name = "Updated On")]
        public string UpdateDate { get; set; }


        public static IngredientDetailViewModel MapIIngredientToIngredientDetailViewModel(IIngredient ingredient)
        {
            IngredientDetailViewModel Vm = new IngredientDetailViewModel()
            {
                Description = ingredient.Description,
                IngredientsInIngredient = ingredient.IngredientsInIngredient,
                Ndbno = ingredient.Ndbno,
                UpdateDate=ingredient.UpdateDate
            };
            return Vm;
        }

        public static IIngredient MapIIngredientDetailViewModelToIngredient(IngredientDetailViewModel vm)
        {
            IIngredient ingredient = new Entity();
            ingredient.Description = vm.Description;
            ingredient.IngredientsInIngredient = vm.IngredientsInIngredient;


            return ingredient;
        }
    }
}
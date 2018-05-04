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
        public string Label { get; set; }
        public decimal Eqv { get; set; }
        public decimal Calories { get; set; } 

        [Display(Name = "Total Fat")]
        public decimal TotalFat { get; set; }

        [Display(Name = "Calories From Fat")]
        public decimal CaloriesFromFat { get; set; }

        public decimal Cholesterol { get; set; }
        public decimal Potassium { get; set; }

        [Display(Name = "Saturated Fat")]
        public decimal SaturatedFat { get; set; }

        [Display(Name = "Trans Fat")]
        public decimal TransFat { get; set; }

        [Display(Name = "Polyunsaturated Fat")]
        public decimal PolyunsaturatedFat { get; set; }

        [Display(Name = "Monounsaturated Fat")]
        public decimal MonounsaturatedFat { get; set; }

        public decimal Sodium { get; set; }

        [Display(Name = "Total Carbohydrate")]
        public decimal TotalCarbohydrate { get; set; }

        [Display(Name = "Dietary Fiber")]
        public decimal DietaryFiber { get; set; }

        public decimal Sugars { get; set; }

        public decimal Protein { get; set; }

        public static IngredientDetailViewModel MapIIngredientToIngredientDetailViewModel(IIngredient ingredient)
        {
            IngredientDetailViewModel Vm = new IngredientDetailViewModel()
            {
                Description = ingredient.Description,
                IngredientsInIngredient = ingredient.IngredientsInIngredient,

                Ndbno = ingredient.Ndbno,
                UpdateDate = ingredient.UpdateDate,
                Label = ingredient.Label,
                Eqv = ingredient.Eqv,
                Calories = ingredient.Calories,
                TotalFat = ingredient.TotalFat,
                SaturatedFat = ingredient.SaturatedFat,
                TransFat=ingredient.TransFat,
                MonounsaturatedFat = ingredient.MonounsaturatedFat,
                PolyunsaturatedFat=ingredient.PolyunsaturatedFat,
                TotalCarbohydrate = ingredient.TotalCarbohydrate,
                CaloriesFromFat = ingredient.CaloriesFromFat,
                Sodium=ingredient.Sodium,
                Cholesterol=ingredient.Cholesterol,
                Potassium=ingredient.Potassium,
                DietaryFiber=ingredient.DietaryFiber,
                Sugars=ingredient.Sugars,
                Protein=ingredient.Protein
            };
            return Vm;
        }
    }
}
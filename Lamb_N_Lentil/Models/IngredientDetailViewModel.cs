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

        [Display(Name = "INGREDIENTS")]
        public string IngredientsInIngredient { get; set; }

        [Display(Name = "Updated On")]
        public string UpdateDate { get; set; }
        public string Label { get; set; }
        public decimal Eqv { get; set; }
        public decimal Calories { get; set; }
        public decimal Calcium { get; set; }

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

        [Display(Name = "Vitamin A")]
        public decimal VitaminA { get; set; }

        [Display(Name = "Vitamin C")]
        public decimal VitaminC { get; set; }

        [Display(Name = "Vitamin D")]
        public decimal VitaminD { get; set; }

        [Display(Name = "Thiamine (Vitamin B-1)")]
        public decimal Thiamine { get; set; }

        [Display(Name = "Riboflavin (Vitamin B-2)")]
        public decimal Riboflavin { get; set; }

        [Display(Name = "Niacin (Vitamin B-3)")]
        public decimal Niacin { get; set; }

        [Display(Name = "Vitamin B-6")]
        public decimal VitaminB6 { get; set; }

        [Display(Name = "Vitamin B-12")]
        public decimal VitaminB12 { get; set; }

        [Display(Name = "Folic Acid")]
        public decimal FolicAcid { get; set; }

        [Display(Name = "Manufacturer Or Food Group")]
        public string ManufacturerOrFoodGroup { get; set; }


        public decimal Iron { get; set; }
        public decimal Magnesium { get; set; }
        public decimal Sugars { get; set; }

        public decimal Protein { get; set; }

       
        public int TotalFatPercentageDailyValue { get; set; }
        public int SaturatedFatPercentageDailyValue { get; set; }
        public int CholesterolPercentageDailyValue { get; set; }
        public int SodiumPercentageDailyValue { get; set; }
        public int PotassiumPercentageDailyValue { get; set; }

        public int TotalCarbohydratePercentageDailyValue { get; set; }
        public int DietaryFiberPercentageDailyValue { get; set; }
        public int VitaminAPercentageDailyValue { get; set; }
        public int VitaminCPercentageDailyValue { get; set; }
        public int CalciumPercentageDailyValue { get; set; }
        public int IronPercentageDailyValue { get; set; }
        public int ThiaminePercentageDailyValue { get; set; }
        public int RiboflavinPercentageDailyValue { get; set; }
        public int NiacinPercentageDailyValue { get; set; }
        public int FolicAcidPercentageDailyValue { get; set; }
        public int VitaminDPercentageDailyValue { get; set; }
        public int VitaminB12PercentageDailyValue { get; set; }
        public int VitaminB6PercentageDailyValue { get; set; } 

        public string TotalFatUnit { get; set; }
        public string SaturatedFatUnit { get; set; }
        public string TransFatUnit { get; set; }
        public string PolyunsaturatedFatUnit { get; set; }
        public string MonounsaturatedFatUnit { get; set; }
        public string CholesterolUnit { get; set; }
         public string SodiumUnit { get; set; }
        public string PotassiumUnit { get; set; } 
        public string TotalCarbohydrateUnit { get; set; }
         public string DietaryFiberUnit { get; set; }
        public string SugarsUnit { get; set; }
        public string ProteinUnit { get; set; }
         public string VitaminAUnit { get; set; }
         public string VitaminCUnit { get; set; }
         public string CalciumUnit { get; set; }
         public string IronUnit { get; set; }
         public string ThiamineUnit { get; set; }
         public string RiboflavinUnit { get; set; }
         public string NiacinUnit { get; set; }
         public string FolicAcidUnit { get; set; }
         public string VitaminDUnit { get; set; }
         public string VitaminB12Unit { get; set; }
         public string VitaminB6Unit { get; set; }

        public static IngredientDetailViewModel MapIIngredientToIngredientDetailViewModel(IIngredient ingredient)
        {
            IngredientDetailViewModel Vm = new IngredientDetailViewModel()
            {
                Description = ingredient.Description,
                Eqv = ingredient.Eqv,
                IngredientsInIngredient = ingredient.IngredientsInIngredient,
                Label = ingredient.Label,
                Magnesium = ingredient.Magnesium,
                Ndbno = ingredient.Ndbno,
                UpdateDate = ingredient.UpdateDate,
                Calcium = ingredient.Calcium,
                Calories = ingredient.Calories,
                FolicAcid = ingredient.FolicAcid,
                Iron = ingredient.Iron,
                MonounsaturatedFat = ingredient.MonounsaturatedFat,
                PolyunsaturatedFat = ingredient.PolyunsaturatedFat,
                SaturatedFat = ingredient.SaturatedFat,
                Sodium = ingredient.Sodium,
                TotalCarbohydrate = ingredient.TotalCarbohydrate,
                TotalFat = ingredient.TotalFat,
                TransFat = ingredient.TransFat,
                CaloriesFromFat = ingredient.CaloriesFromFat,
                Cholesterol = ingredient.Cholesterol,
                Potassium = ingredient.Potassium,
                DietaryFiber = ingredient.DietaryFiber,
                Sugars = ingredient.Sugars,
                Protein = ingredient.Protein,
                VitaminA = ingredient.VitaminA,
                VitaminB6 = ingredient.VitaminB6,
                VitaminB12 = ingredient.VitaminB12,
                VitaminC = ingredient.VitaminC,
                VitaminD = ingredient.VitaminD,
                Thiamine = ingredient.Thiamine,
                Riboflavin = ingredient.Riboflavin,
                Niacin = ingredient.Niacin,
                ManufacturerOrFoodGroup = ingredient.ManufacturerOrFoodGroup,
                // for 2,000 calorie diet - these need to be verified
                TotalFatPercentageDailyValue = Decimal.ToInt16(100 * ingredient.TotalFat / 65),
                SaturatedFatPercentageDailyValue = Decimal.ToInt16(100 * ingredient.SaturatedFat / 20),
                CholesterolPercentageDailyValue = Decimal.ToInt16(100 * ingredient.Cholesterol / 300),
                SodiumPercentageDailyValue = Decimal.ToInt16(100 * ingredient.Sodium / 2400),
                PotassiumPercentageDailyValue = Decimal.ToInt16(100 * ingredient.Potassium / 3500), // test
                TotalCarbohydratePercentageDailyValue = Decimal.ToInt16(100 * ingredient.TotalCarbohydrate / 300),
                DietaryFiberPercentageDailyValue = Decimal.ToInt16(100 * ingredient.DietaryFiber / 25),
                VitaminAPercentageDailyValue = Decimal.ToInt16( ingredient.VitaminA / 50),
                VitaminCPercentageDailyValue = Decimal.ToInt16(100 * ingredient.VitaminC / 50),
                CalciumPercentageDailyValue = Decimal.ToInt16(100 * ingredient.Calcium / 1000),   
                IronPercentageDailyValue = Decimal.ToInt16(100 * ingredient.Iron / 18),
                ThiaminePercentageDailyValue = Decimal.ToInt16(100 * ingredient.Thiamine / 1.5M),
                RiboflavinPercentageDailyValue = Decimal.ToInt16(100 * ingredient.Riboflavin / 1.7M),
                NiacinPercentageDailyValue = Decimal.ToInt16(100 * ingredient.Niacin / 20.0M),
                FolicAcidPercentageDailyValue = Decimal.ToInt16(100 * ingredient.FolicAcid / 400.0M),
                VitaminDPercentageDailyValue = Decimal.ToInt16(100 * ingredient.VitaminD / 400.0M),
                VitaminB12PercentageDailyValue = Decimal.ToInt16(100 * ingredient.VitaminB12 / 6.0M),
                VitaminB6PercentageDailyValue = Decimal.ToInt16(100 * ingredient.VitaminB12 / 2.0M),

                TotalFatUnit = ingredient.TotalFatUnit,
                SaturatedFatUnit = ingredient.SaturatedFatUnit,
                TransFatUnit = ingredient.TransFatUnit,
                PolyunsaturatedFatUnit = ingredient.PolyunsaturatedFatUnit,
                CholesterolUnit=ingredient.CholesterolUnit,
                MonounsaturatedFatUnit=ingredient.MonounsaturatedFatUnit,
                SodiumUnit=ingredient.SodiumUnit,
                PotassiumUnit=ingredient.PotassiumUnit,
                TotalCarbohydrateUnit=ingredient.TotalCarbohydrateUnit,
                DietaryFiberUnit=ingredient.DietaryFiberUnit,
                SugarsUnit=ingredient.SugarsUnit,
                ProteinUnit=ingredient.ProteinUnit,
                VitaminAUnit=ingredient.VitaminAUnit,
                VitaminCUnit=ingredient.VitaminCUnit,
                CalciumUnit=ingredient.CalciumUnit,
                IronUnit=ingredient.IronUnit,
                ThiamineUnit=ingredient.ThiamineUnit,
                RiboflavinUnit=ingredient.RiboflavinUnit,
                NiacinUnit=ingredient.NiacinUnit,
                FolicAcidUnit=ingredient.FolicAcidUnit,
                VitaminDUnit=ingredient.VitaminDUnit,
                VitaminB12Unit=ingredient.VitaminB12Unit,
                VitaminB6Unit=ingredient.VitaminB6Unit,
            };
            return Vm;
        }
    }
}
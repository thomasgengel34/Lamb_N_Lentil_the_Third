using System;
using System.ComponentModel.DataAnnotations;
using Lamb_N_Lentil.Domain.UsdaInformation;

namespace Lamb_N_Lentil.Domain
{
    public class Entity : IIngredient
    {
        public int ID { get; set; }

        [Display(Name = "Name")]
        public string InstanceName { get; set; }

        [Display(Name = "List of Ingredients")]
        public string IngredientsList { get; set; }



        int IIngredient.Ndbno { get; set; }

        [Display(Name = "USDA Data Source")]
        UsdaDataSource IIngredient.UsdaDataSource { get; set; }

        string IIngredient.Description { get; set; }

        [Display(Name = "Manufacturer Or Food Group")]
        string IIngredient.ManufacturerOrFoodGroup { get; set; }

    }
}

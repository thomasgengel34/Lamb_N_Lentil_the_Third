using System;
using System.ComponentModel.DataAnnotations; 

namespace Lamb_N_Lentil.Domain
{
    public class Entity : IEntity
    {
        public int ID { get; set; }

        [Display(Name = "Name")]
        public string InstanceName { get; set; }

        [Display(Name = "List of Ingredients")]
        public string IngredientsList { get; set; }
    }
}

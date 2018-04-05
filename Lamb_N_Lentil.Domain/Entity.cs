using Lamb_N_Lentil.Domain.UsdaInformation;

namespace Lamb_N_Lentil.Domain
{
    public class Entity : IIngredient
    {
        public int ID { get; set; }
         
        public string InstanceName { get; set; }
         
        public string IngredientsList { get; set; }
         
        int IIngredient.Ndbno { get; set; }

 
        UsdaDataSource IIngredient.UsdaDataSource { get; set; }

        string IIngredient.Description { get; set; }
 
        string IIngredient.ManufacturerOrFoodGroup { get; set; }

    }
}

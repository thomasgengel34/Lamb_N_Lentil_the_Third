using Lamb_N_Lentil.Domain.UsdaInformation;

namespace Lamb_N_Lentil.Domain
{
    public class Entity : IIngredient
    {
        public int ID { get; set; }
         
        public string InstanceName { get; set; }
         
        public string IngredientsInIngredient { get; set; }
        public string Ndbno { get; set; }
        public string  Description { get; set; }

        public string UpdateDate { get; set; }
    }
}

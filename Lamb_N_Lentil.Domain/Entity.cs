using System;

namespace Lamb_N_Lentil.Domain
{
    public class Entity : IEntity
    {
        public int ID { get; set; }
        public string InstanceName { get; set; }
        public string ClassName { get; set; }
        public string DisplayName { get; set; }
        public string Discriminator { get; set; }
        public string Description { get; set; }
        public string CreatedByUser { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModifiedByUser { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string IngredientsList { get; set; }
    }
}

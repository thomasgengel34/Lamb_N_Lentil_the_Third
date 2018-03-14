using System;

namespace Lamb_N_Lentil.Domain
{ 
    public interface IEntity
    {
        int ID { get; set; }
        string InstanceName { get; set; }
        string ClassName { get; set; }
        string DisplayName { get; set; }
        string Discriminator { get; set; }

        string Description { get; set; }

        string CreatedByUser { get; set; }
        DateTime CreationDate { get; set; }

        string ModifiedByUser { get; set; }
        DateTime ModifiedDate { get; set; }

        string IngredientsList { get; set; }
    }
}

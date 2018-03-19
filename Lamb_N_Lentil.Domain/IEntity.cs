using System;

namespace Lamb_N_Lentil.Domain
{ 
    public interface IEntity
    {
        int ID { get; set; }
        string InstanceName { get; set; } 
        string IngredientsList { get; set; }
    }
}

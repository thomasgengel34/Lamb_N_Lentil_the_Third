using Lamb_N_Lentil.Domain.UsdaInformation;

namespace Lamb_N_Lentil.Domain
{
    public interface IIngredient : IEntity
    { 
        string Description { get; set; }  
        string Ndbno { get; set; }
    }
}

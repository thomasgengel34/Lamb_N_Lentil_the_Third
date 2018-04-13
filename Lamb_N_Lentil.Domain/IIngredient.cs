using Lamb_N_Lentil.Domain.UsdaInformation;

namespace Lamb_N_Lentil.Domain
{
    public interface IIngredient : IEntity
    {
        string Ndbno { get; set; }  // has to be string because there is a leading 0 that is important in searching USDA database
        UsdaDataSource UsdaDataSource { get; set; }
        string Description { get; set; }
        string ManufacturerOrFoodGroup { get; set; }
    }
}

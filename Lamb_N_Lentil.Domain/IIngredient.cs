namespace Lamb_N_Lentil.Domain
{
    public interface IIngredient : IEntity
    {
        int Ndbno { get; set; }
        UsdaDataSource UsdaDataSource { get; set; }
        string Description { get; set; }
        string ManufacturerOrFoodGroup { get; set; }
    }
}

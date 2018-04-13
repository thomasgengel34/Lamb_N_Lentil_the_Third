using System.Threading.Tasks;

namespace Lamb_N_Lentil.Domain.UsdaInformation
{
    public interface IMapUsdaFoodToIngredient
    {
        Task<string> GetManufacturerOrFoodGroup(string ndbno);
    }
}
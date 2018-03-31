using System.Threading.Tasks;

namespace Lamb_N_Lentil.Domain
{
    public interface IMapUsdaFoodToIngredient
    {
        Task<string> GetManufacturerOrFoodGroup(int ndbno);
    }
}
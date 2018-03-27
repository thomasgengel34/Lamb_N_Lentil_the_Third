using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lamb_N_Lentil.Domain.UsdaInformation
{
    public interface IUsdaAsync
    {
        Task<Foods> GetIngredientFromSearchText(string searchString, string foodGroup = "", UsdaWebApiDataSource usdaWebApiDataSource = UsdaWebApiDataSource.BrandedFoodProducts);

        Task<int?> GetNdbnoFromSearchStringAsync(HttpClient client2, string searchString, string dataSource = ""); 

        Task<Entity> GetIngredientFromTextSearch(string searchText);

        Task<List<IIngredient>> GetListOfIngredientsFromTextSearch(string searchString);

        Task<string> GetListOfIngredientPropertyFromTextSearch(string searchString);

        Task<string> GetManufacturerOrFoodGroup(int ndbno);
       
    }
}
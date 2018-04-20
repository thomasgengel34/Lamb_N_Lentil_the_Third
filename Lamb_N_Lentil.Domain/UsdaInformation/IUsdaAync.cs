using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lamb_N_Lentil.Domain.UsdaInformation
{
    public interface IUsdaAsync
    {
        Task<List<IIngredient>> GetListOfIngredientsFromTextSearch(string searchString, string dataSource = "");

        Task<UsdaFoodReport> FetchUsdaFoodReport(string ndbno);

        int FetchedTotalFromSearch { get; set; }
        string FetchedIngredientsInIngredient { get; set; }
    }
}
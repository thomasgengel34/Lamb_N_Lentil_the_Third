using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lamb_N_Lentil.Domain.UsdaInformation
{
    public interface IUsdaAsync
    {
        Task<List<IIngredient>> GetListOfIngredientsFromTextSearch(string searchString, string dataSource = ""); 
        int FetchedTotalFromSearch { get; set; }
        string FetchedIngredientsInIngredient { get; set; }
    }
}
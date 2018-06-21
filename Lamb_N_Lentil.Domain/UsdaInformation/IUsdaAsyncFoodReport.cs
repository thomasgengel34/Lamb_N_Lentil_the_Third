using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamb_N_Lentil.Domain.UsdaInformation
{
  public interface IUsdaAsyncFoodReport
    {
        Task<UsdaFoodReport> FetchUsdaFoodReport(string ndbno); 
    }
}

using Lamb_N_Lentil.Domain.UsdaInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamb_N_Lentil.Tests.LiveUsdaSite
{
    public class LiveUsdaSiteTestSetup
    {
       
        protected internal string Ndbno { get; set; }
        protected UsdaFoodReport report;
        protected IUsdaAsync usdaAsync;

        protected async Task FetchReport()
        {
            usdaAsync = new UsdaAsync();
            report = await usdaAsync.FetchUsdaFoodReport(Ndbno);
        }
    }
}

using System;
using System.Linq;
using System.Threading.Tasks;
using Lamb_N_Lentil.Domain.UsdaInformation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.LiveUsdaSite
{
    [TestClass]
    public class LiveUsdaAsyncTestForNutrientsShouldFindVarious
    { 
        IUsdaAsyncFoodReport usdaAsync;

        public LiveUsdaAsyncTestForNutrientsShouldFindVarious()
        {
            usdaAsync  = new UsdaAsyncFoodReport();
        }


       
    }
}

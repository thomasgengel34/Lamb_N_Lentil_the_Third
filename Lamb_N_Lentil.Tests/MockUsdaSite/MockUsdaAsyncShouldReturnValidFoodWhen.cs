using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lamb_N_Lentil.Domain;
using Lamb_N_Lentil.Domain.UsdaInformation;
using Lamb_N_Lentil.UI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.MockUsdaSite
{
    [TestClass]
    public class MockUsdaAsyncShouldReturnValidFoodWhen
    {
        private IUsdaAsync usdaAsync { get; set; }
        private IngredientsController Controller  { get; set; }

        public MockUsdaAsyncShouldReturnValidFoodWhen()
        {
            usdaAsync = new MockUsdaAsync();
            Controller = new IngredientsController(null, usdaAsync);
        } 
    }
}

using System.Collections.Generic;
using Lamb_N_Lentil.Domain;
using Lamb_N_Lentil.UI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lamb_N_Lentil.Domain.UsdaInformation;
using System.Threading.Tasks;

namespace Lamb_N_Lentil.Tests.LiveUsdaSite
{
    [TestClass]
    public class LiveUsdaAsyncShouldReturnValidFullFoodReportForHominy20030
    {
        private string ndbno = "20030";

        [TestMethod]
        public async Task  Hominy20030HasCorrectName()
        {
            string correctName = "Hominy, canned, white";
            UsdaAsync usdaAsync = new UsdaAsync();
            UsdaFoodReport report = await usdaAsync.FetchFullUsdaFoodReport(ndbno);
            Assert.AreEqual( correctName, report.foods[0].food.desc.name);
        }

        [TestMethod]
        public async Task Hominy20030HasCorrectNdbno()
        { 
            UsdaAsync usdaAsync = new UsdaAsync();
            UsdaFoodReport report = await usdaAsync.FetchFullUsdaFoodReport(ndbno);
            Assert.AreEqual(ndbno, report.foods[0].food.desc.ndbno);
        }
    }
}

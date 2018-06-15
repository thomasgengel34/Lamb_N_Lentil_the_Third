using System.Collections.Generic;
using Lamb_N_Lentil.Domain;
using Lamb_N_Lentil.UI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lamb_N_Lentil.Domain.UsdaInformation;
using System.Threading.Tasks;

namespace Lamb_N_Lentil.Tests.LiveUsdaSite
{
    [TestClass]
    public class LiveUsdaAsyncShouldReturnValidFoodReportForHominy20030
    {
        private string ndbno = "20030";
        private UsdaFoodReport report;
        private UsdaAsync usdaAsync;

        [TestInitialize]
        public async Task CallFetchReport()
        {
            await FetchReport();
        }

        private async Task FetchReport()
        {
            usdaAsync = new UsdaAsync();
            report = await usdaAsync.FetchUsdaFoodReport(ndbno);
        }

        [TestMethod]
        public void HasCorrectName()
        {
            string correct = "Hominy, canned, white";
            Assert.AreEqual(correct, report.foods[0].food.desc.name);
        }

        [TestMethod]
        public void HasCorrectNdbno()
        {
            Assert.AreEqual(ndbno, report.foods[0].food.desc.ndbno);
        }

        [TestMethod]
        public void HasCorrectUnitForFirstNutrient()
        {
            string correct = "g";
            Assert.AreEqual(correct, report.foods[0].food.nutrients[0].unit);
        }
    }
}

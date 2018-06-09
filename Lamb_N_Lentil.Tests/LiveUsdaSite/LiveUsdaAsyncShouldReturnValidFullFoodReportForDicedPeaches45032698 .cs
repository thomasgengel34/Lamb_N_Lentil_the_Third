using System.Collections.Generic;
using Lamb_N_Lentil.Domain;
using Lamb_N_Lentil.UI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lamb_N_Lentil.Domain.UsdaInformation;
using System.Threading.Tasks;
using System.Linq;

namespace Lamb_N_Lentil.Tests.LiveUsdaSite
{ 
    [TestClass]
    public class LiveUsdaAsyncShouldReturnValidFoodReportForDicedPeaches45032698
    {
       private readonly string ndbno = "45032698";

        [TestMethod]
        public async Task  WithCorrectName()
        {
            string correctName = "DICED PEACHES, UPC: 078742212050";
            UsdaAsync usdaAsync = new UsdaAsync();
            UsdaFoodReport report = await usdaAsync.FetchUsdaFoodReport(ndbno);
            Assert.AreEqual( correctName, report.foods[0].food.desc.name);
        }

        [TestMethod]
        public async Task WithCorrectNdbno()
        { 
            UsdaAsync usdaAsync = new UsdaAsync();
            UsdaFoodReport report = await usdaAsync.FetchUsdaFoodReport(ndbno);
            Assert.AreEqual(ndbno, report.foods[0].food.desc.ndbno);
        }

        [TestMethod]
        public async Task WithCorrectIngredients()
        {
            string correctIngredients = "DICED PEACHES, WATER, SUGAR, NATURAL FLAVORS, ASCORBIC ACID (VITAMIN C) TO PROTECT COLOR, CITRIC ACID.";
            UsdaAsync usdaAsync = new UsdaAsync();
            UsdaFoodReport report = await usdaAsync.FetchUsdaFoodReport(ndbno);
            Assert.AreEqual(correctIngredients, report.foods[0].food.ing.desc);
        }

        [TestMethod]
        public async Task WithCorrectUpdateDate()
        {
            string correct  = "04/10/2018";
            UsdaAsync usdaAsync = new UsdaAsync();
            UsdaFoodReport report = await usdaAsync.FetchUsdaFoodReport(ndbno);
            string returned = report.foods[0].food.ing.upd;
            Assert.AreEqual(correct, returned);
        }

        [TestMethod]
        public async Task WithCorrectEqv()
        {
           decimal correct  = 113.0M;
            UsdaAsync usdaAsync = new UsdaAsync();
            UsdaFoodReport report = await usdaAsync.FetchUsdaFoodReport(ndbno);
           decimal returned  = report.foods[0].food.nutrients.First().measures.First().eqv;
            Assert.AreEqual(correct , returned   );
        }

        [TestMethod]
        public async Task WithCorrectFoodGroupOrManufacturer()
        {
            string correct  = "WAL-MART STORES, INC.";
            UsdaAsync usdaAsync = new UsdaAsync();
            UsdaFoodReport report = await usdaAsync.FetchUsdaFoodReport(ndbno);
           string returnedFg  = report.foods[0].food.desc.fg;
           string returnedManu  = report.foods[0].food.desc.manu;
            Assert.AreEqual(correct , returnedManu );
            Assert.IsNull(returnedFg);
        }
    }
}

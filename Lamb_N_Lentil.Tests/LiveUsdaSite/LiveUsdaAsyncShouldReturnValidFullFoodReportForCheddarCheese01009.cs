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
    public class LiveUsdaAsyncShouldReturnValidFoodReportForCheddarCheese01009 : LiveUsdaSiteTestSetup
    { 
        [TestInitialize]
        public async Task CallFetchReport()
        {
            Ndbno = "01009";
            await FetchReport();
        } 
         

        [TestMethod]
        public void WithCorrectName()
        {
            string correctName = "Cheese, cheddar (Includes foods for USDA's Food Distribution Program)";

            Assert.AreEqual(correctName, report.foods[0].food.desc.name);
        }

        [TestMethod]
        public void WithCorrectNdbno()
        { 
            Assert.AreEqual(Ndbno, report.foods[0].food.desc.ndbno);
        }
         

        [TestMethod]
        public async Task Manufacturer()
        { 
            decimal correct = 0.0M;
            UsdaFoodReport report = await usdaAsync.FetchUsdaFoodReport(Ndbno);
            var returned = (from c in report.foods[0].food.nutrients
                            where c.nutrient_id == 431
                            select c.measures[0].value).FirstOrDefault();
            Assert.AreEqual(correct, returned);
        }

        [TestMethod]
        public void HasCorrectServingSizeForFirstNutrient()
        {
            decimal correct = 1.0M;
            Assert.AreEqual(correct, report.foods[0].food.nutrients[0].measures[0].qty);
        }

        [TestMethod]
        public void FolicAcid()
        {
            decimal correct = 0.0M;
            var returned = (from c in report.foods[0].food.nutrients
                            where c.nutrient_id == 431
                            select c.measures[0].value).FirstOrDefault();
            Assert.AreEqual(correct, returned);
        }

        [TestMethod]
        public void Magnesium()
        { 
            decimal correct = 36.0M; 
            var returned = (from c in report.foods[0].food.nutrients
                            where c.nutrient_id == 304
                            select c.measures[0].value).FirstOrDefault();
            Assert.AreEqual(correct, returned);
        }
        
        [TestMethod]
        public void Calcium()
        { 
            decimal correct = 937.0M; 
            var returned = (from c in report.foods[0].food.nutrients
                            where c.nutrient_id == 301
                            select c.measures[0].value).FirstOrDefault();
            Assert.AreEqual(correct, returned);
        }

        [TestMethod]
        public void VitaminD()
        { 
            decimal correct = 32.0M; 
            var returned = (from c in report.foods[0].food.nutrients
                            where c.nutrient_id == 324
                            select c.measures[0].value).FirstOrDefault();
            Assert.AreEqual(correct, returned);
        }

        [TestMethod]
        public void Thiamine()
        { 
            decimal correct = 0.038M; 
            var returned = (from c in report.foods[0].food.nutrients
                            where c.nutrient_id == 404
                            select c.measures[0].value).FirstOrDefault();
            Assert.AreEqual(correct, returned);
        }

        [TestMethod]
        public void Riboflavin()
        { 
            decimal correct = 0.565M; 
            var returned = (from c in report.foods[0].food.nutrients
                            where c.nutrient_id == 405
                            select c.measures[0].value).FirstOrDefault();
            Assert.AreEqual(correct, returned);
        }

        [TestMethod]
        public void Niacin()
        { 
            decimal correct = 0.078M; 
            var returned = (from c in report.foods[0].food.nutrients
                            where c.nutrient_id == 406
                            select c.measures[0].value).FirstOrDefault();
            Assert.AreEqual(correct, returned);
        }

        [TestMethod]
        public void VitaminB6()
        { 
            decimal correct = 0.087M; 
            var returned = (from c in report.foods[0].food.nutrients
                            where c.nutrient_id == 415
                            select c.measures[0].value).FirstOrDefault();
            Assert.AreEqual(correct, returned);
        }

        [TestMethod]
        public void VitaminB12()
        { 
            decimal correct = 1.45M; 
            var returned = (from c in report.foods[0].food.nutrients
                            where c.nutrient_id == 418
                            select c.measures[0].value).FirstOrDefault();
            Assert.AreEqual(correct, returned);
        }
    }
}

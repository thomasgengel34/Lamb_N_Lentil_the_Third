using System;
using System.Web.Mvc;
using Lamb_N_Lentil.UI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.Controllers
{
    [TestClass]
    public class HomeControllerShould 
    {
        private HomeController controller;

        [TestInitialize]
        public void Setup()
        {
            controller = new HomeController();
        }



        [TestMethod]
        public void Index()
        {  
            ViewResult result = controller.Index() as ViewResult;
             
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {  
            ViewResult result = controller.About() as ViewResult;
             
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {  
            ViewResult result = controller.Contact() as ViewResult;
             
            Assert.IsNotNull(result);
        }

          
    }
}

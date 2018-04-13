﻿using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Lamb_N_Lentil.Domain;
using Lamb_N_Lentil.Tests.MockUsdaSite;
using Lamb_N_Lentil.UI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.Controllers
{
    [TestClass]
    public class EntityControllerShould
    {
        private EntityController controller;

        [TestInitialize]
        public void Setup()
        {
            controller = new EntityController();
        } 
    }
}

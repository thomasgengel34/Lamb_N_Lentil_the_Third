using System;
using Lamb_N_Lentil.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.Classes
{
    [TestClass]
    public class EntityClassShould
    {
        [TestMethod]
        public void ImplementIEntity()
        {
            Type type = typeof(Entity);
            Type implementedInterface=type.GetInterface("IEntity");
            Assert.AreEqual(typeof(IEntity), implementedInterface);
        }
    }
}

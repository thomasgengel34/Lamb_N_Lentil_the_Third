using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.Classes
{
  public class Common
    {
        internal List<PropertyInfo> listOfPropertyInfos;


        internal void VerifyPropertyIsValid(string value)
        {
            var propertyName = from c in listOfPropertyInfos
                               where c.Name == value
                               select c.Name;

            Assert.AreEqual(propertyName.First(), value);
            Assert.IsNotNull(propertyName.Count());
        }
    }
}

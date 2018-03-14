using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Lamb_N_Lentil.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.Classes
{
    [TestClass]
    public class IEntityShouldContain
    {  
        List<PropertyInfo> listOfPropertyInfos;
        
        public IEntityShouldContain()
        {
            PropertyInfo[] propertyInfos = typeof(IEntity).GetProperties();
            listOfPropertyInfos = propertyInfos.Select(i => i).ToList();
        }
        
        [TestMethod]
        public void IDProperty() => VerifyPropertyIsValid("ID");

        [TestMethod]
        public void InstanceNameProperty() => VerifyPropertyIsValid("InstanceName");

        [TestMethod]
        public void ClassNameProperty() => VerifyPropertyIsValid("ClassName");

        [TestMethod]
        public void DiscriminatorProperty() => VerifyPropertyIsValid("Discriminator");

        [TestMethod]
        public void DisplayNameProperty() => VerifyPropertyIsValid("DisplayName");

        [TestMethod]
        public void DescriptionProperty() => VerifyPropertyIsValid("Description");

        [TestMethod]
        public void IngredientsListProperty() => VerifyPropertyIsValid("IngredientsList");

        [TestMethod]
        public void CreatedByUserProperty() => VerifyPropertyIsValid("CreatedByUser");


        [TestMethod]
        public void CreationDateProperty() => VerifyPropertyIsValid("CreationDate");

        [TestMethod]
        public void ModifiedByUserProperty() => VerifyPropertyIsValid("ModifiedByUser");

        [TestMethod]
        public void ModifiedDateProperty() => VerifyPropertyIsValid("ModifiedDate");


        private void VerifyPropertyIsValid(string value)
        {
            var propertyName = from c in listOfPropertyInfos
                               where c.Name == value
                               select c.Name;

            Assert.AreEqual(propertyName.First(), value);
            Assert.IsNotNull(propertyName.Count());
        }
    } 
}

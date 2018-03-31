using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lamb_N_Lentil.Domain;
using Lamb_N_Lentil.Domain.UsdaInformation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.UsdaInformationTest
{
    [TestClass]
    public class UsdaAsyncTest : IUsdaAsync, IMapUsdaFoodToIngredient
    {
          async Task<string> IMapUsdaFoodToIngredient.GetManufacturerOrFoodGroup(int ndbno)
        {
            string foo = "this is a test";
            await Task.Delay(0);
            return foo;
        } 

        Task<List<IIngredient>> IUsdaAsync.GetListOfIngredientsFromTextSearch(string searchString, string dataSource) => throw new NotImplementedException();

        async Task<string> IUsdaAsync.GetManufacturerOrFoodGroup(int ndbno)
        {
            string foo = "this is fake for now";
            await Task.Delay(0);
            return foo;
        }

        [TestMethod]
        public void ReduceStringLengthToWhatWillWorkOnUsdaWillNotThrowErrorWithEmptyString()
        {
            string result =  UsdaAsync.ReduceStringLengthToWhatWillWorkOnUSDA(""); 
        }

        [TestMethod]
        public void ReduceStringLengthToWhatWillWorkOnUsdaWillNotThrowErrorWithNullString()
        {
            string result = UsdaAsync.ReduceStringLengthToWhatWillWorkOnUSDA(null);
        }
    }
}

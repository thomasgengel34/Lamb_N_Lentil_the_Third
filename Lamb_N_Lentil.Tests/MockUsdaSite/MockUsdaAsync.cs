using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lamb_N_Lentil.Domain;
using Lamb_N_Lentil.Domain.UsdaInformation;

namespace Lamb_N_Lentil.Tests.MockUsdaSite
{
    internal class MockUsdaAsync : IUsdaAsync
    {
        public int FetchedTotalFromSearch { get; set; }

        /// <summary>
        /// TODO: should this method have Async in the name?
        /// </summary>
        /// <param name="searchString"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public async Task<List<IIngredient>> GetListOfIngredientsFromTextSearch(string searchString, string description)
        {
            int someRandomID = 79258888;
            string someRandomNumber = "45237067";
            string sampleManufacturereOrFoodGroup = "xxxx";
            if (description == ""||description==UsdaDataSource.Both.ToString())
            {
                sampleManufacturereOrFoodGroup = "Sample Manufacturer Or Food Group For Empty String";
            }
            if (description== UsdaDataSource.BrandedFoodProducts.ToString())
            {
                sampleManufacturereOrFoodGroup= "Sample Manufacturer Or Food Group For Branded Products String";
            }
            if (description==UsdaDataSource.StandardReference.ToString())
            {
                sampleManufacturereOrFoodGroup = "Sample Manufacturer Or Food Group For Standard String";
            }

            await Task.Delay(0);
            List<IIngredient> list = new List<IIngredient>();
            IIngredient ingredient = new Entity() { InstanceName = searchString, ID = someRandomID };
            ingredient.Ndbno = someRandomNumber;
            ingredient.ManufacturerOrFoodGroup = sampleManufacturereOrFoodGroup;
            if (searchString != "This Should Return No Ingredients")
            {
                list.Add(ingredient);
            }

            return list;
        }

        public async Task<string> GetListOfIngredientstFromTextSearch(string searchString, string foodGroup = "", UsdaWebApiDataSource usdaWebApiDataSource = UsdaWebApiDataSource.BrandedFoodProducts)
        {
            Foods foods = new Foods();
            foods.food = new Foods.Food();
            foods.food.desc = new Foods.Food.Desc();
            foods.food.desc.Name = "This is a test";
            foods.food.ing = new Foods.Food.Ing();
            foods.food.ing.desc = "salt, pepper, butter, garlic, turmeric, egg";
            await Task.Delay(0);
            return foods.food.ing.desc;
        }

        public async Task<string> GetManufacturerOrFoodGroup(string ndbno)
        {
            await Task.Delay(0);
            if (ndbno == "01009")
            {

                return "Valley Brook Farm";
            }
            else
            {
                return "this should not be possible to see";
            }
        }


        public async Task<string> GetListOfIngredientsFromTextSearch(string searchString)
        {
            string correctList = "onion, garlic, turmeric, basil";
            if (searchString != "foo")
            {
                throw new Exception("wrong parameter!");
            }
            else
            {
                await Task.Delay(0);
                return correctList;
            }
        }


    }
}

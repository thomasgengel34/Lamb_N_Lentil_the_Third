using Lamb_N_Lentil.Domain;
using Lamb_N_Lentil.Domain.UsdaInformation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lamb_N_Lentil.Tests.MockUsdaSiteFoodReport
{
    public class MockUsdaAsyncForFoodReport : IUsdaAsyncFoodReport
    {

        protected UsdaFoodReport report;

        public MockUsdaAsyncForFoodReport()
        { 
            report = new UsdaFoodReport
            {
                foods = new foods[1]
            };
            report.foods[0] = new foods
            {
                food = new food()
            };
            report.foods[0].food.desc = new desc
            {
                name = "My Name",
                ndbno = "0"
            };
            report.foods[0].food.ing = new ing
            {
                desc = "ing-desc"
            };
            report.foods[0].food.desc.fg = "default food group";
            report.foods[0].food.desc.manu = "default manufacturer";
            report.foods[0].food.ing.upd = "default updated date";

            report.foods[0].food.nutrients = new nutrients[25];

            report.foods[0].food.nutrients[0] = new nutrients
            {
                name = "Total Fat",
                nutrient_id = 204,
                value = "24",
                measures = new measures[1]
            };
            report.foods[0].food.nutrients[0].measures[0] = new measures
            {
                label = "default label total fat",
                eqv = 3.1415926M,
                value = 654.2M
            };

            report.foods[0].food.nutrients[1] = new nutrients
            {
                name = "Calcium",
                nutrient_id = 301,
                value = "25",
                measures = new measures[1]
            };
            report.foods[0].food.nutrients[1].measures[0] = new measures
            {
                label = "default label calcium",
                eqv = 2M,
                value = 0.95M
            };

            report.foods[0].food.nutrients[2] = new nutrients
            {
                name = "Cholesterol",
                nutrient_id = 601,
                value = "25",
                measures = new measures[1]
            };
            report.foods[0].food.nutrients[2].measures[0] = new measures
            {
                label = "default label cholesterol",
                eqv = 2M,
                value = 82.93M
            };

            report.foods[0].food.nutrients[3] = new nutrients
            {
                name = "Iron",
                nutrient_id = 303,
                value = "26",
                measures = new measures[1]
            };
            report.foods[0].food.nutrients[3].measures[0] = new measures
            {
                label = "default label iron",
                eqv = 2M,
                value = 0.114M
            };

            report.foods[0].food.nutrients[4] = new nutrients
            {
                name = "Magnesium",
                nutrient_id = 304,
                value = "27",
                measures = new measures[1]
            };
            report.foods[0].food.nutrients[4].measures[0] = new measures
            {
                label = "default label magnesium",
                eqv = 2M,
                value = 22.23M
            };

            report.foods[0].food.nutrients[5] = new nutrients
            {
                name = "Niacin",
                nutrient_id = 406,
                value = "28",
                measures = new measures[1]
            };
            report.foods[0].food.nutrients[5].measures[0] = new measures
            {
                label = "default label niacin",
                eqv = 2M,
                value = 21.045M
            };

            report.foods[0].food.nutrients[6] = new nutrients
            {
                name = "Monosaturated Fat",
                nutrient_id = 645,
                value = "29",
                measures = new measures[1]
            };
            report.foods[0].food.nutrients[6].measures[0] = new measures
            {
                label = "default label m-s fat",
                eqv = 2M,
                value = 81.92M
            };

            report.foods[0].food.nutrients[7] = new nutrients
            {
                name = "Polyunsaturated Fat",
                nutrient_id = 646,
                value = "30",
                measures = new measures[1]
            };
            report.foods[0].food.nutrients[7].measures[0] = new measures
            {
                label = "default label puns fat",
                eqv = 2M,
                value = 736.08M
            };

            report.foods[0].food.nutrients[8] = new nutrients
            {
                name = "Protein",
                nutrient_id = 203,
                value = "31",
                measures = new measures[1]
            };
            report.foods[0].food.nutrients[8].measures[0] = new measures
            {
                label = "default label protein",
                eqv = 2M,
                value = 7.15M
            };

            report.foods[0].food.nutrients[9] = new nutrients
            {
                name = "Riboflavin",
                nutrient_id = 405,
                value = "32",
                measures = new measures[1]
            };
            report.foods[0].food.nutrients[9].measures[0] = new measures
            {
                label = "default label riboflavin",
                eqv = 2M,
                value = 3.333M
            };

            report.foods[0].food.nutrients[10] = new nutrients
            {
                name = "Sodium",
                nutrient_id = 307,
                value = "33",
                measures = new measures[1]
            };
            report.foods[0].food.nutrients[10].measures[0] = new measures
            {
                label = "default label sodium",
                eqv = 2M,
                value = 143.0M
            };

            report.foods[0].food.nutrients[11] = new nutrients
            {
                name = "Sugars",
                nutrient_id = 269,
                value = "34",
                measures = new measures[1]
            };
            report.foods[0].food.nutrients[11].measures[0] = new measures
            {
                label = "default label sugars",
                eqv = 2M,
                value = 14.30M
            };

            report.foods[0].food.nutrients[12] = new nutrients
            {
                name = "Thiamine",
                nutrient_id = 404,
                value = "35",
                measures = new measures[1]
            };
            report.foods[0].food.nutrients[12].measures[0] = new measures
            {
                label = "default label thiamine",
                eqv = 2M,
                value = 1.228M
            };

            report.foods[0].food.nutrients[13] = new nutrients
            {
                name = "Total carbohydrate",
                nutrient_id = 205,
                value = "36",
                measures = new measures[1]
            };
            report.foods[0].food.nutrients[13].measures[0] = new measures
            {
                label = "default label total carb",
                eqv = 2M,
                value = 77.04M
            };

            report.foods[0].food.nutrients[14] = new nutrients
            {
                name = "Trans Fat",
                nutrient_id = 605,
                value = "37",
                measures = new measures[1]
            };
            report.foods[0].food.nutrients[14].measures[0] = new measures
            {
                label = "default label trans fat",
                eqv = 2M,
                value = 101.01M
            };

            report.foods[0].food.nutrients[15] = new nutrients
            {
                name = "Vitamin A",
                nutrient_id = 318,
                value = "39",
                measures = new measures[1]
            };
            report.foods[0].food.nutrients[15].measures[0] = new measures
            {
                label = "default label vitamin A",
                eqv = 2.1M,
                value = 101.02M
            };

            report.foods[0].food.nutrients[16] = new nutrients
            {
                name = "Vitamin B12",
                nutrient_id = 418,
                value = "39",
                measures = new measures[1]
            };
            report.foods[0].food.nutrients[16].measures[0] = new measures
            {
                label = "default label vitamin B12",
                eqv = 2M,
                value = 71.055M
            };

            report.foods[0].food.nutrients[17] = new nutrients
            {
                name = "Vitamin B6",
                nutrient_id = 415,
                value = "40",
                measures = new measures[1]
            };
            report.foods[0].food.nutrients[17].measures[0] = new measures
            {
                label = "default label vitamin B6",
                eqv = 2M,
                value = 76.05M
            };

            report.foods[0].food.nutrients[18] = new nutrients
            {
                name = "Vitamin C",
                nutrient_id = 401,
                value = "41",
                measures = new measures[1]
            };
            report.foods[0].food.nutrients[18].measures[0] = new measures
            {
                label = "default label vitamin C",
                eqv = 2M,
                value = 1.8M
            };

            report.foods[0].food.nutrients[19] = new nutrients
            {
                name = "Vitamin D",
                nutrient_id = 324,
                value = "42",
                measures = new measures[1]
            };
            report.foods[0].food.nutrients[19].measures[0] = new measures
            {
                label = "default label vitamin D",
                eqv = 2M,
                value = 0.228M
            };

            report.foods[0].food.nutrients[20] = new nutrients
            {
                name = "Saturated Fat",
                nutrient_id = 606,
                value = "42",
                measures = new measures[1]
            };
            report.foods[0].food.nutrients[20].measures[0] = new measures
            {
                label = "default label saturated fat",
                eqv = 2.1M,
                value = 0.230M
            };

            report.foods[0].food.nutrients[21] = new nutrients
            {
                name = "Potassium",
                nutrient_id = 306,
                value = "43",
                measures = new measures[1]
            };
            report.foods[0].food.nutrients[21].measures[0] = new measures
            {
                label = "default label potassium",
                eqv = 2.2M,
                value = 306.2M
            };

            report.foods[0].food.nutrients[22] = new nutrients
            {
                name = "Dietary Fiber",
                nutrient_id = 291,
                value = "44",
                measures = new measures[1]
            };
            report.foods[0].food.nutrients[22].measures[0] = new measures
            {
                label = "default label dietary fiber",
                eqv = 2.3M,
                value = 306.3M
            }; 
        }


        public int FetchedTotalFromSearch { get; set; }
        public string FetchedIngredientsInIngredient { get; set; }

        public async Task<UsdaFoodReport> FetchUsdaFoodReport(string ndbno)
        {
            await Task.Delay(0);
            report.foods[0].food.nutrients[0].measures[0].label = "I am an error";
            if (ndbno == "ShouldReturnIngredients")
            {
                report.foods[0].food.nutrients[0].measures[0].label = "I am a label";
            }
            if (ndbno== "ShouldReturnIngredientsWithPercentageDailyValueTotalFat0")
            {
                report.foods[0].food.nutrients[0].measures[0].value = 0;
            }

            if (ndbno == "ShouldReturnIngredientsWithPercentageDailyValueTotalFat65")
            {
                report.foods[0].food.nutrients[0].measures[0].value = 65;
            }
            if (ndbno == "ShouldReturnIngredientsWithPercentageDailyValueSaturatedFat0")
            {
                report.foods[0].food.nutrients[20].measures[0].value = 0;
            }
            if (ndbno == "ShouldReturnIngredientsWithPercentageDailyValueSaturatedFat20")
            {
                report.foods[0].food.nutrients[20].measures[0].value = 20;
            }
            if (ndbno== "ShouldReturnIngredientsWithPercentageDailyValueCholesterol0")
            {
                report.foods[0].food.nutrients[2].measures[0].value = 0;
            }
            if (ndbno== "ShouldReturnIngredientsWithPercentageDailyValueCholesterol300")
            {
                report.foods[0].food.nutrients[2].measures[0].value = 300;
            }
            if (ndbno== "ShouldReturnIngredientsWithPercentageDailyValueSodium0")
            {
                report.foods[0].food.nutrients[10].measures[0].value = 0;
            }
            if (ndbno == "ShouldReturnIngredientsWithPercentageDailyValueSodium2400")
            {
                report.foods[0].food.nutrients[10].measures[0].value = 2400;
            }
            if (ndbno == "ShouldReturnIngredientsWithPercentageDailyValuePotassium0")
            {
                report.foods[0].food.nutrients[10].measures[0].value = 0;
            }
            if (ndbno== "ShouldReturnIngredientsWithPercentageDailyValuePotassium3500")
            {
                report.foods[0].food.nutrients[10].measures[0].value = 3500;
            }
            if (ndbno== "ShouldReturnIngredientsWithPercentageDailyValueTotalCarbohydrate0")
            {
                report.foods[0].food.nutrients[13].measures[0].value = 0;
            }
            if (ndbno== "ShouldReturnIngredientsWithPercentageDailyValueTotalCarbohydrate300")
            { 
                report.foods[0].food.nutrients[13].measures[0].value = 300;
            }
            if (ndbno== "ShouldReturnIngredientsWithPercentageDailyValueDietaryFiber0")
            {
                report.foods[0].food.nutrients[22].measures[0].value = 0;
            }
            if (ndbno == "ShouldReturnIngredientsWithPercentageDailyValueDietaryFiber25")
            {
                report.foods[0].food.nutrients[22].measures[0].value = 25;
            }
            if (ndbno== "ShouldReturnIngredientsWithPercentageDailyValueVitaminA0")
            {
                report.foods[0].food.nutrients[15].measures[0].value = 0;
            }

            if (ndbno == "ShouldReturnIngredientsWithPercentageDailyValueVitaminA1000")
            {
                report.foods[0].food.nutrients[15].measures[0].value = 1000;
            }
            if (ndbno== "ShouldReturnIngredientsWithPercentageDailyValueVitaminC0")
            {
                report.foods[0].food.nutrients[18].measures[0].value = 0;
            }
            if (ndbno== "ShouldReturnIngredientsWithPercentageDailyValueVitaminC60")
            {
                report.foods[0].food.nutrients[18].measures[0].value = 60;
            }
            if (ndbno== "ShouldReturnIngredientsWithPercentageDailyValueCalcium0")
            {
                report.foods[0].food.nutrients[1].measures[0].value = 0;
            }
            if (ndbno== "ShouldReturnIngredientsWithPercentageDailyValueCalcium1")
            {
                report.foods[0].food.nutrients[1].measures[0].value = 1;
            }
            if (ndbno == "ShouldReturnIngredientsWithPercentageDailyValueIron0")
            {
                report.foods[0].food.nutrients[3].measures[0].value = 0;
            }
            if (ndbno == "ShouldReturnIngredientsWithPercentageDailyValueIron20")
            {
                report.foods[0].food.nutrients[3].measures[0].value = 18;
            }
            if (ndbno==  "ShouldReturnIngredientsWithPercentageDailyValueThiamine0")
            {
                report.foods[0].food.nutrients[12].measures[0].value = 0;
            }
            if (ndbno== "ShouldReturnIngredientsWithPercentageDailyValueThiamine1point5")
            {
                report.foods[0].food.nutrients[12].measures[0].value = 1.5M;
            }
            if (ndbno==  "ShouldReturnIngredientsWithPercentageDailyValueRiboflavin0")
            {
                report.foods[0].food.nutrients[9].measures[0].value = 0;
            }

            if (ndbno == "ManufacturerNotFoodGroup")
            {
                report.foods[0].food.desc.fg = "";
            }
            if (ndbno== "NoManufacturerOrFoodGroup")
            {
                report.foods[0].food.desc.fg = "";
                report.foods[0].food.desc.manu = "";
            }

            return report;
        }

        public Task<UsdaFoodReport> Foo(string testString)
        {
            throw new NotImplementedException("Yowser");
        }

        public Task<List<IIngredient>> GetListOfIngredientsFromTextSearch(string searchString, string dataSource = "")
        {
            throw new NotImplementedException();
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

    }
}

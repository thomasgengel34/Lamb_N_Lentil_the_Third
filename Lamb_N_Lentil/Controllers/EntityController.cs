using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Lamb_N_Lentil.Domain;

namespace Lamb_N_Lentil.UI.Controllers
{
    public class EntityController : Controller
    {
        // GET: Entity
        public ActionResult Index()
        {
            //string searchString = " 076606619663";

            //Task<string> descriptionTask = new EntityAsyncController().GetIngredientsFromDescription
            //      (
            //    searchString,
            //    foodGroup: "",
            //    usdaWebApiDataSource: UsdaWebApiDataSource.BrandedFoodProducts
            //    );
            //string description = descriptionTask.Result.ToString();
            string description = "Salt, Pepper, Egg, Flour, Baking Soda";
            Entity entity = new Entity() { ID = 1, InstanceName = "Trial", IngredientsList = description };
             return View("Index", entity);
        } 
    }
}

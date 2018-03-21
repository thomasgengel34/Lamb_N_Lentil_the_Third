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
            string description = "ground meat, often pork, beef, or veal, along with salt, spices and other flavourings, and breadcrumbs, encased by a skin.";
            Entity entity = new Entity() { ID = 1, InstanceName = "Sausage", IngredientsList = description };
             return View("Index", entity);
        } 
    }
}

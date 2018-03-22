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
        IEntityAsyncController apiController;

            public EntityController()
        {
                 apiController = new EntityAsyncController();
        }

        public EntityController(IEntityAsyncController controller = null)
        {
            if (controller == null)
            {
                apiController = new EntityAsyncController();
            }
            else
            {
                apiController = controller;
            }
        }


        // GET: Entity
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> ShowResults(string searchText)
        {
            // searchText = " 076606619663";

           Entity entity= await apiController.GetIngredientFromSearchText(searchText);
             
            return View(UIType.Index.ToString(), entity);
        }

        public async Task<ActionResult> Details(string searchText)
        {
            Entity entity = await apiController.GetIngredientFromSearchText(searchText); 

          
            return View(UIType.Details.ToString(), entity);
        }
    }
}

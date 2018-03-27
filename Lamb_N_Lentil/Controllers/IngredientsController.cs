using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Lamb_N_Lentil.Domain;
using Lamb_N_Lentil.Domain.UsdaInformation;

namespace Lamb_N_Lentil.UI.Controllers
{
    public class IngredientsController : EntityController
    {
        static IIngredient ingredient;

        public IngredientsController(Controller _controller = null) :base()
        {

        }
        // GET: Ingredients
        public ActionResult Index()
        {
            return View();
        }
         

        public async Task<ActionResult> ShowResults(string searchText)
        {

            List<IIngredient> ingredients = await new UsdaAsync().GetListOfIngredientsFromTextSearch( searchText);

            return View(UIType.Index.ToString(), ingredients);
        }
         
    }
}
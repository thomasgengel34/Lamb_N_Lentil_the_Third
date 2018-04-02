using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Lamb_N_Lentil.Domain;
using Lamb_N_Lentil.Domain.UsdaInformation;
using Lamb_N_Lentil.UI.Models;

namespace Lamb_N_Lentil.UI.Controllers
{
    public class IngredientsController : EntityController
    {
        public IngredientsController()
        {

        }

        public IngredientsController(Controller _controller = null) :base()
        {

        }
        // GET: Ingredients
        public ActionResult Index()
        {
            List<IngredientListViewModel> vm = new List<IngredientListViewModel>();
            ViewBag.SearchText = "Write Your Query Here";
            return View(UIType.Index.ToString(), vm);
        }
         

        public async Task<ActionResult> ShowResults(string searchText)
        { 
           var ingredients = await new UsdaAsync().GetListOfIngredientsFromTextSearch(searchText);
            List<IngredientListViewModel> vm = new List<IngredientListViewModel>();
            foreach (IIngredient ingredient in ingredients)
            {
                vm.Add(IngredientListViewModel.MapIIngredientToIngredientListViewModel(ingredient));
            }

            return View(UIType.Index.ToString(), vm);
        } 
    }
}
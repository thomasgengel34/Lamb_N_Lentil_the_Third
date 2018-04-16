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
        public IUsdaAsync usdaAsync  = new UsdaAsync(); 

        public IngredientsController()
        {
        }

        public IngredientsController(Controller _controller = null) : base()
        {
        }

        public IngredientsController(Controller _controller = null,   IUsdaAsync uSdaAsync=null ) : base()
        {
             usdaAsync = uSdaAsync;
        }

        // GET: Ingredients
        public ActionResult Index()
        {
            List<IngredientListViewModel> vm = new List<IngredientListViewModel>();
            ViewBag.SearchText = "Write Your Query Here";
            return View(UIType.Index.ToString(), vm);
        }


        public async Task<ActionResult> ShowResults(string searchText, UsdaDataSource  databaseSelection = UsdaDataSource.Both)
        {
            
             ViewBag.DatabaseSelection = databaseSelection;
             
          
            var ingredients = await   usdaAsync.GetListOfIngredientsFromTextSearch(searchText, databaseSelection.ToString());
            List<IngredientListViewModel> vm = new List<IngredientListViewModel>();
            foreach (IIngredient ingredient in ingredients)
            {
                vm.Add(IngredientListViewModel.MapIIngredientToIngredientListViewModel(ingredient));
            }

            if (ingredients.Count == 0)
            {
                ViewBag.NoResults = "Nothing was found.  Please try a different search.";
            }
            else
            {
                ViewBag.NoResults = "";
            }
            ViewBag.SearchTotal = usdaAsync.FetchedTotalFromSearch;
            ViewBag.TotalShown = ingredients.Count();

            return View(UIType.Index.ToString(), vm);
        }
    }
}
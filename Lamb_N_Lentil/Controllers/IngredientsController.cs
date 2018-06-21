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

        public IUsdaAsync usdaAsync;
        public IUsdaAsyncFoodReport usdaAsyncFoodReport;


        public IngredientsController()
        {
            usdaAsync = new UsdaAsync(); 
            usdaAsyncFoodReport = new UsdaAsyncFoodReport();
        }

        public IngredientsController(Controller _controller = null) : base()
        {
        }

        public IngredientsController(Controller _controller = null, IUsdaAsync _usdaAsync = null, IUsdaAsyncFoodReport _usdaAsyncFoodReport = null) : base()
        {
            usdaAsync = _usdaAsync;
            usdaAsyncFoodReport = _usdaAsyncFoodReport;
        }

        // GET: Ingredients
        public ActionResult Index()
        {
            List<IngredientListViewModel> vm = new List<IngredientListViewModel>();
            ViewBag.SearchText = "Write Your Query Here";
            ViewBag.SearchTotal = 0;
            ViewBag.TotalShown = 0;
            return View(UIType.Index.ToString(), vm);
        }


        public async Task<ActionResult> ShowResults(string searchText)
        {
            var ingredients = await usdaAsync.GetListOfIngredientsFromTextSearch(searchText);
            List<IngredientListViewModel> vm = new List<IngredientListViewModel>();

            foreach (var ingredient in ingredients)
            {
                vm.Add(IngredientListViewModel.MapIIngredientToIngredientListViewModel(ingredient));
            }


            if (ingredients.Count() == 0)
            {
                ViewBag.NoResults = "Nothing was found.  Please try a different search.";
            }
            else
            {
                ViewBag.NoResults = "";
            }
            
                 ViewBag.SearchTotal = ingredients.Count();
            ViewBag.TotalShown = ingredients.Count();

            return View(UIType.Index.ToString(), vm);
        }

        public async Task<ViewResult> Details(string ndbno)
        {
            var report = await usdaAsyncFoodReport.FetchUsdaFoodReport(ndbno);
            IIngredient ingredient = MapUsdaFoodReportToIIngredient.ConvertUsdaFoodReportToIIngredient(report);
            var vm = IngredientDetailViewModel.MapIIngredientToIngredientDetailViewModel(ingredient);
            return View(UIType.Details.ToString(), vm);
        }
    }
}
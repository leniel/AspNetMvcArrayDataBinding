using AspNetMvcArrayDataBinding.Models;
using System.Web.Mvc;

namespace AspNetMvcArrayDataBinding.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ColorsModel model = new ColorsModel();

            return View(model);
        }

        /// <summary>
        /// This action method works with a simple int[] array that's not part of a ViewModel.
        /// </summary>
        /// <param name="selectedColors">Simple int[] array</param>
        /// <returns>ArrayPostResult view</returns>
        [HttpPost]
        public ActionResult TestArrayPost(int[] selectedColors)
        {
            if (Request.IsAjaxRequest())
            {
                ViewBag.PostBack = "AJAX";

                return PartialView("ArrayPostResult", selectedColors);
            }

            ViewBag.PostBack = "Full";

            return View("ArrayPostResult", selectedColors);
        }

    }
}

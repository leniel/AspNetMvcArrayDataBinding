using AspnetMvcArrayDataBinding.Models;
using System.Web.Mvc;

namespace AspnetMvcArrayDataBinding.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ColorsModel model = new ColorsModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult TestArrayPost(int[] selectedColors)
        {
            if (Request.IsAjaxRequest())
            {
                ViewBag.PostBack = "AJAX";

                return PartialView("ArrayPostResult", selectedColors);
            }

            ViewBag.PostBack = "Traditional";

            return View("ArrayPostResult", selectedColors);
        }

    }
}

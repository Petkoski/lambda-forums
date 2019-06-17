using Microsoft.AspNetCore.Mvc;

namespace LambdaForums.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
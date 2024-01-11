using Microsoft.AspNetCore.Mvc;

namespace MyResume.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

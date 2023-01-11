using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UserapiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

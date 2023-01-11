using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UserapisController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

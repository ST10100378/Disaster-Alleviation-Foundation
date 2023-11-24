using Microsoft.AspNetCore.Mvc;

namespace Disaster_Alleviation_Foundation.Controllers
{
    public class Information : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

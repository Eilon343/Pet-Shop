using Microsoft.AspNetCore.Mvc;

namespace Pet_Shop.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult PageNotFound()
        {
            return View();
        }
        public IActionResult Exception()
        {
            return View();
        }
        public IActionResult UnAuthorized()
        {
            return View();
        }
    }
}

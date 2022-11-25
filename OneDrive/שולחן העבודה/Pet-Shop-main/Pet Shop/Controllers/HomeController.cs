using Microsoft.AspNetCore.Mvc;
using Pet_Shop.Data;
using Pet_Shop.Repositories;

namespace Pet_Shop.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View(_repository.GetPopularAnimals());
        }
    }
}

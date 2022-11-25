using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pet_Shop.Models;
using Pet_Shop.Repositories;

namespace Pet_Shop.Controllers
{
    public class CatalogController : Controller
    {
        private IRepository _repository;
        public CatalogController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index(int id = 0, [FromQuery] int page = 1)
        {
            ViewBag.NumOfAnimals = _repository.GetNumberOfAnimals(id);
            var Categories = _repository.GetCategories();
            ViewBag.Categories = Categories;
            if (id < 0 || id > Categories.Count)
                return RedirectToAction("PageNotFound", "Error");
            return View(_repository.SplitColletion(id, page));
        }

        public IActionResult Details(int id)
        {
            try
            {
                var model = new Tuple<Animal, Comment>(_repository.GetAnimalById(id), new Comment());
                return View(model);
            }
            catch (InvalidOperationException)
            {
                return RedirectToAction("PageNotFound", "Error");
            }
        }
        [Authorize]
        public IActionResult SubmitComment(int animalId, string comment)
        {
            if (comment != null)
            {
                _repository.AddComment(animalId, comment);
                return RedirectToAction("Details", new { id = animalId });
            }
            else
                return RedirectToAction("Details", new { id = animalId });
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pet_Shop.Models;
using Pet_Shop.Repositories;
using System.Diagnostics.Metrics;
using System.Runtime.ExceptionServices;

namespace Pet_Shop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministratorController : Controller
    {
        private IRepository _repository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdministratorController(IRepository repository, IWebHostEnvironment webHostEnvironment)
        {
            _repository = repository;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index(int id = 0, [FromQuery] int page = 1)
        {
            ViewBag.NumOfAnimals = _repository.GetNumberOfAnimals(id);
            var Categories = _repository.GetCategories();
            ViewBag.Categories = Categories;
            if (id < 0 || id > Categories.Count)
                return RedirectToAction("PageNotFound", "Error");
            return View(_repository.SplitColletion(id, page));
        }
        [HttpGet]
        public IActionResult Edit(int animalId)
        {
            try
            {
                return View(_repository.GetAnimalById(animalId));
            }
            catch (InvalidOperationException)
            {
                return RedirectToAction("PageNotFound", "Error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(int animalId, string name, int age, IFormFile Image, string description, int categoryId)
        {
            if (ModelState.IsValid)
            {
                var SaveImg = Path.Combine(_webHostEnvironment.WebRootPath, "Images/Animals", Image.FileName);
                string ImgText = Path.GetExtension(Image.FileName);

                if (ImgText == ".jpg")
                {
                    using (var uploading = new FileStream(SaveImg, FileMode.Create))
                    {
                        await Image.CopyToAsync(uploading);
                    }
                    _repository.UpdateAnimal(animalId, name, age, Image.FileName, description, categoryId);
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = "Only Images with extension .jpg can be uploaded";
                    return View("Edit", _repository.GetAnimalById(animalId));
                }
            }
            return RedirectToAction("Edit", new { animalId = animalId });
        }

        public IActionResult Delete(int animalId)
        {
            try
            {
                _repository.DeleteAnimal(animalId);
                return RedirectToAction("Index");
            }
            catch (InvalidOperationException)
            {
                return RedirectToAction("PageNotFound", "Error");
            }
        }

        public IActionResult AnimalForm()
        {
            return View("Create");
        }
        [HttpPost]
        public async Task<IActionResult> Create(string name, int age, IFormFile Image, string description, int categoryId)
        {
            if (ModelState.IsValid)
            {
                //adding image to the wwwroot folder and checking if its with .jpg extension
                var SaveImg = Path.Combine(_webHostEnvironment.WebRootPath, "Images/Animals", Image.FileName);
                string ImgText = Path.GetExtension(Image.FileName);

                if (ImgText == ".jpg")
                {
                    using (var uplaoding = new FileStream(SaveImg, FileMode.Create))
                    {
                        await Image.CopyToAsync(uplaoding);
                    }
                    _repository.CreateAnimal(name, age, Image.FileName, description, categoryId);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["FileMessage"] = "Only Images with extension .jpg can be uploaded";
                    return View();
                }
            }
            return View();
        }
    }
}

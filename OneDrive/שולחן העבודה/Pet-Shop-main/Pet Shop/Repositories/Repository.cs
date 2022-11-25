using Microsoft.EntityFrameworkCore;
using Pet_Shop.Data;
using Pet_Shop.Models;

namespace Pet_Shop.Repositories
{
    public class Repository : IRepository
    {
        private PetShopContext _context;

        public Repository(PetShopContext context)
        {
            _context = context;
        }
        public Animal GetAnimalById(int id) => _context.Animals!.Include(c => c.Category).ThenInclude(c => c!.Animals!).ThenInclude(c => c.Comments).Single(animal => animal.AnimalId == id);

        public List<Category> GetCategories() => _context.Categories!.ToList();

        public List<Animal> GetPopularAnimals() => _context.Animals!.Include(c => c.Comments).OrderByDescending(c => c.Comments!.Count).Take(2).ToList();

        public void AddComment(int animalId, string comment)
        {
            _context.Animals!.Include(c => c.Category!).ThenInclude(c => c.Animals!).ThenInclude(c => c.Comments!).Single(c => c.AnimalId == animalId).Comments!.Add(new Comment { Text = comment });
            _context.SaveChanges();
        }

        public List<Animal> FilterByCategory(int categoryId)
        {
            return _context.Animals!.Include(c => c.Category).ThenInclude(c => c!.Animals!).ThenInclude(c => c.Comments).Where(c => c.Category!.CategoryId == categoryId).ToList();
        }


        public void UpdateAnimal(int animalId, string name, int age, string pictureName, string description, int categoryId)
        {
            var AnimalToEdit = _context.Animals!.Single(animal => animal.AnimalId == animalId);
            if (categoryId != AnimalToEdit.CategoryId)
                AnimalToEdit.CategoryId = categoryId;
            _context.Animals!.Update(AnimalToEdit);
            AnimalToEdit.Name = name;
            AnimalToEdit.Age = age;
            AnimalToEdit.Description = description;
            AnimalToEdit.PictureName = pictureName;
            _context.SaveChanges();
        }

        public void DeleteAnimal(int animalId)
        {
            var AnimalToRemove = GetAnimalById(animalId);
            _context.Animals!.Remove(AnimalToRemove);
            _context.SaveChanges();
        }

        public void CreateAnimal(string name, int age, string pictureName, string description, int categoryId)
        {
            _context.Add(new Animal
            {
                Name = name,
                Age = age,
                PictureName = pictureName,
                Description = description,
                CategoryId = categoryId
            }
            );
            _context.SaveChanges();
        }

        public List<Animal> SplitColletion(int categoryId, int page)
        {
            //If category id is 0 it means that user choose all animals.
            if (categoryId == 0)
            {
                if (page == 1 || page == 0)
                {
                    return _context.Animals!.Take(6).ToList();
                }
                else
                {
                    return _context.Animals!.Skip((page - 1) * 6).Take(6).ToList();
                }
            }
            //if category id is not 0, filtering the animals by the category id and then doing pagination logic
            else
            {
                var currAnimals = FilterByCategory(categoryId);
                if (page == 1 || page == 0)
                {
                    return currAnimals.Take(6).ToList();
                }
                else
                {
                    return currAnimals.Skip((page - 1) * 6).Take(6).ToList();
                }

            }
        }
        //Getting number of animals for the amount of pages in catalog and admin
        public int GetNumberOfAnimals(int categoryId)
        {
            if (categoryId == 0)
            {
                return _context.Animals!.Count();
            }
            else
            {
                return FilterByCategory(categoryId).Count();
            }
        }
    }

}


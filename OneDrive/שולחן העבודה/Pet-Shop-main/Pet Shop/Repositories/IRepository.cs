using Pet_Shop.Models;

namespace Pet_Shop.Repositories
{
    public interface IRepository
    {
        int GetNumberOfAnimals(int categoryId);
        List<Animal> GetPopularAnimals();
        List<Category> GetCategories();
        List<Animal> FilterByCategory(int categoryId);

        List<Animal> SplitColletion(int categoryId, int page);
        Animal GetAnimalById(int id);
        void AddComment(int animalId, string comment);
        void UpdateAnimal(int animalId, string name, int age, string pictureName, string description, int categoryId);
        void DeleteAnimal(int animalId);
        void CreateAnimal(string name, int age, string pictureName, string description, int categoryId);
    }
}

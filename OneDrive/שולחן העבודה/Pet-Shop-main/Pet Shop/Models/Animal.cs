using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Pet_Shop.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }

        [Required(ErrorMessage = "Please enter animal's name.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter animal's age.")]
        [Range(1, 100, ErrorMessage = "Age must be between 1 - 100")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please upload a picture of the animal.")]
        public string? PictureName { get; set; }

        [Required(ErrorMessage = "Please Write a short description about the animal.")]
        public string? Description { get; set; }

        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please choose a category")]
        public Category? Category { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}

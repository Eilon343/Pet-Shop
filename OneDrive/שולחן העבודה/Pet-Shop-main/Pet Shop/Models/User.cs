using System.ComponentModel.DataAnnotations;

namespace Pet_Shop.Models
{
    public class User
    {
        [Required(ErrorMessage = "Please enter username")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}

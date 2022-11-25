using System.ComponentModel.DataAnnotations;

namespace Pet_Shop.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        [Required(ErrorMessage = "Please enter a comment.")]
        [StringLength(1000)]
        public string? Text { get; set; }
        public int AnimalId { get; set; }
        public Animal? Animal { get; set; }
    }
}

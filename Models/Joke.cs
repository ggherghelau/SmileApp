using System.ComponentModel.DataAnnotations;

namespace Smile.Models 
{
    public class Joke
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string JokeContent { get; set; }
    }
}
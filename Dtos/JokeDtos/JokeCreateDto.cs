using System.ComponentModel.DataAnnotations;

namespace Smile.Dtos.JokeDtos
{
    public class JokeCreateDto
    {
        [Required]
        public char ServType { get; set; }
        [Required]
        public string JokeContent { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Smile.Dtos.JokeDtos
{
    public class JokeUpdateDto
    {
        [Required]
        public char ServType { get; set; }
        [Required]
        public string JokeContent { get; set; }
    }
}
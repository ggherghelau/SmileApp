using System.ComponentModel.DataAnnotations;

namespace Smile.Dtos 
{
    public class JokeCreateDto
    {
        [Required]
        public string JokeContent { get; set; }
    }
}
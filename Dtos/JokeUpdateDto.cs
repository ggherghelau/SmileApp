using System.ComponentModel.DataAnnotations;

namespace Smile.Dtos 
{
    public class JokeUpdateDto
    {
        [Required]
        public string JokeContent { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Smile.Models 
{
    public class Praise
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public char ServType { get; set; }
        [Required]
        public string PraiseContent { get; set; }
    }
}
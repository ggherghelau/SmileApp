using System.ComponentModel.DataAnnotations;

namespace Smile.Models 
{
    public class Cheer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public char ServType { get; set; }
        [Required]
        public string CheerContent { get; set; }
    }
}
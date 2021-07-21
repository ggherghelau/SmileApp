using System;
using System.ComponentModel.DataAnnotations;

namespace Smile.Models 
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string OrderNumber { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
    }
}
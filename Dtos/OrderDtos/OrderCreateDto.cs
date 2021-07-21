using System;
using System.ComponentModel.DataAnnotations;

namespace Smile.Dtos.OrderDtos 
{
    public class OrderCreateDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string OrderNumber { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace Smile.Dtos.OrderDtos 
{
    public class OrderUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string OrderNumber { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
    }
}
using System;

namespace Smile.Dtos.OrderDtos
{
    public class OrderReadDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
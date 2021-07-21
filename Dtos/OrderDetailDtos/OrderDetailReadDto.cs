using System;

namespace Smile.Dtos.OrderDetailDtos
{
    public class OrderDetailReadDto
    {
        public int OrderId { get; set; }
        public string OrderExecDay { get; set; }
        public DateTime OrderExecTime { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace Smile.Models 
{
    public class OrderDetail
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public string OrderExecDay { get; set; }
        [Required]
        public DateTime OrderExecTime { get; set; }
    }
}
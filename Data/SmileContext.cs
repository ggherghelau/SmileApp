using Microsoft.EntityFrameworkCore;
using Smile.Models;
using Microsoft.AspNetCore.Identity;

namespace Smile.Data
{
    public class SmileContext : DbContext
    {
        public SmileContext(DbContextOptions<SmileContext> option) : base(option)
        {

        }

        public DbSet<Joke> Jokes { get; set; }
        public DbSet<Cheer> Cheers { get; set; }
        public DbSet<Praise> Praises { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
    }
}
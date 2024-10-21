using Microsoft.EntityFrameworkCore;
using SurvivorAPI.Models;
using System.Collections.Generic;

namespace SurvivorAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Competitor> Competitors { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}

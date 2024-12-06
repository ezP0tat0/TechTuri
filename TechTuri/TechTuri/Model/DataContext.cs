using Microsoft.EntityFrameworkCore;
using TechTuri.Model.Data;

namespace TechTuri.Model
{
    public class DataContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<img> imgs { get; set; }

        public DataContext(DbContextOptions options) : base(options) 
        {

        }
        
    }
}

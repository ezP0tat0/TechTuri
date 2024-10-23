using Microsoft.EntityFrameworkCore;
using TechTuri.Model.Data;

namespace TechTuri.Model
{
    public class DataContext: DbContext
    {
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ProfilexItem> ProfileItemConnections { get; set; }
        public DbSet<ProfilexReview> ProfileReviewConnections { get; set; }
        public DbSet<Picture> Pictures { get; set; }

        public DataContext(DbContextOptions options) : base(options) 
        {

        }
        
    }
}

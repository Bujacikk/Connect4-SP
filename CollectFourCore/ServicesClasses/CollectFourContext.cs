using CollectFour;
using Microsoft.EntityFrameworkCore;

namespace CollectFourCore.ServicesClasses
{
        public class CollectFourContext : DbContext
        {
        public DbSet<Player> Scores { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Connect4;Trusted_Connection=True;");
            }
        }

}
using GraphQLProject.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLProject.Data
{
    public class GraphQLDbContext : DbContext
    {
        public GraphQLDbContext(DbContextOptions<GraphQLDbContext> options)
            : base(options)
        {
        }

        public DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Menu>().HasData(
                new Menu() { Description = "Cheese Pizza", Id = 1, Name = "Pizza", Price = (double)10.99M },
                new Menu() { Description = "Veggie Pizza", Id = 2, Name = "Pizza", Price = (double)12.99M },
                new Menu() { Description = "Pepperoni Pizza", Id = 3, Name = "Pizza", Price = (double)14.99M },
                new Menu() { Description = "Chicken Pizza", Id = 4, Name = "Pizza", Price = (double)16.99M },
                new Menu() { Description = "Margherita Pizza", Id = 5, Name = "Pizza", Price = (double)11.99M }
                );

        }
    }
}


using foodapp.Models;
using Microsoft.EntityFrameworkCore;

namespace foodapp.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> optiions):base(optiions) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredient>().HasKey(pi => new
            {
                pi.DishId,
                pi.ingredientId

            });
          
            modelBuilder.Entity<DishIngredient>().HasOne(d=>d.Dish).WithMany(di=>di.DishIngredients).HasForeignKey(pi => pi.DishId);
            modelBuilder.Entity<DishIngredient>().HasOne(i=>i.ingredient).WithMany(di=>di.DishIngredients).HasForeignKey(pi => pi.ingredientId);
            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id = 1, Name = "Pizza", price = 70.5, ImageURl = "www.some.com" }

                );
            modelBuilder.Entity<ingredient>().HasData(
            new ingredient { Id = 1, Name = "Tomato Sause" },
            new ingredient { Id = 2, Name = "Cheese" }


            );
            modelBuilder.Entity<DishIngredient>().HasData(

                new DishIngredient { DishId =1,ingredientId=1},
                new DishIngredient { DishId = 1, ingredientId = 2 }



                );

            base.OnModelCreating(modelBuilder);
        }
         public DbSet<Dish> Dishes { get; set; }
        public DbSet<ingredient> ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }

    }
}

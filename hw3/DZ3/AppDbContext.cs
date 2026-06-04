using Microsoft.EntityFrameworkCore;
using DZ3.Models;

namespace DZ3
{
    public class AppDbContext : DbContext
    {
        // Таблица ресторанов
        public DbSet<Restaurant> Restaurants { get; set; }
        // Таблица блюд
        public DbSet<Dish> Dishes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Указываем, что используем SQLite и задаем имя файла БД
            optionsBuilder.UseSqlite("Data Source=restaurants_app.db");
        }
    }
}
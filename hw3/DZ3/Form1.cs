using DZ3.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DZ3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeDatabase(); // Создаем БД при старте
        }

        private void InitializeDatabase()
        {
            using var db = new AppDbContext();

            // Создает файл базы данных, если его еще нет
            db.Database.EnsureCreated();

            // Проверяем, есть ли уже данные. Если нет — добавляем стартовые
            if (!db.Restaurants.Any())
            {
                var rest1 = new Restaurant { Name = "Итальянский дворик" };
                var rest2 = new Restaurant { Name = "Бургерная на углу" };
                var rest3 = new Restaurant { Name = "Токио Суши" };
                var rest4 = new Restaurant { Name = "Вегетарианское кафе" };

                db.Restaurants.AddRange(rest1, rest2, rest3, rest4);
                db.SaveChanges(); // Сохраняем, чтобы получить ID

                db.Dishes.AddRange(
                    new Dish { Name = "Паста Карбонара", Price = 450, RestaurantId = rest1.Id },
                    new Dish { Name = "Пицца Маргарита", Price = 550, RestaurantId = rest1.Id },
                    new Dish { Name = "Тирамису", Price = 300, RestaurantId = rest1.Id },

                    new Dish { Name = "Чизбургер", Price = 350, RestaurantId = rest2.Id },
                    new Dish { Name = "Картофель фри", Price = 150, RestaurantId = rest2.Id },
                    new Dish { Name = "Молочный коктейль", Price = 200, RestaurantId = rest2.Id },

                    new Dish { Name = "Филадельфия", Price = 600, RestaurantId = rest3.Id },
                    new Dish { Name = "Калифорния", Price = 500, RestaurantId = rest3.Id },
                    new Dish { Name = "Мисо суп", Price = 250, RestaurantId = rest3.Id },

                    new Dish { Name = "Салат с киноа", Price = 400, RestaurantId = rest4.Id },
                    new Dish { Name = "Овощной крем-суп", Price = 350, RestaurantId = rest4.Id },
                    new Dish { Name = "Смузи", Price = 280, RestaurantId = rest4.Id }
                );

                db.SaveChanges();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр новой формы
            var restaurantsForm = new RestaurantsForm();
            // Показываем её поверх текущего окна
            restaurantsForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e) // Имя метода может чуть отличаться
        {
            var dishesForm = new DishesForm();
            dishesForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e) // Имя метода может чуть отличаться
        {
            var reportsForm = new ReportsForm();
            reportsForm.ShowDialog();
        }
    }
}
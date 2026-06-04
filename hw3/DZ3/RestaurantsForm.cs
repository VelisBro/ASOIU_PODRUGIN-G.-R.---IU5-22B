using DZ3.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DZ3
{
    public partial class RestaurantsForm : Form
    {
        // Создаем переменную для работы с базой данных
        private AppDbContext _db;

        public RestaurantsForm()
        {
            InitializeComponent();
            _db = new AppDbContext(); // Инициализируем подключение
        }

        // Этот метод срабатывает при открытии окна
        private void RestaurantsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // Отдельный метод для загрузки/обновления данных в таблице
        private void LoadData()
        {
            // Берем все рестораны из БД и отдаем их таблице
            dataGridViewRestaurants.DataSource = _db.Restaurants.ToList();

            // Прячем колонку "Dishes", так как это системная связь, а не текст для вывода
            if (dataGridViewRestaurants.Columns["Dishes"] != null)
            {
                dataGridViewRestaurants.Columns["Dishes"].Visible = false;
            }

            // Немного красоты: растягиваем столбец Name на всю ширину
            if (dataGridViewRestaurants.Columns["Name"] != null)
            {
                dataGridViewRestaurants.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridViewRestaurants.Columns["Name"].HeaderText = "Название ресторана";
            }
            if (dataGridViewRestaurants.Columns["Id"] != null)
            {
                dataGridViewRestaurants.Columns["Id"].HeaderText = "ID";
                dataGridViewRestaurants.Columns["Id"].Width = 50;
            }
        }

        // Важно: закрываем подключение к БД, когда закрываем окно
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _db?.Dispose();
            base.OnFormClosed(e);
        }

        // Двойной клик по кнопке "Добавить"
        private void button1_Click(object sender, EventArgs e) // Название метода может отличаться, если ты переименовывал кнопку
        {
            using var form = new RestaurantEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var newRestaurant = new Models.Restaurant { Name = form.RestaurantName };
                _db.Restaurants.Add(newRestaurant); // LINQ to Entities: Добавление
                _db.SaveChanges();
                LoadData(); // Обновляем таблицу на экране
            }
        }

        // Двойной клик по кнопке "Редактировать"
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridViewRestaurants.CurrentRow == null) return; // Проверка, что строка выбрана

            // Получаем ID выбранного ресторана из таблицы
            int id = (int)dataGridViewRestaurants.CurrentRow.Cells["Id"].Value;
            var restaurant = _db.Restaurants.Find(id); // LINQ: Поиск по ID

            using var form = new RestaurantEditForm(restaurant.Name); // Передаем старое имя
            if (form.ShowDialog() == DialogResult.OK)
            {
                restaurant.Name = form.RestaurantName;
                _db.SaveChanges(); // LINQ: Обновление
                LoadData();
            }
        }

        // Двойной клик по кнопке "Удалить"
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridViewRestaurants.CurrentRow == null) return;

            int id = (int)dataGridViewRestaurants.CurrentRow.Cells["Id"].Value;
            var restaurant = _db.Restaurants.Find(id);

            // Обязательная проверка: есть ли связанные блюда
            bool hasDishes = _db.Dishes.Any(d => d.RestaurantId == id);
            if (hasDishes)
            {
                MessageBox.Show("Нельзя удалить ресторан, пока в нем есть блюда!", "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Запрос подтверждения перед удалением
            if (MessageBox.Show($"Удалить ресторан '{restaurant.Name}'?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _db.Restaurants.Remove(restaurant); // LINQ: Удаление
                _db.SaveChanges();
                LoadData();
            }
        }
    }
}
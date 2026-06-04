using DZ3.Models;
using Microsoft.EntityFrameworkCore; // Обязательно для использования Include
using System;
using System.Linq;
using System.Windows.Forms;

namespace DZ3
{
    public partial class DishesForm : Form
    {
        private AppDbContext _db;

        public DishesForm()
        {
            InitializeComponent();
            _db = new AppDbContext();
        }

        private void DishesForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            // Берем блюда, подгружаем к ним рестораны и формируем красивый список для таблицы
            var dishes = _db.Dishes
                .Include(d => d.Restaurant) // Требование из методички: Include
                .OrderBy(d => d.Name)
                .Select(d => new
                {
                    d.Id,
                    RestaurantName = d.Restaurant!.Name, // Берем имя ресторана
                    d.Name,
                    d.Price
                })
                .ToList();

            dataGridViewDishes.DataSource = dishes;

            // Наводим красоту в столбцах
            if (dataGridViewDishes.Columns["Id"] != null)
            {
                dataGridViewDishes.Columns["Id"].HeaderText = "ID";
                dataGridViewDishes.Columns["Id"].Width = 40;
            }
            if (dataGridViewDishes.Columns["RestaurantName"] != null)
            {
                dataGridViewDishes.Columns["RestaurantName"].HeaderText = "Ресторан";
                dataGridViewDishes.Columns["RestaurantName"].Width = 150;
            }
            if (dataGridViewDishes.Columns["Name"] != null)
            {
                dataGridViewDishes.Columns["Name"].HeaderText = "Блюдо";
                dataGridViewDishes.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (dataGridViewDishes.Columns["Price"] != null)
            {
                dataGridViewDishes.Columns["Price"].HeaderText = "Цена (руб.)";
                dataGridViewDishes.Columns["Price"].Width = 80;
            }
        }
        
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _db?.Dispose();
            base.OnFormClosed(e);
        }

        // Этот метод создался для кнопки "Добавить"
        private void button1_Click_1(object sender, EventArgs e)
        {
            using var form = new DishEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var newDish = new Dish
                {
                    Name = form.DishName,
                    Price = form.DishPrice,
                    RestaurantId = form.SelectedRestaurantId
                };
                _db.Dishes.Add(newDish);
                _db.SaveChanges();
                LoadData(); // Обновляем таблицу
            }
        }

        // Этот метод создался для кнопки "Редактировать"
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewDishes.CurrentRow == null) return;

            int id = (int)dataGridViewDishes.CurrentRow.Cells["Id"].Value;
            var dish = _db.Dishes.Find(id);

            // Передаем в форму текущие данные блюда
            using var form = new DishEditForm(dish.RestaurantId, dish.Name, dish.Price);
            if (form.ShowDialog() == DialogResult.OK)
            {
                dish.Name = form.DishName;
                dish.Price = form.DishPrice;
                dish.RestaurantId = form.SelectedRestaurantId;

                _db.SaveChanges();
                LoadData();
            }
        }

        // Этот метод создался для кнопки "Удалить"
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewDishes.CurrentRow == null) return;

            int id = (int)dataGridViewDishes.CurrentRow.Cells["Id"].Value;
            var dish = _db.Dishes.Find(id);

            if (MessageBox.Show($"Удалить блюдо '{dish.Name}'?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _db.Dishes.Remove(dish);
                _db.SaveChanges();
                LoadData();
            }
        }
    }
}
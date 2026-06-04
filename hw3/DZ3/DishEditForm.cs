using DZ3.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DZ3
{
    public partial class DishEditForm : Form
    {
        public string DishName { get; private set; } = "";
        public int DishPrice { get; private set; }
        public int SelectedRestaurantId { get; private set; }

        public DishEditForm(int? restaurantId = null, string name = "", int price = 0)
        {
            InitializeComponent();

            // Загружаем рестораны в выпадающий список
            using var db = new AppDbContext();
            comboBoxRestaurant.DataSource = db.Restaurants.OrderBy(r => r.Name).ToList();
            comboBoxRestaurant.DisplayMember = "Name"; // То, что видит пользователь
            comboBoxRestaurant.ValueMember = "Id";     // ID, который уходит в базу

            // Если это редактирование, подставляем текущие значения
            if (restaurantId.HasValue)
                comboBoxRestaurant.SelectedValue = restaurantId.Value;

            textBoxName.Text = name;
            textBoxPrice.Text = price > 0 ? price.ToString() : "";

            // Привязываем кнопки
            buttonOk.Click += buttonOk_Click;
            buttonCancel.Click += buttonCancel_Click;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Введите название блюда!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Валидация цены: не отрицательная и целое число
            if (!int.TryParse(textBoxPrice.Text, out int price) || price < 0)
            {
                MessageBox.Show("Цена должна быть положительным целым числом!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DishName = textBoxName.Text.Trim();
            DishPrice = price;
            SelectedRestaurantId = (int)comboBoxRestaurant.SelectedValue;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        
    }
}
using System;

namespace DZ3.Models
{
    /// <summary>
    /// Блюдо в меню (основная таблица, сторона «много»)
    /// </summary>
    public class Dish
    {
        /// <summary>Идентификатор блюда (первичный ключ)</summary>
        public int Id { get; set; }

        /// <summary>Идентификатор ресторана (внешний ключ)</summary>
        public int RestaurantId { get; set; }

        /// <summary>Навигационное свойство: ресторан, к которому относится блюдо</summary>
        public Restaurant? Restaurant { get; set; }

        /// <summary>Название блюда</summary>
        public string Name { get; set; } = "";

        private int _price;

        /// <summary>Цена блюда (не может быть отрицательной)</summary>
        public int Price
        {
            get => _price;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Цена блюда не может быть отрицательной.");
                _price = value;
            }
        }
    }
}
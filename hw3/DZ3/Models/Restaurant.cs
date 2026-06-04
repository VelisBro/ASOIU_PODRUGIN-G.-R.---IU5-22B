using System.Collections.Generic;

namespace DZ3.Models
{
    /// <summary>
    /// Ресторан (справочная таблица, сторона «один»)
    /// </summary>
    public class Restaurant
    {
        /// <summary>Идентификатор ресторана (первичный ключ)</summary>
        public int Id { get; set; }

        /// <summary>Название ресторана</summary>
        public string Name { get; set; } = "";

        /// <summary>Навигационное свойство: блюда в меню этого ресторана</summary>
        public ICollection<Dish> Dishes { get; set; } = new List<Dish>();

        // Переопределяем ToString, чтобы в списках отображалось имя, а не системный тип
        public override string ToString()
        {
            return Name;
        }
    }
}
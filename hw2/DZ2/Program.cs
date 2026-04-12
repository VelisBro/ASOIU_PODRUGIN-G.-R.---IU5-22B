using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

// Пути к файлам
string dbPath = "restaurants.db";
string restaurantsCsv = Path.Combine(AppContext.BaseDirectory, "restaurants.csv");
string dishesCsv = Path.Combine(AppContext.BaseDirectory, "dishes.csv");

// Создание и инициализация БД
var db = new DatabaseManager(dbPath);
db.InitializeDatabase(restaurantsCsv, dishesCsv);

Console.WriteLine();

string choice;
do
{
    Console.WriteLine("╔══════════════════════════════════════════════╗");
    Console.WriteLine("║ УПРАВЛЕНИЕ БЛЮДАМИ В РЕСТОРАНАХ             ║");
    Console.WriteLine("╠══════════════════════════════════════════════╣");
    Console.WriteLine("║ 1 — Показать все рестораны                  ║");
    Console.WriteLine("║ 2 — Показать все блюда                      ║");
    Console.WriteLine("║ 3 — Добавить блюдо                          ║");
    Console.WriteLine("║ 4 — Редактировать блюдо                     ║");
    Console.WriteLine("║ 5 — Удалить блюдо                           ║");
    Console.WriteLine("║ 6 — Отчёты                                  ║");
    Console.WriteLine("║ 7 — Экспорт в CSV                           ║");
    Console.WriteLine("║ 0 — Выход                                   ║");
    Console.WriteLine("╚══════════════════════════════════════════════╝");
    Console.Write("Ваш выбор: ");
    choice = Console.ReadLine()?.Trim() ?? "";
    Console.WriteLine();

    switch (choice)
    {
        case "1":
            ShowRestaurants(db);
            break;
        case "2":
            ShowDishes(db);
            break;
        case "3":
            AddDish(db);
            break;
        case "4":
            EditDish(db);
            break;
        case "5":
            DeleteDish(db);
            break;
        case "6":
            ReportsMenu(db);
            break;
        case "7":
            ExportCsv(db);
            break;
        case "0":
            Console.WriteLine("До свидания!");
            break;
        default:
            Console.WriteLine("Неверный пункт меню.");
            break;
    }

    Console.WriteLine();
}
while (choice != "0");

static void ShowRestaurants(DatabaseManager db)
{
    Console.WriteLine("--- Все рестораны ---");
    var restaurants = db.GetAllRestaurants();
    foreach (var restaurant in restaurants)
        Console.WriteLine(" " + restaurant);
    Console.WriteLine($"Итого: {restaurants.Count}");
}

static void ShowDishes(DatabaseManager db)
{
    Console.WriteLine("--- Все блюда ---");
    var dishes = db.GetAllMenuDishes();
    foreach (var dish in dishes)
        Console.WriteLine(" " + dish);
    Console.WriteLine($"Итого: {dishes.Count}");
}

static void AddDish(DatabaseManager db)
{
    try
    {
        Console.WriteLine("--- Добавление блюда ---");
        Console.WriteLine("Доступные рестораны:");

        var restaurants = db.GetAllRestaurants();
        foreach (var restaurant in restaurants)
            Console.WriteLine(" " + restaurant);

        Console.Write("ID ресторана: ");
        if (!int.TryParse(Console.ReadLine(), out int restaurantId))
        {
            Console.WriteLine("Ошибка: введите целое число.");
            return;
        }

        Console.Write("Название блюда: ");
        string name = Console.ReadLine()?.Trim() ?? "";
        if (name.Length == 0)
        {
            Console.WriteLine("Ошибка: название не может быть пустым.");
            return;
        }

        Console.Write("Цена блюда: ");
        if (!int.TryParse(Console.ReadLine(), out int price))
        {
            Console.WriteLine("Ошибка: введите целое число.");
            return;
        }

        var dish = new MenuDish(0, restaurantId, name, price);
        db.AddMenuDish(dish);
        Console.WriteLine("Блюдо добавлено.");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
    }
}

static void EditDish(DatabaseManager db)
{
    try
    {
        Console.WriteLine("--- Редактирование блюда ---");
        Console.Write("Введите ID блюда: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Ошибка: введите целое число.");
            return;
        }

        var dish = db.GetMenuDishById(id);
        if (dish == null)
        {
            Console.WriteLine($"Блюдо с ID={id} не найдено.");
            return;
        }

        Console.WriteLine($"Текущие данные: {dish}");
        Console.WriteLine("(Нажмите Enter, чтобы оставить значение без изменений)");

        Console.Write($"Название [{dish.Name}]: ");
        string input = Console.ReadLine()?.Trim() ?? "";
        if (input.Length > 0)
            dish.Name = input;

        Console.Write($"ID ресторана [{dish.RestaurantId}]: ");
        input = Console.ReadLine()?.Trim() ?? "";
        if (input.Length > 0)
        {
            if (int.TryParse(input, out int newRestaurantId))
                dish.RestaurantId = newRestaurantId;
            else
            {
                Console.WriteLine("Ошибка: ID ресторана должен быть целым числом.");
                return;
            }
        }

        Console.Write($"Цена [{dish.Price}]: ");
        input = Console.ReadLine()?.Trim() ?? "";
        if (input.Length > 0)
        {
            if (int.TryParse(input, out int newPrice))
                dish.Price = newPrice;
            else
            {
                Console.WriteLine("Ошибка: цена должна быть целым числом.");
                return;
            }
        }

        db.UpdateMenuDish(dish);
        Console.WriteLine("Данные обновлены.");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
    }
}

static void DeleteDish(DatabaseManager db)
{
    try
    {
        Console.WriteLine("--- Удаление блюда ---");
        Console.Write("Введите ID блюда: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Ошибка: введите целое число.");
            return;
        }

        var dish = db.GetMenuDishById(id);
        if (dish == null)
        {
            Console.WriteLine($"Блюдо с ID={id} не найдено.");
            return;
        }

        Console.Write($"Удалить «{dish.Name}»? (да/нет): ");
        string confirm = Console.ReadLine()?.Trim().ToLower() ?? "";

        if (confirm == "да")
        {
            db.DeleteMenuDish(id);
            Console.WriteLine("Блюдо удалено.");
        }
        else
        {
            Console.WriteLine("Удаление отменено.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
    }
}

static void ReportsMenu(DatabaseManager db)
{
    string choice;
    do
    {
        Console.WriteLine("--- Отчёты ---");
        Console.WriteLine(" 1 — Полный список блюд с ресторанами");
        Console.WriteLine(" 2 — Количество блюд в каждом ресторане");
        Console.WriteLine(" 3 — Средняя цена блюд по ресторанам");
        Console.WriteLine(" 4 — Сохранить отчёт 1 в файл");
        Console.WriteLine(" 5 — Сохранить отчёт 2 в файл");
        Console.WriteLine(" 6 — Сохранить отчёт 3 в файл");
        Console.WriteLine(" 0 — Назад");
        Console.Write("Ваш выбор: ");
        choice = Console.ReadLine()?.Trim() ?? "";
        Console.WriteLine();

        switch (choice)
        {
            case "1":
                Report1_DishesWithRestaurants(db);
                break;
            case "2":
                Report2_CountByRestaurant(db);
                break;
            case "3":
                Report3_AvgPriceByRestaurant(db);
                break;
            case "4":
                SaveReport1ToFile(db);
                break;
            case "5":
                SaveReport2ToFile(db);
                break;
            case "6":
                SaveReport3ToFile(db);
                break;
            case "0":
                break;
            default:
                Console.WriteLine("Неверный пункт.");
                break;
        }

        Console.WriteLine();
    }
    while (choice != "0");
}

static void Report1_DishesWithRestaurants(DatabaseManager db)
{
    new ReportBuilder(db)
        .Query(@"
SELECT d.dish_name, r.restaurant_name, d.price
FROM dishes d
JOIN restaurants r ON d.restaurant_id = r.restaurant_id
ORDER BY d.dish_name")
        .Title("Блюда по ресторанам")
        .Header("Блюдо", "Ресторан", "Цена")
        .ColumnWidths(25, 25, 10)
        .Print();
}

static void Report2_CountByRestaurant(DatabaseManager db)
{
    new ReportBuilder(db)
        .Query(@"
SELECT r.restaurant_name, COUNT(*) AS cnt
FROM dishes d
JOIN restaurants r ON d.restaurant_id = r.restaurant_id
GROUP BY r.restaurant_name
ORDER BY r.restaurant_name")
        .Title("Количество блюд по ресторанам")
        .Header("Ресторан", "Кол-во блюд")
        .ColumnWidths(25, 15)
        .Print();
}

static void Report3_AvgPriceByRestaurant(DatabaseManager db)
{
    new ReportBuilder(db)
        .Query(@"
SELECT r.restaurant_name, ROUND(AVG(d.price), 1) AS avg_price
FROM dishes d
JOIN restaurants r ON d.restaurant_id = r.restaurant_id
GROUP BY r.restaurant_name
ORDER BY avg_price DESC")
        .Title("Средняя цена блюд по ресторанам")
        .Header("Ресторан", "Средняя цена")
        .ColumnWidths(25, 15)
        .Print();
}

static void SaveReport1ToFile(DatabaseManager db)
{
    string path = Path.Combine(AppContext.BaseDirectory, "report1.txt");

    new ReportBuilder(db)
        .Query(@"
SELECT d.dish_name, r.restaurant_name, d.price
FROM dishes d
JOIN restaurants r ON d.restaurant_id = r.restaurant_id
ORDER BY d.dish_name")
        .Title("Блюда по ресторанам")
        .Header("Блюдо", "Ресторан", "Цена")
        .ColumnWidths(25, 25, 10)
        .SaveToFile(path);
}

static void SaveReport2ToFile(DatabaseManager db)
{
    string path = Path.Combine(AppContext.BaseDirectory, "report2.txt");

    new ReportBuilder(db)
        .Query(@"
SELECT r.restaurant_name, COUNT(*) AS cnt
FROM dishes d
JOIN restaurants r ON d.restaurant_id = r.restaurant_id
GROUP BY r.restaurant_name
ORDER BY r.restaurant_name")
        .Title("Количество блюд по ресторанам")
        .Header("Ресторан", "Кол-во блюд")
        .ColumnWidths(25, 15)
        .SaveToFile(path);
}

static void SaveReport3ToFile(DatabaseManager db)
{
    string path = Path.Combine(AppContext.BaseDirectory, "report3.txt");

    new ReportBuilder(db)
        .Query(@"
SELECT r.restaurant_name, ROUND(AVG(d.price), 1) AS avg_price
FROM dishes d
JOIN restaurants r ON d.restaurant_id = r.restaurant_id
GROUP BY r.restaurant_name
ORDER BY avg_price DESC")
        .Title("Средняя цена блюд по ресторанам")
        .Header("Ресторан", "Средняя цена")
        .ColumnWidths(25, 15)
        .SaveToFile(path);
}

static void ExportCsv(DatabaseManager db)
{
    string restaurantsPath = Path.Combine(AppContext.BaseDirectory, "restaurants_export.csv");
    string dishesPath = Path.Combine(AppContext.BaseDirectory, "dishes_export.csv");

    db.ExportToCsv(restaurantsPath, dishesPath);

    Console.WriteLine($"Рестораны экспортированы в: {restaurantsPath}");
    Console.WriteLine($"Блюда экспортированы в: {dishesPath}");
}
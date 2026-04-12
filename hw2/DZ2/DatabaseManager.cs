using Microsoft.Data.Sqlite;

/// <summary>
/// Управление базой данных SQLite.
/// Инкапсулирует создание таблиц, импорт CSV,
/// CRUD-операции и выполнение запросов для отчётов.
/// </summary>
class DatabaseManager
{
    private string _connectionString;

    /// <summary>
    /// Конструктор. Принимает путь к файлу базы данных.
    /// </summary>
    public DatabaseManager(string dbPath)
    {
        _connectionString = $"Data Source={dbPath}";
    }

    // ──────────── Инициализация ────────────

    /// <summary>
    /// Создаёт таблицы и загружает данные из CSV при первом запуске.
    /// </summary>
    public void InitializeDatabase(string restaurantCsvPath, string dishCsvPath)
    {
        CreateTables();

        if (GetAllRestaurants().Count == 0 && File.Exists(restaurantCsvPath))
        {
            ImportRestaurantsFromCsv(restaurantCsvPath);
            Console.WriteLine($"[OK] Загружены рестораны из {restaurantCsvPath}");
        }

        if (GetAllMenuDishes().Count == 0 && File.Exists(dishCsvPath))
        {
            ImportMenuDishesFromCsv(dishCsvPath);
            Console.WriteLine($"[OK] Загружены блюда из {dishCsvPath}");
        }
    }

    /// <summary>
    /// Создание таблиц.
    /// </summary>
    private void CreateTables()
    {
        using var conn = new SqliteConnection(_connectionString);
        conn.Open();

        var cmd = conn.CreateCommand();
        cmd.CommandText = @"
CREATE TABLE IF NOT EXISTS restaurants (
    restaurant_id INTEGER PRIMARY KEY AUTOINCREMENT,
    restaurant_name TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS dishes (
    dish_id INTEGER PRIMARY KEY AUTOINCREMENT,
    restaurant_id INTEGER NOT NULL,
    dish_name TEXT NOT NULL,
    price INTEGER NOT NULL,
    FOREIGN KEY (restaurant_id) REFERENCES restaurants(restaurant_id)
);";
        cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// Импорт ресторанов из CSV.
    /// </summary>
    private void ImportRestaurantsFromCsv(string path)
    {
        using var conn = new SqliteConnection(_connectionString);
        conn.Open();

        string[] lines = File.ReadAllLines(path);
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(';');
            if (parts.Length < 2)
                continue;

            var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO restaurants (restaurant_id, restaurant_name) VALUES (@id, @name)";
            cmd.Parameters.AddWithValue("@id", int.Parse(parts[0]));
            cmd.Parameters.AddWithValue("@name", parts[1]);
            cmd.ExecuteNonQuery();
        }
    }

    /// <summary>
    /// Импорт блюд из CSV.
    /// </summary>
    private void ImportMenuDishesFromCsv(string path)
    {
        using var conn = new SqliteConnection(_connectionString);
        conn.Open();

        string[] lines = File.ReadAllLines(path);
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(';');
            if (parts.Length < 4)
                continue;

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
INSERT INTO dishes (dish_id, restaurant_id, dish_name, price)
VALUES (@id, @restaurantId, @name, @price)";
            cmd.Parameters.AddWithValue("@id", int.Parse(parts[0]));
            cmd.Parameters.AddWithValue("@restaurantId", int.Parse(parts[1]));
            cmd.Parameters.AddWithValue("@name", parts[2]);
            cmd.Parameters.AddWithValue("@price", int.Parse(parts[3]));
            cmd.ExecuteNonQuery();
        }
    }

    // ──────────── Чтение данных ────────────

    /// <summary>
    /// Получить все рестораны.
    /// </summary>
    public List<Restaurant> GetAllRestaurants()
    {
        var result = new List<Restaurant>();

        using var conn = new SqliteConnection(_connectionString);
        conn.Open();

        var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT restaurant_id, restaurant_name FROM restaurants ORDER BY restaurant_id";

        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new Restaurant(
                reader.GetInt32(0),
                reader.GetString(1)));
        }

        return result;
    }

    /// <summary>
    /// Получить все блюда.
    /// </summary>
    public List<MenuDish> GetAllMenuDishes()
    {
        var result = new List<MenuDish>();

        using var conn = new SqliteConnection(_connectionString);
        conn.Open();

        var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT dish_id, restaurant_id, dish_name, price FROM dishes ORDER BY dish_id";

        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new MenuDish(
                reader.GetInt32(0),
                reader.GetInt32(1),
                reader.GetString(2),
                reader.GetInt32(3)));
        }

        return result;
    }

    /// <summary>
    /// Получить блюдо по Id.
    /// </summary>
    public MenuDish? GetMenuDishById(int id)
    {
        using var conn = new SqliteConnection(_connectionString);
        conn.Open();

        var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT dish_id, restaurant_id, dish_name, price FROM dishes WHERE dish_id = @id";
        cmd.Parameters.AddWithValue("@id", id);

        using var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            return new MenuDish(
                reader.GetInt32(0),
                reader.GetInt32(1),
                reader.GetString(2),
                reader.GetInt32(3));
        }

        return null;
    }

    // ──────────── Изменение данных ────────────

    /// <summary>
    /// Добавить блюдо (Id генерируется автоматически).
    /// </summary>
    public void AddMenuDish(MenuDish dish)
    {
        using var conn = new SqliteConnection(_connectionString);
        conn.Open();

        var cmd = conn.CreateCommand();
        cmd.CommandText = @"
INSERT INTO dishes (restaurant_id, dish_name, price)
VALUES (@restaurantId, @name, @price)";
        cmd.Parameters.AddWithValue("@restaurantId", dish.RestaurantId);
        cmd.Parameters.AddWithValue("@name", dish.Name);
        cmd.Parameters.AddWithValue("@price", dish.Price);
        cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// Обновить блюдо по Id.
    /// </summary>
    public void UpdateMenuDish(MenuDish dish)
    {
        using var conn = new SqliteConnection(_connectionString);
        conn.Open();

        var cmd = conn.CreateCommand();
        cmd.CommandText = @"
UPDATE dishes
SET restaurant_id = @restaurantId,
    dish_name = @name,
    price = @price
WHERE dish_id = @id";
        cmd.Parameters.AddWithValue("@id", dish.Id);
        cmd.Parameters.AddWithValue("@restaurantId", dish.RestaurantId);
        cmd.Parameters.AddWithValue("@name", dish.Name);
        cmd.Parameters.AddWithValue("@price", dish.Price);
        cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// Удалить блюдо по Id.
    /// </summary>
    public void DeleteMenuDish(int id)
    {
        using var conn = new SqliteConnection(_connectionString);
        conn.Open();

        var cmd = conn.CreateCommand();
        cmd.CommandText = "DELETE FROM dishes WHERE dish_id = @id";
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }

    // ──────────── Выполнение произвольного запроса ────────────

    /// <summary>
    /// Выполняет SQL-запрос и возвращает названия столбцов и строки результата.
    /// Используется ReportBuilder.
    /// </summary>
    public (string[] columns, List<string[]> rows) ExecuteQuery(string sql)
    {
        using var conn = new SqliteConnection(_connectionString);
        conn.Open();

        var cmd = conn.CreateCommand();
        cmd.CommandText = sql;

        using var reader = cmd.ExecuteReader();

        string[] columns = new string[reader.FieldCount];
        for (int i = 0; i < reader.FieldCount; i++)
            columns[i] = reader.GetName(i);

        var rows = new List<string[]>();
        while (reader.Read())
        {
            string[] row = new string[reader.FieldCount];
            for (int i = 0; i < reader.FieldCount; i++)
                row[i] = reader.GetValue(i)?.ToString() ?? "";

            rows.Add(row);
        }

        return (columns, rows);
    }

    // ──────────── Экспорт в CSV [дополнительно] ────────────

    /// <summary>
    /// Экспортирует обе таблицы в CSV-файлы.
    /// </summary>
    public void ExportToCsv(string restaurantsPath, string dishesPath)
    {
        var restaurantLines = new List<string>();
        restaurantLines.Add("restaurant_id;restaurant_name");
        foreach (var restaurant in GetAllRestaurants())
            restaurantLines.Add($"{restaurant.Id};{restaurant.Name}");
        File.WriteAllLines(restaurantsPath, restaurantLines);

        var dishLines = new List<string>();
        dishLines.Add("dish_id;restaurant_id;dish_name;price");
        foreach (var dish in GetAllMenuDishes())
            dishLines.Add($"{dish.Id};{dish.RestaurantId};{dish.Name};{dish.Price}");
        File.WriteAllLines(dishesPath, dishLines);
    }
}
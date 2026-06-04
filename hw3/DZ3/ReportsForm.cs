using DZ3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DZ3
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
            this.Load += ReportsForm_Load; 
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            using var db = new AppDbContext();

            // Раздел 1. Полный список блюд
            dataGridViewReport1.DataSource = db.Dishes
                .Include(d => d.Restaurant)
                .OrderBy(d => d.Name)
                .Select(d => new
                {
                    Блюдо = d.Name,
                    Ресторан = d.Restaurant!.Name,
                    Цена = d.Price
                })
                .ToList();

            // Раздел 2. Количество записей по категориям
            dataGridViewReport2.DataSource = db.Dishes
                .GroupBy(d => d.Restaurant!.Name)
                .Select(g => new
                {
                    Ресторан = g.Key,
                    КоличествоБлюд = g.Count()
                })
                .OrderBy(r => r.Ресторан)
                .ToList();

            // Раздел 3. Средняя цена
            dataGridView1.DataSource = db.Dishes
                .GroupBy(d => d.Restaurant!.Name)
                .Select(g => new
                {
                    Ресторан = g.Key,
                    СредняяЦена = Math.Round(g.Average(d => d.Price), 1)
                })
                .OrderByDescending(r => r.СредняяЦена)
                .ToList();

            // Автоматическое выравнивание ширины столбцов
            if (dataGridViewReport1.Columns.Count > 0)
                dataGridViewReport1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dataGridViewReport2.Columns.Count > 0)
                dataGridViewReport2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dataGridView1.Columns.Count > 0)
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ВОТ ОН — СПАСИТЕЛЬНЫЙ МЕТОД
        // Оставляем его пустым, он нужен только чтобы убрать ошибку
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
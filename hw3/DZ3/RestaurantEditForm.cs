using System;
using System.Windows.Forms;

namespace DZ3
{
    public partial class RestaurantEditForm : Form
    {
        public string RestaurantName { get; private set; } = "";

        public RestaurantEditForm(string currentName = "")
        {
            InitializeComponent();
            textBoxName.Text = currentName;

            // Привязываем клики к кнопкам через код
            buttonOk.Click += buttonOk_Click;
            buttonCancel.Click += buttonCancel_Click;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Название не может быть пустым!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RestaurantName = textBoxName.Text.Trim();
            this.DialogResult = DialogResult.OK; // Говорим, что всё прошло успешно
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
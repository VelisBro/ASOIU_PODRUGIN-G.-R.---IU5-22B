namespace DZ3
{
    partial class DishesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewDishes = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDishes).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewDishes
            // 
            dataGridViewDishes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDishes.Location = new Point(81, 57);
            dataGridViewDishes.Name = "dataGridViewDishes";
            dataGridViewDishes.RowHeadersWidth = 51;
            dataGridViewDishes.Size = new Size(601, 198);
            dataGridViewDishes.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackgroundImageLayout = ImageLayout.Center;
            button1.Location = new Point(81, 275);
            button1.Name = "button1";
            button1.Size = new Size(131, 62);
            button1.TabIndex = 1;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.Location = new Point(318, 275);
            button2.Name = "button2";
            button2.Size = new Size(131, 62);
            button2.TabIndex = 2;
            button2.Text = "Редактировать";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // button3
            // 
            button3.Location = new Point(551, 275);
            button3.Name = "button3";
            button3.Size = new Size(131, 62);
            button3.TabIndex = 3;
            button3.Text = "Удалить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // DishesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridViewDishes);
            Name = "DishesForm";
            Text = "DishesForm";
            Load += DishesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewDishes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewDishes;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}
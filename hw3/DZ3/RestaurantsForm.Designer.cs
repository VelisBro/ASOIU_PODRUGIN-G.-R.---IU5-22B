namespace DZ3
{
    partial class RestaurantsForm
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
            dataGridViewRestaurants = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRestaurants).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewRestaurants
            // 
            dataGridViewRestaurants.BackgroundColor = SystemColors.ControlLightLight;
            dataGridViewRestaurants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRestaurants.Location = new Point(117, 69);
            dataGridViewRestaurants.Name = "dataGridViewRestaurants";
            dataGridViewRestaurants.RowHeadersWidth = 51;
            dataGridViewRestaurants.Size = new Size(531, 219);
            dataGridViewRestaurants.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(117, 294);
            button1.Name = "button1";
            button1.Size = new Size(129, 68);
            button1.TabIndex = 1;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(314, 294);
            button2.Name = "button2";
            button2.Size = new Size(129, 68);
            button2.TabIndex = 2;
            button2.Text = "Редактировать";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(519, 294);
            button3.Name = "button3";
            button3.Size = new Size(129, 68);
            button3.TabIndex = 3;
            button3.Text = "Удалить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // RestaurantsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridViewRestaurants);
            Name = "RestaurantsForm";
            Text = "RestaurantsForm";
            Load += RestaurantsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewRestaurants).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewRestaurants;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}
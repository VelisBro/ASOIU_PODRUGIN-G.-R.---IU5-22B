namespace DZ3
{
    partial class DishEditForm
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
            comboBoxRestaurant = new ComboBox();
            textBoxName = new TextBox();
            textBoxPrice = new TextBox();
            buttonOk = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // comboBoxRestaurant
            // 
            comboBoxRestaurant.FormattingEnabled = true;
            comboBoxRestaurant.Location = new Point(86, 201);
            comboBoxRestaurant.Name = "comboBoxRestaurant";
            comboBoxRestaurant.Size = new Size(385, 28);
            comboBoxRestaurant.TabIndex = 0;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(86, 244);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(182, 27);
            textBoxName.TabIndex = 1;
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(298, 244);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(173, 27);
            textBoxPrice.TabIndex = 2;
            // 
            // buttonOk
            // 
            buttonOk.Location = new Point(86, 277);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(126, 55);
            buttonOk.TabIndex = 3;
            buttonOk.Text = "Сохранить";
            buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(345, 277);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(126, 55);
            buttonCancel.TabIndex = 4;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // DishEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOk);
            Controls.Add(textBoxPrice);
            Controls.Add(textBoxName);
            Controls.Add(comboBoxRestaurant);
            Name = "DishEditForm";
            Text = "DishEditForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxRestaurant;
        private TextBox textBoxName;
        private TextBox textBoxPrice;
        private Button buttonOk;
        private Button buttonCancel;
    }
}
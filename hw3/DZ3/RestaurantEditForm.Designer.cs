namespace DZ3
{
    partial class RestaurantEditForm
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
            textBoxName = new TextBox();
            buttonOk = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(277, 252);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(188, 27);
            textBoxName.TabIndex = 0;
            textBoxName.Text = "textBoxName";
            // 
            // buttonOk
            // 
            buttonOk.Location = new Point(221, 332);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(108, 82);
            buttonOk.TabIndex = 1;
            buttonOk.Text = "Сохранить";
            buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(398, 332);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(108, 82);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // RestaurantEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOk);
            Controls.Add(textBoxName);
            Name = "RestaurantEditForm";
            Text = "RestaurantEditForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxName;
        private Button buttonOk;
        private Button buttonCancel;
    }
}
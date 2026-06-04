namespace DZ3
{
    partial class ReportsForm
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
            label1 = new Label();
            dataGridViewReport1 = new DataGridView();
            label2 = new Label();
            dataGridViewReport2 = new DataGridView();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReport1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReport2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 9);
            label1.Name = "label1";
            label1.Size = new Size(225, 20);
            label1.TabIndex = 0;
            label1.Text = "Раздел 1. Полный список блюд";
            // 
            // dataGridViewReport1
            // 
            dataGridViewReport1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReport1.Location = new Point(32, 32);
            dataGridViewReport1.Name = "dataGridViewReport1";
            dataGridViewReport1.RowHeadersWidth = 51;
            dataGridViewReport1.Size = new Size(300, 188);
            dataGridViewReport1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(407, 9);
            label2.Name = "label2";
            label2.Size = new Size(307, 20);
            label2.TabIndex = 2;
            label2.Text = "Раздел 2. Количество блюд по ресторанам";
            // 
            // dataGridViewReport2
            // 
            dataGridViewReport2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReport2.Location = new Point(407, 32);
            dataGridViewReport2.Name = "dataGridViewReport2";
            dataGridViewReport2.RowHeadersWidth = 51;
            dataGridViewReport2.Size = new Size(300, 188);
            dataGridViewReport2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(54, 302);
            label3.Name = "label3";
            label3.Size = new Size(254, 20);
            label3.TabIndex = 4;
            label3.Text = "Раздел 3. Средняя стоимость меню";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(32, 325);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(300, 188);
            dataGridView1.TabIndex = 5;
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(967, 540);
            Controls.Add(dataGridView1);
            Controls.Add(label3);
            Controls.Add(dataGridViewReport2);
            Controls.Add(label2);
            Controls.Add(dataGridViewReport1);
            Controls.Add(label1);
            Name = "ReportsForm";
            Text = "ReportsForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewReport1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReport2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridViewReport1;
        private Label label2;
        private DataGridView dataGridViewReport2;
        private Label label3;
        private DataGridView dataGridView1;
    }
}
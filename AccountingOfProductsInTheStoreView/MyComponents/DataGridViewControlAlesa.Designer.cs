
namespace ComponentsAutumn
{
    partial class DataGridViewControlAlesa
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewAlesa = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlesa)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAlesa
            // 
            this.dataGridViewAlesa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAlesa.Location = new System.Drawing.Point(4, 4);
            this.dataGridViewAlesa.Name = "dataGridViewAlesa";
            this.dataGridViewAlesa.RowHeadersVisible = false;
            this.dataGridViewAlesa.RowHeadersWidth = 62;
            this.dataGridViewAlesa.RowTemplate.Height = 28;
            this.dataGridViewAlesa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAlesa.Size = new System.Drawing.Size(278, 156);
            this.dataGridViewAlesa.TabIndex = 0;
            // 
            // DataGridViewControlAlesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewAlesa);
            this.Name = "DataGridViewControlAlesa";
            this.Size = new System.Drawing.Size(285, 163);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlesa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAlesa;
    }
}

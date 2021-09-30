
namespace ComponentsAutumn
{
    partial class TextBoxControlAlesa
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBoxNull = new System.Windows.Forms.CheckBox();
            this.labelData = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox_SelectedChanged);
            // 
            // checkBoxNull
            // 
            this.checkBoxNull.AutoSize = true;
            this.checkBoxNull.Location = new System.Drawing.Point(13, 90);
            this.checkBoxNull.Name = "checkBoxNull";
            this.checkBoxNull.Size = new System.Drawing.Size(134, 24);
            this.checkBoxNull.TabIndex = 1;
            this.checkBoxNull.Text = "null значение";
            this.checkBoxNull.UseVisualStyleBackColor = true;
            this.checkBoxNull.CheckedChanged += new System.EventHandler(this.checkBoxNull_CheckedChanged);
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.Location = new System.Drawing.Point(9, 11);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(138, 20);
            this.labelData.TabIndex = 2;
            this.labelData.Text = "Введите данные";
            // 
            // TextBoxControlAlesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelData);
            this.Controls.Add(this.checkBoxNull);
            this.Controls.Add(this.textBox1);
            this.Name = "TextBoxControlAlesa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBoxNull;
        private System.Windows.Forms.Label labelData;
    }
}

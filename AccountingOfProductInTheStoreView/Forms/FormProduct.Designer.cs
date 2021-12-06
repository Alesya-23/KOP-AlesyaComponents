
namespace AccountingOfProductInTheStoreView.Forms
{
    partial class FormProduct
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
            this.TextBoxCountry = new MyControlLibrary.RangeTextBoxUserControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxControlAlesa1 = new ComponentsAutumn.ListBoxControlAlesa();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxFirstSupplier = new System.Windows.Forms.TextBox();
            this.textBoxSecondSupplier = new System.Windows.Forms.TextBox();
            this.textBoxThirdSupplier = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancell = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextBoxCountry
            // 
            this.TextBoxCountry.Location = new System.Drawing.Point(456, 38);
            this.TextBoxCountry.MaxSymbols = null;
            this.TextBoxCountry.MinSymbols = 0;
            this.TextBoxCountry.Name = "TextBoxCountry";
            this.TextBoxCountry.Size = new System.Drawing.Size(203, 43);
            this.TextBoxCountry.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(490, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Страна";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(481, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Третий производитель";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(261, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Второй производитель";
            // 
            // listBoxControlAlesa1
            // 
            this.listBoxControlAlesa1.AutoScroll = true;
            this.listBoxControlAlesa1.AutoSize = true;
            this.listBoxControlAlesa1.Location = new System.Drawing.Point(248, 38);
            this.listBoxControlAlesa1.Name = "listBoxControlAlesa1";
            this.listBoxControlAlesa1.Size = new System.Drawing.Size(135, 51);
            this.listBoxControlAlesa1.TabIndex = 6;
            this.listBoxControlAlesa1.ValueList = "";
            this.listBoxControlAlesa1.SpecEvent += new System.EventHandler(this.changeUnit);
            this.listBoxControlAlesa1.Load += new System.EventHandler(this.FormProduct_Load);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(236, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Единица измерения (кг и т.д.)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(191, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Первый производитель";
            // 
            // textBoxFirstSupplier
            // 
            this.textBoxFirstSupplier.Location = new System.Drawing.Point(42, 158);
            this.textBoxFirstSupplier.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxFirstSupplier.Name = "textBoxFirstSupplier";
            this.textBoxFirstSupplier.Size = new System.Drawing.Size(135, 26);
            this.textBoxFirstSupplier.TabIndex = 9;
            // 
            // textBoxSecondSupplier
            // 
            this.textBoxSecondSupplier.Location = new System.Drawing.Point(290, 158);
            this.textBoxSecondSupplier.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSecondSupplier.Name = "textBoxSecondSupplier";
            this.textBoxSecondSupplier.Size = new System.Drawing.Size(135, 26);
            this.textBoxSecondSupplier.TabIndex = 10;
            // 
            // textBoxThirdSupplier
            // 
            this.textBoxThirdSupplier.Location = new System.Drawing.Point(507, 158);
            this.textBoxThirdSupplier.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxThirdSupplier.Name = "textBoxThirdSupplier";
            this.textBoxThirdSupplier.Size = new System.Drawing.Size(135, 26);
            this.textBoxThirdSupplier.TabIndex = 11;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(11, 38);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(162, 26);
            this.textBoxName.TabIndex = 12;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(11, 15);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(158, 20);
            this.labelName.TabIndex = 13;
            this.labelName.Text = "Название продукта";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(202, 203);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(101, 27);
            this.buttonSave.TabIndex = 14;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancell
            // 
            this.buttonCancell.Location = new System.Drawing.Point(338, 203);
            this.buttonCancell.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCancell.Name = "buttonCancell";
            this.buttonCancell.Size = new System.Drawing.Size(101, 27);
            this.buttonCancell.TabIndex = 15;
            this.buttonCancell.Text = "Отмена";
            this.buttonCancell.UseVisualStyleBackColor = true;
            this.buttonCancell.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 247);
            this.Controls.Add(this.buttonCancell);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxThirdSupplier);
            this.Controls.Add(this.textBoxSecondSupplier);
            this.Controls.Add(this.textBoxFirstSupplier);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBoxControlAlesa1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxCountry);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormProduct";
            this.Text = "FormProduct";
            this.Load += new System.EventHandler(this.FormProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyControlLibrary.RangeTextBoxUserControl TextBoxCountry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ComponentsAutumn.ListBoxControlAlesa listBoxControlAlesa1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxFirstSupplier;
        private System.Windows.Forms.TextBox textBoxSecondSupplier;
        private System.Windows.Forms.TextBox textBoxThirdSupplier;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancell;
    }
}
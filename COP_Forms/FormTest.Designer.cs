
namespace ComponentsAutumn
{
    partial class FormTest
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
            this.components = new System.ComponentModel.Container();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.textBoxInputItems = new System.Windows.Forms.TextBox();
            this.buttonAddText = new System.Windows.Forms.Button();
            this.buttonSaveStorage = new System.Windows.Forms.Button();
            this.labelCurrent = new System.Windows.Forms.Label();
            this.dataGridViewControlAlesa1 = new ComponentsAutumn.DataGridViewControlAlesa();
            this.textBoxControlAlesa1 = new ComponentsAutumn.TextBoxControlAlesa();
            this.listBoxControlAlesa1 = new ComponentsAutumn.ListBoxControlAlesa();
            this.labelNumb = new System.Windows.Forms.Label();
            this.wordTableOne = new UnvisualComponentsAlesa.WordTableOne();
            this.wordTableTwo = new UnvisualComponentsAlesa.WordTableTwo(this.components);
            this.gistagramWord = new UnvisualComponentsAlesa.GistagramWord();
            this.buttonGistogram = new System.Windows.Forms.Button();
            this.SaveDataChangebleWordButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(27, 136);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(161, 49);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(27, 205);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(161, 49);
            this.buttonClear.TabIndex = 2;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // textBoxInputItems
            // 
            this.textBoxInputItems.BackColor = System.Drawing.SystemColors.ControlDark;
            this.textBoxInputItems.Location = new System.Drawing.Point(27, 96);
            this.textBoxInputItems.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxInputItems.Name = "textBoxInputItems";
            this.textBoxInputItems.Size = new System.Drawing.Size(245, 31);
            this.textBoxInputItems.TabIndex = 3;
            // 
            // buttonAddText
            // 
            this.buttonAddText.Location = new System.Drawing.Point(320, 210);
            this.buttonAddText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonAddText.Name = "buttonAddText";
            this.buttonAddText.Size = new System.Drawing.Size(161, 49);
            this.buttonAddText.TabIndex = 5;
            this.buttonAddText.Text = "Добавить";
            this.buttonAddText.UseVisualStyleBackColor = true;
            this.buttonAddText.Click += new System.EventHandler(this.ButtonAddText_Click);
            // 
            // buttonSaveStorage
            // 
            this.buttonSaveStorage.Location = new System.Drawing.Point(42, 334);
            this.buttonSaveStorage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSaveStorage.Name = "buttonSaveStorage";
            this.buttonSaveStorage.Size = new System.Drawing.Size(280, 49);
            this.buttonSaveStorage.TabIndex = 7;
            this.buttonSaveStorage.Text = "Сохранить данные";
            this.buttonSaveStorage.UseVisualStyleBackColor = true;
            this.buttonSaveStorage.Click += new System.EventHandler(this.buttonSaveStorage_Click);
            // 
            // labelCurrent
            // 
            this.labelCurrent.AutoSize = true;
            this.labelCurrent.Location = new System.Drawing.Point(178, 19);
            this.labelCurrent.Name = "labelCurrent";
            this.labelCurrent.Size = new System.Drawing.Size(74, 25);
            this.labelCurrent.TabIndex = 8;
            this.labelCurrent.Text = "Current:";
            // 
            // dataGridViewControlAlesa1
            // 
            this.dataGridViewControlAlesa1.Location = new System.Drawing.Point(542, 19);
            this.dataGridViewControlAlesa1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dataGridViewControlAlesa1.Name = "dataGridViewControlAlesa1";
            this.dataGridViewControlAlesa1.Size = new System.Drawing.Size(317, 204);
            this.dataGridViewControlAlesa1.TabIndex = 6;
            this.dataGridViewControlAlesa1.Load += new System.EventHandler(this.dataGridViewControlAlesa1_Load);
            // 
            // textBoxControlAlesa1
            // 
            this.textBoxControlAlesa1.Location = new System.Drawing.Point(320, 15);
            this.textBoxControlAlesa1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.textBoxControlAlesa1.Name = "textBoxControlAlesa1";
            this.textBoxControlAlesa1.Size = new System.Drawing.Size(167, 188);
            this.textBoxControlAlesa1.TabIndex = 4;
            this.textBoxControlAlesa1.SpecEvent += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // listBoxControlAlesa1
            // 
            this.listBoxControlAlesa1.Location = new System.Drawing.Point(27, 19);
            this.listBoxControlAlesa1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.listBoxControlAlesa1.Name = "listBoxControlAlesa1";
            this.listBoxControlAlesa1.Size = new System.Drawing.Size(161, 70);
            this.listBoxControlAlesa1.TabIndex = 0;
            this.listBoxControlAlesa1.ValueList = "";
            this.listBoxControlAlesa1.SpecEvent += new System.EventHandler(this.listBoxControl_SelectedChangedEvent);
            // 
            // labelNumb
            // 
            this.labelNumb.AutoSize = true;
            this.labelNumb.Location = new System.Drawing.Point(353, 276);
            this.labelNumb.Name = "labelNumb";
            this.labelNumb.Size = new System.Drawing.Size(74, 25);
            this.labelNumb.TabIndex = 9;
            this.labelNumb.Text = "Current:";
            // 
            // buttonGistogram
            // 
            this.buttonGistogram.Location = new System.Drawing.Point(353, 334);
            this.buttonGistogram.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonGistogram.Name = "buttonGistogram";
            this.buttonGistogram.Size = new System.Drawing.Size(280, 49);
            this.buttonGistogram.TabIndex = 10;
            this.buttonGistogram.Text = "Гистограмма";
            this.buttonGistogram.UseVisualStyleBackColor = true;
            this.buttonGistogram.Click += new System.EventHandler(this.buttonGistogram_Click);
            // 
            // SaveDataChangebleWordButton
            // 
            this.SaveDataChangebleWordButton.Location = new System.Drawing.Point(178, 421);
            this.SaveDataChangebleWordButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SaveDataChangebleWordButton.Name = "SaveDataChangebleWordButton";
            this.SaveDataChangebleWordButton.Size = new System.Drawing.Size(279, 80);
            this.SaveDataChangebleWordButton.TabIndex = 11;
            this.SaveDataChangebleWordButton.Text = "Сохранить в настраимой таблице";
            this.SaveDataChangebleWordButton.UseVisualStyleBackColor = true;
            this.SaveDataChangebleWordButton.Click += new System.EventHandler(this.SaveDataChangebleWordButton_Click);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 562);
            this.Controls.Add(this.SaveDataChangebleWordButton);
            this.Controls.Add(this.buttonGistogram);
            this.Controls.Add(this.labelNumb);
            this.Controls.Add(this.labelCurrent);
            this.Controls.Add(this.buttonSaveStorage);
            this.Controls.Add(this.dataGridViewControlAlesa1);
            this.Controls.Add(this.buttonAddText);
            this.Controls.Add(this.textBoxControlAlesa1);
            this.Controls.Add(this.textBoxInputItems);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listBoxControlAlesa1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.Load += new System.EventHandler(this.FormTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBoxControlAlesa listBoxControlAlesa1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.TextBox textBoxInputItems;
        private TextBoxControlAlesa textBoxControlAlesa1;
        private System.Windows.Forms.Button buttonAddText;
        private DataGridViewControlAlesa dataGridViewControlAlesa1;
        private UnvisualComponentsAlesa.WordTableOne wordTableOne;
        private UnvisualComponentsAlesa.WordTableTwo wordTableTwo;
        private UnvisualComponentsAlesa.GistagramWord gistagramWord;
        private System.Windows.Forms.Button buttonSaveStorage;
        private System.Windows.Forms.Label labelCurrent;
        private System.Windows.Forms.Label labelNumb;
        private System.Windows.Forms.Button buttonGistogram;
        private System.Windows.Forms.Button SaveDataChangebleWordButton;
    }
}

namespace AccountingOfProductInTheStoreView.Forms
{
    partial class FormChooseReport
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
            this.buttonCreate = new System.Windows.Forms.Button();
            this.comboBoxChoose = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(24, 69);
            this.buttonCreate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(447, 35);
            this.buttonCreate.TabIndex = 3;
            this.buttonCreate.Text = "Сформировать";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // comboBoxChoose
            // 
            this.comboBoxChoose.FormattingEnabled = true;
            this.comboBoxChoose.Location = new System.Drawing.Point(24, 26);
            this.comboBoxChoose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxChoose.Name = "comboBoxChoose";
            this.comboBoxChoose.Size = new System.Drawing.Size(445, 28);
            this.comboBoxChoose.TabIndex = 2;
            // 
            // FormChooseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 120);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.comboBoxChoose);
            this.Name = "FormChooseReport";
            this.Text = "FormChooseReport";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.ComboBox comboBoxChoose;
    }
}
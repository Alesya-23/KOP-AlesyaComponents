
namespace AccountingOfProductInTheStoreView.Forms
{
    partial class FormMessage
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.labelReceiver = new System.Windows.Forms.Label();
            this.labelMsg = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 53);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.Size = new System.Drawing.Size(335, 375);
            this.dataGridView.TabIndex = 0;
            // 
            // labelReceiver
            // 
            this.labelReceiver.AutoSize = true;
            this.labelReceiver.Location = new System.Drawing.Point(86, 18);
            this.labelReceiver.Name = "labelReceiver";
            this.labelReceiver.Size = new System.Drawing.Size(102, 20);
            this.labelReceiver.TabIndex = 1;
            this.labelReceiver.Text = "Получатели";
            // 
            // labelMsg
            // 
            this.labelMsg.AutoSize = true;
            this.labelMsg.Location = new System.Drawing.Point(420, 18);
            this.labelMsg.Name = "labelMsg";
            this.labelMsg.Size = new System.Drawing.Size(140, 20);
            this.labelMsg.TabIndex = 2;
            this.labelMsg.Text = "Текст сообщения";
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(369, 53);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(262, 332);
            this.textBox.TabIndex = 3;
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(369, 391);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(262, 36);
            this.buttonSend.TabIndex = 4;
            this.buttonSend.Text = "Отправить";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // FormMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 444);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.labelMsg);
            this.Controls.Add(this.labelReceiver);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormMessage";
            this.Text = "Оповещение";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label labelReceiver;
        private System.Windows.Forms.Label labelMsg;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button buttonSend;
    }
}
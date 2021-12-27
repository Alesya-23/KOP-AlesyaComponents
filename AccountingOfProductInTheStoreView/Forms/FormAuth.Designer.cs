
namespace AccountingOfProductInTheStoreView.Forms
{
    partial class FormAuth
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
            this.buttonAuth = new System.Windows.Forms.Button();
            this.textBoxApiHash = new System.Windows.Forms.TextBox();
            this.textBoxApiId = new System.Windows.Forms.TextBox();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxChoose = new System.Windows.Forms.ComboBox();
            this.textBoxToken = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.labelMsg = new System.Windows.Forms.Label();
            this.labelReceiver = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAuth
            // 
            this.buttonAuth.Location = new System.Drawing.Point(33, 249);
            this.buttonAuth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAuth.Name = "buttonAuth";
            this.buttonAuth.Size = new System.Drawing.Size(300, 35);
            this.buttonAuth.TabIndex = 13;
            this.buttonAuth.Text = "Авторизироваться";
            this.buttonAuth.UseVisualStyleBackColor = true;
            this.buttonAuth.Click += new System.EventHandler(this.buttonAuth_Click);
            // 
            // textBoxApiHash
            // 
            this.textBoxApiHash.Location = new System.Drawing.Point(129, 180);
            this.textBoxApiHash.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxApiHash.Name = "textBoxApiHash";
            this.textBoxApiHash.Size = new System.Drawing.Size(214, 26);
            this.textBoxApiHash.TabIndex = 12;
            // 
            // textBoxApiId
            // 
            this.textBoxApiId.Location = new System.Drawing.Point(106, 125);
            this.textBoxApiId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxApiId.Name = "textBoxApiId";
            this.textBoxApiId.Size = new System.Drawing.Size(236, 26);
            this.textBoxApiId.TabIndex = 11;
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(195, 68);
            this.textBoxNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(148, 26);
            this.textBoxNumber.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 129);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "API id:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 185);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "API hash:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Номер телефона:";
            // 
            // comboBoxChoose
            // 
            this.comboBoxChoose.FormattingEnabled = true;
            this.comboBoxChoose.Location = new System.Drawing.Point(33, 26);
            this.comboBoxChoose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxChoose.Name = "comboBoxChoose";
            this.comboBoxChoose.Size = new System.Drawing.Size(310, 28);
            this.comboBoxChoose.TabIndex = 14;
            // 
            // textBoxToken
            // 
            this.textBoxToken.Location = new System.Drawing.Point(128, 216);
            this.textBoxToken.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxToken.Name = "textBoxToken";
            this.textBoxToken.Size = new System.Drawing.Size(214, 26);
            this.textBoxToken.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 219);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Token";
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(732, 384);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(262, 36);
            this.buttonSend.TabIndex = 21;
            this.buttonSend.Text = "Отправить";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(732, 46);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(262, 332);
            this.textBox.TabIndex = 20;
            // 
            // labelMsg
            // 
            this.labelMsg.AutoSize = true;
            this.labelMsg.Location = new System.Drawing.Point(783, 11);
            this.labelMsg.Name = "labelMsg";
            this.labelMsg.Size = new System.Drawing.Size(140, 20);
            this.labelMsg.TabIndex = 19;
            this.labelMsg.Text = "Текст сообщения";
            // 
            // labelReceiver
            // 
            this.labelReceiver.AutoSize = true;
            this.labelReceiver.Location = new System.Drawing.Point(449, 11);
            this.labelReceiver.Name = "labelReceiver";
            this.labelReceiver.Size = new System.Drawing.Size(102, 20);
            this.labelReceiver.TabIndex = 18;
            this.labelReceiver.Text = "Получатели";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(375, 46);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.Size = new System.Drawing.Size(335, 375);
            this.dataGridView.TabIndex = 17;
            this.dataGridView.DataSourceChanged += new System.EventHandler(this.buttonAuth_Click);
            // 
            // FormAuth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 442);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.labelMsg);
            this.Controls.Add(this.labelReceiver);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxToken);
            this.Controls.Add(this.comboBoxChoose);
            this.Controls.Add(this.buttonAuth);
            this.Controls.Add(this.textBoxApiHash);
            this.Controls.Add(this.textBoxApiId);
            this.Controls.Add(this.textBoxNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormAuth";
            this.Text = "FormAuth";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAuth;
        private System.Windows.Forms.TextBox textBoxApiHash;
        private System.Windows.Forms.TextBox textBoxApiId;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxChoose;
        private System.Windows.Forms.TextBox textBoxToken;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label labelMsg;
        private System.Windows.Forms.Label labelReceiver;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}
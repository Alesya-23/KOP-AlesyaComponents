
using MyComponentsLibrary;

namespace AccountingOfProductInTheStoreView.Forms
{
    partial class FormMainProduct
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
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.студентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникВеличинToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётВордToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.линейнаяДиаграммаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сообщениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.конфигураторДокументовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userControlListBox1 = new COP_labs.UserControlListBox();
            this.pdfTableComponent = new MyComponentsLibrary.PDFTableComponent(this.components);
            this.wordTableOne = new AccountingOfProductInTheStoreView.WordTableOne();
            this.excelChart = new ExcelComponents.ExcelChart(this.components);
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.студентыToolStripMenuItem,
            this.справочникВеличинToolStripMenuItem,
            this.отчётВордToolStripMenuItem,
            this.отчетPDFToolStripMenuItem,
            this.линейнаяДиаграммаToolStripMenuItem,
            this.сообщениеToolStripMenuItem,
            this.конфигураторДокументовToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(350, 228);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // студентыToolStripMenuItem
            // 
            this.студентыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem,
            this.изменитьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.студентыToolStripMenuItem.Name = "студентыToolStripMenuItem";
            this.студентыToolStripMenuItem.Size = new System.Drawing.Size(349, 32);
            this.студентыToolStripMenuItem.Text = "Продукты";
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(279, 34);
            this.создатьToolStripMenuItem.Text = "Создать (Cntrl + A)";
            this.создатьToolStripMenuItem.Click += new System.EventHandler(this.создатьToolStripMenuItem_Click);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(279, 34);
            this.изменитьToolStripMenuItem.Text = "Изменить (Cntrl + U)";
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.изменитьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(279, 34);
            this.удалитьToolStripMenuItem.Text = "Удалить (Cntrl + A)";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // справочникВеличинToolStripMenuItem
            // 
            this.справочникВеличинToolStripMenuItem.Name = "справочникВеличинToolStripMenuItem";
            this.справочникВеличинToolStripMenuItem.Size = new System.Drawing.Size(349, 32);
            this.справочникВеличинToolStripMenuItem.Text = "Справочник величин";
            this.справочникВеличинToolStripMenuItem.Click += new System.EventHandler(this.справочникВеличинToolStripMenuItem_Click);
            // 
            // отчётВордToolStripMenuItem
            // 
            this.отчётВордToolStripMenuItem.Name = "отчётВордToolStripMenuItem";
            this.отчётВордToolStripMenuItem.Size = new System.Drawing.Size(349, 32);
            this.отчётВордToolStripMenuItem.Text = "Отчёт ворд  (Cntrl + S)";
            this.отчётВордToolStripMenuItem.Click += new System.EventHandler(this.отчётВордToolStripMenuItem_Click);
            // 
            // отчетPDFToolStripMenuItem
            // 
            this.отчетPDFToolStripMenuItem.Name = "отчетPDFToolStripMenuItem";
            this.отчетPDFToolStripMenuItem.Size = new System.Drawing.Size(349, 32);
            this.отчетPDFToolStripMenuItem.Text = "Отчет PDF  (Cntrl + T)";
            this.отчетPDFToolStripMenuItem.Click += new System.EventHandler(this.отчетPDFToolStripMenuItem_Click);
            // 
            // линейнаяДиаграммаToolStripMenuItem
            // 
            this.линейнаяДиаграммаToolStripMenuItem.Name = "линейнаяДиаграммаToolStripMenuItem";
            this.линейнаяДиаграммаToolStripMenuItem.Size = new System.Drawing.Size(349, 32);
            this.линейнаяДиаграммаToolStripMenuItem.Text = "Линейная диаграмма  (Cntrl + C)";
            this.линейнаяДиаграммаToolStripMenuItem.Click += new System.EventHandler(this.линейнаяДиаграммаToolStripMenuItem_Click);
            // 
            // сообщениеToolStripMenuItem
            // 
            this.сообщениеToolStripMenuItem.Name = "сообщениеToolStripMenuItem";
            this.сообщениеToolStripMenuItem.Size = new System.Drawing.Size(349, 32);
            this.сообщениеToolStripMenuItem.Text = "Сообщение";
            this.сообщениеToolStripMenuItem.Click += new System.EventHandler(this.сообщениеToolStripMenuItem_Click);
            // 
            // конфигураторДокументовToolStripMenuItem
            // 
            this.конфигураторДокументовToolStripMenuItem.Name = "конфигураторДокументовToolStripMenuItem";
            this.конфигураторДокументовToolStripMenuItem.Size = new System.Drawing.Size(349, 32);
            this.конфигураторДокументовToolStripMenuItem.Text = "Конфигуратор документов";
            this.конфигураторДокументовToolStripMenuItem.Click += new System.EventHandler(this.конфигураторДокументовToolStripMenuItem_Click);
            // 
            // userControlListBox1
            // 
            this.userControlListBox1.AutoSize = true;
            this.userControlListBox1.ContextMenuStrip = this.contextMenuStrip;
            this.userControlListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlListBox1.GetIndex = -1;
            this.userControlListBox1.Location = new System.Drawing.Point(0, 0);
            this.userControlListBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userControlListBox1.Name = "userControlListBox1";
            this.userControlListBox1.Size = new System.Drawing.Size(1113, 355);
            this.userControlListBox1.TabIndex = 1;
            // 
            // FormMainProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 355);
            this.Controls.Add(this.userControlListBox1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMainProduct";
            this.Text = "Основное окно";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.outputControl_KeyDown);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem студентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справочникВеличинToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private PDFTableComponent pdfTableComponent;
        private ExcelComponents.ExcelChart excelChart;
        private WordTableOne wordTableOne;
        private COP_labs.UserControlListBox userControlListBox1;
        private System.Windows.Forms.ToolStripMenuItem отчётВордToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетPDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem линейнаяДиаграммаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сообщениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem конфигураторДокументовToolStripMenuItem;
    }
}
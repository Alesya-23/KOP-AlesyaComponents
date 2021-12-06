﻿using AccountingOfProductInTheStoreView.Logic.BindingModels;
using AccountingOfProductInTheStoreView.Logic.BusinessLogics;
using AccountingOfProductInTheStoreView.Logic.ViewModels;
using ExcelComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AccountingOfProductInTheStoreView.Forms
{
    public partial class FormMainProduct : Form
    {
        private readonly ProductLogic productLogic = new ProductLogic();

        public FormMainProduct()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            userControlListBox1.AddTemplate("Страна {Country}, Идентификатор {Id}, Название продукта {name}," +
            " Единица измерения {UnitOfMeasurement}", '{', '}');
            try
            {
                List<ProductViewModel> list = productLogic.Read(null);
                userControlListBox1.ClearListBox();
                foreach (ProductViewModel product in list)
                {
                    userControlListBox1.AddObjectToListBox<ProductViewModelListBoxData>(new ProductViewModelListBoxData
                    {

                        Id = (int)product.Id,
                        name = product.name,
                        Country = product.Country,
                        UnitOfMeasurement = product.UnitOfMeasurement,
                        SupplierOne = product.SupplierOne,
                        SupplierTwo = product.SupplierTwo,
                        SupplierThree = product.SupplierThree
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void CreateProduct()
        {
            try
            {
                FormProduct form = new FormProduct();
                form.ShowDialog();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void DeleteProduct()
        {
            if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    ProductViewModelListBoxData product = userControlListBox1.GetItem<ProductViewModelListBoxData>();
                    productLogic.Delete(new ProductBindingModel { Id = product.Id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void EditProduct()
        {
            try
            {
                ProductViewModelListBoxData product = userControlListBox1.GetItem<ProductViewModelListBoxData>();
                FormProduct form = new FormProduct();
                form.Id = (int)product.Id;
                form.ShowDialog();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }


        private void CreateDocumentWord()
        {
            List<ProductViewModel> list = productLogic.Read(null);
            string fileName = "";
            try
            {
                using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        fileName = dialog.FileName.ToString();
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                    }
                }
                //доделать!!!
                List<string[,]> datas = new List<string[,]>();
                int count = list.Count;
                string[,] data = new string[count, 3];
                int i = 0;
                foreach (var listItem in list)
                {
                    data[i, 0] = listItem.SupplierOne;
                    data[i, 1] = listItem.SupplierTwo;
                    data[i, 2] = listItem.SupplierThree;
                    if (i < count)
                        i++;
                }
                datas.Add(data);
                wordTableOne.SaveData(fileName, "otchet", datas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        [Obsolete]
        private void CreateDocumentPDF()
        {
            List<ProductViewModel> list = productLogic.Read(null);
            try
            {
                string fileName = "";
                using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        fileName = dialog.FileName.ToString();
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                    }
                }
                bool result = pdfTableComponent.CreateDocumentWithObjects(fileName,
                   "Text", list, new List<string>
                    { "Id", "name","UnitOfMeasurement", "Country" }, new List<int>
                    {2,3}, new Dictionary<int, string> { { 1, "5cm" }, { 3, "5cm" } });

                if (result)
                {
                    MessageBox.Show("Saved");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не выполнено", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void CreateDiagramExel()
        {
            List<ProductViewModel> list = productLogic.Read(null);
            string fileName = "";
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName.ToString();
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                }
            }
            List<string> serias = new List<string>();
            List<string> country = new List<string>();
            List<int> values = new List<int>();
            foreach (ProductViewModel product in list)
            {
                if (!country.Contains(product.Country))
                {
                    country.Add(product.Country);
                    values.Add(0);
                }
                serias.Add(product.UnitOfMeasurement);
            }

            foreach (ProductViewModel product in list)
            {
                for (int i = 0; i < country.Count; i++)
                {
                    if (country[i] == product.Country)
                        values[i]++;
                }
            }
            // exel Semen
            excelChart.CreateExcel(new LineChartConfig
            {
                FilePath = fileName,
                Header = "Количество продуктов в ращных странах",
                ChartTitle = "Диаграмма",
                Position = LegendPosition.Botton,
                //Это значения по Х
                XValues = new List<List<int>>
                        {
                           values
                        },
                //Это подписи по Х
                YValues = country,
                //Тут история диаграммы
                SeriesNames = new List<string> { "" }
            });
            MessageBox.Show("Отчет сформирован успешно", "Сообщение",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        [Obsolete]
        private void outputControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control)
        && e.KeyValue == 'A')
            {
                CreateProduct();
            }
            if (e.KeyCode == Keys.U && e.Control)
            {
                EditProduct();
            }
            if (e.KeyCode == Keys.D && e.Control)
            {
                DeleteProduct();
            }
            //files
            if (e.KeyCode == Keys.S && e.Control)
            {
                CreateDocumentWord();
            }
            if (e.KeyCode == Keys.T && e.Control)
            {
                CreateDocumentPDF();
            }
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control)
        && e.KeyValue == 'C')
            {
                CreateDiagramExel();
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateProduct();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditProduct();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteProduct();
        }

        private void справочникВеличинToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUnitOfMeasurement form = new FormUnitOfMeasurement();
            form.ShowDialog();
            LoadData();
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {

        }

        private void отчётВордToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateDocumentWord();
        }

        private void отчетPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateDocumentPDF();
        }

        private void линейнаяДиаграммаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateDiagramExel();
        }
    }
}
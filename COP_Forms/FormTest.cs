using COP_Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UnvisualComponentsAlesa;
using UnvisualComponentsAlesa.HelperModels;

namespace ComponentsAutumn
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void listBoxControl_SelectedChangedEvent(object sender, EventArgs e)
        {
            labelCurrent.Text = listBoxControlAlesa1.ValueList;
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            textBoxInputItems.Text = listBoxControlAlesa1.ValueList;
            Console.WriteLine(listBoxControlAlesa1.ValueList);
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            listBoxControlAlesa1.AddItem(textBoxInputItems.Text);
            textBoxInputItems.Clear();
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            listBoxControlAlesa1.ClearList();
        }

        private void ButtonAddText_Click(object sender, EventArgs e)
        {
            labelNumb.Text = textBoxControlAlesa1.ValueTextBox.ToString();
        }

        public class MyObject
        {
            public string name { get; set; }

            public int count { get; set; }
        }
        private void dataGridViewControlAlesa1_Load(object sender, EventArgs e)
        {
            MyObject objMy = new MyObject();
            objMy.count = 9;
            objMy.name = "Alesya";
            MyObject objMy2 = new MyObject();
            objMy2.count = 12;
            objMy2.name = "Таня";
            ColumnsDataGrid column = new ColumnsDataGrid();
            column.CountColumn = 2;
            column.NameColumn = new string[] { "name", "count" };
            column.Width = new int[] { 80, 50 };
            column.Visible = new bool[] { true, true };
            column.PropertiesObject = new string[] { "name", "count" };
            dataGridViewControlAlesa1.ConfigColumn(column);
            dataGridViewControlAlesa1.AddRow(objMy);
            dataGridViewControlAlesa1.AddRow(objMy2);
        }

        private void buttonSaveStorage_Click(object sender, EventArgs e)
        {
            string fileName = "";
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName.ToString();
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                }
            }
            List<string[,]> datas = new List<string[,]>();
            string[,] data = new string[,] { { "Anya", "Vasya" }, { "Dasha", "Mark" } };
            datas.Add(data);
            wordTableOne.SaveData(fileName, "otchet", datas);

        }

        private void buttonGistogram_Click(object sender, EventArgs e)
        {
            string fileName = "";
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName.ToString();
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                }
            }
            List<TestData> data = new List<TestData>();
            data.Add(new TestData { name = "csscdscd", value = 1 });
            data.Add(new TestData { name = "aaa", value = 51 });
            data.Add(new TestData { name = "sdcdscd", value = 11 });
            data.Add(new TestData { name = "q234", value = 43 });
            data.Add(new TestData { name = "Ty", value = 32 });
            LocationLegend legend = new LocationLegend();
            gistagramWord.ReportSaveGistogram(fileName, "gistagram", "gistagram", legend, data);
        }

        private void SaveDataChangebleWordButton_Click(object sender, EventArgs e)
        {
            DataClass data = new DataClass();
            string fileName = "";
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName.ToString();
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                }
            }
            wordTableTwo.SaveData<TestData>(new ComponentWordTableConfig<TestData>
            {
                WordInfo = new WordInfo
                {
                    FileName = fileName,
                    Title = "Тестовая данная"
                },
                ColumnsWidth = data.getColumnsWidth(2, 2400),
                RowsHeight = data.getRowsHeight(5, 1000),
                Headers = data.GetHeader(2),
                PropertiesQueue = data.GetHeader(2),
                ListData = data.GetTests()
            });
        }

        private void FormTest_Load(object sender, EventArgs e)
        {

        }
    }
}

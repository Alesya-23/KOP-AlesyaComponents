using System;
using System.Windows.Forms;

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

        public class MyObject{ 
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
            column.NameColumn = new string []{"name", "count"};
            column.Width = new int[] { 80, 50 };
            column.Visible = new bool[] { true, true };
            column.PropertiesObject = new string[] { "name", "count" };
            dataGridViewControlAlesa1.ConfigColumn(column);
            dataGridViewControlAlesa1.AddRow(objMy);
            dataGridViewControlAlesa1.AddRow(objMy2);
        }

        private void buttonSaveStorage_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                //    report.SaveComponentsToWordFile(new ReportBindingModel
                //    {
                //        FileName = dialog.FileName
                //    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                }
            }
        }
    }
}

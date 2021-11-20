using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ComponentsAutumn
{
    public partial class DataGridViewControlAlesa : UserControl
    {
        public int IndexRow
        {
            get { return dataGridViewAlesa.SelectedRows[0].Index; }
            set
            {
                if (dataGridViewAlesa.SelectedRows.Count <= value || value < 0)
                    throw new ArgumentException(string.Format("{0} is an invalid row index.", value));
                else
                {
                    dataGridViewAlesa.ClearSelection();
                    dataGridViewAlesa.Rows[value].Selected = true;
                }
            }
        }

        /// <summary>
        ///Инициализация DataGrid
        /// </summary>
        public DataGridViewControlAlesa()
        {
            InitializeComponent();
        }

        /// <summary>
        ///Метoд очистки строк DataGrid
        /// </summary>
        public void ClearDataGrid()
        {
            dataGridViewAlesa.DataSource = null;

        }
        /// <summary>
        /// Метод конфигурации DataGridView. Отдельный метод для конфигурации столбцов. Через 
        //метод указывается сколько колонок в DataGridView добавлять, 
        //их заголовки, ширину, признак видимости и имя свойства/поля
        //объекта класса, записи которого будут в таблице выводиться,
        //значение из которого потребуется выводить в ячейке этой колонки.
        /// </summary>
        /// <param name="countColumn"></param>
        /// <param name=""></param>
        public void ConfigColumn(ColumnsDataGrid columnsData)
        {
            dataGridViewAlesa.ColumnCount = columnsData.CountColumn;
            for (int i = 0; i < columnsData.CountColumn; i++)
            {
                dataGridViewAlesa.Columns[i].Name = columnsData.NameColumn[i];
                dataGridViewAlesa.Columns[i].Width = columnsData.Width[i];
                dataGridViewAlesa.Columns[i].Visible = columnsData.Visible[i];
                dataGridViewAlesa.Columns[i].DataPropertyName = columnsData.PropertiesObject[i];
            }
        }
        /// <summary>
        /// Полуение объекта из строки
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetSelectedObjectIntoRow<T>()
        {
            T objectMy = (T)Activator.CreateInstance(typeof(T));
            var propertiesObj = typeof(T).GetProperties();
            foreach (var properties in propertiesObj)
            {
                bool propIsExist = false;
                int columnIndex = 0;
                for (; columnIndex < dataGridViewAlesa.Columns.Count; columnIndex++)
                {
                    if (dataGridViewAlesa.Columns[columnIndex].DataPropertyName.ToString() == properties.Name)
                    {
                        propIsExist = true;
                        break;
                    }
                }
                if (!propIsExist) { throw new Exception("can not find propertie"); };
                object value = dataGridViewAlesa.SelectedRows[0].Cells[columnIndex].Value;
                properties.SetValue(objectMy, value);
            }
            return objectMy;
        }

        /// <summary>
        ///  Заполнение DataGridView построчно
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectMy"></param>

        public void AddRow<T>(T objectMy)
        {
            int count = dataGridViewAlesa.Columns.Count;
            string[] objValue = new string[count];
            int j = 0;
            foreach (var prop in typeof(T).GetProperties())
            {
                objValue[j] = prop.GetValue(objectMy).ToString();
                Console.WriteLine(prop.Name + prop.GetValue(objectMy));
                j++;
            }
            int rowId = dataGridViewAlesa.Rows.Add();
            var row = dataGridViewAlesa.Rows[rowId];
            for (int i = 0; i < count; i++)
            {
                row.Cells[i].Value = objValue[i];
            }
        }
    }
}

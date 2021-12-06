using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyControlLibrary
{
    public partial class CheckedListBoxControl : UserControl
    {
        public CheckedListBoxControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Последний выбранный элемент
        /// </summary>
        public string CurrentItem
        {
            set
            {
                int index = checkedListBox.Items.IndexOf(value);
                if (index == -1)
                {
                    checkedListBox.Items.Add(value);
                    index = checkedListBox.Items.Count - 1;
                }
                checkedListBox.SetItemChecked(index, true);
            }
            get
            {
                return checkedListBox.SelectedItem?.ToString() ?? "";
            }
        }

        /// <summary>
        /// Добавляет строковый элемент в список
        /// </summary>
        /// <param name="item">Добавляемый строковый элемент</param>
        public void AddItem(string item)
        {
            checkedListBox.Items.Add(item);
        }

        /// <summary>
        /// Очищает весь список элементов
        /// </summary>
        public void ClearList()
        {
            checkedListBox.Items.Clear();
        }

        private event EventHandler _selectedChanged;

        /// <summary>
        /// Событие при изменении выбранного элемента
        /// </summary>
        public event EventHandler SelectedChanged
        {
            add { _selectedChanged += value; }
            remove { _selectedChanged -= value; }
        }

        private void checkedListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            _selectedChanged?.Invoke(sender, e);
        }
    }
}

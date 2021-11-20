using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComponentsAutumn
{
    public partial class TextBoxControlAlesa : UserControl
    {
        public double? ValueTextBox
        {
            get
            {
                if (checkBoxNull.Checked) return null;
                if (!CheckValueDouble())
                    throw new Exception("Ошибка не число");
                return Convert.ToDouble(textBox1.Text);

            }
            set
            {
                if (value != null)
                {
                    textBox1.Text = value.Value.ToString();
                    checkBoxNull.Checked = false;
                }
                else
                {
                    textBox1.Text = string.Empty;
                    checkBoxNull.Checked = true;
                }
            }
        }

         public event EventHandler eventHandler;

        private void TextBox_SelectedChanged(object sender, System.EventArgs e)
        {
            eventHandler.Invoke(sender, e);
        }

        /// <summary>
        /// Событие, которое вызывается при изменении элемента
        /// </summary>
        public event EventHandler SpecEvent
        {
            add { eventHandler += value; }
            remove { eventHandler += value; }
        }

        /// <summary>
        /// Проверка на вещественное число
        /// </summary>
        private bool CheckValueDouble()
        {
            string textBoxValue = textBox1.Text.ToString();
            bool match = Regex.IsMatch(textBoxValue, string.Format(@"((\d+)(\,+)(\d*))$", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
            if (match)
            {
                ValueTextBox = Convert.ToDouble(textBoxValue);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Метод инициализации компонента
        /// </summary>
        public TextBoxControlAlesa()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод обработки чекбокса поля ввода
        /// </summary>
        private void checkBoxNull_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNull.Checked)
            {
                textBox1.ReadOnly = true;
                textBox1.Clear();
            }
            else textBox1.ReadOnly = false;
        }
    }
}

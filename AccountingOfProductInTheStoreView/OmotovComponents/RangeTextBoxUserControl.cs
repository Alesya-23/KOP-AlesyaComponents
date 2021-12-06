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
    public partial class RangeTextBoxUserControl : UserControl
    {
        public RangeTextBoxUserControl()
        {
            InitializeComponent();
        }
        private int _minSymbols = 0;
        private int? _maxSymbols;

        /// <summary>
        /// Текущее значение текстового поля.
        /// Если количество символов не входит в требуемый диапозон, то выдаётся ошибка.
        /// Если максимальное количество символов не установлено, то выдаётся ошибка.
        /// </summary>
        public string CurrentText
        {
            get
            {
                if(MaxSymbols == null)
                {
                    throw new Exception("Максимальное количество символов не установлено");
                }
                if(textBox.Text.Length < MinSymbols)
                {
                    throw new Exception("Количество введённых символов меньше допустимого значения");
                }
                if (textBox.Text.Length > MaxSymbols)
                {
                    throw new Exception("Количество введённых символов больше допустимого значения");
                }

                return textBox.Text;
            }
            set
            {
                textBox.Text = value;
            }
        }

        /// <summary>
        /// Минимальное доступное количество символов в текстовом поле. 
        /// При установке значений меньше нуля, приводится к 0
        /// При установке значений больше максимального (если установленно), приводится к максимально доступному количеству символов
        /// </summary>
        public int MinSymbols
        {
            get {
                return _minSymbols;
            }
            set { 
                if (value < 0)
                {
                    _minSymbols = 0;
                }
                else if(_maxSymbols != null && _maxSymbols < _minSymbols)
                {
                    _minSymbols = (int)_maxSymbols;
                }
                else
                {
                    _minSymbols = value;
                }
            }
        }

        /// <summary>
        /// Максимальное доступное количество символов в текстовом поле. 
        /// При установке значений меньше минимального, приводится к минимально доступному количеству символов
        /// </summary>
        public int? MaxSymbols
        {
            get
            {
                return _maxSymbols;
            }
            set
            {
                if (value < _minSymbols)
                {
                    _maxSymbols = _minSymbols;
                }
                else
                {
                    _maxSymbols = value;
                }
            }
        }
    }
}

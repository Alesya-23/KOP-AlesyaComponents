using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace COP_labs
{
    public partial class UserControlListBox : UserControl
    {
        private List<string> Fields;

        private string Template = "";

        private char begin = ' ';

        private char end = ' ';

        public UserControlListBox()
        {
            InitializeComponent();
        }

        public void AddTemplate(string NewTemplate, char begin, char end)
        {
            this.begin = begin;
            this.end = end;
            string[] splitedStrings = NewTemplate.Split(begin, end);
            if (splitedStrings.Length < 3)
            {
                return;
            }
            Fields = new List<string>();
            for (int i = 0; i < splitedStrings.Length; i++)
            {
                if (i % 2 != 0)
                {
                    Fields.Add(splitedStrings[i]);
                }
            }
            Template = NewTemplate;
        }

        public int GetIndex
        {
            get
            {
                return ListBoxData.SelectedIndex;
            }
            set
            {
                if (value > -1 && value < ListBoxData.Items.Count)
                {
                    ListBoxData.SelectedIndex = value;
                }
                else
                {
                    //throw new Exception("Вне диапазона допустимых индексов списка");
                }
            }
        }

        public T GetItem<T>() where T : new()
        {
            if (ListBoxData.SelectedIndex != -1)
            {
                string item = ListBoxData.SelectedItem.ToString();
                T template = new T();

                string[] splitedStrings = item.Split(begin, end);
                if (splitedStrings.Length < 3)
                {
                    return new T();
                }
                List<string> TFields = new List<string>();
                for (int i = 0; i < splitedStrings.Length; i++)
                {
                    if (i % 2 != 0)
                    {
                        TFields.Add(splitedStrings[i]);
                    }
                }

                Type type = template.GetType();
                PropertyInfo[] props = type.GetProperties();
                FieldInfo[] fields = type.GetFields();
                //проходимся по названиям полей класса T
                foreach (var p in props)
                {
                    for (int i = 0; i < Fields.Count; i++)
                    {
                        if (p.Name.Equals(Fields[i]))
                        {
                            Type propsType = type.GetProperty(Fields[i]).PropertyType;
                            var replaceField = Convert.ChangeType(TFields[i], propsType);
                            type.GetProperty(Fields[i]).SetValue(template, replaceField);
                            break;
                        }
                    }
                }

                foreach (var f in fields)
                {
                    for (int i = 0; i < Fields.Count; i++)
                    {
                        if (f.Name.Equals(Fields[i]))
                        {
                            Type propsType = type.GetField(Fields[i]).FieldType;
                            var replaceField = Convert.ChangeType(TFields[i], propsType);
                            type.GetField(Fields[i]).SetValue(template, replaceField);
                            break;
                        }
                    }
                }
                return template;
            }
            return new T();
        }

        public void AddObjectToListBox<T>(Object obj)
        {
            for (int i = 0; i < Fields.Count; i++)
            {
                if (Fields[i].Equals(""))
                {
                    throw new Exception("Поля не заполнены");
                }
            }

            List<string> InputObjectProperty = new List<string>();
            List<string> InputObjectFields = new List<string>();

            Type type = obj.GetType();
            PropertyInfo[] props = type.GetProperties();
            FieldInfo[] fields = type.GetFields();

            foreach (var property in props)
            {
                for (int i = 0; i < Fields.Count; i++)
                {
                    if (property.Name.Equals(Fields[i]))
                    {
                        InputObjectProperty.Add(property.GetValue(obj).ToString());
                        break;
                    }
                }
            }

            foreach (var field in fields)
            {
                for (int i = 0; i < Fields.Count; i++)
                {
                    if (field.Name.Equals(Fields[i]))
                    {
                        InputObjectFields.Add(field.GetValue(obj).ToString());
                        break;
                    }
                }
            }
            string FillTemplate = Template;
            for (int i = 0; i < Fields.Count; i++)
            {
                FillTemplate = FillTemplate.Replace(Fields[i], InputObjectProperty[i]);
            }

            ListBoxData.Items.Add(FillTemplate);
        }

        public void ClearListBox()
        {
            ListBoxData.Items.Clear();
        }
    }
}
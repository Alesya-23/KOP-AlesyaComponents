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

        private string Field1 = "";

        private string Field2 = "";

        private bool isField = false;

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
            Field1 = splitedStrings[1];
            Field2 = splitedStrings[3];
            isField = true;
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
                Object field1 = splitedStrings[1];
                Object field2 = splitedStrings[3];
                Type type = template.GetType();
                PropertyInfo[] props = type.GetProperties();
                FieldInfo[] fields = type.GetFields();
                //проходимся по названиям полей класса T
                foreach (var p in props)
                {
                    if (p.Name.Equals(Field1))
                    {
                        Type propsType = type.GetProperty(Field1).PropertyType;
                        var replaceField1 = Convert.ChangeType(field1, propsType);
                        type.GetProperty(Field1).SetValue(template, replaceField1);
                    }
                    if (p.Name.Equals(Field2))
                    {
                        Type propsType = type.GetProperty(Field2).PropertyType;
                        var replaceField2 = Convert.ChangeType(field2, propsType);
                        type.GetProperty(Field2).SetValue(template, replaceField2);
                    }
                }

                foreach (var f in fields)
                {
                    if (f.Name.Equals(Field1))
                    {
                        Type propsType = type.GetField(Field1).FieldType;
                        var replaceField1 = Convert.ChangeType(field1, propsType);
                        type.GetField(Field1).SetValue(template, replaceField1);
                    }
                    if (f.Name.Equals(Field2))
                    {
                        Type propsType = type.GetField(Field2).FieldType;
                        var replaceField2 = Convert.ChangeType(field2, propsType);
                        type.GetField(Field2).SetValue(template, replaceField2);
                    }
                }
                return template;
            }
            return new T();
        }

        public void AddObjectToListBox<T>(Object obj)
        {

            if (!isField || Field1.Equals("") || Field2.Equals(""))
            {
                throw new Exception("Поля не заполнены");
            }
            string InputObjectProperty = "";
            string InputObjectFields = "";

            Type type = obj.GetType();
            PropertyInfo[] props = type.GetProperties();
            FieldInfo[] fields = type.GetFields();

            foreach (var property in props)
            {

                if (property.Name.Equals(Field1))
                {
                    InputObjectProperty = property.GetValue(obj).ToString();
                }
                if (property.Name.Equals(Field2))
                {
                    InputObjectFields = property.GetValue(obj).ToString();
                }
            }

            foreach (var field in fields)
            {
                if (field.Name.Equals(Field1))
                {
                    InputObjectProperty = field.GetValue(obj).ToString();
                }
                if (field.Name.Equals(Field2))
                {
                    InputObjectFields = field.GetValue(obj).ToString();
                }
            }
            ListBoxData.Items.Add(Template.Replace(Field1, InputObjectProperty).Replace(Field2, InputObjectFields));
        }
    }
}

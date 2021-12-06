using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace MyControlLibrary
{
    public partial class TreeViewControl : UserControl
    {
        public TreeViewControl()
        {
            InitializeComponent();
        }

        private List<string> _order = new List<string>();

        /// <summary>
        /// Возвращает значение выбранного конечного элемента в виде класса, переданного в параметре. 
        /// Если текущий элемент неконечный, то возвращается default переданного класса.
        /// Если передан неверный класс, то выдаётся ошибка.
        /// </summary>
        public T GetChoosedLeafValue<T>()
        {
            if (treeView.SelectedNode.Nodes.Count == 0)
            {
                Type type = typeof(T);
                T obj = (T)Activator.CreateInstance(type);
                TreeNode currentNode = treeView.SelectedNode;
                for (int i = _order.Count-1; i >= 0; i--)
                {
                    PropertyInfo prop = type.GetProperty(_order[i]);
                    if(prop == null)
                    {
                        throw new Exception("У класса нет необходимого атрибута");
                    }
                    prop.SetValue(obj, currentNode.Text, null);
                    currentNode = currentNode.Parent;
                }
                return obj;
            }
            else
            {
                return default;
            }
        }

        /// <summary>
        /// Индекс выбранной ветки. При установке значения меньше 0 не выбрана ни одна ветка.
        /// При установке значения больше количества веток в корне, выбранная ветка остаётся прежней
        /// При отсутствии выбранного возвращается -1
        /// </summary>
        public int IndexChoosed {
            get
            {
                return treeView.SelectedNode?.Index ?? -1;
            }
            set
            {
                if(value < 0)
                {
                    treeView.SelectedNode = null;
                    return;
                }
                if (value < treeView.Nodes.Count)
                {
                    treeView.SelectedNode = treeView.Nodes[value];
                }
            }
        }

        /// <summary>
        /// Установка иерархии свойств. 
        /// </summary>
        /// <param name="order">Список свойств от важного к менее важному</param>
        public void SetOrder(List<string> order)
        {
            _order = order;
        }

        /// <summary>
        /// Добавление объекта со свойствами к дереву
        /// </summary>
        /// <param name="obj">Объект со свойствами</param>
        public void Add(Object obj)
        {
            Type type = obj.GetType();
            TreeNodeCollection currentNode = treeView.Nodes;
            foreach(string item in _order)
            {
                PropertyInfo info = type.GetProperty(item);
                if(info != null)
                {
                    string value = info.GetValue(obj).ToString();
                    TreeNode treeNode = new TreeNode(value)
                    {
                        Name = value
                    };
                    if (!currentNode.ContainsKey(value))
                    {
                        currentNode.Add(treeNode);
                    }
                    currentNode = currentNode[currentNode.IndexOfKey(value)].Nodes;
                }
            }
        }
    }
}

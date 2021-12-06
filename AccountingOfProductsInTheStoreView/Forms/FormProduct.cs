using AccountingOfProductsInTheStoreView.Logic.BindingModels;
using AccountingOfProductsInTheStoreView.Logic.BusinessLogics;
using AccountingOfProductsInTheStoreView.Logic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AccountingOfProductsInTheStoreView.Forms
{
    public partial class FormProduct : Form
    {
        public int Id { set { id = value; } }
        private readonly ProductLogic productLogic = new ProductLogic();
        private readonly UnitOfMeasurementLogic unitOfMeasurementLogic = new UnitOfMeasurementLogic();
        private int? id;

        public FormProduct()
        {
            InitializeComponent();
            TextBoxCountry.CurrentText = "dmvfkvdf";
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Введите название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxFirstSupplier.Text))
            {
                textBoxFirstSupplier.Text = "Отсутсвует";
            }
            if (string.IsNullOrEmpty(textBoxSecondSupplier.Text))
            {
                textBoxSecondSupplier.Text = "Отсутсвует";
            }
            if (string.IsNullOrEmpty(textBoxThirdSupplier.Text))
            {
                textBoxThirdSupplier.Text = "Отсутсвует";
            }
            if (string.IsNullOrEmpty(TextBoxCountry.CurrentText.ToString()))
            {
                MessageBox.Show("Введите страну", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(listBoxControlAlesa1.ValueList))
            {
                MessageBox.Show("Выберите единицу измерения", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                ProductBindingModel product = new ProductBindingModel
                {
                    Id = id,
                    name = textBoxName.Text,
                    Country = TextBoxCountry.CurrentText,
                    SupplierOne = textBoxFirstSupplier.Text,
                    SupplierTwo = textBoxSecondSupplier.Text,
                    SupplierThree = textBoxThirdSupplier.Text,
                    UnitOfMeasurement = listBoxControlAlesa1.ValueList.ToString(),
                };
                if (product.Id.HasValue)
                {
                    productLogic.Update(product);
                }
                else
                {
                    productLogic.Create(product);
                }

                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            TextBoxCountry.MinSymbols = 10;
            TextBoxCountry.MaxSymbols = 50;
            List<UnitOfMeasurementViewModel> list = unitOfMeasurementLogic.Read(null);
            List<String> listStr = new List<String>();
            foreach (var name in list)
            {
                listStr.Add(name.Name);
                listBoxControlAlesa1.AddItem(name.Name);
            }

            if (id.HasValue)
            {
                try
                {
                    var view = productLogic.Read(new ProductBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.name;
                        TextBoxCountry.CurrentText = view.Country;
                        listBoxControlAlesa1.ValueList = view.UnitOfMeasurement;
                        textBoxSecondSupplier.Text = view.SupplierTwo;
                        textBoxFirstSupplier.Text = view.SupplierTwo;
                        textBoxThirdSupplier.Text = view.SupplierThree;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
    }
}
using AccountingOfProductInTheStoreView.Logic.BindingModels;
using AccountingOfProductInTheStoreView.Logic.BusinessLogics;
using AccountingOfProductInTheStoreView.Logic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AccountingOfProductInTheStoreView.Forms
{
    public partial class FormUnitOfMeasurement : Form
    {
        private readonly UnitOfMeasurementLogic logic = new UnitOfMeasurementLogic();
        List<UnitOfMeasurementViewModel> list;

        public FormUnitOfMeasurement()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            try
            {
                list = logic.Read(null);
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Insert)
            {
                if (dataGridView.Rows.Count == 0)
                {
                    list.Add(new UnitOfMeasurementViewModel());
                    dataGridView.DataSource = new List<UnitOfMeasurementViewModel>(list);
                    dataGridView.CurrentCell = dataGridView.Rows[0].Cells[1];
                    return;
                }
                if (dataGridView.Rows[dataGridView.Rows.Count - 1].Cells[1].Value != null)
                {
                    list.Add(new UnitOfMeasurementViewModel());
                    dataGridView.DataSource = new List<UnitOfMeasurementViewModel>(list);
                    dataGridView.CurrentCell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells[1];
                    return;
                }
            }
            if (e.KeyData == Keys.Delete)
            {
                if (MessageBox.Show("Вы действительно хотите удалить?", "Предупреждение",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    logic.Delete(new UnitOfMeasurementBindingModel() { Id = (int)dataGridView.CurrentRow.Cells[0].Value });
                    list = logic.Read(null);
                    dataGridView.DataSource = new List<UnitOfMeasurementViewModel>(list);
                }

            }
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (String.IsNullOrEmpty(((DataGridView)sender).CurrentCell.EditedFormattedValue.ToString()))
            {

                if (dataGridView.CurrentRow.Cells[0].Value != null)
                {
                    var listDBM = logic.Read(new UnitOfMeasurementBindingModel() { Id = (int)dataGridView.CurrentRow.Cells[0].Value });
                    dataGridView.CurrentRow.Cells[1].Value = ((UnitOfMeasurementViewModel)listDBM[0]).Name;
                }

            }
            else
            {
                if (dataGridView.CurrentRow.Cells[0].Value != null)
                {
                    logic.Update(new UnitOfMeasurementBindingModel()
                    {
                        Id = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value),
                        Name = (string)dataGridView.CurrentRow.Cells[1].EditedFormattedValue
                    });
                }
                else
                {
                    logic.Create(new UnitOfMeasurementBindingModel()
                    {
                        Name = (string)dataGridView.CurrentRow.Cells[1].EditedFormattedValue
                    });
                }
            }

            LoadData();
        }

        private void FormСourse_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
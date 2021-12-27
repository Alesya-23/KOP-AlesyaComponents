using AccountingOfProductInTheStoreView.Logic.ViewModels;
using ClassLibraryPluginsConfigurations.Interfaces;
using ClassLibraryPluginsConfigurations.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnvisualComponentsAlesa.HelperModels;

namespace AccountingOfProductInTheStoreView.Forms
{
    public partial class FormChooseReport : Form
    {
        private Manager manager;
        public FormChooseReport(Manager manager)
        {
            InitializeComponent();
            this.manager = manager;
            FillCombobox();
        }

        private void FillCombobox()
        {
            if (manager.Plugins != null && manager.Plugins.Count() != 0)
            {
                List<string> list = new List<string>();

                int i = 0;
                foreach (var header in manager.Plugins)
                {
                    if (header is ICreateWordDocument)
                    {
                        list.Add(manager.Headers[i]);
                    }
                    i++;
                }
                comboBoxChoose.Items.AddRange(list.ToArray());
                comboBoxChoose.Text = comboBoxChoose.Items[0].ToString();
                comboBoxChoose.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (comboBoxChoose.Text.Equals(manager.Plugins.FirstOrDefault(p => p is ICreateWordDocument).PluginName))
            {
                try
                {

                    WordInfoConfigModel wordInfoConfigModel = new WordInfoConfigModel();

                    using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
                    {
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            wordInfoConfigModel = new WordInfoConfigModel()
                            {
                                FileName = dialog.FileName,
                                Title = "Title"
                            };
                        }
                    }

                    AbstractModel abstractModel = new AbstractModel() { WordInfoConfigModel = wordInfoConfigModel };

                    manager.Functions[manager.Plugins.FirstOrDefault(p => p is ICreateWordDocument).PluginName](abstractModel);

                    var plugin = manager.Plugins.FirstOrDefault(p => p is ICreateWordDocument) as ICreateWordDocument;

                    plugin.Execute(new AbstractModel { WordInfoConfigModel = wordInfoConfigModel });

                    plugin.AddImage(new ImageConfigModel
                    {
                        Title = "title",
                        Path = "C:\\Users\\aleca\\Downloads\\1-4.png"
                    });

                    plugin.AddParagraph(new ParagraphConfigModel()
                    {
                        Text = "Text 1Text 1Text 1Text 1Text 1Text 1Text 1Text 1Text 1Text 1Text 1Text 1Text 1Text 1Text 1Text 1Text 1Text 1Text 1",
                        Bold = true,
                        FontSize = 28
                    });

                    plugin.AddTable(new TableConfigModel<ProductViewModel>
                    {
                        Title = "Заголовок",
                        ColumnInfo = new List<ColumnInfoConfigModel>
                    {
                        new ColumnInfoConfigModel
                        {
                            PropertyName = "Id",
                            Title = "Айди",
                            Width = 50
                        },
                        new ColumnInfoConfigModel
                        {
                            PropertyName = "name",
                            Title = "Название",
                            Width = 50
                        },
                    },
                        Objects = new List<ProductViewModel>
                    {
                        new ProductViewModel
                        {
                            Id = 1,
                            name =  "ввввв"
                        },
                        new ProductViewModel
                        {
                            Id = 2,
                            name =  "фывфы"
                        },
                        new ProductViewModel
                        {
                            Id = 3,
                            name =  "ddd"
                        },
                        new ProductViewModel
                        {
                            Id = 14,
                            name =  "ян",
                        }
                    }
                    });

                    plugin.AddParagraph(new ParagraphConfigModel()
                    {
                        Text = "текст 2текст 2текст 2текст 2текст 2текст 2текст 2текст 2текст 2текст 2текст 2текст 2текст 2текст 2текст 2",
                        Bold = false,
                        FontSize = 20
                    });

                    List<ChartData> data = new List<ChartData>();
                    data.Add(new ChartData { SeriesName = "csscdscd", Data = new int[] { 1, 2, 8 } });
                    data.Add(new ChartData { SeriesName = "aaa", Data = new int[] { 1, 12, 13 } });
                    data.Add(new ChartData { SeriesName = "q234", Data = new int[] { 1, 5, 7, 0 } });
                    LegendPosition legend = new LegendPosition();
                    ChartConfigModel chartConfigModel = new ChartConfigModel();
                    chartConfigModel.ChartTitle = "gistagram";
                    chartConfigModel.Title = "gistag";
                    chartConfigModel.LegendPosition = LegendPosition.Bottom;
                    chartConfigModel.ChartData = data;
                    plugin.AddChart(chartConfigModel );

                    plugin.SaveDocument();

                    MessageBox.Show("Отчет сформирован успешно", "Сообщение",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void comboBoxChoose_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

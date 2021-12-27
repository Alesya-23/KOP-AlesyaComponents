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
using TLSharp;
using TLSharp.Core;

namespace AccountingOfProductInTheStoreView.Forms
{
    public partial class FormAuth : Form
    {
        private SenderManager manager;
        private SendMessageModel model;

        private string AcsessToken;

        private IPlugin _messenger;
        public FormAuth(SenderManager manager)
        {
            InitializeComponent();
            this.manager = manager;
            List<string> nameSenderPlugins = new List<string>();
            nameSenderPlugins.Add("Telegram");
            nameSenderPlugins.Add("SenderMessagePluginVk");
            nameSenderPlugins.Add("SenderMessageViber");
            foreach (var plugin in manager.Plugins)
            {
                foreach (var pl in nameSenderPlugins)
                {
                    if (pl.Equals(plugin.Key))
                    {
                        comboBoxChoose.Items.Add(plugin.Key);
                    }
                }
            }
        }

        private async void buttonAuth_Click(object sender, EventArgs e)
        {
            _messenger = manager.Plugins[comboBoxChoose.SelectedItem.ToString()];
            if (_messenger.PluginName == "Вконтакте")
            {
                ISendMessageVk sendMessageVk;
                sendMessageVk = (ISendMessageVk)manager.Plugins[comboBoxChoose.SelectedItem.ToString()];
                var persons = sendMessageVk.Connect(new SenderConfiguratorModel
                {
                    AccessToken = textBoxToken.Text
                });

                AcsessToken = textBoxToken.Text;
                dataGridView.Columns.Add("id", "Id");
                dataGridView.Columns.Add("name", "ФИО");
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                foreach (var person in persons.Where(x => x.Name.Contains("Демянчук")).ToList())
                {
                    dataGridView.Rows.Add(person.Id, person.Name);
                }
                if (sendMessageVk.Errors.Count() > 0)
                {
                    foreach (var error in sendMessageVk.Errors)
                    {
                        MessageBox.Show(error.Message, error.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count < 1)
            {
                MessageBox.Show("Выберите получателя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            model = new SendMessageModel
            {
                RecepientId = long.Parse(dataGridView.SelectedRows[0].Cells[0].Value.ToString()),
                Body = textBox.Text
            };
            foreach (var plugin in manager.Plugins)
            {
                if (_messenger.PluginName == "Вконтакте")
                {
                    ISendMessageVk sendMessageVk;
                    sendMessageVk = (ISendMessageVk)manager.Plugins[comboBoxChoose.SelectedItem.ToString()];
                    var persons = sendMessageVk.Connect(new SenderConfiguratorModel
                    {
                        AccessToken = AcsessToken

                    }) ;
                    sendMessageVk.SendMessage(model);
                    if (sendMessageVk.Errors.Count() > 0)
                    {
                        foreach (var error in sendMessageVk.Errors)
                        {
                            MessageBox.Show(error.Message, error.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        return;
                    }
                    MessageBox.Show("Сообщение отправлено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

    }
}

using System.Windows.Forms;

namespace AccountingOfProductInTheStoreView.Forms
{
    public partial class FormMessage : Form
    {
        //[ImportMany(typeof(ISenderMessage))]
        //private IEnumerable<ISenderMessage> _senderMessages { get; set; }

        //private SendMessageModel model;

        public FormMessage()
        {
            InitializeComponent();
        }

        private void buttonSend_Click(object sender, System.EventArgs e)
        {

        }

        //private void FormSendMessage_Load(object sender, EventArgs e)
        //{
        //    textBox.Text = "От 'Склад продуктов'\n На склад поступили новые товары. Заходи за покупками.";
        //    ImportPlugin();
        //    foreach (var plugin in _senderMessages)
        //    {
        //        var persons = plugin.Connect(new SenderConfiguratorModel
        //        {
        //            AccessToken = "d0dbf20537d470de603fa51a13dd110773836e3a16f2fb8fd5dd0ebe35f4fe93358ed0dd1e11ec7005ec1"
        //        });
        //        if (plugin.Errors.Count() > 0)
        //        {
        //            foreach (var error in plugin.Errors)
        //            {
        //                MessageBox.Show(error.Message, error.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }

        //        dataGridView.Columns.Add("id", "Id");
        //        dataGridView.Columns.Add("name", "ФИО");
        //        dataGridView.Columns[0].Visible = false;
        //        dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //        foreach (var person in persons.Where(x => x.Name.Contains("Демянчук")).ToList())
        //        {
        //            dataGridView.Rows.Add(person.Id, person.Name);
        //        }
        //    }
        //}

        //public void ImportPlugin()
        //{
        //    var catalog = new AggregateCatalog();
        //    var path = Path.Combine(Directory.GetCurrentDirectory(), "SenderMessage");
        //    catalog.Catalogs.Add(new DirectoryCatalog(path));
        //    var container = new CompositionContainer(catalog);
        //    container.ComposeParts(this);
        //}

        //private void buttonSend_Click(object sender, EventArgs e)
        //{
        //    if (dataGridView.SelectedRows.Count < 1)
        //    {
        //        MessageBox.Show("Выберите получателя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    model = new SendMessageModel
        //    {
        //        RecepientId = long.Parse(dataGridView.SelectedRows[0].Cells[0].Value.ToString()),
        //        Body = textBox.Text
        //    };

        //    foreach (var plugin in _senderMessages)
        //    {
        //        plugin.SendMessage(model);
        //        if (plugin.Errors.Count() > 0)
        //        {
        //            foreach (var error in plugin.Errors)
        //            {
        //                MessageBox.Show(error.Message, error.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //            return;
        //        }
        //        MessageBox.Show("Сообщение отправлено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        //private void labelReceiver_Click(object sender, EventArgs e)
        //{

        //}

        //private void labelMsg_Click(object sender, EventArgs e)
        //{

        //}

        //private void textBox_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //        }
    }
}

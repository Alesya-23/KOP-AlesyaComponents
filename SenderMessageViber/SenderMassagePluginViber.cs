using ClassLibraryPluginsConfigurations.Interfaces;
using ClassLibraryPluginsConfigurations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viber.Bot;

namespace SenderMessageViber
{
    public class SenderMassagePluginViber : ISenderMessageViber
    {
        /// <summary>
        /// Список ошибок
        /// </summary>
        /// 
        private string _authToken;
        private string _webhookUrl;
        private string _adminId;
        private IViberBotClient _viberBotClient;
        private List<(string, string)> some_errors = new List<(string, string)>();

        /// <summary>
        /// Получить список ошибок
        /// </summary>
        public IEnumerable<(string Title, string Message)> Errors => some_errors;

        public string PluginName => "Viber";

        /// <summary>
        /// Посмотреть некоторую информацию про бота
        /// </summary>
        /// <param name="config"> Конфиг бота </param>
        /// <returns></returns>
        public IEnumerable<(string Title, string Message)> Connect(SenderConfiguratorModel config)
        {

            _authToken = config.authtoken;
            _webhookUrl = config.webhookUrl;
            _adminId = config.adminId;

            _viberBotClient = new ViberBotClient(_authToken);
            var subscribers = new List<(string Id, string Name)>();

            return subscribers;
        }

        public void Execute(AbstractModel abstractModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Отправить сообщение пользователю Viber
        /// </summary>
        /// <param name="message"> Модель сообщения </param>
        public void SendMessage(SendMessageModel message)
        {
            var result =  _viberBotClient.SendTextMessageAsync(new TextMessage
            {
                Receiver = _adminId,
                Sender = new UserBase
                {
                    Name = "Smbdy"
                },
                Text = "Hi!:)"
            });
            return;
        }
    }
}


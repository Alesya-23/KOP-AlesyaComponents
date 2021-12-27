using ClassLibraryPluginsConfigurations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPluginsConfigurations.Interfaces
{
    public interface ISendMessageVk : IPlugin
    {
        /// <summary>
        /// Перечень ошибок
        /// </summary>
        IEnumerable<(string Title, string Message)> Errors { get; }
        /// <summary>
        /// Подключение к мессенджеру
        /// </summary>
        /// <param name="config"></param>
        IEnumerable<(string Id, string Name)> Connect(SenderConfiguratorModel config);
        /// <summary>
        /// Отправка сообщения
        /// </summary>
        /// <param name="message"></param>
        void SendMessage(SendMessageModel message);
    }
}

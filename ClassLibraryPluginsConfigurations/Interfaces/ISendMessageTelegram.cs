using ClassLibraryPluginsConfigurations.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using TLSharp.Core;

namespace ClassLibraryPluginsConfigurations.Interfaces
{
    /// <summary>
    /// Рассылка сообщений через Телеграм
    /// </summary>
    public interface ISendMessageTelegram : IPlugin
    {
        /// <summary>
        /// Подключение к мессенджеру
        /// </summary>
        /// <param name="config"></param>
        Task<TelegramClient> Connect(SenderConfiguratorModel config);
        /// <summary>
        /// Отправка сообщения
        /// </summary>
        /// <param name="message"></param>
        void SendMessage(SendMessageModel message);
    }
}
using ClassLibraryPluginsConfigurations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPluginsConfigurations.Interfaces
{
    public interface ISenderMessageViber  : IPlugin { 
        /// <summary>
                                           /// Перечень ошибок
                                           /// </summary>
    IEnumerable<(string Title, string Message)> Errors { get; }

    /// <summary>
    /// Подключение к мессенджеру
    /// </summary>
    /// <param name="config"></param>
    /// <returns></returns>
    IEnumerable<(string Title, string Message)> Connect(SenderConfiguratorModel config);

    /// <summary>
    /// Отправка сообщения
    /// </summary>
    /// <param name="message">сообщение</param>
    void SendMessage(SendMessageModel message);

}

}

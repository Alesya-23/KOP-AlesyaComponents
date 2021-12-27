using ClassLibraryPluginsConfigurations.Interfaces;
using ClassLibraryPluginsConfigurations.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace SenderMessagePluginVk
{
    [Export(typeof(ISendMessageVk))]
    public class SenderMessagePluginVk : ISendMessageVk
    {
        VkApi _api;

        List<(string Title, string Message)> ErrorsData = new List<(string Title, string Message)>();

        public SenderMessagePluginVk() { }

        public IEnumerable<(string Title, string Message)> Errors
        {
            get { return ErrorsData; }
        }

        public string PluginName => "Вконтакте";

        public IEnumerable<(string Id, string Name)> Connect(SenderConfiguratorModel config)
        {
            ErrorsData.Clear();

            var subscribers = new List<(string Id, string Name)>();

            _api = new VkApi();

            try
            {
                _api.Authorize(new ApiAuthParams
                {
                    AccessToken = config.AccessToken
                });
            }
            catch (Exception ex)
            {
                ErrorsData.Add(("Не удалось авторизоваться", ex.Message));
            }

            VkCollection<User> friends = null;

            try
            {
                friends = _api.Friends.Get(new FriendsGetParams
                {
                    UserId = _api.UserId,
                    Fields = ProfileFields.All,
                }, false);
            }
            catch (Exception ex)
            {
                ErrorsData.Add(("Ошибка добавления пользователй", ex.Message));
            }

            if (friends != null)
            {
                foreach (var friend in friends)
                {
                    subscribers.Add((friend.Id.ToString(), $"{friend.FirstName} {friend.LastName}"));
                }
            }

            return subscribers;
        }

        public void Execute(AbstractModel abstractModel)
        {
            if (abstractModel.SendMessageModel != null)
            {
                SendMessage(abstractModel.SendMessageModel);
            }

        }

        public void SendMessage(SendMessageModel message)
        {
            ErrorsData.Clear();

            Random rnd = new Random();
            try
            {
                _api.Messages.Send(new MessagesSendParams
                {
                    RandomId = rnd.Next(100000, 1000000000),
                    UserId = message.RecepientId,
                    Message = message.Body
                });
            }
            catch (Exception ex)
            {
                ErrorsData.Add(("Ошибка отправки сообщения", ex.Message));
            }
        }
    }
}
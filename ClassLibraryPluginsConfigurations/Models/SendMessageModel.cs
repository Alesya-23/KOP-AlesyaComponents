
namespace ClassLibraryPluginsConfigurations.Models
{
    public class SendMessageModel
    {
        public string Code { get; set; }
        public string Text { get; set; }
        public string RecipientPhoneNumber { get; set; }
        public string Hash { get; set; }

        //VK
        public long? RecepientId { get; set; }

        public string Body { get; set; }
    }
}
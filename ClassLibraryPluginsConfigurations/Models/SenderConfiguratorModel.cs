
namespace ClassLibraryPluginsConfigurations.Models
{
    public class SenderConfiguratorModel
    {
        public int apiId { get; set; }
        public string apiHash { get; set; }
        public string phoneNumber { get; set; }

        public string AccessToken { get; set; }


        public string authtoken { get; set; }
        public string webhookUrl { get; set; }
        public string adminId { get; set; }
    }
}
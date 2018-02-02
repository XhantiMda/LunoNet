namespace LunoNet.Network
{
    public class Configuration
    {
        public Configuration(string api_key_secret, string api_key_id, string api_key_pin)
        {
            Api_Key_Secret = api_key_secret;
            Api_Key_Id = api_key_id;
            Api_Key_Pin = api_key_pin;
        }

        public string Api_Key_Secret { get; set; }
        public string Api_Key_Id { get; set; }
        public string Api_Key_Pin { get; set; }
    }
}

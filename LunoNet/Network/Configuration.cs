namespace LunoNet.Network
{
    /// <summary>
    /// The LunoApi Authentication credentials.
    /// </summary>
    public class Configuration
    {
        public Configuration(string api_key_secret, string api_key_id)
        {
            Api_Key_Secret = api_key_secret;
            Api_Key_Id = api_key_id;
        }

        public string Api_Key_Secret { get; }
        public string Api_Key_Id { get; }

    }
}

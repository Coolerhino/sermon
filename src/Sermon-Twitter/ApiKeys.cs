namespace Sermon_Twitter
{
    public class ApiKeys
    {
        public string ConsumerKey { get; set; }
        public string ConsumerKeySecret { get; set; }
        public string AccessToken { get; set; }
        public string AccessTokenSecret { get; set; }

        public ApiKeys(string consumerKey, string consumerKeySecret, string accessToken, string accessTokenSecret)
        {
            ConsumerKey = consumerKey;
            ConsumerKeySecret = consumerKeySecret;
            AccessToken = accessToken;
            AccessTokenSecret = accessTokenSecret;
        }
    }
}
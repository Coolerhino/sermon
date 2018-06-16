using System;
using TweetSharp;

namespace Sermon_Twitter
{
    public class TwitterApi
    {

        private TwitterService _twitterService;
        public TwitterApi(ApiKeys keys)
        {
            _twitterService = new TwitterService(keys.ConsumerKey, keys.ConsumerKeySecret, keys.AccessToken, keys.AccessTokenSecret);
        }

        public void GiveMePopeTweets()
        {
            var popeTweets =
                _twitterService.ListTweetsOnUserTimeline(
                    new ListTweetsOnUserTimelineOptions() {ScreenName = "Pontifex", Count = 50});
            foreach (var tweet in popeTweets)
            {
                Console.WriteLine(tweet.Text);
            }
        }
    }
}
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
//dodaj funkcje ktora przyjmuje najnowszy id tweeta ktory jest w bazie danych i pobiera tylko nowsze
//dodaj funkcje z parametrem w zaleznosci od jezyka

        public void GiveMePopeTweets(string screenName = "Pontifex")
        {
            // en, pl, it, es, lt, ar(tu bedzie hardkor), fr, de, pt
            //get pope twitter username from that language
            var name = screenName;
            var popeTweets =
                _twitterService.ListTweetsOnUserTimeline(
                    new ListTweetsOnUserTimelineOptions() {ScreenName = screenName, Count = 50});
            foreach (var tweet in popeTweets)
            {
                Console.WriteLine(tweet.Text);
            }
        }
    }
}
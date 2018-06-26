using System;
using System.Collections.Generic;
using System.Linq;
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

            //foreach (var tweet in popeTweets)
            //{
            //    Console.WriteLine(tweet.Text);
            //}
        }

        public List<string> GiveMeMostRecentTweets(string screenName = "Pontifex")
        {
            var popeTweets =
                _twitterService.ListTweetsOnUserTimeline(
                    new ListTweetsOnUserTimelineOptions() { ScreenName = screenName, Count = 200});
            var list = new List<string>();
            foreach (var item in popeTweets)
            {
                list.Add(item.Text);
            }

            return list;
        }
    }
}
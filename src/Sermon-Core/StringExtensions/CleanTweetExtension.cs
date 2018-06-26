using System.Text;
using System.Text.RegularExpressions;

namespace Sermon_Core.StringExtensions
{
    public static class CleanTweetExtension
    {
        public static string CleanTweet(this string tweet)
        {
            var matches = Regex.Matches(tweet, @"(?<!\w)#\w+");
            foreach (Match match in matches)
            {
                tweet = tweet.Replace(match.Value, "");
            }
            //var linkParser = new Regex(@"\b(?:https?://|www\.)\S+\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            //var linkParse = new Regex(@"((http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?)");
            var linkParse = new Regex(@"(http|https):\/\/[\w\-_]+(\.[\w\-_]+)+[\w\-\.,@?^=%&amp;:\/~‌​\+#]*[\w\-\@?^=%&amp‌​;\/~\+#]");
            foreach (Match match in linkParse.Matches(tweet))
            {
                tweet = tweet.Replace(match.Value, "");
            }
            return tweet;
        }
    }
}
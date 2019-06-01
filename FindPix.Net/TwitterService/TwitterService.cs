using System.Collections.Generic;
using Tweetinvi;

namespace TwitterService
{
    public static class TwitterService
    {

        static TwitterService()
        {
            Auth.SetUserCredentials("wwpKDzDBNJbwiR7eorCDgd9qD", "4RhaaCI6NRWqA6ozgdt17kXq8G6TUfgvFM4AcVSsYyD8mQZUDp",
              "2178584198-O5Toi9sCNAGPiFUk37frEDQYO3bk9AKWDzVOsXG", "75zsGEAFDJGv0jGND5AWDlrMSi5SvLqFYAXOOofhVv0mC");
            //var authenticatedUser = User.GetAuthenticatedUser();
            //if (authenticatedUser == null) // Something went wrong but we don't know what
            //{
            //    // We can get the latest exception received by Tweetinvi
            //    var latestException = ExceptionHandler.GetLastException();
            //    Trace.WriteLine("The following error occured : '{0}'", latestException.TwitterDescription);
            //}

            //Trace.WriteLine(authenticatedUser);
        }

        public static IEnumerable<string> FindTweets(string keyword)
        {
            foreach (var tweet in Search.SearchTweets(keyword))
            {
                yield return tweet.Text;
            }
        }
    }
}
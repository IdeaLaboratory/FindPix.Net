using System.Collections.Generic;
using System.Linq;

namespace FindPix.Net.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        #region Singleton
        private MainWindowViewModel()
        {
        }

        private static MainWindowViewModel instance;

        public static MainWindowViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainWindowViewModel();
                }

                return instance;
            }
        }

        #endregion

        #region fields
        public string AppTitle { get; set; } = "FindFix.Net";

        string _messages = "Stats OK";
        public string Messages
        {
            get
            {
                return _messages;
            }
            set
            {
                _messages = value;
                OnPropertyChanged("Messages");
            }
        }

        private string searchString = "nature";

        public string SearchString
        {
            get { return searchString; }
            set { searchString = value; }
        }

        List<string> images = new List<string>();
        public List<string> Images
        {
            get
            {
                return images;
            }
            set
            {
                images = value;
                OnPropertyChanged();
            }
        }

        List<string> items = new List<string>();
        public List<string> Tweets
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
                OnPropertyChanged();
            }
        }

        #endregion

        internal void ExecuteFindPictures()
        {
            var imgs = FlickrService.FlickrService.FindPics(SearchString);
            if (imgs == null || imgs.Count() == 0)
            {
                Messages = "No pic found";
                return;
            }
            Images = imgs.ToList();
        }

        internal void ExecuteFindTweets()
        {
            var tweets = TwitterService.TwitterService.FindTweets(searchString);
            if (tweets == null || tweets.Count() == 0)
            {
                Messages = "No tweet found";
                return;
            }
            Tweets = tweets.ToList();
        }
    }
}
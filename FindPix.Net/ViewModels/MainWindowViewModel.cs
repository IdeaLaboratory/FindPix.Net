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

        List<string> _images = new List<string>();
        public List<string> Images
        {
            get
            {
                return _images;
            }
            set
            {
                _images = value;
                OnPropertyChanged();
            }
        }

        #endregion

        internal void ExecuteSearch()
        {
            var imgs = FlickrService.FlickrService.FindPics(SearchString);
            if (imgs == null)
            {
                Messages = "No result found";
                return;
            }

            Images = imgs.ToList();
        }
    }
}
using System;

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

        #endregion

        internal void ExecuteSearch()
        {
            throw new NotImplementedException();
        }
    }
}
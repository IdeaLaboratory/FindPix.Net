using FindPix.Net.ViewModels;
using System;
using System.Threading;
using System.Windows.Input;

namespace FindPix.Net.Commands
{
    internal class SearchCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Thread flickr = new Thread(delegate ()
            {
                MainWindowViewModel.Instance.ExecuteFindPictures();
            });
            flickr.Start();

            Thread twitter = new Thread(delegate ()
            {
                MainWindowViewModel.Instance.ExecuteFindTweets();
            });
            twitter.Start();
        }
    }
}

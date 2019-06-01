using FindPix.Net.ViewModels;
using System;
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
            MainWindowViewModel.Instance.ExecuteFindPictures();
            MainWindowViewModel.Instance.ExecuteFindTweets();
        }
    }
}

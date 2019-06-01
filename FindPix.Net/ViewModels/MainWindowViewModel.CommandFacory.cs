using FindPix.Net.Commands;
using System.Windows.Input;

namespace FindPix.Net.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        SearchCommand _searchCommand;
        public ICommand GetSearchCommand
        {
            get
            {
                return _searchCommand ?? (_searchCommand = new SearchCommand());
            }
        }
    }
}
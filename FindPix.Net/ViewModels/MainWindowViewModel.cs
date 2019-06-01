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

        public string AppTitle { get; set; } = "FindFix.Net";
    }
}
using ModernStyledApplication.MVVM.View;
using ModernVPN.Core;
using System.Windows;

namespace ModernStyledApplication.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        /* Commands */
        public RelayCommand MoveWindowCommand { get; set; }
        public RelayCommand ShutdownWindowCommand { get; set; }
        public RelayCommand MaximizeWindowCommand { get; set; }
        public RelayCommand MinimizeWindowCommand { get; set; }
        public RelayCommand ShowHomeView { get; set; }
        public RelayCommand ShowSettingsView { get; set; }
        public RelayCommand ShowUserView { get; set; }

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set 
            {
                _currentView = value; 
                OnPropertyChanged();
            }
        }

        public HomeViewModel HomeVM { get; set; }
        public SettingsViewModel SettingsVM { get; set; }
        public UserViewModel UserVM { get; set; }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            SettingsVM = new SettingsViewModel();
            UserVM = new UserViewModel();
            CurrentView = HomeVM;

            Application.Current.MainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            MoveWindowCommand = new RelayCommand(o => { Application.Current.MainWindow.DragMove(); });
            ShutdownWindowCommand = new RelayCommand(o => { Application.Current.Shutdown(); });
            MaximizeWindowCommand = new RelayCommand(o => 
            {
                if(Application.Current.MainWindow.WindowState == WindowState.Maximized)
                    Application.Current.MainWindow.WindowState = WindowState.Normal; 
                else
                    Application.Current.MainWindow.WindowState = WindowState.Maximized;
            });
            MinimizeWindowCommand = new RelayCommand(o => { Application.Current.MainWindow.WindowState = WindowState.Minimized; });

            ShowHomeView = new RelayCommand(o => { CurrentView = HomeVM; });
            ShowSettingsView = new RelayCommand(o => { CurrentView = SettingsVM; });
            ShowUserView = new RelayCommand(o => { CurrentView = UserVM; });
        }
    }
}

using BarbellPro.Application.Models.Services;
using BarbellPro.Application.Utilities;
using System.Windows.Input;
using System.Windows.Media;

namespace BarbellPro.Application.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ImageSource appIconImage;
        public ImageSource AppIconImage
        {
            get { return appIconImage; }
            private set { appIconImage = value; }
        }

        private object? _currentView;
        public object? CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand NavigateToCalculatorViewCommand { get; set; }
        public ICommand NavigateToLoadoutViewCommand { get; set; }
        public ICommand NavigateToSettingsViewCommand { get; set; }

        private void NavigateToCalculatorView(object obj) => CurrentView = new CalculatorViewModel();
        private void NavigateToLoadoutView(object obj) => CurrentView = new LoadoutViewModel();
        private void NavigateToSettingsView(object obj) => CurrentView = new SettingsViewModel();

        public MainWindowViewModel()
        {
            // NavCommands
            NavigateToCalculatorViewCommand = new RelayCommand(NavigateToCalculatorView);
            NavigateToLoadoutViewCommand = new RelayCommand(NavigateToLoadoutView);
            NavigateToSettingsViewCommand = new RelayCommand(NavigateToSettingsView);

            // Startup UserControl
            CurrentView = new CalculatorViewModel();

            // Load AppIconImage
            appIconImage = ImageManagerService.LoadAppIconImage();
        }
    }
}

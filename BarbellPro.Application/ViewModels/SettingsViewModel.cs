using BarbellPro.Application.Models;
using BarbellPro.Application.Utilities;

namespace BarbellPro.Application.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private readonly SettingsModel _settingsModel;
        
        public string Message
        {
            get { return _settingsModel.Status; }
            set { _settingsModel.Status = value; OnPropertyChanged(); }
        }

        public SettingsViewModel() 
        {
            _settingsModel = new SettingsModel();
            Message = "!!!UNDER CONSTRUCTION!!!";
        }
    }
}

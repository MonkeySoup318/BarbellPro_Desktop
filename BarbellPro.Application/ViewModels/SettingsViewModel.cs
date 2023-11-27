using BarbellPro.Application.Models;
using BarbellPro.Application.Utilities;
using System;

namespace BarbellPro.Application.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private readonly SettingsModel _settingsModel;
        
        public string? Message
        {
            get { return _settingsModel.SettingPlaceholderText; }
            set { _settingsModel.SettingPlaceholderText = value; OnPropertyChanged(); }
        }

        public SettingsViewModel() 
        {
            _settingsModel = new SettingsModel();
            Message = "!!!UNDER CONSTRUCTION!!!";
        }
    }
}

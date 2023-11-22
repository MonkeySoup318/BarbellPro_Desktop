using BarbellPro.Application.Models;
using BarbellPro.Application.Utilities;

namespace BarbellPro.Application.ViewModels
{
    public class LoadoutViewModel : ViewModelBase
    {
        private readonly LoadoutModel _loadoutModel;
        public string? Test
        {
            get { return _loadoutModel.PlaceholderText; }
            set { _loadoutModel.PlaceholderText = value; OnPropertyChanged(); }
        }

        public LoadoutViewModel() 
        { 
            _loadoutModel = new LoadoutModel();
            Test = "Hello World";
        }
    }
}

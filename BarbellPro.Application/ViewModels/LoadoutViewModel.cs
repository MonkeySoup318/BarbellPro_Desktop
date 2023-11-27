using BarbellPro.Application.Models;
using BarbellPro.Application.Utilities;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BarbellPro.Application.ViewModels
{
    public class LoadoutViewModel : ViewModelBase
    {
        private const double Button25_0Value = 25.0;
        private const double Button20_0Value = 20.0;
        private const double Button15_0Value = 15.0;
        private const double Button10_0Value = 10.0;
        private const double Button5_0Value = 5.0;
        private const double Button2_5Value = 2.5;
        private const double Button2_0Value = 2.0;
        private const double Button1_5Value = 1.5;
        private const double Button1_25Value = 1.25;
        private const double Button1_0Value = 1.0;
        private const double Button0_5Value = 0.5;
        private const double Button0_25Value = 0.25;
        
        private readonly LoadoutModel _loadoutModel;
        private bool _button25_0State;
        private bool _button20_0State;
        private bool _button15_0State;
        private bool _button10_0State;
        private bool _button5_0State;
        private bool _button2_5State;
        private bool _button2_0State;
        private bool _button1_5State;
        private bool _button1_25State;
        private bool _button1_0State;
        private bool _button0_5State;
        private bool _button0_25State;     
        private ObservableCollection<string>? _loadoutSelectionList;
        private ObservableCollection<double>? _calculationArray;

        public string? LeftBorderMessage
        {
            get { return _loadoutModel.LoadoutLeftBorderText; }
            set { _loadoutModel.LoadoutLeftBorderText = value; OnPropertyChanged(); }
        }

        public string? RightBorderMessage
        {
            get { return _loadoutModel.LoadoutRightBorderText; }
            set
            {
                _loadoutModel.LoadoutRightBorderText = value;
                OnPropertyChanged();
            }
        }
                
        public bool Button25_0State
        {
            get { return _button25_0State; }
            set
            {
                if (_button25_0State != value)
                {
                    _button25_0State = value;
                    OnPropertyChanged(nameof(Button25_0State));
                }
            }
        }
      
        public bool Button20_0State
        {
            get { return _button20_0State; }
            set
            {
                if (_button20_0State != value)
                {
                    _button20_0State = value;
                    OnPropertyChanged(nameof(Button20_0State));
                }
            }
        }
       
        public bool Button15_0State
        {
            get { return _button15_0State; }
            set
            {
                if (_button15_0State != value)
                {
                    _button15_0State = value;
                    OnPropertyChanged(nameof(Button15_0State));
                }
            }
        }
        
        public bool Button10_0State
        {
            get { return _button10_0State; }
            set
            {
                if (_button10_0State != value)
                {
                    _button10_0State = value;
                    OnPropertyChanged(nameof(Button10_0State));
                }
            }
        }
       
        public bool Button5_0State
        {
            get { return _button5_0State; }
            set
            {
                if (_button5_0State != value)
                {
                    _button5_0State = value;
                    OnPropertyChanged(nameof(Button5_0State));
                }
            }
        }
       
        public bool Button2_5State
        {
            get { return _button2_5State; }
            set
            {
                if (_button2_5State != value)
                {
                    _button2_5State = value;
                    OnPropertyChanged(nameof(Button2_5State));
                }
            }
        }
        
        public bool Button2_0State
        {
            get { return _button2_0State; }
            set
            {
                if (_button2_0State != value)
                {
                    _button2_0State = value;
                    OnPropertyChanged(nameof(Button2_0State));
                }
            }
        }
        
        public bool Button1_5State
        {
            get { return _button1_5State; }
            set
            {
                if (_button1_5State != value)
                {
                    _button1_5State = value;
                    OnPropertyChanged(nameof(Button1_5State));
                }
            }
        }
        
        public bool Button1_25State
        {
            get { return _button1_25State; }
            set
            {
                if (_button1_25State != value)
                {
                    _button1_25State = value;
                    OnPropertyChanged(nameof(Button1_25State));
                }
            }
        }
      
        public bool Button1_0State
        {
            get { return _button1_0State; }
            set
            {
                if (_button1_0State != value)
                {
                    _button1_0State = value;
                    OnPropertyChanged(nameof(Button1_0State));
                }
            }
        }
       
        public bool Button0_5State
        {
            get { return _button0_5State; }
            set
            {
                if (_button0_5State != value)
                {
                    _button0_5State = value;
                    OnPropertyChanged(nameof(Button0_5State));
                }
            }
        }

        public bool Button0_25State
        {
            get { return _button0_25State; }
            set
            {
                if (_button0_25State != value)
                {
                    _button0_25State = value;
                    OnPropertyChanged(nameof(Button0_25State));
                }
            }
        }
        
        // Text input for loadout name by user // maybe async?
        public string? UserInputLoadoutName
        {
            get { return _loadoutModel.UserInputLoadoutName; }
            set
            {
                // TODO: Remember that when saving a new loadout this has to be set to null or choose a default loadout name
                if (_loadoutModel.UserInputLoadoutName != value)
                {
                    _loadoutModel.UserInputLoadoutName = value;
                    OnPropertyChanged(nameof(UserInputLoadoutName));
                }
            }
        }

        public ObservableCollection<string>? LoadoutSelectionList
        {
            get { return _loadoutSelectionList; }
            set
            {
                if (_loadoutSelectionList != value)
                {
                    _loadoutSelectionList = value;
                    OnPropertyChanged(nameof(LoadoutSelectionList));
                }
            }
        }

        public ObservableCollection<double>? CalculationArray
        {
            get { return _calculationArray; }
            set
            {
                if (_calculationArray != value)
                {
                    _calculationArray = value;
                    OnPropertyChanged(nameof(CalculationArray));
                }
            }
        }

        public ICommand? ClickWeightPlateCommand { get; }
        public ICommand ToggleButton25_0Command { get; }
        public ICommand ToggleButton20_0Command { get; }
        public ICommand ToggleButton15_0Command { get; }
        public ICommand ToggleButton10_0Command { get; }
        public ICommand ToggleButton5_0Command { get; }
        public ICommand ToggleButton2_5Command { get; }
        public ICommand ToggleButton2_0Command { get; }
        public ICommand ToggleButton1_5Command { get; }
        public ICommand ToggleButton1_25Command { get; }
        public ICommand ToggleButton1_0Command { get; }
        public ICommand ToggleButton0_5Command { get; }
        public ICommand ToggleButton0_25Command { get; }
        public ICommand? SaveLoadoutCommand { get; }
        public ICommand? DeleteLoadoutCommand { get; }
        public ICommand SetButtonStateAllTrueCommand { get; }
        public ICommand SetButtonStateAllFalseCommand { get; }
        public ICommand? SelectedItemChangedCommand { get; }

        public LoadoutViewModel()
        {
            _loadoutModel = new LoadoutModel() { };
            LoadoutSelectionList = new ObservableCollection<string>
            {
                "Olympic Weightlifting",
                "Powerlifting",
                "Custom Loadout 1",
                "Custom Loadout 2",
                "Custom Loadout 3",
                "Custom Loadout 4"
            };
            LeftBorderMessage = "Select or deselect plates:";
            RightBorderMessage = "Create new Loadout:";

            ToggleButton25_0Command = new RelayCommand(_ => Button25_0State = !Button25_0State, _ => true);
            ToggleButton20_0Command = new RelayCommand(_ => Button20_0State = !Button20_0State, _ => true);
            ToggleButton15_0Command = new RelayCommand(_ => Button15_0State = !Button15_0State, _ => true);
            ToggleButton10_0Command = new RelayCommand(_ => Button10_0State = !Button10_0State, _ => true);
            ToggleButton5_0Command = new RelayCommand(_ => Button5_0State = !Button5_0State, _ => true);
            ToggleButton2_5Command = new RelayCommand(_ => Button2_5State = !Button2_5State, _ => true);
            ToggleButton2_0Command = new RelayCommand(_ => Button2_0State = !Button2_0State, _ => true);
            ToggleButton1_5Command = new RelayCommand(_ => Button1_5State = !Button1_5State, _ => true);
            ToggleButton1_25Command = new RelayCommand(_ => Button1_25State = !Button1_25State, _ => true);
            ToggleButton1_0Command = new RelayCommand(_ => Button1_0State = !Button1_0State, _ => true);
            ToggleButton0_5Command = new RelayCommand(_ => Button0_5State = !Button0_5State, _ => true);
            ToggleButton0_25Command = new RelayCommand(_ => Button0_25State = !Button0_25State, _ => true);
            SetButtonStateAllTrueCommand = new RelayCommand(ExecuteSelectAll);
            SetButtonStateAllFalseCommand = new RelayCommand(ExecuteUnselectAll);
        }

        public ObservableCollection<double>? SetCalculationArray()
        {
            CalculationArray.Clear();
            bool[] buttonStates = 
            { 
                Button25_0State, Button20_0State, Button15_0State, Button10_0State, 
                Button5_0State, Button2_5State, Button2_0State, Button1_5State, 
                Button1_0State, Button0_5State, Button1_25State, Button0_25State 
            };
            double[] buttonValues = 
            { 
                Button25_0Value, Button20_0Value, Button15_0Value, Button10_0Value, 
                Button5_0Value, Button2_5Value, Button2_0Value, Button1_5Value, 
                Button1_25Value, Button1_0Value, Button0_5Value, Button0_25Value 
            };

            for (int i = 0; i < buttonStates.Length; i++)
            {
                if (buttonStates[i])
                {
                    CalculationArray.Add(buttonValues[i]);
                }
            }

            OnPropertyChanged(nameof(CalculationArray));
            return CalculationArray;
        }

        private void ExecuteSelectAll(object obj) 
        {
            Button25_0State = true;
            Button20_0State = true;
            Button15_0State = true;
            Button10_0State = true;
            Button5_0State = true;
            Button2_5State = true;
            Button2_0State = true;
            Button1_5State = true;
            Button1_0State = true;
            Button0_5State = true;
            Button1_25State = true;
            Button0_25State = true;
        }

        private void ExecuteUnselectAll(object obj) 
        {
            Button25_0State = false;
            Button20_0State = false;
            Button15_0State = false;
            Button10_0State = false;
            Button5_0State = false;
            Button2_5State = false;
            Button2_0State = false;
            Button1_5State = false;
            Button1_0State = false;
            Button0_5State = false;
            Button1_25State = false;
            Button0_25State = false;
        }

        private void SaveLoadout() { }
    }
}
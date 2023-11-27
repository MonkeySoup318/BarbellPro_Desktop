using BarbellPro.Application.Models.Enums;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BarbellPro.Application.Models
{
    public class LoadoutModel
    {
        public string? LoadoutLeftBorderText { get; set; }
        public string? LoadoutRightBorderText { get; set; }
        public string? UserInputLoadoutName {  get; set; }
        public string? LoadoutName { get; set; }
        public ObservableCollection<double>? CalculationArray { get; set; } 

        public LoadoutModel() { }

        public LoadoutModel(string loadoutName, ObservableCollection<double> calculationArray) 
        { 
            LoadoutName = loadoutName;
            CalculationArray = calculationArray;
        }

    }
}

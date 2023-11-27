using BarbellPro.Application.Models;
using BarbellPro.Application.Models.Enums;
using BarbellPro.Application.Models.Services;
using BarbellPro.Application.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace BarbellPro.Application.ViewModels
{
    public class CalculatorViewModel : ViewModelBase
    {
        private const int BarWeightMale = 20;
        private const int BarWeightFemale = 15;
        private const int Clipped = 5;
        private const int Unclipped = 0;
        private const double MaxWeight = 300.0;
       
        private readonly ImageManagerService imageManager;
        private readonly double[] originalWeightPlates = new double[10];
        private ImageSource emptyBarbellImage;
        private Gender selectedGender;
        private int inputWeight;
        private bool hasClip;
        private bool resetView;
        private double minWeight;
        private double maxWeight;
        private double algoWeight;        
        private double[] weightPlates = new double[10];
        private ObservableCollection<Image> imageCollection = new();

        public ObservableCollection<CalculatorModel>? CObject { get; set; }

        // Property for the Barbell Image
        public ImageSource EmptyBarbellImage
        {
            get { return emptyBarbellImage; }
            private set { emptyBarbellImage = value; }
        }

        // Properties for user input
        public Gender SelectedGender
        {
            get { return selectedGender; }
            set
            {
                if (selectedGender != value)
                {
                    selectedGender = value;
                    OnPropertyChanged(nameof(SelectedGender));
                }               
            }
        }
      
        public int InputWeight
        {
            get { return inputWeight; }
            set
            {
                if (inputWeight != value)
                {
                    inputWeight = value;
                    OnPropertyChanged(nameof(InputWeight));
                }               
            }
        }
      
        public bool HasClip
        {
            get { return hasClip; }
            set
            {
                if (hasClip != value)
                {
                    hasClip = value;
                    OnPropertyChanged(nameof(HasClip));
                }             
            }
        }
       
        public bool ResetView
        {
            get { return resetView; }
            set
            {
                if (resetView != value)
                {
                    resetView = value;
                    OnPropertyChanged(nameof(ResetView));
                }
            }
        }

        // Fields for calculations       
        public double MinWeight
        {
            get { return minWeight; }
            set
            {
                if (minWeight != value)
                {
                    minWeight = value;
                    OnPropertyChanged(nameof(MinWeight));
                }
            }
        }
             
        public double AlgoWeight
        {
            get { return algoWeight; }
            set
            {
                if (algoWeight != value)
                {
                    algoWeight = value;
                    OnPropertyChanged(nameof(AlgoWeight));
                }
            }
        }

        // Fields for View display               
        public double[] WeightPlates
        {
            get { return weightPlates; }
            set
            {
                if (weightPlates != value)
                {
                    weightPlates = value;
                    OnPropertyChanged(nameof(WeightPlates));
                }
            }
        }

        // Field to hold my images for the stackpanel in the View       
        public ObservableCollection<Image> ImageCollection
        {
            get { return imageCollection; }
            set
            {
                imageCollection = value;
                OnPropertyChanged(nameof(ImageCollection));
            }
        }

        public ICommand CalculateCommand { get; }
        public ICommand ResetViewCommand { get; }

        // Constructor
        public CalculatorViewModel()
        {
            // Default Data
            CObject = new ObservableCollection<CalculatorModel>
            {
                new CalculatorModel
                {
                    Gender = Gender.Male,
                    Weight = 0,
                    HasClip = false
                }
            };

            imageManager = new ImageManagerService();
            imageManager.LoadBumberPlateImages();  
            
            emptyBarbellImage = imageManager.GetImageFromDictionary(Images._barbell).Source;

            Array.Copy(weightPlates, originalWeightPlates, weightPlates.Length);

            CalculateCommand = new RelayCommand(ExecuteCalculate, CanExecuteCalculate);
            ResetViewCommand = new RelayCommand(ExecuteResetView);
        }

        public void SetMinWeight()
        {
            MinWeight = SelectedGender switch
            {
                Gender.Male => HasClip ? BarWeightMale + Clipped : BarWeightMale + Unclipped,       // 25 or 20
                Gender.Female => HasClip ? BarWeightFemale + Clipped : BarWeightFemale + Unclipped, // 20 or 15
                _ => throw new InvalidOperationException("Invalid gender selection")
            };
        }

        public void SetAlgoWeight()
        {
            double _algoWeight = (InputWeight - MinWeight) / 2;

            if (_algoWeight < 0)
                AlgoWeight = 0.0;
            else
                AlgoWeight = _algoWeight;           
        }

        public bool CanExecuteCalculate(object obj)
        {
            SetMinWeight();
            SetAlgoWeight();

            return ((AlgoWeight > 0.0) && (InputWeight <= MaxWeight));
        }

        public void ExecuteCalculate(object obj)
        {
            ClearAllImages();
            double[] plateWeights = { 25.0, 20.0, 15.0, 10.0, 5.0, 2.5, 2.0, 1.5, 1.0, 0.5 };
            double remainWeight;
            double _algoWeight = AlgoWeight;

            for (int i = 0; i < plateWeights.Length; i++)
            {
                if (_algoWeight >= plateWeights[i])
                {
                    WeightPlates[i] = (int)(_algoWeight / plateWeights[i]);
                    remainWeight = _algoWeight % plateWeights[i];
                    _algoWeight = remainWeight;
                }
            }

            DisplayImagesFromKeys();
        }

        public void DisplayImagesFromKeys()
        {
            Images[] weightPlateKeys =
            {
                Images._25kg, 
                Images._20kg,
                Images._15kg,
                Images._10kg,
                Images._5kg,
                Images._2_5kg,
                Images._2_0kg,
                Images._1_5kg,
                Images._1_0kg,
                Images._0_5kg,
                Images._clip
            };

            for (int i = 0; i < WeightPlates.Length; i++)
            {
                for (int j = 0; j < WeightPlates[i]; j++)
                    ImageCollection.Add(imageManager.GetImageFromDictionary(weightPlateKeys[i]));
            }

            if (HasClip)
            {
                int clipIndex = 10;
                ImageCollection.Add(imageManager.GetImageFromDictionary(weightPlateKeys[clipIndex]));
            }               
        }

        public void ClearAllImages()
        {
            Array.Copy(originalWeightPlates, weightPlates, originalWeightPlates.Length);
            OnPropertyChanged(nameof(WeightPlates));

            // Reset images to empty barbell
            if (ImageCollection.Count > 0)
                ImageCollection.Clear();
        }

        public void ExecuteResetView(object obj)
        {
            // Reset the input properties to default values
            SelectedGender = Gender.Male;
            InputWeight = 0;
            HasClip = false;

            ClearAllImages();
        }
    }
}
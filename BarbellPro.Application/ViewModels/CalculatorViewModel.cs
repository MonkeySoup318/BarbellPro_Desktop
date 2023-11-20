using BarbellPro.Application.Models;
using BarbellPro.Application.Models.Enums;
using BarbellPro.Application.Models.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace BarbellPro.Application.ViewModels
{
    public class CalculatorViewModel : ViewModelBase
    {
        // Constants
        private const int BarWeightMale = 20;
        private const int BarWeightFemale = 15;
        private const int Clipped = 5;
        private const int Unclipped = 0;
        private const double MaxWeightDefault = 300.0;

        public ObservableCollection<CalculationObjectModel> CObject { get; set; }
        private readonly ImageManagerService imageManager;

        // Property for AppIcon Image
        private ImageSource appIconImage;
        public ImageSource AppIconImage
        {
            get { return appIconImage; }
            private set { appIconImage = value; }
        }

        // Property for the Barbell Image
        private ImageSource emptyBarbellImage;
        public ImageSource EmptyBarbellImage
        {
            get { return emptyBarbellImage; }
            private set { emptyBarbellImage = value; }
        }

        // Properties for user input
        private Gender selectedGender;
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

        private int inputWeight;
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

        private bool hasClip;
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

        private bool resetView;
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
        private double minWeight;
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

        private double maxWeight;
        public double MaxWeight
        {
            get { return maxWeight; }
            set
            {
                if (maxWeight != value)
                {
                    maxWeight = value;
                    OnPropertyChanged(nameof(maxWeight));
                }
            }
        }

        private double algoWeight;
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
        private readonly double[] originalWeightPlates = new double[10];

        private double[] weightPlates = new double[10];
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
        private ObservableCollection<Image> imageCollection = new();
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
            CObject = new ObservableCollection<CalculationObjectModel>
            {
                new CalculationObjectModel
                {
                    Gender = Gender.Male,
                    Weight = 0,
                    HasClip = false
                }
            };

            imageManager = new ImageManagerService();
            imageManager.LoadBumberPlateImages();  
            
            appIconImage = ImageManagerService.LoadAppIconImage();
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

        public void SetMaxWeight()
        {
            MaxWeight = MaxWeightDefault;
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
            SetMaxWeight();
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

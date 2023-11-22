using Xunit;

namespace BarbellPro.Tests
{
    public class CalculatorViewModelTests
    {
        [Fact]
        public void SetMaxWeight_True_Zero()
        {
            double maxWeight = 0;
            double result = maxWeight.CompareTo(0);
            Assert.Equal(0, result);
        }

        [Fact]
        public void SetMaxWeight_True_One()
        {
            double maxWeight = 1;
            double result = maxWeight.CompareTo(0);
            Assert.Equal(1, result);
        }

        [Fact]
        public void SetAlgoWeight_Female_100kg_40kg()
        {
            double inputWeight = 100.0;
            double minWeight = 15.0;
            double result = (inputWeight - minWeight) / 2;
            Assert.Equal(42.5, result);
        }
        
        [Fact]
        public void SetAlgoWeight_Male_100kg_40kg()
        {
            double inputWeight = 100.0;
            double minWeight = 20.0;
            double result = (inputWeight - minWeight) / 2;
            Assert.Equal(40.0, result);
        }

        // CanExecuteCalculate()

        // ExecuteCalculate()

        // DisplayImagesFromKeys()

        // ClearAllImages()

        // ExecuteResetView()
    }
}
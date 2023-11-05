using BarbellPro.Application.ViewModels;
using System.Windows.Controls;

namespace BarbellPro.Application.Views
{
    /// <summary>
    /// Interaction logic for CalculatorView.xaml
    /// </summary>
    public partial class CalculatorView : UserControl
    {
        public CalculatorView()
        {
            InitializeComponent();
            CalculatorViewModel viewModel = new();
            DataContext = viewModel;
        }
    }
}

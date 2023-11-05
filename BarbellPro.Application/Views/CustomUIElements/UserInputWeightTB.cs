using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace BarbellPro.Application.Views.CustomUIElements
{
    public partial class UserInputWeightTB : TextBox
    {
        private static readonly Regex regex = MyRegex();

        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            if (!regex.IsMatch(e.Text))
                e.Handled = true;

            base.OnPreviewTextInput(e);
        }

        [GeneratedRegex("^[0-9]$")]
        private static partial Regex MyRegex();
    }
}
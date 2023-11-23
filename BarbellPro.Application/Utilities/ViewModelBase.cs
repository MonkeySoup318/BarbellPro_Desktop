using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BarbellPro.Application.Utilities
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new System.ArgumentException($"'{nameof(propertyName)}' cannot be null or whitespace.", nameof(propertyName));            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

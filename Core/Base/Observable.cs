using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CountEZ.Core.Base
{
    internal class Observable : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Notifies subscribers of the property change.
        /// </summary>
        protected void Set<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
        {
            if (Equals(storage, value)) return;

            storage = value;
            OnPropertyChanged(propertyName);
        }

        /// <summary>
        /// Notifies subscribers of the property change.
        /// </summary>
        protected void OnPropertyChanged(string? propertyName) 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
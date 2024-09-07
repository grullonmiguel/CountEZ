using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace CountEZ.Core.Base
{
    internal class Observable : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies subscribers of the property change.
        /// </summary>
        protected virtual bool NotifyPropertyChanged<T>(ref T oldValue, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (Equals(oldValue, newValue))
                return false;

            oldValue = newValue;

            OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Notifies subscribers of the property change.
        /// </summary>
        protected virtual bool NotifyPropertyChanged<T>(ref T oldValue, T newValue, Action onChanged, [CallerMemberName] string propertyName = null)
        {
            if (Equals(oldValue, newValue))
                return false;

            oldValue = newValue;
            onChanged?.Invoke();

            OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Notifies subscribers of the property change.
        /// </summary>
        protected virtual bool NotifyPropertyChanged<T>(ref T oldValue, T newValue, Action<T> onChanging, Action onChanged, [CallerMemberName] string propertyName = null)
        {
            if (Equals(oldValue, newValue))
                return false;

            if (oldValue != null)
                onChanging(oldValue);

            oldValue = newValue;
            onChanged?.Invoke();

            OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Notifies subscribers of the property change.
        /// </summary>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Notifies subscribers of the property change.
        /// </summary>
        protected void OnPropertyChanged<T>(Expression<Func<T>> property)
        {
            OnPropertyChanged(ExtractPropertyName(property));
        }

        #region Helper Methods

        private string ExtractPropertyName<T>(Expression<Func<T>> property)
        {
            ArgumentNullException.ThrowIfNull(property);

            if (!(property.Body is MemberExpression body))
                throw new ArgumentException("Unable to access Expression", nameof(property));

            PropertyInfo member = body.Member as PropertyInfo;

            if (member == null)
                throw new ArgumentException("Expression is not a Property", nameof(property));

            if (member.GetMethod.IsStatic)
                throw new ArgumentException("Static Member not allowed for Expression", nameof(property));

            return body.Member.Name;
        }

        #endregion
    }
}
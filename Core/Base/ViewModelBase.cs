using CommunityToolkit.Mvvm.ComponentModel;

namespace CountEZ.Core.Base
{
    internal class ViewModelBase : ObservableObject, IDisposable
    {
        protected bool _isDisposed;

        #region Properties

        public string ViewName
        {
            get => _viewName;
            set => SetProperty(ref _viewName, value);
        }
        private string _viewName;

        #endregion

        #region Constructor

        protected ViewModelBase()
        {

        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            //Logger.Debug(this, $"Disposing {GetType().Name}", "Disposal");
            OnDispose();
        }

        /// <summary>
        /// Child classes can override this method to perform.
        /// </summary>
        protected virtual void OnDispose()
        { }

        #endregion
    }
}
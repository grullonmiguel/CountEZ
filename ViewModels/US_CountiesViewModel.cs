using CommunityToolkit.Mvvm.Input;
using CountEZ.Core.Base;
using CountEZ.Core.Contracts;
using CountEZ.Core.Services;
using CountEZ.Models;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Windows.Data;
using System.Windows.Input;

namespace CountEZ.ViewModels
{
    internal class US_CountiesViewModel : ViewModelBase
    {
        #region Fields

        private readonly IStateDataService _dataService;

        #endregion

        #region Properties

        public IEnumerable<US_County>? Counties
        {
            get => _counties;
            set => SetProperty(ref _counties, value);
        }
        private IEnumerable<US_County>? _counties;

        public ICollectionView CountiesCollection
        {

            get => _countiesCollection;
            set => SetProperty(ref _countiesCollection, value);
        }
        private ICollectionView _countiesCollection;


        public US_County? CountySelected
        {
            get => _countySelected;
            set
            {
                SetProperty(ref _countySelected, value);
                Task.Run(OnCountySelected);
            }
        }
        private US_County? _countySelected;

        public string FilterByState
        {
            get => _filterByState;
            set
            {
                if (value != _filterByState)
                {
                    _filterByState = value;
                    CountiesCollection.Refresh();
                    OnPropertyChanged(nameof(FilterByState));
                }
            }
        }
        private string _filterByState;

        public string FilterByCounty
        {
            get => _filterByCounty;
            set
            {
                if (value != _filterByCounty)
                {
                    _filterByCounty = value;
                    CountiesCollection.Refresh();
                    OnPropertyChanged(nameof(FilterByCounty));
                }
            }
        }
        private string _filterByCounty;

        #endregion


        #region Commands

        public ICommand LoadedCommand => new AsyncRelayCommand(OnLoaded);

        #endregion

        #region Constructor

        public US_CountiesViewModel(IStateDataService dataService)
        {
            _dataService = dataService;   
        }

        #endregion

        #region Methods


        private async Task OnLoaded()
        {
            await GetAllCounties();
        }

        private async Task GetAllCounties()
        {
            Counties = await _dataService.GetAllCounties() as List<US_County>;

            CountiesCollection = CollectionViewSource.GetDefaultView(Counties);
            CountiesCollection.Filter = FilterCountyList;

        }
        private bool FilterCountyList(object o)
        {
            if (o is not US_County county)
                return true;

            // Return all records
            if (string.IsNullOrEmpty(FilterByState) && string.IsNullOrEmpty(FilterByCounty))
                return true;

            return true;

            // Filter by State
            //if (!string.IsNullOrEmpty(FilterByState) && string.IsNullOrEmpty(FilterByCounty))
            //    return county.StateID.GetEnumDisplayName().ToString().ToUpper().Contains(FilterByState.ToUpper());

            //// Filter by County
            //if (string.IsNullOrEmpty(FilterByState) && !string.IsNullOrEmpty(FilterByCounty))
            //    return county.Name.ToString().ToUpper().Contains(FilterByCounty.ToUpper());

            //// Filter by State and County
            //return county.Name.ToString().ToUpper().Contains(FilterByCounty.ToUpper()) &&
            //       county.StateID.GetEnumDisplayName().ToString().ToUpper().Contains(FilterByState.ToUpper());
        }

        private async void OnCountySelected()
        {
            //if (CountySelected != null)
            //    await _dialogService.ShowDialogAsync(new CountyDialogViewModel(CountySelected, _systemService));
        }

        #endregion
    }
}

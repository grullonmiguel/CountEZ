using CommunityToolkit.Mvvm.Input;
using CountEZ.Core.Base;
using CountEZ.Core.Contracts;
using CountEZ.Models;
using CountEZ.ViewModels.Dialogs;
using System.Diagnostics.Metrics;
using System.Windows.Input;

namespace CountEZ.ViewModels
{
    internal class US_StatesViewModel :ViewModelBase
    {
        #region Fields

        private readonly IDialogService _dialogService;
        private readonly IStateDataService _dataService;
        private readonly ISystemService _systemService;

        #endregion

        #region Properties

        public List<US_County>? Counties
        {
            get => _counties;
            set => SetProperty(ref _counties, value);
        }
        private List<US_County>? _counties;

        public IEnumerable<US_State>? States
        {
            get => _states;
            set => SetProperty(ref _states, value);
        }
        private IEnumerable<US_State>? _states;

        public US_State? StateSelected
        {
            get => _stateSelected;
            set
            {
                Counties = null;
                SetProperty(ref _stateSelected, value);
                UpdateStateSelected();
                UpdateCountyList();
                OnPropertyChanged(nameof(CountyCount));
            }
        }
        private US_State? _stateSelected;

        public string CountyCount 
            => StateSelected?.Counties?.Count <= 1 ? 
                $"{StateSelected?.Counties?.Count} County" : 
                $"{StateSelected?.Counties?.Count} Counties";

        #endregion

        #region Commands

        public ICommand LoadedCommand => new AsyncRelayCommand(OnLoaded);
        public ICommand AppraisalOfficeCommand => new RelayCommand<US_County>(OpenAppraisalOfficeURL);
        public ICommand ClerkOfficeCommand => new RelayCommand<US_County>(OpenClerksOfficeURL);
        public ICommand TaxOfficeCommand => new RelayCommand<US_County>(OpenTaxOfficeURL);
        public ICommand BestCountiesCommand => new RelayCommand(OpenBestCountiesURL);
        public ICommand WorstCountiesCommand => new RelayCommand(OpenWorstCountiesURL);
        public ICommand StateSelectedCommand => new RelayCommand<StateCode>(GetSelectedState);
        public ICommand ViewStateCommand => new RelayCommand(OpenStateSelected);

        #endregion

        #region Constructor

        public US_StatesViewModel(IDialogService dialogService, IStateDataService dataService, ISystemService systemService)
        {
            _dataService = dataService;
            _dialogService = dialogService;
            _systemService = systemService;
        }

        #endregion

        #region Methods

        private async Task OnLoaded()
        {
            await GetStateList();

            if (States != null)
                StateSelected = States.FirstOrDefault();
        }

        private async Task GetStateList() 
            => States = await _dataService.GetAllStates() as List<US_State>;

        private void UpdateStateSelected()
        {
            if (States == null)
                return;

            // Unselect all states first
            foreach (var s in States)
                s.IsSelected = false;

            // Update IsSelected property for selected state
            foreach (var s in States)
            {
                if (s.StateID == StateSelected?.StateID)
                {
                    s.IsSelected = true;
                    break;
                }
            }
        }

        private void UpdateCountyList() 
            => Counties = StateSelected?.Counties;

        private void GetSelectedState(StateCode state) 
            => StateSelected = States?.FirstOrDefault(x => x.StateID == state);

        private void OpenAppraisalOfficeURL(US_County? county)
            => _systemService.OpenWebSearch($"{county?.Name} county, {StateSelected?.Name} assessor's office");

        private void OpenClerksOfficeURL(US_County? county)
            => _systemService.OpenWebSearch($"{county?.Name} county, {StateSelected?.Name} clerk's office");

        private void OpenTaxOfficeURL(US_County? county)
            => _systemService.OpenWebSearch($"{county?.Name} county, {StateSelected?.Name} {(StateSelected?.SalesType == SaleTypeCode.Lien ? "tax lien sale" : "tax deed sale")}");

        private void OpenBestCountiesURL()
            => _systemService.OpenWebSearch($"{StateSelected?.Name} best counties");

        private void OpenWorstCountiesURL()
            => _systemService.OpenWebSearch($"{StateSelected?.Name} worst counties");

        private async void OpenStateSelected()
        {
            if (StateSelected != null)
            {
                var dlg = new StateDialogViewModel(StateSelected,_systemService);
                await _dialogService.ShowDialogAsync(dlg);
            }
        }

        #endregion
    }
}
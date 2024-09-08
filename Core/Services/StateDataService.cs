using CountEZ.Core.Contracts;
using CountEZ.Models;

namespace CountEZ.Core.Services
{
    internal class StateDataService : IStateDataService
    {
        private static IEnumerable<US_County>? _counties;
        private static IEnumerable<US_State>?  _states;

        public StateDataService()
        {
                
        }

        public async Task<IEnumerable<US_County>> GetAllCounties()
        {
            _counties ??= await AllCounties();

            return _counties;
        }

        public async Task<IEnumerable<US_State>> GetAllStates()
        {
            await Task.CompletedTask;

            _states ??= StateDataFactory.AllStates();

            return _states;
        }

        public async Task<IEnumerable<US_County>> AllCounties()
        {
            await Task.CompletedTask;

            _states ??= StateDataFactory.AllStates();

            var counties = new List<US_County>();
            foreach (var state in _states)
            {
                foreach (var c in state.Counties)
                    counties.Add(c);
            }

            return counties;
        }
    }
}
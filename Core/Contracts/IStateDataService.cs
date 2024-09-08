using CountEZ.Models;

namespace CountEZ.Core.Contracts
{
    internal interface IStateDataService
    {
        Task<IEnumerable<US_State>> GetAllStates();

        Task<IEnumerable<US_County>> GetAllCounties();
    }
}
using SportingGroupAPI.Models;

namespace SportingGroupAPI.Services
{
    public interface IBettingService
    {
        Task PostAsync(IEnumerable<ApiPostBetFixture> request);
        Task<ApiGetBet> GetAsync(int id);
    }
}

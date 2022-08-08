using SportingGroupAPI.Models;

namespace SportingGroupAPI.Services
{
    public interface IFixtureService
    {
        Task<IEnumerable<ApiGetFixture>> GetAllAsync();
        Task<ApiGetFixture> GetAsync(int id);
        Task PostAsync(ApiPostFixture request);
    }
}

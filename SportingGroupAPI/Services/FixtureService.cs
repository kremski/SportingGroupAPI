using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportingGroupAPI.DAL;
using SportingGroupAPI.DAL.Models;
using SportingGroupAPI.Models;

namespace SportingGroupAPI.Services
{
    public class FixtureService : IFixtureService
    {
        private readonly SportingGroupDbContext _context;
        private readonly IMapper _mapper;

        public FixtureService(SportingGroupDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ApiGetFixture>> GetAllAsync()
        {
            var fixtures =
                await _context.Fixture
                .AsNoTracking()
                .Include(x => x.HostTeam)
                .Include(x => x.GuestTeam)
                .Include(x => x.Result)
                .ToListAsync();
            return _mapper.Map<List<ApiGetFixture>>(fixtures);
        }

        public async Task<ApiGetFixture> GetAsync(int id)
        {
            var fixture =
                await _context.Fixture
                .Include(x => x.HostTeam)
                .Include(x => x.GuestTeam)
                .Include(x => x.Result)
                .SingleOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<ApiGetFixture>(fixture);
        }

        public async Task PostAsync(ApiPostFixture request)
        {
            var fixture = new Fixture
            {
                HostTeamId = request.HostTeamId,
                GuestTeamId = request.GuestTeamId,
                ResultId = 1
            };
            await _context.Fixture.AddAsync(fixture);
            await _context.SaveChangesAsync();
        }
    }
}

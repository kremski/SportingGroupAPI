using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportingGroupAPI.DAL;
using SportingGroupAPI.DAL.Models;
using SportingGroupAPI.Models;

namespace SportingGroupAPI.Services
{
    public class BettingService : IBettingService
    {
        private readonly SportingGroupDbContext _context;
        private readonly IMapper _mapper;

        public BettingService(SportingGroupDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiGetBet> GetAsync(int id)
        {
            var bet =
                await _context.Bet
                .Include(x => x.BetFixtures)
                .Include(x => x.BetFixtures).ThenInclude(y => y.BetResult)
                .Include(x => x.BetFixtures).ThenInclude(y => y.Fixture)
                .Include(x => x.BetFixtures).ThenInclude(y => y.Fixture).ThenInclude(z => z.GuestTeam)
                .Include(x => x.BetFixtures).ThenInclude(y => y.Fixture).ThenInclude(z => z.HostTeam)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (bet == null)
            {
                return null;
            }

            var apiBetFixtures = new List<ApiGetBetFixture>();
            foreach (var betFixture in bet.BetFixtures)
            {
                var apiFixture = _mapper.Map<ApiGetFixture>(betFixture.Fixture);
                var fixtureResult = FixtureDecider();
                apiFixture.WasPlayed = true;
                apiFixture.ResultId = fixtureResult;

                var apiBetFixture = new ApiGetBetFixture
                {
                    Fixture = apiFixture,
                    BetResult = _mapper.Map<ApiResult>(betFixture.BetResult),
                    BetFixtureOutcome = apiFixture.ResultId == betFixture.BetResultId ? "You won!" : "You lost"
                };

                apiBetFixtures.Add(apiBetFixture);
            }

            return new ApiGetBet
                { 
                    BetId = bet.Id, 
                    BetFixtures = apiBetFixtures
                };
        }

        public async Task PostAsync(IEnumerable<ApiPostBetFixture> request)
        {
            var bet = new Bet();
            await _context.Bet.AddAsync(bet);
            await _context.SaveChangesAsync();
            var betFixtures = new List<BetFixture>();
            foreach (var item in request)
            {
                betFixtures.Add(
                    new BetFixture
                    {
                        BetId = bet.Id,
                        BetResultId = item.BetResultId,
                        FixtureId = item.FixtureId
                    });
            }
            await _context.BetFixture.AddRangeAsync(betFixtures);
            await _context.SaveChangesAsync();
        }

        private int FixtureDecider()
        {
            // here would check if given Fixture has been played and if so what's the result
            // for brevity - random result pick of existing Results
            Random random = new Random();
            return random.Next(2, 5);
        }
    }
}

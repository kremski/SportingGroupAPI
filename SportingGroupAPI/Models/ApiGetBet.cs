namespace SportingGroupAPI.Models
{
    public class ApiGetBet
    {
        public int BetId { get; set; }
        public IEnumerable<ApiGetBetFixture> BetFixtures { get; set; }
    }
}

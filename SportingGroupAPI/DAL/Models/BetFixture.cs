namespace SportingGroupAPI.DAL.Models
{
    public class BetFixture
    {
        public int Id { get; set; }
        public int BetId { get; set; }
        public virtual Bet Bet { get; set; }
        public int FixtureId { get; set; }
        public virtual Fixture Fixture { get; set; }
        public int BetResultId { get; set; }
        public virtual Result BetResult { get; set; }
    }
}

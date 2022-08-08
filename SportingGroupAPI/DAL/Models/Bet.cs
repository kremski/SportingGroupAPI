namespace SportingGroupAPI.DAL.Models
{
    public class Bet
    {
        public int Id { get; set; }

        public virtual ICollection<BetFixture> BetFixtures { get; set; }
    }
}

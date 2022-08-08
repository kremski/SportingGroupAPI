namespace SportingGroupAPI.DAL.Models
{
    public class Fixture
    {
        public int Id { get; set; }
        public int HostTeamId { get; set; }
        public virtual Team HostTeam { get; set; }
        public int GuestTeamId { get; set; }
        public virtual Team GuestTeam { get; set; }
        public bool WasPlayed { get; set; }
        public int ResultId { get; set; }
        public virtual Result Result { get; set; }

        public virtual ICollection<BetFixture> BetFixtures { get; set; }
    }
}

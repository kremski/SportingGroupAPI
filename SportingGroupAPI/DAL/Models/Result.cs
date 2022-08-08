namespace SportingGroupAPI.DAL.Models
{
    public class Result
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Fixture> Fixtures { get; set; }
        public virtual ICollection<BetFixture> BetFixtures { get; set; }
    }
}

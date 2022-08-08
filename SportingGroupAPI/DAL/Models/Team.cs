namespace SportingGroupAPI.DAL.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Fixture> FixtureHosts { get; set; }
        public virtual ICollection<Fixture> FixtureGuests { get; set; }
    }
}

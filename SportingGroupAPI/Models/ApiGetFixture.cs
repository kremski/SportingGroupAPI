namespace SportingGroupAPI.Models
{
    public class ApiGetFixture
    {
        public int Id { get; set; }
        public ApiTeam HostTeam { get; set; }
        public ApiTeam GuestTeam { get; set; }
        public bool WasPlayed { get; set; }
        public int ResultId { get; set; }
        public ApiResult Result { get; set; }
    }
}

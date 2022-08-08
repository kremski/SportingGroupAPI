using System.ComponentModel.DataAnnotations;

namespace SportingGroupAPI.Models
{
    public class ApiPostFixture
    {
        [Required] public int HostTeamId { get; set; }
        [Required] public int GuestTeamId { get; set; }
    }
}

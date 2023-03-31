using LogixTechnology.Data.Models;

namespace LogixTechnology.Data.Repositories
{
    public class UserActivityInput
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public int Action { get; set; }
    }
}

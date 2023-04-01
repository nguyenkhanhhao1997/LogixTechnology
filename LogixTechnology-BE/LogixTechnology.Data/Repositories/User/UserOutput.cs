using System.IdentityModel.Tokens.Jwt;

namespace LogixTechnology.Data.Repositories
{
    public class UserOutput
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}

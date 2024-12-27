using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;

namespace FCNetwork.Infrastructure.Entities.Security
{
    public class User : IdentityUser
    {
        public string? PlayerId { get; set; }
        public Player? Player { get; set; }
    }
}

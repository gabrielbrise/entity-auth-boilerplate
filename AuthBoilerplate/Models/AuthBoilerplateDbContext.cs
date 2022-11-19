using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthBP.Models
{
    public class AuthBoilerplateDbContext : IdentityDbContext
    {
        public AuthBoilerplateDbContext(DbContextOptions<AuthBoilerplateDbContext> options) : base(options) { }
    }
}

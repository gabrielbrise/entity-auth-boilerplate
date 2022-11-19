using AuthBP.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthBoilerplate.Utils
{
    public static class DatabaseUtils
    {
        public static void RunMigrations(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AuthBoilerplateDbContext>();
            db.Database.Migrate();
        }
    }
}

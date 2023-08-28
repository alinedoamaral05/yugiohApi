using Microsoft.EntityFrameworkCore;
using YuGiOhApi.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace YuGiOhApi.Infra.Database.Config.Identity
{
    public class UserContext: IdentityDbContext<User>
    {
        public UserContext(DbContextOptions<UserContext> options): base(options)
        {
            
        }
    }
}

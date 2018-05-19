using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Web.Domain.Users;
using Web.Entities.Domain.Logs;
using Web.Infra.Logs;

namespace Web.Infra.EF
{
    public class AdvContext: IdentityDbContext<User,IdentityRole<Guid>,Guid>
    {
        public AdvContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Log> Logs { get; set; }

    }
}

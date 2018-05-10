using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Web.Domain.Users;

namespace Web.Infra.EF
{
    public class AdvContext: IdentityDbContext<User,IdentityRole<Guid>,Guid>
    {
        public AdvContext(DbContextOptions options)
            :base(options)
        {

        }
        
    }
}

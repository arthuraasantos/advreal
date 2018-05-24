using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Web.Domain.Users;
using Web.Entities.Domain.Logs;
using Web.Entities.Domain.Offices;
using Web.Entities.Domain.Users.Interfaces;

namespace Web.Infra.EF
{
    public class AdvContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>, IAdvContext
    {
        public AdvContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Log> Logs { get; set; }
        public DbSet<Office> Offices { get; set; }

        #region Configure

        public void Commit() => SaveChanges();

        public override int SaveChanges()
        {
            
            return base.SaveChanges();
        }

        public void RegisterLogs(User user)
        {
            var entitiesToLog = new List<Log>();

            foreach (var entry in ChangeTracker.Entries().Where
            (x => (x.State == EntityState.Added) ||
                (x.State == EntityState.Deleted) ||
                (x.State == EntityState.Modified)))
            {
                var log = new Log()
                {
                    Date = DateTime.UtcNow,
                    Entity = entry.ToString(),
                    Type = entry.GetType().ToString(),
                    User = user.FullName,
                    UserId = user.Id
                };

                if (entry.State == EntityState.Added)
                {
                    entitiesToLog.Add(new Log()
                    {

                        Message = $"Inseriu na tabela {entry.GetType().ToString()}",
                        OldValues = null,
                        NewValues = entry.ToString()
                    });
                }
                else if (entry.State == EntityState.Modified)
                {
                    entitiesToLog.Add(new Log()
                    {

                        Message = $"Alterou na tabela {entry.GetType().ToString()}",
                        OldValues = entry.OriginalValues.ToString(),
                        NewValues = entry.ToString()
                    });
                }

                Logs.Add(log);
            }
        }


        #endregion
        
    }
}

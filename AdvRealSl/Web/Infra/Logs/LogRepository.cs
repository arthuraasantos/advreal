using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Domain.Users;
using Web.Entities.Domain.Logs;
using Web.Infra.EF;

namespace Web.Infra.Logs
{
    public interface ILogRepository
    {
        void Register(User user, Log log);
    }

    public class LogRepository: ILogRepository
    {
        protected readonly AdvContext _context;
        protected readonly DbSet<Log> _dbSetLogs;

        public LogRepository(AdvContext context)
        {
            _context = context;
            _dbSetLogs = _context.Logs;
        }

        public void Register(User user, Log log)
        {
            log.User = user.FullName;
            log.UserId = user.Id;
            _dbSetLogs.AddAsync(log);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

using System;
using Web.Domain.Users;
using Web.Entities.Domain.Logs;
using Web.Entities.Domain.Logs.Enums;
using Web.Entities.Domain.Logs.Interfaces;
using Web.Infra.EF;
using Web.Infra.Logs;

namespace Web.Services
{
    public class LogService<T> : ILogService<T>
        where T: class 
    {
        public AdvContext _context;
        public ILogRepository _logRepository;
        public LogService(AdvContext advContext, ILogRepository logRepository)
        {
            _context = advContext;
            _logRepository = logRepository;
        }

        public void Register(LogType type, T entity, User user, string message)
        {
            //if (string.IsNullOrWhiteSpace(message)) throw new InvalidOperationException();
            //if (string.IsNullOrWhiteSpace(user.FullName)) throw new InvalidOperationException();
            if (Guid.Empty == user.Id) throw new InvalidOperationException();

            var log = new Log()
            {
                Date = DateTime.UtcNow,
                Entity = entity.GetType()?.Name?.ToString(),
                Message = message,
                Type = type.ToString(),
                User = user.FullName,
                UserId = user.Id
            };

            if (type == LogType.Change)
            {
                log.NewValues = entity.ToString();
                log.OldValues = entity.ToString();
            }

            _logRepository.Register(user, log);
            _context.SaveChanges();
        }
    }
}

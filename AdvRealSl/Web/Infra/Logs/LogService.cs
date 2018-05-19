using System;
using Web.Entities.Domain.Logs;
using Web.Entities.Domain.Logs.Enums;
using Web.Entities.Domain.Logs.Interfaces;

namespace Web.Infra.Logs
{
    public class LogService<T> : ILogService<T>
        where T: class 
    {
        public void Register(LogType type, T entity, string message, Guid userId, string userName)
        {
            if (string.IsNullOrWhiteSpace(message)) throw new InvalidOperationException();
            if (string.IsNullOrWhiteSpace(userName)) throw new InvalidOperationException();
            if (Guid.Empty == userId) throw new InvalidOperationException();

            var log = new Log()
            {
                Date = DateTime.UtcNow,
                Entity = entity.GetType().ToString(),
                Message = message,
                Type = type.ToString(),
                User = userName,
                UserId = userId
            };


            
        }
    }
}

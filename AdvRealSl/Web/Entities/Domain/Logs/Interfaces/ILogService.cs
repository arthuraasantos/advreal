using System;
using Web.Entities.Domain.Logs.Enums;

namespace Web.Entities.Domain.Logs.Interfaces
{
    public interface ILogService<T>
        where T: class
    {
        void Register(LogType type, T entity, string message, Guid userId, string userName);
    }
}

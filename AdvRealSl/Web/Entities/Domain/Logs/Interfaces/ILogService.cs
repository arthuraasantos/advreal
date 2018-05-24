using System;
using Web.Domain.Users;
using Web.Entities.Domain.Logs.Enums;

namespace Web.Entities.Domain.Logs.Interfaces
{
    public interface ILogService<T>
        where T: class
    {
        void Register(LogType type, T entity, User user, string message);
    }
}

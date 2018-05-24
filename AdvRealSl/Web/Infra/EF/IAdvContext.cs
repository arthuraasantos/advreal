using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Domain.Users;
using Web.Entities.Domain.Offices;
using Web.Entities.Domain.Users.Interfaces;

namespace Web.Infra.EF
{
    public interface IAdvContext
    {
        void RegisterLogs(User user);
        void Commit();
    }
}


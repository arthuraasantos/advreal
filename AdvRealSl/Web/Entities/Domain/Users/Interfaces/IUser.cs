using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Entities.Domain.Users.Interfaces
{
    public interface IUser
    {
        string Email { get; }
        string FullName { get; }
        Guid Id { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Entities.Domain.Offices
{
    public interface IOffice
    {
        string Name { get; }
        Guid Id { get; }
    }
}

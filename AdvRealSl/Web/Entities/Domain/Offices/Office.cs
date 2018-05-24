using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Entities.Domain.Offices
{
    public class Office : IOffice
    {

        public Office()
        {

        }
        public string Name { get; set; }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}

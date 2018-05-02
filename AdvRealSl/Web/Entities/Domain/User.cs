using Microsoft.AspNetCore.Identity;
using System;

namespace Web.Domain
{
    public class User: IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
        public string Password { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using Web.Entities.Domain.Logs;
using Web.Entities.Domain.Users.Interfaces;

namespace Web.Domain.Users
{
    public class User: IdentityUser<Guid>, ILog, IUser
    {
        [Obsolete("Para o EF, não utilizar",true)]
        public User()
        {

        }

        public User(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException();
            
            UserName = email;
            Email = email;
            Password = password;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
        public string Password { get; protected set; }


        public void SetPassword(string password) => Password = password;
    }
}

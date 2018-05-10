using System;

namespace Web.Entities.ViewModels
{
    public class UserProfileViewModel
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

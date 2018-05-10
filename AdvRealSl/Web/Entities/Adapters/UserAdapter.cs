using Web.Domain.Users;
using Web.Entities.ViewModels;

namespace Web.Entities.Adapters
{
    public static class UserAdapter
    {
        public static UserProfileViewModel DomainToProfileViewModel(User user)
        {
            var userProfile = new UserProfileViewModel();

            userProfile.UserId = user.Id;
            userProfile.Email = user.Email;
            userProfile.FirstName = user.FirstName;
            userProfile.LastName = user.LastName;
            
            return userProfile;
        }
    }
}

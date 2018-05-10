using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Web.Domain.Users;
using Web.Entities.ViewModels;

namespace Web.Entities.Domain.Users.Interfaces
{
    public interface IUserService
    {
        User GetProfile(string email);
        Task<User> GetByEmail(string email);
        Task<SignInResult> SignIn(User user, string password, bool remember);
        Task SignOut();
        Task<IdentityResult> Create(User user, string password);
        void UpdateProfile(UserProfileViewModel user);
    }
}

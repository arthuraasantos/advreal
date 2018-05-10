using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Web.Domain.Users;
using Web.Entities.Domain.Users.Interfaces;
using Web.Entities.ViewModels;
using Web.Infra.Security;
using Web.Infra.Validations;

namespace Web.Application
{
    public class UserService: IUserService
    {
        private readonly SignInManager<User> _signInManager;
        private UserManager<User> _userManager;
        private ISecurity _security;

        public UserService(SignInManager<User> signInManager, UserManager<User> userManager, ISecurity security)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _security = security;
        }

        public async Task<User> GetByEmail(string email)
            => await _userManager.FindByEmailAsync(email);

        public async Task<SignInResult> SignIn(User user, string password, bool remember)
        {
            var hash = _security.Criptography(password);
            return await _signInManager.PasswordSignInAsync(user, hash, remember, true);
        }
            
        public Task SignOut()
            => _signInManager.SignOutAsync();

        public async Task<IdentityResult> Create(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new InvalidOperationException();

            var hash = _security.Criptography(password);
            user.SetPassword(hash);
            return await _userManager.CreateAsync(user, hash);
        }

        public void UpdateProfile(UserProfileViewModel userViewModel)
        {
            var user = GetByEmail(userViewModel.Email).Result;
            if (user == null)
                return;

            if (!string.IsNullOrWhiteSpace(userViewModel.FirstName))
                user.FirstName = userViewModel.FirstName;

            if (!string.IsNullOrWhiteSpace(userViewModel.LastName))
                user.LastName = userViewModel.LastName;

            _userManager.UpdateAsync(user);
        }

        public User GetProfile(string email)
        {
            throw new NotImplementedException();
        }
    }
}

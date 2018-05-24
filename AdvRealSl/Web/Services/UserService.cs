using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Web.Domain.Users;
using Web.Entities.Domain.Logs.Enums;
using Web.Entities.Domain.Logs.Interfaces;
using Web.Entities.Domain.Users.Interfaces;
using Web.Entities.ViewModels;
using Web.Infra.EF;
using Web.Infra.Security;
using Web.Infra.Validations;

namespace Web.Services
{
    public class UserService: IUserService
    {
        private readonly SignInManager<User> _signInManager;
        private UserManager<User> _userManager;
        private ISecurity _security;
        private ILogService<User> _logService;

        public UserService(SignInManager<User> signInManager, UserManager<User> userManager, ISecurity security,
                           ILogService<User> logService
            )
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _security = security;
            _logService = logService;
        }

        public async Task<User> GetByEmail(string email)
            => await _userManager.FindByEmailAsync(email);

        public async Task<SignInResult> SignIn(User user, string password, bool remember)
        {
            var hash = _security.Criptography(password);
            var signInResult = await _signInManager.PasswordSignInAsync(user, hash, remember, true);

            if (signInResult.Succeeded)
            {
                RegisterLog(LogType.Event, user, user, "O usuário logou no sistema");
            }
            return signInResult;
        }
            
        public Task SignOut()
            => _signInManager.SignOutAsync();

        public async Task<IdentityResult> Create(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new InvalidOperationException();

            var hash = _security.Criptography(password);
            user.SetPassword(hash);
            var createResult = await _userManager.CreateAsync(user, hash);

            if (createResult.Succeeded)
                RegisterLog(LogType.Creation, user, user, "Criado um usuário");

            return createResult;
        }

        public void UpdateProfile(UserProfileViewModel userViewModel)
        {
            var user = _userManager.FindByIdAsync(userViewModel.UserId.ToString()).Result;
            if (user == null)
                return;

            if (!string.IsNullOrWhiteSpace(userViewModel.FirstName))
                user.FirstName = userViewModel.FirstName;

            if (!string.IsNullOrWhiteSpace(userViewModel.LastName))
                user.LastName = userViewModel.LastName;

            var updateResult = _userManager.UpdateAsync(user).Result;
            if (!updateResult.Succeeded)
                throw new Exception($"Erro ao salvar {updateResult.Errors.ToString()}");

            RegisterLog(LogType.Change, user, user, "Usuário alterado");
        }

        private void RegisterLog(LogType logType, User entity, User executionUser, string message)
        {
            try
            {
                _logService.Register(logType, entity, executionUser, message);
            }
            catch
            {

            }
        }
    }
}

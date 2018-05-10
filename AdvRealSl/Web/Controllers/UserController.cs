using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Domain.Users;
using Web.Entities.Adapters;
using Web.Entities.Commands;
using Web.Entities.Domain.Users.Interfaces;
using Web.Entities.ViewModels;

namespace Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IUserService _userService { get; }
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Profile()
        {
            var currentUser = this.User;
            var user = _userService.GetByEmail(currentUser.Identity.Name).Result;
            var userProfile = UserAdapter.DomainToProfileViewModel(user);

            return View(userProfile);
        }

        [HttpPost]
        public IActionResult Profile(UserProfileViewModel command)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            _userService.UpdateProfile(command);
            
            return RedirectToAction("Profile");
        }

        #region UserAccount
        [AllowAnonymous]
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> New(NewUserCommand command)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Inválido", "Dados para login inválidos");
                return BadRequest();
            }

            var user = new User(command.Email, command.Password);
            var result =
                await _userService.Create(user, user.Password);

            if (result.Succeeded)
            {
                var userCreated = await _userService.GetByEmail(user.Email);

                if (userCreated == null)
                    return StatusCode(StatusCodes.Status500InternalServerError);

                var signInResult = await _userService.SignIn(userCreated, command.Password, true);

                if (signInResult.IsLockedOut)
                    return StatusCode(StatusCodes.Status423Locked);

                return RedirectToAction("Start", "Office");
            }

            return Unauthorized();


        }
        #endregion

        #region Login/Logout

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await _userService.GetByEmail(command.Email);

            if (user == null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            var signInResult = await _userService.SignIn(user, command.Password, command.Remember);

            if (signInResult.IsLockedOut)
                return StatusCode(StatusCodes.Status423Locked);

            return RedirectToAction("Start", "Office");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _userService.SignOut();
            return Ok();
        }
        #endregion

    }
}
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tsi.Template.Core;
using Tsi.Template.Core.Configuration;
using Tsi.Template.Core.Entities;
using Tsi.Template.Core.Models;
using Tsi.Template.Framework.Factories.User;

namespace Tsi.Template.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRegistrationService _userRegistrationService;
        private readonly IAccountModelFactory _accountModelFactory;
        private readonly IUserService _userService;
        private readonly ISettingService _settingService;

        public AccountController(IUserRegistrationService userRegistrationService
            , IAccountModelFactory accountModelFactory
            , IUserService userService
            , ISettingService settingService)
        {
            _userRegistrationService = userRegistrationService;
            _accountModelFactory = accountModelFactory;
            _userService = userService;
            _settingService = settingService;
        }

        public async Task<IActionResult> LoginAsync()
        {
            var model = await _accountModelFactory.PrepareLoginModelAsync(); 

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginModel model, string returnUrl = "")
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var loginResult = await _userRegistrationService.ValidateUser(model);

            switch (loginResult)
            { 
                case Core.Enums.LoginResult.NotFound:
                    ModelState.AddModelError("", "username not found");
                    break;
                case Core.Enums.LoginResult.WrongPassword:
                    ModelState.AddModelError("", "Wrong password");
                    break;
                case Core.Enums.LoginResult.LockedOut:
                    ModelState.AddModelError("", "You have been locked out. Contact your administrator");
                    break;
                case Core.Enums.LoginResult.NotActive:
                    ModelState.AddModelError("", "Your account is not active. Contact your administrator");
                    break;
                case Core.Enums.LoginResult.Success:
                    var settings = await _settingService.LoadSettingAsync<UserSettings>();
                    User user;
                    if (settings.UserNameEnabled)
                    {
                        user = await _userService.GetUserByUsernameAsync(model.Username);
                    }
                    else
                    {
                        user = await _userService.GetUserByEmailAsync(model.Email);
                    } 
                    
                    await _userRegistrationService.SignInAsync(user, model.RememberMe);

                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
            } 

            return  View(model);
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await _userRegistrationService.SignOutAsync();

            return RedirectToAction("Login");
        }

        public async Task<IActionResult> RegisterAsync()
        {
            var model = await _accountModelFactory.PrepareRegisterModelAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(UserRegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var registrationResult = await _userRegistrationService.RegisterUser(model);

            switch (registrationResult)
            {
                case Core.Enums.RegisterResult.UsernameNotProvided:
                    ModelState.AddModelError("", "username not found");
                    break;
                case Core.Enums.RegisterResult.UsernameUsed:
                    ModelState.AddModelError("", "username not found");
                    break;
                case Core.Enums.RegisterResult.EmailNotProvided:
                    ModelState.AddModelError("", "username not found");
                    break;
                case Core.Enums.RegisterResult.EmailUsed:
                    ModelState.AddModelError("", "username not found");
                    break;
                case Core.Enums.RegisterResult.PhoneNumberUsed:
                    ModelState.AddModelError("", "username not found");
                    break;
                case Core.Enums.RegisterResult.Success:
                    var settings = await _settingService.LoadSettingAsync<UserSettings>();

                    if (settings.AdministratorActivationRequired)
                    {
                        return RedirectToAction(nameof(LoginAsync));
                    }
                    else
                    {
                        User user;
                        if (settings.UserNameEnabled)
                        {
                            user = await _userService.GetUserByUsernameAsync(model.Username);
                        }
                        else
                        {
                            user = await _userService.GetUserByEmailAsync(model.Email);
                        } 
                        await _userRegistrationService.SignInAsync(user, false);
                        return RedirectToAction("Index", "Home");
                    }  
            } 
            return View(model);
        }
    }
}

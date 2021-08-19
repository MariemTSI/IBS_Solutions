using System.Threading.Tasks;
using Tsi.Template.Core;
using Tsi.Template.Core.Attributes;
using Tsi.Template.Core.Configuration;
using Tsi.Template.Core.Entities;
using Tsi.Template.Core.Enums;
using Tsi.Template.Core.Helpers;
using Tsi.Template.Core.Models;

namespace Tsi.Template.Services.Common
{
    [Injectable(typeof(IUserRegistrationService))]
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly IUserService _userService;
        private readonly ISettingService _settingService;
        private readonly IUserAuthenticationService _userAuthenticationService;

        public UserRegistrationService(IUserService userService
            , ISettingService settingService
            , IUserAuthenticationService userAuthenticationService)
        {
            _userService = userService;
            _settingService = settingService;
            _userAuthenticationService = userAuthenticationService;
        }

        public async Task<User> GetAuthenticatedUserAsync()
        {
            return await _userAuthenticationService.GetAuthenticatedUserAsync();
        }

        public async Task<RegisterResult> RegisterUser(UserRegisterModel model)
        {
            User user;

            var userSettings = await _settingService.LoadSettingAsync<UserSettings>();

            if (userSettings.UserNameEnabled)
            {
                if (string.IsNullOrWhiteSpace(model.Username))
                {
                    return RegisterResult.UsernameNotProvided;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(model.Email))
                {
                    return RegisterResult.EmailNotProvided;
                }
            }

            user = await _userService.GetUserByUsernameAsync(model.Username);

            if (user is not null)
            {
                return RegisterResult.UsernameUsed;
            }

            user = await _userService.GetUserByEmailAsync(model.Email);

            if (user is not null)
            {
                return RegisterResult.EmailUsed;
            }

            if (!string.IsNullOrWhiteSpace(model.PhoneNumber))
            {
                user = await _userService.GetUserByPhoneNumberAsync(model.PhoneNumber);

                if (user is not null)
                {
                    return RegisterResult.EmailUsed;
                }
            }

            user = new User
            {
                Email = model.Email,
                Username = model.Username,
                NormalizedEmail = CommonHelper.Normalize(model.Email),
                NormalizedUsername = CommonHelper.Normalize(model.Username),
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = string.IsNullOrWhiteSpace(model.PhoneNumber) ? string.Empty : model.PhoneNumber
            };

            if (!userSettings.AdministratorActivationRequired)
            {
                user.Active = true;
            }

            await _userService.CreateUserAsync(user);

            await _userService.CreatePasswordAsync(user, model.Password);

            return RegisterResult.Success;
        }

        public async Task SignInAsync(User user, bool isPersistent)
        {
            await _userAuthenticationService.SignInAsync(user, isPersistent);
        }

        public async Task SignOutAsync()
        {
            await _userAuthenticationService.SignOutAsync();
        }

        public async Task<LoginResult> ValidateUser(LoginModel model)
        {
            User user = await _userService.GetUserByUserNameOrEmail(model.Username, model.Email);

            if (user is null)
            {
                return LoginResult.NotFound;
            }

            if (user.LockedOut)
            {
                return LoginResult.LockedOut;
            }

            if (!user.Active)
            {
                return LoginResult.NotActive;
            }

            var passwordValidation = await _userService.ValidatePassword(user, model.Password);

            switch (passwordValidation)
            {
                case PasswordValidationResult.Valid:

                    if (user.FailedAttempts != 0)
                    {
                        user.FailedAttempts = 0;
                        await _userService.UpdateAsync(user);
                    }

                    return LoginResult.Success;
                case PasswordValidationResult.Expired:
                    return LoginResult.PasswordExpired;
                case PasswordValidationResult.Invalid: 
                case PasswordValidationResult.WrongPassword:
                default:
                    user.FailedAttempts++;
                    
                    var userSetting = await _settingService.LoadSettingAsync<UserSettings>();

                    if(userSetting.TotalFailedLoginAttemps != 0 && user.FailedAttempts >= userSetting.TotalFailedLoginAttemps)
                    {
                        user.LockedOut = true;
                    }
                    await _userService.UpdateAsync(user);
                    return LoginResult.WrongPassword;
            }
        }

    }
}

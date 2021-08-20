using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Tsi.Template.Core;
using Tsi.Template.Core.Abstractions;
using Tsi.Template.Core.Attributes;
using Tsi.Template.Core.Configuration;
using Tsi.Template.Core.Entities;
using Tsi.Template.Core.Exceptions;
using Tsi.Template.Core.Models;
using Tsi.Template.Infrastructure.Repository; 

namespace Tsi.Template.Services.Common
{
    [Injectable(typeof(IUserService))]
    public class UserService : IUserService
    {
        #region Fields

        private readonly IPasswordHasher _passwordHasher;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<UserRole> _userRoleRepository;
        private readonly IRepository<UserRoleMapping> _userRoleMappingRepository;
        private readonly IRepository<UserPassword> _userPasswordRepository;
        private readonly ISettingService _settingService;

        #endregion

        #region Ctor

        public UserService(IPasswordHasher passwordHasher
            , IRepository<User> userRepository
            , IRepository<UserRole> userRoleRepository
            , IRepository<UserRoleMapping> userRoleMappingRepository, IRepository<UserPassword> userPasswordRepository, ISettingService settingService)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _userRoleMappingRepository = userRoleMappingRepository;
            _userPasswordRepository = userPasswordRepository;
            _settingService = settingService;
        }

        #endregion

        #region User Loading

        public async Task<User> GetUserByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return null;
            }

            var normalizedEmail = email.Trim().ToUpper();
            return await _userRepository.GetAsync(u => u.NormalizedEmail.Equals(email));
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }

            var normalizedUserName = username.Trim().ToUpper();
            return await _userRepository.GetAsync(u => u.NormalizedUsername.Equals(normalizedUserName));
        }

        public async Task<User> GetUserByPhoneNumberAsync(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return null;
            }

            var normalizedUserName = phoneNumber.Trim().ToUpper();
            return await _userRepository.GetAsync(u => u.PhoneNumber.Equals(normalizedUserName));
        }

        public async Task<User> GetUserByUserNameOrEmail(string username, string email)
        {
            var userSettings = await _settingService.LoadSettingAsync<UserSettings>();

            User user;

            if (userSettings.UserNameEnabled)
            {
                user = await GetUserByUsernameAsync(username);
            }
            else
            {
                user = await GetUserByEmailAsync(email);
            }

            return user;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        #endregion


        #region User Crud

        public async Task CreateUserAsync(User user)
        {
            if (user is null)
            {
                return;
            }

            await _userRepository.AddAsync(user);
        }

        #endregion


        #region User Roles

        public async Task<IEnumerable<UserRole>> GetRolesAsync(User user)
        {
            if (user is null)
            {
                return null;
            }

            var userRoleMappings = await _userRoleMappingRepository.GetManyAsync(userRoleMapping => userRoleMapping.UserId == user.Id);

            if (userRoleMappings is null || !userRoleMappings.Any())
            {
                return null;
            }

            var result = new List<UserRole>();

            foreach (var userRoleMapping in userRoleMappings)
            {
                var userRole = await _userRoleRepository.GetAsync(userRole => userRole.Id == userRoleMapping.UserRoleId);

                if (userRole is not null)
                {
                    result.Add(userRole);
                }
            }

            return result;
        }

        public async Task AssignUserToRoleAsync(User user, string userRoleSystemName)
        {
            if (string.IsNullOrWhiteSpace(userRoleSystemName))
            {
                throw new CoreException("Argument null exception in GetPermissionAndUserRoleCoupleAsync", new ArgumentNullException(nameof(userRoleSystemName), "Cannot be empty"));
            }

            var userRole = await _userRoleRepository.GetAsync(userRole => userRole.SystemName.Equals(userRoleSystemName));

            if (userRole is null)
            {
                throw new CoreException("Argument null exception in GetPermissionAndUserRoleCoupleAsync", new ApplicationException($"Role with system name ({userRoleSystemName}) not found."));
            }

            var userRoleMapping = await _userRoleMappingRepository.GetAsync(userRoleMapping => userRoleMapping.UserRoleId == userRole.Id && userRoleMapping.UserId == user.Id);

            if (userRoleMapping is not null)
            {
                return;
            }

            await _userRoleMappingRepository.AddAsync(new()
            {
                UserId = user.Id,
                UserRoleId = userRole.Id
            });
        }

        public async Task AssignUserToRolesAsync(User user, IEnumerable<string> userRolesSystemNames)
        {
            await _userRoleMappingRepository.DeleteAsync(userRoleMapping => userRoleMapping.UserId == user.Id);

            foreach (var userRole in userRolesSystemNames)
            {
                await AssignUserToRoleAsync(user, userRole);
            }
        }

        public async Task<bool> IsUserAdminAsync(User user)
        {
            if (user is null)
            {
                return false;
            }

            var adminRole = await _userRoleRepository.GetAsync(role => role.SystemName.Equals(CoreDefaults.AdministratorRole));

            if (adminRole is null)
            {
                // we make sure that the admin role is created
                await _userRoleRepository.AddAsync(new()
                {
                    SystemName = CoreDefaults.AdministratorRole,
                    Name = "Administrator"
                });

                return false;
            }
            var roles = await GetRolesAsync(user);
            if(roles is null || !roles.Any())
            {
                return false;
            }

            foreach (var item in roles)
            {
                if (item.SystemName.Equals(CoreDefaults.AdministratorRole))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion


        #region Password Methods

        public async Task<PasswordValidationResult> ValidatePassword(User user, string password)
        {
            var settings = await _settingService.LoadSettingAsync<UserSettings>();

            var currentPassword = await GetLastPasswordAsync(user);

            if(currentPassword is null)
            {
                return PasswordValidationResult.Invalid;
            }

            if (settings.PasswordExpires)
            {
                var expiringDate = currentPassword.CreatedOnUtc.AddDays(settings.PasswordLifeTime);

                if(expiringDate < DateTime.UtcNow)
                {
                    return PasswordValidationResult.Expired;
                }
            }

            if(currentPassword.Password.Equals(_passwordHasher.GenerateHash(password, currentPassword.Salt)))
            {
                return PasswordValidationResult.Valid;
            }
            else
            {
                return PasswordValidationResult.WrongPassword;
            } 
        }

        public async Task<UserPassword> GetLastPasswordAsync(User user)
        {
            return (await _userPasswordRepository.GetAllAsync(password => password.CreatedOnUtc, true)).FirstOrDefault();
        }

        public async Task CreatePasswordAsync(User user, string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new CoreException("Password cannot be empty");
            }

            if (user is null)
            {
                throw new CoreException("User cannot be empty");
            }

            var userPassword = new UserPassword()
            {
                CreatedOnUtc = DateTime.UtcNow
            };

            userPassword.Salt = _passwordHasher.GenerateSalt();
            userPassword.Password = _passwordHasher.GenerateHash(password, userPassword.Salt);
            userPassword.UserId = user.Id;

            await _userPasswordRepository.AddAsync(userPassword);
        }

        public async Task<bool> ChangeUserPasswordAsync(User user, string oldPassword, string newPassword)
        {
            // Get all old passwords
            var currentPassword = await GetLastPasswordAsync(user);

            if (currentPassword is null)
            {
                throw new CoreException("User have no password");
            }

            // Validate old password
            if (!currentPassword.Password.Equals(_passwordHasher.GenerateHash(oldPassword, currentPassword.Salt)))
            {
                // wrong old password
                return false;
            }

            await CreatePasswordAsync(user, newPassword);

            return true;
        }

        public async Task UpdateAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

        #endregion

    }
}

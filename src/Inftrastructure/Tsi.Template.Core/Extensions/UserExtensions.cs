

using Tsi.Template.Core.Entities;
using Tsi.Template.Core.Models;

namespace Tsi.Template.Helpers.Common
{
    public static class UserExtensions
    {
        public static UserModel ToModel(this User input) => new()
        {
            Id = input.Id,
            FirstName = input.FirstName,
            LastName = input.LastName,
            Username = input.Username,
            Email = input.Email,
            PhoneNumber = input.PhoneNumber
        };
    }
}

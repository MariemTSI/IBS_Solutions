using Tsi.Template.Core.Abstractions;

namespace Tsi.Template.Core.Entities
{
    public class User : BaseEntity, ICommonEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string NormalizedUsername { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public string PhoneNumber { get; set; }
        public bool LockedOut { get; set; }
        public bool Active { get; set; }
        public int FailedAttempts { get; set; }
        public int? LanguageId { get; set; }
        public string LastIpAdress { get; set; }
        public string Description => $"{FirstName}, {LastName}";
    }
}

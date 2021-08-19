using Tsi.Template.Core.Abstractions;

namespace Tsi.Template.Core.Configuration
{
    public class UserSettings : ISettings
    {
        public bool UserNameEnabled { get; set; }
        public bool AdministratorActivationRequired { get; set; }
        public int CookieLifetime { get; set; }
        public bool PasswordExpires { get; set; }
        public int PasswordLifeTime { get; set; } 
        public int TotalFailedLoginAttemps { get; set; }
    }
}

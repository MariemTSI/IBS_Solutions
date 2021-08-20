namespace Tsi.Template.Core.Models
{
    public record LoginModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool UserNameEnabled { get; set; }
        public bool RememberMe { get; set; }
    }
}

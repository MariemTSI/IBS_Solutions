using Tsi.Template.Core.Entities;

namespace Tsi.Template.Core.Defaults
{
    public static class StandardPermissionProvider
    {
        public static Permission ManageDepartements => new()
        {
            SystemName = "Managae_Department",
            Name = "Permissions.ManageDepartments"
        };

        public static readonly Permission AccessAdminPanel = new() { Name = "Access admin area", SystemName = "AccessAdminPanel" };
    }
}

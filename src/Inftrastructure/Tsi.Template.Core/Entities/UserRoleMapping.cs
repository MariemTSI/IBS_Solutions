using Tsi.Template.Core.Abstractions;

namespace Tsi.Template.Core.Entities
{
    public class UserRoleMapping : BaseEntity, ICommonEntity
    {
        public int UserId { get; set; }
        public int UserRoleId { get; set; }
    }
}

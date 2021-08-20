using Tsi.Template.Core.Abstractions;

namespace Tsi.Template.Core.Entities
{
    public class UserRole : BaseEntity, ICommonEntity
    {
        public string SystemName { get; set; }
        public string Name { get; set; } 
    }
}

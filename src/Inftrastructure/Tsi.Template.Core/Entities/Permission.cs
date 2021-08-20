using Tsi.Template.Core.Abstractions;

namespace Tsi.Template.Core.Entities
{
    public class Permission: BaseEntity, ICommonEntity
    { 
        public string Name { get; set; } 

        public string SystemName { get; set; }
    }
}

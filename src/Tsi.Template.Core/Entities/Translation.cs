using Tsi.Template.Core.Abstractions;

namespace Tsi.Template.Core.Entities
{
    public class Translation : BaseEntity, ICommonEntity
    {
        public int LanguageId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; } 
    }
}

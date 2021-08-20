using Tsi.Template.Core.Abstractions;

namespace Tsi.Template.Core.Entities
{
    public class Currency : BaseEntity, ICommonEntity
    {
        public string Name { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Rate { get; set; }
        public string CustomFormatting { get; set; }
    }
}

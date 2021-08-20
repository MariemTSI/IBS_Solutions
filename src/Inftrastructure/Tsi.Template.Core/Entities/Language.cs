using Tsi.Template.Core.Abstractions;

namespace Tsi.Template.Core.Entities
{
    public class Language : BaseEntity, ICommonEntity, IDisplayedOrdered
    {
        public string Name { get; set; }

        public string LanguageCulture { get; set; }

        public string UniqueSeoCode { get; set; }

        public string FlagImageFileName { get; set; }

        public bool Rtl { get; set; }

        public int DisplayOrder { get; set; }
    }
}

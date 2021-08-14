using System.Threading.Tasks;
using Tsi.Template.Core;
using Tsi.Template.Core.Attributes;

namespace Tsi.Template.CoreServices.Localization
{
    [Injectable(typeof(ILocalizationService))]
    public class LocalizationService : ILocalizationService
    {
        public Task<string> LoadResource(string key)
        {
            return Task.FromResult($"{key} - this message comes from the implemented localization service");
        }
    }
}

using System.Threading.Tasks;

namespace Tsi.Template.Core
{
    public interface ILocalizationService
    {
        Task<string> LoadResource(string key);
    }
}

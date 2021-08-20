using Microsoft.AspNetCore.Mvc.Razor;
using Tsi.Template.Core;
using Tsi.Template.Framework.Localization;

namespace Tsi.Template.Framework.Razor
{
    public abstract class TsiRazorPage<TModel>: RazorPage<TModel>
    {
        private ILocalizationService _localizationService;
        private Localizer _localizer;


        public Localizer T
        {
            get
            {
                if (_localizationService == null)
                {
                    _localizationService = EngineContext.Current.Resolve<ILocalizationService>();
                }

                if (_localizer == null)
                {
                    _localizer = (key, args) =>
                    {
                        var resFormat = _localizationService.GetResourceAsync(key).GetAwaiter().GetResult();
                        if (string.IsNullOrEmpty(resFormat))
                        {
                            return new LocalizedString(key);
                        }
                        return new LocalizedString((args == null || args.Length == 0)
                            ? resFormat
                            : string.Format(resFormat, args));
                    };
                }
                return _localizer;
            }
        }
    }

    public abstract class TsiRazorPage : TsiRazorPage<dynamic>
    {
    }
}

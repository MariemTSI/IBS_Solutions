using Tsi.Template.Core;
using Tsi.Template.Data;
using Tsi.Template.Helpers;
using Tsi.Template.Services;
using Tsi.Template.Validation;

namespace Tsi.Template.Web.Installers
{
    public class AssemblyLoader
    {
        public static void LoadAssemblies()
        {
            EngineContext.Current.LoadAssembly(typeof(Startup));
            EngineContext.Current.LoadAssembly(typeof(AssemblyReferencerServices));
            EngineContext.Current.LoadAssembly(typeof(AssemblyReferencerHelpers)); 
            EngineContext.Current.LoadAssembly(typeof(ValidatorAssemblyReferencer));
            EngineContext.Current.LoadAssembly(typeof(ApplicationContext)); 
        }
    }
}

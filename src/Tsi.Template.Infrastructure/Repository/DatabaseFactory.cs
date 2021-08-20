using Microsoft.Extensions.Configuration;
using System;
using Tsi.Template.Core;
using Tsi.Template.Infrastructure.Data;

namespace Tsi.Template.Infrastructure.Repository
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        public CoreContext DataContext { get; }

        public DatabaseFactory(IConfiguration configuration)
        { 
            var context = Activator.CreateInstance(EngineContext.Current.ContextType, configuration);
            DataContext = (CoreContext)context;
        }
        protected override void DisposeCore()
        {
            DataContext?.Dispose();
        }
    }

}

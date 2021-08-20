
using System;
using Tsi.Template.Infrastructure.Data;

namespace Tsi.Template.Infrastructure.Repository
{
    public interface IDatabaseFactory : IDisposable
    {
        CoreContext DataContext { get; }
    } 
}

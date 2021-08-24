using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tsi.Template.Core.Attributes;
using Tsi.Template.ViewModels;

namespace Tsi.Template.Web.Factories
{
    [Injectable(typeof(IPaysModelFactory))]
    public class PaysModelFactory : IPaysModelFactory
    {
        public Task<PaysViewModel> PreparePaysViewModelAsync() => Task.FromResult(new PaysViewModel());
    }
}

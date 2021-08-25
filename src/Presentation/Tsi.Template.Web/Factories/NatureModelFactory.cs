using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tsi.Template.Core.Attributes;
using Tsi.Template.ViewModels;

namespace Tsi.Template.Web.Factories
{
    [Injectable(typeof(INatureModelFactory))]
    public class NatureModelFactory : INatureModelFactory
    {
        public Task<NatureViewModel> PrepareNatureViewModelAsync() => Task.FromResult(new NatureViewModel());
    }
}

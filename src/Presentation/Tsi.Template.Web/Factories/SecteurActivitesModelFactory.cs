using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tsi.Template.Core.Attributes;
using Tsi.Template.ViewModels;

namespace Tsi.Template.Web.Factories
{
    [Injectable(typeof(ISecteurActivitesModelFactory))]
    public class SecteurActivitesModelFactory : ISecteurActivitesModelFactory
    {
        public Task<SecteursActivitesViewModel> PrepareSecteurActivitesViewModelAsync() => Task.FromResult(new SecteursActivitesViewModel());

    }
}

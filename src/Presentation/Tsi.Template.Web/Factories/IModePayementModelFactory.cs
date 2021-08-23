using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tsi.Template.Domain;
using Tsi.Template.ViewModels;

namespace Tsi.Template.Web.Factories
{
    public interface IModePayementModelFactory
    {
        Task<ModePayementViewModel> PrepareModePayementViewModelAsync();
    }
}

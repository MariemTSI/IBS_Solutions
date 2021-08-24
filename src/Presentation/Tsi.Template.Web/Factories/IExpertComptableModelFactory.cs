using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tsi.Template.ViewModels;

namespace Tsi.Template.Web.Factories
{
    public interface IExpertComptableModelFactory
    {
        Task<ExpertComptableViewModel> PrepareExpertComptableViewModelAsync();
        Task<ExpertComptableViewModel> PrepareExpertComptableCreateModelAsync(int id);

        Task<ExpertComptableViewModel> PopulatePayssSelectListAsync(ExpertComptableViewModel model);
    }
}

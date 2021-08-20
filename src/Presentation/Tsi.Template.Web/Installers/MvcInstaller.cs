using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tsi.Template.Core.Abstractions;
using Tsi.Template.Validation;

namespace Tsi.Template.Web.Installers
{
    public class MvcInstaller : IInstaller
    {
        public int Order => 0;

        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ValidatorAssemblyReferencer>());
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tsi.Template.Core;
using Tsi.Template.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http; 
using Tsi.Template.Core.Exceptions;
using System.Linq;
using System.Security.Claims;
using System;
using Tsi.Template.CoreServices;
using Tsi.Template.Core.Extensions;
using Tsi.Template.Framework.Routing;

namespace Tsi.Template.Web.Extensions
{
    public static class StartupExtensions
    {
        public static void ConfigureApplicationServices(this IServiceCollection services, IConfiguration Configuration, Action loadingAssembliesAction)
        {
            EngineContext.Create();

            if(loadingAssembliesAction is null)
            {
                throw new CoreException("Cannot initialize application services without configuring the EngineContext Assemblies");
            }

            loadingAssembliesAction();

            LoadAssemblies();

            services.AddHttpContextAccessor();

            services.InstallAuthentification();

            services.RegisterApplicationDependencies(Configuration);
        }

        public static void InstallAuthentification(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(
                CookieAuthenticationDefaults.AuthenticationScheme, (options) =>
                {
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Account/Logout";
                    options.Events = new CookieAuthenticationEvents
                    {
                        OnValidatePrincipal = async context =>
                        {
                            // Pull database from registered DI services.
                            var userRepository = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                            var registrationService = context.HttpContext.RequestServices.GetRequiredService<IUserRegistrationService>();
                            var userPrincipal = context.Principal;

                            var userIdCLaim = userPrincipal.Claims.Where(claim => claim.Type == ClaimTypes.PrimarySid).FirstOrDefault();

                            int id = 0;

                            if (string.IsNullOrEmpty(userIdCLaim.Value) || userIdCLaim.Equals("0") || !Int32.TryParse(userIdCLaim.Value, out id))
                            {
                                context.RejectPrincipal();
                                await registrationService.SignOutAsync();
                            }

                            var user = await userRepository.GetUserByIdAsync(id);

                            if (user is null || !user.Active)
                            {
                                context.RejectPrincipal();
                                await registrationService.SignOutAsync();
                            }
                        }
                    };
                });

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
        }

        

        private static void LoadAssemblies()
        {
            EngineContext.Current.LoadAssembly(typeof(StartupExtensions));  
            EngineContext.Current.LoadAssembly(typeof(AssemblyReferencerInfrastructure)); 
            EngineContext.Current.LoadAssembly(typeof(EngineContext));
            EngineContext.Current.LoadAssembly(typeof(AssemblyReferencerCoreServices));
        }

        public static void ConfigureApplicationPipeline(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            EngineContext.Current.SetupServiceProvider(app.ApplicationServices);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapAreaControllerRoute("AdminRoutes", "Admin", "{controller=Home}/{action=Index}/{id?}");
                 
                endpoints.RegisterRoutes();
                 
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

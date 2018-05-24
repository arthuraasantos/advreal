using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web.Services;
using Web.Domain.Users;
using Web.Entities.Domain.Users.Interfaces;
using Web.Infra.EF;
using Web.Infra.Security;
using Web.Entities.Domain.Logs.Interfaces;
using Web.Infra.Logs;

namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AdvContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddIdentity<User, IdentityRole<Guid>>(options => 
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<AdvContext>()
            .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options => options.LoginPath = "/User/Login");

            services = DependencyInjection(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes => 
            {
                routes.MapRoute(
                        name: "default",
                        template: "{controller=Office}/{action=Start}/{id?}");
            });


        }

        private IServiceCollection DependencyInjection(IServiceCollection services)
        {
            //Context
            services.AddScoped(typeof(IAdvContext), provider => provider.GetService<AdvContext>());

            //Services 
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILogService<User>, LogService<User>>();

            // Infra
            services.AddScoped<ISecurity, Security>();

            // Repositories
            services.AddScoped<ILogRepository, LogRepository>();
            return services;
        }
    }
}

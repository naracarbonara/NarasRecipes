using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Naras_Kitchen.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Naras_Kitchen.Repositories.Interfaces;
using Naras_Kitchen.Repositories;
using Naras_Kitchen.Services.Interfaces;
using Naras_Kitchen.Services;
using Microsoft.AspNetCore.Authorization;

namespace Naras_Kitchen
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdministratorRole",
                     policy => policy.RequireRole("Administrator"));
            });

            //services.AddAuthorization(options =>
            //{
            //    options.DefaultPolicy = new AuthorizationPolicyBuilder()
            //        .RequireAuthenticatedUser()
            //        .Build();
            //});

            services.AddDbContext<RecipeDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("NarasRecipesTest2")));

            services.AddTransient<IRecipesRepository, RecipesRepository>();
            services.AddTransient<IRecipesService, RecipesService>();
            services.AddTransient<IUserRepository, UserRepsitory>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ICommentService, CommentService >();
            services.AddTransient<IRatingRepository, RatingRepository>();
            services.AddTransient<IRatingService, RatingService>();
            services.AddTransient<IWeeklyMenuRepository, WeeklyMenuRepository>();
            services.AddTransient<IWeeklyMenuService, WeeklyMenuService>();
            services.AddTransient<ICheckingRepository, CheckingRepository>();
            services.AddTransient<ICheckingService, CheckingSErvice>();
            services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<RecipeDbContext>();



            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);



        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Home}/{id?}");
            });
        }
    }
}

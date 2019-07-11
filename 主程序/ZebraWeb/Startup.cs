using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Logging;

using ELearning.ORM.SqlServer;
using ELearning.UserAndRole;
 

using Microsoft.AspNetCore.Authorization;
using ELearning.Entities;
using ELearning.DataAccess;

namespace ELZebra
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
            services.AddDbContext<SqlServerDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("ELearningConnection")));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
              //.AddDefaultUI(UIFramework.Bootstrap4)
              .AddEntityFrameworkStores<SqlServerDbContext>()
              .AddDefaultTokenProviders();
            services.AddDistributedMemoryCache();
            services.AddSession();
        

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;

                // Default SignIn settings.
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);

                options.LoginPath = "/Account/Logon";
                options.AccessDeniedPath = "/Account/AccessDenied";
                //options.SlidingExpiration = true;
            });
            // 限制表单上传字节大小，600 兆
            services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = 1000000000;
            });

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            #region 配置依赖注入映射服务
            services.AddScoped<IEntityRepository<City>, EntityRepository<City>>();
            //services.AddScoped<IEntityRepository<BusinessFile>, EntityRepository<BusinessFile>>();
            //services.AddScoped<IEntityRepository<BusinessVideo>, EntityRepository<BusinessVideo>>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseMvc();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseSession();


            app.UseMvc(routes =>
            {
                // 添加区域 Admin 路由
                routes.MapAreaRoute(
                    name: "AdminArea",
                    areaName: "Admin",
                    template: "Admin/{controller=Themes}/{action=Index}/{id?}");

                // 缺省路由
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Index}/{action=index}/{id?}");
            });
        }
    }
}

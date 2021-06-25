using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using Amazon;
using Amazon.S3;
using Microsoft.EntityFrameworkCore;
using Web.Bussiness.Services.AccountManagement;
using Web.Bussiness.Services.AdminManagement;
using Web.Bussiness.Services.CommonManagement.EmailManagement;
using Web.Bussiness.Services.CommonManagement.ProductManagement;
using Web.Bussiness.Services.GamesManagement;
using Web.Bussiness.Services.OrdersManagement;
using Web.Bussiness.Services.RoleAdminManagement;
using Web.Bussiness.Services.UserManagement;
using Web.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Web.UI
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
            services.AddMvc();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "My API", Version = "v2" });
            });
            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(Configuration["Data:ConnectionStrings:DefaultConnection"]));
            services.AddSingleton<IS3Service, S3Service>();
            services.AddAWSService<IAmazonS3>();
            services.AddDefaultAWSOptions(
                new Amazon.Extensions.NETCore.Setup.AWSOptions
                {
                    Region = RegionEndpoint.GetBySystemName(Configuration["AWS:regionServer"])
                }
            );

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = "Cookies";
                    options.DefaultChallengeScheme = "oidc";
                })
                .AddCookie("Cookies")
                .AddOpenIdConnect("oidc", options =>
                {
                    options.SignInScheme = "Cookies";

                    options.Authority = "http://localhost:5000";
                    options.RequireHttpsMetadata = false;
                    options.ClientId = "testclient";
                    options.ClientSecret = "secret";
                    options.ResponseType = "code id_token";
                    options.SaveTokens = true;
                    options.GetClaimsFromUserInfoEndpoint = true;

                    options.Scope.Add("testapi");
                    options.Scope.Add("offline_access");
                });

            //configuration of password:
            services.AddIdentity<AppUser, IdentityRole>(opts => {
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
                opts.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<AppIdentityDbContext>()
              .AddDefaultTokenProviders();
            services.AddTransient<IAdminService, AdminService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleAdminService, RoleAdminService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IObjectsManipulationGamesService, GamesService>();
            services.AddTransient<IDataManipulationGameService, GamesService>();
            services.AddTransient<IOrdersService, OrdersService>();
            services.AddTransient<ITokenService, TokenService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            Migrate(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V2");
            });

            app.UseStatusCodePages();

            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseDeveloperExceptionPage();

            app.UseAuthentication();
        }

        private static void Migrate(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetRequiredService<AppIdentityDbContext>();

            context.Database.Migrate();
        }
    }
}

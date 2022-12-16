using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfLibrary1.Services.Services.Implements;
using WpfLibrary1.Services.Services.Interfaces;
using WpfSample1.Configuration;
using WpfSample1.Configuration.Constants;
using WpfSample1.Configuration.Implements;
using WpfSample1.Configuration.Interfaces;
using WpfSample1.Data;
using WpfSample1.Services.Implements;
using WpfSample1.Services.Interfaces;

namespace WpfSample1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }
        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {

            var rootConfiguration = CreateRootConfiguration();
            services.AddSingleton(rootConfiguration);

            AddAuthenticationServices(services, rootConfiguration.AdminConfiguration);
            RegisterAuthorization(services, rootConfiguration);

            //services.Configure<AppSettings>(Configuration.GetSection(nameof(AppSettings)));
            services.AddDbContext<SampleDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient(typeof(MainWindow));
            services.AddScoped<ISampleService, SampleService>();
            services.AddScoped<IBODServices, BODServices>();
            services.AddAutoMapper(typeof(App));
            

        }

        /// <summary>
        /// The CreateRootConfiguration.
        /// </summary>
        /// <returns>The <see cref="IRootConfiguration"/>.</returns>
        protected IRootConfiguration CreateRootConfiguration()
        {
            var rootConfiguration = new RootConfiguration();
            Configuration.GetSection(ConfigurationConsts.AdminConfigurationKey).Bind(rootConfiguration.AdminConfiguration);
            return rootConfiguration;
        }


        private void AddAuthenticationServices(IServiceCollection services, AdminConfiguration adminConfiguration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = AuthenticationConsts.OidcAuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultForbidScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
                    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                        options =>
                        {
                            options.Cookie.Name = adminConfiguration.IdentityAdminCookieName;
                            options.Cookie.SameSite = SameSiteMode.None;
                            //options.Cookie.SecurePolicy = CookieSecurePolicy.None;
                        })

                    .AddOpenIdConnect(AuthenticationConsts.OidcAuthenticationScheme, options =>
                    {
                        options.Authority = adminConfiguration.IdentityServerBaseUrl;
                        options.RequireHttpsMetadata = adminConfiguration.RequireHttpsMetadata;
                        options.ClientId = adminConfiguration.ClientId;
                        options.ClientSecret = adminConfiguration.ClientSecret;
                        options.ResponseType = adminConfiguration.OidcResponseType;
                        options.Scope.Clear();
                        foreach (var scope in adminConfiguration.Scopes)
                        {
                            options.Scope.Add(scope);
                        }

                        options.ClaimActions.MapJsonKey(adminConfiguration.TokenValidationClaimRole, adminConfiguration.TokenValidationClaimRole, adminConfiguration.TokenValidationClaimRole);
                        options.SaveTokens = true;
                        options.GetClaimsFromUserInfoEndpoint = true;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            NameClaimType = adminConfiguration.TokenValidationClaimName,
                            RoleClaimType = adminConfiguration.TokenValidationClaimRole
                        };

                        options.Events = new OpenIdConnectEvents
                        {
                            OnMessageReceived = context => OnMessageReceived(context, adminConfiguration),
                            OnRedirectToIdentityProvider = context => OnRedirectToIdentityProvider(context, adminConfiguration),
                            OnAuthenticationFailed = context =>
                            {
                                if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                                {
                                    context.Response.Headers.Add("Token-Expired", "true");
                                }
                                return Task.CompletedTask;
                            }
                        };
                    });
        }


        /// <summary>
        /// The OnMessageReceived.
        /// </summary>
        /// <param name="context">The context<see cref="MessageReceivedContext"/>.</param>
        /// <param name="adminConfiguration">The adminConfiguration<see cref="AdminConfiguration"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        private Task OnMessageReceived(MessageReceivedContext context, AdminConfiguration adminConfiguration)
        {
            context.Properties.IsPersistent = true;
            context.Properties.ExpiresUtc = new DateTimeOffset(DateTime.Now.AddHours(adminConfiguration.IdentityAdminCookieExpiresUtcHours));
            return Task.FromResult(0);
        }

        /// <summary>
        /// The OnRedirectToIdentityProvider.
        /// </summary>
        /// <param name="n">The n<see cref="RedirectContext"/>.</param>
        /// <param name="adminConfiguration">The adminConfiguration<see cref="AdminConfiguration"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        private Task OnRedirectToIdentityProvider(RedirectContext n, AdminConfiguration adminConfiguration)
        {
            n.ProtocolMessage.RedirectUri = adminConfiguration.IdentityAdminRedirectUri;
            return Task.FromResult(0);
        }

        /// <summary>
        /// The RegisterAuthorization.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <param name="rootConfiguration">The rootConfiguration<see cref="IRootConfiguration"/>.</param>
        private void RegisterAuthorization(IServiceCollection services, IRootConfiguration rootConfiguration)
        {
        }

    }
}

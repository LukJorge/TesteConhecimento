using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TesteFCamara.Extentions;
using TesteFCamara.Identity;
using Microsoft.IdentityModel.Tokens;

namespace TesteFCamara
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
            services.ConfigureDependencies();

            services.AddIdentityServer()
                    .AddInMemoryApiScopes(IdentityConfig.ApiScopes)
                    .AddInMemoryClients(IdentityConfig.Clients)
                    .AddDeveloperSigningCredential(); 

            services.AddControllers();

            // accepts any access token issued by identity server
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:6001";

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });

            // adds an authorization policy to make sure the token is for scope 'api1'
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "TestFCamara");
                });
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseRouting();

            app.UseIdentityServer();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                // endpoints.MapControllers().RequireAuthorization("ApiScope");
            });
        }
    }
}

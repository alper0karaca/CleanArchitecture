using CleanArchitecture.Infrastructure.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace CleanArchitecture.WebApi.Configurations;

public sealed class AuthorizeServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder hostBuilder)
    {
        services.AddAuthentication().AddJwtBearer();
        services.AddScoped<IAuthorizationHandler, RoleRequirementHandler>();
        services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", policyBuilder =>
            {
                policyBuilder.Requirements.Add(new RoleRequirement("Admin"));
            });
    
            options.AddPolicy("Moderator", policyBuilder =>
            {
                policyBuilder.Requirements.Add(new RoleRequirement("Moderator"));
            });
    
            options.AddPolicy("Uye", policyBuilder =>
            {
                policyBuilder.Requirements.Add(new RoleRequirement("Uye"));
            });
        }); 
        
        services.AddScoped<IAuthorizationMiddlewareResultHandler, CustomAuthorizationMiddlewareResultHandler>();
    }
}
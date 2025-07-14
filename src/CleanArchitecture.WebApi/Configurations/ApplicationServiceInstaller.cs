using CleanArchitecture.Application.Behaviors;
using FluentValidation;
using MediatR;

namespace CleanArchitecture.WebApi.Configurations;

public sealed class ApplicationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder hostBuilder)
    {
        // CQRS için
        services.AddMediatR(conf => 
            conf.RegisterServicesFromAssembly(
                typeof(CleanArchitecture.Application.AssemblyReference).Assembly));
        
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        
        services.AddValidatorsFromAssembly(
            typeof(CleanArchitecture.Application.AssemblyReference).Assembly);
    }
}
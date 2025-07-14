using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.Infrastructure.Authorization;

public class CustomAuthorizationMiddlewareResultHandler : IAuthorizationMiddlewareResultHandler
{
    private readonly AuthorizationMiddlewareResultHandler _defaultHandler = new();
    
    public async Task HandleAsync(RequestDelegate next, HttpContext context, AuthorizationPolicy policy,
        PolicyAuthorizationResult authorizeResult)
    {
        if (authorizeResult.Forbidden && context.User.Identity?.IsAuthenticated == true) 
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            context.Response.ContentType = "application/json";
            
            var response = new
            {
                status = 403,
                message = "Bu işlem için yetkiniz bulunmamaktadır."
            };

            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
            return;
        }
        await _defaultHandler.HandleAsync(next, context, policy, authorizeResult);
    }
}
using ApiKey.Middlewares;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ApiKey.Middlewares;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private readonly List<ApiKeyDefinition> _apiKeys;

    public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _apiKeys = configuration.GetSection("ApiKeys").Get<List<ApiKeyDefinition>>();
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue("X-API-KEY", out var extractedKey))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("API Key is missing.");
            return;
        }

        var matchedKey = _apiKeys.FirstOrDefault(k => k.Key == extractedKey);
        if (matchedKey == null)
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Unauthorized API Key.");
            return;
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, matchedKey.Owner),
            new Claim(ClaimTypes.Role, matchedKey.Role)
        };

        var identity = new ClaimsIdentity(claims, "ApiKey");
        context.User = new ClaimsPrincipal(identity);

        await _next(context);
    }
}
